using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchCustomerFollowUpArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? CustomerID;        
        public string CustomerName;
        public Guid? PartnerID;
        public string PartnerName;
        public string FollowType;
        public string Title;
	}
}
