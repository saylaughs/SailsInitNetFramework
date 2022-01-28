
namespace SailsInitNetFramework
{
    partial class InitPro
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
            this.chartExt1 = new WinformControlLibraryExtension.ChartExt();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chartExt1
            // 
            this.chartExt1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.chartExt1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(112)))), ((int)(((byte)(219)))));
            this.chartExt1.LineDotColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(112)))), ((int)(((byte)(219)))));
            this.chartExt1.Location = new System.Drawing.Point(-5, -36);
            this.chartExt1.Name = "chartExt1";
            this.chartExt1.Size = new System.Drawing.Size(2946, 2575);
            this.chartExt1.TabIndex = 0;
            this.chartExt1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 1;
            // 
            // InitPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartExt1);
            this.Name = "InitPro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建项目";
            this.Load += new System.EventHandler(this.InitPro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinformControlLibraryExtension.ChartExt chartExt1;
        private System.Windows.Forms.Label label1;
    }
}