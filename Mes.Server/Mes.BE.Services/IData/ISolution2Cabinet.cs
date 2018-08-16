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
        Solution2Cabinet GetSolution2Cabinet(Sender sender, Guid CabinetID);
        [OperationContract]
        List<Solution2Cabinet> GetSolution2CabinetsBySolutionID(Sender sender, Guid SolutionID);
        [OperationContract]
        void SaveSolution2Cabinet(Sender sender, Solution2Cabinet item);
    }
}
