using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [BE_OrderProduct]数据模型
    /// </summary>
    [Serializable]
    [DataContract(Name = "OrderProduct")]
    public class OrderProduct
    {
        public OrderProduct()
        {

        }

        /// <summary>
        ///产品ID
        /// </summary>
        [DataMember(Name = "ProductID")]
        public Guid ProductID { set; get; }

        /// <summary>
        ///订单ID
        /// </summary>
        [DataMember(Name = "OrderID")]
        public Guid OrderID { set; get; }

        /// <summary>
        ///产品组号
        /// </summary>
        [DataMember(Name = "ProductGroup")]
        public string ProductGroup { set; get; }

        /// <summary>
        ///产品编号
        /// </summary>
        [DataMember(Name = "ProductCode")]
        public string ProductCode { set; get; }

        /// <summary>
        ///产品名称
        /// </summary>
        [DataMember(Name = "ProductName")]
        public string ProductName { set; get; }

        /// <summary>
        ///规格
        /// </summary>
        [DataMember(Name = "Size")]
        public string Size { set; get; }

        /// <summary>
        ///材质
        /// </summary>
        [DataMember(Name = "MaterialStyle")]
        public string MaterialStyle { set; get; }

        /// <summary>
        ///类型
        /// </summary>
        [DataMember(Name = "MaterialCategory")]
        public string MaterialCategory { set; get; }

        /// <summary>
        ///颜色
        /// </summary>
        [DataMember(Name = "Color")]
        public string Color { set; get; }

        /// <summary>
        ///单位
        /// </summary>
        [DataMember(Name = "Unit")]
        public string Unit { set; get; }

        /// <summary>
        ///数量
        /// </summary>
        [DataMember(Name = "Qty")]
        public decimal Qty { set; get; }

        /// <summary>
        ///价格
        /// </summary>
        [DataMember(Name = "Price")]
        public decimal Price { set; get; }

        /// <summary>
        ///报价
        /// </summary>
        [DataMember(Name = "SalePrice")]
        public decimal SalePrice { set; get; }

        /// <summary>
        ///总面积
        /// </summary>
        [DataMember(Name = "TotalAreal")]
        public decimal TotalAreal { set; get; }

        /// <summary>
        ///总长度
        /// </summary>
        [DataMember(Name = "TotalLength")]
        public decimal TotalLength { set; get; }

        /// <summary>
        ///批次号
        /// </summary>
        [DataMember(Name = "BattchCode")]
        public string BattchCode { set; get; }

        /// <summary>
        ///产品状态
        /// </summary>
        [DataMember(Name = "ProductStatus")]
        public string ProductStatus { set; get; }

        /// <summary>
        ///备注
        /// </summary>
        [DataMember(Name = "Remark")]
        public string Remark { set; get; }

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
        ///修改时间
        /// </summary>
        [DataMember(Name = "Modified")]
        public DateTime Modified { set; get; }

        /// <summary>
        ///修改人
        /// </summary>
        [DataMember(Name = "ModifiedBy")]
        public string ModifiedBy { set; get; }

    }
}

