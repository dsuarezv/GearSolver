using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator.Solvers
{
    public abstract class CircularSolver
    {
        private const double Deg2Rad = Math.PI / 180d;

        public double MinAngle = 0;
        public double MaxAngle = 360;
        public double NumSteps = 1000;

        public void Run(IExportClient cl)
        {
            BeforeCircle(cl);

            SolverPoint last = null;

            for (int i = 0; i < NumSteps; ++i)
            {
                var angle = (MaxAngle - MinAngle) / NumSteps * i + MinAngle;
                var r = angle * Deg2Rad;
                var p = GetCircularPoint(i, r, cl);

                if (last != null) cl.Line(last, p, 0, "base");
                last = p;
            }

            AfterCircle(cl);
        }

        protected virtual void BeforeCircle(IExportClient cl)
        { 
        
        }

        protected virtual void AfterCircle(IExportClient cl)
        {
            
        }

        protected abstract SolverPoint GetCircularPoint(int step, double angleRads, IExportClient cl);
    }
}
