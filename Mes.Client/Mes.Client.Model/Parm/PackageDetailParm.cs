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
	public class PackageDetailParm
	{
		private HttpContext _context;
		public PackageDetailParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///板件唯一ID
		///</summary>
		public Guid DetailID
		{
			get { return Guid.Parse(_context.Request["DetailID"]);}
			set { this.detailID = value; }
		}
		private Guid detailID;
		
		///<summary>
		///板件ID
		///</summary>
		public Guid ItemID
		{
			get { return Guid.Parse(_context.Request["ItemID"]);}
			set { this.itemID = value; }
		}
		private Guid itemID;
		
		///<summary>
		///包号ID
		///</summary>
		public Guid PakageID
		{
			get { return Guid.Parse(_context.Request["PakageID"]);}
			set { this.pakageID = value; }
		}
		private Guid pakageID;
		
		///<summary>
		///所在层
		///</summary>
		public int LayerNum
		{
			get { return Convert.ToInt32(_context.Request["LayerNum"]);}
			set { this.layerNum = value; }
		}
		private int layerNum;
		
		///<summary>
		///是否已包装
		///</summary>
		public bool IsPakaged
		{
			get { return Convert.ToBoolean(_context.Request["IsPakaged"]);}
			set { this.isPakaged = value; }
		}
		private bool isPakaged;
		
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
