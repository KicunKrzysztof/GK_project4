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
        public int x, y, z;
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
