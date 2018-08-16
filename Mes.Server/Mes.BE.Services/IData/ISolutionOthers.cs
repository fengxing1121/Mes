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
        SolutionOthers GetSolutionOthers(Sender sender, Guid DetailID);
        [OperationContract]
        List<SolutionOthers> GetSolutionOthersByCabinetGroup(Sender sender, Guid SolutionID, string CabinetGroup);
        [OperationContract]
        List<SolutionOthers> GetSolutionOthersBySolutionID(Sender sender, Guid SolutionID);
        [OperationContract]
        void SaveSolutionOthers(Sender sender, SaveSolutionOthersArgs args);
        [OperationContract]
        void DeleteSolutionOthers(Sender sender, Guid DetailID);
        [OperationContract]
        SearchResult SearchSolutionOthers(Sender sender, SearchSolutionOthersArgs args);

    }
}
