using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchWarehouseArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        
        public Guid? WarehouseID;
        public Guid? MaterialID;
        public Guid? LocationID;     
        public string CabinetNum;
        public List<string> Categorys;
        public List<string> SubCategorys;
        public string LocationCode;
        public string LayerNum;
        public bool? IsDisabled;
        public string MaterialCode;
        public string MaterialName;        
        public string Color;
        public string Style;
        public int? Deepth;
	}
}
