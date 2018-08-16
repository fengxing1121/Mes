using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchSMSLogArgs
    {
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

     
        public bool Status;
        public DateTime? CreatedFrom;
        public DateTime? CreatedTo;
	}
}
