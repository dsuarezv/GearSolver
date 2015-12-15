using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator.Solvers
{
    public class SampleSolver: ISolver
    {
        private const double Deg2Rad = Math.PI / 180d;


        public double Angle = 35;


        public string Name
        {
            get { return "Sample solver"; }
        }

        public string Description
        {
            get { return "A minimal sample to show how to create new solvers."; }
        }

        public IList<SolverParameter> GetParams()
        {
            return new SolverParameter[] 
            { 
                new SolverParameter("Angle", "Angle in degrees", 180, -180, 35)
            };
        }

        public void Run(IExportClient cl)
        {
            var len = 50d;
            var p1 = new SolverPoint(0, 0);
            var p2 = new SolverPoint(len, 0);
            var p3 = new SolverPoint(len * Math.Cos(Angle * Deg2Rad), len * Math.Sin(Angle * Deg2Rad));

            cl.Line(p1, p2, 1, "base");
            cl.Line(p1, p3, 0, "base");
        }
    }
}
