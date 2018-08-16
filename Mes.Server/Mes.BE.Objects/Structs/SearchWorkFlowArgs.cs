using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchWorkFlowArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        public Guid WorkFlowID;
        public string WorkFlowCode;
        public string WorkFlowName;
        public string ImageUrl;
        public string Remark;
        public DateTime Created;
        public string CreatedBy;
    }
}

