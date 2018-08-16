using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class ProductionSetParm
    {
        private HttpContext _context;
        public ProductionSetParm(HttpContext context)
        {
            this._context = context;
        }

        /// <summary>
        ///序号
        /// </summary>
        public Guid SetID
        {
            get { return Guid.Parse(_context.Request["SetID"]); }
            set { this.setid = value; }
        }
        private Guid setid;

        /// <summary>
        ///开始日期
        /// </summary>
        public DateTime Started
        {
            get { return Convert.ToDateTime(_context.Request["Started"]); }
            set { this.started = value; }
        }
        private DateTime started;

        /// <summary>
        ///截止日期
        /// </summary>
        public DateTime Ended
        {
            get { return Convert.ToDateTime(_context.Request["Ended"]); }
            set { this.ended = value; }
        }
        private DateTime ended;

        /// <summary>
        ///区段总计有多少周
        /// </summary>
        public int Weeks
        {
            get { return Convert.ToInt32(_context.Request["Weeks"]); }
            set { this.weeks = value; }
        }
        private int weeks;

        /// <summary>
        ///工作日(天)
        /// </summary>
        public int Days
        {
            get { return Convert.ToInt32(_context.Request["Days"]); }
            set { this.days = value; }
        }
        private int days;

        /// <summary>
        ///总排单量
        /// </summary>
        public double TotalAreal
        {
            get { return Convert.ToDouble(_context.Request["TotalAreal"]); }
            set { this.totalareal = value; }
        }
        private double totalareal;

        /// <summary>
        ///处理时间
        /// </summary>
        public DateTime Created
        {
            get { return Convert.ToDateTime(_context.Request["Created"]); }
            set { this.created = value; }
        }
        private DateTime created;

        /// <summary>
        ///处理人
        /// </summary>
        public string CreatedBy
        {
            get { return Convert.ToString(_context.Request["CreatedBy"]); }
            set { this.createdby = value; }
        }
        private string createdby;

    }
}

