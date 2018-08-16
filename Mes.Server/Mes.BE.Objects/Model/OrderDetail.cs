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
    [DataContract(Name = "OrderDetail")]
    public class OrderDetail
    {
        public OrderDetail()
        {
        }

        /// <summary>
        ///子订单ID
        /// </summary>
        [DataMember(Name = "ItemID")]
        public Guid ItemID
        {
            get;
            set;
        }

        /// <summary>
        ///部件名称
        /// </summary>
        [DataMember(Name = "ItemName")]
        public string ItemName
        {
            get;
            set;
        }

        /// <summary>
        ///部件类型,B：板件，G：玻璃，I：铝材，D：移门，门板
        /// </summary>
        [DataMember(Name = "ItemType")]
        public string ItemType
        {
            get;
            set;
        }

        /// <summary>
        ///材质颜色
        /// </summary>
        [DataMember(Name = "MaterialType")]
        public string MaterialType
        {
            get;
            set;
        }

        /// <summary>
        ///包装尺寸类型，L：大，M：中，S：小；
        /// </summary>
        [DataMember(Name = "PackageSizeType")]
        public string PackageSizeType
        {
            get;
            set;
        }

        /// <summary>
        ///包装类型
        /// </summary>
        [DataMember(Name = "PackageCategory")]
        public string PackageCategory
        {
            get;
            set;
        }

        /// <summary>
        ///板件条码
        /// </summary>
        [DataMember(Name = "BarcodeNo")]
        public string BarcodeNo
        {
            get;
            set;
        }

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
        ///
        /// </summary>
        [DataMember(Name = "CabinetID")]
        public Guid CabinetID
        {
            get;
            set;
        }

        /// <summary>
        ///板件排产序号
        /// </summary>
        [DataMember(Name = "ItemIndex")]
        public int ItemIndex
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
        ///开孔信息
        /// </summary>
        [DataMember(Name = "HoleDesc")]
        public string HoleDesc
        {
            get;
            set;
        }

        /// <summary>
        ///板件状态
        /// </summary>
        [DataMember(Name = "DetailStatus")]
        public string DetailStatus
        {
            get;
            set;
        }
        /// <summary>
        ///批次号
        /// </summary>
        [DataMember(Name = "BatchNum")]
        public string BatchNum
        {
            get;
            set;
        }
        /// <summary>
        ///开料宽度
        /// </summary>
        [DataMember(Name = "MadeWidth")]
        public decimal MadeWidth
        {
            get;
            set;
        }

        /// <summary>
        ///开料高度
        /// </summary>
        [DataMember(Name = "MadeHeight")]
        public decimal MadeHeight
        {
            get;
            set;
        }

        /// <summary>
        ///开料长度
        /// </summary>
        [DataMember(Name = "MadeLength")]
        public decimal MadeLength
        {
            get;
            set;
        }

        /// <summary>
        ///成品宽度
        /// </summary>
        [DataMember(Name = "EndWidth")]
        public decimal EndWidth
        {
            get;
            set;
        }

        /// <summary>
        ///成品长度
        /// </summary>
        [DataMember(Name = "EndLength")]
        public decimal EndLength
        {
            get;
            set;
        }

        /// <summary>
        ///数量
        /// </summary>
        [DataMember(Name = "Qty")]
        public decimal Qty
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
        ///生产批次号
        /// </summary>
        [DataMember(Name = "MadeBattchNum")]
        public string MadeBattchNum
        {
            get;
            set;
        }

        /// <summary>
        ///是否有孔
        /// </summary>
        [DataMember(Name = "HasHole")]
        public bool HasHole
        {
            get;
            set;
        }

        /// <summary>
        ///有孔的面数
        /// </summary>
        [DataMember(Name = "HoleFaceQty")]
        public int HoleFaceQty
        {
            get;
            set;
        }

        /// <summary>
        ///1面孔的个数
        /// </summary>
        [DataMember(Name = "Hole1Qty")]
        public int Hole1Qty
        {
            get;
            set;
        }

        /// <summary>
        ///2面孔的个数
        /// </summary>
        [DataMember(Name = "Hole2Qty")]
        public int Hole2Qty
        {
            get;
            set;
        }

        /// <summary>
        ///3面孔的个数
        /// </summary>
        [DataMember(Name = "Hole3Qty")]
        public int Hole3Qty
        {
            get;
            set;
        }

        /// <summary>
        ///4面孔的个数
        /// </summary>
        [DataMember(Name = "Hole4Qty")]
        public int Hole4Qty
        {
            get;
            set;
        }

        /// <summary>
        ///5面孔的个数
        /// </summary>
        [DataMember(Name = "Hole5Qty")]
        public int Hole5Qty
        {
            get;
            set;
        }

        /// <summary>
        ///6面孔的个数
        /// </summary>
        [DataMember(Name = "Hole6Qty")]
        public int Hole6Qty
        {
            get;
            set;
        }

        /// <summary>
        ///是否有槽
        /// </summary>
        [DataMember(Name = "HasSlot")]
        public bool HasSlot
        {
            get;
            set;
        }

        /// <summary>
        ///是否有正面槽
        /// </summary>
        [DataMember(Name = "HasFrontSlot")]
        public bool HasFrontSlot
        {
            get;
            set;
        }

        /// <summary>
        ///是否有反面槽
        /// </summary>
        [DataMember(Name = "HasBackSlot")]
        public bool HasBackSlot
        {
            get;
            set;
        }

        /// <summary>
        ///部件类型，P：外购件；S：库存件；M：加工件；
        /// </summary>
        [DataMember(Name = "ItemCategory")]
        public string ItemCategory
        {
            get;
            set;
        }

        /// <summary>
        ///是否异形板
        /// </summary>
        [DataMember(Name = "IsSpecialShap")]
        public bool IsSpecialShap
        {
            get;
            set;
        }

        /// <summary>
        ///损坏（补货）数量
        /// </summary>
        [DataMember(Name = "DamageQty")]
        public int DamageQty
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "Created")]
        public DateTime Created
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "CreatedBy")]
        public string CreatedBy
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "Modified")]
        public DateTime Modified
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "ModifiedBy")]
        public string ModifiedBy
        {
            get;
            set;
        }
        /// <summary>
        ///板件组
        /// </summary>
        [DataMember(Name = "ItemGroup")]
        public string ItemGroup { get; set; }
    }
}
