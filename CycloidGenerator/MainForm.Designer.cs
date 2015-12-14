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
            this.SolverNameLabel = new System.Windows.Forms.Label();
            this.gearVisualizer1 = new CycloidGenerator.GearVisualControl();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // ExportDxfButton
            // 
            this.ExportDxfButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExportDxfButton.Location = new System.Drawing.Point(3, 510);
            this.ExportDxfButton.Name = "ExportDxfButton";
            this.ExportDxfButton.Size = new System.Drawing.Size(255, 23);
            this.ExportDxfButton.TabIndex = 1;
            this.ExportDxfButton.Text = "Export DXF...";
            this.ExportDxfButton.UseVisualStyleBackColor = true;
            this.ExportDxfButton.Click += new System.EventHandler(this.ExportDxfButton_Click);
            // 
            // ParamsPanel
            // 
            this.ParamsPanel.Location = new System.Drawing.Point(3, 45);
            this.ParamsPanel.Name = "ParamsPanel";
            this.ParamsPanel.Size = new System.Drawing.Size(255, 459);
            this.ParamsPanel.TabIndex = 2;
            // 
            // SolverNameLabel
            // 
            this.SolverNameLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SolverNameLabel.Location = new System.Drawing.Point(5, 8);
            this.SolverNameLabel.Name = "SolverNameLabel";
            this.SolverNameLabel.Size = new System.Drawing.Size(253, 28);
            this.SolverNameLabel.TabIndex = 3;
            // 
            // gearVisualizer1
            // 
            this.gearVisualizer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gearVisualizer1.DrawGrid = true;
            this.gearVisualizer1.Location = new System.Drawing.Point(264, 13);
            this.gearVisualizer1.Name = "gearVisualizer1";
            this.gearVisualizer1.Size = new System.Drawing.Size(551, 520);
            this.gearVisualizer1.Solver = null;
            this.gearVisualizer1.TabIndex = 0;
            this.gearVisualizer1.Text = "cycloidControl1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "dxf";
            this.saveFileDialog1.Filter = "DXF files|*.dxf|All files|*.*";
            this.saveFileDialog1.Title = "Export as DXF...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 545);
            this.Controls.Add(this.SolverNameLabel);
            this.Controls.Add(this.ParamsPanel);
            this.Controls.Add(this.ExportDxfButton);
            this.Controls.Add(this.gearVisualizer1);
            this.Name = "MainForm";
            this.Text = "Cycloidal gear calculator";
            this.ResumeLayout(false);

        }

        #endregion

        private GearVisualControl gearVisualizer1;
        private System.Windows.Forms.Button ExportDxfButton;
        private System.Windows.Forms.Panel ParamsPanel;
        private System.Windows.Forms.Label SolverNameLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

