using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator.Solvers
{
    public class SensingerCycloidSolver : CircularSolver, ISolver
    {
        public double R;
        public double Rr;
        public double Z1;
        //public double Y;
        public double E;
        public double CamDiameter;



        public string Name
        {
            get { return "Hypocycloid gear (Sensinger)"; }
        }

        public string Description
        {
            get { return "An hypocycloid gear profile generator. From 'Unified approach to Cycloid Drive Profile, Stress and Efficiency optimization' by Jonathon W. Sensinger (2010)."; }
        }

        public IList<SolverParameter> GetParams()
        {
            return new SolverParameter[] 
            { 
                new SolverParameter("R", "Roller distance from center", 60, 0, 25),
                new SolverParameter("Rr", "Radius of the rollers", 60, 0, 2.5),
                new SolverParameter("Z1", "Num teeth", 60, 0, 10),
                //new SolverParameter("Y", "Contact angle between cycloid lobe and roller", 90, 0, 25),
                new SolverParameter("E", "Eccentricity", 10, 0, 1.5),
                new SolverParameter("CamDiameter", "Cam center diameter", 50, 5, 22),
            };
        }

        protected override void BeforeCircle(IExportClient cl)
        {
            // Constraints


            // R constraint

            //var Rmin = Math.Sqrt(
            //    (Rr * Rr * Math.Pow(Z1 + 2, 3)) /
            //    (27 * Z1)
            //    + E * E * Math.Pow(Z1 + 1, 2));

            //if (R < Rmin) R = Rmin;


            // Rr constraint

            //var Rrmax1 = R * Math.Sin(Math.PI / (Z1 + 1));
            //var Rrmax2 = Math.Sqrt(
            //    (27 * Z1 * (R * R - E * E * (Z1 + 1) * (Z1 + 1))) /
            //    Math.Pow(Z1 + 2, 3));

            //var Rrmax = Math.Min(Rrmax1, Rrmax2);

            //if (Rr > Rrmax) Rr = Rrmax;


            // Eccentricity contraint

            var Emax = Math.Sqrt(
                (27 * R * R * Z1 - Rr * Rr * Math.Pow(Z1 + 2, 3)) /
                (27 * Z1 * Math.Pow(Z1 + 1, 2)));

            if (E > Emax) E = Emax;
        }

        protected override void AfterCircle(IExportClient cl)
        {
            for (int i = 0; i < Z1 + 1; ++i)
            {
                var angle = 360d / (Z1 + 1) * i * Deg2Rad;

                var x = R * Math.Cos(angle) - E;
                var y = R * Math.Sin(angle);

                cl.Circle(new SolverPoint(x, y), Rr, 1, "rollers");
            }

            cl.Circle(new SolverPoint(-E, 0), 2.5, 1, "rollers");
            cl.Circle(new SolverPoint(0, 0), CamDiameter / 2, 0, "base");
        }

        protected override SolverPoint GetCircularPoint(int step, double angle, IExportClient cl)
        {
            //var Yr = Y * Deg2Rad;

            // Contact angle is calculated here
            var Yr = Math.Atan2(Math.Sin(Z1 * angle), Math.Cos(Z1 * angle) - R / (E * (Z1 + 1)) );

            var x = R * Math.Cos(angle) + Rr * Math.Cos(angle + Yr) - E * Math.Cos((Z1 + 1) * angle);
            var y = R * Math.Sin(angle) + Rr * Math.Sin(angle + Yr) - E * Math.Sin((Z1 + 1) * angle);

            return new SolverPoint(x, y);
        }
    }
}
