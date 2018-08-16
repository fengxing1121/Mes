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

        public Order GetOrder(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Order obj = new Order();
                    obj.OrderID = OrderID;
                    if (op.LoadOrder(obj) == 0)
                        return null;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public void SaveOrder(Sender sender, SaveOrderArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Order obj = new Order();
                    obj.OrderID = args.Order.OrderID;

                    List<Category> Categorys = op.LoadCategorysByParentID(ORDERTYPECATEGORORYID);


                    if (op.LoadOrder(obj) == 0)
                    {
                        string ordertypeCode = Categorys.Where(t => t.CategoryName == args.Order.OrderType).FirstOrDefault().CategoryCode;
                        string key = ordertypeCode + DateTime.Now.ToString("yy");

                        int index = this.GetIncrease(sender, key);
                        args.Order.OrderNo = key + DateTime.Now.Month.ToString("00") + index.ToString("00000");

                        args.Order.Created = DateTime.Now;
                        args.Order.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.Order.Modified = DateTime.Now;
                        args.Order.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertOrder(args.Order);
                    }
                    else
                    {
                        args.Order.Modified = DateTime.Now;
                        args.Order.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateOrderByOrderID(args.Order);
                    }



                    #region 订单产品
                    if (args.OrderProducts != null)
                    {
                        for (int i = 0; i < args.OrderProducts.Count; i++)
                        {
                            var model = args.OrderProducts[i];
                            OrderProduct subObj = new OrderProduct();
                            subObj.ProductID = model.ProductID;
                            if (op.LoadOrderProduct(subObj) == 0)
                            {
                                if (string.IsNullOrEmpty(model.ProductCode) || model.ProductCode.Length <= 1)
                                {
                                    //subObj.CabinetCode = args.Order.OrderNo + (char)(64 + order2Cabinet.Sequence);
                                    model.ProductCode = string.Format("{0}-{1}-{2}", args.Order.OrderNo, args.OrderProducts.Count, i + 1);
                                }
                                model.Created = DateTime.Now;
                                model.CreatedBy = sender.UserCode + "." + sender.UserName;
                                model.Modified = DateTime.Now;
                                model.ModifiedBy = sender.UserCode + "." + sender.UserName;
                                op.InsertOrderProduct(model);
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(model.ProductCode) || model.ProductCode.Length <= 1)
                                {
                                    //order2Cabinet.CabinetCode = args.Order.OrderNo + (char)(64 + order2Cabinet.Sequence);
                                    model.ProductCode = string.Format("{0}-{1}-{2}", args.Order.OrderNo, args.OrderProducts.Count, i + 1);
                                }
                                model.Modified = DateTime.Now;
                                model.ModifiedBy = sender.UserCode + "." + sender.UserName;
                                op.UpdateOrderProductByProductID(model);
                            }
                        }
                    }
                    #endregion

                    #region 订单步骤
                    if (args.OrderStepLog != null)
                    {
                        args.OrderStepLog.Started = DateTime.Now;
                        args.OrderStepLog.StartedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertOrderStepLog(args.OrderStepLog);
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

        public SearchResult SearchOrder(Sender sender, SearchOrderArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchOrder(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public int UpdateOrder(Order args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.UpdateOrderByOrderID(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }


        #region  以下为旧接口，不用。如需使用请将方法移到外面，后续项目整理时这里面方法将删除
        public Order GetOrderByOrderNo(Sender sender, string OrderNo)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Order obj = new Order();
                    obj.OrderNo = OrderNo;
                    //if (op.LoadOrderByOrderNo(obj) == 0)
                    return null;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<Order> GetAllOrders(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    //return op.LoadOrders();
                    return null;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }


        public SearchResult SearchCloudSplitOrder(Sender sender, SearchOrderArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    //return op.SearchCloudSplitOrder(args);
                    SearchResult SearchResult = new SearchResult();
                    return SearchResult;
                }


            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool IsExistsCabinetNum(Guid OrderID, string CabinetNum)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.IsExistsCabinetNum(OrderID, CabinetNum);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public SearchResult SearchOrdersByOrderNoList(Sender sender, List<string> orderNoList)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchOrdersByOrderNoList(orderNoList);
                }


            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void UpdateOrderStatusByOrderIDs(Sender sender, List<Guid> OrderIDs, string OrderStatus, Guid ItemID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    // op.UpdateOrderStatusByOrderIDs(OrderIDs, OrderStatus);
                    //OrderDetail model = op.LoadOrderDetailsByItemID(ItemID).FirstOrDefault();
                    //if (model != null)
                    //{
                    //    op.UpdateOrderDetailByBatchNum(model.BatchNum, OrderStatus);
                    //}
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void UpdateOrderStatusByBattchNum(Sender sender, string BattchNum, string OrderStatus)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    // op.UpdateOrderStatusByBattchNum(BattchNum, OrderStatus);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchPrintOrderData(Sender sender, string OrderNo)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    // return op.SearchPrintOrderData(OrderNo);
                    SearchResult SearchResult = new SearchResult();
                    return SearchResult;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public int GetTotalOrderBattchQty(Sender sender, string BattchNo)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.GetTotalOrderBattchQty(BattchNo);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void UpdateOrderBattchIndex(Sender sender, string BattchNum)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    op.UpdateOrderBattchIndex(BattchNum);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public string GetTaskNo(Sender sender)
        {
            try
            {
                string key = "KN" + DateTime.Now.ToString("yy");
                int increase = GetIncrease(sender, key);
                return key + increase.ToString("0000000");
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public string GetOrderNo(Sender sender)
        {
            try
            {
                string key = "BN" + DateTime.Now.ToString("yyMM");
                int increase = GetIncrease(sender, key);
                return key + increase.ToString("0000000");
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public string GetBattchNum(Sender sender)
        {
            try
            {
                string key = "P" + DateTime.Now.Year.ToString();
                int increase = GetIncrease(sender, key);
                return key + increase.ToString("0000");
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        #endregion


    }
}
