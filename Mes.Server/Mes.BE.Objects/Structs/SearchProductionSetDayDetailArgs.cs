using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchProductionSetDayDetailArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        public Guid ID;
        public Guid SetID;
        public DateTime Datetime;
        public double TotalAreal;
        public double MadeTotalAreal;
        public int WeekNo;
    }
}

