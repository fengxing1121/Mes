using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-10-18 16:58:01。
	/// </summary>
	public class SupplierParm
	{
		private HttpContext _context;
		public SupplierParm(HttpContext context)
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
		public Guid SupplierID
		{
			get { return Guid.Parse(_context.Request["SupplierID"]);}
			set { this.supplierID = value; }
		}
		private Guid supplierID;
		
		///<summary>
		///供应商类型
		///</summary>
		public string Category
		{
			get { return Convert.ToString(_context.Request["Category"]);}
			set { this.category = value; }
		}
		private string category;
		
		///<summary>
		///供应商编号
		///</summary>
		public string SupplierCode
		{
			get { return Convert.ToString(_context.Request["SupplierCode"]);}
			set { this.supplierCode = value; }
		}
		private string supplierCode;
		
		///<summary>
		///供应商名称
		///</summary>
		public string SupplierName
		{
			get { return Convert.ToString(_context.Request["SupplierName"]);}
			set { this.supplierName = value; }
		}
		private string supplierName;
		
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
		///所属省份
		///</summary>
		public string Province
		{
			get { return Convert.ToString(_context.Request["Province"]);}
			set { this.province = value; }
		}
		private string province;
		
		///<summary>
		///所属城市
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
		///联系电话
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
		///邮箱
		///</summary>
		public string Email
		{
			get { return Convert.ToString(_context.Request["Email"]);}
			set { this.email = value; }
		}
		private string email;
		
		///<summary>
		///备注
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
