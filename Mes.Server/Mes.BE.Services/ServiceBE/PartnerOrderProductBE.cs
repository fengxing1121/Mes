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
        public PartnerOrderProduct GetPartnerOrderProduct(Sender sender, Guid ProductID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PartnerOrderProduct obj = new PartnerOrderProduct();
                    obj.ProductID = ProductID;
                    if (op.LoadPartnerOrderProduct(obj) == 0)
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

        public List<PartnerOrderProduct> GetAllPartnerOrderProducts(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPartnerOrderProducts();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<PartnerOrderProduct> GetPartnerOrderProductByOrderID(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PartnerOrderProduct obj = new PartnerOrderProduct();
                    obj.OrderID = OrderID;
                    return op.LoadPartnerOrderProductByOrderID(obj);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public SearchResult SearchPartnerOrderProduct(Sender sender, SearchPartnerOrderProductArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchPartnerOrderProduct(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public void SavePartnerOrderProduct(Sender sender, PartnerOrderProduct obj)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadPartnerOrderProduct(obj) == 0)
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertPartnerOrderProduct(obj);
                    }
                    else
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdatePartnerOrderProductByProductID(obj);
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

