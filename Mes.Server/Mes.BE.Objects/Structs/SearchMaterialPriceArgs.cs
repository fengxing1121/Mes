using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchMaterialPriceArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        
        public List<Guid> MaterialIDs;
        public string MaterialCode;
        public string MaterialName;
        public string Category;
        public string SubCategory;
        public string Color;
        public string Style;
        public int? Deepth;
    }
}
