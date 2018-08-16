using MES.Libraries;
using Mes.Package.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mes.Package
{
    public class BaseForm : Form
    {
        //public Sender CurrentUser
        //{
        //    get { 
        //        Sender user = new Sender();
        //        user.UserCode ="CPT";
        //        user.UserName="System";
        //        user.MACAddress="127.0.0.0";
        //        user.IPAddress = "127.0.0.0";
        //        user.IdentityHostName="Server";
        //        user.CompanyID= new Guid("35EB4E48-A99D-4FCE-938A-DD390FE4E3ED");               
        //        return user;
        //    } 
        //}

        public Sender CurrentUser
        {
            get;
            set;
        }
    }
}
