using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Client.Utility.Enum
{
    /// <summary>
    /// 方案状态
    /// </summary>
    public enum SolutionStatus
    {
        /// <summary>
        /// 待上传方案文件
        /// </summary>
        [Description("待上传方案文件")]
        N,
        /// <summary>
        /// 待生成报价明细
        /// </summary>
        [Description("待生成报价明细")]
        P,
        /// <summary>
        /// 已报价
        /// </summary>
        [Description("已报价")]
        Q,
        /// <summary>
        /// 方案成交
        /// </summary>
        [Description("方案成交")]
        F,
        /// <summary>
        /// 已取消
        /// </summary>
        [Description("已取消")]
        C,
    }
}
