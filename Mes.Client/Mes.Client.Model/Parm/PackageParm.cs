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
	public class PackageParm
	{
		private HttpContext _context;
		public PackageParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///包装箱ID
		///</summary>
		public Guid PackageID
		{
			get { return Guid.Parse(_context.Request["PackageID"]);}
			set { this.packageID = value; }
		}
		private Guid packageID;
		
		///<summary>
		///包装箱条码
		///</summary>
		public string PackageBarcode
		{
			get { return Convert.ToString(_context.Request["PackageBarcode"]);}
			set { this.packageBarcode = value; }
		}
		private string packageBarcode;
		
		///<summary>
		///
		///</summary>
		public Guid OrderID
		{
			get { return Guid.Parse(_context.Request["OrderID"]);}
			set { this.orderID = value; }
		}
		private Guid orderID;
		
		///<summary>
		///
		///</summary>
		public Guid CabinetID
		{
			get { return Guid.Parse(_context.Request["CabinetID"]);}
			set { this.cabinetID = value; }
		}
		private Guid cabinetID;
		
		///<summary>
		///包装箱编号
		///</summary>
		public int PackageNum
		{
			get { return Convert.ToInt32(_context.Request["PackageNum"]);}
			set { this.packageNum = value; }
		}
		private int packageNum;
		
		///<summary>
		///宽度
		///</summary>
		public decimal Width
		{
			get { return Convert.ToDecimal(_context.Request["Width"]);}
			set { this.width = value; }
		}
		private decimal width;
		
		///<summary>
		///厚度
		///</summary>
		public decimal Height
		{
			get { return Convert.ToDecimal(_context.Request["Height"]);}
			set { this.height = value; }
		}
		private decimal height;
		
		///<summary>
		///长度
		///</summary>
		public decimal Length
		{
			get { return Convert.ToDecimal(_context.Request["Length"]);}
			set { this.length = value; }
		}
		private decimal length;
		
		///<summary>
		///重量
		///</summary>
		public decimal Weight
		{
			get { return Convert.ToDecimal(_context.Request["Weight"]);}
			set { this.weight = value; }
		}
		private decimal weight;
		
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
	}
}
