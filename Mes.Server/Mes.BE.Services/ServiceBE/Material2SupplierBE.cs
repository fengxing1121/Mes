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
        public void SaveMaterial2Supplier(Sender sender, SaveMaterial2SupplierArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Material2Supplier obj = new Material2Supplier();
                    obj.MaterialID = args.Material2Supplier.MaterialID;
                    obj.SupplierID = args.Material2Supplier.SupplierID;
                    if (op.LoadMaterial2SupplierByMaterialID_SupplierID(obj) == 0)
                    {
                        op.InsertMaterial2Supplier(args.Material2Supplier);
                    }
                    else
                    {
                        op.UpdateMaterial2SupplierByMaterialID_SupplierID(args.Material2Supplier);
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
        public Material2Supplier GetMaterial2Supplier(Sender sender, Guid MaterialID, Guid SupplierID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Material2Supplier obj = new Material2Supplier();
                    obj.SupplierID = SupplierID;
                    obj.MaterialID = MaterialID;
                    if (op.LoadMaterial2SupplierByMaterialID_SupplierID(obj) == 0)
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
        public List<Material2Supplier> GetMaterial2SuppliersByMaterialID(Sender sender, Guid MaterialID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadMaterial2SuppliersByMaterialID(MaterialID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<Material2Supplier> GetMaterial2SuppliersBySupplierID(Sender sender, Guid SupplierID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadMaterial2SuppliersBySupplierID(SupplierID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SeachMaterial2Supplier(Sender sender, SearchMaterial2SupplierArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SeachMaterial2Supplier(args);
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
