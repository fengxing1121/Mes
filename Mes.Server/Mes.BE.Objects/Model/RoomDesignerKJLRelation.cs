using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
    [Serializable]
    [DataContract(Name = "RoomDesignerKJLRelation")]
    public class RoomDesignerKJLRelation
    {
        public RoomDesignerKJLRelation()
        {
        }

        [DataMember(Name = "ID")]
        public Guid ID { get; set; }

        [DataMember(Name = "DesignerNo")]
        public int DesignerNo { get; set; }

        [DataMember(Name = "KJLDesignID")]
        public string KJLDesignID { get; set; }

        [DataMember(Name = "Status")]
        public bool Status { get; set; }

        [DataMember(Name = "Created")]
        public DateTime Created { get; set; }

        [DataMember(Name = "CreatedBy")]
        public string CreatedBy { get; set; }
    }
}
