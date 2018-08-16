using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
    /// <summary>
    /// 代码工具生成，不可以手工修改。2017-04-06 21:37:39。
    /// </summary>
    public class SolutionParm
    {
        private HttpContext _context;
        public SolutionParm(HttpContext context)
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
        ///方案ID
        ///</summary>
        public Guid SolutionID
        {
            get { return Guid.Parse(_context.Request["SolutionID"]); }
            set { this.solutionID = value; }
        }
        private Guid solutionID;

        ///<summary>
        ///
        ///</summary>
        public Guid CustomerID
        {
            get { return Guid.Parse(_context.Request["CustomerID"]); }
            set { this.customerID = value; }
        }
        private Guid customerID;


        private Guid referenceID;
        public Guid ReferenceID
        {
            get { return Guid.Parse(_context.Request["ReferenceID"]); }
            set { this.referenceID = value; }
        }

        ///<summary>
        ///方案编号
        ///</summary>
        public string SolutionCode
        {
            get { return Convert.ToString(_context.Request["SolutionCode"]); }
            set { this.solutionCode = value; }
        }
        private string solutionCode;

        ///<summary>
        ///方案名称
        ///</summary>
        public string SolutionName
        {
            get { return Convert.ToString(_context.Request["SolutionName"]); }
            set { this.solutionName = value; }
        }
        private string solutionName;

        ///<summary>
        ///方案设计软件:DSC，酷家乐...
        ///</summary>
        public string DesignSoft
        {
            get { return Convert.ToString(_context.Request["DesignSoft"]); }
            set { this.designSoft = value; }
        }
        private string designSoft;

        ///<summary>
        ///方案描述
        ///</summary>
        public string Remark
        {
            get { return Convert.ToString(_context.Request["Remark"]); }
            set { this.remark = value; }
        }
        private string remark;

        ///<summary>
        ///
        ///</summary>
        public string Version
        {
            get { return Convert.ToString(_context.Request["Version"]); }
            set { this.version = value; }
        }
        private string version;

        ///<summary>
        ///设计师
        ///</summary>
        public string Designer
        {
            get { return Convert.ToString(_context.Request["Designer"]); }
            set { this.designer = value; }
        }
        private string designer;

        ///<summary>
        ///方案状态：N,待上传方案文件；P,待生成报价明细；Q,已报价；F,方案成交；C,已取消；
        ///</summary>
        public string Status
        {
            get { return Convert.ToString(_context.Request["Status"]); }
            set { this.status = value; }
        }
        private string status;

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
    }
}
