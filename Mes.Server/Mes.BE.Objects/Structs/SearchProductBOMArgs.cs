using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchProductBOMArgs
    {
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public string BOMID;
        public string ProductCode;
        public string ProductName;
        public bool? Status;
        public DateTime? CreatedFrom;
        public DateTime? CreatedTo;
    }
}
