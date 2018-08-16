using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class LogisticsEnterpriseParm
    {
        private HttpContext _context;
        public LogisticsEnterpriseParm(HttpContext context)
        {
            this._context = context;
        }
        
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
        ///物流名称
        ///</summary>
        public string EnterpriseName
        {
            get { return Convert.ToString(_context.Request["EnterpriseName"]); }
            set { this.enterpriseName = value; }
        }
        private string enterpriseName;
         
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
        ///地址
        ///</summary>
        public string Address
        {
            get { return Convert.ToString(_context.Request["Address"]); }
            set { this.address = value; }
        }
        private string address;

        ///<summary>
        ///电话
        ///</summary>
        public string Tel
        {
            get { return Convert.ToString(_context.Request["Tel"]); }
            set { this.tel = value; }
        }
        private string tel;

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