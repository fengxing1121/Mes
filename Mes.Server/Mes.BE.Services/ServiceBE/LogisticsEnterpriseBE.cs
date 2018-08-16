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
        public void SaveLogisticsEnterprise(Sender sender, SaveLogisticsEnterpriseArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    LogisticsEnterprise obj = new LogisticsEnterprise();
                    obj.EnterpriseID = args.LogisticsEnterprise.EnterpriseID;
                    if (op.LoadLogisticsEnterpriseByEnterpriseID(obj) == 0)
                    {
                        args.LogisticsEnterprise.Created = DateTime.Now;
                        args.LogisticsEnterprise.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.LogisticsEnterprise.Modified = DateTime.Now;
                        args.LogisticsEnterprise.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertLogisticsEnterprise(args.LogisticsEnterprise);
                    }
                    else
                    {
                        args.LogisticsEnterprise.Modified = DateTime.Now;
                        args.LogisticsEnterprise.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateLogisticsEnterpriseByEnterpriseID(args.LogisticsEnterprise);
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
        public LogisticsEnterprise GetLogisticsEnterprise(Sender sender, Guid EnterpriseID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    LogisticsEnterprise obj = new LogisticsEnterprise();
                    obj.EnterpriseID = EnterpriseID;
                    if (op.LoadLogisticsEnterpriseByEnterpriseID(obj) == 0)
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
        public SearchResult SearchLogisticsEnterprise(Sender sender, SearchLogisticsEnterpriseArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    return op.SearchLogisticsEnterprise(args);
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
