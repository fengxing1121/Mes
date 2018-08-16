using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Client.Utility.Enum
{
    /// <summary>
    /// 用户类型
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// 工厂
        /// </summary>
        [Description("工厂用户")]
        U = 1,
        /// <summary>
        /// 经销商
        /// </summary>
        [Description("经销商")]
        D = 2,
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        G = -1
    }
}
