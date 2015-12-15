using CycloidGenerator.Solvers;
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
        private ISolver mSolver;

        public MainForm()
        {
            InitializeComponent();

            InitSolvers();

            //SetSolver(
            //    new ZinclandCycloidSolver()
            //    {
            //        p = 6,
            //        d = 15,
            //        e = 4,
            //        ang = 50.0,
            //        c = 0,
            //        n = 10,
            //        s = 1000
            //    }
            //);

            //SetSolver(new SampleSolver() { Angle = 60 });
        }


        // __ Impl ____________________________________________________________

        
        private void InitSolvers()
        {
            foreach (var s in SolverManager.GetSolvers())
            {
                SolverCombo.Items.Add(s);
            }

            SolverCombo.SelectedIndex = 0;
        }

        private void SetSolver(ISolver solver)
        {
            if (solver == null) return;

            mSolver = solver;
            
            var pars = solver.GetParams();
            if (pars != null) CreateParamsControls(pars);

            gearVisualizer1.Solver = solver;
        }

        private void CreateParamsControls(IList<SolverParameter> pars)
        {
            ParamsPanel.SuspendLayout();
            ParamsPanel.Controls.Clear();

            int currentY = 0;

            foreach (var p in pars)
            {
                CreateTrackBarForParam(p, ref currentY);
            }

            ParamsPanel.ResumeLayout();
        }

        private void CreateTrackBarForParam(SolverParameter p, ref int y)
        {
            const int NumLargeChangeDivisions = 10;
            const int NumSmallChangeDivisions = 100;

            var dp = new DependencyTrackBar();

            dp.DependencyPropertyName = p.DependencyPropertyName;
            dp.Width = ParamsPanel.Width;
            dp.Top = y;
            dp.Maximum = p.MaxValue; 
            dp.Minimum = p.MinValue;
            dp.Value = p.DefaultValue;
            dp.Caption = p.Caption;
            dp.Hint = p.Hint;
            dp.LargeChange = p.LargeChange == 0 ? (p.MaxValue - p.MinValue) / NumLargeChangeDivisions : p.LargeChange;
            dp.SmallChange = p.SmallChange == 0 ? (p.MaxValue - p.MinValue) / NumSmallChangeDivisions : p.SmallChange;
            dp.TargetChanged += (s, e) => { gearVisualizer1.Invalidate(); p.Value = dp.Value; };
            dp.DependencyObject = mSolver;

            y += dp.Height;

            ParamsPanel.Controls.Add(dp);
        }

        private void ExportDxfButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DxfExporter.ExportCycloid(mSolver, saveFileDialog1.FileName);
            }
        }

        private void SolverCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSolver(SolverCombo.SelectedItem as ISolver);
        }
    }
}
