using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PrestressedConcrete
{
    public class Strands
    {
        public int NoStrands { get; set; }
        public double AreaPerStrand { get; set; }
        public double Area { get; private set; }
        public double Location { get; set; }
        public double E_p { get; set; }
        public double f_pu { get; private set; }
        public double f_py { get; private set; }
        public double JackingRatio { get; set; }
        public double f_pbt { get; private set; }
        public double f_pe { get; private set; }
        public double f_pj { get; private set; }
        public double f_po { get; private set; }
        public double f_ps { get; private set; }
        public double f_pt { get; private set; }

        /*private static void unNull(Strands strand)
            {
                foreach (PropertyInfo property in strand.GetType().GetProperties())
                {
                    if(property == null)
                    {
                        property = 0;
                    }
                }
            }*/

        public Strands()
        {
            NoStrands = 0;
            AreaPerStrand = 0;
            Area = 0;
            Location = 0;
            E_p = 28500;
        }

        public Strands(int noStrands, double areaPerStrand, double location)
        {
            NoStrands = noStrands;
            AreaPerStrand = areaPerStrand;
            Area = noStrands * areaPerStrand;
            Location = location;
            E_p = 28500;
        }

        public void SetProperties(double f_pu, bool lowRelaxation)
        {
            this.f_pu = f_pu;
            if (lowRelaxation)
            {
                f_py = 0.9 * f_pu;
                JackingRatio = 0.75;
            }
            else
            {
                f_py = 0.85 * f_pu;
                JackingRatio = 0.7;
            }
            f_pj = JackingRatio * f_pu;
        }

         

    }
}
