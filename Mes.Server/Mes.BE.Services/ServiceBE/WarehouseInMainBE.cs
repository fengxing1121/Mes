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
        public SearchResult SearchWarehouseInDetail(Sender sender, SearchWarehouseInDetailArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchWarehouseInDetail(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<WarehouseInMain> GetAllWarehouseInMains(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadWarehouseInMains();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public WarehouseInMain GetWarehouseInMain(Sender sender, Guid InID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WarehouseInMain obj = new WarehouseInMain();
                    obj.InID = InID;
                    if (op.LoadWarehouseInMainByInID(obj) == 0)
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
        public void SaveWarehouseInMain(Sender sender, SaveWarehouseInMainArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    WarehouseInMain obj = new WarehouseInMain();
                    obj.InID = args.WarehouseInMain.InID;
                    if (op.LoadWarehouseInMainByInID(obj) == 0)
                    {
                        args.WarehouseInMain.Created = DateTime.Now;
                        args.WarehouseInMain.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.WarehouseInMain.Modified = DateTime.Now;
                        args.WarehouseInMain.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertWarehouseInMain(args.WarehouseInMain);
                    }
                    else
                    {
                        args.WarehouseInMain.Modified = DateTime.Now;
                        args.WarehouseInMain.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateWarehouseInMainByInID(args.WarehouseInMain);
                    }
                    if (args.WarehouseInDetails != null)
                    {
                        //入库数量
                        foreach (WarehouseInDetail item in args.WarehouseInDetails)
                        {
                            WarehouseInDetail subObj = new WarehouseInDetail();
                            subObj.DetailID = item.DetailID;
                            if (op.LoadWarehouseInDetailByDetailID(subObj) == 0)
                            {
                                op.InsertWarehouseInDetail(item);
                            }
                            else
                            {
                                op.UpdateWarehouseInDetailByDetailID(item);
                            }

                            //入库
                            Warehouse wh = new Warehouse();
                            wh.MaterialID = item.MaterialID;
                            wh.LocationID = item.LocationID;
                            if (op.LoadWarehouseByMaterialID_LocationID(wh) == 0)
                            {
                                wh = new Warehouse();
                                wh.MaterialID = item.MaterialID;
                                wh.LocationID = item.LocationID;
                                wh.Qty = item.Qty;
                                wh.Price = item.Price;
                                op.InsertWarehouse(wh);
                            }
                            else
                            {
                                wh.Price = (wh.Qty * wh.Price + item.Qty * item.Price) / (wh.Qty + item.Qty); //求平均值
                                wh.Qty += item.Qty;
                                op.UpdateWarehouseByMaterialID_LocationID(wh);
                            }
                        }
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
        public SearchResult SearchWarehouseInMain(Sender sender, SearchWarehouseInMainArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchWarehouseInMain(args);
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
