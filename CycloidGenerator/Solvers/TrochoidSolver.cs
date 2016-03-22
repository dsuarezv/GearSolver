using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator.Solvers
{
    public class TrochoidSolver: CircularSolver, ISolver
    {
        public double A;
        public double B;

        public string Name
        {
            get { return "Trochoid solver"; }
        }

        public string Description
        {
            get { return "A Trochoid curve generator. https://en.wikipedia.org/wiki/Trochoid"; }
        }

        public TrochoidSolver()
        {
            MinAngle = -360 * 4;
            MaxAngle = 360 * 4;
        }

        public IList<SolverParameter> GetParams()
        {
            return new SolverParameter[] 
            { 
                new SolverParameter("A", "Radius of rolling circle", 30, 0, 10),
                new SolverParameter("B", "Radius drawing point", 30, 0, 10),
            };
        }

        protected override SolverPoint GetCircularPoint(int step, double angleRads, IExportClient cl)
        {
            return new SolverPoint(
                    A * angleRads - B * Math.Sin(angleRads),
                    A - B * Math.Cos(angleRads));
        }
    }
}
