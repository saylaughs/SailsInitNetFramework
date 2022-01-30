using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SailsInitNetFramework
{
     public class RunCommand
    {
        private static string cmdPath = "C:\\Windows\\System32\\cmd.exe";

        // [Obsolete]
        public async static Task<string> RunCMDCommandMany(string path,string cmd)
        {
            string result = string.Empty;
            Process process = new Process();
            try
            {
                process.StartInfo = new ProcessStartInfo();
                process.StartInfo.WorkingDirectory = path;
                var newStr = cmd.Trim().TrimEnd('&'); //不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态

               // newStr += newStr.ToLower().Contains("cd") ? "" : "&exit";
                //设置要启动的执行程序
                process.StartInfo.FileName = cmdPath;
                process.StartInfo.CreateNoWindow = true;
                Console.WriteLine(cmd);
                //是否使用操作系统shell启动进程
                process.StartInfo.UseShellExecute = false;
                //应用程序的输入是否从Process.StandardInput流中读取/是否接受来自调用程序的输入信息
                process.StartInfo.RedirectStandardInput = true;

                //是否将应用程序的输出写入Process.StandardOutput流中/是否调用程序获取输出信息
                //置为false时StandardOutput.ReadToEnd获取异常
                process.StartInfo.RedirectStandardOutput = true;

                process.StartInfo.RedirectStandardError = true;
                //process.StartInfo.CreateNoWindow = false; 
                process.Start();

                //向cmd窗口写入命令
                await process.StandardInput.WriteLineAsync(newStr);
                
                await process.StandardInput.WriteLineAsync("1");  //选择要安装的模式
                 
                process.StandardInput.AutoFlush = true;
             //   process.WaitForExit();
                process.Close(); 

                result = "&exit初始化项目完成";
                ////获取cmd窗口的输出信息
                //result = await process.StandardOutput.ReadToEndAsync();

                //process.WaitForExit();//等待程序执行完退出进程 
                result = Regex.Split(result, "&exit", RegexOptions.IgnoreCase)[1].Trim();
            }
            catch (Exception ex)
            {
                //记录错误日志信息
                //log4net
                result = ex.Message;
            }
            finally
            {
                //释放
                process.Dispose();
            }
            return result;
        }


        public async static Task<string> RunCMDCommand(string cmd)
        {
              //cmd.exe执行文件目录
            cmd = cmd.Trim().TrimEnd('&') + "&exit";  //不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态

            string result = string.Empty;
            Process process = new Process();
            try
            {
                //设置要启动的执行程序
                process.StartInfo.FileName = cmdPath;

                //是否使用操作系统shell启动进程
                process.StartInfo.UseShellExecute = false;
                //应用程序的输入是否从Process.StandardInput流中读取/是否接受来自调用程序的输入信息
                process.StartInfo.RedirectStandardInput = true;

                //是否将应用程序的输出写入Process.StandardOutput流中/是否调用程序获取输出信息
                //置为false时StandardOutput.ReadToEnd获取异常
                process.StartInfo.RedirectStandardOutput = true;

                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                //向cmd窗口写入命令
                process.StandardInput.WriteLine(cmd);
                process.StandardInput.AutoFlush = true;

                //获取cmd窗口的输出信息
                result = await process.StandardOutput.ReadToEndAsync();
                process.WaitForExit();//等待程序执行完退出进程
                process.Close();

                Console.WriteLine(result);
                result = Regex.Split(result, "&exit", RegexOptions.IgnoreCase)[1].Trim();
            }
            catch (Exception ex)
            {
                //记录错误日志信息
                //log4net
                result = ex.Message;
            }
            finally
            {
                //释放
                process.Dispose();
            }
            return result ;
        }
    }
}
