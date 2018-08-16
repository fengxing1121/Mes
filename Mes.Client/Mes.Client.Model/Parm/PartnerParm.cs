using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-10-18 16:58:00。
	/// </summary>
	public class PartnerParm
	{
		private HttpContext _context;
		public PartnerParm(HttpContext context)
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
		///合作商ID
		///</summary>
		public Guid PartnerID
		{
			get { return Guid.Parse(_context.Request["PartnerID"]);}
			set { this.partnerID = value; }
		}
		private Guid partnerID;
		
		///<summary>
		///
		///</summary>
		public string PartnerCode
		{
			get { return Convert.ToString(_context.Request["PartnerCode"]);}
			set { this.partnerCode = value; }
		}
		private string partnerCode;
		
		///<summary>
		///合作商名称
		///</summary>
		public string PartnerName
		{
			get { return Convert.ToString(_context.Request["PartnerName"]);}
			set { this.partnerName = value; }
		}
		private string partnerName;

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
		///固定电话
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
		///
		///</summary>
		public string Fax
		{
			get { return Convert.ToString(_context.Request["Fax"]);}
			set { this.fax = value; }
		}
		private string fax;
		
		///<summary>
		///店铺大小（平方米）
		///</summary>
		public int ShopSize
		{
			get
            {
                string str = _context.Request["ShopSize"];
                return string.IsNullOrEmpty(str)?0: Convert.ToInt32(_context.Request["ShopSize"]);
            }
			set { this.shopSize = value; }
		}
		private int shopSize;
		
		///<summary>
		///合作商类型（1.直营；2.加盟；3.合资）
		///</summary>
		public string ShopType
		{
			get { return Convert.ToString(_context.Request["ShopType"]);}
			set { this.shopType = value; }
		}
		private string shopType;
		
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
