using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchTransportDetailArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? TransportID;
        public Guid? OrderID;
        
        public string EnterpriseName;
        public string CustomerAddress;
        public string EnterpriseAddress;
        public string LinkMan;
        public string PlateNo;
        public string DriverName;
        public string TransportNo;
        public string OrderNo;
        public string CustomerName;   
  
        
	}
}
