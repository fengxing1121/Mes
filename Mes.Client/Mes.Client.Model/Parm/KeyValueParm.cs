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
	public class KeyValueParm
	{
		private HttpContext _context;
		public KeyValueParm(HttpContext context)
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
		public string Key
		{
			get { return Convert.ToString(_context.Request["Key"]);}
			set { this.key = value; }
		}
		private string key;
		
		///<summary>
		///
		///</summary>
		public string Value
		{
			get { return Convert.ToString(_context.Request["Value"]);}
			set { this.value = value; }
		}
		private string value;
		
		///<summary>
		///
		///</summary>
		public string Remark
		{
			get { return Convert.ToString(_context.Request["Remark"]);}
			set { this.remark = value; }
		}
		private string remark;
	}
}
