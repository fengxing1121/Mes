using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SaveRoomDesignerArgs
    {
        public RoomDesigner RoomDesigner;
        public List<RoomDesignerFile> RoomDesignerFiles;
    }
}
