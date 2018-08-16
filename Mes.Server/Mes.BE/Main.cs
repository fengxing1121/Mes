using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.Libraries;
using System.IO;
using Mes.BE;

namespace Mes.BE
{
    public partial class Main : Form
    {
        private FormWindowState tmpFormWindowState;
        private System.Drawing.Size tmpFormSize;
        private Point tmpFormLocation;
        private bool isClose = false;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                tmpFormWindowState = this.WindowState;
                PLogger.Listeners.Clear();
                PLogger.Listeners.Add(new PTraceListener("BE", Path.Combine(Config.WorkingFolder, "Log\\BE")));
                PLogger.Listeners.Add(new PTextBoxTraceListener(this.txtLogs));
                this.notifyIcon.Visible = true;
                this.Visible = true;
                Host.Start();
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
        }
        private void menuShowWindow_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = tmpFormWindowState;
                this.Size = tmpFormSize;
                this.Location = tmpFormLocation;
                this.Visible = true;
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void menuClose_Click(object sender, EventArgs e)
        {
            isClose = true;
            Close();
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.WindowsShutDown || isClose)
                {
                    return;
                }
                e.Cancel = true;
                this.tmpFormWindowState = this.WindowState;
                this.tmpFormSize = this.Size;
                this.tmpFormLocation = this.Location;
                this.Visible = false;

            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void notifyIcon_Click(object sender, EventArgs e)
        {
            try
            {
                if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (this.Visible)
                    {
                        this.tmpFormWindowState = this.WindowState;
                        this.tmpFormSize = this.Size;
                        this.tmpFormLocation = this.Location;
                        this.Visible = false;
                    }
                    else
                    {
                        this.Visible = true;
                        this.WindowState = tmpFormWindowState;
                        this.Size = tmpFormSize;
                        this.Location = tmpFormLocation;
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
