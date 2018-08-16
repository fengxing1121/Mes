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
        #region 报价
        public QuoteMain GetQuoteMain(Sender sender, Guid QuoteID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    QuoteMain obj = new QuoteMain();
                    obj.QuoteID = QuoteID;
                    if (op.LoadQuoteMainByQuoteID(obj) == 0)
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
        public QuoteMain GetQuoteMainBySolutionID(Sender sender, Guid SolutionID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    QuoteMain obj = new QuoteMain();
                    obj.SolutionID = SolutionID;
                    if (op.LoadQuoteMainBySolutionID(obj) == 0)
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
        public QuoteMain GetQuoteMainByQuoteNo(Sender sender, string QuoteNo)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    QuoteMain obj = new QuoteMain();
                    obj.QuoteNo = QuoteNo;
                    if (op.LoadQuoteMainByQuoteNo(obj) == 0)
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
        public void SaveQuote(Sender sender, SaveQuoteMainArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    QuoteMain obj = new QuoteMain();
                    obj.QuoteID = args.QuoteMain.QuoteID;
                    if (op.LoadQuoteMainByQuoteID(obj) == 0)
                    {
                        args.QuoteMain.Created = DateTime.Now;
                        args.QuoteMain.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.QuoteMain.Modified = DateTime.Now;
                        args.QuoteMain.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertQuoteMain(args.QuoteMain);
                    }
                    else
                    {
                        args.QuoteMain.Modified = DateTime.Now;
                        args.QuoteMain.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateQuoteMainByQuoteID(args.QuoteMain);
                    }
                    if (args.QuoteDetails != null)
                    {
                        op.DeleteQuoteDetailsByQuoteID(args.QuoteMain.QuoteID);
                        foreach (QuoteDetail item in args.QuoteDetails)
                        {
                            op.InsertQuoteDetail(item);
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
        public SearchResult SearchQuote(Sender sender, SearchQuoteMainArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchQuote(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public QuoteDetail GetQuoteDetail(Sender sender, Guid DetailID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    QuoteDetail obj = new QuoteDetail();
                    obj.DetailID = DetailID;
                    if (op.LoadQuoteDetailByDetailID(obj) == 0)
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
        public SearchResult SearchQuoteDetail(Sender sender, SearchQuoteDetailArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchQuoteDetail(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteQuote(Sender sender, Guid QuoteID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteQuoteDetailsByQuoteID(QuoteID);
                    op.DeleteQuoteMainByQuoteID(QuoteID);
                    op.CommitTransaction();
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
