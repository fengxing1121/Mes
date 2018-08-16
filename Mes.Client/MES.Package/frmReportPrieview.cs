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
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;

namespace Mes.Package
{
    public partial class frmReportPrieview : Form
    {
        public string LogoFile
        {
            get;
            set;
        }
        public DataSet reportData
        {
            get;
            set;
        }
        public frmReportPrieview()
        {
            InitializeComponent();
        }
        private void frmReportPrieview_Load(object sender, EventArgs e)
        {
            try
            {
                //PreviewReport();
                //this.rptView.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private void LoadReport()
        //{
        //    try
        //    {
        //        this.rptView.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
        //        this.rptView.LocalReport.DataSources.Clear();
        //        LocalReport reportEngine = new LocalReport();

        //        using (ProxyBE p = new ProxyBE())
        //        {

        //            this.rptView.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
        //            this.rptView.LocalReport.DataSources.Clear();


        //            DataSet ds = new DataSet("dsPackageLabel");
        //            DataTable tb = reportData.Tables[0].Copy();
        //            tb.Columns.Add(new DataColumn("Remarks", typeof(string)));
        //            tb.Columns.Add(new DataColumn("PackageDesc", typeof(string)));
        //            tb.Columns.Add(new DataColumn("Qty", typeof(int)));
        //            tb.Columns.Add(new DataColumn("Barcode", typeof(byte[])));
        //            tb.Columns.Add(new DataColumn("Logo", typeof(byte[])));
        //            tb.Columns.Add(new DataColumn("PrintDate", typeof(string)));


        //            //重置报表数据列
        //            foreach (DataRow row in tb.Rows)
        //            {
        //                SearchPackageDetailArgs subArgs = new SearchPackageDetailArgs();
        //                subArgs.OrderID = (Guid)row["OrderID"];
        //                subArgs.PackageID = (Guid)row["PackageID"];
        //                SearchResult subResult = p.Client.SearchPackageDetail(null, subArgs);

        //                int totalQty = 0;
        //                //string CabinetNum = "";
        //                string remarks = "";
        //                string strColor = "";
        //                int rowscount = 1;

        //                var query = from g in subResult.DataSet.Tables[0].AsEnumerable()
        //                            group g by new
        //                            {
        //                                Size = g.Field<string>("Size"),
        //                                PackageNum = g.Field<int>("PackageNum"),
        //                                PackageBarcode = g.Field<string>("PackageBarcode"),
        //                                MaterialType = g.Field<string>("MaterialType"),
        //                                ItemName = g.Field<string>("ItemName"),
        //                                MadeLength = g.Field<decimal>("MadeLength"),
        //                                MadeWidth = g.Field<decimal>("MadeWidth"),
        //                                MadeHeight = g.Field<decimal>("MadeHeight")
        //                            } into lists_Package
        //                            select new
        //                            {
        //                                ItemName = lists_Package.Key.ItemName,
        //                                MaterialType = lists_Package.Key.MaterialType,
        //                                Size = lists_Package.Key.Size,
        //                                PackageBarcode = lists_Package.Key.PackageBarcode,
        //                                PackageNum = lists_Package.Key.PackageNum,
        //                                MadeWidth = lists_Package.Key.MadeWidth,
        //                                MadeLength = lists_Package.Key.MadeLength,
        //                                MadeHeight = lists_Package.Key.MadeHeight,
        //                                Qty = lists_Package.Sum(n => n.Field<int>("Qty"))
        //                            };

        //                if (query.ToList().Count > 0)
        //                {
        //                    var lists = query.ToList();
        //                    foreach (var item in lists)
        //                    {
        //                        if (rowscount > 11)
        //                        {
        //                            break;
        //                        }
        //                        totalQty += item.Qty;


        //                        string itemName = item.ItemName;
        //                        if ("A,B,C,D,E,F".Contains(itemName.Substring(0, 1)))
        //                        {
        //                            itemName = itemName.Substring(1);
        //                        }
        //                        int index = item.ItemName.LastIndexOf("mm");
        //                        if (index >= 0)
        //                        {
        //                            itemName = itemName.Substring(index + 2, itemName.Length - (index + 2));
        //                        }

        //                        if (item.ItemName.Length > 4)
        //                        {
        //                            remarks += string.Format("{0}:{1}*{2}*{3}={4}\r\n", itemName.Substring(0, 4), item.MadeLength.ToString("#"), item.MadeWidth.ToString("#"), item.MadeHeight.ToString("#"), item.Qty);
        //                        }
        //                        else
        //                        {
        //                            remarks += string.Format("{0}:{1}*{2}*{3}={4}\r\n", itemName, item.MadeLength.ToString("#"), item.MadeWidth.ToString("#"), item.MadeHeight.ToString("#"), item.Qty);
        //                        }
        //                        strColor = item.MaterialType;
        //                        rowscount++;
        //                    };
        //                }
        //                row["Qty"] = totalQty;
        //                row["Remarks"] = remarks;
        //                row["Address"] = row["Province"].ToString() + row["City"].ToString() + row["Address"].ToString();
        //                row["Barcode"] = CommonView.getQRcode(row["PackageBarcode"].ToString());
        //                row["PackageDesc"] = string.Format("第 {0} 包", int.Parse(row["PackageNum"].ToString()).ToString("00"));
        //                row["Logo"] = CommonView.getLogoFile(this.LogoFile);
        //                row["PrintDate"] = DateTime.Now.ToString("yyyy-MM-dd");
        //            }
        //            ds.Tables.Add(tb);

        //            ReportDataSource rptDataSource = new ReportDataSource();
        //            rptDataSource.Name = "dsPackageLabel";
        //            rptDataSource.Value = ds.Tables[0];

        //            LocalReport report = new LocalReport();
        //            report.DataSources.Clear();
        //            //设置需要打印的报表的文件名称。            
        //            report.ReportEmbeddedResource = "Mes.Package.Report.rptPackageLabel.rdlc";
        //            report.DataSources.Add(rptDataSource);
        //            //刷新报表中的需要呈现的数据
        //            report.Refresh();

        //            this.rptView.LocalReport.DataSources.Add(rptDataSource);
        //            this.rptView.RefreshReport();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        /// <summary>
        /// 打印预览
        /// </summary>
        public void PreviewReport()
        {

            CrptDataSource rptds = new CrptDataSource();
            DataSet ds = rptds.GetItemLabelDataSource(this.reportData.Tables[0], this.LogoFile);
            ReportDataSource rptDataSource = new ReportDataSource();
            rptDataSource.Name = "tbPackageDataTable";
            rptDataSource.Value = ds.Tables[0];

            this.rptView.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.rptView.LocalReport.DataSources.Clear();
            this.rptView.LocalReport.ReportEmbeddedResource = "Mes.Package.Report.Report1.rdlc";
            this.rptView.LocalReport.DataSources.Add(rptDataSource);
            this.rptView.RefreshReport();
        }
        public void PreviewCommonReport(Guid CabinetID, string CategoryName)
        {
            CrptDataSource rptds = new CrptDataSource();
            DataSet ds = rptds.GetCommonLabelDataSource(CabinetID, CategoryName, this.LogoFile);
            ReportDataSource rptDataSource = new ReportDataSource();
            rptDataSource.Name = "tbPackageDataTable";
            rptDataSource.Value = ds.Tables[0];

            this.rptView.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.rptView.LocalReport.DataSources.Clear();
            this.rptView.LocalReport.ReportEmbeddedResource = "Mes.Package.Report.rptCommonLabel.rdlc";
            this.rptView.LocalReport.DataSources.Add(rptDataSource);
            this.rptView.RefreshReport();
        }
    }
}
