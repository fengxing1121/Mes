using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [ComponentType]组件类型（柜体、门、五金...）
    /// </summary>
    [Serializable]
    [DataContract(Name = "ComponentType")]
    public class ComponentType
    {
        public ComponentType()
        {

        }

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
        ///组件类型编码(A、B、C)
        /// </summary>
        [DataMember(Name = "ComponentTypeCode")]
        public string ComponentTypeCode { set; get; }

        /// <summary>
        ///父节点
        /// </summary>
        [DataMember(Name = "ParentID")]
        public int ParentID { set; get; }

        /// <summary>
        ///状态(0禁用,1正常)
        /// </summary>
        [DataMember(Name = "Status")]
        public bool Status { set; get; }

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

    }
}