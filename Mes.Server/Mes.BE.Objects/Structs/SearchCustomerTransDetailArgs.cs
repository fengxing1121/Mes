using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchCustomerTransDetailArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? TransID;
        public Guid? QuoteID;
        public Guid? CustomerID;
        public string QuoteNo;       
        public Guid? PartnerID;
        public string CustomerName;
        public string Mobile;
        public string LinkMan;
        public string VoucherNo;
        public DateTime? TransDateFrom;
        public DateTime? TransDateTo;
        public string PartnerName;
        public string PartnerCode;
       
	}
}
