using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformControlLibraryExtension;

namespace SailsInitNetFramework
{
    public partial class Main : Form
    {

        private static InitPro init;
        public Main()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }



        private void 新建项目ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (init!=null) {  init.Close(); }

           var proPath =  setInitSpace("选择新建项目地址");  //选择新建项目地址 
            if (string.IsNullOrEmpty(proPath))
            {
                return;
            }
            init = new InitPro();
            init.MdiParent = this;
            init.num = 0;
            init.initPath = proPath;
            init.TopLevel = false;
            init.Parent = this.chartExt1; 
            init.Show();
            init.BringToFront();
        }


        private string setInitSpace(string Description) 
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = Description;
            DialogResult da = DialogResult.None;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                dialog.Dispose();
                da = MessageBoxExt.Show(this, @"是否选择地址：" + foldPath + "?", "提示", MessageBoxExtButtons.YesNoCancel, MessageBoxExtIcon.Question);
                if (da == DialogResult.No)
                {
                    setInitSpace("选择新建项目地址"); 
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

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (init != null) { init.Close(); }

            var proPath = setInitSpace("请选择导入的项目路径");  // 
            init = new InitPro();
            init.num = 1;
            init.initPath = proPath;
            init.TopLevel = false;
            init.Parent = this.chartExt1;
            init.Show();
            init.BringToFront();
        }

        private void installNpmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test test = new Test();
            test.TopLevel = false;
            test.Parent = this.chartExt1;
            test.Show();
            test.BringToFront(); 
        }

    }
}
