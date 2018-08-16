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
        public SolutionDetail GetSolutionDetail(Sender sender, Guid ItemID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    SolutionDetail obj = new SolutionDetail();
                    obj.ItemID = ItemID;
                    if (op.LoadSolutionDetailByItemID(obj) == 0)
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
        public SolutionDetail GetSolutionDetailByBarcode(Sender sender, string Barcode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    SolutionDetail obj = new SolutionDetail();
                    obj.BarcodeNo = Barcode;

                    if (op.LoadSolutionDetailByBarcodeNo(obj) == 0)
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
        public SearchResult SearchSolutionDetail(Sender sender, SearchSolutionDetailArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchSolutionDetail(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteSolutionDetailByCabinetID(Sender sender, Guid CabinetID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteSolutionDetailsByCabinetID(CabinetID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteSolutionDetailBySolutionID(Sender sender, Guid SolutionID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteSolutionDetailsBySolutionID(SolutionID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SaveSolutionDetail(Sender sender, SolutionDetail item)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    SolutionDetail obj = new SolutionDetail();
                    obj.CabinetID = item.CabinetID;
                    if (op.LoadSolutionDetailByItemID(obj) == 0)
                    {
                        item.Created = DateTime.Now;
                        item.CreatedBy = sender.UserCode + "." + sender.UserName;
                        item.Modified = DateTime.Now;
                        item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertSolutionDetail(item);
                    }
                    else
                    {
                        item.Modified = DateTime.Now;
                        item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateSolutionDetailByItemID(item);
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
        private bool IsSolutionBarcodeDuplicated(Sender sender, SolutionDetail item)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    SolutionDetail obj = new SolutionDetail();
                    obj.BarcodeNo = item.BarcodeNo;

                    if (op.LoadSolutionDetailByBarcodeNo(obj) == 0)
                    {
                        return false;
                    }
                    return obj.ItemID != item.ItemID;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchSolutionQuoteDetail(Sender sender, Guid SolutonID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchSolutionQuoteDetail(SolutonID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchSolutionQuoteHardwareDetail(Sender sender, Guid SolutonID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchSolutionQuoteHardwareDetail(SolutonID);
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
