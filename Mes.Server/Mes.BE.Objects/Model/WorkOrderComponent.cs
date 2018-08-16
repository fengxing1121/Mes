using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [BE_WorkOrderComponent]工单和产品组件关联表
    /// </summary>
    [Serializable]
    [DataContract(Name = "WorkOrderComponent")]
    public class WorkOrderComponent
    {
        public WorkOrderComponent()
        {

        }

        /// <summary>
        ///工单ID
        /// </summary>
        [DataMember(Name = "WorkOrderID")]
        public Guid WorkOrderID { set; get; }

        /// <summary>
        ///组件ID
        /// </summary>
        [DataMember(Name = "ComponentID")]
        public int ComponentID { set; get; }

    }
}

