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
        void SaveOrder2Hardware(Sender sender, SaveOrder2HardwareArgs args);
        [OperationContract]
        Order2Hardware GetOrder2Hardware(Sender sender, Guid ItemID);
        [OperationContract]
        List<Order2Hardware> GetOrder2HardwaresByOrderID(Sender sender, Guid OrderID);
        [OperationContract]
        List<Order2Hardware> GetOrder2HardwaresByOrderID_CabinetID(Sender sender, Guid OrderID, Guid CabinetID);
        [OperationContract]
        SearchResult SearchOrder2Hardware(Sender sender, SearchOrder2HardwareArgs args);
        [OperationContract]
        void DeleteOrder2HardwareByCabinetID(Sender sender, Guid CabinetID);
        [OperationContract]
        void DeleteOrder2HardwareByOrderID(Sender sender, Guid OrderID);
    }
}
