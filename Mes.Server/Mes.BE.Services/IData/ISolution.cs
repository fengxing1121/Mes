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
        Solution GetSolution(Sender sender, Guid SolutionID);
        [OperationContract]
        Solution GetSolutionByDesignerID(Sender sender, Guid DesignerID);
        [OperationContract]
        Solution GetSolutionBySolutionCode(Sender sender, string SolutionCode);
        [OperationContract]
        void SaveSolution(Sender sender, SaveSolutionArgs args);
        [OperationContract]
        SearchResult SearchSolution(Sender sender, SearchSolutionArgs args);

    }
}
