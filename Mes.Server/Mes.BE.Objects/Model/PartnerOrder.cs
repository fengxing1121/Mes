using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [BE_PartnerOrder]数据模型
    /// </summary>
    [Serializable]
    [DataContract(Name = "PartnerOrder")]
    public class PartnerOrder
    {
        public PartnerOrder()
        {

        }

        /// <summary>
        ///订单ID
        /// </summary>
        [DataMember(Name = "OrderID")]
        public Guid OrderID { set; get; }

        /// <summary>
        ///订单编号
        /// </summary>
        [DataMember(Name = "OrderNo")]
        public string OrderNo { set; get; }

        /// <summary>
        ///订单类型
        /// </summary>
        [DataMember(Name = "OrderType")]
        public string OrderType { set; get; }

        /// <summary>
        ///外部单号
        /// </summary>
        [DataMember(Name = "OutOrderNo")]
        public string OutOrderNo { set; get; }

        /// <summary>
        ///门店ID
        /// </summary>
        [DataMember(Name = "PartnerID")]
        public Guid PartnerID { set; get; }

        /// <summary>
        ///门店名称
        /// </summary>
        [DataMember(Name = "PartnerName")]
        public string PartnerName { set; get; }

        /// <summary>
        ///客户ID
        /// </summary>
        [DataMember(Name = "CustomerID")]
        public Guid CustomerID { set; get; }

        /// <summary>
        ///客户名称
        /// </summary>
        [DataMember(Name = "CustomerName")]
        public string CustomerName { set; get; }

        /// <summary>
        ///业务人员
        /// </summary>
        [DataMember(Name = "SalesMan")]
        public string SalesMan { set; get; }

        /// <summary>
        ///客户地址
        /// </summary>
        [DataMember(Name = "Address")]
        public string Address { set; get; }

        /// <summary>
        ///联系方式
        /// </summary>
        [DataMember(Name = "Mobile")]
        public string Mobile { set; get; }

        /// <summary>
        ///下单日期
        /// </summary>
        [DataMember(Name = "BookingDate")]
        public DateTime BookingDate { set; get; }

        /// <summary>
        ///交货日期
        /// </summary>
        [DataMember(Name = "ShipDate")]
        public DateTime ShipDate { set; get; }

        /// <summary>
        ///订单状态
        /// </summary>
        [DataMember(Name = "Status")]
        public string Status { set; get; }

        /// <summary>
        ///当前节点ID
        /// </summary>
        [DataMember(Name = "StepNo")]
        public int StepNo { set; get; }

        /// <summary>
        ///订单备注
        /// </summary>
        [DataMember(Name = "Remark")]
        public string Remark { set; get; }

        /// <summary>
        ///订单附件
        /// </summary>
        [DataMember(Name = "AttachmentFile")]
        public string AttachmentFile { set; get; }

        /// <summary>
        ///创建人
        /// </summary>
        [DataMember(Name = "Created")]
        public DateTime Created { set; get; }

        /// <summary>
        ///创建时间
        /// </summary>
        [DataMember(Name = "CreatedBy")]
        public string CreatedBy { set; get; }

        /// <summary>
        ///修改人
        /// </summary>
        [DataMember(Name = "Modified")]
        public DateTime Modified { set; get; }

        /// <summary>
        ///修改时间
        /// </summary>
        [DataMember(Name = "ModifiedBy")]
        public string ModifiedBy { set; get; }

    }
}

