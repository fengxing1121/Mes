using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// 代码工具生成，不可以手工修改。2017-05-17 15:24:57。
    /// </summary>
    [Serializable]
    [DataContract(Name = "Order2Cabinet")]
    public class Order2Cabinet
    {
        public Order2Cabinet()
        {
        }

        /// <summary>
        ///产品ID
        /// </summary>
        [DataMember(Name = "CabinetID")]
        public Guid CabinetID
        {
            get;
            set;
        }
        /// <summary>
        ///产品组号
        /// </summary>
        [DataMember(Name = "CabinetGroup")]
        public string CabinetGroup { get; set; }

        /// <summary>
        ///订单ID
        /// </summary>
        [DataMember(Name = "OrderID")]
        public Guid OrderID
        {
            get;
            set;
        }

        /// <summary>
        ///产品编号
        /// </summary>
        [DataMember(Name = "CabinetCode")]
        public string CabinetCode
        {
            get;
            set;
        }

        /// <summary>
        ///产品名称
        /// </summary>
        [DataMember(Name = "CabinetName")]
        public string CabinetName
        {
            get;
            set;
        }

        /// <summary>
        ///成品尺寸
        /// </summary>
        [DataMember(Name = "Size")]
        public string Size
        {
            get;
            set;
        }

        /// <summary>
        ///主材料款式
        /// </summary>
        [DataMember(Name = "MaterialStyle")]
        public string MaterialStyle
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "MaterialCategory")]
        public string MaterialCategory
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "Color")]
        public string Color
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "Unit")]
        public string Unit
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "Qty")]
        public decimal Qty
        {
            get;
            set;
        }

        /// <summary>
        ///销售价格
        /// </summary>
        [DataMember(Name = "Price")]
        public decimal Price
        {
            get;
            set;
        }

        /// <summary>
        ///成本价格
        /// </summary>
        [DataMember(Name = "CostPrice")]
        public decimal CostPrice
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "DealerPrice")]
        public decimal DealerPrice
        {
            get;
            set;
        }

        /// <summary>
        ///板件总面积
        /// </summary>
        [DataMember(Name = "TotalAreal")]
        public decimal TotalAreal
        {
            get;
            set;
        }

        /// <summary>
        ///板件总长度
        /// </summary>
        [DataMember(Name = "TotalLength")]
        public decimal TotalLength
        {
            get;
            set;
        }

        /// <summary>
        ///文件上传标志
        /// </summary>
        [DataMember(Name = "FileUploadFlag")]
        public bool FileUploadFlag
        {
            get;
            set;
        }

        /// <summary>
        ///是否预装
        /// </summary>
        [DataMember(Name = "IsTestAssemble")]
        public bool IsTestAssemble
        {
            get;
            set;
        }

        /// <summary>
        ///批次索引号
        /// </summary>
        [DataMember(Name = "BattchIndex")]
        public int BattchIndex
        {
            get;
            set;
        }

        /// <summary>
        ///序号
        /// </summary>
        [DataMember(Name = "Sequence")]
        public int Sequence
        {
            get;
            set;
        }

        /// <summary>
        ///状态
        /// </summary>
        [DataMember(Name = "CabinetStatus")]
        public string CabinetStatus
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "Remark")]
        public string Remark
        {
            get;
            set;
        }

        /// <summary>
        ///创建时间
        /// </summary>
        [DataMember(Name = "Created")]
        public DateTime Created
        {
            get;
            set;
        }

        /// <summary>
        ///创建人
        /// </summary>
        [DataMember(Name = "CreatedBy")]
        public string CreatedBy
        {
            get;
            set;
        }

        /// <summary>
        ///修改时间
        /// </summary>
        [DataMember(Name = "Modified")]
        public DateTime Modified
        {
            get;
            set;
        }

        /// <summary>
        ///修改人
        /// </summary>
        [DataMember(Name = "ModifiedBy")]
        public string ModifiedBy
        {
            get;
            set;
        }

        /// <summary>
        ///批次
        /// </summary>
        [DataMember(Name = "BattchCode")]
        public string BattchCode { get; set; }

    }
}
