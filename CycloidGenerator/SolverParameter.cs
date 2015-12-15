using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator
{
    public class SolverParameter
    {
        public string DependencyPropertyName;
        public string Caption;
        public string Hint;
        public double MaxValue;
        public double MinValue;
        public double DefaultValue;
        public double LargeChange;
        public double SmallChange;


        public SolverParameter(string depPropName, string caption, double maxv, double minv, double defv)
        {
            DependencyPropertyName = depPropName;
            Caption = caption;
            MaxValue = maxv;
            MinValue = minv;
            DefaultValue = defv;
        }
    }
}
