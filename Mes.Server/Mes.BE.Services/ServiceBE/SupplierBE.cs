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
        public Supplier GetSupplier(Sender sender, Guid SupplierID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Supplier obj = new Supplier();
                    obj.SupplierID = SupplierID;
                    if (op.LoadSupplierBySupplierID(obj) == 0)
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
        public void SaveSupplier(Sender sender, SaveSupplierArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Supplier obj = new Supplier();
                    obj.SupplierID = args.Supplier.SupplierID;
                    if (op.LoadSupplierBySupplierID(obj) == 0)
                    {
                        args.Supplier.Created = DateTime.Now;
                        args.Supplier.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.Supplier.Modified = DateTime.Now;
                        args.Supplier.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertSupplier(args.Supplier);
                    }
                    else
                    {
                        args.Supplier.Modified = DateTime.Now;
                        args.Supplier.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateSupplierBySupplierID(args.Supplier);
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
        public SearchResult SearchSupplier(Sender sender, SearchSupplierArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchSupplier(args);
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
