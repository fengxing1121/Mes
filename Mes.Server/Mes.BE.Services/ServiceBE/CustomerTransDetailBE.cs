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
        #region 客户收款管理
        public CustomerTransDetail GetCustomerTransDetail(Sender sender, Guid TransID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    CustomerTransDetail obj = new CustomerTransDetail();
                    obj.TransID = TransID;
                    if (op.LoadCustomerTransDetailByTransID(obj) == 0)
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
        public SearchResult SearchCustomerTransDetail(Sender sender, SearchCustomerTransDetailArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchCustomerTransDetail(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<CustomerTransDetail> GetCustomerTransDetailsByCustomerID(Sender sender, Guid CustomerID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadCustomerTransDetailsByCustomerID(CustomerID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<CustomerTransDetail> GetCustomerTransDetailsByQuoteID(Sender sender, Guid QuoteID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadCustomerTransDetailsByQuoteID(QuoteID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SaveCustomerTransDetail(Sender sender, SaveCustomerTransDetailArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    CustomerTransDetail obj = new CustomerTransDetail();
                    obj.TransID = args.CustomerTransDetail.TransID;
                    if (op.LoadCustomerTransDetailByTransID(obj) == 0)
                    {
                        args.CustomerTransDetail.Created = DateTime.Now;
                        args.CustomerTransDetail.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertCustomerTransDetail(args.CustomerTransDetail);
                    }
                    else
                    {
                        op.UpdateCustomerTransDetailByTransID(args.CustomerTransDetail);
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

        public void DeleteCustomerTransDetail(Sender sender, Guid TransID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteCustomerTransDetailByTransID(TransID);
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
