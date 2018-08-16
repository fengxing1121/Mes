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
	public class WarehouseInMainParm
	{
		private HttpContext _context;
		public WarehouseInMainParm(HttpContext context)
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
		public Guid InID
		{
			get { return Guid.Parse(_context.Request["InID"]);}
			set { this.inID = value; }
		}
		private Guid inID;
		
		///<summary>
		///单号
		///</summary>
		public string BillNo
		{
			get { return Convert.ToString(_context.Request["BillNo"]);}
			set { this.billNo = value; }
		}
		private string billNo;
		
		///<summary>
		///批次号
		///</summary>
		public string BattchNo
		{
			get { return Convert.ToString(_context.Request["BattchNo"]);}
			set { this.battchNo = value; }
		}
		private string battchNo;
		
		///<summary>
		///供应商ID
		///</summary>
		public Guid SupplierID
		{
			get { return Guid.Parse(_context.Request["SupplierID"]);}
			set { this.supplierID = value; }
		}
		private Guid supplierID;
		
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
		///入库时间
		///</summary>
		public DateTime CheckInDate
		{
			get { return  Convert.ToDateTime(_context.Request["CheckInDate"]);}
			set { this.checkInDate = value; }
		}
		private DateTime checkInDate;
		
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
