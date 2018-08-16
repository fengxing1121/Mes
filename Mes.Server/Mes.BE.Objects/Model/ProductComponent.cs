using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [ProductComponent]产品组件（产品1包含柜体、门、五金...）
    /// </summary>
    [Serializable]
    [DataContract(Name = "ProductComponent")]
    public class ProductComponent
    {
        public ProductComponent()
        {

        }

        /// <summary>
        ///组件ID
        /// </summary>
        [DataMember(Name = "ComponentID")]
        public int ComponentID { set; get; }

        /// <summary>
        ///组件编码
        /// </summary>
        [DataMember(Name = "ComponentCode")]
        public string ComponentCode { set; get; }

        /// <summary>
        ///产品编码
        /// </summary>
        [DataMember(Name = "ProductCode")]
        public string ProductCode { set; get; }

        /// <summary>
        ///组件类型ID
        /// </summary>
        [DataMember(Name = "ComponentTypeID")]
        public int ComponentTypeID { set; get; }

        /// <summary>
        ///组件类型名称
        /// </summary>
        [DataMember(Name = "ComponentTypeName")]
        public string ComponentTypeName { set; get; }

        /// <summary>
        ///该组件类型下所有物料数量
        /// </summary>
        [DataMember(Name = "Quantity")]
        public decimal Quantity { set; get; }

        /// <summary>
        ///该组件类型下物料的面积和
        /// </summary>
        [DataMember(Name = "Amount")]
        public decimal Amount { set; get; }

        /// <summary>
        ///状态
        /// </summary>
        [DataMember(Name = "Status")]
        public bool Status { set; get; }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "Created")]
        public DateTime Created { set; get; }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "CreatedBy")]
        public string CreatedBy { set; get; }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "Modified")]
        public DateTime Modified { set; get; }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "ModifiedBy")]
        public string ModifiedBy { set; get; }

    }
}