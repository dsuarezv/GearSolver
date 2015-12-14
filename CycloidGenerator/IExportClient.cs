using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator
{
    public interface IExportClient
    {
        void Circle(Point center, double radius, int color, string layer);
        void Line(Point p1, Point p2, int color, string layer);
    }
}
