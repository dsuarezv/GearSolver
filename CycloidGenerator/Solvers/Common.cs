using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator.Solvers
{
    public struct SolverPoint
    {
        public double X;
        public double Y;

        public SolverPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        // def toRect(r, a):
        //     return r*math.cos(a), r*math.sin(a)
        public static SolverPoint FromPolar(double r, double angle)
        {
            return new SolverPoint(r * Math.Cos(angle), r * Math.Sin(angle));
        }
    }


    public struct SolverPolar
    {
        public double D;
        public double Angle;

        public SolverPolar(double d, double angle)
        {
            D = d;
            Angle = angle;
        }

        // def toPolar(x, y):
        //     return (x**2 + y**2)**0.5, math.atan2(y, x)
        public static SolverPolar FromRect(double x, double y)
        {
            return new SolverPolar(Math.Sqrt(x * x + y * y), Math.Atan2(y, x));
        }
    }
}
