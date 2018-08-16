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
        public void SaveTransport(Sender sender, SaveTransportArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    TransportMain obj = new TransportMain();
                    obj.TransportID = args.TransportMain.TransportID;
                    if (op.LoadTransportMainByTransportID(obj) == 0)
                    {
                        args.TransportMain.Created = DateTime.Now;
                        args.TransportMain.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertTransportMain(args.TransportMain);
                    }
                    else
                    {
                        op.UpdateTransportMainByTransportID(args.TransportMain);
                    }

                    if (args.TransportDetails != null)
                    {
                        op.DeleteTransportDetailsByTransportID(args.TransportMain.TransportID);
                        foreach (TransportDetail item in args.TransportDetails)
                        {
                            op.InsertTransportDetail(item);
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
        public TransportMain GetTransportMain(Sender sender, Guid TransportID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    TransportMain obj = new TransportMain();
                    obj.TransportID = TransportID;
                    if (op.LoadTransportMainByTransportID(obj) == 0)
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
        public SearchResult SearchTransportMain(Sender sender, SearchTransportMainArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    return op.SearchTransportMain(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchTransportDetail(Sender sender, SearchTransportDetailArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    return op.SearchTransportDetail(args);
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
