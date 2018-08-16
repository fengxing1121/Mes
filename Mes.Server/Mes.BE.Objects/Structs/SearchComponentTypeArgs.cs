using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchComponentTypeArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        public int ComponentTypeID;
        public string ComponentTypeName;
        public string ComponentTypeCode;
        public int ParentID;
        public bool Status;
        public DateTime Created;
        public string CreatedBy;
    }
}