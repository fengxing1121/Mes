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
        public OrderStepLog GetOrderStepLog(Sender sender, Guid StepID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    OrderStepLog obj = new OrderStepLog();
                    obj.StepID = StepID;
                    if (op.LoadOrderStepLog(obj) == 0)
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

        public List<OrderStepLog> GetAllOrderStepLogs(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrderStepLogs();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<OrderStepLog> GetOrderStepLogByOrderID(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    OrderStepLog obj = new OrderStepLog();
                    obj.OrderID = OrderID;
                    return op.LoadOrderStepLogByOrderID(obj);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }


        public void SaveOrderStepLog(Sender sender, OrderStepLog obj)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadOrderStepLog(obj) == 0)
                    {
                        //obj.Created = DateTime.Now;
                        //obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertOrderStepLog(obj);
                    }
                    else
                    {
                        //obj.Created = DateTime.Now;
                        //obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateOrderStepLogByStepID(obj);
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

