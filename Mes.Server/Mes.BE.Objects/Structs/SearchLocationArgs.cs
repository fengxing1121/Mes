using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchLocationArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        
        public Guid? WarehouseID;
        public string CabinetNum;
        public string Category;
        public string LocationCode;
        public string LayerNum;
        public bool? IsDisabled;
        public bool? Flag;
	}
}
