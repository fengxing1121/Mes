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
        public SearchResult SearchAllOrderWorkflow(Sender sender, SearchOrderWorkFlowArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchOrderWorkFlow(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public void ScanBarcode(Sender sender, string Barcode, Guid WorkShiftID, Guid WorkFlowID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    WorkFlow wf = new WorkFlow();
                    wf.WorkFlowID = WorkFlowID;
                    //if (op.LoadWorkFlowByWorkFlowID(wf) == 0)
                    //{
                    //    throw new PException("工序代码【{0}】无效或不存在", WorkFlowID);
                    //}

                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.BarcodeNo = Barcode;
                    if (op.LoadOrderDetailByBarcodeNo(orderDetail) == 0)
                    {
                        throw new PException("板件条码【{0}】无效", Barcode);
                    }

                    Order order = new Order();
                    order.OrderID = orderDetail.OrderID;
                    if (op.LoadOrder(order) == 0)
                    {
                        throw new PException("板件条码【{0}】无效", Barcode);
                    }

                    //if (order.ManufactureDate == DateTime.MinValue)
                    //{
                    //    order.ManufactureDate = DateTime.Now;
                    //    order.Status = "P";
                    //    op.UpdateOrderByOrderID(order); //订单开始生产日期
                    //}

                    //判断当前板件是否需要经过当前工序
                    OrderWorkFlow ow = new OrderWorkFlow();
                    ow.ItemID = orderDetail.ItemID;
                    ow.SourceWorkFlowID = WorkFlowID;
                    if (op.LoadOrderWorkFlowByItemID_SourceWorkFlowID(ow) == 0)
                    {
                        throw new PException("板件条码【{0}】不需要经过此生产工序", Barcode);
                    }
                    //判断是否已经全部扫描
                    int Qty = op.CountOrderMadeStatesByBarcode_WorkFlowID(Barcode, WorkFlowID);
                    if (Qty >= ow.TotalQty)
                    {
                        throw new PException("板件条码【{0}】在此工序中已经全部扫描,请检查是否重复扫描。", Barcode);
                    }

                    OrderMadeState orderMS = new OrderMadeState();
                    orderMS.DetailID = Guid.NewGuid();
                    orderMS.OrderID = orderDetail.OrderID;
                    orderMS.ItemID = orderDetail.ItemID;
                    orderMS.Barcode = orderDetail.BarcodeNo;
                    orderMS.CabinetID = orderDetail.CabinetID;
                    orderMS.MadeHeight = orderDetail.MadeHeight;
                    orderMS.MadeLength = orderDetail.MadeLength;
                    orderMS.MadeWidth = orderDetail.MadeHeight;
                    //orderMS.PaymentType = wf.PaymentType;
                    //orderMS.Price = wf.Price;
                    orderMS.Qty = 1;
                    orderMS.WorkFlowID = wf.WorkFlowID;
                    orderMS.WorkShiftID = WorkShiftID;
                    orderMS.Processed = DateTime.Now;
                    orderMS.ProcessedBy = sender.UserCode;
                    op.InsertOrderMadeState(orderMS);

                    OrderWorkFlow owf = new OrderWorkFlow();
                    owf.ItemID = orderDetail.ItemID;
                    owf.SourceWorkFlowID = WorkFlowID;

                    if (op.LoadOrderWorkFlowByItemID_SourceWorkFlowID(owf) != 0)
                    {
                        owf.MadeQty += 1;
                        op.UpdateOrderWorkFlowByItemID_SourceWorkFlowID(owf);
                    }

                    OrderScheduling os = new OrderScheduling();
                    os.CabinetID = orderDetail.CabinetID;
                    os.WorkFlowID = WorkFlowID;
                    if (op.LoadOrderSchedulingByCabinetID_WorkFlowID(os) != 0)
                    {
                        if (os.MadeStarted == DateTime.MinValue)
                        {
                            //生产开始时间
                            os.MadeStarted = DateTime.Now;
                        }
                        os.MadeTotalQty += 1;
                        os.MadeTotalAreal += orderDetail.MadeLength * orderDetail.MadeWidth * 0.000001M;
                        os.MadeTotalLength += (orderDetail.MadeLength + orderDetail.MadeWidth) * 2 * 0.001M;

                        if (os.MadeTotalQty == os.TotalQty)
                        {
                            //生产结束时间
                            os.MadeEnded = DateTime.Now;
                        }
                        op.UpdateOrderSchedulingByMadeID(os);
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

        public void ReworkScanBarcode(Sender sender, string Barcode, Guid WorkShiftID, Guid WorkFlowID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    WorkFlow wf = new WorkFlow();
                    wf.WorkFlowID = WorkFlowID;
                    //if (op.LoadWorkFlowByWorkFlowID(wf) == 0)
                    //{
                    //    throw new PException("工序代码【{0}】无效或不存在", WorkFlowID);
                    //}

                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.BarcodeNo = Barcode;
                    if (op.LoadOrderDetailByBarcodeNo(orderDetail) == 0)
                    {
                        throw new PException("板件条码【{0}】无效", Barcode);
                    }

                    Order order = new Order();
                    order.OrderID = orderDetail.OrderID;
                    if (op.LoadOrder(order) == 0)
                    {
                        throw new PException("板件条码【{0}】无效", Barcode);
                    }

                    //if (order.ManufactureDate == DateTime.MinValue)
                    //{
                    //    order.ManufactureDate = DateTime.Now;
                    //    op.UpdateOrderByOrderID(order); //订单开始生产日期
                    //}

                    //判断当前板件是否需要经过当前工序
                    OrderWorkFlow ow = new OrderWorkFlow();
                    ow.ItemID = orderDetail.ItemID;
                    ow.SourceWorkFlowID = WorkFlowID;
                    if (op.LoadOrderWorkFlowByItemID_SourceWorkFlowID(ow) == 0)
                    {
                        throw new PException("板件条码【{0}】不需要经过此生产工序", Barcode);
                    }
                    //判断是否已经全部扫描
                    //int Qty = op.CountOrderMadeStatesByBarcode_WorkFlowID(Barcode, WorkFlowID);
                    //if (Qty >= ow.TotalQty)
                    //{
                    //    throw new PException("板件条码【{0}】在此工序中已经全部扫描,请检查是否重复扫描。", Barcode);
                    //}

                    op.DeleteOrderMadeStateByItemID_WorkFlowID(orderDetail.ItemID, wf.WorkFlowID);

                    OrderWorkFlow owf = new OrderWorkFlow();
                    owf.ItemID = orderDetail.ItemID;
                    owf.SourceWorkFlowID = WorkFlowID;

                    if (op.LoadOrderWorkFlowByItemID_SourceWorkFlowID(owf) != 0)
                    {
                        owf.MadeQty = 0;
                        op.UpdateOrderWorkFlowByItemID_SourceWorkFlowID(owf);
                    }

                    OrderScheduling os = new OrderScheduling();
                    os.CabinetID = orderDetail.CabinetID;
                    os.WorkFlowID = WorkFlowID;
                    if (op.LoadOrderSchedulingByCabinetID_WorkFlowID(os) != 0)
                    {
                        if (os.MadeStarted == DateTime.MinValue)
                        {
                            //生产开始时间
                            os.MadeStarted = DateTime.Now;
                        }
                        os.MadeTotalQty -= 1;
                        os.MadeTotalAreal -= orderDetail.MadeLength * orderDetail.MadeWidth * 0.000001M;
                        os.MadeTotalLength -= (orderDetail.MadeLength + orderDetail.MadeWidth) * 2 * 0.001M;

                        if (os.MadeTotalQty == os.TotalQty)
                        {
                            //生产结束时间
                            os.MadeEnded = DateTime.Now;
                        }
                        op.UpdateOrderSchedulingByMadeID(os);
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

        public void UpdateOrderWorkFlowByPrintCount(Sender sender, Guid WorkingID, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    op.UpdateOrderWorkFlowByPrintCount(WorkingID, OrderID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<OrderWorkFlow> GetOrderWorkFlowByItemID(Sender sender, Guid ItemID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrderWorkFlowsByItemID(ItemID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public OrderWorkFlow GetOrderWorkFlow(Sender sender, Guid WorkingID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    OrderWorkFlow obj = new OrderWorkFlow();
                    obj.WorkingID = WorkingID;
                    if (op.LoadOrderWorkFlowByWorkingID(obj) == 0)
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
        public OrderWorkFlow GetOrderWorkFlowByItemID_WorkFlowNo(Sender sender, Guid ItemID, int WorkFlowNo)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    OrderWorkFlow obj = new OrderWorkFlow();
                    obj.ItemID = ItemID;
                    obj.WorkFlowNo = WorkFlowNo;
                    if (op.LoadOrderWorkFlowByItemID_WorkFlowNo(obj) == 0)
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
        public void SaveOrderWorkFlow(Sender sender, SaveOrderWorkFlowArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    OrderWorkFlow obj = new OrderWorkFlow();
                    obj.WorkingID = args.OrderWorkFlow.WorkingID;
                    if (op.LoadOrderWorkFlowByWorkingID(obj) == 0)
                    {
                        op.InsertOrderWorkFlow(args.OrderWorkFlow);
                    }
                    else
                    {
                        op.UpdateOrderWorkFlowByWorkingID(args.OrderWorkFlow);
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
        public SearchResult SearchOrderWorkFlow(Sender sender, SearchOrderWorkFlowArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchOrderWorkFlow(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }


        /// <summary>GetAllWorkFlows
        /// 根据订单号，产品号，外部单号查询工位信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="BarcodeNo"></param>
        /// <param name="OrderNo"></param>
        /// <param name="OutOrderNo"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public List<OrderWorkFlow> GetOrderWorkFlowsBySearchKey(Sender sender, string SearchKey)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrderWorkFlowsBySearchKey(SearchKey);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        /// <summary>
        /// 进度跟踪
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        public List<OrderWorkFlow> GetOrderWorkFlowsByProcessed(Sender sender, Guid ItemID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrderWorkFlowsByProcessed(ItemID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        /// <summary>
        /// 根据订单号获取排产流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public List<OrderWorkFlow> GetOrderWorkFlowByOrderID(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrderWorkFlowsByOrderID(OrderID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 产品是否已油漆
        /// </summary>
        /// <param name="CabinetID"></param>
        /// <returns></returns>
        public int CountOrderWorkFlows(Guid CabinetID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.CountOrderWorkFlows(CabinetID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchPrintListByOrderWorkFlow(Sender sender, SearchOrderWorkFlowArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchPrintListByOrderWorkFlow(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchScanListByOrderWorkFlow(Sender sender, SearchOrderWorkFlowArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchScanListByOrderWorkFlow(args);
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
