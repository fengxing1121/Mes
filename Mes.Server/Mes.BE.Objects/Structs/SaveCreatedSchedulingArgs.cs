using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SaveCreatedSchedulingArgs
    {
        public string BattchCode;
        public List<Guid> CabinetIDs;
        public List<OrderWorkFlow> OrderWorkFlows;
        public List<OrderScheduling> OrderSchedulings;
        public List<WorkCenterScheduling> WorkCenterSchedulings;
        public List<PackageDetail> PackageDetails;
    }
}
