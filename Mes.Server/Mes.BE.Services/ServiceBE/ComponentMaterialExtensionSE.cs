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
        public ComponentMaterialExtension GetComponentMaterialExtension(Sender sender, Int32 ID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ComponentMaterialExtension obj = new ComponentMaterialExtension();
                    obj.ID = ID;
                    if (op.LoadComponentMaterialExtension(obj) == 0)
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

        public List<ComponentMaterialExtension> GetAllComponentMaterialExtensions(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadComponentMaterialExtensions();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<ComponentMaterialExtension> GetComponentMaterialExtensionByID(Sender sender, Int32 ID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ComponentMaterialExtension obj = new ComponentMaterialExtension();
                    obj.ID = ID;
                    return op.LoadComponentMaterialExtensionByID(obj);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public SearchResult SearchComponentMaterialExtension(Sender sender, SearchComponentMaterialExtensionArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchComponentMaterialExtension(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public void SaveComponentMaterialExtension(Sender sender, ComponentMaterialExtension obj)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadComponentMaterialExtension(obj) == 0)
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertComponentMaterialExtension(obj);
                    }
                    else
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateComponentMaterialExtensionByID(obj);
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

        public void SaveComponentMaterialExtensions(Sender sender, SaveComponentMaterialExtensionArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadComponentMaterialExtension(args.ComponentMaterialExtension) == 0)
                    {
                        string key = "S" + DateTime.Now.ToString("yy");
                        int index = this.GetIncrease(sender, key);
                        //args.ComponentMaterialExtension.ProduceNo= key + DateTime.Now.Month.ToString("00") + index.ToString("00000");
                        args.ComponentMaterialExtension.Created = DateTime.Now;
                        args.ComponentMaterialExtension.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertComponentMaterialExtension(args.ComponentMaterialExtension);
                    }
                    else
                    {
                        args.ComponentMaterialExtension.Created = DateTime.Now;
                        args.ComponentMaterialExtension.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateComponentMaterialExtensionByID(args.ComponentMaterialExtension);
                    }

                    #region 订单产品
                    //if (args.ComponentMaterialExtensions != null)
                    //{
                    //    foreach (ComponentMaterialExtension Item in args.ComponentMaterialExtensions)
                    //    {
                    //        if (op.LoadComponentMaterialExtension(args.ComponentMaterialExtension) == 0)
                    //        {
                    //            op.InsertComponentMaterialExtensionComponent(Item);
                    //        }
                    //        else
                    //        {
                    //            op.UpdateComponentMaterialExtensionByID(Item);
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
    }
}