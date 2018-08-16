using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2018-05-10 16:58:00。
	/// </summary>
	public class CompanyParm
	{
		private HttpContext _context;
		public CompanyParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///
		///</summary>
		public Guid CompanyID
		{
			get { return Guid.Parse(_context.Request["CompanyID"]);}
			set { this.companyID = value; }
		}
		private Guid companyID;
		
		
		///<summary>
		///
		///</summary>
		public string CompanyCode
        {
			get { return Convert.ToString(_context.Request["CompanyCode"]);}
			set { this.companyCode = value; }
		}
		private string companyCode;
		
		///<summary>
		///合作商名称
		///</summary>
		public string CompanyName
		{
			get { return Convert.ToString(_context.Request["CompanyName"]);}
			set { this.companyName = value; }
		}
		private string companyName;
		
		
		///<summary>
		///详细地址
		///</summary>
		public string Address
		{
			get { return Convert.ToString(_context.Request["Address"]);}
			set { this.address = value; }
		}
		private string address;
		
		///<summary>
		///联系人
		///</summary>
		public string LinkMan
		{
			get { return Convert.ToString(_context.Request["LinkMan"]);}
			set { this.linkMan = value; }
		}
		private string linkMan;
		
		
		///<summary>
		///手机
		///</summary>
		public string Mobile
		{
			get { return Convert.ToString(_context.Request["Mobile"]);}
			set { this.mobile = value; }
		}
		private string mobile;
		
		///<summary>
		///邮箱
		///</summary>
		public string Email
		{
			get { return Convert.ToString(_context.Request["Email"]);}
			set { this.email = value; }
		}
		private string email;
		
		///<summary>
		///
		///</summary>
		public string Remark
		{
			get { return Convert.ToString(_context.Request["Remark"]);}
			set { this.remark = value; }
		}
		private string remark;
        public string Province
        {
            get { return Convert.ToString(_context.Request["Province"]); }
            set { this.province = value; }
        }
        private string province;
        public string City
        {
            get { return Convert.ToString(_context.Request["City"]); }
            set { this.city = value; }
        }
        private string city;

        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime Created
		{
			get { return  Convert.ToDateTime(_context.Request["Created"]);}
			set { this.created = value; }
		}
		private DateTime created;
		
		///<summary>
		///创建人
		///</summary>
		public string CreatedBy
		{
			get { return Convert.ToString(_context.Request["CreatedBy"]);}
			set { this.createdBy = value; }
		}
		private string createdBy;
		
		///<summary>
		///修改时间
		///</summary>
		public DateTime Modified
		{
			get { return  Convert.ToDateTime(_context.Request["Modified"]);}
			set { this.modified = value; }
		}
		private DateTime modified;
		
		///<summary>
		///修改人
		///</summary>
		public string ModifiedBy
		{
			get { return Convert.ToString(_context.Request["ModifiedBy"]);}
			set { this.modifiedBy = value; }
		}
		private string modifiedBy;


        public int Sort
        {
            get { return Convert.ToInt32(_context.Request["Sort"]); }
            set { this.sort = value; }
        }
        private int sort;
	}
}
