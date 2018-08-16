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
        List<WorkingLine> GetAllWorkingLines(Sender sender);
        [OperationContract]
        WorkingLine GetWorkingLine(Sender sender, Guid WorkingLineID);
        [OperationContract]
        void SaveWorkingLine(Sender sender, SaveWorkingLineArgs args);
        [OperationContract]
        SearchResult SearchWorkingLine(Sender sender, SearchWorkingLineArgs args);
        [OperationContract]
        bool WorkingLineIsDuplicated(Sender sender, WorkingLine WorkingLine);
    }
}
