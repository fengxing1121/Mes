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
        void SaveSolutionFile(Sender sender, SaveSolutionFileArgs args);
        [OperationContract]
        SolutionFile GetSolutionFile(Sender sender, Guid FileID);
        [OperationContract]
        SolutionFile GetSolutionFileBySourceID(Sender sender, Guid SourceID);
        [OperationContract]
        void DeleteSolutionFile(Sender sender, Guid FileID);
        [OperationContract]
        SearchResult SearchSolutionFile(Sender sender, SearchSolutionFileArgs args);
    }
}
