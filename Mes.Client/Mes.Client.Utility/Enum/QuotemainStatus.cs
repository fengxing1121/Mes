using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Client.Utility.Enum
{
    /// <summary>
    /// 报价单状态
    /// </summary>
    public enum QuotemainStatus
    {
        /// <summary>
        /// 确认中
        /// </summary>
        [Description("N")]
        N,
        /// <summary>
        /// 已确认
        /// </summary>
        [Description("F")]
        F,
        /// <summary>
        /// 已取消
        /// </summary>
        [Description("C")]
        C
    }
}
