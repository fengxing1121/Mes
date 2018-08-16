using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SaveProductionSetArgs
    {
        public ProductionSet ProductionSet;

        public List<ProductionSetDayDetail> ProductionSetDayDetails;

        public List<ProductionSetWeekDetail> ProductionSetWeekDetails;
    }
}

