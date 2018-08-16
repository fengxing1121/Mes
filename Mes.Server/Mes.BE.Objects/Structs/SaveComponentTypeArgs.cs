using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SaveComponentTypeArgs
    {
        public ComponentType ComponentType;
        public List<ComponentType> ComponentTypes;
    }
}

