using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchOrderProductArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        public Guid ProductID;
        public Guid OrderID;
        public string ProductGroup;
        public string ProductCode;
        public string ProductName;
        public string Size;
        public string MaterialStyle;
        public string MaterialCategory;
        public string Color;
        public string Unit;
        public decimal Qty;
        public decimal Price;
        public decimal SalePrice;
        public decimal TotalAreal;
        public decimal TotalLength;
        public string BattchCode;
        public string ProductStatus;
        public string Remark;
        public DateTime Created;
        public string CreatedBy;
        public DateTime Modified;
        public string ModifiedBy;
    }
}

