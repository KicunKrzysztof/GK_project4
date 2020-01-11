﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
//using MathNet.Numerics.LinearAlgebra.Double;

namespace _3d_basic
{
    class Engine
    {
        public PictureBox p_box;
        private DirectBitmap btm;
        private Timer my_timer;
        private int[,] z_buf;
        private Matrix<double> view_matrix, projection_matrix;
        private double 
            n = 1, //near clipping
            f = 100, //far clipping
            fov = (1 / 4.0) * Math.PI, //camera angle (leans)
            a; //aspect ratio
        private List<Mesh> meshes;
        private const int z_depth = 10000;
        public Engine(PictureBox _p_box) 
        {
            p_box = _p_box;
            btm = new DirectBitmap(p_box.Width, p_box.Height);
            p_box.Image = btm.Bitmap;
            z_buf = new int[p_box.Width, p_box.Height];
            FlushBuf();
            SetTimer(1);
            a = (double)p_box.Height / p_box.Width;
            FillProjectionMatrix();
            view_matrix = CreateMatrix.DenseOfArray(new double[,] {
                {0,1,0,-0.5},
                {0,0,1,-0.5},
                {1,0,0,-3},
                {0,0,0,1}});
            InitializeMeshes();
        }

        private void InitializeMeshes()
        {
            Matrix<double> model_matrix = CreateMatrix.DenseIdentity<double>(4);
            meshes = new List<Mesh>(){ new Cube(Color.Red, model_matrix)};
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
            for (int i = 0; i < z_buf.GetLength(0); i++)
                for (int k = 0; k < z_buf.GetLength(1); k++)
                    z_buf[i, k] = int.MaxValue;
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
            Logic();
            VanishBitmap();
            foreach (Mesh mesh in meshes)
            {
                Render(mesh);
            }
            p_box.Refresh();
        }
        private void Render(Mesh m)
        {
            FlushBuf();
            List<Vector<double>> converted_points = new List<Vector<double>>();
            for (int i = 0; i < m.points.Length; i++)
            {
                converted_points.Add(projection_matrix * view_matrix * m.model_matrix * m.points[i]);
                converted_points[converted_points.Count - 1] = converted_points[converted_points.Count - 1].Multiply(1 / converted_points[converted_points.Count - 1][3]);
            }
            foreach (Face face in m.faces)
            {
                Color color = (Color)(face.color == null ? m.color : face.color);
                FillPolyHelper.FillPolygon(GetPolyFromFace(face, converted_points), GetFaceZ(face, converted_points), z_buf,  color, btm);
            }
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
            {
                z_list.Add((int)(points[index][2] * z_depth));
            }
            return z_list;
        }
        private void Logic()
        {
            meshes[0].ResetModelMatrix();
            meshes[0].RotationX(0.1);
        }
        private void VanishBitmap()
        {
            Graphics tmp_graphics = Graphics.FromImage(btm.Bitmap);
            tmp_graphics.Clear(Color.Empty);
        }
        private void LookAt()
        {

        }
        public void TestFill()
        {
            FillPolyHelper.FillPolygon(new List<Point>() { new Point(0, 0), new Point(btm.Width, 0), new Point(btm.Width, btm.Height), new Point(0, btm.Height) }, null, null, Color.White, btm);
            p_box.Refresh();
        }
    }
}