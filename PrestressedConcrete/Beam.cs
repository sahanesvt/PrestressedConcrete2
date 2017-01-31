using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestressedConcrete
{
    public class Beam
    {
        public List<Strands> Strands { get; set; }
        public double E_p { get; set; }             // modulus of elasticity of prestressing steel
        public double E_c { get; set; }             // modulus of elasticity of prestressed concrete
        public double E_ci { get; set; }            // modulus of elasticity of prestressed concrete at release
        public double f_c { get; set; }
        public double f_ci { get; set; }
        public double A_ps { get; private set; }    // total area of prestressing steel
        public double A_g { get; set; }             // gross beam area    
        public double I_g { get; private set; }     // gross moment of inertia of beam
        public double CG { get; set; }
        public double e_pg { get; private set; }    // eccentricity of prestressing force with respect to the centroid of girder
        //public double K_id { get; private set; }  // transformed section coefficient that accounts for the time-dependant interaction between concrete and bonded
                                                    // steel in the section being considered for time period between transfer and deck placement
        //public double eps_bid { get; private set; }// concrte shrinkage strain of girder between the time of transfer and deck placement
        //public double psi_b { get; private set; } // girder creep coefficient at final time due to loading introduced at transfer
        public double f_cgp { get; private set; }   //sum of concrete stresses at the center of gravity of prestressing tendons due to the prestressing force 
                                                    //after jacking and the self-weight of the member at the sections of maximum moment
        public double V_S { get; private set; }


        public Beam(Shape shape, Concrete concrete, Strands strands)
        {

            A_g = shape.Area;
            CG = shape.CG_x;
            I_g = shape.I_x;
            E_c = concrete.E_c;
            E_ci = concrete.E_ci;
            f_c = concrete.f_c;
            f_ci = concrete.f_ci;
            E_p = strands.E_p;
            e_pg = CG - strands.Location;
            A_ps = strands.Area;
            V_S = shape.Area / shape.Perimeter;
        }

         public Beam(Shape shape, Concrete concrete, List<Strands> strands)
        {
            A_g = shape.Area;
            CG = shape.CG_x;
            I_g = shape.I_x;
            E_c = concrete.E_c;
            E_ci = concrete.E_ci;
            f_c = concrete.f_c;
            f_ci = concrete.f_ci;
            Strands = strands;
            calcStrands();
            V_S = shape.Area / shape.Perimeter;
            //E_p = strands[0].E_p;
            //A_ps = strands.Sum(x => x.Area);
            //e_pg = strands.Sum(x => x.Location * x.Area) / A_ps;
        }

        public void calcStrands()
        {
            E_p = Strands[0].E_p;
            A_ps = Strands.Sum(x => x.Area);
            e_pg = Strands.Sum(x => x.Location * x.Area) / A_ps;
        }

        public double psi_t_ti(double t_i, double t, double f_c, double humidity)
        {
            double k_s = Math.Max(1.0,1.45 - 0.13 * V_S);
            double k_hc = 1.56 - 0.008 * humidity;
            double k_f = 5 / (1 + f_c);
            double k_td = (t_i - t) / (61 - 4 * f_c + (t_i - t));
            return 1.9 * k_s * k_hc * k_f * k_td * Math.Pow(t, -0.118);
        }







    }
}
