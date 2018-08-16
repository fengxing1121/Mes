using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchOrderArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        
        public List<Guid> OrderIDs;
        public string OrderNo;
        public List<string> OrderTypes;
        public string Mobile;
        public string CustomerName;
        public string PartnerName;
        public Guid? CustomerID;
        public Guid? PartnerID;      
        public string Address;
        public string BattchNo;
        public DateTime? BookingDateFrom;
        public DateTime? BookingDateTo;
        public DateTime? ShipDateFrom;
        public DateTime? ShipDateTo;
        public List<string> Status;
        public string Resource;
        public string StepNo;
        public string PurchaseNo;
        public bool? IsStandard;
        public bool? IsOutsourcing;
        public string CabinetType;
        public string OutOrderNo;

	}
}
