using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SaveComponentMaterialArgs
    {
        public ComponentMaterial ComponentMaterial;
        public List<ComponentMaterial> ComponentMaterials;
    }
}

