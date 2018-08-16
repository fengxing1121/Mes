using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchProductionSetArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        public Guid SetID;
        public DateTime Started;
        public DateTime Ended;
        public int Weeks;
        public int Days;
        public decimal TotalAreal;
        public DateTime Created;
        public string CreatedBy;
    }
}

