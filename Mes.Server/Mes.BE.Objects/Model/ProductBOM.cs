using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [ProductBOM]产品与BOM对照表
    /// </summary>
    [Serializable]
    [DataContract(Name = "ProductBOM")]
    public class ProductBOM
    {
        public ProductBOM()
        {

        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "ID")]
        public int ID { set; get; }

        /// <summary>
        ///BOM编码
        /// </summary>
        [DataMember(Name = "BOMID")]
        public string BOMID { set; get; }

        /// <summary>
        ///产品编码
        /// </summary>
        [DataMember(Name = "ProductCode")]
        public string ProductCode { set; get; }

        /// <summary>
        ///产品名称
        /// </summary>
        [DataMember(Name = "ProductName")]
        public string ProductName { set; get; }

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

    }
}
