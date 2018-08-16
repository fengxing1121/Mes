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
        public WorkOrder GetWorkOrder(Sender sender, Guid WorkOrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WorkOrder obj = new WorkOrder();
                    obj.WorkOrderID = WorkOrderID;
                    if (op.LoadWorkOrder(obj) == 0)
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

        public List<WorkOrder> GetAllWorkOrders(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadWorkOrders();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<WorkOrder> GetWorkOrderByWorkOrderID(Sender sender, Guid WorkOrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WorkOrder obj = new WorkOrder();
                    obj.WorkOrderID = WorkOrderID;
                    return op.LoadWorkOrderByWorkOrderID(obj);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public SearchResult SearchWorkOrder(Sender sender, SearchWorkOrderArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchWorkOrder(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public void SaveWorkOrders(Sender sender, SaveWorkOrderArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (args.WorkOrders != null)
                    {
                        foreach (WorkOrder Item in args.WorkOrders)
                        {
                            string key = "W" + DateTime.Now.ToString("yy");
                            int index = this.GetIncrease(sender, key);
                            Item.WorkOrderNo = key + DateTime.Now.Month.ToString("00") + index.ToString("00000");
                            Item.Created = DateTime.Now;
                            Item.CreatedBy = sender.UserCode + "." + sender.UserName;
                            op.InsertWorkOrder(Item);
                        }
                    }

                    if (args.ProductionOrder != null)
                    {
                        op.UpdateProductionOrderByProductionID(args.ProductionOrder);
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

