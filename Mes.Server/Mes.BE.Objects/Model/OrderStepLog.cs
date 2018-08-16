using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [BE_OrderStepLog]数据模型
    /// </summary>
    [Serializable]
    [DataContract(Name = "OrderStepLog")]
    public class OrderStepLog
    {
        public OrderStepLog()
        {

        }

        /// <summary>
        ///步骤ID
        /// </summary>
        [DataMember(Name = "StepID")]
        public Guid StepID { set; get; }

        /// <summary>
        ///订单ID
        /// </summary>
        [DataMember(Name = "OrderID")]
        public Guid OrderID { set; get; }

        /// <summary>
        ///节点ID
        /// </summary>
        [DataMember(Name = "StepNo")]
        public int StepNo { set; get; }

        /// <summary>
        ///节点名称
        /// </summary>
        [DataMember(Name = "StepName")]
        public string StepName { set; get; }

        /// <summary>
        ///处理人
        /// </summary>
        [DataMember(Name = "StartedBy")]
        public string StartedBy { set; get; }

        /// <summary>
        ///处理时间
        /// </summary>
        [DataMember(Name = "Started")]
        public DateTime Started { set; get; }

        /// <summary>
        ///备注
        /// </summary>
        [DataMember(Name = "Remark")]
        public string Remark { set; get; }

    }
}

