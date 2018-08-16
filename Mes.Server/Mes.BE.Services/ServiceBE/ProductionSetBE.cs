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
        public ProductionSet GetProductionSet(Sender sender, Guid SetID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ProductionSet obj = new ProductionSet();
                    obj.SetID = SetID;
                    if (op.LoadProductionSet(obj) == 0)
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
        public ProductionSetDayDetail GetProductionSetDayDetailByMadeTotalAreal(Sender sender, decimal MadeTotalAreal)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ProductionSetDayDetail obj = new ProductionSetDayDetail();
                    obj.MadeTotalAreal = MadeTotalAreal;
                    if (op.LoadProductionSetDayDetailByMadeTotalAreal(obj) == 0)
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
        public List<ProductionSet> GetAllProductionSets(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadProductionSets();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<ProductionSet> GetProductionSetBySetID(Sender sender, Guid SetID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ProductionSet obj = new ProductionSet();
                    obj.SetID = SetID;
                    return op.LoadProductionSetBySetID(obj);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public SearchResult SearchProductionSet(Sender sender, SearchProductionSetArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchProductionSet(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchProductionSetDayDetail(Sender sender, SearchProductionSetDayDetailArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchProductionSetDayDetail(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool ExistsProductionSetDayDetailByDatetime(DateTime Started, DateTime Ended)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.ExistsProductionSetDayDetailByDatetime(Started,Ended);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SaveProductionSet(Sender sender, ProductionSet obj)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadProductionSet(obj) == 0)
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertProductionSet(obj);
                    }
                    else
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateProductionSetBySetID(obj);
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

        public void SaveProductionSets(Sender sender, SaveProductionSetArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadProductionSet(args.ProductionSet) == 0)
                    {
                        args.ProductionSet.Created = DateTime.Now;
                        args.ProductionSet.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertProductionSet(args.ProductionSet);
                    }
                    else
                    {
                        args.ProductionSet.Created = DateTime.Now;
                        args.ProductionSet.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateProductionSetBySetID(args.ProductionSet);
                    }

                    #region 生产订单排单设置主表
                    if (args.ProductionSetDayDetails != null)
                    {
                        foreach (ProductionSetDayDetail Item in args.ProductionSetDayDetails)
                        {
                            if (op.LoadProductionSetDayDetail(Item) == 0)
                            {
                                op.InsertProductionSetDayDetail(Item);
                            }
                            else
                            {
                                op.UpdateProductionSetDayDetailByID(Item);
                            }
                        }
                    }
                    #endregion

                    #region 生产订单排单设置主表
                    if (args.ProductionSetWeekDetails != null)
                    {
                        foreach (ProductionSetWeekDetail Item in args.ProductionSetWeekDetails)
                        {
                            if (op.LoadProductionSetWeekDetail(Item) == 0)
                            {
                                op.InsertProductionSetWeekDetail(Item);
                            }
                            else
                            {
                                op.UpdateProductionSetWeekDetailByID(Item);
                            }
                        }
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
    }
}

