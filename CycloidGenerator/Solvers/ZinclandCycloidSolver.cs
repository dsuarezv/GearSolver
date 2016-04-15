using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator.Solvers
{
    public class ZinclandCycloidSolver: ISolver
    {
        public double p = 6;
        public double b = 24;
        public double d = 6;
        public double e = 2;
        public double ang = 50;
        public double c = 0;
        public double n = 9;
        public double s = 1000;
        public double ccd = 22;
        public double csd = 8;

        public IList<SolverParameter> GetParams()
        {
            return new SolverParameter[]
            {
                new SolverParameter("p", "Tooth pitch", 20, 0, 6),
                new SolverParameter("b", "Roller distance from center (overrides Tooth pitch)", 200, 0, 24),
                new SolverParameter("d", "Roller diameter", 20, 0, 6),
                new SolverParameter("e", "Cam eccentricity", 50, 0, 2),
                new SolverParameter("ang", "Pressure angle limit", 89, 0, 50),
                new SolverParameter("c", "Offset in pressure angle", 20, 0, 0),
                new SolverParameter("n", "Number of teeth in cam", 20, 2, 9) { SmallChange = 1, LargeChange = 5, IsInteger = true },
                new SolverParameter("s", "Line segments in DXF", 3000, 1, 1000),
                new SolverParameter("ccd", "Diameter of cam hole", 60, 4, 22),
                new SolverParameter("csd", "Diameter of driving shaft", 50, 2, 8),
            };
        }


        private static SolverPolar ToPolar(double x, double y)
        {
            return SolverPolar.FromRect(x, y);
        }

        private static SolverPoint ToRect(double r, double a)
        {
            return SolverPoint.FromPolar(r, a);
        }

        //def calcyp(a,e,n):
        //    return ath.atan(math.sin(n*a)/(math.cos(n*a)+(n*p)/(e*(n+1))))
        private double CalcCyp(double a, double e, double n)
        {
            return Math.Atan(Math.Sin(n * a) / (Math.Cos(n * a) + (n * p) / (e * (n + 1))));
        }

        //def calcX(p,d,e,n,a):
        //    return (n*p)*math.cos(a)+e*math.cos((n+1)*a)-d/2*math.cos(calcyp(a,e,n)+a)
        private double CalcX(double p, double d, double e, double n, double a)
        {
            return (n * p) * Math.Cos(a) + e * Math.Cos((n + 1) * a) - d / 2 * Math.Cos(CalcCyp(a, e, n) + a);
        }


        //def calcY(p,d,e,n,a):
        //    return (n*p)*math.sin(a)+e*math.sin((n+1)*a)-d/2*math.sin(calcyp(a,e,n)+a)
        private double CalcY(double p, double d, double e, double n, double a)
        {
            return (n * p) * Math.Sin(a) + e * Math.Sin((n + 1) * a) - d / 2 * Math.Sin(CalcCyp(a, e, n) + a);
        }

        //def calcPressureAngle(p,d,n,a):
        //    ex = 2**0.5
        //    r3 = p*n
        //    rg = r3/ex
        //    pp = rg * (ex**2 + 1 - 2*ex*math.cos(a))**0.5 - d/2
        //    return math.asin( (r3*math.cos(a)-rg)/(pp+d/2))*180/math.pi
        private double CalcPressureAngle(double p, double d, double n, double a)
        {
            var ex = Math.Sqrt(2);
            var r3 = p * n;
            var rg = r3 / ex;
            var pp = rg * Math.Sqrt(2 + 1 - 2 * ex * Math.Cos(a)) - d / 2;
            return Math.Asin((r3 * Math.Cos(a) - rg) / (pp + d / 2)) * 180 / Math.PI;
        }

        //def calcPressureLimit(p,d,e,n,a):
        //    ex = 2**0.5
        //    r3 = p*n
        //    rg = r3/ex
        //    q = (r3**2 + rg**2 - 2*r3*rg*math.cos(a))**0.5
        //    x = rg - e + (q-d/2)*(r3*math.cos(a)-rg)/q
        //    y = (q-d/2)*r3*math.sin(a)/q
        //    return (x**2 + y**2)**0.5
        private double CalcPressureLimit(double p, double d, double e, double n, double a)
        {
            var ex = Math.Sqrt(2);
            var r3 = p * n;
            var rg = r3 / ex;
            var q = Math.Sqrt(r3 * r3 + rg * rg - 2 * r3 * rg * Math.Cos(a));
            var x = rg - e + (q - d / 2) * (r3 * Math.Cos(a) - rg) / q;
            var y = (q - d / 2) * r3 * Math.Sin(a) / q;
            return Math.Sqrt(x * x + y * y);
        }

        //def checkLimit(x,y,maxrad,minrad,offset):
        //    r, a = toPolar(x, y)
        //    if (r > maxrad) or (r < minrad):
        //            r = r - offset
        //            x, y = toRect(r, a)
        //    return x, y
        private SolverPoint CheckLimit(double x, double y, double maxrad, double minrad, double offset)
        {
            var ra = ToPolar(x, y);
            var r = ra.D;
            var a = ra.Angle;

            var result = new SolverPoint(x, y);

            if (r > maxrad || r < minrad)
            {
                r = r - offset;
                result = ToRect(r, a);
            }
            return result;
        }

        public void Run(IExportClient cl)
        {
            if (cl == null) throw new Exception("null export client");

            //if b > 0:
            //    p = b/n
            if (b > 0) p = b / n;

            //q=2*math.pi/float(s)
            var q = 2.0 * Math.PI / s;

            //# Find the pressure angle limit circles
            //minAngle = -1.0
            //maxAngle = -1.0
            //for i in range(0, 180):
            //        x = calcPressureAngle(p,d,n,float(i)*math.pi/180)
            //        if (x < ang) and (minAngle < 0):
            //                minAngle = float(i)
            //        if (x < -ang) and (maxAngle < 0):
            //                maxAngle = float(i-1)
            //minRadius = calcPressureLimit(p,d,e,n,minAngle*math.pi/180)
            //maxRadius = calcPressureLimit(p,d,e,n,maxAngle*math.pi/180)
            //dxf.append( sdxf.Circle(center=(-e, 0), radius=minRadius, layer="pressure") )
            //dxf.append( sdxf.Circle(center=(-e, 0), radius=maxRadius, layer="pressure") )

            var minAngle = -1.0;
            var maxAngle = -1.0;

            for (int i = 0; i < 180; ++i)
            {
                var x = CalcPressureAngle(p, d, n, i * Math.PI / 180d);
                if (x < ang && minAngle < 0) minAngle = (double)i;
                if (x < -ang && maxAngle < 0) maxAngle = (double)(i - 1);
            }

            var minRadius = CalcPressureLimit(p, d, e, n, minAngle * Math.PI / 180d);
            var maxRadius = CalcPressureLimit(p, d, e, n, maxAngle * Math.PI / 180d);

            cl.Circle(new SolverPoint(-e, 0), minRadius, 2, "pressure");
            cl.Circle(new SolverPoint(-e, 0), maxRadius, 2, "pressure");


            //#generate the cam profile - note: shifted in -x by eccentricicy amount
            //i=0
            //x1 = calcX(p,d,e,n,q*i)
            //y1 = calcY(p,d,e,n,q*i)
            //x1, y1 = checkLimit(x1,y1,maxRadius, minRadius, c)
            //for i in range(0, s):
            //        x2 = calcX(p,d,e,n,q*(i+1))
            //        y2 = calcY(p,d,e,n,q*(i+1))
            //        x2, y2 = checkLimit(x2,y2,maxRadius, minRadius, c)
            //    dxf.append( sdxf.Line(points=[(x1-e,y1),  (x2-e,y2)], layer="cam" ) )
            //        x1 = x2
            //        y1 = y2
            var points = new List<SolverPoint>();

            var ii = 0;
            var x1 = CalcX(p, d, e, n, q * ii);
            var y1 = CalcY(p, d, e, n, q * ii);
            var xy1 = CheckLimit(x1, y1, maxRadius, minRadius, c);
            xy1.X -= e;
            points.Add(xy1);

            for (int j = 0; j < s; ++j)
            {
                var x2 = CalcX(p, d, e, n, q * (j + 1));
                var y2 = CalcY(p, d, e, n, q * (j + 1));
                var xy2 = CheckLimit(x2, y2, maxRadius, minRadius, c);

                xy2.X -= e;
                points.Add(xy2);
            }

            cl.Spline(points, 0, "cam");



            //#add a circle in the center of the cam
            //dxf.append( sdxf.Circle(center=(-e, 0), radius=d/2, layer="cam") )

            cl.Circle(new SolverPoint(-e, 0), ccd / 2, 0, "cam");

            //#generate the pin locations
            //for i in range(0, n+1):
            //    x = p*n*math.cos(2*math.pi/(n+1)*i)
            //    y = p*n*math.sin(2*math.pi/(n+1)*i)
            //    dxf.append( sdxf.Circle(center=(x,y), radius=d/2, layer="roller") )
            //#add a circle in the center of the pins
            //dxf.append( sdxf.Circle(center=(0, 0), radius=d/2, layer="roller") )
            for (int k = 0; k < n + 1; ++k)
            {
                var x = p * n * Math.Cos(2 * Math.PI / (n + 1) * k);
                var y = p * n * Math.Sin(2 * Math.PI / (n + 1) * k);
                cl.Circle(new SolverPoint(x, y), d / 2, 1, "roller");
            }

            cl.Circle(new SolverPoint(0, 0), csd / 2, 1, "roller");
        }

        public string Name
        {
            get { return "Cycloidal Gear"; }
        }

        public string Description
        {
            get
            {
                return @"2015 David Suárez. This is a port of the python script by Alex Lait (see url below).

Original readme and notice: 
---------------------------

Copyright 	2009, Alex Lait
Version 	v0.2 (09/13/09)
License 	GPL
Homepage 	http://www.zincland.com/hypocycloid

Credit to:
	Formulas to describe a hypocycloid cam
	http://gears.ru/transmis/zaprogramata/2.139.pdf

	Insperational thread on CNCzone
	http://www.cnczone.com/forums/showthread.php?t=72261

	Documenting and updating the sdxf library
	http://www.kellbot.com/sdxf-python-library-for-dxf/

	Formulas for calculating the pressure angle and finding the limit circles
	http://imtuoradea.ro/auo.fmte/files-2007/MECATRONICA_files/Anamaria_Dascalescu_1.pdf

Notes:
	Does not currently do ANY checking for sane input values and it
	is possible to create un-machinable cams, use at your own risk
Suggestions:
	- Eccentricity should not be more than the roller radius
	- Has not been tested with negative values, may have interesting results :)
            ";
            }
        }
    }
}
