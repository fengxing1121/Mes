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
        public void SaveOrder2Hardware(Sender sender, SaveOrder2HardwareArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Order2Hardware obj = new Order2Hardware();
                    obj.ItemID = args.Order2Hardware.ItemID;
                    if (op.LoadOrder2HardwareByItemID(obj) == 0)
                    {
                        op.InsertOrder2Hardware(args.Order2Hardware);
                    }
                    else
                    {
                        op.UpdateOrder2HardwareByItemID(args.Order2Hardware);
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
        public Order2Hardware GetOrder2Hardware(Sender sender, Guid ItemID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Order2Hardware obj = new Order2Hardware();
                    obj.ItemID = ItemID;
                    if (op.LoadOrder2HardwareByItemID(obj) == 0)
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
        public List<Order2Hardware> GetOrder2HardwaresByOrderID(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrder2HardwaresByOrderID(OrderID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<Order2Hardware> GetOrder2HardwaresByOrderID_CabinetID(Sender sender, Guid OrderID, Guid CabinetID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    List<Order2Hardware> list = op.LoadOrder2HardwaresByOrderID(OrderID);
                    if (list != null)
                    {
                        return list.FindAll(item => item.CabinetID == CabinetID);
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchOrder2Hardware(Sender sender, SearchOrder2HardwareArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchOrder2Hardware(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteOrder2HardwareByCabinetID(Sender sender, Guid CabinetID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteOrder2HardwaresByCabinetID(CabinetID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteOrder2HardwareByOrderID(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteOrder2HardwaresByOrderID(OrderID);
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
