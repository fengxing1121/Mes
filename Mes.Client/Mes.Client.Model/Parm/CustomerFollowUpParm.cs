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
	public class CustomerFollowUpParm
	{
		private HttpContext _context;
		public CustomerFollowUpParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///
		///</summary>
		public Guid FollowID
		{
			get { return Guid.Parse(_context.Request["FollowID"]);}
			set { this.followID = value; }
		}
		private Guid followID;
		
		///<summary>
		///
		///</summary>
		public Guid CustomerID
		{
			get { return Guid.Parse(_context.Request["CustomerID"]);}
			set { this.customerID = value; }
		}
		private Guid customerID;
		
		///<summary>
		///跟进方式,D：直接登门；V：邀约登门；T：电话跟进，M：手机短信；，O：其他
		///</summary>
		public string FollowType
		{
			get { return Convert.ToString(_context.Request["FollowType"]);}
			set { this.followType = value; }
		}
		private string followType;
		
		///<summary>
		///跟进主题
		///</summary>
		public string Title
		{
			get { return Convert.ToString(_context.Request["Title"]);}
			set { this.title = value; }
		}
		private string title;
		
		///<summary>
		///跟进内容
		///</summary>
		public string Remark
		{
			get { return Convert.ToString(_context.Request["Remark"]);}
			set { this.remark = value; }
		}
		private string remark;
		
		///<summary>
		///重要信息及结果
		///</summary>
		public string ImportantResult
		{
			get { return Convert.ToString(_context.Request["ImportantResult"]);}
			set { this.importantResult = value; }
		}
		private string importantResult;
		
		///<summary>
		///建议及应对策略
		///</summary>
		public string Suggest
		{
			get { return Convert.ToString(_context.Request["Suggest"]);}
			set { this.suggest = value; }
		}
		private string suggest;
		
		///<summary>
		///
		///</summary>
		public DateTime Created
		{
			get { return  Convert.ToDateTime(_context.Request["Created"]);}
			set { this.created = value; }
		}
		private DateTime created;
		
		///<summary>
		///
		///</summary>
		public string CreatedBy
		{
			get { return Convert.ToString(_context.Request["CreatedBy"]);}
			set { this.createdBy = value; }
		}
		private string createdBy;
		
		///<summary>
		///
		///</summary>
		public DateTime Modified
		{
			get { return  Convert.ToDateTime(_context.Request["Modified"]);}
			set { this.modified = value; }
		}
		private DateTime modified;
		
		///<summary>
		///
		///</summary>
		public string ModifiedBy
		{
			get { return Convert.ToString(_context.Request["ModifiedBy"]);}
			set { this.modifiedBy = value; }
		}
		private string modifiedBy;
	}
}
