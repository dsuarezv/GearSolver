using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CycloidGenerator
{
    public partial class MainForm : Form
    {
        private Cycloid mCycloid = new Cycloid()
            {
                p = 8,
                d = 15,
                e = 5,
                ang = 50.0,
                c = 1,
                n = 10, 
                s = 400
            };

        public MainForm()
        {
            InitializeComponent();

            cycloidControl1.Cycloid = mCycloid;
            dependencyTrackBar1.DependencyObject = mCycloid;
            dependencyTrackBar2.DependencyObject = mCycloid;
            dependencyTrackBar3.DependencyObject = mCycloid;
            dependencyTrackBar4.DependencyObject = mCycloid;
            dependencyTrackBar5.DependencyObject = mCycloid;
            dependencyTrackBar6.DependencyObject = mCycloid;
            dependencyTrackBar7.DependencyObject = mCycloid;
            dependencyTrackBar8.DependencyObject = mCycloid;
        }

        private void SampleButton_Click(object sender, EventArgs e)
        {
            
        }

        private void CycloidTrackBar_TargetChanged(object sender, EventArgs e)
        {
            cycloidControl1.Invalidate();
        }
    }
}
