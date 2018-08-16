using LitJson;
using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// TransportMainHandler 的摘要说明
    /// </summary>
    public class TransportMainHandler : BaseHttpHandler
    {
        TransportMainParm Parm;
        #region ===================初始加载=====================
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            Parm = new TransportMainParm(context);

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

        public void SearchWarehouseOutMain()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchTransportMainArgs args = new SearchTransportMainArgs();
                    args.OrderBy = "[Created] Desc";
                    if (!string.IsNullOrEmpty(Parm.TransportNo))
                    {
                        args.TransportNo = Parm.TransportNo;
                    }
                    if (!string.IsNullOrEmpty(Request["PlateNo"]))
                    {
                        args.PlateNo = Request["PlateNo"];
                    }
                    if (!string.IsNullOrEmpty(Request["DriverName"]))
                    {
                        args.DriverName = Request["DriverName"];
                    }
                    if (!string.IsNullOrEmpty(Request["EnterpriseName"]))
                    {
                        args.EnterpriseName = Request["EnterpriseName"];
                    }
                    if (!string.IsNullOrEmpty(Parm.Source))
                    {
                        args.DriverName = Parm.Source;
                    }
                    if (!string.IsNullOrEmpty(Parm.Target))
                    {
                        args.DriverName = Parm.Target;
                    }
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    SearchResult sr = p.Client.SearchTransportMain(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 订单出库产品保存
        /// </summary>
        public void SaveTransportMainOut()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    TransportMain tm = new TransportMain();
                    tm.TransportID = Parm.TransportID;
                    tm.TransportNo = Parm.TransportNo;
                    tm.CarID = Parm.CarID;
                    tm.Source = Parm.Source;
                    tm.Target = Parm.Target;
                    tm.Price = Parm.Price;
                    SaveTransportArgs args = new SaveTransportArgs();
                    args.TransportMain = tm;

                    //遍历详细页
                    List<TransportDetail> listdetails = new List<TransportDetail>();
                    string OutDetail = Request["OutDetail"];
                    JsonData sj = JsonMapper.ToObject(OutDetail);
                    if (sj.Count > 0)
                    {
                        //遍历对象元素，保存                        
                        foreach (JsonData item in sj)
                        {
                            TransportDetail detail = new TransportDetail();
                            detail.TransportID = Parm.TransportID;
                            detail.OrderID = Guid.Parse(item["OrderID"].ToString());
                            listdetails.Add(detail);

                            #region 1.改变订单状态
                            Order order = p.Client.GetOrder(SenderUser, Guid.Parse(item["OrderID"].ToString()));
                            order.Status = "F"; //已完成
                            SaveOrderArgs sargs = new SaveOrderArgs();
                            sargs.Order = order;
                            p.Client.SaveOrder(SenderUser, sargs);
                            #endregion

                            #region 2.把存放对应的订单的仓位 设置为不占用、包数设为0、重量设为0
                            SearchProductWarehouseDetailArgs pargs = new SearchProductWarehouseDetailArgs();
                            pargs.RowNumberFrom = pagingParm.RowNumberFrom;
                            pargs.RowNumberTo = pagingParm.RowNumberTo;
                            pargs.OrderID = Guid.Parse(item["OrderID"].ToString());
                            SearchResult sr = p.Client.SearchProductWarehouseDetail(SenderUser, pargs);
                            if (sr.Total > 0)
                            {
                                for (int i = 0; i < sr.DataSet.Tables[0].Rows.Count; i++)
                                {
                                    DataRow dr = sr.DataSet.Tables[0].Rows[i];
                                    Location location = p.Client.GetLocation(SenderUser, new Guid(dr["LocationID"].ToString()));
                                    location.Flag = false;
                                    location.PackageQty = 0;
                                    location.Weight = 0;

                                    SaveLocationArgs lags = new SaveLocationArgs();
                                    lags.Location = location;
                                    p.Client.SaveLocation(SenderUser, lags);
                                }
                            }
                            #endregion
                        }
                    }
                    args.TransportDetails = listdetails;
                    p.Client.SaveTransport(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }

        }

        /// <summary>
        /// 获取对应OutMain数据
        /// </summary>
        public void GetOutMain()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["TransportID"]))
                {
                    throw new Exception("出库ID参数无效。");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    SearchTransportMainArgs args = new SearchTransportMainArgs();
                    args.TransportID = new Guid(Request["TransportID"]);
                    SearchResult sr = p.Client.SearchTransportMain(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 出库详细
        /// </summary>
        public void SearchOutMainDetail()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["TransportID"]))
                {
                    throw new Exception("出库ID参数无效。");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    SearchTransportDetailArgs args = new SearchTransportDetailArgs();
                    args.OrderBy = "[TransportNo]";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    args.TransportID = new Guid(Request["TransportID"]);
                    SearchResult sr = p.Client.SearchTransportDetail(SenderUser, args);
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