using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchWarehouseInMainArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? InID;
        public string BillNo;
        public string SupplierCode;
        public string SupplierName;
        public Guid? SupplierID;
        public DateTime? CheckInDateFrom;
        public DateTime? CheckInDateTo;
        public string HandlerMan;

        
    }
}
