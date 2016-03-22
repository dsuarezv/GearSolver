using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator.Solvers
{
    public class HypocycloidSolver: CircularSolver, ISolver
    {

        public double A;
        public double B;


        public string Name
        {
            get { return "Hypocloid"; }
        }

        public string Description
        {
            get { return "An hypocycloid curve generator. https://en.wikipedia.org/wiki/Hypocycloid"; }
        }

        public IList<SolverParameter> GetParams()
        {
            return new SolverParameter[] 
            { 
                new SolverParameter("A", "Radius of directing pitch circle", 60, 0, 25),
                new SolverParameter("B", "Radius of rolling circle", 30, 0, 5),
            };
        }


        public HypocycloidSolver()
        {
            //MaxAngle = 360 * 4;
        }

        
        protected override void AfterCircle(IExportClient cl)
        {
            cl.Circle(new SolverPoint(0, 0), A, 1, "circles");
        }

        protected override SolverPoint GetCircularPoint(int step, double angleRads, IExportClient cl)
        {
            var v = (A - B) / B * angleRads;

            var centerX = (A - B) * Math.Cos(angleRads);
            var centerY = (A - B) * Math.Sin(angleRads);
            var x = centerX + B * Math.Cos(v);
            var y = centerY - B * Math.Sin(v);

            var result = new SolverPoint(x, y);


            if (step % (NumSteps / 20) == 0)
            {
                cl.Circle(new SolverPoint(centerX, centerY), B, 1, "circles");
                cl.Point(result, 5, "points");
            }


            return result;
        }
    }
}
