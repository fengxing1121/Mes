using LitJson;
using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// ProductWarehouseMainHandler 的摘要说明
    /// </summary>
    public class ProductWarehouseMainHandler : BaseHttpHandler
    {
        ProductWarehouseMainParm Parm;
        #region ===================初始加载=====================
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            Parm = new ProductWarehouseMainParm(context);

            if (!string.IsNullOrEmpty(method))
            {
                foreach (MethodInfo mi in this.GetType().GetMethods())
                {
                    if (mi.Name.ToLower() == method.ToLower())
                    {
                        mi.Invoke(this, null);
                        break;
                    }
                }
            }
        }
        #endregion

        public void SearchProductWarehouseMain()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchProductWarehouseMainArgs args = new SearchProductWarehouseMainArgs();
                    args.OrderBy = "[Created] Desc";
                    if (!string.IsNullOrEmpty(Parm.BillNo))
                    {
                        args.BillNo = Parm.BillNo;
                    }
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    SearchResult sr = p.Client.SearchProductWarehouseMain(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取对应InMain数据
        /// </summary>
        public void GetInMain()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["InID"]))
                {
                    throw new Exception("入库ID参数无效。");
                }
                using (ProxyBE p = new ProxyBE())
                {

                    SearchProductWarehouseMainArgs args = new SearchProductWarehouseMainArgs();
                    args.InID = new Guid(Request["InID"]);
                    SearchResult sr = p.Client.SearchProductWarehouseMain(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 订单入库保存
        /// </summary>
        public void OrderCheckIn()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    ProductWarehouseMain pw = new ProductWarehouseMain();
                    pw.InID = Guid.NewGuid();
                    pw.BillNo = Parm.BillNo;
                    pw.OrderID = Parm.OrderID;
                    SaveProductWarehouseArgs args = new SaveProductWarehouseArgs();
                    args.ProductWarehouseMain = pw;

                    SaveLocationArgs largs = new SaveLocationArgs();
                    //遍历详细页
                    List<ProductWarehouseDetail> listdetails = new List<ProductWarehouseDetail>();
                    string InDetail = Request["InDetail"];
                    JsonData sj = JsonMapper.ToObject(InDetail);
                    if (sj.Count > 0)
                    {

                        //遍历对象元素，保存                        
                        foreach (JsonData item in sj)
                        {
                            ProductWarehouseDetail detail = new ProductWarehouseDetail();
                            detail.InID = pw.InID;
                            detail.DetailID = Guid.NewGuid();
                            detail.PackageID = Guid.Parse(item["PackageID"].ToString());
                            detail.LocationID = Guid.Parse(item["LocationID"].ToString());
                            listdetails.Add(detail);
                            args.ProductWarehouseDetails = listdetails;

                            //2.把该仓位占用、仓位放的包数、重量累计
                            Location location = p.Client.GetLocation(SenderUser, detail.LocationID);
                            location.PackageQty += 1;
                            location.Weight += Convert.ToDecimal(item["Weight"].ToString());
                            location.Flag = true;
                            largs.Location = location;
                            p.Client.SaveLocation(SenderUser, largs);
                        }
                    }

                    //1.把订单状态改为待备货 O
                    Order order = p.Client.GetOrder(SenderUser, Parm.OrderID);
                    order.Status = "O";
                    SaveOrderArgs oargs = new SaveOrderArgs();
                    oargs.Order = order;
                    p.Client.SaveOrder(SenderUser, oargs);
                    p.Client.SaveProductWarehouse(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 入库详细
        /// </summary>
        public void SearchInMainDetail()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["InID"]))
                {
                    throw new Exception("入库ID参数无效。");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    SearchProductWarehouseDetailArgs args = new SearchProductWarehouseDetailArgs();
                    args.OrderBy = "[BillNo]";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    args.InID = new Guid(Request["InID"]);
                    SearchResult sr = p.Client.SearchProductWarehouseDetail(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }
    }
}