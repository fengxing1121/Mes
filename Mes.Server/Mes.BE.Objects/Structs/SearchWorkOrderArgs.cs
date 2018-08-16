using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchWorkOrderArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        public Guid WorkOrderID;
        public string WorkOrderNo;
        public Guid OrderID;
        public Guid ProductionID;
        public string Status;
        public DateTime Created;
        public string CreatedBy;
    }
}

