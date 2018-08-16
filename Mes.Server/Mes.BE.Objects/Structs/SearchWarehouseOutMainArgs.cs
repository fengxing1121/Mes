using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchWarehouseOutMainArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? OutID;
        public string BillNo;       
        public DateTime? CheckOutDateFrom;
        public DateTime? CheckOutDateTo;
        public string HandlerMan;
        public Guid? WorkShopID;
        public string WorkShopName;
        
    }
}
