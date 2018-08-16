using System.Runtime.Serialization;

namespace Mes.Client.Utility
{
    public class ExcelColumName
    {
        /// <summary>
        /// 板件编号
        /// </summary>
        [DataMember(Name = "BarcodeNo")]
        public string BarcodeNo
        {
            get;
            set;
        }

        /// <summary>
        /// 材料名称
        /// </summary>
        [DataMember(Name = "ItemName")]
        public string ItemName
        {
            get;
            set;
        }

        /// <summary>
        ///颜色
        /// </summary>
        [DataMember(Name = "Color")]
        public string Color
        {
            get;
            set;
        }

        /// <summary>
        ///类型
        /// </summary>
        [DataMember(Name = "Model")]
        public string Model
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "MaterialCode")]
        public string MaterialCode
        {
            get;
            set;
        }

        /// <summary>
        ///材质名称
        /// </summary>
        [DataMember(Name = "Material")]
        public string MaterialName
        {
            get;
            set;
        }

        /// <summary>
        ///材料类型
        /// </summary>
        [DataMember(Name = "MaterialType")]
        public string MaterialType
        {
            get;
            set;
        }

        /// <summary>
        ///材料分类
        /// </summary>
        [DataMember(Name = "MaterialCategory")]
        public string MaterialCategory
        {
            get;
            set;
        }

        /// <summary>
        ///纹理方向
        /// </summary>
        [DataMember(Name = "TextureDirection")]
        public string TextureDirection
        {
            get;
            set;
        }

        /// <summary>
        ///打孔信息
        /// </summary>
        [DataMember(Name = "HoleDesc")]
        public string HoleDesc
        {
            get;
            set;
        }

        /// <summary>
        ///开料宽度
        /// </summary>
        [DataMember(Name = "MadeWidth")]
        public string MadeWidth
        {
            get;
            set;
        }

        /// <summary>
        ///开料厚度
        /// </summary>
        [DataMember(Name = "MadeHeight")]
        public string MadeHeight
        {
            get;
            set;
        }

        /// <summary>
        ///开料长度
        /// </summary>
        [DataMember(Name = "MadeLength")]
        public string MadeLength
        {
            get;
            set;
        }

        /// <summary>
        ///成品宽度
        /// </summary>
        [DataMember(Name = "EndWidth")]
        public string EndWidth
        {
            get;
            set;
        }

        /// <summary>
        ///成品长度
        /// </summary>
        [DataMember(Name = "EndLength")]
        public string EndLength
        {
            get;
            set;
        }

        /// <summary>
        ///数量
        /// </summary>
        [DataMember(Name = "Qty")]
        public string Qty
        {
            get;
            set;
        }

        /// <summary>
        ///正面标签
        /// </summary>
        [DataMember(Name = "FrontLabel")]
        public string FrontLabel
        {
            get;
            set;
        }

        /// <summary>
        ///反面标签
        /// </summary>
        [DataMember(Name = "BackLabel")]
        public string BackLabel
        {
            get;
            set;
        }

        /// <summary>
        ///备注
        /// </summary>
        [DataMember(Name = "Remarks")]
        public string Remarks
        {
            get;
            set;
        }

        /// <summary>
        ///柜号
        /// </summary>
        [DataMember(Name = "CabinetNum")]
        public string CabinetNum
        {
            get;
            set;
        }

        /// <summary>
        ///封边1
        /// </summary>
        [DataMember(Name = "Edge1")]
        public string Edge1
        {
            get;
            set;
        }

        /// <summary>
        ///封边2
        /// </summary>
        [DataMember(Name = "Edge2")]
        public string Edge2
        {
            get;
            set;
        }

        /// <summary>
        ///封边3
        /// </summary>
        [DataMember(Name = "Edge3")]
        public string Edge3
        {
            get;
            set;
        }

        /// <summary>
        ///封边4
        /// </summary>
        [DataMember(Name = "Edge4")]
        public string Edge4
        {
            get;
            set;
        }

        /// <summary>
        ///封边描述
        /// </summary>
        [DataMember(Name = "EdgeDesc")]
        public string EdgeDesc
        {
            get;
            set;
        }

        /// <summary>
        /// 生产批次
        /// </summary>
        [DataMember(Name = "MadeBattchNum")]
        public string MadeBattchNum
        {
            get;
            set;
        }
        /// <summary>
        /// 单位
        /// </summary>
        [DataMember(Name = "Unit")]
        public string Unit
        {
            get;
            set;
        }
        /// <summary>
        /// 价格
        /// </summary>
        [DataMember(Name = "Price")]
        public decimal Price
        {
            get;
            set;
        }
        /// <summary>
        /// 是否异形
        /// </summary>
        [DataMember(Name = "IsSpesial")]
        public string IsSpesial
        {
            get;
            set;
        }

        /// <summary>
        /// 部件类型
        /// </summary>
        [DataMember(Name = "ItemType")]
        public string ItemType
        {
            get;
            set;
        }
    }
}
