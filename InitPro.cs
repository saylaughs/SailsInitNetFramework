using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using WinformControlLibraryExtension;
using static System.Net.WebRequestMethods;

namespace SailsInitNetFramework
{
    public partial class InitPro : Form
    {
        public InitPro()
        {
            InitializeComponent();
        }

        public string initPath { get; set; } 
        public int num { get; set; }
        public string proName { get; set; }
        public static bool isOpen { get; set; } = false;


        public string workPath { get; set; }
        private async void InitPro_Load(object sender, EventArgs e)
        {
            this.slideMenuExt1.Visible = false;
            isOpen = true;

            this.slideMenuExt1.MenuPanel.Drag.Draging += Draw_Drawing;
            this.slideMenuExt1.MenuPanel.SelectedChanged += MenuPanel_SelectedChanged;

            var path = checkPath();
            if (string.IsNullOrEmpty(path)) {  return; }
            var sailsVersion = await checkSails(path);
            switch (num) {
                case 0:
                    workPath = path;
                    await sailsInit(path, await getInput());
                    break;
                case 1:
                    proName =  path.Substring( path.LastIndexOf("\\") + 1);
                    workPath = path;
                    path = path.Substring(0,path.LastIndexOf("\\"));
                    //SlideMenuPanelExt.Node menuItem1 = new SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = proName };
                    //menu = new SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = proName };
                    TreeNode tv = new TreeNode();   
                    load(tv.Nodes, path, proName);
                    break;
                default:
                    break;
            }
        }



         private void BuildMneu(SlideMenuPanelExt menuPanel, TreeNodeCollection fNodes, string proName) 
         {
             var menu= new SlideMenuPanelExt.Node(null)
             { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = new DirectoryInfo(proName).Name }; //此时创建二级


            var menuTwo = new SlideMenuPanelExt.Node(menu)
            { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = null }; //此时创建二级

            foreach (TreeNode node in fNodes) 
             {
                menuTwo.Text = node.Text;
                var nodes = FindNode(menuTwo, node);
                menu.Children.Add(nodes);

                menuTwo = new SlideMenuPanelExt.Node(menu)
                { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = null };
            }
             menuPanel.Nodes.Add(menu);
             menuPanel.RestMenuNodes();
             menuPanel.ExpandFirstNode();
        }

        private SlideMenuPanelExt.Node FindNode(SlideMenuPanelExt.Node menuItem, TreeNode tnParent)
        {
            SlideMenuPanelExt.Node tnRet;
            foreach (TreeNode tn in tnParent.Nodes)
            {
                var type = tn.Text.Contains(".") ? SlideMenuPanelExt.NodeTypes.MenuTab: SlideMenuPanelExt.NodeTypes.Menu;
                tnRet = new SlideMenuPanelExt.Node(menuItem){ ItemType = type, Text = tn.Text  };
                menuItem.Children.Add(tnRet); 
                FindNode(tnRet,tn);
            }
            return menuItem;
        }

        /// <summary>
        /// 获取输入的内容
        /// </summary>
        /// <returns></returns>
        public async Task<string> getInput()
        {
            string str = string.Empty;

            await Task.Run(() =>
            {
                this.Invoke(new Action(() =>
                {
                    str = Interaction.InputBox("请输入项目名称", "提示信息", "", -1, -1);
                    if (string.IsNullOrEmpty(str))
                    {
                        MessageBoxExt.Show(this, @"名称不能为空", "提示", MessageBoxExtButtons.OK, MessageBoxExtIcon.Question);
                        this.Close();
                    }
                }));

                return str;
            });
            return str;
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
                    this.Text = "您选择的项目初始地址是：" + path + ",目前你的sails版本是：" + result;
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


        private async Task sailsInit(string path,string str)
        { 
            //await RunCommand.RunCMDCommand("cd "+path);
            string command = $"sails new {str} --fast ";
            var result = await RunCommand.RunCMDCommandMany(path,command);
            if (!string.IsNullOrEmpty(result)&&!string.IsNullOrEmpty(str))
            {
                MessageBoxExt.Show(this, result, "提示", MessageBoxExtButtons.OK, MessageBoxExtIcon.Question);
                // SlideMenuPanelExt.Node menuItem1 = new SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = str };
                TreeView tv = new TreeView();
                load(tv.Nodes, path,str);
            }
        }

        private void load(TreeNodeCollection fNodes, string path,string proName) 
        {
            this.slideMenuExt1.Visible = true;  
            this.BuildDirectoryNode(fNodes, path+"/"+proName); 
            TreeNode tv = new TreeNode();
            BuildMneu(this.slideMenuExt1.MenuPanel, fNodes, proName); 
        }

        private void Draw_Drawing(object sender, SlideMenuPanelExt.DragingEventArgs e)
        {
            this.slideMenuExt1.MenuWidth += e.X;
            this.panel1.Width = this.ClientRectangle.Width - this.slideMenuExt1.Width;
            this.panel1.Location = new Point(this.slideMenuExt1.Right, this.panel1.Location.Y);
        }

        private List<FileInfo> getAllFiles(DirectoryInfo dir, List<FileInfo> files)
{
            var fil =  dir.GetFiles();
            DirectoryInfo[] di = dir.GetDirectories();
            foreach (FileInfo f in fil)
            {
                files.Add(f);
            }
            foreach (var d in di)
            {
                getAllFiles(d, files);
            }
            return files;
        }


        private void MenuPanel_SelectedChanged(object sender, SlideMenuPanelExt.SelectedChangedEventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(workPath);
            DirectoryInfo[] dii = dir.GetDirectories();
            List<FileInfo> files = new List<FileInfo>();
            foreach (var d in dii)
            {
                getAllFiles(d,files);
            }
           
            if (!string.IsNullOrEmpty(workPath))
{ 
                var file = files.Where(o=>o.FullName.Contains(e.Node.Text))?.ToList()[0].FullName;
                if (System.IO.File.Exists(file)) 
                {
                    FileHelper fileHelper = new FileHelper();
                    Console.WriteLine(e.Node.Text);
                    List<string> text = fileHelper.readFiles(file);
                    this.label1.Text = string.Join("", text.ToArray());
                }
               
            }
        }


        private void slideMenuExt1_PatternChanged(object sender, SlideMenuExt.PatternChangedEventArgs e)
        { 
            this.panel1.Width = this.ClientRectangle.Width - this.slideMenuExt1.Width;
            this.panel1.Location = new Point(this.slideMenuExt1.Right, this.panel1.Location.Y);
        }


        private SlideMenuPanelExt.Node menu = null; 
        #region
        /// <summary>
        /// 创建目录和文件树
        /// </summary>
        /// <param name="fNodes"></param>
        /// <param name="fPath"></param>
        public void BuildDirectoryNode(TreeNodeCollection fNodes, String fPath)
        {
            foreach (String directoryPath in Directory.GetDirectories(fPath))
            {
                TreeNode node = new TreeNode();
                node.Text = new DirectoryInfo(directoryPath).Name; // 获取目录名称
                node.Tag = directoryPath;
                this.BuildDirectoryNode(node.Nodes, directoryPath); // 递归创建目录节点 
                this.BuildFileNode(node.Nodes, directoryPath); // 创建文件节点 
                fNodes.Add(node); 
            } 
        }
         
        public void BuildFileNode(TreeNodeCollection fNodes, String fPath)
        {
            foreach (String filePath in Directory.GetFiles(fPath))
            {
                TreeNode node = new TreeNode();
                node.Text = Path.GetFileName(filePath);
                node.Tag = filePath;
                fNodes.Add(node);
            }
        }

        #endregion




        public void BuildDirectoryNode(SlideMenuPanelExt menuPanel,SlideMenuPanelExt.Node menuItem1, String fPath)
        {
           SlideMenuPanelExt.Node menuItem2;
            foreach (String directoryPath in Directory.GetDirectories(fPath))
            {
               menuItem2  = new SlideMenuPanelExt.Node(menuItem1) 
               { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = new DirectoryInfo(directoryPath).Name, Data = "9" }; //此时创建二级

                menuItem1.Children.Add(menuItem2);
                menu.Children.Add(menuItem1);
                this.BuildFileNode( menuItem1, directoryPath); // 创建文件节点   查找对应路径下的文件
                this.BuildDirectoryNode(menuPanel,menuItem2, directoryPath); // 递归创建目录节点  然后再次把当前目录下的文件进行递归，如果有的话，就重新刷新node
            }
            menuPanel.Nodes.Add(menu);
            menuPanel.RestMenuNodes();
        }

        

        //遍历出文件
        public void BuildFileNode(SlideMenuPanelExt.Node menuItem2, String fPath)
        {
            SlideMenuPanelExt.Node menuItem3 ;
            foreach (String filePath in Directory.GetFiles(fPath))
            {
                menuItem3 = new SlideMenuPanelExt.Node(menuItem2)
                { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = Path.GetFileName(filePath) };
                menuItem2.Children.Add(menuItem3); 
            } 
        }




}
}
