using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestressedConcrete
{
    public class Polygon : Shape
    {
        public Polygon(double[] xCoords, double[] yCoords, bool void_, bool xSymmetric, bool ySymmetric) : base(xCoords, yCoords, void_, xSymmetric, ySymmetric) { }
    }
}
