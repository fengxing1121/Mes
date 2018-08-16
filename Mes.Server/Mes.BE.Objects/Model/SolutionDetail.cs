using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// 代码工具生成，不可以手工修改。2017-05-17 15:25:02。
    /// </summary>
    [Serializable]
    [DataContract(Name = "SolutionDetail")]
    public class SolutionDetail
    {
        public SolutionDetail()
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
        ///材质/材质颜色
        /// </summary>
        [DataMember(Name = "MaterialType")]
        public string MaterialType
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
        [DataMember(Name = "SolutionID")]
        public Guid SolutionID
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
        ///是否异形板
        /// </summary>
        [DataMember(Name = "IsSpecialShap")]
        public bool IsSpecialShap
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
		///
		/// </summary>
		[DataMember(Name = "[FilePathUrl]")]
        public string FilePathUrl
        {
            get;
            set;
        }
    }
}
