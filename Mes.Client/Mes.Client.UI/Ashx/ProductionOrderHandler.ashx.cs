using LitJson;
using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Enum;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Mes.Client.UI.Ashx
{
    public class ProductionOrderHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        ProductionOrderParm parm = null;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new ProductionOrderParm(context);
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

        #region 查询生产订单
        public void SearchProductionOrder()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchProductionOrderArgs args = new SearchProductionOrderArgs();

                    args.OrderBy = "Created desc";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;

                    if (!string.IsNullOrEmpty(parm.ProductionID.ToString()))
                    {
                        args.ProductionID = parm.ProductionID;
                    }
                    if (!string.IsNullOrEmpty(parm.ProduceNo.ToString()))
                    {
                        args.ProduceNo = parm.ProduceNo;
                    }
                    if (!string.IsNullOrEmpty(parm.OrderID.ToString()))
                    {
                        args.OrderID = parm.OrderID;
                    }
                    if (!string.IsNullOrEmpty(parm.OrderNo.ToString()))
                    {
                        args.OrderNo = parm.OrderNo;
                    }
                    if (!string.IsNullOrEmpty(parm.FinishDate.ToString()))
                    {
                        args.FinishDate = parm.FinishDate;
                    }
                    if (!string.IsNullOrEmpty(parm.Created.ToString()))
                    {
                        args.Created = parm.Created;
                    }
                    if (!string.IsNullOrEmpty(parm.CreatedBy.ToString()))
                    {
                        args.CreatedBy = parm.CreatedBy;
                    }
                    
                    if (!string.IsNullOrEmpty(parm.Status) && Request["Status"] != "全部")
                    {
                        args.Status = parm.Status.Split(',').ToList();
                    }
                    if (!string.IsNullOrEmpty(parm.OrderType) && Request["OrderType"] != "全部")
                    {
                        args.OrderTypes = parm.OrderType.Split(',').ToList();
                    }
                    if (!string.IsNullOrEmpty(parm.OrderNo))
                    {
                        args.OrderNo = parm.OrderNo;
                    }
                    if (!string.IsNullOrEmpty(parm.PurchaseNo))
                    {
                        args.PurchaseNo = parm.PurchaseNo;
                    }

                    if (!string.IsNullOrEmpty(parm.BattchNum))
                    {
                        args.BattchNo = parm.BattchNum;
                    }

                    if (!string.IsNullOrEmpty(parm.OutOrderNo))
                    {
                        args.OutOrderNo = parm.OutOrderNo;
                    }
                    if (!string.IsNullOrEmpty(parm.Mobile))
                    {
                        args.Mobile = parm.Mobile;
                    }
                    if (!string.IsNullOrEmpty(parm.BattchNum))
                    {
                        args.BattchNo = parm.BattchNum;
                    }
                    if (!string.IsNullOrEmpty(parm.Address))
                    {
                        args.Address = parm.Address;
                    }
                    if (!string.IsNullOrEmpty(parm.CustomerName))
                    {
                        args.CustomerName = parm.CustomerName;
                    }
                    if (!string.IsNullOrEmpty(Request["BookingDateFrom"]))
                    {
                        args.BookingDateFrom = parm.BookingDateFrom;
                    }
                    if (!string.IsNullOrEmpty(Request["BookingDateTo"]))
                    {
                        args.BookingDateTo = parm.BookingDateTo.AddDays(1);
                    }
                    if (!string.IsNullOrEmpty(Request["ShipDateFrom"]))
                    {
                        args.ShipDateFrom = parm.ShipDateFrom;
                    }
                    if (!string.IsNullOrEmpty(Request["ShipDateTo"]))
                    {
                        args.ShipDateTo = parm.ShipDateTo.AddDays(1);
                    }
                    if (!string.IsNullOrEmpty(Request["ProductionStatus"]))
                    {
                        args.ProductionStatus = Request["ProductionStatus"];
                    }
                    args.ComponentTypeID = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ComponentTypeID"]);
                    SearchResult sr = p.Client.SearchProductionOrder(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }

        public void SearchProductComponents()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["OrderID"]))
                {
                    Response.Write("{\"total\":0,\"rows\":[]}");
                }
                else
                {
                    using (ProxyBE p = new ProxyBE())
                    {
                        SearchResult sr = p.Client.SearchProductComponents(SenderUser, new Guid(Request["OrderID"]));
                        Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }

        public void SearchOrders()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchOrderArgs args = new SearchOrderArgs();

                    args.OrderBy = "Created desc";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;

                    SearchResult sr = p.Client.SearchOrderByProductionOrder(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }
        #endregion

        #region 操作生产订单
        public void SaveProductionOrder()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SaveProductionOrderArgs args = new SaveProductionOrderArgs();
                    ProductionOrder obj = new ProductionOrder();
                    if (!string.IsNullOrEmpty(Request["edit"]))
                    {
                        obj = p.Client.GetProductionOrder(SenderUser, parm.ProductionID);
                    }
                    if (obj == null)
                    {
                        throw new Exception("数据不存在");
                    }

                    obj.ProductionID = Guid.NewGuid();
                    obj.ProduceNo = parm.ProduceNo;
                    obj.OrderID = parm.OrderID;
                    obj.OrderNo = parm.OrderNo;
                    obj.FinishDate = parm.FinishDate;
                    obj.Created = parm.Created;
                    obj.Status = ProductionOrderStatus.N.ToString();
                    obj.CreatedBy = parm.CreatedBy;
                    args.ProductionOrder = obj;

                    //List<ProductionOrderComponent> list = new List<ProductionOrderComponent>();
                    //string Cabinets = Request["Cabinets"];
                    //JsonData sj = JsonMapper.ToObject(Cabinets);
                    //if (sj.Count > 0)
                    //{
                    //    foreach (JsonData item in sj)
                    //    {
                    //        ProductionOrderComponent model = new ProductionOrderComponent()
                    //        {
                    //             ProductionID = obj.ProductionID,
                    //             ComponentID = int.Parse(item["ComponentID"].ToString()),
                    //        };
                    //        list.Add(model);
                    //    }
                    //}
                    //args.ProductionOrderComponents = list;

                    p.Client.SaveProductionOrder(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SchedulingProductionOrder()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SchedulingProductionOrderArgs args = new SchedulingProductionOrderArgs();

                    if (string.IsNullOrEmpty(Request["ProductionIDs"]))
                    {
                        throw new Exception("参数错误！");
                    }
                    string[] array = Request["ProductionIDs"].TrimEnd(',').Split(',');
                    for(int i=0;i< array.Length; i++)
                    {
                        Guid ProductionID = new Guid(array[i]);
                        ProductionOrder productionorder = p.Client.GetProductionOrder(SenderUser, ProductionID);
                        if (productionorder == null)
                        {
                            throw new Exception(string.Format("订单{0}不存在！", productionorder.OrderNo));
                        }
                        if (productionorder.Status.Trim()!="N")
                        {
                            throw new Exception(string.Format("订单{0}已排单！", productionorder.OrderNo));
                        }

                        List<ProductComponent> componentlist = p.Client.GetProductComponentByOrderID(SenderUser, productionorder.OrderID);
                        if (componentlist.Count<1)
                        {
                            throw new Exception(string.Format("订单{0}未查询到组件！", productionorder.OrderNo));
                        }
                        int ComponentTypeID = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ComponentTypeID"]);
                        var SumAmount = componentlist.Where(t=>t.ComponentTypeID== ComponentTypeID).ToList().Sum(t => t.Amount);
                        if (SumAmount < 1)
                        {
                            throw new Exception("订单面积有误！");
                        }
                        ProductionSetDayDetail detail=p.Client.GetProductionSetDayDetailByMadeTotalAreal(SenderUser, SumAmount);
                        if (detail==null)
                        {
                            throw new Exception("请先进行排单参数设置！");
                        }
                        //排产记录
                        ProductionOrderScheduling scheduling = new ProductionOrderScheduling()
                        {
                            SchedulingID = Guid.NewGuid(),
                            OrderID = productionorder.OrderID,
                            ProductionID = ProductionID,
                            DaysDetailID = detail.ID,
                            TotalAreal = SumAmount,
                        };
                        args.ProductionOrderScheduling = scheduling;

                        //更新已排单量和未排单量
                        detail.MadeTotalAreal = detail.MadeTotalAreal+ SumAmount;
                        args.ProductionSetDayDetail = detail;

                        //更新生产订单状态，预计完工时间
                        productionorder.Status = ProductionOrderStatus.Y.ToString();
                        productionorder.FinishDate = detail.Datetime;
                        args.ProductionOrder = productionorder;

                        //订单日志
                        OrderStepLog ot = new OrderStepLog();
                        ot.StepID = Guid.NewGuid();
                        ot.OrderID = scheduling.OrderID;
                        ot.StepNo = 0;
                        ot.StepName = "订单已排单";
                        ot.Remark =string.Format("预计完工日期：{0}", detail.Datetime.ToString("D"));
                        args.OrderStepLog = ot;

                        p.Client.SchedulingProductionOrder(SenderUser, args);
                    } 
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
        #endregion
    }
}

