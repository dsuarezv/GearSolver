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
                p = 6,
                d = 15,
                e = 4,
                ang = 50.0,
                c = 0,
                n = 10, 
                s = 1000
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
            dependencyTrackBar9.DependencyObject = mCycloid;
            dependencyTrackBar10.DependencyObject = mCycloid;
        }

        private void ExportDxfButton_Click(object sender, EventArgs e)
        {
            DxfExporter.ExportCycloid(mCycloid, "test.dxf");
        }

        private void CycloidTrackBar_TargetChanged(object sender, EventArgs e)
        {
            cycloidControl1.Invalidate();
        }
    }
}
