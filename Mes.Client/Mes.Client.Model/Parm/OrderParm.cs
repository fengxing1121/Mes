using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
    /// <summary>
    /// 代码工具生成，不可以手工修改。2016-10-18 16:57:59。
    /// </summary>
    public class OrderParm
    {
        private HttpContext _context;
        public OrderParm(HttpContext context)
        {
            this._context = context;
        }

        ///<summary>
        ///
        ///</summary>
        public Guid CompanyID
        {
            get { return Guid.Parse(_context.Request["CompanyID"]); }
            set { this.companyID = value; }
        }
        private Guid companyID;

        ///<summary>
        ///
        ///</summary>
        public Guid OrderID
        {
            get { return Guid.Parse(_context.Request["OrderID"]); }
            set { this.orderID = value; }
        }
        private Guid orderID;

        ///<summary>
        ///客户ID
        ///</summary>
        public Guid CustomerID
        {
            get { return Guid.Parse(_context.Request["CustomerID"]); }
            set { this.customerID = value; }
        }
        private Guid customerID;

        ///<summary>
        ///经销商ID
        ///</summary>
        public Guid PartnerID
        {
            get { return Guid.Parse(_context.Request["PartnerID"]); }
            set { this.partnerID = value; }
        }
        private Guid partnerID;

        ///<summary>
        ///订单号
        ///</summary>
        public string OrderNo
        {
            get { return Convert.ToString(_context.Request["OrderNo"]); }
            set { this.orderNo = value; }
        }
        private string orderNo;

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
        ///联系人
        ///</summary>
        public string LinkMan
        {
            get { return Convert.ToString(_context.Request["LinkMan"]); }
            set { this.linkMan = value; }
        }
        private string linkMan;

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

        ///<summary>
        ///
        ///</summary>
        public DateTime ManufactureDate
        {
            get { return Convert.ToDateTime(_context.Request["ManufactureDate"]); }
            set { this.manufactureDate = value; }
        }
        private DateTime manufactureDate;

        ///<summary>
        ///
        ///</summary>
        public int StepNo
        {
            get { return Convert.ToInt32(_context.Request["StepNo"]); }
            set { this.stepNo = value; }
        }
        private int stepNo;

        ///<summary>
        ///
        ///</summary>
        public DateTime Created
        {
            get { return Convert.ToDateTime(_context.Request["Created"]); }
            set { this.created = value; }
        }
        private DateTime created;

        ///<summary>
        ///
        ///</summary>
        public string CreatedBy
        {
            get { return Convert.ToString(_context.Request["CreatedBy"]); }
            set { this.createdBy = value; }
        }
        private string createdBy;

        ///<summary>
        ///
        ///</summary>
        public DateTime Modified
        {
            get { return Convert.ToDateTime(_context.Request["Modified"]); }
            set { this.modified = value; }
        }
        private DateTime modified;

        ///<summary>
        ///
        ///</summary>
        public string ModifiedBy
        {
            get { return Convert.ToString(_context.Request["ModifiedBy"]); }
            set { this.modifiedBy = value; }
        }
        private string modifiedBy;

        public string Remark
        {
            get { return Convert.ToString(_context.Request["Remark"]); }
            set { this.remark = value; }
        }
        private string remark;

        ///<summary>
        ///是否正标
        ///</summary>
        public bool IsStandard
        {
            get { return Convert.ToBoolean(_context.Request["IsStandard"]); }
            set { this.isStandard = value; }
        }
        private bool isStandard;

        ///<summary>
        ///是否外购
        ///</summary>
        public bool IsOutsourcing
        {
            get { return Convert.ToBoolean(_context.Request["IsOutsourcing"]); }
            set { this.isOutsourcing = value; }
        }
        private bool isOutsourcing;


        ///<summary>
        ///产品类型
        ///</summary>
        public string CabinetType
        {
            get { return Convert.ToString(_context.Request["CabinetType"]); }
            set { this.cabinetType = value; }
        }
        private string cabinetType;

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
