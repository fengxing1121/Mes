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
	public class WarehouseParm
	{
		private HttpContext _context;
		public WarehouseParm(HttpContext context)
		{
			this._context = context;
		}
		
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
		///存储位置
		///</summary>
		public Guid LocationID
		{
			get { return Guid.Parse(_context.Request["LocationID"]);}
			set { this.locationID = value; }
		}
		private Guid locationID;
		
		///<summary>
		///
		///</summary>
		public decimal Qty
		{
			get { return Convert.ToDecimal(_context.Request["Qty"]);}
			set { this.qty = value; }
		}
		private decimal qty;
		
		///<summary>
		///
		///</summary>
		public decimal Price
		{
			get { return Convert.ToDecimal(_context.Request["Price"]);}
			set { this.price = value; }
		}
		private decimal price;
	}
}
