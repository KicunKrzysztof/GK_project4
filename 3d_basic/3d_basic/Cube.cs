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
    class Cube:Mesh
    {
        public Cube(Color col, Matrix<double> matrix)
        {
            points = new DenseVector[] {
                        new DenseVector(new double[] { 0,0,0,1}),
                        new DenseVector(new double[] { 1,0,0,1}),
                        new DenseVector(new double[] { 1,1,0,1}),
                        new DenseVector(new double[] { 0,1,0,1}),
                        new DenseVector(new double[] { 0,0,1,1}),
                        new DenseVector(new double[] { 1,0,1,1}),
                        new DenseVector(new double[] { 1,1,1,1}),
                        new DenseVector(new double[] { 0,1,1,1}) };
            faces = new Face[] {
                        new Face(0, 1, 2, Color.Red),
                        new Face(0, 2, 3, Color.Red),
                        new Face(1, 5, 6, Color.Green),
                        new Face(1, 6, 2, Color.Green),
                        new Face(5, 6, 7, Color.Blue),
                        new Face(4, 5, 7, Color.Blue),
                        new Face(0, 3, 4, Color.Cyan),
                        new Face(3, 4, 7, Color.Cyan),
                        new Face(2, 3, 6, Color.Black),
                        new Face(3, 6, 7, Color.Black),
                        new Face(0, 1, 4, Color.Magenta),
                        new Face(1, 4, 5, Color.Magenta),
            };
            color = col;
            model_matrix = matrix;
        }
    }
}