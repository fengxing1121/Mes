using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchMaterial2SupplierArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        public List<Guid> MaterialIDs;
        
        public string MaterialCode;
        public string MaterialName;
        public List<string> Categorys;
        public List<string> SubCategorys;
        public string Color;
        public string Style;
        public int? Deepth;

        public Guid? SupplierID;
        public string SupplierCode;
        public string SupplierName;
    }
}
