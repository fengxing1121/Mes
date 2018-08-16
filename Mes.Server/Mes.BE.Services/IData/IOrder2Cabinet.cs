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
        void UpdateOrder2CabinetStatusByBattchCode(string BattchCode, string CabinetStatus);
        [OperationContract]
        void SaveOrder2Cabinet(Sender sender, SaveOrder2CabinetArgs args);
        [OperationContract]
        Order2Cabinet GetOrder2Cabinet(Sender sender, Guid CabinetID);
        [OperationContract]
        Order2Cabinet GetOrder2CabinetByOrderID_CabinetName(Sender sender, Guid OrderID, string CabinetName);
        [OperationContract]
        List<Order2Cabinet> GetOrder2CabinetByOrderID(Sender sender, Guid OrderID);
        [OperationContract]
        SearchResult SearchOrder2Cabinet(Sender sender, SearchOrder2CabinetArgs args);
        [OperationContract]
        SearchResult SearchPrintCabinetData(Sender sender, string BarcodeNo);
        [OperationContract]
        int UpdateCabinetStatus(Order2Cabinet obj, OprationType Opration, Sender sender);
        [OperationContract]
        void DeleteOrder2CabinetByCabinetID(Sender sender, Guid CabinetID);
        [OperationContract]
        void DeleteOrder2CabinetByOrderID(Sender sender, Guid OrderID);
        [OperationContract]
        int GetTotalOrderCabinetQty(Sender sender, Guid OrderID);
    }
}
