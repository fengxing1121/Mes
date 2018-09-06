using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [ComponentMaterial]组件物料（某一种组件所包含的所有物料...）
    /// </summary>
    [Serializable]
    [DataContract(Name = "ComponentMaterial")]
    public class ComponentMaterial
    {
        public ComponentMaterial()
        {

        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "ID")]
        public int ID { set; get; }

        /// <summary>
        ///组件ID、物料分类
        /// </summary>
        [DataMember(Name = "ComponentID")]
        public int ComponentID { set; get; }

        /// <summary>
        ///物料编码
        /// </summary>
        [DataMember(Name = "MaterialCode")]
        public string MaterialCode { set; get; }

        /// <summary>
        ///物料名称
        /// </summary>
        [DataMember(Name = "MaterialName")]
        public string MaterialName { set; get; }

        /// <summary>
        ///规格型号
        /// </summary>
        [DataMember(Name = "Specification")]
        public string Specification { set; get; }

        /// <summary>
        ///单位
        /// </summary>
        [DataMember(Name = "Unit")]
        public string Unit { set; get; }

        [DataMember(Name = "Amount")]
        public decimal Amount { set; get; }

        /// <summary>
        ///数量、用量
        /// </summary>
        [DataMember(Name = "Quantity")]
        public decimal Quantity { set; get; }

        /// <summary>
        ///板件名称
        /// </summary>
        [DataMember(Name = "PlateName")]
        public string PlateName { set; get; }

        /// <summary>
        ///材质
        /// </summary>
        [DataMember(Name = "Material")]
        public string Material { set; get; }

        /// <summary>
        ///颜色
        /// </summary>
        [DataMember(Name = "Color")]
        public string Color { set; get; }

        /// <summary>
        ///长
        /// </summary>
        [DataMember(Name = "Length")]
        public string Length { set; get; }

        /// <summary>
        ///宽
        /// </summary>
        [DataMember(Name = "Width")]
        public string Width { set; get; }

        /// <summary>
        ///高
        /// </summary>
        [DataMember(Name = "Height")]
        public string Height { set; get; }

        /// <summary>
        ///开料长
        /// </summary>
        [DataMember(Name = "CutLength")]
        public string CutLength { set; get; }

        /// <summary>
        ///开料宽
        /// </summary>
        [DataMember(Name = "CutWidth")]
        public string CutWidth { set; get; }

        /// <summary>
        ///开料高
        /// </summary>
        [DataMember(Name = "CutHeight")]
        public string CutHeight { set; get; }

        /// <summary>
        ///开料面积
        /// </summary>
        [DataMember(Name = "CutArea")]
        public string CutArea { set; get; }

        /// <summary>
        ///前封边
        /// </summary>
        [DataMember(Name = "EdgeFront")]
        public string EdgeFront { set; get; }

        /// <summary>
        ///后封边
        /// </summary>
        [DataMember(Name = "EdgeBack")]
        public string EdgeBack { set; get; }

        /// <summary>
        ///左封边
        /// </summary>
        [DataMember(Name = "EdgeLeft")]
        public string EdgeLeft { set; get; }

        /// <summary>
        ///右封边
        /// </summary>
        [DataMember(Name = "EdgeRight")]
        public string EdgeRight { set; get; }

        /// <summary>
        ///纹理
        /// </summary>
        [DataMember(Name = "Veins")]
        public string Veins { set; get; }

        /// <summary>
        ///工艺路线
        /// </summary>
        [DataMember(Name = "Routing")]
        public string Routing { set; get; }

        /// <summary>
        ///是否需要优化
        /// </summary>
        [DataMember(Name = "IsOptimization")]
        public bool IsOptimization { set; get; }

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

        /// <summary>
        /// 扩展字段实体类
        /// </summary>
        [DataMember(Name = "ExtensionModel")]
        public ComponentMaterialExtension ExtensionModel { set; get; }
    }
}