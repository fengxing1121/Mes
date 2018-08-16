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
        List<WorkCenterScheduling> GetAllWorkCenterSchedulings(Sender sender);
        [OperationContract]
        WorkCenterScheduling GetWorkCenterScheduling(Sender sender, Guid WorkID);
        [OperationContract]
        void SaveWorkCenterScheduling(Sender sender, SaveWorkCenterSchedulingArgs args);
        [OperationContract]
        List<WorkCenterScheduling> GetWorkCenterSchedulingWorkCenterID(Sender sender, Guid WorkCenterID);
        [OperationContract]
        SearchResult SearchWorkCenterScheduling(Sender sender, SearchWorkCenterSchedulingArgs args);
        [OperationContract]
        WorkCenterScheduling GetLastWorkCenterSchedulingByWorkCenterID(Sender sender, Guid WorkCenterID);
    }
}
