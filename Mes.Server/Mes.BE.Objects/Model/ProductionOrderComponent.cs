using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [BE_ProductionOrderComponent]生产订单和产品组件关联表
    /// </summary>
    [Serializable]
    [DataContract(Name = "ProductionOrderComponent")]
    public class ProductionOrderComponent
    {
        public ProductionOrderComponent()
        {

        }

        /// <summary>
        ///生产订单ID
        /// </summary>
        [DataMember(Name = "ProductionID")]
        public Guid ProductionID { set; get; }

        /// <summary>
        ///产品组件ID
        /// </summary>
        [DataMember(Name = "ComponentID")]
        public int ComponentID { set; get; }

    }
}

