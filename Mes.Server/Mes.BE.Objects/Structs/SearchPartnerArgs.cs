using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchPartnerArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        
        public List<Guid> PartnerIDs;
        public string PartnerCode;
        public string PartnerName;
        public string Mobile;
        public string Tel;
        public string Fax;
        public string Address;
        public string LinkMan;      
        public string Province;
        public string City;       
	}
}
