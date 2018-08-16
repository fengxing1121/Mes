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
        public ProductionOrder GetProductionOrder(Sender sender, Guid ProductionID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ProductionOrder obj = new ProductionOrder();
                    obj.ProductionID = ProductionID;
                    if (op.LoadProductionOrder(obj) == 0)
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

        public List<ProductionOrder> GetAllProductionOrders(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadProductionOrders();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<ProductionOrder> GetProductionOrderByProductionID(Sender sender, Guid ProductionID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ProductionOrder obj = new ProductionOrder();
                    obj.ProductionID = ProductionID;
                    return op.LoadProductionOrderByProductionID(obj);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public SearchResult SearchProductionOrder(Sender sender, SearchProductionOrderArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchProductionOrder(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public SearchResult SearchProductComponents(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchProductComponents(OrderID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public void SaveProductionOrder(Sender sender, SaveProductionOrderArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadProductionOrder(args.ProductionOrder) == 0)
                    {
                        string key = "S" + DateTime.Now.ToString("yy");
                        int index = this.GetIncrease(sender, key);
                        args.ProductionOrder.ProduceNo= key + DateTime.Now.Month.ToString("00") + index.ToString("00000");
                        args.ProductionOrder.Created = DateTime.Now;
                        args.ProductionOrder.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertProductionOrder(args.ProductionOrder);
                    }
                    else
                    {
                        args.ProductionOrder.Created = DateTime.Now;
                        args.ProductionOrder.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateProductionOrderByProductionID(args.ProductionOrder);
                    }

                    #region 订单产品
                    //if (args.ProductionOrderComponents != null)
                    //{
                    //    foreach (ProductionOrderComponent Item in args.ProductionOrderComponents)
                    //    {
                    //        //if (op.LoadProductionOrderComponent(Item) == 0)
                    //       // {
                    //            op.InsertProductionOrderComponent(Item);
                    //        //}
                    //        //else
                    //        //{
                    //        //    op.UpdateProductionOrderComponentByProductionID(Item);
                    //        //}
                    //    }
                    //}
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

        public SearchResult SearchOrderByProductionOrder(Sender sender, SearchOrderArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchOrderByProductionOrder(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public void SchedulingProductionOrder(Sender sender, SchedulingProductionOrderArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadProductionOrderScheduling(args.ProductionOrderScheduling) == 0)
                    {
                        args.ProductionOrderScheduling.Created = DateTime.Now;
                        args.ProductionOrderScheduling.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertProductionOrderScheduling(args.ProductionOrderScheduling);
                    }
                    else
                    {
                        args.ProductionOrderScheduling.Created = DateTime.Now;
                        args.ProductionOrderScheduling.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateProductionOrderSchedulingBySchedulingID(args.ProductionOrderScheduling);
                    }

                    if (args.ProductionSetDayDetail != null)
                    {
                        op.UpdateProductionSetDayDetailByID(args.ProductionSetDayDetail);
                    }

                    if (args.ProductionOrder != null)
                    {
                        op.UpdateProductionOrderByProductionID(args.ProductionOrder);
                    }

                    if (args.OrderStepLog != null)
                    {
                        args.OrderStepLog.Started = DateTime.Now;
                        args.OrderStepLog.StartedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertOrderStepLog(args.OrderStepLog);
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
    }
}

