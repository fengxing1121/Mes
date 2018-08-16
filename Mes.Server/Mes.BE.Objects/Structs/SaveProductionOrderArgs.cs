using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SaveProductionOrderArgs
    {
        public ProductionOrder ProductionOrder;
        public List<ProductionOrderComponent> ProductionOrderComponents;
    }

    [Serializable]
    public struct SchedulingProductionOrderArgs
    {
        public ProductionOrderScheduling ProductionOrderScheduling;

        public ProductionOrder ProductionOrder;

        public ProductionSetDayDetail ProductionSetDayDetail;

        public OrderStepLog OrderStepLog;
    }
}

