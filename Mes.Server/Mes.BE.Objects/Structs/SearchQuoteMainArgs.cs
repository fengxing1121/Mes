using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchQuoteMainArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? QuoteID;
        public Guid? CustomerID;
        public string QuoteNo;
        public Guid? SolutionID;
        public Guid? PartnerID;
        public string CustomerName;
        public string SolutionName;
        public string SolutionCode;
        public string Status;
	}
}
