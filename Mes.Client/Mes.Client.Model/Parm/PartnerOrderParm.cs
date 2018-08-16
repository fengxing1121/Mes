using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    /// <summary>
    /// [BE_PartnerOrder]数据模型
    /// </summary>
    public class PartnerOrderParm
    {
        private HttpContext _context;
        public PartnerOrderParm(HttpContext context)
        {
            this._context = context;
        }

        /// <summary>
        ///订单ID
        /// </summary>
        public Guid OrderID
        {
            get { return (string.IsNullOrEmpty(_context.Request["OrderID"]) ? new Guid() : Guid.Parse(_context.Request["OrderID"])); }
            set { this.orderid = value; }
        }
        private Guid orderid;

        /// <summary>
        ///订单编号
        /// </summary>
        public string OrderNo
        {
            get { return (string.IsNullOrEmpty(_context.Request["OrderNo"]) ? string.Empty : Convert.ToString(_context.Request["OrderNo"])); }
            set { this.orderno = value; }
        }
        private string orderno;

        /// <summary>
        ///订单类型
        /// </summary>
        public string OrderType
        {
            get { return (string.IsNullOrEmpty(_context.Request["OrderType"]) ? string.Empty : Convert.ToString(_context.Request["OrderType"])); }
            set { this.ordertype = value; }
        }
        private string ordertype;

        /// <summary>
        ///外部单号
        /// </summary>
        public string OutOrderNo
        {
            get { return (string.IsNullOrEmpty(_context.Request["OutOrderNo"]) ? string.Empty : Convert.ToString(_context.Request["OutOrderNo"])); }
            set { this.outorderno = value; }
        }
        private string outorderno;

        /// <summary>
        ///门店ID
        /// </summary>
        public Guid PartnerID
        {
            get { return (string.IsNullOrEmpty(_context.Request["PartnerID"]) ? new Guid() : Guid.Parse(_context.Request["PartnerID"])); }
            set { this.partnerid = value; }
        }
        private Guid partnerid;

        /// <summary>
        ///门店名称
        /// </summary>
        public string PartnerName
        {
            get { return (string.IsNullOrEmpty(_context.Request["PartnerName"]) ? string.Empty : Convert.ToString(_context.Request["PartnerName"])); }
            set { this.partnername = value; }
        }
        private string partnername;

        /// <summary>
        ///客户ID
        /// </summary>
        public Guid CustomerID
        {
            get { return (string.IsNullOrEmpty(_context.Request["CustomerID"]) ? new Guid() : Guid.Parse(_context.Request["CustomerID"])); }
            set { this.customerid = value; }
        }
        private Guid customerid;

        /// <summary>
        ///客户名称
        /// </summary>
        public string CustomerName
        {
            get { return (string.IsNullOrEmpty(_context.Request["CustomerName"]) ? string.Empty : Convert.ToString(_context.Request["CustomerName"])); }
            set { this.customername = value; }
        }
        private string customername;

        /// <summary>
        ///业务人员
        /// </summary>
        public string SalesMan
        {
            get { return (string.IsNullOrEmpty(_context.Request["SalesMan"]) ? string.Empty : Convert.ToString(_context.Request["SalesMan"])); }
            set { this.salesman = value; }
        }
        private string salesman;

        /// <summary>
        ///客户地址
        /// </summary>
        public string Address
        {
            get { return (string.IsNullOrEmpty(_context.Request["Address"]) ? string.Empty : Convert.ToString(_context.Request["Address"])); }
            set { this.address = value; }
        }
        private string address;

        /// <summary>
        ///联系方式
        /// </summary>
        public string Mobile
        {
            get { return (string.IsNullOrEmpty(_context.Request["Mobile"]) ? string.Empty : Convert.ToString(_context.Request["Mobile"])); }
            set { this.mobile = value; }
        }
        private string mobile;

        /// <summary>
        ///下单日期
        /// </summary>
        public DateTime BookingDateFrom
        {
            get { return (string.IsNullOrEmpty(_context.Request["BookingDateFrom"]) ? Convert.ToDateTime("1970-01-01") : Convert.ToDateTime(_context.Request["BookingDateFrom"])); }
            set { this.bookingdatefrom = value; }
        }
        private DateTime bookingdatefrom;

        public DateTime BookingDateTo
        {
            get { return (string.IsNullOrEmpty(_context.Request["BookingDateTo"]) ? Convert.ToDateTime("1970-01-01") : Convert.ToDateTime(_context.Request["BookingDateTo"])); }
            set { this.bookingdateto = value; }
        }
        private DateTime bookingdateto;
        public DateTime BookingDate
        {
            get { return (string.IsNullOrEmpty(_context.Request["BookingDate"]) ? Convert.ToDateTime("1970-01-01") : Convert.ToDateTime(_context.Request["BookingDate"])); }
            set { this.bookingdate = value; }
        }
        private DateTime bookingdate;
        /// <summary>
        ///交货日期
        /// </summary>
        public DateTime ShipDateFrom
        {
            get { return (string.IsNullOrEmpty(_context.Request["ShipDateFrom"]) ? Convert.ToDateTime("1970-01-01") : Convert.ToDateTime(_context.Request["ShipDateFrom"])); }
            set { this.shipdatefrom = value; }
        }
        private DateTime shipdatefrom;

        public DateTime ShipDateTo
        {
            get { return (string.IsNullOrEmpty(_context.Request["ShipDateTo"]) ? Convert.ToDateTime("1970-01-01") : Convert.ToDateTime(_context.Request["ShipDateTo"])); }
            set { this.shipdateto = value; }
        }
        private DateTime shipdateto;
        public DateTime ShipDate
        {
            get { return (string.IsNullOrEmpty(_context.Request["ShipDate"]) ? Convert.ToDateTime("1970-01-01") : Convert.ToDateTime(_context.Request["ShipDate"])); }
            set { this.shipdate = value; }
        }
        private DateTime shipdate;
        /// <summary>
        ///订单状态
        /// </summary>
        public string Status
        {
            get { return (string.IsNullOrEmpty(_context.Request["Status"]) ? string.Empty : Convert.ToString(_context.Request["Status"])); }
            set { this.status = value; }
        }
        private string status;

        /// <summary>
        ///当前节点ID
        /// </summary>
        public int StepNo
        {
            get { return (string.IsNullOrEmpty(_context.Request["StepNo"]) ? 0 : Convert.ToInt32(_context.Request["StepNo"])); }
            set { this.stepno = value; }
        }
        private int stepno;

        /// <summary>
        ///订单备注
        /// </summary>
        public string Remark
        {
            get { return (string.IsNullOrEmpty(_context.Request["Remark"]) ? string.Empty : Convert.ToString(_context.Request["Remark"])); }
            set { this.remark = value; }
        }
        private string remark;

        /// <summary>
        ///订单附件
        /// </summary>
        public string AttachmentFile
        {
            get { return (string.IsNullOrEmpty(_context.Request["AttachmentFile"]) ? string.Empty : Convert.ToString(_context.Request["AttachmentFile"])); }
            set { this.attachmentfile = value; }
        }
        private string attachmentfile;

        /// <summary>
        ///创建人
        /// </summary>
        public DateTime Created
        {
            get { return (string.IsNullOrEmpty(_context.Request["Created"]) ? Convert.ToDateTime("1970-01-01") : Convert.ToDateTime(_context.Request["Created"])); }
            set { this.created = value; }
        }
        private DateTime created;

        /// <summary>
        ///创建时间
        /// </summary>
        public string CreatedBy
        {
            get { return (string.IsNullOrEmpty(_context.Request["CreatedBy"]) ? string.Empty : Convert.ToString(_context.Request["CreatedBy"])); }
            set { this.createdby = value; }
        }
        private string createdby;

        /// <summary>
        ///修改人
        /// </summary>
        public DateTime Modified
        {
            get { return (string.IsNullOrEmpty(_context.Request["Modified"]) ? Convert.ToDateTime("1970-01-01") : Convert.ToDateTime(_context.Request["Modified"])); }
            set { this.modified = value; }
        }
        private DateTime modified;

        /// <summary>
        ///修改时间
        /// </summary>
        public string ModifiedBy
        {
            get { return (string.IsNullOrEmpty(_context.Request["ModifiedBy"]) ? string.Empty : Convert.ToString(_context.Request["ModifiedBy"])); }
            set { this.modifiedby = value; }
        }
        private string modifiedby;

    }
}

