using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator
{
    public class SolverParameter
    {
        private double mValue;

        public string DependencyPropertyName;
        public string Caption;
        public string Hint;
        public double MaxValue;
        public double MinValue;
        public double DefaultValue;
        public double LargeChange;
        public double SmallChange;
        
        public bool IsInteger = false;
        public bool IsReadOnly = false;

        public double Value
        {
            get { return mValue; }
            set
            {
                if (mValue == value) return;

                mValue = value;
                ValueChanged?.Invoke(mValue);
            }
        }


        public event Action<double> ValueChanged;


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
