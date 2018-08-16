using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [BE_ProductionOrderScheduling]生产订单排单
    /// </summary>
    [Serializable]
    [DataContract(Name = "ProductionOrderScheduling")]
    public class ProductionOrderScheduling
    {
        public ProductionOrderScheduling()
        {

        }

        /// <summary>
        ///主键
        /// </summary>
        [DataMember(Name = "SchedulingID")]
        public Guid SchedulingID { set; get; }

        /// <summary>
        ///订单ID
        /// </summary>
        [DataMember(Name = "OrderID")]
        public Guid OrderID { set; get; }

        /// <summary>
        ///生产订单ID
        /// </summary>
        [DataMember(Name = "ProductionID")]
        public Guid ProductionID { set; get; }

        /// <summary>
        ///生产订单排单设置日计划详情表ID
        /// </summary>
        [DataMember(Name = "DaysDetailID")]
        public Guid DaysDetailID { set; get; }

        /// <summary>
        ///生产订单总面积
        /// </summary>
        [DataMember(Name = "TotalAreal")]
        public decimal TotalAreal { set; get; }

        /// <summary>
        ///排单日期
        /// </summary>
        [DataMember(Name = "Created")]
        public DateTime Created { set; get; }

        /// <summary>
        ///操作人
        /// </summary>
        [DataMember(Name = "CreatedBy")]
        public string CreatedBy { set; get; }

    }
}

