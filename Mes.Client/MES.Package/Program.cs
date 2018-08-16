using MES.Libraries;
using Mes.Package.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mes.Package
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (RunningInstance() != null)
            {

                MessageBox.Show("程序已经运行，请不要重复打开。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            else
            {
                if (CGlobal.Init())
                {
                    CGlobal.Login();
                }
                else
                {
                    PLogger.LogError("登录失败。");
                    Environment.Exit(1);
                }               
            }
        }

        private static Process RunningInstance()
        {

            Process current = Process.GetCurrentProcess();

            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            //遍历正在有相同名字运行的例程
            foreach (Process process in processes)
            {
                //忽略现有的例程
                if (process.Id != current.Id)
                {
                    //确保例程从EXE文件运行
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\\\") ==
                        current.MainModule.FileName)
                    {
                        //返回另一个例程实例                        
                        return process;
                    }
                }
            }
            //没有其它的例程，返回Null
            return null;
        }
    }
}
