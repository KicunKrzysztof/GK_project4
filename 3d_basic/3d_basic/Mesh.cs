using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
//using MathNet.Numerics.LinearAlgebra.Double;

namespace _3d_basic
{
    class Mesh
    {
        public Vector<double>[] points;
        public Face[] faces;
        public Vector<double>[] normals;
        public Color color;
        public Matrix<double> model_matrix;
        public double angle_x, angle_y, angle_z;
        public SurfaceFactors factors;

        public Mesh(Color col, double ax, double ay, double az)
        {
            model_matrix = CreateMatrix.DenseIdentity<double>(4);
            color = col;
            angle_x = ax; angle_y = ay; angle_z = az;
            factors = new SurfaceFactors();
        }
        public Mesh(Color col, double ax, double ay, double az, Vector<double>[] _points, Face[] _faces, Vector<double>[] _normals)
        {
            model_matrix = CreateMatrix.DenseIdentity<double>(4);
            color = col;
            angle_x = ax; angle_y = ay; angle_z = az;
            points = _points;
            faces = _faces;
            normals = _normals;
            factors = new SurfaceFactors();
        }
        public void RotationX(double delta_angle)
        {
            angle_x += delta_angle;
            Matrix<double> rotation_matrix = CreateMatrix.DenseOfArray(new double[,] {
                {1, 0, 0, 0},
                {0, Math.Cos(angle_x), -Math.Sin(angle_x), 0},
                {0, Math.Sin(angle_x), Math.Cos(angle_x), 0},
                {0, 0, 0, 1}
            });
            model_matrix = rotation_matrix * model_matrix;
        }
        public void RotationY(double delta_angle)
        {
            angle_y += delta_angle;
            Matrix<double> rotation_matrix = CreateMatrix.DenseOfArray(new double[,] {
                {Math.Cos(angle_y), 0, Math.Sin(angle_y), 0},
                {0, 1, 0, 0},
                {-Math.Sin(angle_y), 0, Math.Cos(angle_y), 0},
                {0, 0, 0, 1}
            });
            model_matrix = rotation_matrix * model_matrix;
        }
        public void RotationZ(double delta_angle)
        {
            angle_z += delta_angle;
            Matrix<double> rotation_matrix = CreateMatrix.DenseOfArray(new double[,] {
                {Math.Cos(angle_z), -Math.Sin(angle_z), 0, 0},
                {Math.Sin(angle_z), Math.Cos(angle_z), 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            });
            model_matrix = rotation_matrix * model_matrix;
        }
        public void Translation(double _x, double _y, double _z)
        {
            Matrix<double> translation_matrix = CreateMatrix.DenseOfArray(new double[,] {
                {1, 0, 0, _x},
                {0, 1, 0, _y},
                {0, 0, 1, _z},
                {0, 0, 0, 1}
            });
            model_matrix = translation_matrix * model_matrix;
        }
        public void Scale(double _x, double _y, double _z)
        {
            Matrix<double> scale_matrix = CreateMatrix.DenseOfArray(new double[,] {
                {_x, 0, 0, 0},
                {0, _y, 0, 0},
                {0, 0, _z, 0},
                {0, 0, 0, 1}
            });
            model_matrix = scale_matrix * model_matrix;
        }
        public void ResetModelMatrix()
        {
            model_matrix = CreateMatrix.DenseIdentity<double>(4);
        }
    }
    class Face
    {
        public int[] indexes;
        public Color? color;
        public Face(int aa, int bb, int cc, Color? c)
        {
            indexes = new int[] { aa, bb, cc };
            color = c;
        }
    }
    class SurfaceFactors
    {
        public double ka;
        public double kd;
        public double ks;
        public int n;
        public SurfaceFactors()
        {
            ka = 0.15;//0.15;
            kd = 0.5;// 0.5;
            ks = 1;
            n = 10;
        }
    }
}
