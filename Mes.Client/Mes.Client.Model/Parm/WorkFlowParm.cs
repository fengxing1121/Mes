using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class WorkFlowParm
    {
        private HttpContext _context;
        public WorkFlowParm(HttpContext context)
        {
            this._context = context;
        }

        /// <summary>
        ///主键ID
        /// </summary>
        public Guid WorkFlowID
        {
            get { return Guid.Parse(_context.Request["WorkFlowID"]); }
            set { this.workflowid = value; }
        }
        private Guid workflowid;

        /// <summary>
        ///工序编号
        /// </summary>
        public string WorkFlowCode
        {
            get { return Convert.ToString(_context.Request["WorkFlowCode"]); }
            set { this.workflowcode = value; }
        }
        private string workflowcode;

        /// <summary>
        ///工序名称
        /// </summary>
        public string WorkFlowName
        {
            get { return Convert.ToString(_context.Request["WorkFlowName"]); }
            set { this.workflowname = value; }
        }
        private string workflowname;

        /// <summary>
        ///图片
        /// </summary>
        public string ImageUrl
        {
            get { return Convert.ToString(_context.Request["ImageUrl"]); }
            set { this.imageurl = value; }
        }
        private string imageurl;

        /// <summary>
        ///备注
        /// </summary>
        public string Remark
        {
            get { return Convert.ToString(_context.Request["Remark"]); }
            set { this.remark = value; }
        }
        private string remark;

        /// <summary>
        ///排序
        /// </summary>
        public int SortNo
        {
            get { return Convert.ToInt32(_context.Request["SortNo"]); }
            set { this.sortno = value; }
        }
        private int sortno;

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

