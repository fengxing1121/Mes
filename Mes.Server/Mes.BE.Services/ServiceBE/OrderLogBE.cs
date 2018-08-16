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
        public List<OrderLog> GetOrderLogs(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrderLogsByOrderID(OrderID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<OrderLog> GetOrderStatusLogsByOrderID(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrderStatusLogsByOrderID(OrderID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public void SaveOrderLog(Sender sender, SaveOrderLogArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    OrderLog obj = new OrderLog();
                    obj.LogID = args.OrderLog.LogID;
                    if (op.LoadOrderLogByLogID(obj) == 0)
                    {
                        args.OrderLog.Created = DateTime.Now;
                        args.OrderLog.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertOrderLog(args.OrderLog);
                    }
                    else
                    {
                        op.UpdateOrderLogByLogID(args.OrderLog);
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
