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
        /// <summary>
        /// 字典表中订单类型ID
        /// </summary>
        Guid ORDERTYPECATEGORORYID = new Guid("F1E5C1D4-3D37-4CE4-852B-88B362410B12");

        public PartnerOrder GetPartnerOrder(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PartnerOrder obj = new PartnerOrder();
                    obj.OrderID = OrderID;
                    if (op.LoadPartnerOrder(obj) == 0)
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

        public void SavePartnerOrder(Sender sender, SavePartnerOrderArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    PartnerOrder obj = new PartnerOrder();
                    obj.OrderID = args.Order.OrderID;

                    List<Category> Categorys = op.LoadCategorysByParentID(ORDERTYPECATEGORORYID);

                    
                    if (op.LoadPartnerOrder(obj) == 0)
                    {
                        string ordertypeCode = Categorys.Where(t => t.CategoryName == args.Order.OrderType).FirstOrDefault().CategoryCode;
                        string key = ordertypeCode +"P"+ DateTime.Now.ToString("yy");

                        int index = this.GetIncrease(sender, key);
                        args.Order.OrderNo = key + DateTime.Now.Month.ToString("00") + index.ToString("00000");

                        args.Order.Created = DateTime.Now;
                        args.Order.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.Order.Modified = DateTime.Now;
                        args.Order.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertPartnerOrder(args.Order);
                    }
                    else
                    {
                        args.Order.Modified = DateTime.Now;
                        args.Order.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdatePartnerOrderByOrderID(args.Order);
                    }



                    #region 订单产品
                    if (args.PartnerOrderProducts != null)
                    {
                        for(int i=0;i< args.PartnerOrderProducts.Count; i++)
                        {
                            var model = args.PartnerOrderProducts[i];
                            PartnerOrderProduct subObj = new PartnerOrderProduct();
                            subObj.ProductID = model.ProductID;
                            if (op.LoadPartnerOrderProduct(subObj) == 0)
                            {
                                if (string.IsNullOrEmpty(model.ProductCode) || model.ProductCode.Length <= 1)
                                {
                                    //subObj.CabinetCode = args.Order.OrderNo + (char)(64 + order2Cabinet.Sequence);
                                    model.ProductCode = string.Format("{0}-{1}-{2}", args.Order.OrderNo, args.PartnerOrderProducts.Count, i+1);
                                }
                                model.Created = DateTime.Now;
                                model.CreatedBy = sender.UserCode + "." + sender.UserName;
                                model.Modified = DateTime.Now;
                                model.ModifiedBy = sender.UserCode + "." + sender.UserName;
                                op.InsertPartnerOrderProduct(model);
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(model.ProductCode) || model.ProductCode.Length <= 1)
                                {
                                    //order2Cabinet.CabinetCode = args.Order.OrderNo + (char)(64 + order2Cabinet.Sequence);
                                    model.ProductCode = string.Format("{0}-{1}-{2}", args.Order.OrderNo, args.PartnerOrderProducts.Count, i + 1);
                                }
                                model.Modified = DateTime.Now;
                                model.ModifiedBy = sender.UserCode + "." + sender.UserName;
                                op.UpdatePartnerOrderProductByProductID(model);
                            }
                        }
                    }
                    #endregion

                    #region 订单步骤
                    if (args.OrderStepLog != null)
                    {
                        args.OrderStepLog.Started = DateTime.Now;
                        args.OrderStepLog.StartedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertOrderStepLog(args.OrderStepLog);
                    }
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

        public SearchResult SearchPartnerOrder(Sender sender, SearchPartnerOrderArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchPartnerOrder(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public int UpdatePartnerOrder(Order args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.UpdatePartnerOrder(args);
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
