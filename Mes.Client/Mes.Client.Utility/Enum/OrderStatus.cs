using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Client.Utility.Enum
{
    /// <summary>
    /// 订单状态(记录整个订单流转过程)
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// 待门店初审
        /// </summary>
        A,

        /// <summary>
        /// 待工厂确认
        /// </summary>
        B,

        /// <summary>
        /// 待工厂初审
        /// </summary>
        C,

        /// <summary>
        /// 待提交设计
        /// </summary>
        D,

        /// <summary>
        /// 待销售报价
        /// </summary>
        E,


        /// <summary>
        /// 待财务审核
        /// </summary>
        F,

        /// <summary>
        /// 待导入BOM
        /// </summary>
        G,

        /// <summary>
        /// 待排单优化
        /// </summary>
        H,

        /// <summary>
        /// 已取消
        /// </summary>
        Z,
    }

    /// <summary>
    /// 订单步骤(只记录销售订单可变流程)
    /// </summary>
    public enum StepCode
    {
        /// <summary>
        /// 门店新增订单
        /// </summary>
        partneraddorder,

        /// <summary>
        /// 门店订单初审
        /// </summary>
        partnerordersconfirm,

        /// <summary>
        /// 工厂预订单导入
        /// </summary>
        importorder,

        /// <summary>
        /// 工厂新增订单
        /// </summary>
        addorder,

        /// <summary>
        /// 工厂订单初审
        /// </summary>
        ordersconfirm,

        /// <summary>
        /// 工厂提交设计
        /// </summary>
        ordersdesign,

        /// <summary>
        /// 工厂销售报价
        /// </summary>
        ordersprice,

        /// <summary>
        /// 工厂财务审核
        /// </summary>
        ordersreview,
    }

    public enum ProductionOrderStatus
    {
        /// <summary>
        /// 未排单
        /// </summary>
        N,

        /// <summary>
        /// 已排单
        /// </summary>
        Y,

        /// <summary>
        /// 已转工单
        /// </summary>
        K,
    }
}