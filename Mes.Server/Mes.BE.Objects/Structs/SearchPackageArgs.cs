using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchPackageArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

    
        public Guid? OrderID;
        public string OrderNo;
        public Guid? PackageID;
        public Guid? CabinetID;
        public string BattchNo;
        public string PackageBarcode;
        public int? PackageNum;
        public string CabinetName;
        public Guid? CustomerID;
        public string CustomerName;
        public string CabinetCode;
        public string OutOrderNo;
	}
}
