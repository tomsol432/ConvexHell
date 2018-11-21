using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIConvexHull;

namespace ConvexHell
{
    class FastVector : IVertex
    {
public FastVector(double x, double y)
        {
            this.position = new double[2] { x, y };
        }

        private double[] position;
public double[] Position { get => position; set => position = value; }
    }
}
