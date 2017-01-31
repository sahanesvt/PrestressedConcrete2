using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestressedConcrete
{
    class Program
    {
        static void Main(string[] args)
        {
            //double[] xCoords = new double[16] { -1, -2, -6, -6, 6, 6, 2, 1, 1, 2, 6, 6, -6, -6, -2, -1 };
            //double[] yCoords = new double[16] { 2, 3, 3, 4, 4, 3, 3, 2, -2, -3, -3, -4, -4, -3, -3, -2 };
            //Polygon polygon = new Polygon(xCoords, yCoords, false, false, false);


            //double[] xCoords = new double[8] { -12.25, -13, -13, -3, -3, -5, -21, -21 };
            //double[] yCoords = new double[8] { 0, 0.75, 6, 10.5, 46.5, 48.5, 50.5, 54 };
            double[] xCoords = new double[8] { -21, -21, -5, -3, -3, -13, -13, -12.25 };
            double[] yCoords = new double[8] { 54, 50.5, 48.5, 46.5, 10.5, 6, 0.75, 0 };
            Polygon polygon = new Polygon(xCoords, yCoords, false, true, false);
            Concrete concrete = new Concrete(6, 4.5, .15, .15, 1);
            Strands strands = new Strands(10, 0.153, 2.5);
            strands.SetProperties(270, true);
            Beam beam = new Beam(polygon, concrete, strands);

            Console.WriteLine("Area of polygon is {0}", polygon.Area);
            Console.WriteLine("Perimeter of polygon is {0}", polygon.Perimeter);
            Console.WriteLine("NA of polygon is x = {0}, y = {1}", polygon.CG_x, polygon.CG_y);
            Console.WriteLine("Moment of Inertia about x axis is {0}", polygon.I_x);
            Console.WriteLine("psi 1 = {0}", beam.psi_t_ti(60, 0.75, beam.f_ci, 75));
            Console.ReadLine();
        }
    }
}
