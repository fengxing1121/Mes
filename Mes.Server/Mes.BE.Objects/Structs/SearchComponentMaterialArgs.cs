using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchComponentMaterialArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        public int ID;
        public int ComponentID;
        public string MaterialCode;
        public string MaterialName;
        public string Specification;
        public string Unit;
        public decimal Quantity;
        public string PlateName;
        public string Material;
        public string Color;
        public string Length;
        public string Width;
        public string Height;
        public string CutLength;
        public string CutWidth;
        public string CutHeight;
        public string CutArea;
        public string EdgeFront;
        public string EdgeBack;
        public string EdgeLeft;
        public string EdgeRight;
        public string Veins;
        public string Routing;
        public bool IsOptimization;
        public bool Status;
        public DateTime Created;
        public DateTime CreatedBy;
        public DateTime Modified;
        public string ModifiedBy;
    }
}