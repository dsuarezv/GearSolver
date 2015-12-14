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
            this.dependencyTrackBar10 = new CycloidGenerator.DependencyTrackBar();
            this.dependencyTrackBar9 = new CycloidGenerator.DependencyTrackBar();
            this.dependencyTrackBar8 = new CycloidGenerator.DependencyTrackBar();
            this.dependencyTrackBar7 = new CycloidGenerator.DependencyTrackBar();
            this.dependencyTrackBar6 = new CycloidGenerator.DependencyTrackBar();
            this.dependencyTrackBar5 = new CycloidGenerator.DependencyTrackBar();
            this.dependencyTrackBar4 = new CycloidGenerator.DependencyTrackBar();
            this.dependencyTrackBar3 = new CycloidGenerator.DependencyTrackBar();
            this.dependencyTrackBar2 = new CycloidGenerator.DependencyTrackBar();
            this.dependencyTrackBar1 = new CycloidGenerator.DependencyTrackBar();
            this.cycloidControl1 = new CycloidGenerator.CycloidControl();
            this.SuspendLayout();
            // 
            // ExportDxfButton
            // 
            this.ExportDxfButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExportDxfButton.Location = new System.Drawing.Point(3, 510);
            this.ExportDxfButton.Name = "ExportDxfButton";
            this.ExportDxfButton.Size = new System.Drawing.Size(223, 23);
            this.ExportDxfButton.TabIndex = 1;
            this.ExportDxfButton.Text = "Export DXF...";
            this.ExportDxfButton.UseVisualStyleBackColor = true;
            this.ExportDxfButton.Click += new System.EventHandler(this.ExportDxfButton_Click);
            // 
            // dependencyTrackBar10
            // 
            this.dependencyTrackBar10.DependencyObject = null;
            this.dependencyTrackBar10.DependencyPropertyName = "CenterShaftDiameter";
            this.dependencyTrackBar10.LargeChange = 1D;
            this.dependencyTrackBar10.Location = new System.Drawing.Point(13, 391);
            this.dependencyTrackBar10.Maximum = 50D;
            this.dependencyTrackBar10.Minimum = 2D;
            this.dependencyTrackBar10.Name = "dependencyTrackBar10";
            this.dependencyTrackBar10.Size = new System.Drawing.Size(228, 36);
            this.dependencyTrackBar10.SmallChange = 0.1D;
            this.dependencyTrackBar10.TabIndex = 11;
            this.dependencyTrackBar10.Value = 2D;
            this.dependencyTrackBar10.TargetChanged += new System.EventHandler(this.CycloidTrackBar_TargetChanged);
            // 
            // dependencyTrackBar9
            // 
            this.dependencyTrackBar9.DependencyObject = null;
            this.dependencyTrackBar9.DependencyPropertyName = "CenterCamDiameter";
            this.dependencyTrackBar9.LargeChange = 1D;
            this.dependencyTrackBar9.Location = new System.Drawing.Point(12, 349);
            this.dependencyTrackBar9.Maximum = 80D;
            this.dependencyTrackBar9.Minimum = 4D;
            this.dependencyTrackBar9.Name = "dependencyTrackBar9";
            this.dependencyTrackBar9.Size = new System.Drawing.Size(228, 36);
            this.dependencyTrackBar9.SmallChange = 0.1D;
            this.dependencyTrackBar9.TabIndex = 10;
            this.dependencyTrackBar9.Value = 4D;
            this.dependencyTrackBar9.TargetChanged += new System.EventHandler(this.CycloidTrackBar_TargetChanged);
            // 
            // dependencyTrackBar8
            // 
            this.dependencyTrackBar8.DependencyObject = null;
            this.dependencyTrackBar8.DependencyPropertyName = "s";
            this.dependencyTrackBar8.LargeChange = 1D;
            this.dependencyTrackBar8.Location = new System.Drawing.Point(12, 307);
            this.dependencyTrackBar8.Maximum = 3000D;
            this.dependencyTrackBar8.Minimum = 0D;
            this.dependencyTrackBar8.Name = "dependencyTrackBar8";
            this.dependencyTrackBar8.Size = new System.Drawing.Size(228, 36);
            this.dependencyTrackBar8.SmallChange = 0.1D;
            this.dependencyTrackBar8.TabIndex = 9;
            this.dependencyTrackBar8.Value = 0D;
            this.dependencyTrackBar8.TargetChanged += new System.EventHandler(this.CycloidTrackBar_TargetChanged);
            // 
            // dependencyTrackBar7
            // 
            this.dependencyTrackBar7.DependencyObject = null;
            this.dependencyTrackBar7.DependencyPropertyName = "n";
            this.dependencyTrackBar7.LargeChange = 5D;
            this.dependencyTrackBar7.Location = new System.Drawing.Point(13, 265);
            this.dependencyTrackBar7.Maximum = 100D;
            this.dependencyTrackBar7.Minimum = 0D;
            this.dependencyTrackBar7.Name = "dependencyTrackBar7";
            this.dependencyTrackBar7.Size = new System.Drawing.Size(228, 36);
            this.dependencyTrackBar7.SmallChange = 10D;
            this.dependencyTrackBar7.TabIndex = 8;
            this.dependencyTrackBar7.Value = 0D;
            this.dependencyTrackBar7.TargetChanged += new System.EventHandler(this.CycloidTrackBar_TargetChanged);
            // 
            // dependencyTrackBar6
            // 
            this.dependencyTrackBar6.DependencyObject = null;
            this.dependencyTrackBar6.DependencyPropertyName = "c";
            this.dependencyTrackBar6.LargeChange = 1D;
            this.dependencyTrackBar6.Location = new System.Drawing.Point(13, 223);
            this.dependencyTrackBar6.Maximum = 30D;
            this.dependencyTrackBar6.Minimum = 0D;
            this.dependencyTrackBar6.Name = "dependencyTrackBar6";
            this.dependencyTrackBar6.Size = new System.Drawing.Size(228, 36);
            this.dependencyTrackBar6.SmallChange = 0.1D;
            this.dependencyTrackBar6.TabIndex = 7;
            this.dependencyTrackBar6.Value = 0D;
            this.dependencyTrackBar6.TargetChanged += new System.EventHandler(this.CycloidTrackBar_TargetChanged);
            // 
            // dependencyTrackBar5
            // 
            this.dependencyTrackBar5.DependencyObject = null;
            this.dependencyTrackBar5.DependencyPropertyName = "ang";
            this.dependencyTrackBar5.LargeChange = 1D;
            this.dependencyTrackBar5.Location = new System.Drawing.Point(13, 181);
            this.dependencyTrackBar5.Maximum = 180D;
            this.dependencyTrackBar5.Minimum = 0D;
            this.dependencyTrackBar5.Name = "dependencyTrackBar5";
            this.dependencyTrackBar5.Size = new System.Drawing.Size(228, 36);
            this.dependencyTrackBar5.SmallChange = 0.1D;
            this.dependencyTrackBar5.TabIndex = 6;
            this.dependencyTrackBar5.Value = 0D;
            this.dependencyTrackBar5.TargetChanged += new System.EventHandler(this.CycloidTrackBar_TargetChanged);
            // 
            // dependencyTrackBar4
            // 
            this.dependencyTrackBar4.DependencyObject = null;
            this.dependencyTrackBar4.DependencyPropertyName = "e";
            this.dependencyTrackBar4.LargeChange = 1D;
            this.dependencyTrackBar4.Location = new System.Drawing.Point(13, 139);
            this.dependencyTrackBar4.Maximum = 10D;
            this.dependencyTrackBar4.Minimum = 0D;
            this.dependencyTrackBar4.Name = "dependencyTrackBar4";
            this.dependencyTrackBar4.Size = new System.Drawing.Size(228, 36);
            this.dependencyTrackBar4.SmallChange = 0.1D;
            this.dependencyTrackBar4.TabIndex = 5;
            this.dependencyTrackBar4.Value = 0D;
            this.dependencyTrackBar4.TargetChanged += new System.EventHandler(this.CycloidTrackBar_TargetChanged);
            // 
            // dependencyTrackBar3
            // 
            this.dependencyTrackBar3.DependencyObject = null;
            this.dependencyTrackBar3.DependencyPropertyName = "d";
            this.dependencyTrackBar3.LargeChange = 1D;
            this.dependencyTrackBar3.Location = new System.Drawing.Point(13, 97);
            this.dependencyTrackBar3.Maximum = 30D;
            this.dependencyTrackBar3.Minimum = 0D;
            this.dependencyTrackBar3.Name = "dependencyTrackBar3";
            this.dependencyTrackBar3.Size = new System.Drawing.Size(228, 36);
            this.dependencyTrackBar3.SmallChange = 0.1D;
            this.dependencyTrackBar3.TabIndex = 4;
            this.dependencyTrackBar3.Value = 0D;
            this.dependencyTrackBar3.TargetChanged += new System.EventHandler(this.CycloidTrackBar_TargetChanged);
            // 
            // dependencyTrackBar2
            // 
            this.dependencyTrackBar2.DependencyObject = null;
            this.dependencyTrackBar2.DependencyPropertyName = "b";
            this.dependencyTrackBar2.LargeChange = 1D;
            this.dependencyTrackBar2.Location = new System.Drawing.Point(13, 55);
            this.dependencyTrackBar2.Maximum = 200D;
            this.dependencyTrackBar2.Minimum = 0D;
            this.dependencyTrackBar2.Name = "dependencyTrackBar2";
            this.dependencyTrackBar2.Size = new System.Drawing.Size(228, 36);
            this.dependencyTrackBar2.SmallChange = 0.1D;
            this.dependencyTrackBar2.TabIndex = 3;
            this.dependencyTrackBar2.Value = 0D;
            this.dependencyTrackBar2.TargetChanged += new System.EventHandler(this.CycloidTrackBar_TargetChanged);
            // 
            // dependencyTrackBar1
            // 
            this.dependencyTrackBar1.DependencyObject = null;
            this.dependencyTrackBar1.DependencyPropertyName = "p";
            this.dependencyTrackBar1.LargeChange = 1D;
            this.dependencyTrackBar1.Location = new System.Drawing.Point(13, 13);
            this.dependencyTrackBar1.Maximum = 20D;
            this.dependencyTrackBar1.Minimum = 0D;
            this.dependencyTrackBar1.Name = "dependencyTrackBar1";
            this.dependencyTrackBar1.Size = new System.Drawing.Size(228, 36);
            this.dependencyTrackBar1.SmallChange = 0.1D;
            this.dependencyTrackBar1.TabIndex = 2;
            this.dependencyTrackBar1.Value = 0D;
            this.dependencyTrackBar1.TargetChanged += new System.EventHandler(this.CycloidTrackBar_TargetChanged);
            // 
            // cycloidControl1
            // 
            this.cycloidControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cycloidControl1.Cycloid = null;
            this.cycloidControl1.DrawGrid = true;
            this.cycloidControl1.Location = new System.Drawing.Point(264, 13);
            this.cycloidControl1.Name = "cycloidControl1";
            this.cycloidControl1.Size = new System.Drawing.Size(551, 520);
            this.cycloidControl1.TabIndex = 0;
            this.cycloidControl1.Text = "cycloidControl1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 545);
            this.Controls.Add(this.dependencyTrackBar10);
            this.Controls.Add(this.dependencyTrackBar9);
            this.Controls.Add(this.dependencyTrackBar8);
            this.Controls.Add(this.dependencyTrackBar7);
            this.Controls.Add(this.dependencyTrackBar6);
            this.Controls.Add(this.dependencyTrackBar5);
            this.Controls.Add(this.dependencyTrackBar4);
            this.Controls.Add(this.dependencyTrackBar3);
            this.Controls.Add(this.dependencyTrackBar2);
            this.Controls.Add(this.dependencyTrackBar1);
            this.Controls.Add(this.ExportDxfButton);
            this.Controls.Add(this.cycloidControl1);
            this.Name = "MainForm";
            this.Text = "Cycloidal gear calculator";
            this.ResumeLayout(false);

        }

        #endregion

        private CycloidControl cycloidControl1;
        private System.Windows.Forms.Button ExportDxfButton;
        private DependencyTrackBar dependencyTrackBar1;
        private DependencyTrackBar dependencyTrackBar2;
        private DependencyTrackBar dependencyTrackBar3;
        private DependencyTrackBar dependencyTrackBar4;
        private DependencyTrackBar dependencyTrackBar5;
        private DependencyTrackBar dependencyTrackBar6;
        private DependencyTrackBar dependencyTrackBar7;
        private DependencyTrackBar dependencyTrackBar8;
        private DependencyTrackBar dependencyTrackBar9;
        private DependencyTrackBar dependencyTrackBar10;
    }
}

