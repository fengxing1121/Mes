using Mes.Client.Utility.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mes.Client.Web.View.CRM
{
    public partial class PartnetUserManager : PageBase
    {
        public string strEndDate = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            strEndDate = DateTime.Now.AddMonths(12).ToString("yyyy-MM-dd");
        }
    }
}