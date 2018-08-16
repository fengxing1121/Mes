using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Reflection;
using System.Runtime.InteropServices;
using Mes.BE;

namespace Mes.BE
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Process p = RunningInstance();
                if (p != null)
                {
                    if (Config.RunMode.ToLower() == "windowsapplication")
                    {
                        //MessageBox.Show("程序已经运行，请不要重复打开。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        HandleRunningInstance(p);
                        Environment.Exit(1);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("程序已在后台运行，请停止后台程序再运行。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(1);
                        return;
                    }
                }

                switch (Config.RunMode.ToLower())
                {
                    case "windowsservice":
                        ServiceBase[] ServicesToRun = new ServiceBase[] { new BE_Service() };
                        ServiceBase.Run(ServicesToRun);
                        break;

                    case "windowsapplication":
                    default:
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Main());
                        break;
                }
            }
            catch
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
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
        ///<summary>
        /// 该函数设置由不同线程产生的窗口的显示状态
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="cmdShow">指定窗口如何显示。查看允许值列表，请查阅ShowWlndow函数的说明部分</param>
        /// <returns>如果函数原来可见，返回值为非零；如果函数原来被隐藏，返回值为零</returns>
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        /// <summary>
        ///  该函数将创建指定窗口的线程设置到前台，并且激活该窗口。键盘输入转向该窗口，并为用户改各种可视的记号。
        ///  系统给创建前台窗口的线程分配的权限稍高于其他线程。 
        /// </summary>
        /// <param name="hWnd">将被激活并被调入前台的窗口句柄</param>
        /// <returns>如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零</returns>
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);



        private const int SW_SHOWNOMAL = 1;
        private static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, SW_SHOWNOMAL);//显示
            SetForegroundWindow(instance.MainWindowHandle);//当到最前端
        }
    }
}
