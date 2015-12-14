using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CycloidGenerator
{
    public partial class DependencyTrackBar : UserControl
    {
        private object mDepObject;
        private string mDepPropertyName;
        private string mCaption;
        private string mHint; 


        public event EventHandler TargetChanged;

        public string Caption
        {
            get { return mCaption; }
            set { mCaption = value; CaptionLabel.Text = value; }
        }

        public string Hint
        {
            get { return mHint; }
            set { mHint = value; Invalidate(); }
        }

        public object DependencyObject 
        {
            get { return mDepObject; }
            set { mDepObject = value; ReadFromObject(); }
        }
        
        public string DependencyPropertyName 
        {
            get { return mDepPropertyName; }
            set { mDepPropertyName = value; CaptionLabel.Text = value; ReadFromObject(); }
        }
        
        public double Minimum 
        {
            get { return trackBar1.Minimum / 100d; }
            set { trackBar1.Minimum = (int)(value * 100d); }
        }
        
        public double Maximum 
        {
            get { return trackBar1.Maximum / 100d; }
            set { trackBar1.Maximum = (int)(value * 100d); } 
        }

        public double Value
        {
            get { return trackBar1.Value / 100d; }
            set { trackBar1.Value = (int)(value * 100d); }
        }

        public double LargeChange
        {
            get { return trackBar1.LargeChange / 100d; }
            set { trackBar1.LargeChange = (int)(value * 100d); }
        }

        public double SmallChange
        {
            get { return trackBar1.SmallChange / 100d; }
            set { trackBar1.SmallChange = (int)(value * 100d); }
        }

        public DependencyTrackBar()
        {
            InitializeComponent();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            WriteToObject();
        }

        private void ReadFromObject()
        {
            if (DependencyObject == null || DependencyPropertyName == null) return;

            var field = DependencyObject.GetType().GetField(DependencyPropertyName);
            var val = field.GetValue(DependencyObject);

            if (val is double) Value = (double)val;

            ValueLabel.Text = Value.ToString();
        }

        private void WriteToObject()
        {
            if (DependencyObject == null || DependencyPropertyName == null) return;

            var field = DependencyObject.GetType().GetField(DependencyPropertyName);
            field.SetValue(DependencyObject, Value);

            if (TargetChanged != null) TargetChanged(this, EventArgs.Empty);

            ValueLabel.Text = Value.ToString();
        }
    }
}
