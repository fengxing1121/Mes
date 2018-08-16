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
        public void UpdateOrder2CabinetStatusByBattchCode(string BattchCode, string CabinetStatus)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.UpdateOrder2CabinetStatusByBattchCode(BattchCode, CabinetStatus);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public void SaveOrder2Cabinet(Sender sender, SaveOrder2CabinetArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Order2Cabinet obj = new Order2Cabinet();
                    obj.CabinetID = args.Order2Cabinet.CabinetID;
                    if (op.LoadOrder2CabinetByCabinetID(obj) == 0)
                    {
                        args.Order2Cabinet.Created = DateTime.Now;
                        args.Order2Cabinet.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.Order2Cabinet.Modified = DateTime.Now;
                        args.Order2Cabinet.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertOrder2Cabinet(args.Order2Cabinet);
                    }
                    else
                    {
                        op.UpdateOrder2CabinetByCabinetID(args.Order2Cabinet);
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
        public Order2Cabinet GetOrder2Cabinet(Sender sender, Guid CabinetID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Order2Cabinet obj = new Order2Cabinet();
                    obj.CabinetID = CabinetID;
                    if (op.LoadOrder2CabinetByCabinetID(obj) == 0)
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
        public Order2Cabinet GetOrder2CabinetByOrderID_CabinetName(Sender sender, Guid OrderID, string CabinetName)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Order2Cabinet obj = new Order2Cabinet();
                    obj.OrderID = OrderID;
                    obj.CabinetName = CabinetName;
                    if (op.LoadOrder2CabinetByOrderID_CabinetName(obj) == 0)
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
        public List<Order2Cabinet> GetOrder2CabinetByOrderID(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrder2CabinetsByOrderID(OrderID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchOrder2Cabinet(Sender sender, SearchOrder2CabinetArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchOrder2Cabinet(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public SearchResult SearchPrintCabinetData(Sender sender, string BarcodeNo)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchPrintCabinetData(BarcodeNo);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public int UpdateCabinetStatus(Order2Cabinet obj, OprationType Opration, Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    int resurt = op.UpdateCabinetStatus(obj, Opration, sender);
                    op.CommitTransaction();//加入事物处理，保证数据统一
                    return resurt;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteOrder2CabinetByCabinetID(Sender sender, Guid CabinetID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteOrder2CabinetByCabinetID(CabinetID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteOrder2CabinetByOrderID(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteOrder2CabinetsByOrderID(OrderID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public int GetTotalOrderCabinetQty(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.GetTotalOrderCabinetQty(OrderID);
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
