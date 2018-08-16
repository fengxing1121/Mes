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
        void SaveRoomDesigner(Sender sender, SaveRoomDesignerArgs args);
        [OperationContract]
        RoomDesigner GetRoomDesigner(Sender sender, Guid DesignerID);
        [OperationContract]
        bool ExistsRoomDesignersByDesignerNo(Sender sender, int designerNo);
        [OperationContract]
        List<RoomDesigner> GetRoomDesigners(Sender sender);
        [OperationContract]
        SearchResult SearchRoomDesigner(Sender sender, SearchRoomDesignerArgs args);
    }
}
