using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchSupplierArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        
        public List<Guid> SupplierIDs;
        public string SupplierCode;
        public string SupplierName;
        public string Category;
        public string Mobile;
        public string Tel;   
        public string Address;
        public string LinkMan;
        public string Province;
        public string City;       
	}
}
