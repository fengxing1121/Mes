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
        Cabinet2Door GetCabinet2Door(Sender sender, Guid DoorID);
        [OperationContract]
        List<Cabinet2Door> GetCabinet2DoorByCabinetID(Sender sender, Guid CabinetID);
        [OperationContract]
        void SaveCabinet2Door(Sender sender, SaveCabinet2DoorArgs args);
        [OperationContract]
        void DeleteCabinet2Door(Sender sender, Guid DoorID);
        [OperationContract]
        SearchResult SearchCabinet2Door(Sender sender, SearchCabinet2DoorArgs args);
    }
}
