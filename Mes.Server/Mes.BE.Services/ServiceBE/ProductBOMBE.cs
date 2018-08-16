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
        public ProductBOM GetProductBOM(Sender sender, Int32 ID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ProductBOM obj = new ProductBOM();
                    obj.ID = ID;
                    if (op.LoadProductBOM(obj) == 0)
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

        public List<ProductBOM> GetAllProductBOMs(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadProductBOMs();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<ProductBOM> GetProductBOMByID(Sender sender, Int32 ID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ProductBOM obj = new ProductBOM();
                    obj.ID = ID;
                    return op.LoadProductBOMByID(obj);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public SearchResult SearchProductBOM(Sender sender, SearchProductBOMArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchProductBOM(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public void SaveProductBOM(Sender sender, ProductBOM obj)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    ProductBOM model = new ProductBOM();
                    model.ID = obj.ID;
                    if (op.LoadProductBOM(model) == 0)
                    {
                        string key = "BOM" + DateTime.Now.ToString("yy");
                        int index = this.GetIncrease(sender, key);
                        obj.BOMID = key + DateTime.Now.Month.ToString("00") + index.ToString("00000");
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertProductBOM(obj);
                    }
                    else
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateProductBOMByID(obj);
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

        public void SaveProductBOMs(Sender sender, SaveProductBOMArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadProductBOM(args.ProductBOM) == 0)
                    {
                        string key = "S" + DateTime.Now.ToString("yy");
                        int index = this.GetIncrease(sender, key);
                        //args.ProductBOM.ProduceNo= key + DateTime.Now.Month.ToString("00") + index.ToString("00000");
                        args.ProductBOM.Created = DateTime.Now;
                        args.ProductBOM.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertProductBOM(args.ProductBOM);
                    }
                    else
                    {
                        args.ProductBOM.Created = DateTime.Now;
                        args.ProductBOM.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateProductBOMByID(args.ProductBOM);
                    }

                    #region 订单产品
                    //if (args.ProductBOMs != null)
                    //{
                    //    foreach (ProductBOM Item in args.ProductBOMs)
                    //    {
                    //        if (op.LoadProductBOM(args.ProductBOM) == 0)
                    //        {
                    //            op.InsertProductBOMComponent(Item);
                    //        }
                    //        else
                    //        {
                    //            op.UpdateProductBOMByID(Item);
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

