using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using MES.Libraries;
using System.Net.Sockets;
using System.Configuration;
using Mes.Package.Report;

namespace Mes.Package.Common
{
    public class CGlobal
    {

        #region Msg
        public const int WM_USER = 0x0400; //是windows系统定义的用户消息
        public const int WM_CLOSEME = WM_USER + 10;
        public const int VK_ESCAPE = 0x1B;
        public const int WM_MYHOTKEY = WM_USER + 100;
        public const int WM_DESTROY = 0x0002;
        public const int WM_CREATE = 0x0001;

        #endregion

          
        public static frmManualPackage m_MainForm = null;
        public static frmWorkFlowCheck m_WorkFlowCheck = null;

        public CGlobal()
        {
        }

        public static bool Init()
        {
            return true;
        }

        
        

        public static bool Login()
        {
            frmLogin theWinLogin = new frmLogin();
            if (theWinLogin.ShowDialog() == DialogResult.OK)
            {
                if (!bool.Parse(ConfigurationManager.AppSettings["IsPackageScan"]))
                {
                    if (m_WorkFlowCheck == null)
                    {
                        m_WorkFlowCheck = new frmWorkFlowCheck();
                        Application.Run(CGlobal.m_WorkFlowCheck);
                    }
                    else
                    {
                        m_WorkFlowCheck.Show();
                    }
                }
                else
                {
                    if (m_MainForm == null)
                    {
                        m_MainForm = new frmManualPackage();
                        Application.Run(CGlobal.m_MainForm);

                        //test test = new test();
                        //Application.Run(test);
                    }
                    else
                    {
                        m_MainForm.Show();
                    }
                }
                return true;
            }
            return false;
        }
        public static void LogOut()
        {
            Application.Exit();
        }
        
        public static OnlineUser CurrentUser
        {
            get;
            set;
        }

        public static Sender SenderUser
        {
            get
            {
                Sender user = new Sender();
                user.UserCode = CurrentUser.UserCode;
                user.UserName = CurrentUser.UserName;
                user.MACAddress = "";
                user.IPAddress = GetLocalIP();
                user.IdentityHostName = "Server";
                return user;
            } 
        }

        public static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名  
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址  
                    //AddressFamily.InterNetwork表示此IP为IPv4,  
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型  
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch
            {               
                return "";
            }
        }  

        public delegate void NewThreadDelegate(Exception ce);
        public static void NewThread(Exception ce)
        {
            throw ce;
        }

        public static HorizontalAlignment getAlingment(int iValue)
        {
            switch (iValue)
            {
                case 0:
                    return HorizontalAlignment.Left;
                case 1:
                    return HorizontalAlignment.Center;
                case 2:
                    return HorizontalAlignment.Right;
                default:
                    return HorizontalAlignment.Left;
            }
        }
    }
}
