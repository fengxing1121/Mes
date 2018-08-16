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
    public partial interface IServiceBE
    {
        [OperationContract]
        void SaveLogisticsEnterprise(Sender sender, SaveLogisticsEnterpriseArgs args);
        [OperationContract]
        LogisticsEnterprise GetLogisticsEnterprise(Sender sender, Guid EnterpriseID);
        [OperationContract]
        SearchResult SearchLogisticsEnterprise(Sender sender, SearchLogisticsEnterpriseArgs args);
    }
}
