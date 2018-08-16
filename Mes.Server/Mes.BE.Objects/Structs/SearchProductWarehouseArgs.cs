using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchProductWarehouseMainArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        
        public Guid? InID;
        public Guid? OrderID;        
        public string Address;      
        public string LinkMan;
        public string Mobile;
        public string OrderNo;
        public string CustomerName;
        public string BillNo;
	}
}
