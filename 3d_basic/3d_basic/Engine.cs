using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics;

namespace _3d_basic
{
    enum camera { constant, track, bounded };
    class Engine
    {
        public PictureBox p_box;
        private DirectBitmap btm;
        private System.Windows.Forms.Timer my_timer;
        private int[,] z_buf;
        private Matrix<double> view_matrix, projection_matrix;
        private double 
            n = 1, //near clipping
            f = 100, //far clipping
            fov = (1 / 4.0) * Math.PI, //camera angle (leans)
            a; //aspect ratio
        private List<Mesh> meshes;
        private const int z_depth = 10000;
        private List<Light> lights;
        public BackgroundWorker bgr_worker;
        private double current_angle = 0, r = 10;
        public bool first_frame = true;
        public double ka = 0.15, kd = 0.2, ks = 0.5, surface_factor_n = 20;
        public camera cam_mode = camera.constant;
        private Vector<double> static_camera_position = CreateVector.DenseOfArray(new double[] { 0, 2, 20 });
        public bool sun=true, spotlight=true;
        public double spotlight_angle = 0.8, spotlight_n = 10;
        private Func<int, int, List<Point>, List<ColorDouble>, SurfaceFactors, ColorDouble, List<Vector<double>>, List<Vector<double>>, List<Light>, ColorDouble, ColorDouble> shading_func = FillPolyHelper.ConstantShading;
        public Engine(PictureBox _p_box, BackgroundWorker _bgr_worker) 
        {
            bgr_worker = _bgr_worker;
            p_box = _p_box;
            btm = new DirectBitmap(p_box.Width, p_box.Height);
            p_box.Image = btm.Bitmap;
            z_buf = new int[p_box.Width, p_box.Height];
            FlushBuf();
            SetTimer(1);
            a = (double)p_box.Height / p_box.Width;
            FillProjectionMatrix();
            InitializeMeshes();
            FirstSetSurfaceFactors();
        }

        private void InitializeMeshes()
        {
            meshes = new List<Mesh>();
            SimpleBabylon cube = JsonConvert.DeserializeObject<SimpleBabylon>(Properties.Resources.cube);
            SimpleBabylon monkey = JsonConvert.DeserializeObject<SimpleBabylon>(Properties.Resources.monkey);
            SimpleBabylon plane = JsonConvert.DeserializeObject<SimpleBabylon>(Properties.Resources.plane);
            meshes.Add(cube.ConvertToMesh(Color.Gray, 0, 0, 0));
            meshes.Add(monkey.ConvertToMesh(Color.Brown, 0, 0, 0));
            meshes.Add(plane.ConvertToMesh(Color.Green, 0, 0, 0));
        }

        public void FillProjectionMatrix()
        {
            double e = 1 / Math.Tan(fov / 2.0);
            projection_matrix =  CreateMatrix.DenseOfArray(new double[,] {
                    {e,0,0,0},
                    {0,e/a,0,0},
                    {0,0,-(f + n)/(f - n),-2*f*n/(f - n)},
                    {0,0,-1,0}});
        }
        public void FlushBuf()
        {
            int i = 0;
            Parallel.For(i, z_buf.GetLength(0), x =>
            {
                for (int k = 0; k < z_buf.GetLength(1); k++)
                    z_buf[x, k] = int.MaxValue;
            });
        }
        private void SetTimer(int delta)
        {
            my_timer = new Timer();
            my_timer.Tick += new EventHandler(TimerEventProcessor);
            my_timer.Interval = delta;
            my_timer.Start();
        }
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            my_timer.Stop();
            if (bgr_worker.IsBusy)
                return;
            bgr_worker.RunWorkerAsync();
            my_timer.Enabled = true;
        }
        public void RunFrame()
        {
            Logic();
            VanishBitmap();
            FlushBuf();
            foreach (Mesh mesh in meshes)
            {
                Render(mesh);
            }
        }
        public void Refresh()
        {
            p_box.Refresh();
            if (!my_timer.Enabled)
                my_timer.Enabled = true;
        }
        private void Render(Mesh m)
        {
            List<Vector<double>> converted_points = new List<Vector<double>>();
            List<Vector<double>> converted_normals = new List<Vector<double>>();
            List<Vector<double>> converted_camera_points = new List<Vector<double>>();
            List<Vector<double>> converted_light_positions = new List<Vector<double>>();
            List<Vector<double>> converted_spotlight_to_position = new List<Vector<double>>();
            Matrix<double> inversed_model_matrix = m.model_matrix.Inverse();
            for (int i = 0; i < m.points.Length; i++)
            {
                converted_points.Add(projection_matrix * view_matrix * m.model_matrix * m.points[i]);
                converted_camera_points.Add(view_matrix * m.model_matrix * m.points[i]);
                converted_normals.Add(view_matrix.Inverse().Transpose() * m.model_matrix.Inverse().Transpose() * m.normals[i]);
                converted_points[converted_points.Count - 1] = converted_points[converted_points.Count - 1].Multiply(1 / converted_points[converted_points.Count - 1][3]);
            }
            for (int i = 0; i < lights.Count; i++)
            {
                if(!lights[i].spotlight)
                {
                    converted_light_positions.Add(view_matrix * lights[i].world_position);
                    converted_spotlight_to_position.Add(null);
                }  
                else if (lights[i].spotlight)
                {
                    converted_light_positions.Add(view_matrix * lights[i].world_position);
                    converted_spotlight_to_position.Add(view_matrix * lights[i].world_to_position);
                }
            }
            SetLightsConvertedPoints(converted_light_positions, converted_spotlight_to_position);
            foreach (Face face in m.faces)
            {
                Color _color = (Color)(face.color == null ? m.color : face.color);
                var color = ColorDouble.CreateFromColor(_color);
                FillPolyHelper.FillPolygon(GetPolyFromFace(face, converted_points), GetFaceZ(face, converted_points), GetFaceNormals(face, converted_normals), 
                    GetFace3dPoints(face, converted_camera_points), lights, z_buf,  color, face.surface_factors, btm, shading_func);
            }
        }
        public List<Vector<double>> GetFace2dPoints(Face face, List<Vector<double>> converted_points)
        {
            var poly = new List<Vector<double>>();
            foreach (int index in face.indexes)
            {
                poly.Add(CreateVector.DenseOfArray(new double[] { converted_points[index][0], converted_points[index][1], converted_points[index][2] }));
            }
            return poly;
        }
        private List<Point> GetPolyFromFace(Face face, List<Vector<double>> points)
        {
            var poly = new List<Point>();
            foreach (int index in face.indexes)
            {
                poly.Add(GetPoint(index, points));
            }
            return poly;
        }
        private Point GetPoint(int index, List<Vector<double>> points)
        {
            return new Point((int)(points[index][0] * btm.Width / 2 + btm.Width / 2),
                (int)(points[index][1] * (-btm.Height / 2) + btm.Height / 2));
        }

        private List<int> GetFaceZ(Face face, List<Vector<double>> points)
        {
            var z_list = new List<int>();
            foreach (int index in face.indexes)
                z_list.Add((int)(points[index][2] * z_depth));
            return z_list;
        }
        public List<Vector<double>> GetFaceNormals(Face face, List<Vector<double>> converted_normals)
        {
            var z_list = new List<Vector<double>>();
            foreach (int index in face.indexes)
                z_list.Add(CreateVector.DenseOfArray(new double[] { converted_normals[index][0], converted_normals[index][1], converted_normals[index][2] }));
            return z_list;
        }
        public List<Vector<double>> GetFace3dPoints(Face face, List<Vector<double>> converted_points)
        {
            var points_list = new List<Vector<double>>();
            foreach (int index in face.indexes)
                points_list.Add(CreateVector.DenseOfArray(new double[] { converted_points[index][0], converted_points[index][1], converted_points[index][2] }));
            return points_list;
        }
        private void SetLightsConvertedPoints(List<Vector<double>> converted_lights_points, List<Vector<double>> converted_spotlight_to_position)
        {
            for(int i = 0; i < lights.Count; i++)
            {
                if (!lights[i].spotlight)
                    lights[i].position = CreateVector.DenseOfArray(new double[]{ converted_lights_points[i][0], converted_lights_points[i][1], converted_lights_points[i][2]});
                else if(lights[i].spotlight)
                {
                    lights[i].position = CreateVector.DenseOfArray(new double[] { converted_lights_points[i][0], converted_lights_points[i][1], converted_lights_points[i][2] });
                    var tmp = (CreateVector.DenseOfArray(new double[] { converted_spotlight_to_position[i][0], converted_spotlight_to_position[i][1], converted_spotlight_to_position[i][2] }));
                    lights[i].direction = (tmp - lights[i].position).Normalize(2);
                }
            }
        }
        private void Logic()  //[0]cube, [1]monkey, [2]plane
        {
            SetMeshesLightFactors();
            meshes[0].ResetModelMatrix();
            meshes[1].ResetModelMatrix();
            meshes[2].ResetModelMatrix();

            current_angle += 0.05;
            double dz = Math.Sin(current_angle) * r;
            double dx = Math.Cos(current_angle) * r;
            if (first_frame)
            {
                meshes[0].RotationZ(0.1);
            }
            if (spotlight)
            {
                meshes[0].faces[0].color = Color.White;
                meshes[0].faces[6].color = Color.White;
            }
            if (!spotlight)
            {
                meshes[0].faces[0].color = Color.Black;
                meshes[0].faces[6].color = Color.Black;
            }
            meshes[0].faces[0].surface_factors.ka = 1;
            meshes[0].faces[6].surface_factors.ka = 1;
            meshes[0].faces[0].surface_factors.kd = 0;
            meshes[0].faces[6].surface_factors.kd = 0;
            meshes[0].faces[0].surface_factors.ks = 0;
            meshes[0].faces[6].surface_factors.ks = 0;
            meshes[0].RotationZ(0);
            meshes[0].RotationY(-0.05);
            meshes[0].Scale(0.4, 0.4, 0.4);
            meshes[0].Translation(dx, 3, dz);

            meshes[1].RotationY(0.1);
            meshes[1].RotationX(0.01);
            meshes[1].RotationZ(0.03);
            meshes[1].Translation(0, 1.5, 0);
            meshes[1].Scale(1.6, 1.6, 1.6);

            meshes[2].Scale(8, 8, 8);

            switch(cam_mode)
            {
                case camera.constant:
                    LookAt(static_camera_position, CreateVector.DenseOfArray(new double[] { 0, 0, 0 }));
                    break;
                case camera.track:
                    LookAt(static_camera_position, CreateVector.DenseOfArray(new double[] { dx, 1, dz }));
                    break;
                case camera.bounded:
                    LookAt(CreateVector.DenseOfArray(new double[] { dx, 5, dz + 20}), CreateVector.DenseOfArray(new double[] { dx, 1, dz }));
                    break;
            }
            CreateLights(dx, dz);
            first_frame = false;
        }
        private void VanishBitmap()
        {
            Graphics tmp_graphics = Graphics.FromImage(btm.Bitmap);
            tmp_graphics.Clear(Color.Black);
        }
        private void LookAt(Vector<double> from, Vector<double> to)
        {
            var up_v = CreateVector.Dense<double>(new double[] { 0, 1, 0 });
            var z_axis = (from - to).Normalize(2);
            var x_axis = CrossProduct.Cross(up_v, z_axis);
            var y_axis = CrossProduct.Cross(z_axis, x_axis);
            var tmp_matrix =  CreateMatrix.DenseOfArray(new double[,] {
                {x_axis[0],     y_axis[0],      z_axis[0],      from[0]},
                {x_axis[1],     y_axis[1],      z_axis[1],      from[1]},
                {x_axis[2],     y_axis[2],      z_axis[2],      from[2]},
                {0,     0,      0,      1}
            });
            view_matrix = tmp_matrix.Inverse();
        }
        private void CreateLights(double dx, double dz)
        {
            lights = new List<Light>();
            if(sun)
            {
                lights.Add(new Light(CreateVector.DenseOfArray(new double[] { 0, 10, 0, 1 }), ColorDouble.CreateFromColor(Color.White)));
            }
            if(spotlight)
            {
                lights.Add(Light.CreateSpotlight(CreateVector.DenseOfArray(new double[] { dx, 1, dz, 1 }), ColorDouble.CreateFromColor(Color.White),
                    CreateVector.DenseOfArray(new double[] { 0, 1.5, 0, 1 }), spotlight_angle, spotlight_n));
            }
        }
        public void SetConstantShading()
        {
            shading_func = FillPolyHelper.ConstantShading;
        }
        public void SetGouraud()
        {
            shading_func = FillPolyHelper.Gouraud;
        }
        public void SetPhong()
        {
            shading_func = FillPolyHelper.Phong;
        }
        public void SetMeshesLightFactors()
        {
            for (int i = 0; i < meshes.Count(); i++)
            {
                for(int j = 0; j < meshes[i].faces.Count(); j++)
                {
                    meshes[i].faces[j].surface_factors.ka = this.ka;
                    meshes[i].faces[j].surface_factors.kd = this.kd;
                    meshes[i].faces[j].surface_factors.ks = this.ks;
                    meshes[i].faces[j].surface_factors.n = this.surface_factor_n;
                }
            }
        }
        public void FirstSetSurfaceFactors()
        {
            for (int i = 0; i < meshes.Count(); i++)
            {
                for (int j = 0; j < meshes[i].faces.Count(); j++)
                {
                    meshes[i].faces[j].surface_factors = new SurfaceFactors();
                    meshes[i].faces[j].surface_factors.ka = this.ka;
                    meshes[i].faces[j].surface_factors.kd = this.kd;
                    meshes[i].faces[j].surface_factors.ks = this.ks;
                    meshes[i].faces[j].surface_factors.n = this.surface_factor_n;
                }
            }
        }
    }
}
