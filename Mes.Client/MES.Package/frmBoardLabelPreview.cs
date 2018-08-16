using MES.Libraries;
using Mes.Package.Common;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mes.Package
{
    public partial class frmBoardLabelPreview : Form
    {
        public frmBoardLabelPreview()
        {
            InitializeComponent();
        }

        private void frmBoardLabelPreview_Load(object sender, EventArgs e)
        {

            this.rptView.RefreshReport();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {

                    SearchOrderDetailArgs args = new SearchOrderDetailArgs();
                    args.OrderBy = "[OrderID]";
                    args.Barcode = this.txtBarcode.Text;
                    //args.OrderStatus = "P";
                    SearchResult sr = p.Client.SearchOrderDetail(CGlobal.SenderUser, args);

                    if (sr.DataSet.Tables[0].Rows.Count > 0)
                    {
                        sr.DataSet.Tables[0].Columns.Add(new DataColumn("BarcodeImg", typeof(byte[])));
                        sr.DataSet.Tables[0].Columns.Add(new DataColumn("TotalBattchQty", typeof(Int32)));
                        sr.DataSet.Tables[0].Columns.Add(new DataColumn("TotalOrderQty", typeof(Int32)));
                        sr.DataSet.Tables[0].Rows[0]["BarcodeImg"] = CommonView.getQRcode(sr.DataSet.Tables[0].Rows[0]["BarcodeNo"].ToString());
                        sr.DataSet.Tables[0].Rows[0]["TotalOrderQty"] = 10;
                        sr.DataSet.Tables[0].Rows[0]["TotalBattchQty"] = 10;
                    }
                    else
                    {
                        throw new Exception("条码不存在。");
                    }
                    
                    this.rptView.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                    this.rptView.LocalReport.DataSources.Clear();                 
                    sr.DataSet.DataSetName = "DataSet1";
                    ReportDataSource rptDataSource = new ReportDataSource();
                    rptDataSource.Name = "DataSet1";
                    rptDataSource.Value = sr.DataSet.Tables[0];

                    //YK170300007
                    LocalReport report = new LocalReport();
                    report.DataSources.Clear();
                    //设置需要打印的报表的文件名称。            
                    report.ReportEmbeddedResource = "Mes.Package.Report.rptBoardLabel.rdlc";
                    report.DataSources.Add(rptDataSource);
                    //刷新报表中的需要呈现的数据
                    report.Refresh();

                    this.rptView.LocalReport.DataSources.Add(rptDataSource);
                    this.rptView.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
