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
        private const double FixedPointMultiplier = 100d;

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
            get { return trackBar1.Minimum / FixedPointMultiplier; }
            set { trackBar1.Minimum = (int)(value * FixedPointMultiplier); }
        }
        
        public double Maximum 
        {
            get { return trackBar1.Maximum / FixedPointMultiplier; }
            set { trackBar1.Maximum = (int)(value * FixedPointMultiplier); } 
        }

        public double Value
        {
            get { return trackBar1.Value / FixedPointMultiplier; }
            set { trackBar1.Value = (int)(value * FixedPointMultiplier); }
        }

        public double LargeChange
        {
            get { return trackBar1.LargeChange / FixedPointMultiplier; }
            set { trackBar1.LargeChange = (int)(value * FixedPointMultiplier); }
        }

        public double SmallChange
        {
            get { return trackBar1.SmallChange / FixedPointMultiplier; }
            set 
            { 
                trackBar1.SmallChange = (int)(value * FixedPointMultiplier); 
                trackBar1.TickFrequency = trackBar1.LargeChange; 
            }
        }

        public DependencyTrackBar()
        {
            InitializeComponent();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            //var bar = (TrackBar)sender;
            
            //if (bar.Value % bar.SmallChange != 0)
            //{
            //    bar.Value = bar.SmallChange * ((bar.Value + bar.SmallChange / 2) / bar.SmallChange);
            //}

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


        // __ ValueTextbox impl _______________________________________________


        private void ValueTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double val;
                if (double.TryParse(ValueTextbox.Text, out val))
                {
                    Value = val;
                }

                SetTextBox(false);
            }
        }

        private void SetTextBox(bool visible)
        {
            ValueLabel.Visible = !visible;
            ValueTextbox.Visible = visible;
        }

        private void ValueLabel_DoubleClick(object sender, EventArgs e)
        {
            ValueTextbox.Text = Value.ToString();
            ValueTextbox.SelectAll();
            SetTextBox(true);
            ValueTextbox.Focus();
        }
    }
}
