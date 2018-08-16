using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace MES.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-08-15 11:45:50。
	/// </summary>
	public class Material2SupplierParm
	{
		private HttpContext _context;
		public Material2SupplierParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///
		///</summary>
		public Guid MaterialID
		{
			get { return Guid.Parse(_context.Request["MaterialID"]);}
			set { this.materialID = value; }
		}
		private Guid materialID;
		
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
		///
		///</summary>
		public decimal Price
		{
			get { return Convert.ToDecimal(_context.Request["Price"]);}
			set { this.price = value; }
		}
		private decimal price;
		
		///<summary>
		///最小采购量
		///</summary>
		public int MinPurchaseQty
		{
			get { return Convert.ToInt32(_context.Request["MinPurchaseQty"]);}
			set { this.minPurchaseQty = value; }
		}
		private int minPurchaseQty;
		
		///<summary>
		///最小交期
		///</summary>
		public int MinDelivery
		{
			get { return Convert.ToInt32(_context.Request["MinDelivery"]);}
			set { this.minDelivery = value; }
		}
		private int minDelivery;
	}
}
