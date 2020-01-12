using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;

namespace _3d_basic
{
    class SimpleBabylon
    {
        public IList<double> positions { get; set; }
        public IList<double> normals { get; set; }
        public IList<int> indices { get; set; }

        public Mesh ConvertToMesh(Color col, double _x, double _y, double _z, double ax, double ay, double az)
        {
            List<Vector<double>> points = new List<Vector<double>>();
            List<Face> faces = new List<Face>();
            for(int i = 0; i < positions.Count; i+=3)
                points.Add(CreateVector.DenseOfArray(new double[] { positions[i], positions[i + 1], positions[i + 2], 1 }));
            for(int i = 0; i < indices.Count; i+=3)
                faces.Add(new Face(indices[i], indices[i + 1], indices[i + 2], null));
            return new Mesh(col, _x, _y, _z, ax, ay, az, points.ToArray(), faces.ToArray());
        }
    }
}
