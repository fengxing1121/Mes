using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchProductComponentArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        public int ComponentID;
        public string ComponentCode;
        public string ProductCode;
        public int ComponentTypeID;
        public string ComponentTypeName;
        public decimal Quantity;
        public decimal Amount;
        public bool Status;
        public DateTime Created;
        public DateTime CreatedBy;
        public DateTime Modified;
        public string ModifiedBy;
    }
}