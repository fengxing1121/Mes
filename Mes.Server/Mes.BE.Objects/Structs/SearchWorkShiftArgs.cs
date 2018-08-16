using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchWorkShiftArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        
        public Guid? WorkShiftID;
        public string WorkShiftCode;
        public string WorkShiftName;        
    }
}
