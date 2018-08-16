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
        void SaveRoomDesignerFile(Sender sender, SaveRoomDesignerFileArgs args);
        [OperationContract]
        RoomDesignerFile GetRoomDesignerFile(Sender sender, Guid FileID);
        [OperationContract]
        List<RoomDesignerFile> GetRoomDesignerFilesByDesignerID(Sender sender, Guid DesignerID);
    }
}
