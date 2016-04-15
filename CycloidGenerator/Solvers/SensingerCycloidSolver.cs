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
        public double deo;
        public double dR;
        public double dcs;
        public double dcp;
        public double djb;


        private SolverParameter[] mParams = new SolverParameter[]
        {
            new SolverParameter("R", "Roller distance from center", 60, 0, 25),
            new SolverParameter("Rr", "Radius of the rollers", 60, 0, 2.5),
            new SolverParameter("Z1", "Num teeth", 60, 0, 10) { IsInteger = true, SmallChange = 1 },
            //new SolverParameter("Y", "Contact angle between cycloid lobe and roller", 90, 0, 25),
            new SolverParameter("E", "Eccentricity", 10, 0, 1.5),
            new SolverParameter("CamDiameter", "Cam center diameter", 50, 5, 22),
            new SolverParameter("deo", "Tolerance of the input cam eccentricity (deo)", 1, -1, 0),
            new SolverParameter("dR", "Offset of the holes in the ground structure for the rollers (dR)", 1, 0, 0),
            new SolverParameter("dcs", "Offset of the input shaft of the cycloid disk (dcs)", 1, 0, 0),
            new SolverParameter("dcp", "Offset of the cycloid profile (dcp)", 1, 0, 0),
            new SolverParameter("djb", "Axial play in the journal bearing of the rollers (djb)", 1, 0, 0),
        };


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
            return mParams;
        }

        protected override void BeforeCircle(IExportClient cl)
        {
            // Constraints


            // R constraint

            var Rmin = Math.Sqrt(
                (Rr * Rr * Math.Pow(Z1 + 2, 3)) /
                (27 * Z1)
                + E * E * Math.Pow(Z1 + 1, 2));

            if (R < Rmin)
            {
                R = Rmin;
                mParams[0].Value = R;
            }


            // Rr constraint

            var Rrmax1 = R * Math.Sin(Math.PI / (Z1 + 1));
            var Rrmax2 = Math.Sqrt(
                (27 * Z1 * (R * R - E * E * (Z1 + 1) * (Z1 + 1))) /
                Math.Pow(Z1 + 2, 3));

            var Rrmax = Math.Min(Rrmax1, Rrmax2);

            if (Rr > Rrmax)
            {
                Rr = Rrmax;
                mParams[1].Value = Rr;
            }


            // Eccentricity constraint

            var Emax = Math.Sqrt(
                (27 * R * R * Z1 - Rr * Rr * Math.Pow(Z1 + 2, 3)) /
                (27 * Z1 * Math.Pow(Z1 + 1, 2)));

            if (E > Emax)
            {
                E = Emax;
                mParams[3].Value = E;
            }


            // Draw Rollers

            for (int i = 0; i < Z1 + 1; ++i)
            {
                var angle = 360d / (Z1 + 1) * i * Deg2Rad;

                var x = R * Math.Cos(angle) - E;
                var y = R * Math.Sin(angle);

                cl.Circle(new SolverPoint(x, y), Rr, 1, "rollers");
            }

            // Draw Centers

            cl.Circle(new SolverPoint(-E, 0), 2.5, 1, "rollers");
            cl.Circle(new SolverPoint(0, 0), CamDiameter / 2, 0, "base");
        }

        protected override void AfterCircle(IExportClient cl)
        {
            // Tolerances

            var dgap = deo + dR + dcs + dcp;
            var Rprofile = R - dgap;

            var dsum = Math.Sqrt(deo * deo + dR * dR + dcs * dcs + dcp * dcp + djb * djb) + dgap;
            var backlash = 2 * dsum / (E * Z1);  // radians

            // Rollers after tolerance

            for (int i = 0; i < Z1 + 1; ++i)
            {
                var angle = 360d / (Z1 + 1) * i * Deg2Rad;

                var x = Rprofile * Math.Cos(angle) - E;
                var y = Rprofile * Math.Sin(angle);

                cl.Circle(new SolverPoint(x, y), Rr, 4, "rollers_tolerance");
            }
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
