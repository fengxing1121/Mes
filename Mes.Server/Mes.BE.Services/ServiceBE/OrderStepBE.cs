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
        public OrderStep GetOrderStep(Sender sender, Guid StepID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    OrderStep obj = new OrderStep();
                    obj.StepID = StepID;
                    if (op.LoadOrderStep(obj) == 0)
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

        public List<OrderStep> GetAllOrderSteps(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrderSteps();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public OrderStep GetOrderStepByStepCode(Sender sender, string StepCode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    OrderStep obj = new OrderStep();
                    obj.StepCode = StepCode;
                    if (op.LoadOrderStepByStepCode(obj) == 0)
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
        public OrderStep GetOrderStepByPrivilegeID(Sender sender, Guid PrivilegeID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    OrderStep obj = new OrderStep();
                    obj.PrivilegeID = PrivilegeID;
                    if (op.LoadOrderStepByPrivilegeID(obj) == 0)
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

        public void SaveOrderStep(Sender sender, OrderStep obj)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadOrderStep(obj) == 0)
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertOrderStep(obj);
                    }
                    else
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateOrderStepByStepID(obj);
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

