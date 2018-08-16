using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [BE_ProduceOrder]数据模型
    /// </summary>
    [Serializable]
    [DataContract(Name = "ProductionOrder")]
    public class ProductionOrder
    {
        public ProductionOrder()
        {

        }

        /// <summary>
        ///生产订单ID
        /// </summary>
        [DataMember(Name = "ProductionID")]
        public Guid ProductionID { set; get; }

        /// <summary>
        ///生产订单号
        /// </summary>
        [DataMember(Name = "ProduceNo")]
        public string ProduceNo { set; get; }

        /// <summary>
        ///销售订单ID
        /// </summary>
        [DataMember(Name = "OrderID")]
        public Guid OrderID { set; get; }

        /// <summary>
        ///销售订单号
        /// </summary>
        [DataMember(Name = "OrderNo")]
        public string OrderNo { set; get; }

        /// <summary>
        ///预计完工日期
        /// </summary>
        [DataMember(Name = "FinishDate")]
        public DateTime FinishDate { set; get; }

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

        /// <summary>
        ///状态（N未排单 Y 已排单）
        /// </summary>
        [DataMember(Name = "Status")]
        public string Status { set; get; }
    }
}

