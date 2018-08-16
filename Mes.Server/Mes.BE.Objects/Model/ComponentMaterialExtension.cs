using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [ComponentMaterialExtension]组件物料属性扩展（对表ComponentMaterial字段进行扩展，额外的，不必需的一类...）
    /// </summary>
    [Serializable]
    [DataContract(Name = "ComponentMaterialExtension")]
    public class ComponentMaterialExtension
    {
        public ComponentMaterialExtension()
        {

        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "ID")]
        public int ID { set; get; }

        /// <summary>
        ///组件物料ID
        /// </summary>
        [DataMember(Name = "ComponentMaterialID")]
        public int ComponentMaterialID { set; get; }

        /// <summary>
        ///外部条码
        /// </summary>
        [DataMember(Name = "Barcode")]
        public string Barcode { set; get; }

        /// <summary>
        ///输出名称
        /// </summary>
        [DataMember(Name = "OutputName")]
        public string OutputName { set; get; }

        /// <summary>
        ///A面孔
        /// </summary>
        [DataMember(Name = "MprA")]
        public string MprA { set; get; }

        /// <summary>
        ///B面孔
        /// </summary>
        [DataMember(Name = "MprB")]
        public string MprB { set; get; }

        /// <summary>
        ///机器文件、加工程序
        /// </summary>
        [DataMember(Name = "MachineFile")]
        public string MachineFile { set; get; }

        /// <summary>
        ///备注信息
        /// </summary>
        [DataMember(Name = "Remark")]
        public string Remark { set; get; }

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