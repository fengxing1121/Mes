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
        ProductionSet GetProductionSet(Sender sender, Guid SetID);

        [OperationContract]
        List<ProductionSet> GetAllProductionSets(Sender sender);

        [OperationContract]
        List<ProductionSet> GetProductionSetBySetID(Sender sender, Guid SetID);

        [OperationContract]
        SearchResult SearchProductionSet(Sender sender, SearchProductionSetArgs args);

        [OperationContract]
        void SaveProductionSet(Sender sender, ProductionSet obj);

        [OperationContract]
        void SaveProductionSets(Sender sender, SaveProductionSetArgs args);

        [OperationContract]
        bool ExistsProductionSetDayDetailByDatetime(DateTime Started, DateTime Ended);

        [OperationContract]
        SearchResult SearchProductionSetDayDetail(Sender sender, SearchProductionSetDayDetailArgs args);

        [OperationContract]
        ProductionSetDayDetail GetProductionSetDayDetailByMadeTotalAreal(Sender sender, decimal MadeTotalAreal);
    }
}

