using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchSolutionDetailArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;
       
        public Guid? SolutionID;
        public Guid? CabinetID;
        
        public string SolutionCode;
        public string SolutionName;
        public string CustomerName;       
        public string ItemName;
        public Guid? ItemID;
        public string BarcodeNo;
        public bool? IsSpecialShap;
        public string ItemType;
	}
}
