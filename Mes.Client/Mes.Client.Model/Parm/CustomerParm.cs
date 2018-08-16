using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-10-18 16:57:58。
	/// </summary>
	public class CustomerParm
	{
		private HttpContext _context;
		public CustomerParm(HttpContext context)
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
		///客户ID
		///</summary>
		public Guid CustomerID
		{
			get { return Guid.Parse(_context.Request["CustomerID"]);}
			set { this.customerID = value; }
		}
		private Guid customerID;
		
		///<summary>
		///
		///</summary>
		public Guid PartnerID
		{
			get { return Guid.Parse(_context.Request["PartnerID"]);}
			set { this.partnerID = value; }
		}
		private Guid partnerID;
		
		///<summary>
		///客户名称
		///</summary>
		public string CustomerName
		{
			get { return Convert.ToString(_context.Request["CustomerName"]);}
			set { this.customerName = value; }
		}
		private string customerName;
		
		///<summary>
		///
		///</summary>
		public string Province
		{
			get { return Convert.ToString(_context.Request["Province"]);}
			set { this.province = value; }
		}
		private string province;
		
		///<summary>
		///
		///</summary>
		public string City
		{
			get { return Convert.ToString(_context.Request["City"]);}
			set { this.city = value; }
		}
		private string city;
		
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
		///联系人职位
		///</summary>
		public string Position
		{
			get { return Convert.ToString(_context.Request["Position"]);}
			set { this.position = value; }
		}
		private string position;
		
		///<summary>
		///地址
		///</summary>
		public string Address
		{
			get { return Convert.ToString(_context.Request["Address"]);}
			set { this.address = value; }
		}
		private string address;
		
		///<summary>
		///电话
		///</summary>
		public string Tel
		{
			get { return Convert.ToString(_context.Request["Tel"]);}
			set { this.tel = value; }
		}
		private string tel;
		
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
		///传真
		///</summary>
		public string Fax
		{
			get { return Convert.ToString(_context.Request["Fax"]);}
			set { this.fax = value; }
		}
		private string fax;
		
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
		///主页
		///</summary>
		public string HomePage
		{
			get { return Convert.ToString(_context.Request["HomePage"]);}
			set { this.homePage = value; }
		}
		private string homePage;
		
		///<summary>
		///备注说明
		///</summary>
		public string Remark
		{
			get { return Convert.ToString(_context.Request["Remark"]);}
			set { this.remark = value; }
		}
		private string remark;

        ///<summary>
        ///收货地址
        ///</summary>
        public string ReceiveAddress
        {
            get { return Convert.ToString(_context.Request["ReceiveAddress"]); }
            set { this.receiveAddress = value; }
        }
        private string receiveAddress;
        ///<summary>
        ///收货人
        ///</summary>
        public string ReceiveLinkMan
        {
            get { return Convert.ToString(_context.Request["ReceiveLinkMan"]); }
            set { this.receiveLinkMan = value; }
        }
        private string receiveLinkMan;
        ///<summary>
        ///收货电话
        ///</summary>
        public string ReceiveMobile
        {
            get { return Convert.ToString(_context.Request["ReceiveMobile"]); }
            set { this.receiveMobile = value; }
        }
        private string receiveMobile;
		
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
	}
}
