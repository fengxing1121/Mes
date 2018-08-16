using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-10-18 16:58:02。
	/// </summary>
	public class WarehouseOutMainParm
	{
		private HttpContext _context;
		public WarehouseOutMainParm(HttpContext context)
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
		///出库ID
		///</summary>
		public Guid OutID
		{
			get { return Guid.Parse(_context.Request["OutID"]);}
			set { this.outID = value; }
		}
		private Guid outID;
		
		///<summary>
		///出库单号
		///</summary>
		public string BillNo
		{
			get { return Convert.ToString(_context.Request["BillNo"]);}
			set { this.billNo = value; }
		}
		private string billNo;
		
		///<summary>
		///使用车间
		///</summary>
		public Guid WorkShopID
		{
			get { return Guid.Parse(_context.Request["WorkShopID"]);}
			set { this.workShopID = value; }
		}
		private Guid workShopID;
		
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
		///出库日期
		///</summary>
		public DateTime CheckOutDate
		{
			get { return  Convert.ToDateTime(_context.Request["CheckOutDate"]);}
			set { this.checkOutDate = value; }
		}
		private DateTime checkOutDate;
		
		///<summary>
		///经手人
		///</summary>
		public string HandlerMan
		{
			get { return Convert.ToString(_context.Request["HandlerMan"]);}
			set { this.handlerMan = value; }
		}
		private string handlerMan;
		
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
