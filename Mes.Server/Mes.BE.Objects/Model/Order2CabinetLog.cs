using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mes.BE.Objects
{
    /// <summary>
    /// 代码工具生成，不可以手工修改。2016-10-18 15:59:42。
    /// </summary>
    [Serializable]
    [DataContract(Name = "Order2CabinetLog")]
    public class Order2CabinetLog
    {
        public Order2CabinetLog()
        {
        }

        /// <summary>
        ///步骤ID
        /// </summary>
        [DataMember(Name = "LogID")]
        public Guid LogID
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
        /// 产品ID
        /// </summary>
        [DataMember(Name = "CabinetID")]
        public Guid CabinetID
        {
            get;
            set;
        }

        /// <summary>
        ///处理动作
        /// </summary>
        [DataMember(Name = "Action")]
        public string Action
        {
            get;
            set;
        }

        /// <summary>
        /// 处理类型
        /// </summary>
        [DataMember(Name = "ActionType")]
        public int ActionType
        {
            get;
            set;
        }


        /// <summary>
        ///提交人
        /// </summary>
        [DataMember(Name = "StartedBy")]
        public string StartedBy
        {
            get;
            set;
        }

        /// <summary>
        ///提交时间
        /// </summary>
        [DataMember(Name = "Started")]
        public DateTime Started
        {
            get;
            set;
        }

        /// <summary>
        ///处理人
        /// </summary>
        [DataMember(Name = "EndedBy")]
        public string EndedBy
        {
            get;
            set;
        }

        /// <summary>
        ///处理时间
        /// </summary>
        [DataMember(Name = "Ended")]
        public DateTime Ended
        {
            get;
            set;
        }

        /// <summary>
        /// 是否已完成
        /// </summary>
        [DataMember(Name = "IsFinish")]
        public bool IsFinish
        {
            get;
            set;
        }

        /// <summary>
        ///处理说明
        /// </summary>
        [DataMember(Name = "Remark")]
        public string Remark
        {
            get;
            set;
        }
        /// <summary>
        /// 产品大小
        /// </summary>
        [DataMember(Name = "OldSize")]
        public string OldSize
        {
            get;
            set;
        }
        /// <summary>
        /// 产品颜色
        /// </summary>
        [DataMember(Name = "OldColor")]
        public string OldColor
        {
            get;
            set;
        }

        /// <summary>
        /// 产品样式
        /// </summary>
        [DataMember(Name = "OldMaterialStyle")]
        public string OldMaterialStyle
        {
            get;
            set;
        }
    }

    public enum OprationType
    {
        /// <summary>
        /// 申请改单
        /// </summary>
        applyUpdate,
        /// <summary>
        /// 允许改单
        /// </summary>
        allowUpdate,
        /// <summary>
        /// 撤销改单
        /// </summary>
        cancelUpdate,

        /// <summary>
        /// 申请消单
        /// </summary>
        applyDelete,
        /// <summary>
        /// 允许消单
        /// </summary>
        allowDelete,
        /// <summary>
        /// 撤销消单
        /// </summary>
        cancelDelete,
    }
}
