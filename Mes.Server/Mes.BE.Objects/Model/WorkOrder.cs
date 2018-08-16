using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [BE_WorkOrder]工单
    /// </summary>
    [Serializable]
    [DataContract(Name = "WorkOrder")]
    public class WorkOrder
    {
        public WorkOrder()
        {

        }

        /// <summary>
        ///工单ID
        /// </summary>
        [DataMember(Name = "WorkOrderID")]
        public Guid WorkOrderID { set; get; }

        /// <summary>
        ///工单编号
        /// </summary>
        [DataMember(Name = "WorkOrderNo")]
        public string WorkOrderNo { set; get; }

        /// <summary>
        ///订单编号
        /// </summary>
        [DataMember(Name = "OrderID")]
        public Guid OrderID { set; get; }

        /// <summary>
        ///生产订单号
        /// </summary>
        [DataMember(Name = "ProductionID")]
        public Guid ProductionID { set; get; }

        /// <summary>
        ///组件ID
        /// </summary>
        [DataMember(Name = "ComponentID")]
        public int ComponentID { set; get; }

        /// <summary>
        ///组件类型ID
        /// </summary>
        [DataMember(Name = "ComponentTypeID")]
        public int ComponentTypeID { set; get; }

        /// <summary>
        ///状态
        /// </summary>
        [DataMember(Name = "Status")]
        public string Status { set; get; }

        /// <summary>
        ///创建时间
        /// </summary>
        [DataMember(Name = "Created")]
        public DateTime Created { set; get; }

        /// <summary>
        ///创建人
        /// </summary>
        [DataMember(Name = "CreatedBy")]
        public string CreatedBy { set; get; }

    }
}

