using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using System.Drawing;

namespace _3d_basic
{
    class Light
    {
        public Vector<double> world_position; //size == 4
        public Vector<double> position; //camera position, used in FillPoly, size == 3
        public ColorDouble color;
        public Light(Vector<double> _pos, ColorDouble _col)
        {
            world_position = _pos.Normalize(1);
            color = _col;
        }
    }
}
