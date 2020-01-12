using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;

namespace _3d_basic
{
    class FillPolyHelper
    {
        public static void FillPolygon(List<Point> poly_list, List<int> z_list, int [,] z_bufor, Color c, DirectBitmap btm)
        {
            if (PolyOutOfBtm(poly_list, btm))
                return;
            Point[] poly = new List<Point>(poly_list).ToArray();
            int[] idx = Enumerable.Range(0, poly.Length).ToArray();
            Array.Sort((Point[])poly.Clone(), idx, new YPointsComparer());
            int y_min = poly[idx[0]].Y, y_max = poly[idx[idx.Length - 1]].Y, next_idx = 0;
            List<EdgeBucket> AET = new List<EdgeBucket>();
            List<(int, int, int)> scanline_list = new List<(int, int, int)>();
            for (int curr_y = y_min; curr_y < y_max; curr_y++)
            {
                while (next_idx < poly.Length && poly[idx[next_idx]].Y == curr_y)
                {
                    int next_vertex = idx[next_idx] - 1 == -1 ? poly.Length - 1 : idx[next_idx] - 1;

                    //add or delete first edge from this vertex
                    if (poly[(idx[next_idx] + 1) % poly.Length].Y < curr_y)
                    {
                        EdgeBucket.DeleteEdgeFromAET(idx[next_idx], AET);
                    }
                    else if (poly[(idx[next_idx] + 1) % poly.Length].Y > curr_y)
                    {
                        AET.Add(new EdgeBucket(curr_y, poly[(idx[next_idx] + 1) % poly.Length].Y, poly[(idx[next_idx] + 1) % poly.Length].X - poly[idx[next_idx]].X,
                            poly[(idx[next_idx] + 1) % poly.Length].Y - poly[idx[next_idx]].Y, idx[next_idx], poly[idx[next_idx]].X));
                    }

                    //add or delete second edge from this vertex
                    if (poly[next_vertex].Y < curr_y)
                    {
                        EdgeBucket.DeleteEdgeFromAET(next_vertex, AET);
                    }
                    else if (poly[next_vertex].Y > curr_y)
                    {
                        AET.Add(new EdgeBucket(curr_y, poly[next_vertex].Y, poly[next_vertex].X - poly[idx[next_idx]].X,
                            poly[next_vertex].Y - poly[idx[next_idx]].Y, next_vertex, poly[idx[next_idx]].X)); ;
                    }
                    next_idx++;
                }
                AET.Sort(new XEdgesComparer());
                for (int i = 0; i < AET.Count; i += 2)
                {
                    scanline_list.Add((curr_y, (int)Math.Round(AET[i].x), (int)Math.Round(AET[i + 1].x)));
                    AET[i].IncrementX();
                    AET[i + 1].IncrementX();
                }
            }
            Parallel.ForEach(scanline_list, boundaries =>
            {
                for (int x = boundaries.Item2; x <= boundaries.Item3; x++)
                {
                    if (OnBitmap(x, boundaries.Item1, btm.Width, btm.Height))
                    {
                        int tmp_z_value = ComputeZFrorPoint(poly_list, z_list, x, boundaries.Item1);
                        if (z_bufor[x, boundaries.Item1] > tmp_z_value)
                        {
                            btm.SetPixel(x, boundaries.Item1, c);
                            z_bufor[x, boundaries.Item1] = tmp_z_value;
                        }
                    }
                }
            });
        }
        public class YPointsComparer : IComparer<Point>
        {
            int IComparer<Point>.Compare(Point p1, Point p2)
            {
                if (p1.Y == p2.Y)
                    return 0;
                return p1.Y > p2.Y ? 1 : -1;
            }
        }
        public class XEdgesComparer : IComparer<EdgeBucket>
        {
            int IComparer<EdgeBucket>.Compare(EdgeBucket e1, EdgeBucket e2)
            {
                if (e1.x == e2.x)
                    return 0;
                return e1.x > e2.x ? 1 : -1;
            }
        }

        public static int ComputeZFrorPoint(List<Point> poly, List<int> z_list, int x, int y)
        {
            double u = 0, v = 0, w = 0;
            Point p = new Point(x, y);
            Barycentric(p, poly[0], poly[1], poly[2], ref u, ref v, ref w);
            return (int)(u * z_list[0] + v * z_list[1] + w * z_list[2]);
        }
        // Compute barycentric coordinates (u, v, w) for
        // point p with respect to triangle (a, b, c)
        public static void Barycentric(Point p, Point a, Point b, Point c, ref double u, ref double v, ref double w)
        {
            Vector<double> v0 = CreateVector.DenseOfArray(new double[] {b.X - a.X, b.Y - a.Y });
            Vector<double> v1 = CreateVector.DenseOfArray(new double[] {c.X - a.X, c.Y - a.Y });
            Vector<double> v2 = CreateVector.DenseOfArray(new double[] {p.X - a.X, p.Y - a.Y });
            double d00 = v0.DotProduct(v0);
            double d01 = v0.DotProduct(v1);
            double d11 = v1.DotProduct(v1);
            double d20 = v2.DotProduct(v0);
            double d21 = v2.DotProduct(v1);
            double denom = d00 * d11 - d01 * d01;
            v = (d11 * d20 - d01 * d21) / denom;
            w = (d00 * d21 - d01 * d20) / denom;
            u = 1.0f - v - w;
        }
        public static bool OnBitmap(int x, int y, int btm_x, int btm_y)
        {
            if (x < 0 || y < 0 || x >= btm_x || y >= btm_y)
                return false;
            return true;
        }
        public static bool PolyOutOfBtm(List<Point> poly_list, DirectBitmap btm)
        {
            foreach(Point p in poly_list)
            {
                if (OnBitmap(p.X, p.Y, btm.Width, btm.Height))
                    return false;
            }
            return true; ;
        }
    }
}
