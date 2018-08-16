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
        public void DeletePackageItem(Sender sender, string Barcode, Guid WorkFlowID, bool IsRemovePackage)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    //包装数据                    
                    OrderDetail subOrder = new OrderDetail();
                    subOrder.BarcodeNo = Barcode;
                    if (op.LoadOrderDetailByBarcodeNo(subOrder) == 0)
                    {
                        throw new PException("【{0}】条码数据不存在。", Barcode);
                    }

                    Guid PackageID = Guid.Empty;
                    List<PackageDetail> PackageDetails = op.LoadPackageDetailsByItemID(subOrder.ItemID);
                    PackageDetail packageDetail = PackageDetails.Find(p => p.IsPackaged = true);
                    if (packageDetail != null)
                    {
                        PackageID = packageDetail.PakageID;
                        packageDetail.IsPackaged = false;
                        packageDetail.PakageID = Guid.Empty;
                        packageDetail.LayerNum = 0;
                        op.UpdatePackageDetailByDetailID(packageDetail);
                    }
                    else
                    {
                        throw new PException("【{0}】没有打包数据。", Barcode);
                    }

                    if (IsRemovePackage)
                    {
                        op.DeletePackageByPackageID(PackageID);
                    }
                    else
                    {
                        Package package = new Package();
                        package.PackageID = PackageID;
                        if (op.LoadPackageByPackageID(package) == 0)
                        {
                            throw new PException("【{0}】没有打包数据。", Barcode);
                        }
                        else
                        {
                            package.ItemsQty -= 1;
                            package.Weight -= subOrder.MadeLength * subOrder.MadeWidth * subOrder.MadeHeight * 0.000008M;
                            op.UpdatePackageByPackageID(package);
                        }
                    }

                    //生产流程                   
                    List<OrderMadeState> lists_oms = op.LoadOrderMadeStatesByItemID_WorkFlowID(subOrder.ItemID, WorkFlowID);
                    if (lists_oms.Count > 0)
                    {
                        op.DeleteOrderMadeStateByDetailID(lists_oms[0].DetailID);
                    }

                    //生产状态:数量减少
                    OrderWorkFlow owf = new OrderWorkFlow();
                    owf.ItemID = subOrder.ItemID;
                    owf.SourceWorkFlowID = WorkFlowID;
                    if (op.LoadOrderWorkFlowByItemID_SourceWorkFlowID(owf) != 0)
                    {
                        owf.MadeQty -= 1;
                        op.UpdateOrderWorkFlowByItemID_SourceWorkFlowID(owf);
                    }

                    //生产进度
                    OrderScheduling os = new OrderScheduling();
                    os.CabinetID = subOrder.CabinetID;
                    os.WorkFlowID = WorkFlowID;
                    if (op.LoadOrderSchedulingByCabinetID_WorkFlowID(os) != 0)
                    {
                        os.MadeTotalQty -= 1;
                        os.MadeTotalAreal -= subOrder.MadeLength * subOrder.MadeWidth * 0.000001M;
                        os.MadeTotalLength -= (subOrder.MadeLength + subOrder.MadeWidth) * 2 * 0.001M;
                        op.UpdateOrderSchedulingByMadeID(os);
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

        public Package GetPackage(Sender sender, Guid PackageID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Package obj = new Package();
                    obj.PackageID = PackageID;
                    if (op.LoadPackageByPackageID(obj) == 0)
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
        public List<Package> GetPackagesByOrderID(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPackagesByOrderID(OrderID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SavePackage(Sender sender, SavePackageArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Package obj = new Package();
                    obj.PackageID = args.Package.PackageID;
                    if (op.LoadPackageByPackageID(obj) == 0)
                    {
                        args.Package.Created = DateTime.Now;
                        args.Package.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertPackage(args.Package);
                    }
                    else
                    {
                        op.UpdatePackageByPackageID(args.Package);
                    }

                    if (args.PackageDetail != null)
                    {
                        PackageDetail item = new PackageDetail();
                        item.DetailID = args.PackageDetail.DetailID;
                        if (op.LoadPackageDetailByDetailID(item) == 0)
                        {
                            args.PackageDetail.Created = DateTime.Now;
                            args.PackageDetail.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                            args.PackageDetail.Modified = DateTime.Now;
                            args.PackageDetail.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                            op.InsertPackageDetail(args.PackageDetail);
                        }
                        else
                        {
                            args.PackageDetail.Modified = DateTime.Now;
                            args.PackageDetail.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                            op.UpdatePackageDetailByDetailID(args.PackageDetail);
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
        public int GetMaxPackageNum(Sender sender, Guid OrderID, Guid CabinetID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadMaxPackageNum(OrderID, CabinetID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SavePackageDetail(Sender sender, SavePackageDetailArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (args.PackageDetail != null)
                    {
                        PackageDetail obj = new PackageDetail();
                        obj.DetailID = args.PackageDetail.DetailID;
                        if (op.LoadPackageDetailByDetailID(obj) == 0)
                        {
                            args.PackageDetail.Created = DateTime.Now;
                            args.PackageDetail.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                            args.PackageDetail.Modified = DateTime.Now;
                            args.PackageDetail.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                            op.InsertPackageDetail(args.PackageDetail);
                        }
                        else
                        {
                            args.PackageDetail.Modified = DateTime.Now;
                            args.PackageDetail.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                            op.UpdatePackageDetailByDetailID(args.PackageDetail);
                        }
                    }

                    if (args.PackageDetails != null)
                    {
                        foreach (PackageDetail item in args.PackageDetails)
                        {
                            PackageDetail subobj = new PackageDetail();
                            subobj.DetailID = item.DetailID;
                            if (op.LoadPackageDetailByDetailID(subobj) == 0)
                            {
                                item.Created = DateTime.Now;
                                item.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                                item.Modified = DateTime.Now;
                                item.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                                op.InsertPackageDetail(item);
                            }
                            else
                            {
                                item.Modified = DateTime.Now;
                                item.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                                op.UpdatePackageDetailByDetailID(item);
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
        public SearchResult SearchPackage(Sender sender, SearchPackageArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchPackage(args);
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
