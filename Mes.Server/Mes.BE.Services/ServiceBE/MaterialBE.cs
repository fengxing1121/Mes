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
        #region 材料
        public List<Material> GetAllMaterials(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadMaterials();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public Material GetMaterial(Sender sender, Guid MaterialID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Material obj = new Material();
                    obj.MaterialID = MaterialID;
                    if (op.LoadMaterialByMaterialID(obj) == 0)
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
        public void SaveMaterial(Sender sender, SaveMaterialArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {

                    Material obj = new Material();
                    obj.MaterialID = args.Material.MaterialID;
                    if (op.LoadMaterialByMaterialID(obj) == 0)
                    {
                        args.Material.Created = DateTime.Now;
                        args.Material.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.Material.Modified = DateTime.Now;
                        args.Material.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertMaterial(args.Material);
                    }
                    else
                    {
                        args.Material.Modified = DateTime.Now;
                        args.Material.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateMaterialByMaterialID(args.Material);
                    }

                    if (args.Material2Suppliers != null)
                    {
                        foreach (Material2Supplier item in args.Material2Suppliers)
                        {
                            Material2Supplier subObj = new Material2Supplier();
                            subObj.MaterialID = item.MaterialID;
                            subObj.SupplierID = item.SupplierID;
                            if (op.LoadMaterial2SupplierByMaterialID_SupplierID(subObj) == 0)
                            {
                                op.InsertMaterial2Supplier(item);
                            }
                            else
                            {
                                op.UpdateMaterial2SupplierByMaterialID_SupplierID(item);
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
        public SearchResult SearchMaterial(Sender sender, SearchMaterialArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchMaterial(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public Material GetMaterialByMaterialCode(Sender sender, string MaterialCode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Material obj = new Material();
                    obj.MaterialCode = MaterialCode;
                    if (op.LoadMaterialByMaterialCode(obj) == 0)
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
        #endregion
    }
}
