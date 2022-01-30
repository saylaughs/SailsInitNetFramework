
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
            this.slideMenuExt1 = new WinformControlLibraryExtension.SlideMenuExt();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // chartExt1
            // 
            this.chartExt1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.chartExt1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(112)))), ((int)(((byte)(219)))));
            this.chartExt1.LineDotColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(112)))), ((int)(((byte)(219)))));
            this.chartExt1.Location = new System.Drawing.Point(0, 0);
            this.chartExt1.Name = "chartExt1";
            this.chartExt1.Size = new System.Drawing.Size(2946, 2575);
            this.chartExt1.TabIndex = 0;
            this.chartExt1.TabStop = false;
            // 
            // slideMenuExt1
            // 
            this.slideMenuExt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(208)))), ((int)(((byte)(188)))));
            this.slideMenuExt1.Dock = System.Windows.Forms.DockStyle.Left;
            this.slideMenuExt1.Location = new System.Drawing.Point(0, 0);
            this.slideMenuExt1.MenuHeight = 650;
            // 
            // 
            // 
            this.slideMenuExt1.MenuPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.slideMenuExt1.MenuPanel.Font = new System.Drawing.Font("宋体", 20F);
            this.slideMenuExt1.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.slideMenuExt1.MenuPanel.Menu.DisableBackColor = System.Drawing.Color.Empty;
            this.slideMenuExt1.MenuPanel.Menu.DisableTextColor = System.Drawing.Color.Empty;
            this.slideMenuExt1.MenuPanel.Menu.EnterTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.slideMenuExt1.MenuPanel.Menu.NormalTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.slideMenuExt1.MenuPanel.MenuTab.DisableBackColor = System.Drawing.Color.Empty;
            this.slideMenuExt1.MenuPanel.MenuTab.DisableTextColor = System.Drawing.Color.Empty;
            this.slideMenuExt1.MenuPanel.MenuTab.EnterTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.slideMenuExt1.MenuPanel.MenuTab.NormalTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.slideMenuExt1.MenuPanel.MenuTab.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.slideMenuExt1.MenuPanel.Name = "";
            this.slideMenuExt1.MenuPanel.Size = new System.Drawing.Size(200, 650);
            this.slideMenuExt1.MenuPanel.TabIndex = 0;
            this.slideMenuExt1.MenuPanel.TabStop = false;
            this.slideMenuExt1.MinimumSize = new System.Drawing.Size(5, 0);
            this.slideMenuExt1.Name = "slideMenuExt1";
            this.slideMenuExt1.Size = new System.Drawing.Size(200, 650);
            this.slideMenuExt1.TabIndex = 0;
            this.slideMenuExt1.TabStop = false;
            this.slideMenuExt1.PatternChanged += new WinformControlLibraryExtension.SlideMenuExt.StatusChangedEventHandler(this.slideMenuExt1_PatternChanged);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 650);
            this.panel1.TabIndex = 3;
            // 
            // InitPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.slideMenuExt1);
            this.Controls.Add(this.chartExt1);
            this.Name = "InitPro";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建项目";
            this.Load += new System.EventHandler(this.InitPro_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WinformControlLibraryExtension.ChartExt chartExt1;
        private WinformControlLibraryExtension.SlideMenuExt slideMenuExt1;
        private System.Windows.Forms.Panel panel1;
    }
}