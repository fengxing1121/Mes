using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchWorkShift2WorkShopArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        public Guid CompanyID;
        public Guid? WorkShiftID;
        public string WorkShiftCode;
        public string WorkShiftName;
        public Guid? WorkShopID;
        public string WorkShopCode;
        public string WorkShopName;
    }
}
