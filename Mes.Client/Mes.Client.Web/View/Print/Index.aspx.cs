using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mes.Client.Utility;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility.Common;
using Mes.Client.Utility.Enum;

namespace Mes.Client.Web.View.Print
{
    public partial class Index : System.Web.UI.Page
    {
       

        public string PrintHtml = string.Empty;
        public bool IsPrint = false, IsView = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string template = Request["template"];
                if (!string.IsNullOrEmpty(template))
                {
                    PrintHtml = GetPrintHtml(template);
                    if (!string.IsNullOrEmpty(PrintHtml))
                    {
                        IsPrint = true;
                    }

                    string isview = Request["isview"];
                    if (!string.IsNullOrEmpty(isview))
                    {
                        IsView = Convert.ToBoolean(isview);
                    }
                }
                else
                {
                    Response.Write("参数错误！");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                PLogger.LogError(ex);
            }
        }

        /// <summary>
        /// 统一处理传递的参数请求
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        private string GetPrintHtml(string template)
        {
            string PrintHtml = string.Empty;
            template templateEn = (template)Enum.Parse(typeof(template), template);

            //包装和产品条码
            if (templateEn == Utility.Enum.template.package || templateEn == Utility.Enum.template.cabinet)
            {
                string Barcode = Request["Barcode"];
                string WorkingID = Request["WorkingID"];

                string[] ArrayBarcode = Barcode.TrimEnd(',').Split(',');
                string[] ArrayWorkingID = WorkingID.TrimEnd(',').Split(',');

                for (int i = 0; i < ArrayBarcode.Length; i++)
                {
                    PrintHtml += "<div class=\"qrcodetable\">";//解决连续打印
                    using (ProxyBE p = new ProxyBE())
                    {
                        OrderWorkFlow model = p.Client.GetOrderWorkFlow(null, new Guid(ArrayWorkingID[i]));
                        if (model.WorkFlowNo == 1)
                        {
                            PrintHtml += PrintCabinetData(ArrayBarcode[i], ArrayWorkingID[i], Utility.Enum.template.cabinet);
                        }
                        else
                        {
                            PrintHtml += PrintPackageData(ArrayBarcode[i], ArrayWorkingID[i], templateEn);
                        }
                    }
                    PrintHtml += "</div>";
                }
            }
            //订单条码
            else if (templateEn == Utility.Enum.template.order)
            {
                string OrderNo = Request["OrderNo"];
                int printnumber = !string.IsNullOrEmpty(Request["printnumber"]) ? int.Parse(Request["printnumber"]) : 1;//打印份数

                string[] ArrayBarcode = OrderNo.TrimEnd(',').Split(',');

                for (int j = 0; j < printnumber; j++)
                {
                    for (int i = 0; i < ArrayBarcode.Length; i++)
                    {
                        PrintHtml += "<div class=\"qrcodetable\">";
                        PrintHtml += PrintOrderData(ArrayBarcode[i], templateEn);
                        PrintHtml += "</div>";
                    }
                }

            }

            return PrintHtml;
        }

        /// <summary>
        /// 打印产品
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        private string PrintCabinetData(string Barcode, string WorkingID, template template)
        {

            string templatepath = Request.MapPath(string.Format(@"\portal\Print\template\{0}.html", template.ToString()));
            string templatehtml = ReadFileHelp.GetTemplet(Convert.ToInt32(template), templatepath);

            using (ProxyBE p = new ProxyBE())
            {
                SearchResult sr = p.Client.SearchPrintCabinetData(null, Barcode);
                if (sr.Total > 0)
                {
                    foreach (DataRow row in sr.DataSet.Tables[0].Rows)
                    {
                        string BarcodeNo = GetDataRow(row, "BarcodeNo");
                        string ItemGroup = GetDataRow(row, "ItemGroup");
                        string ItemName = GetDataRow(row, "ItemName");
                        string MaterialType = GetDataRow(row, "MaterialType");
                        string OrderNo = GetDataRow(row, "OrderNo");
                        string CustomerName = GetDataRow(row, "CustomerName");
                        string PartnerName = GetDataRow(row, "PartnerName");
                        string OrderID = GetDataRow(row, "OrderID");

                        templatehtml = templatehtml
                            .Replace("{BarcodeNo}", BarcodeNo)
                            .Replace("{ItemGroup}", ItemGroup)
                            .Replace("{ItemName}", ItemName)
                            .Replace("{MaterialType}", MaterialType)
                            .Replace("{OrderNo}", OrderNo)
                            .Replace("{BarcodeNo}", BarcodeNo)
                            .Replace("{CustomerName}", GetPartnerName(PartnerName, CustomerName));

                        //更新打印记录
                        //if(!string.IsNullOrEmpty(Request["isconfig"]))
                        p.Client.UpdateOrderWorkFlowByPrintCount(null, new Guid(WorkingID), new Guid(OrderID));
                    }
                }
            }

            return templatehtml;
        }

        /// <summary>
        /// 打印包装数据
        /// </summary>
        /// <param name="Barcode"></param>
        /// <param name="WorkingID"></param>
        /// <returns></returns>
        private string PrintPackageData(string Barcode, string WorkingID, template template)
        {

            string templatepath = Request.MapPath(string.Format(@"\portal\Print\template\{0}.html", template.ToString()));
            string templatehtml = ReadFileHelp.GetTemplet(Convert.ToInt32(template), templatepath);

            using (ProxyBE p = new ProxyBE())
            {
                SearchResult sr = p.Client.SearchPrintCabinetData(null, Barcode);
                if (sr.Total > 0)
                {
                    foreach (DataRow row in sr.DataSet.Tables[0].Rows)
                    {
                        string OrderNo = GetDataRow(row, "OrderNo");
                        string CabinetName = GetDataRow(row, "CabinetName");
                        string MaterialStyle = GetDataRow(row, "MaterialStyle");
                        string Color = GetDataRow(row, "Color");
                        string Size = GetDataRow(row, "Size");
                        string CustomerName = GetDataRow(row, "CustomerName");
                        string PartnerName = GetDataRow(row, "PartnerName");
                        string BarcodeNo = GetDataRow(row, "BarcodeNo");
                        string OrderID = GetDataRow(row, "OrderID");
                        string CabinetCode = GetDataRow(row, "CabinetCode");
                        string GroupNumber = GetDataRow(row, "GroupNumber");

                        templatehtml = templatehtml
                            .Replace("{OrderNo}", OrderNo)
                            .Replace("{CabinetName}", CabinetName)
                            .Replace("{MaterialStyle}", MaterialStyle)
                            .Replace("{Color}", Color)
                            .Replace("{Size}", Size)
                            .Replace("{GroupNumber}", GroupNumber)
                            .Replace("{CabinetCode}", CabinetCode)
                            .Replace("{BarcodeNo}", BarcodeNo)
                            .Replace("{CustomerName}", GetPartnerName(PartnerName, CustomerName));

                        //更新打印记录
                        //if (!string.IsNullOrEmpty(Request["isconfig"]))
                        p.Client.UpdateOrderWorkFlowByPrintCount(null, new Guid(WorkingID), new Guid(OrderID));
                    }
                }
            }

            return templatehtml;
        }

        /// <summary>
        /// 打印订单数据
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        private string PrintOrderData(string OrderNo, template template)
        {

            string templatepath = Request.MapPath(string.Format(@"\portal\Print\template\{0}.html", template.ToString()));
            string templatehtml = ReadFileHelp.GetTemplet(Convert.ToInt32(template), templatepath);

            using (ProxyBE p = new ProxyBE())
            {
                SearchResult sr = p.Client.SearchPrintOrderData(null, OrderNo);
                if (sr.Total > 0)
                {
                    foreach (DataRow row in sr.DataSet.Tables[0].Rows)
                    {
                        string OutOrderNo = GetDataRow(row, "OutOrderNo");
                        string OrderType = GetDataRow(row, "OrderType");
                        string CabinetType = GetDataRow(row, "CabinetType");
                        string BookingDate = GetDataRow(row, "BookingDate");
                        string ShipDate = GetDataRow(row, "ShipDate");
                        string CustomerName = GetDataRow(row, "CustomerName");
                        string PartnerName = GetDataRow(row, "PartnerName");

                        templatehtml = templatehtml
                            .Replace("{OutOrderNo}", OutOrderNo)
                            .Replace("{OrderType}", OrderType)
                            .Replace("{CabinetType}", CabinetType)
                            .Replace("{BookingDate}", !string.IsNullOrEmpty(BookingDate) ? DateTime.Parse(BookingDate).ToString("yyyy-MM-dd") : string.Empty)
                            .Replace("{ShipDate}", !string.IsNullOrEmpty(ShipDate) ? DateTime.Parse(ShipDate).ToString("yyyy-MM-dd") : string.Empty)
                            .Replace("{BarcodeNo}", OutOrderNo)
                            .Replace("{CustomerName}", GetPartnerName(PartnerName, CustomerName));
                    }
                }
            }

            return templatehtml;
        }

        /// <summary>
        /// dataset
        /// </summary>
        /// <param name="row"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        private string GetDataRow(DataRow row, string field)
        {
            return (row[field] == null ? string.Empty : row[field].ToString());
        }

        /// <summary>
        /// 客户名称
        /// </summary>
        /// <param name="PartnerName"></param>
        /// <param name="CustomerName"></param>
        /// <returns></returns>
        private string GetPartnerName(string PartnerName, string CustomerName)
        {
            if (!string.IsNullOrEmpty(PartnerName) && !string.IsNullOrEmpty(CustomerName)) return PartnerName + "(" + CustomerName + ")";
            if (!string.IsNullOrEmpty(PartnerName)) return PartnerName;
            if (!string.IsNullOrEmpty(CustomerName)) return CustomerName;

            return string.Empty;
        }
    }
}