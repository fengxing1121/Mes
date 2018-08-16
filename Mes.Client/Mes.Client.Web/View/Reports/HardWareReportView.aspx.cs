using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using MES.Libraries;

namespace Mes.Client.Web.View.Reports
{
    public partial class HardWareReportView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    InitializeForm();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void InitializeData()
        {
            string ReportPath = this.Request.QueryString["ReportPath"];
        }

        private void InitializeForm()
        {
            string ReportPath = this.Request.QueryString["ReportPath"];
            string orderNo = Request["H_OrderNo"];
            string resportServer = Config.ReportServer;
            List<ReportParameter> paralist = new List<ReportParameter>();
            paralist.Add(new ReportParameter("系统编号", orderNo, false));
            this.rptView.ServerReport.ReportServerUrl = new Uri(resportServer);
            this.rptView.ServerReport.ReportPath = ReportPath;
            this.rptView.ServerReport.SetParameters(paralist);
        }
    }
}