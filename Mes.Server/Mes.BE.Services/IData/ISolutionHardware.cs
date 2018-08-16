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
        SearchResult SearchSolutionHardware(Sender sender, SearchSolution2HardwareArgs args);
        [OperationContract]
        void DeleteSolution2HardwareBySolutionID(Sender sender, Guid SolutionID);
        [OperationContract]
        void DeleteSolution2HardwareByCabinetID(Sender sender, Guid CabinetID);
        [OperationContract]
        void SaveSolution2Hardware(Sender sender, Solution2Hardware item);
    }
}
