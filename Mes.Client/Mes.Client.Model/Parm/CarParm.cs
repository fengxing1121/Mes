using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class CarParm
    {
        private HttpContext _context;
        public CarParm(HttpContext context)
        {
            this._context = context;
        }

        public Guid CarID
        {
            get { return Guid.Parse(_context.Request["CarID"]); }
            set { this.carID = value; }
        }
        private Guid carID;

        ///<summary>
        ///企业物流ID
        ///</summary>
        public Guid EnterpriseID
        {
            get { return Guid.Parse(_context.Request["EnterpriseID"]); }
            set { this.enterpriseID = value; }
        }
        private Guid enterpriseID;
        

        ///<summary>
        ///车牌号码
        ///</summary>
        public string PlateNo
        {
            get { return Convert.ToString(_context.Request["PlateNo"]); }
            set { this.plateNo = value; }
        }
        private string plateNo;
         
        ///<summary>
        ///车名
        ///</summary>
        public string CarName
        {
            get { return Convert.ToString(_context.Request["CarName"]); }
            set { this.carName = value; }
        }
        private string carName;


        ///<summary>
        ///车型
        ///</summary>
        public string CarStyle
        {
            get { return Convert.ToString(_context.Request["CarStyle"]); }
            set { this.carStyle = value; }
        }
        private string carStyle;

        ///<summary>
        ///驾驶人
        ///</summary>
        public string DriverName
        {
            get { return Convert.ToString(_context.Request["DriverName"]); }
            set { this.driverName = value; }
        }
        private string driverName;

        ///<summary>
        ///手机
        ///</summary>
        public string Mobile
        {
            get { return Convert.ToString(_context.Request["Mobile"]); }
            set { this.mobile = value; }
        }
        private string mobile;


        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime Created
        {
            get { return Convert.ToDateTime(_context.Request["Created"]); }
            set { this.created = value; }
        }
        private DateTime created;

        ///<summary>
        ///创建人
        ///</summary>
        public string CreatedBy
        {
            get { return Convert.ToString(_context.Request["CreatedBy"]); }
            set { this.createdBy = value; }
        }
        private string createdBy;

        ///<summary>
        ///修改时间
        ///</summary>
        public DateTime Modified
        {
            get { return Convert.ToDateTime(_context.Request["Modified"]); }
            set { this.modified = value; }
        }
        private DateTime modified;

        ///<summary>
        ///修改人
        ///</summary>
        public string ModifiedBy
        {
            get { return Convert.ToString(_context.Request["ModifiedBy"]); }
            set { this.modifiedBy = value; }
        }
        private string modifiedBy;
    }
}