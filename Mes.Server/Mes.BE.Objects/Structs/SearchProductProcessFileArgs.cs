using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchProductProcessFileArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;
        public Guid? ProductID;
        
        public Guid? CategoryID;
        public string ProductCode;
        public string ProductName;
        public string CategoryName;
        public string Color;
        public string MaterialStyle;
        public string MaterialCategory;
        public string Size;
        public decimal? MinPrice;
        public decimal? MaxPrice;
        public Guid? ItemID;
        public string FileType;
        public string Tag;
	}
}
