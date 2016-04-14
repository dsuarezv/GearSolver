using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator.Solvers
{
    public class WawCycloidSolver: CircularSolver, ISolver
    {
        public double Rz;
        public double q;
        public double l;
        public double i;
        public double e;
        public double z;
        public double N;


        public string Name
        {
            get { return "Hypocycloid gear (waw.pl) BUGGY"; }
        }

        public string Description
        {
            get { return "An hypocycloid gear profile generator. http://www.esmats.eu/esmatspapers/pastpapers/pdfs/2013/seweryn.pdf"; }
        }

        public IList<SolverParameter> GetParams()
        {
            return new SolverParameter[] 
            { 
                new SolverParameter("Rz", "Radius of the arrangement rollers in the sun ring", 60, 0, 25),
                new SolverParameter("q", "Radius of the rollers in the sun gear", 30, 0, 5),
                new SolverParameter("l", "Attitude tooth head to the base", 5, 0, 0.1),
                new SolverParameter("i", "Gear ratio", 30, 0, 5),
                new SolverParameter("e", "Eccentricity", 20, 0, 0.5),
                new SolverParameter("z", "z", 20, 0, 1),
                new SolverParameter("N", "N", 20, 0, 10),
            };
        }

        
        protected override void AfterCircle(IExportClient cl)
        {
            for (int j = 0; j < N; ++j)
            {
                var angle = j * 360 / N * Deg2Rad;

                cl.Circle(new SolverPoint(Rz * Math.Cos(angle), Rz * Math.Sin(angle)), q, 1, "output_rollers");
            }
            
        }

        protected override SolverPoint GetCircularPoint(int step, double angle, IExportClient cl)
        {
            var common = angle + Math.Atan2(Math.Sin(z * angle), 1 / l + Math.Cos(z * angle));

            var x = Rz * Math.Cos(angle) + e * Math.Cos(N * angle) - q * Math.Cos(common);
            var y = Rz * Math.Sin(angle) + e * Math.Sin(N * angle) - q * Math.Sin(common);

            return new SolverPoint(x, y);
        }
    }
}
