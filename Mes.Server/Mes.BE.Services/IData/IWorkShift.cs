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
        List<WorkShift> GetAllWorkShifts(Sender sender);
        [OperationContract]
        WorkShift GetWorkShift(Sender sender, Guid WorkShiftID);
        [OperationContract]
        WorkShift GetWorkShiftByWorkShiftCode(Sender sender, string WorkShiftCode);
        [OperationContract]
        void SaveWorkShift(Sender sender, SaveWorkShiftArgs args);
        [OperationContract]
        SearchResult SearchWorkShift(Sender sender, SearchWorkShiftArgs args);
    }
}
