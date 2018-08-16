using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    /// <summary>
    /// [ProductionOrderParm]数据模型
    /// </summary>
    public class ProductionOrderParm
    {
        private HttpContext _context;
        public ProductionOrderParm(HttpContext context)
        {
            this._context = context;
        }

        /// <summary>
        ///生产订单ID
        /// </summary>
        public Guid ProductionID
        {
            get { return (string.IsNullOrEmpty(_context.Request["ProductionID"]) ? new Guid() : Guid.Parse(_context.Request["ProductionID"])); }
            set { this.ProductionOrderid = value; }
        }
        private Guid ProductionOrderid;

        /// <summary>
        ///生产订单号
        /// </summary>
        public string ProduceNo
        {
            get { return (string.IsNullOrEmpty(_context.Request["ProduceNo"]) ? string.Empty : Convert.ToString(_context.Request["ProduceNo"])); }
            set { this.produceno = value; }
        }
        private string produceno;

        /// <summary>
        ///销售订单ID
        /// </summary>
        public Guid OrderID
        {
            get { return (string.IsNullOrEmpty(_context.Request["OrderID"]) ? new Guid() : Guid.Parse(_context.Request["OrderID"])); }
            set { this.orderid = value; }
        }
        private Guid orderid;

        /// <summary>
        ///销售订单号
        /// </summary>
        public string OrderNo
        {
            get { return (string.IsNullOrEmpty(_context.Request["OrderNo"]) ? string.Empty : Convert.ToString(_context.Request["OrderNo"])); }
            set { this.orderno = value; }
        }
        private string orderno;

        /// <summary>
        ///预计完工日期
        /// </summary>
        public DateTime FinishDate
        {
            get { return (string.IsNullOrEmpty(_context.Request["FinishDate"]) ? Convert.ToDateTime("1970-01-01") : Convert.ToDateTime(_context.Request["FinishDate"])); }
            set { this.finishdate = value; }
        }
        private DateTime finishdate;

        /// <summary>
        ///创建时间
        /// </summary>
        public DateTime Created
        {
            get { return (string.IsNullOrEmpty(_context.Request["Created"]) ? Convert.ToDateTime("1970-01-01") : Convert.ToDateTime(_context.Request["Created"])); }
            set { this.created = value; }
        }
        private DateTime created;

        /// <summary>
        ///创建人
        /// </summary>
        public string CreatedBy
        {
            get { return (string.IsNullOrEmpty(_context.Request["CreatedBy"]) ? string.Empty : Convert.ToString(_context.Request["CreatedBy"])); }
            set { this.createdby = value; }
        }
        private string createdby;

        ///<summary>
        ///采购单号
        ///</summary>
        public string PurchaseNo
        {
            get { return Convert.ToString(_context.Request["PurchaseNo"]); }
            set { this.purchaseNo = value; }
        }
        private string purchaseNo;

        ///<summary>
        ///
        ///</summary>
        public string OrderType
        {
            get { return Convert.ToString(_context.Request["OrderType"]); }
            set { this.orderType = value; }
        }
        private string orderType;
        ///<summary>
        ///门店名称
        ///</summary>
        public string PartnerName
        {
            get { return Convert.ToString(_context.Request["PartnerName"]); }
            set { this.partnerName = value; }
        }
        private string partnerName;
        ///<summary>
        ///客户名称
        ///</summary>
        public string CustomerName
        {
            get { return Convert.ToString(_context.Request["CustomerName"]); }
            set { this.customerName = value; }
        }
        private string customerName;
        ///<summary>
        ///业务员
        ///</summary>
        public string SalesMan
        {
            get { return Convert.ToString(_context.Request["SalesMan"]); }
            set { this.salesMan = value; }
        }
        private string salesMan;
        ///<summary>
        ///附件
        ///</summary>
        public string AttachmentFile
        {
            get { return Convert.ToString(_context.Request["AttachmentFile"]); }
            set { this.attachmentFile = value; }
        }
        private string attachmentFile;
        ///<summary>
        ///地址
        ///</summary>
        public string Address
        {
            get { return Convert.ToString(_context.Request["Address"]); }
            set { this.address = value; }
        }
        private string address;

        

        ///<summary>
        ///联系电话
        ///</summary>
        public string Mobile
        {
            get { return Convert.ToString(_context.Request["Mobile"]); }
            set { this.mobile = value; }
        }
        private string mobile;

        ///<summary>
        ///客户下订时间
        ///</summary>
        public DateTime BookingDate
        {
            get { return Convert.ToDateTime(_context.Request["BookingDate"]); }
            set { this.bookingDate = value; }
        }
        private DateTime bookingDate;


        ///<summary>
        ///客户下订时间
        ///</summary>
        public DateTime BookingDateFrom
        {
            get { return Convert.ToDateTime(_context.Request["BookingDateFrom"]); }
            set { this.bookingDateFrom = value; }
        }
        private DateTime bookingDateFrom;

        ///<summary>
        ///客户下订时间
        ///</summary>
        public DateTime BookingDateTo
        {
            get { return Convert.ToDateTime(_context.Request["BookingDateTo"]); }
            set { this.bookingDateTo = value; }
        }
        private DateTime bookingDateTo;

        ///<summary>
        ///发货时间
        ///</summary>
        public DateTime ShipDate
        {
            get { return Convert.ToDateTime(_context.Request["ShipDate"]); }
            set { this.shipDate = value; }
        }
        private DateTime shipDate;

        ///<summary>
        ///发货时间
        ///</summary>
        public DateTime ShipDateFrom
        {
            get { return Convert.ToDateTime(_context.Request["ShipDateFrom"]); }
            set { this.shipDateFrom = value; }
        }
        private DateTime shipDateFrom;

        //<summary>
        ///发货时间
        ///</summary>
        public DateTime ShipDateTo
        {
            get { return Convert.ToDateTime(_context.Request["ShipDateTo"]); }
            set { this.shipDateTo = value; }
        }
        private DateTime shipDateTo;

        ///<summary>
        ///订单状态
        ///</summary>
        public string Status
        {
            get { return Convert.ToString(_context.Request["Status"]); }
            set { this.status = value; }
        }
        private string status;

        ///<summary>
        ///生产批次号
        ///</summary>
        public string BattchNum
        {
            get { return Convert.ToString(_context.Request["BattchNum"]); }
            set { this.battchNum = value; }
        }
        private string battchNum;


        /// <summary>
        /// 外部订单号
        /// </summary>
        public string OutOrderNo
        {
            get { return Convert.ToString(_context.Request["OutOrderNo"]); }
            set { this.outorderno = value; }
        }
        private string outorderno;
    }
}

