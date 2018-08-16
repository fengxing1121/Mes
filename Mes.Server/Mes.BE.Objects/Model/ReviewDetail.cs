using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [BE_ReviewDetail]数据模型
    /// </summary>
    [Serializable]
    [DataContract(Name = "ReviewDetail")]
    public class ReviewDetail
    {
        public ReviewDetail()
        {

        }

        /// <summary>
        ///收款ID
        /// </summary>
        [DataMember(Name = "TransID")]
        public Guid TransID { set; get; }

        /// <summary>
        ///订单ID
        /// </summary>
        [DataMember(Name = "OrderID")]
        public Guid OrderID { set; get; }

        /// <summary>
        ///收款日期
        /// </summary>
        [DataMember(Name = "TransDate")]
        public DateTime TransDate { set; get; }

        /// <summary>
        ///收款金额
        /// </summary>
        [DataMember(Name = "Amount")]
        public decimal Amount { set; get; }

        /// <summary>
        ///凭证号
        /// </summary>
        [DataMember(Name = "VoucherNo")]
        public string VoucherNo { set; get; }

        /// <summary>
        ///收款人
        /// </summary>
        [DataMember(Name = "Payee")]
        public string Payee { set; get; }

        /// <summary>
        ///创建日期
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

