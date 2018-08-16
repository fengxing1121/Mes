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
        public List<WarehouseOutMain> GetAllWarehouseOutMains(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadWarehouseOutMains();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public WarehouseOutMain GetWarehouseOutMain(Sender sender, Guid OutID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WarehouseOutMain obj = new WarehouseOutMain();
                    obj.OutID = OutID;
                    if (op.LoadWarehouseOutMainByOutID(obj) == 0)
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
        public void SaveWarehouseOutMain(Sender sender, SaveWarehouseOutMainArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    WarehouseOutMain obj = new WarehouseOutMain();
                    obj.OutID = args.WarehouseOutMain.OutID;
                    if (op.LoadWarehouseOutMainByOutID(obj) == 0)
                    {
                        args.WarehouseOutMain.Created = DateTime.Now;
                        args.WarehouseOutMain.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.WarehouseOutMain.Modified = DateTime.Now;
                        args.WarehouseOutMain.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertWarehouseOutMain(args.WarehouseOutMain);
                    }
                    else
                    {
                        args.WarehouseOutMain.Modified = DateTime.Now;
                        args.WarehouseOutMain.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateWarehouseOutMainByOutID(args.WarehouseOutMain);
                    }
                    if (args.WarehouseOutDetails != null)
                    {
                        //出库数量
                        foreach (WarehouseOutDetail item in args.WarehouseOutDetails)
                        {
                            WarehouseOutDetail subObj = new WarehouseOutDetail();
                            subObj.DetailID = item.DetailID;
                            if (op.LoadWarehouseOutDetailByDetailID(subObj) == 0)
                            {
                                op.InsertWarehouseOutDetail(item);
                            }
                            else
                            {
                                op.UpdateWarehouseOutDetailByDetailID(item);
                            }

                            //出库
                            Warehouse wh = new Warehouse();
                            wh.MaterialID = item.MaterialID;
                            wh.LocationID = item.LocationID;
                            if (op.LoadWarehouseByMaterialID_LocationID(wh) == 0)
                            {
                                wh = new Warehouse();
                                wh.MaterialID = item.MaterialID;
                                wh.LocationID = item.LocationID;
                                wh.Qty = -item.Qty;
                                wh.Price = 0;
                                op.InsertWarehouse(wh);
                            }
                            else
                            {
                                wh.Qty -= item.Qty;
                                //如果为0，则删除
                                if (wh.Qty == 0)
                                {
                                    op.DeleteWarehouseByMaterialID_LocationID(item.MaterialID, item.LocationID);
                                }
                                else
                                {
                                    op.UpdateWarehouseByMaterialID_LocationID(wh);
                                }
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
        public SearchResult SearchWarehouseOutMain(Sender sender, SearchWarehouseOutMainArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchWarehouseOutMain(args);
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
