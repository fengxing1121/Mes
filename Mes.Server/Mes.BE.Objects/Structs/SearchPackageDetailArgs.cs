using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchPackageDetailArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

    
        public Guid? OrderID;
        public string OrderNo;
        public Guid? PackageID;
        public Guid? CabinetID;
        public string BattchNo;
        public string Barcode;
        public string PackageBarcode;
        public int? PackageNum;
        public string CabinetName;
        public Guid? CustomerID;
        public string CustomerName;
        public bool? IsPackaged;
        public bool? IsOptimized;
        public bool? IsPlanning;
        public bool? IsDisabled;
        public bool? IsPakaged;
        public bool? IsStandard;
        public bool? IsOutsourcing;
        public string CabinetCode;
        public string OutOrderNo;
        public string ItemCategory;
        public string MaterialType;
        public string ItemName;
        public string ItemType;
        public string PackageSizeType;
        public string PackageCategory;
        public bool? IsSpecialShap;
    }
}
