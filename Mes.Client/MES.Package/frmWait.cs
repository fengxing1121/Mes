using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mes.Package
{
    public partial class frmWait : Form
    {
        public frmWait()
        {
            InitializeComponent();
        }

        public void Notify(string message)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    SetMessage e = new SetMessage(Notify);
                    this.Invoke(e, message);
                }
                lblmsg.Text = message;
            }
            catch
            {
            }
        }

        delegate void SetMessage(string msg);
    }
}
