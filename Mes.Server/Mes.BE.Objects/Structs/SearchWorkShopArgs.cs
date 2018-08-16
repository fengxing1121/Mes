using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchWorkShopArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        
        public Guid? WorkShopID;
        public string WorkShopCode;
        public string WorkShopName;
        public Guid? WorkingLineID;
        public string WorkingLineName;
	}
}
