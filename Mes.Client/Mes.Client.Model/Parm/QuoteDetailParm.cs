using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-26 17:30:46。
	/// </summary>
	public class QuoteDetailParm
	{
		private HttpContext _context;
		public QuoteDetailParm(HttpContext context)
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
		public Guid QuoteID
		{
			get { return Guid.Parse(_context.Request["QuoteID"]);}
			set { this.quoteID = value; }
		}
		private Guid quoteID;
		
		///<summary>
		///
		///</summary>
		public string ItemGroup
		{
			get { return Convert.ToString(_context.Request["ItemGroup"]);}
			set { this.itemGroup = value; }
		}
		private string itemGroup;
		
		///<summary>
		///
		///</summary>
		public string ItemName
		{
			get { return Convert.ToString(_context.Request["ItemName"]);}
			set { this.itemName = value; }
		}
		private string itemName;
		
		///<summary>
		///
		///</summary>
		public string ItemStyle
		{
			get { return Convert.ToString(_context.Request["ItemStyle"]);}
			set { this.itemStyle = value; }
		}
		private string itemStyle;
		
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
		
		///<summary>
		///
		///</summary>
		public string ItemRemark
		{
			get { return Convert.ToString(_context.Request["ItemRemark"]);}
			set { this.itemRemark = value; }
		}
		private string itemRemark;
	}
}
