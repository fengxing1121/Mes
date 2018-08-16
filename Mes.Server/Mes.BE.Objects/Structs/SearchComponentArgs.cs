using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
    public struct SearchComponentArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public List<Guid> ComponentIDs;
        public string ProductCategory;
        public string ComponentCategory;
        public string ComponentNum;
        public string ComponentName;
        public string Style;
        public string Color;
        public string Model;
        public string DesignBy;
	}
}
