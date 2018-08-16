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
	public class Order2HardwareParm
	{
		private HttpContext _context;
		public Order2HardwareParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///明细ID
		///</summary>
		public Guid ItemID
		{
			get { return Guid.Parse(_context.Request["ItemID"]);}
			set { this.itemID = value; }
		}
		private Guid itemID;
		
		///<summary>
		///条码编号
		///</summary>
		public string BarcodeNo
		{
			get { return Convert.ToString(_context.Request["BarcodeNo"]);}
			set { this.barcodeNo = value; }
		}
		private string barcodeNo;
		
		///<summary>
		///订单编号
		///</summary>
		public Guid OrderID
		{
			get { return Guid.Parse(_context.Request["OrderID"]);}
			set { this.orderID = value; }
		}
		private Guid orderID;
		
		///<summary>
		///柜ID
		///</summary>
		public Guid CabinetID
		{
			get { return Guid.Parse(_context.Request["CabinetID"]);}
			set { this.cabinetID = value; }
		}
		private Guid cabinetID;
		
		///<summary>
		///柜号
		///</summary>
		public string CabinetNum
		{
			get { return Convert.ToString(_context.Request["CabinetNum"]);}
			set { this.cabinetNum = value; }
		}
		private string cabinetNum;
		
		///<summary>
		///材料ID
		///</summary>
		public Guid MaterialID
		{
			get { return Guid.Parse(_context.Request["MaterialID"]);}
			set { this.materialID = value; }
		}
		private Guid materialID;
		
		///<summary>
		///数量
		///</summary>
		public decimal Qty
		{
			get { return Convert.ToDecimal(_context.Request["Qty"]);}
			set { this.qty = value; }
		}
		private decimal qty;
		
		///<summary>
		///备注
		///</summary>
		public string Remarks
		{
			get { return Convert.ToString(_context.Request["Remarks"]);}
			set { this.remarks = value; }
		}
		private string remarks;
		
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
