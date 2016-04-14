using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator.Solvers
{
    public class BasicCycloidSolver: CircularSolver, ISolver
    {
        public double A;
        public double B;
        public double NumRollers;
        public double Offset;



        public string Name
        {
            get { return "Hypocycloid gear (BASE)"; }
        }

        public string Description
        {
            get { return "An hypocycloid gear profile generator."; }
        }

        public IList<SolverParameter> GetParams()
        {
            return new SolverParameter[] 
            { 
                new SolverParameter("A", "Radius of the arrangement rollers in the sun ring", 60, 0, 25),
                new SolverParameter("B", "Radius of the rollers", 60, 0, 2.5),
                new SolverParameter("NumRollers", "Num rollers", 60, 0, 10),
                //new SolverParameter("Offset", "Profile offset", 60, 0, 25),

            };
        }
        
        protected override SolverPoint GetCircularPoint(int step, double angle, IExportClient cl)
        {
            var radius = A / NumRollers;

            var x = A * Math.Cos(angle) + radius * Math.Cos(angle * NumRollers);
            var y = A * Math.Sin(angle) + radius * Math.Sin(angle * NumRollers);

            return new SolverPoint(x, y);
        }
    }
}
