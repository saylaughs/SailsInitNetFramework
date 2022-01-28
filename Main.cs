using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformControlLibraryExtension;
using static WinformControlLibraryExtension.GroupPanelExt;
using static WinformControlLibraryExtension.TextCarouselExt;

namespace SailsInitNetFramework
{
    public partial class Main : Form
    {
        public Main()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void 新建项目ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           var proPath =  setInitSpace();  //选择新建项目地址

            InitPro init = new InitPro();
            init.initPath = proPath;
            init.ShowDialog();
        }


        private string setInitSpace() 
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择新建项目地址...";
            DialogResult da = DialogResult.None;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                dialog.Dispose();
                da = MessageBoxExt.Show(this, @"是否选择地址：" + foldPath + "?", "提示", MessageBoxExtButtons.YesNoCancel, MessageBoxExtIcon.Question);
                if (da == DialogResult.No)
                {
                    setInitSpace(); 
                }
                else {
                    return foldPath;
                } 
                //MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return string.Empty ;

        }

        private async void Form1_Load(object sender, EventArgs e)
        { 
            var command = "node -v";
            var nodeVersion = await GetNodeVersion(command);
            this.label1.Text = "你的Node.js版本是：" + nodeVersion;
        }


        private async Task<string> GetNodeVersion(string command) {  
            var result = await RunCommand.RunCMDCommand(command);
            if (String.IsNullOrEmpty(result)) {
                result = "你好像没有安装Node.js...";
            }
            return result;
        }
    }
}
