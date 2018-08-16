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
        void SaveCar(Sender sender, SaveCarArgs args);
        [OperationContract]
        Car GetCar(Sender sender, Guid CarID);
        [OperationContract]
        SearchResult SearchCar(Sender sender, SearchCarArgs args);
    }
}
