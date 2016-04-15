using CycloidGenerator.Solvers;
using MadMilkman.Ini;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
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

        private void SetSolverByName(string solverName)
        {
            var solvers = SolverManager.GetSolvers();

            foreach (var s in solvers)
            {
                if (s.Name == solverName) SetSolver(s);
            }
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
            const int NumSmallChangeDivisions = 200;

            var dp = new DependencyTrackBar();

            dp.DependencyPropertyName = p.DependencyPropertyName;
            dp.Width = ParamsPanel.Width;
            dp.Top = y;
            dp.IsInteger = p.IsInteger;
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
            if (dxfSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                DxfExporter.Export(mSolver, dxfSaveFileDialog.FileName);
            }
        }


        private void SaveParamsButton_Click(object sender, EventArgs e)
        {
            if (cfgSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveCurrentParams(cfgSaveFileDialog.FileName);
            }
        }

        private void SolverCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSolver(SolverCombo.SelectedItem as ISolver);
        }


        // __ Config serialization ____________________________________________


        private void SaveCurrentParams(string fileName)
        {
            var ini = new IniFile();
            var data = ini.Sections.Add("Data");
            data.Keys.Add("Solver", mSolver.Name);

            foreach (Control c in ParamsPanel.Controls)
            {
                var t = c as DependencyTrackBar;
                if (t == null) continue;

                data.Keys.Add(t.DependencyPropertyName, t.Value.ToString(CultureInfo.InvariantCulture));
            }

            ini.Save(fileName);
        }

        private void LoadParams(string fileName)
        {
            var ini = new IniFile();
            ini.Load(fileName);
            var data = ini.Sections["Data"];

            var solver = data.Keys["Solver"].Value;
            if (solver != mSolver.Name) SetSolverByName(solver);
            
            foreach (Control c in ParamsPanel.Controls)
            {
                var t = c as DependencyTrackBar;
                if (t == null) continue;

                t.Value = double.Parse(data.Keys[t.DependencyPropertyName].Value, CultureInfo.InvariantCulture);
            }            
        }

        
        // __ Drag & drop _____________________________________________________

        
        private void gearVisualizer1_DragEnter(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fileList.Length != 1) return;

            var ext = Path.GetExtension(fileList[0]);
            if (ext.ToLower() != ".solvercfg") return;

            e.Effect = DragDropEffects.Copy;
        }

        private void gearVisualizer1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length != 1) return;

            LoadParams(files[0]);
        }

        private void gearVisualizer1_DragOver(object sender, DragEventArgs e)
        {

        }

    }
}
