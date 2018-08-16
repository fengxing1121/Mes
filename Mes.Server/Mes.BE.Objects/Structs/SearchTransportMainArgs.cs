using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchTransportMainArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? TransportID;
        
        public string EnterpriseName;
        public string Address;
        public string LinkMan;
        public string PlateNo;
        public string DriverName;
        public string TransportNo;
	}
}
