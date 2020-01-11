using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3d_basic
{
    class EdgeBucket
    {
        public int y_min, y_max, dx, dy, id;
        public double x, delta_x;
        public EdgeBucket(int _y_min, int _y_max, int _dx, int _dy, int _id, double _x)
        {
            y_min = _y_min; y_max = _y_max;
            dx = _dx; dy = _dy;
            x = _x;
            id = _id;
            delta_x = dx / (double)dy;
        }
        public void IncrementX()
        {
            x += delta_x;
        }
        public static void DeleteEdgeFromAET(int id, List<EdgeBucket> AET)
        {
            for (int i = 0; i < AET.Count; i++)
                if (AET[i].id == id)
                {
                    AET.RemoveAt(i);
                    return;
                }
        }
    }
}
