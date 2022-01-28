using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using WinformControlLibraryExtension;

namespace SailsInitNetFramework
{
    public partial class InitPro : Form
    {
        public InitPro()
        {
            InitializeComponent();
        }

        public string initPath { get; set; }
        private async void InitPro_Load(object sender, EventArgs e)
        {
            var path = checkPath();
            var sailsVersion = await checkSails(path); 

            string str = Interaction.InputBox("请输入项目名称", "提示信息", "", -1, -1);
            var result = await sailsInit(path,str);
            MessageBoxExt.Show(this, result+"---", "提示", MessageBoxExtButtons.OK, MessageBoxExtIcon.Question);
        }

        //判断是否选择地址
        private string checkPath() {
            if (string.IsNullOrEmpty(initPath))
            {
                MessageBoxExt.Show(this, @"你好像没有选择一个初始化项目的地址", "提示", MessageBoxExtButtons.OK, MessageBoxExtIcon.Question);
                return null;
            }
            else {
                return initPath;
            }
        }

        private async Task<string> checkSails(string path)
        {
            var result = string.Empty;
            await Task.Run(() =>
            {
                var command = "sails -v";
                result = RunCommand.RunCMDCommand(command).Result;

                this.Invoke(new Action(() =>
                {
                    this.label1.Text = "您选择的项目初始地址是：" + path + ",目前你的sails版本是：" + result;
                }));
                if (string.IsNullOrEmpty(result))
                {
                    MessageBoxExt.Show(this, @"你好像没有安装sails,是否需要安装sails?", "提示", MessageBoxExtButtons.OK, MessageBoxExtIcon.Question);
                    return null;
                }
                else
                {
                    return result;
                }
            });
            return result;
        }


        private async Task<string> sailsInit(string path,string str)
        { 
            //await RunCommand.RunCMDCommand("cd "+path);
            string command = $"sails new {str} --fast ";
            var result = await RunCommand.RunCMDCommandMany(path,command);
            if (!string.IsNullOrEmpty(result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }





    }
}
