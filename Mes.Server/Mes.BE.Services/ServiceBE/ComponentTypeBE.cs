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
        public ComponentType GetComponentType(Sender sender, Int32 ComponentTypeID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ComponentType obj = new ComponentType();
                    obj.ComponentTypeID = ComponentTypeID;
                    if (op.LoadComponentType(obj) == 0)
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

        public List<ComponentType> GetAllComponentTypes(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadComponentTypes();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<ComponentType> GetComponentTypeByComponentTypeID(Sender sender, Int32 ComponentTypeID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ComponentType obj = new ComponentType();
                    obj.ComponentTypeID = ComponentTypeID;
                    return op.LoadComponentTypeByComponentTypeID(obj);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public SearchResult SearchComponentType(Sender sender, SearchComponentTypeArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchComponentType(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public void SaveComponentType(Sender sender, ComponentType obj)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    ComponentType model = new ComponentType();
                    model.ComponentTypeID = obj.ComponentTypeID;
                    if (op.LoadComponentType(model) == 0)
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertComponentType(obj);
                    }
                    else
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateComponentTypeByComponentTypeID(obj);
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

        public void SaveComponentTypes(Sender sender, SaveComponentTypeArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadComponentType(args.ComponentType) == 0)
                    {
                        string key = "S" + DateTime.Now.ToString("yy");
                        int index = this.GetIncrease(sender, key);
                        //args.ComponentType.ProduceNo= key + DateTime.Now.Month.ToString("00") + index.ToString("00000");
                        args.ComponentType.Created = DateTime.Now;
                        args.ComponentType.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertComponentType(args.ComponentType);
                    }
                    else
                    {
                        args.ComponentType.Created = DateTime.Now;
                        args.ComponentType.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateComponentTypeByComponentTypeID(args.ComponentType);
                    }

                    #region 订单产品
                    //if (args.ComponentTypes != null)
                    //{
                    //    foreach (ComponentType Item in args.ComponentTypes)
                    //    {
                    //        if (op.LoadComponentType(args.ComponentType) == 0)
                    //        {
                    //            op.InsertComponentTypeComponent(Item);
                    //        }
                    //        else
                    //        {
                    //            op.UpdateComponentTypeByComponentTypeID(Item);
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

