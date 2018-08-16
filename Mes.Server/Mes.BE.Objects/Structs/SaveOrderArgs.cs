using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SaveOrderArgs
    {
        public Order Order;
        public List<OrderDetail> OrderDetails;
        public OrderLog OrderLog;
        //public OrderStep OrderStep;
        //public OrderResource OrderResource;
        public List<OrderProcessFile> OrderProcessFiles;
        public List<OrderProduct> OrderProducts;
        public List<OrderWorkFlow> OrderWorkFlows;
        public List<Order2Hardware> Order2Hardwares;
        public List<OrderScheduling> OrderSchedulings;
        public List<WorkCenterScheduling> WorkCenterSchedulings;
        public List<PackageDetail> PackageDetails;
        public List<Cabinet2Door> Cabinet2Doors;
        public OrderStepLog OrderStepLog;        
    }
}
