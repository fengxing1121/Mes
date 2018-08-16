using Mes.Client.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mes.Client.UI.View.BOM
{
    public partial class download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DownLoadHelper.DownLoadLocalFile("/Content/template/BOM模版.xls");
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.Message);
            }
        }
    }
}