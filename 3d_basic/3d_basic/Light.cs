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
        public bool spotlight;
        public Vector<double> direction;
        public Vector<double> world_direction;
        public double cutoff;
        public double n;
        public Light(Vector<double> _pos, ColorDouble _col)
        {
            spotlight = false;
            world_position = _pos;
            color = _col;
        }
        private Light (Vector<double> _pos, ColorDouble _col, Vector<double> _dir, double _cutoff, double _n)
        {
            spotlight = true;
            world_position = _pos;
            color = _col;
            world_direction = _dir - _pos;
            cutoff = _cutoff;
            n = _n;
        }
        public static Light CreateSpotlight(Vector<double> _pos, ColorDouble _col, Vector<double> _dir, double _cutoff, double _n)
        {
            return new Light(_pos, _col, _dir, _cutoff, _n);
        }
        public void PointTo(Vector<Double> dir)
        {
            world_direction = dir - position;
        }
    }
}
