using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [BE_ProductionSet]生产订单排单设置主表
    /// </summary>
    [Serializable]
    [DataContract(Name = "ProductionSet")]
    public class ProductionSet
    {
        public ProductionSet()
        {

        }

        /// <summary>
        ///序号
        /// </summary>
        [DataMember(Name = "SetID")]
        public Guid SetID { set; get; }

        /// <summary>
        ///开始日期
        /// </summary>
        [DataMember(Name = "Started")]
        public DateTime Started { set; get; }

        /// <summary>
        ///截止日期
        /// </summary>
        [DataMember(Name = "Ended")]
        public DateTime Ended { set; get; }

        /// <summary>
        ///区段总计有多少周
        /// </summary>
        [DataMember(Name = "Weeks")]
        public int Weeks { set; get; }

        /// <summary>
        ///工作日(天)
        /// </summary>
        [DataMember(Name = "Days")]
        public int Days { set; get; }

        /// <summary>
        ///总排单量
        /// </summary>
        [DataMember(Name = "TotalAreal")]
        public decimal TotalAreal { set; get; }

        /// <summary>
        ///处理时间
        /// </summary>
        [DataMember(Name = "Created")]
        public DateTime Created { set; get; }

        /// <summary>
        ///处理人
        /// </summary>
        [DataMember(Name = "CreatedBy")]
        public string CreatedBy { set; get; }

    }
}

