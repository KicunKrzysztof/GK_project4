using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _3d_basic
{
    class ColorDouble
    {
        public double r;
        public double g;
        public double b;
        public ColorDouble(double _r, double _g, double _b)
        {
            r = _r; g = _g; b = _b;
        }
        public Color GetColor()
        {
            r = Math.Max(Math.Min(1, r), 0);
            g = Math.Max(Math.Min(1, g), 0);
            b = Math.Max(Math.Min(1, b), 0);
            return Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
        }
        public static ColorDouble operator *(double factor, ColorDouble color)
        {
            return new ColorDouble(color.r * factor, color.g * factor, color.b * factor);
        }
        public static ColorDouble operator +(ColorDouble color1, ColorDouble color2)
        {
            return new ColorDouble(color1.r + color2.r, color1.g + color2.g, color1.b + color2.b);
        }
        public static ColorDouble CreateFromColor(Color c)
        {
            return new ColorDouble(c.R / 255.0, c.G / 255.0, c.B / 255.0);
        }
    }
}
