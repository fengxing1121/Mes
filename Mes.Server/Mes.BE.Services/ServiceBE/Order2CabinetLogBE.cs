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
        public List<Order2CabinetLog> GetOrder2CabinetLog(Sender sender, Guid CabinetID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrder2CabinetLog(CabinetID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchOrder2CabinetLogs(Sender sender, SearchOrder2CabinetArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchOrder2CabinetLogs(args);
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
