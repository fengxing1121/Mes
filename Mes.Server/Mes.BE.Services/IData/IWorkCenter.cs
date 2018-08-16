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
        List<WorkCenter> GetAllWorkCenters(Sender sender);
        [OperationContract]
        WorkCenter GetWorkCenter(Sender sender, Guid WorkCenterID);
        [OperationContract]
        WorkCenter GetWorkCenterByWorkCenterCode(Sender sender, string WorkCenterCode);
        [OperationContract]
        void SaveWorkCenter(Sender sender, SaveWorkCenterArgs args);
        [OperationContract]
        SearchResult SearchWorkCenter(Sender sender, SearchWorkCenterArgs args);
    }
}
