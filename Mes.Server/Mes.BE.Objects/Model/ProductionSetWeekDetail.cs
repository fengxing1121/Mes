using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [BE_ProductionSetWeekDetail]生产订单排单设置周计划详情表
    /// </summary>
    [Serializable]
    [DataContract(Name = "ProductionSetWeekDetail")]
    public class ProductionSetWeekDetail
    {
        public ProductionSetWeekDetail()
        {

        }

        /// <summary>
        ///序号
        /// </summary>
        [DataMember(Name = "ID")]
        public Guid ID { set; get; }

        /// <summary>
        ///配置主表编号
        /// </summary>
        [DataMember(Name = "SetID")]
        public Guid SetID { set; get; }

        /// <summary>
        ///第几周
        /// </summary>
        [DataMember(Name = "WeekNo")]
        public int WeekNo { set; get; }

        /// <summary>
        ///生产比例
        /// </summary>
        [DataMember(Name = "MaxCapacity")]
        public decimal MaxCapacity { set; get; }

        /// <summary>
        ///每周总排单量
        /// </summary>
        [DataMember(Name = "TotalAreal")]
        public decimal TotalAreal { set; get; }

    }
}

