using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchComponentMaterialExtensionArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        public int ID;
        public int ComponentMaterialID;
        public string Barcode;
        public string OutputName;
        public string MprA;
        public string MprB;
        public string MachineFile;
        public string Remark;
    }
}