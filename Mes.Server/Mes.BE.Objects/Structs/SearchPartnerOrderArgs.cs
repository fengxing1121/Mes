using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchPartnerOrderArgs
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
        public DateTime? BookingDateFrom;
        public DateTime? BookingDateTo;
        public DateTime? ShipDateFrom;
        public DateTime? ShipDateTo;
        public List<string> Status;
        public string Resource;
        public string OutOrderNo;
        public string StepNo;

    }
}
