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
        #region 经销商收款管理
        public PartnerTransDetail GetPartnerTransDetail(Sender sender, Guid TransID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PartnerTransDetail obj = new PartnerTransDetail();
                    obj.TransID = TransID;
                    if (op.LoadPartnerTransDetailByTransID(obj) == 0)
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
        public SearchResult SearchPartnerTransDetail(Sender sender, SearchPartnerTransDetailArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchPartnerTransDetail(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PartnerTransDetail> GetPartnerTransDetailsByPartnerID(Sender sender, Guid PartnerID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPartnerTransDetailsByPartnerID(PartnerID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PartnerTransDetail> GetPartnerTransDetailsByOrderID(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPartnerTransDetailsByOrderID(OrderID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SavePartnerTransDetail(Sender sender, SavePartnerTransDetailArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    PartnerTransDetail obj = new PartnerTransDetail();
                    obj.TransID = args.PartnerTransDetail.TransID;
                    if (op.LoadPartnerTransDetailByTransID(obj) == 0)
                    {
                        args.PartnerTransDetail.Created = DateTime.Now;
                        args.PartnerTransDetail.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertPartnerTransDetail(args.PartnerTransDetail);
                    }
                    else
                    {
                        op.UpdatePartnerTransDetailByTransID(args.PartnerTransDetail);
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
        public void DeletePartnerTransDetail(Sender sender, Guid TransID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeletePartnerTransDetailByTransID(TransID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        #endregion
    }
}
