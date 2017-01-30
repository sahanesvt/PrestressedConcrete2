using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestressedConcrete
{
    public class Concrete
    {
        public double E_c { get; set; }
        public double E_ci { get; set; }
        public double f_c { get; set; }
        public double f_ci { get; set; }
        public double DensityForWeight { get; set; }
        public double DensityForModElast { get; set; }
        public double K_1 { get; set; }

        private static double modElastCode(double k_1, double w_c, double f_c)
        {
            return 33000 * k_1 * Math.Pow(w_c, 1.5) * Math.Sqrt(f_c);
        }

        private static double modElastCommentary(double f_c)
        {
            return 1820 * Math.Sqrt(f_c);
        }

        public Concrete()
        {
            E_c = 0; E_ci = 0; f_c = 0; f_ci = 0; DensityForWeight = 0.15; DensityForModElast = 0.15; K_1 = 1;
        }

        public Concrete(double f_c)
        {
            this.f_c = f_c;
            E_c = modElastCode(K_1, DensityForModElast, f_c);
            E_ci = 0; f_ci = 0; DensityForWeight = 0.15; DensityForModElast = 0.15; K_1 = 1;
        }

        public Concrete(double f_c, double f_ci)
        {
            this.f_c = f_c;
            E_c = modElastCode(K_1, DensityForModElast, f_c);
            E_ci = modElastCode(K_1, DensityForModElast, f_ci);
            DensityForWeight = 0.15; DensityForModElast = 0.15; K_1 = 1;
        }

        public Concrete(double f_c, double f_ci, double densityForWeight, double densityForModElast, double k_1)
        {
            this.f_c = f_c;
            K_1 = k_1; DensityForModElast = densityForModElast; DensityForWeight = densityForWeight;
            E_c = modElastCode(k_1, densityForModElast, f_c);
            E_ci = modElastCode(k_1, densityForModElast, f_ci);
        }


        public void ModElast(double f_c, double density)
        {
            E_c = modElastCode(K_1, density, f_c);
        }

        public void ModElast(double f_c, double f_ci, double density)
        {
            E_c = modElastCode(K_1, density, f_c);
            E_ci = modElastCode(K_1, density, f_ci);
        }
    }
}
