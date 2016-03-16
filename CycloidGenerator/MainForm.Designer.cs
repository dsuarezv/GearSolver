namespace CycloidGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExportDxfButton = new System.Windows.Forms.Button();
            this.ParamsPanel = new System.Windows.Forms.Panel();
            this.dxfSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SolverCombo = new System.Windows.Forms.ComboBox();
            this.SaveParamsButton = new System.Windows.Forms.Button();
            this.cfgSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.gearVisualizer1 = new CycloidGenerator.SolverGraphControl();
            this.SuspendLayout();
            // 
            // ExportDxfButton
            // 
            this.ExportDxfButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExportDxfButton.Location = new System.Drawing.Point(3, 561);
            this.ExportDxfButton.Name = "ExportDxfButton";
            this.ExportDxfButton.Size = new System.Drawing.Size(255, 23);
            this.ExportDxfButton.TabIndex = 1;
            this.ExportDxfButton.Text = "Export DXF...";
            this.ExportDxfButton.UseVisualStyleBackColor = true;
            this.ExportDxfButton.Click += new System.EventHandler(this.ExportDxfButton_Click);
            // 
            // ParamsPanel
            // 
            this.ParamsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ParamsPanel.Location = new System.Drawing.Point(3, 45);
            this.ParamsPanel.Name = "ParamsPanel";
            this.ParamsPanel.Size = new System.Drawing.Size(255, 486);
            this.ParamsPanel.TabIndex = 2;
            // 
            // dxfSaveFileDialog
            // 
            this.dxfSaveFileDialog.DefaultExt = "dxf";
            this.dxfSaveFileDialog.Filter = "DXF files|*.dxf|All files|*.*";
            this.dxfSaveFileDialog.Title = "Export as DXF...";
            // 
            // SolverCombo
            // 
            this.SolverCombo.DisplayMember = "Name";
            this.SolverCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SolverCombo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SolverCombo.FormattingEnabled = true;
            this.SolverCombo.Location = new System.Drawing.Point(5, 11);
            this.SolverCombo.Name = "SolverCombo";
            this.SolverCombo.Size = new System.Drawing.Size(253, 25);
            this.SolverCombo.TabIndex = 3;
            this.SolverCombo.SelectedIndexChanged += new System.EventHandler(this.SolverCombo_SelectedIndexChanged);
            // 
            // SaveParamsButton
            // 
            this.SaveParamsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveParamsButton.Location = new System.Drawing.Point(3, 535);
            this.SaveParamsButton.Name = "SaveParamsButton";
            this.SaveParamsButton.Size = new System.Drawing.Size(255, 23);
            this.SaveParamsButton.TabIndex = 4;
            this.SaveParamsButton.Text = "Save params...";
            this.SaveParamsButton.UseVisualStyleBackColor = true;
            this.SaveParamsButton.Click += new System.EventHandler(this.SaveParamsButton_Click);
            // 
            // cfgSaveFileDialog
            // 
            this.cfgSaveFileDialog.DefaultExt = "solvercfg";
            this.cfgSaveFileDialog.Filter = "SOLVERCFG files|*.solvercfg|All files|*.*";
            this.cfgSaveFileDialog.Title = "Save solver parameters...";
            // 
            // gearVisualizer1
            // 
            this.gearVisualizer1.AllowDrop = true;
            this.gearVisualizer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gearVisualizer1.DrawGrid = true;
            this.gearVisualizer1.Location = new System.Drawing.Point(264, 13);
            this.gearVisualizer1.Name = "gearVisualizer1";
            this.gearVisualizer1.Size = new System.Drawing.Size(587, 565);
            this.gearVisualizer1.Solver = null;
            this.gearVisualizer1.TabIndex = 0;
            this.gearVisualizer1.Text = "cycloidControl1";
            this.gearVisualizer1.DragDrop += new System.Windows.Forms.DragEventHandler(this.gearVisualizer1_DragDrop);
            this.gearVisualizer1.DragEnter += new System.Windows.Forms.DragEventHandler(this.gearVisualizer1_DragEnter);
            this.gearVisualizer1.DragOver += new System.Windows.Forms.DragEventHandler(this.gearVisualizer1_DragOver);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 590);
            this.Controls.Add(this.SaveParamsButton);
            this.Controls.Add(this.SolverCombo);
            this.Controls.Add(this.ParamsPanel);
            this.Controls.Add(this.ExportDxfButton);
            this.Controls.Add(this.gearVisualizer1);
            this.Name = "MainForm";
            this.Text = "Cycloidal gear calculator";
            this.ResumeLayout(false);

        }

        #endregion

        private SolverGraphControl gearVisualizer1;
        private System.Windows.Forms.Button ExportDxfButton;
        private System.Windows.Forms.Panel ParamsPanel;
        private System.Windows.Forms.SaveFileDialog dxfSaveFileDialog;
        private System.Windows.Forms.ComboBox SolverCombo;
        private System.Windows.Forms.Button SaveParamsButton;
        private System.Windows.Forms.SaveFileDialog cfgSaveFileDialog;
    }
}

