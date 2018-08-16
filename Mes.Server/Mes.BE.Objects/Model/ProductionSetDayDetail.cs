using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [BE_ProductionSetDayDetail]生产订单排单设置日计划详情表
    /// </summary>
    [Serializable]
    [DataContract(Name = "ProductionSetDayDetail")]
    public class ProductionSetDayDetail
    {
        public ProductionSetDayDetail()
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
        ///日期
        /// </summary>
        [DataMember(Name = "Datetime")]
        public DateTime Datetime { set; get; }

        /// <summary>
        ///当天预计排单量
        /// </summary>
        [DataMember(Name = "TotalAreal")]
        public decimal TotalAreal { set; get; }

        /// <summary>
        ///当天实际排已单量
        /// </summary>
        [DataMember(Name = "MadeTotalAreal")]
        public decimal MadeTotalAreal { set; get; }

        /// <summary>
        ///当天第几周
        /// </summary>
        [DataMember(Name = "WeekNo")]
        public int WeekNo { set; get; }

    }
}

