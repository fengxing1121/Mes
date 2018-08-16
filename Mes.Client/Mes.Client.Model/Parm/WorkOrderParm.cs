using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class WorkOrderParm
    {
        private HttpContext _context;
        public WorkOrderParm(HttpContext context)
        {
            this._context = context;
        }

        /// <summary>
        ///工单ID
        /// </summary>
        public Guid WorkOrderID
        {
            get { return Guid.Parse(_context.Request["WorkOrderID"]); }
            set { this.workorderid = value; }
        }
        private Guid workorderid;

        /// <summary>
        ///工单编号
        /// </summary>
        public string WorkOrderNo
        {
            get { return Convert.ToString(_context.Request["WorkOrderNo"]); }
            set { this.workorderno = value; }
        }
        private string workorderno;

        /// <summary>
        ///订单编号
        /// </summary>
        public Guid OrderID
        {
            get { return Guid.Parse(_context.Request["OrderID"]); }
            set { this.orderid = value; }
        }
        private Guid orderid;

        /// <summary>
        ///生产订单号
        /// </summary>
        public Guid ProductionID
        {
            get { return Guid.Parse(_context.Request["ProductionID"]); }
            set { this.productionid = value; }
        }
        private Guid productionid;

        /// <summary>
        ///状态
        /// </summary>
        public string Status
        {
            get { return Convert.ToString(_context.Request["Status"]); }
            set { this.status = value; }
        }
        private string status;

        /// <summary>
        ///创建时间
        /// </summary>
        public DateTime Created
        {
            get { return Convert.ToDateTime(_context.Request["Created"]); }
            set { this.created = value; }
        }
        private DateTime created;

        /// <summary>
        ///创建人
        /// </summary>
        public string CreatedBy
        {
            get { return Convert.ToString(_context.Request["CreatedBy"]); }
            set { this.createdby = value; }
        }
        private string createdby;

    }
}

