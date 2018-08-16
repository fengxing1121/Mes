using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchProductWarehouseDetailArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        
        public Guid? InID;
        public Guid? DetailID;
        public Guid? OrderID;
        public string Address;
        public string LinkMan;
        public string Mobile;
        public string OrderNo;
        public string CustomerName;
        public string BillNo;
        public Guid? PackageID;
        public string PackageNum;
        public string PackageBarcode;       
	}
}
