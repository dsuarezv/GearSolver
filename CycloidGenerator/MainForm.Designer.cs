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
            this.cycloidControl1 = new CycloidGenerator.CycloidControl();
            this.SampleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cycloidControl1
            // 
            this.cycloidControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cycloidControl1.Cycloid = null;
            this.cycloidControl1.Location = new System.Drawing.Point(264, 13);
            this.cycloidControl1.Name = "cycloidControl1";
            this.cycloidControl1.Size = new System.Drawing.Size(551, 520);
            this.cycloidControl1.TabIndex = 0;
            this.cycloidControl1.Text = "cycloidControl1";
            // 
            // SampleButton
            // 
            this.SampleButton.Location = new System.Drawing.Point(13, 359);
            this.SampleButton.Name = "SampleButton";
            this.SampleButton.Size = new System.Drawing.Size(75, 23);
            this.SampleButton.TabIndex = 1;
            this.SampleButton.Text = "DrawSample";
            this.SampleButton.UseVisualStyleBackColor = true;
            this.SampleButton.Click += new System.EventHandler(this.SampleButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 545);
            this.Controls.Add(this.SampleButton);
            this.Controls.Add(this.cycloidControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CycloidControl cycloidControl1;
        private System.Windows.Forms.Button SampleButton;
    }
}

