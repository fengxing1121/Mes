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
	public class CategoryParm
	{
		private HttpContext _context;
		public CategoryParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///企业ID
		///</summary>
		public Guid CompanyID
		{
			get { return Guid.Parse(_context.Request["CompanyID"]);}
			set { this.companyID = value; }
		}
		private Guid companyID;
		
		///<summary>
		///字典ID
		///</summary>
		public Guid CategoryID
		{
			get { return Guid.Parse(_context.Request["CategoryID"]);}
			set { this.categoryID = value; }
		}
		private Guid categoryID;
		
		///<summary>
		///所属父级
		///</summary>
		public Guid ParentID
		{
			get { return Guid.Parse(_context.Request["ParentID"]);}
			set { this.parentID = value; }
		}
		private Guid parentID;
		
		///<summary>
		///字典码
		///</summary>
		public string CategoryCode
		{
			get { return Convert.ToString(_context.Request["CategoryCode"]);}
			set { this.categoryCode = value; }
		}
		private string categoryCode;
		
		///<summary>
		///字典名称
		///</summary>
		public string CategoryName
		{
			get { return Convert.ToString(_context.Request["CategoryName"]);}
			set { this.categoryName = value; }
		}
		private string categoryName;
		
		///<summary>
		///简称
		///</summary>
		public string ShortName
		{
			get { return Convert.ToString(_context.Request["ShortName"]);}
			set { this.shortName = value; }
		}
		private string shortName;
		
		///<summary>
		///排序号
		///</summary>
		public int Sequence
		{
			get { return Convert.ToInt32(_context.Request["Sequence"]);}
			set { this.sequence = value; }
		}
		private int sequence;

        ///<summary>
        ///是否禁用
        ///</summary>
        public bool IsDisabled
        {
            get { return Convert.ToBoolean(_context.Request["IsDisabled"]); }
            set { this.isDisabled = value; }
        }
        private bool isDisabled;

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
