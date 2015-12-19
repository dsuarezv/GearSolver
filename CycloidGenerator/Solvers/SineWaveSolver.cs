using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator.Solvers
{
    public class SineWaveSolver: ISolver
    {
        private const double Deg2Rad = Math.PI / 180d;


        public double Amplitude = 30;
        public double Period = 60;
        public double VerticalShift = 0;
        public double HorizontalShift = 0;


        public string Name
        {
            get { return "Sine wave"; }
        }

        public string Description
        {
            get { return "A minimal sample to show how to create new solvers."; }
        }

        public IList<SolverParameter> GetParams()
        {
            return new SolverParameter[] 
            { 
                new SolverParameter("Amplitude", "Wave Amplitude", 101, 1, Amplitude),
                new SolverParameter("Period", "Wave period", 100, 0.5, Period),
                new SolverParameter("HorizontalShift", "Horizontal Wave offset ", 100, -100, HorizontalShift),
                new SolverParameter("VerticalShift", "Vertical Wave offset", 100, -100, VerticalShift)
            };
        }

        public void Run(IExportClient cl)
        {
            double start = -100;
            double end = 100;
            double step = 0.1;
            
            var p1 = new SolverPoint(start, F(start));

            for (double x = start; x <= end; x += step)
            {
                double y = F(x);
                var p2 = new SolverPoint(x, y);
                cl.Line(p1, p2, 0, "base");

                p1 = p2;
            }
        }

        private double F(double x)
        {
            var offset = HorizontalShift * Deg2Rad;
            var b = 2 * Math.PI / Period;

            return Amplitude * Math.Sin(b * (x - offset)) + VerticalShift;
        }
    }
}
