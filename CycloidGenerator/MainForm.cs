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
        private Cycloid mCycloid;

        public MainForm()
        {
            InitializeComponent();
        }

        private void SampleButton_Click(object sender, EventArgs e)
        {
            mCycloid = new Cycloid()
            {
                p = 0.08,
                d = 0.15,
                e = 0.05,
                ang = 50.0,
                c = 0.01,
                n = 10, 
                s = 400
            };

            cycloidControl1.Cycloid = mCycloid;
        }
    }
}
