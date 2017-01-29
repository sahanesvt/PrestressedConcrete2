using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestressedConcrete
{
    public class Beam
    {
        //public List<Strands> Strands { get; set; }
        public double E_p { get; set; }             // modulus of elasticity of prestressing steel
        public double E_c { get; set; }             // modulus of elasticity of prestressed concrete
        public double E_ci { get; set; }            // modulus of elasticity of prestressed concrete at release
        public double A_ps { get; private set; }    // total area of prestressing steel
        public double A_g { get; set; }             // gross beam area    
        public double I_g { get; private set; }     // gross moment of inertia of beam
        public double e_pg { get; private set; }    // eccentricity of prestressing force with respect to the centroid of girder
        //public double K_id { get; private set; }  // transformed section coefficient that accounts for the time-dependant interaction between concrete and bonded
                                                    // steel in the section being considered for time period between transfer and deck placement
        //public double eps_bid { get; private set; }// concrte shrinkage strain of girder between the time of transfer and deck placement
        //public double psi_b { get; private set; } // girder creep coefficient at final time due to loading introduced at transfer
        public double f_cgp { get; private set; }   //sum of concrete stresses at the center of gravity of prestressing tendons due to the prestressing force 
                                                    //after jacking and the self-weight of the member at the sections of maximum moment


         







    }
}
