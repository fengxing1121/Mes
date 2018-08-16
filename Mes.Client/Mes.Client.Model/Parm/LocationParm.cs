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
	public class LocationParm
	{
		private HttpContext _context;
		public LocationParm(HttpContext context)
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
		public Guid LocationID
		{
			get { return Guid.Parse(_context.Request["LocationID"]);}
			set { this.locationID = value; }
		}
		private Guid locationID;
		
		///<summary>
		///所属仓库ID
		///</summary>
		public Guid WarehouseID
		{
			get { return Guid.Parse(_context.Request["WarehouseID"]);}
			set { this.warehouseID = value; }
		}
		private Guid warehouseID;
		
		///<summary>
		///所属仓库
		///</summary>
		public string Category
		{
			get { return Convert.ToString(_context.Request["Category"]);}
			set { this.category = value; }
		}
		private string category;
		
		///<summary>
		///仓位编号
		///</summary>
		public string LocationCode
		{
			get { return Convert.ToString(_context.Request["LocationCode"]);}
			set { this.locationCode = value; }
		}
		private string locationCode;
		
		///<summary>
		///最大重量
		///</summary>
		public decimal MaxWeight
		{
			get { return Convert.ToDecimal(_context.Request["MaxWeight"]);}
			set { this.maxWeight = value; }
		}
		private decimal maxWeight;
		
		///<summary>
		///最大包数/件数
		///</summary>
		public int MaxPackage
		{
			get { return Convert.ToInt32(_context.Request["MaxPackage"]);}
			set { this.maxPackage = value; }
		}
		private int maxPackage;
		
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
		///层号
		///</summary>
		public string LayerNum
		{
			get { return Convert.ToString(_context.Request["LayerNum"]);}
			set { this.layerNum = value; }
		}
		private string layerNum;
		
		///<summary>
		///
		///</summary>
		public bool IsDisabled
		{
			get { return Convert.ToBoolean(_context.Request["IsDisabled"]);}
			set { this.isDisabled = value; }
		}
		private bool isDisabled;
		
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
