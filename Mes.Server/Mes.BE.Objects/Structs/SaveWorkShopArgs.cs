using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SaveWorkShopArgs
    {
        public WorkShop WorkShop;
        public List<Guid> WorkShiftIDs;
    }
}
