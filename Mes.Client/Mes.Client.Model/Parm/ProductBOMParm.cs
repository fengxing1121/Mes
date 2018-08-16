using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class ProductBOMParm
    {
        private HttpContext _context;
        public ProductBOMParm(HttpContext context)
        {
            this._context = context;
        }

        /// <summary>
        ///
        /// </summary>
        public int ID
        {
            get { return (string.IsNullOrEmpty(_context.Request["ID"]) ? 0 : Convert.ToInt32(_context.Request["ID"])); }
            set { this.id = value; }
        }
        private int id;

        /// <summary>
        ///BOM编码
        /// </summary>
        public string BOMID
        {
            get { return (string.IsNullOrEmpty(_context.Request["BOMID"]) ? string.Empty : Convert.ToString(_context.Request["BOMID"])); }
            set { this.bomid = value; }
        }
        private string bomid;

        /// <summary>
        ///产品编码
        /// </summary>
        public string ProductCode
        {
            get { return (string.IsNullOrEmpty(_context.Request["ProductCode"]) ? string.Empty : Convert.ToString(_context.Request["ProductCode"])); }
            set { this.productcode = value; }
        }
        private string productcode;

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName
        {
            get { return (string.IsNullOrEmpty(_context.Request["ProductName"]) ? string.Empty : Convert.ToString(_context.Request["ProductName"])); }
            set { this.ProductName = value; }
        }

        /// <summary>
        ///状态
        /// </summary>
        public bool Status
        {
            get { return (string.IsNullOrEmpty(_context.Request["Status"]) ? false : Convert.ToBoolean(_context.Request["Status"])); }
            set { this.status = value; }
        }
        private bool status;

        /// <summary>
        ///
        /// </summary>
        public DateTime Created
        {
            get { return (string.IsNullOrEmpty(_context.Request["Created"]) ? Convert.ToDateTime("1970-01-01") : Convert.ToDateTime(_context.Request["Created"])); }
            set { this.created = value; }
        }
        private DateTime created;

        /// <summary>
        ///开始日期
        /// </summary>
        public DateTime CreatedFrom
        {
            get { return (string.IsNullOrEmpty(_context.Request["CreatedFrom"]) ? Convert.ToDateTime("1970-01-01") : Convert.ToDateTime(_context.Request["CreatedFrom"])); }
            set { this.createdFrom = value; }
        }
        private DateTime createdFrom;

        /// <summary>
        ///结束日期
        /// </summary>
        public DateTime CreatedTo
        {
            get { return (string.IsNullOrEmpty(_context.Request["CreatedTo"]) ? Convert.ToDateTime("1970-01-01") : Convert.ToDateTime(_context.Request["CreatedTo"])); }
            set { this.createdTo = value; }
        }
        private DateTime createdTo;

        /// <summary>
        ///
        /// </summary>
        public string CreatedBy
        {
            get { return (string.IsNullOrEmpty(_context.Request["CreatedBy"]) ? string.Empty : Convert.ToString(_context.Request["CreatedBy"])); }
            set { this.createdby = value; }
        }
        private string createdby;

    }
}

