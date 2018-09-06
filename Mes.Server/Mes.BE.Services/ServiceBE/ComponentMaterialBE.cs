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
        public ComponentMaterial GetComponentMaterial(Sender sender, Int32 ID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ComponentMaterial obj = new ComponentMaterial();
                    obj.ID = ID;
                    if (op.LoadComponentMaterial(obj) == 0)
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

        public List<ComponentMaterial> GetAllComponentMaterials(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadComponentMaterials();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<ComponentMaterial> GetComponentMaterialByID(Sender sender, Int32 ID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ComponentMaterial obj = new ComponentMaterial();
                    obj.ID = ID;
                    return op.LoadComponentMaterialByID(obj);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public SearchResult SearchComponentMaterial(Sender sender, SearchComponentMaterialArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchComponentMaterial(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchComponentMaterialByComponentID(Sender sender, SearchComponentMaterialArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchComponentMaterialByComponentID(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SaveComponentMaterial(Sender sender, ComponentMaterial obj)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadComponentMaterial(obj) == 0)
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        obj.Modified = DateTime.Now;
                        obj.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertComponentMaterial(obj);
                    }
                    else
                    {
                        obj.Modified = DateTime.Now;
                        obj.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateComponentMaterialByID(obj);
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

        public void SaveComponentMaterials(Sender sender, SaveComponentMaterialArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadComponentMaterial(args.ComponentMaterial) == 0)
                    {
                        // string key = "S" + DateTime.Now.ToString("yy");
                        //int index = this.GetIncrease(sender, key);
                        //args.ComponentMaterial.ProduceNo= key + DateTime.Now.Month.ToString("00") + index.ToString("00000");
                        args.ComponentMaterial.Created = DateTime.Now;
                        args.ComponentMaterial.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertComponentMaterial(args.ComponentMaterial);
                    }
                    else
                    {
                        args.ComponentMaterial.Created = DateTime.Now;
                        args.ComponentMaterial.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateComponentMaterialByID(args.ComponentMaterial);
                    }

                    #region 订单产品
                    //if (args.ComponentMaterials != null)
                    //{
                    //    foreach (ComponentMaterial Item in args.ComponentMaterials)
                    //    {
                    //        if (op.LoadComponentMaterial(args.ComponentMaterial) == 0)
                    //        {
                    //            op.InsertComponentMaterialComponent(Item);
                    //        }
                    //        else
                    //        {
                    //            op.UpdateComponentMaterialByID(Item);
                    //        }
                    //    }
                    //}
                    #endregion

                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public void SaveComponentMaterialAndExtension(Sender sender, SaveComponentMaterialArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (args.ComponentMaterials != null)
                    {
                        foreach (ComponentMaterial Item in args.ComponentMaterials)
                        {
                            if (op.LoadComponentMaterial(Item) == 0)
                            {
                                Item.Created = DateTime.Now;
                                Item.CreatedBy = sender.UserCode + "." + sender.UserName;
                                Item.Modified = DateTime.Now;
                                Item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                                int componentMaterialID = op.AddComponentMaterial(Item);

                                Item.ExtensionModel.ComponentMaterialID = componentMaterialID;
                                Item.ExtensionModel.Created = DateTime.Now;
                                Item.ExtensionModel.CreatedBy = sender.UserCode + "." + sender.UserName;
                                op.InsertComponentMaterialExtension(Item.ExtensionModel);
                            }
                            else
                            {
                                Item.Modified = DateTime.Now;
                                Item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                                op.UpdateComponentMaterialByID(Item);
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
    }
}

