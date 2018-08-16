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
        void SaveRoomDesignerKJLRelation(Sender sender, SaveRoomDesignerKJLRelationArgs args);
        [OperationContract]
        bool ExistsRoomDesignerKJLRelatioByDesignerNo(Sender sender, int designerNo);
        [OperationContract]
        RoomDesignerKJLRelation LoadRoomDesignerKJLRelatioByDesignID(Sender sender, SaveRoomDesignerKJLRelationArgs args);
    }
}
