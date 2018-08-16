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
        public List<WorkShop> GetAllWorkShops(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadWorkShops();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public WorkShop GetWorkShop(Sender sender, Guid WorkShopID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WorkShop obj = new WorkShop();
                    obj.WorkShopID = WorkShopID;
                    if (op.LoadWorkShopByWorkShopID(obj) == 0)
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
        public WorkShop GetWorkShopByWorkShopCode(Sender sender, string WorkShopCode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WorkShop obj = new WorkShop();
                    obj.WorkShopCode = WorkShopCode;
                    if (op.LoadWorkShopByWorkShopCode(obj) == 0)
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
        public void SaveWorkShop(Sender sender, SaveWorkShopArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    WorkShop obj = new WorkShop();
                    obj.WorkShopID = args.WorkShop.WorkShopID;
                    if (op.LoadWorkShopByWorkShopID(obj) == 0)
                    {
                        args.WorkShop.Created = DateTime.Now;
                        args.WorkShop.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.WorkShop.Modified = DateTime.Now;
                        args.WorkShop.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertWorkShop(args.WorkShop);
                    }
                    else
                    {
                        args.WorkShop.Modified = DateTime.Now;
                        args.WorkShop.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateWorkShopByWorkShopID(args.WorkShop);
                    }

                    if (args.WorkShiftIDs != null)
                    {
                        op.DeleteWorkShift2WorkShopsByWorkShopID(args.WorkShop.WorkShopID);
                        foreach (Guid workShiftID in args.WorkShiftIDs)
                        {
                            WorkShift2WorkShop ws2ws = new WorkShift2WorkShop();
                            ws2ws.WorkShiftID = workShiftID;
                            ws2ws.WorkShopID = args.WorkShop.WorkShopID;
                            op.InsertWorkShift2WorkShop(ws2ws);
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
        public SearchResult SearchWorkShop(Sender sender, SearchWorkShopArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchWorkShop(args);
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
