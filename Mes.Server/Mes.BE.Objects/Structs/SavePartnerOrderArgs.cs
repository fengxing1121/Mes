using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SavePartnerOrderArgs
    {
        public PartnerOrder Order;
        
        public List<PartnerOrderProduct> PartnerOrderProducts;

        public OrderStepLog OrderStepLog;

        public OrderLog OrderLog;

    }
}
