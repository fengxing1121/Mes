using Mes.BE.Objects;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Mes.BE.Services
{
    public partial class ServiceBE : IServiceBE
    {
        public void CreatedScheduling(Sender sender, SaveCreatedSchedulingArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    #region 部件工序
                    if (args.OrderWorkFlows != null)
                    {
                        foreach (OrderWorkFlow workflow in args.OrderWorkFlows)
                        {
                            OrderWorkFlow ow = new OrderWorkFlow();
                            ow.WorkingID = workflow.WorkingID;
                            if (op.LoadOrderWorkFlowByWorkingID(ow) == 0)
                            {
                                op.InsertOrderWorkFlow(workflow);
                            }
                            else
                            {
                                op.UpdateOrderWorkFlowByWorkingID(workflow);
                            }
                        }
                    }
                    #endregion

                    #region 排产计划
                    if (args.OrderSchedulings != null)
                    {
                        foreach (OrderScheduling item in args.OrderSchedulings)
                        {
                            OrderScheduling subobj = new OrderScheduling();
                            subobj.MadeID = item.MadeID;
                            if (op.LoadOrderSchedulingByMadeID(subobj) == 0)
                            {
                                item.Created = DateTime.Now;
                                item.CreatedBy = sender.UserCode + "." + sender.UserName;
                                item.Modified = DateTime.Now;
                                item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                                op.InsertOrderScheduling(item);
                            }
                            else
                            {
                                item.Modified = DateTime.Now;
                                item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                                op.UpdateOrderSchedulingByMadeID(item);
                            }
                        }
                    }
                    //工作车间生产计划
                    if (args.WorkCenterSchedulings != null)
                    {
                        foreach (WorkCenterScheduling item in args.WorkCenterSchedulings)
                        {
                            WorkCenterScheduling wcs = new WorkCenterScheduling();
                            wcs.WorkID = item.WorkID;
                            if (op.LoadWorkCenterSchedulingByWorkID(wcs) == 0)
                            {
                                item.Created = DateTime.Now;
                                item.CreatedBy = sender.UserCode + "." + sender.UserName;
                                item.Modified = DateTime.Now;
                                item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                                op.InsertWorkCenterScheduling(item);
                            }
                            else
                            {
                                item.Modified = DateTime.Now;
                                item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                                op.UpdateWorkCenterSchedulingByWorkID(item);
                            }
                        }
                    }
                    #endregion

                    #region 包装数据
                    if (args.PackageDetails != null)
                    {
                        foreach (PackageDetail item in args.PackageDetails)
                        {
                            PackageDetail subobj = new PackageDetail();
                            subobj.DetailID = item.DetailID;
                            if (op.LoadPackageDetailByDetailID(subobj) == 0)
                            {
                                item.Created = DateTime.Now;
                                item.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                                item.Modified = DateTime.Now;
                                item.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                                op.InsertPackageDetail(item);
                            }
                            else
                            {
                                item.Modified = DateTime.Now;
                                item.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                                op.UpdatePackageDetailByDetailID(item);
                            }
                        }
                    }
                    #endregion

                    #region 修改柜体状态
                    List<Guid> OrderIDs = new List<Guid>();
                    if (args.CabinetIDs != null)
                    {
                        foreach (Guid CabinetID in args.CabinetIDs)
                        {
                            Order2Cabinet cabinet = new Order2Cabinet();
                            cabinet.CabinetID = CabinetID;
                            if (op.LoadOrder2CabinetByCabinetID(cabinet) != 0)
                            {
                                if (!OrderIDs.Contains(cabinet.OrderID))
                                {
                                    OrderIDs.Add(cabinet.OrderID);
                                }
                                Order order = new Order();
                                order.OrderID = cabinet.OrderID;
                                if (op.LoadOrder(order) != 0)
                                {
                                    //订单日志
                                    OrderLog log = new OrderLog();
                                    log.LogID = Guid.NewGuid();
                                    log.OrderID = order.OrderID;
                                    log.LogType = "订单排产";
                                    log.Remark = "完成排产";
                                    log.Created = DateTime.Now;
                                    log.CreatedBy = sender.UserCode + "." + sender.UserName;
                                    op.InsertOrderLog(log);

                                    //流程步骤
                                    //OrderTask ot = new OrderTask();
                                    //ot.Action = "排产完成，待订单优化";
                                    //ot.CurrentStep = "订单排产";
                                    //ot.ActionRemarksType = "订单系统操作";
                                    //ot.ActionRemarks = "排产完成，待订单优化";
                                    //ot.Resource = "订单排产组";
                                    //ot.NextResources = "订单优化组";
                                    //ot.NextStep = "待生产优化";

                                    cabinet.BattchCode = args.BattchCode;
                                    cabinet.CabinetStatus = "M";//待生产
                                    op.UpdateOrder2CabinetByCabinetID(cabinet);

                                    SaveOrderArgs orderargs = new SaveOrderArgs();
                                    orderargs.Order = order;
                                    //orderargs.OrderTask = ot;
                                    //orderargs.Order2Cabinets = new List<Order2Cabinet>() { cabinet };
                                    //this.SubmitTask(op, sender, orderargs);
                                }
                            }
                        }

                        foreach (Guid orderID in OrderIDs)
                        {
                            //op.UpdateMadeOrderStatus(orderID);
                        }
                    }
                    #endregion

                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<OrderScheduling> GetAllOrderSchedulings(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrderSchedulings();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public OrderScheduling GetOrderScheduling(Sender sender, Guid MadeID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    OrderScheduling obj = new OrderScheduling();
                    obj.MadeID = MadeID;
                    if (op.LoadOrderSchedulingByMadeID(obj) == 0)
                    {
                        return null;
                    }
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SaveOrderScheduling(Sender sender, SaveOrderSchedulingArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    OrderScheduling obj = new OrderScheduling();
                    obj.MadeID = args.OrderScheduling.MadeID;
                    if (op.LoadOrderSchedulingByMadeID(obj) == 0)
                    {
                        args.OrderScheduling.Created = DateTime.Now;
                        args.OrderScheduling.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.OrderScheduling.Modified = DateTime.Now;
                        args.OrderScheduling.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertOrderScheduling(args.OrderScheduling);
                    }
                    else
                    {
                        args.OrderScheduling.Modified = DateTime.Now;
                        args.OrderScheduling.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateOrderSchedulingByMadeID(args.OrderScheduling);
                    }
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<OrderScheduling> GetOrderSchedulingByOrderID(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrderSchedulingsByOrderID(OrderID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchOrderScheduling(Sender sender, SearchOrderSchedulingArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchOrderScheduling(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
    }
}
