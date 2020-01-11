using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace _3d_basic
{
    class Mesh
    {
        public DenseVector[] points;
        public Face[] faces;
        public Color color;
        public Matrix<double> model_matrix;
        public double x, y, z;
        public double angle_x, angle_y, angle_z;

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
            x += _x; y += _y; z += _z;
            Matrix<double> translation_matrix = CreateMatrix.DenseOfArray(new double[,] {
                {1, 0, 0, x},
                {0, 1, 0, y},
                {0, 0, 1, z},
                {0, 0, 0, 1}
            });
            model_matrix = translation_matrix * model_matrix;
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
        public Face (int aa, int bb, int cc, Color c)
        {
            indexes = new int[] { aa, bb, cc };
            color = c;
        }
    }
}
