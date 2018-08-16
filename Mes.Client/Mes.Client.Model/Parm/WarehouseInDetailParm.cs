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
	public class WarehouseInDetailParm
	{
		private HttpContext _context;
		public WarehouseInDetailParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///
		///</summary>
		public Guid DetailID
		{
			get { return Guid.Parse(_context.Request["DetailID"]);}
			set { this.detailID = value; }
		}
		private Guid detailID;
		
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
		///物料ID
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
		///
		///</summary>
		public decimal Price
		{
			get { return Convert.ToDecimal(_context.Request["Price"]);}
			set { this.price = value; }
		}
		private decimal price;
		
		///<summary>
		///仓位ID
		///</summary>
		public Guid LocationID
		{
			get { return Guid.Parse(_context.Request["LocationID"]);}
			set { this.locationID = value; }
		}
		private Guid locationID;
	}
}
