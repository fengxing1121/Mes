using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-04-06 21:37:39。
	/// </summary>
	public class Solution2HardwareParm
	{
		private HttpContext _context;
		public Solution2HardwareParm(HttpContext context)
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
		public Guid SolutionID
		{
			get { return Guid.Parse(_context.Request["SolutionID"]);}
			set { this.solutionID = value; }
		}
		private Guid solutionID;
		
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
		///五金编号
		///</summary>
		public string HardwareCode
		{
			get { return Convert.ToString(_context.Request["HardwareCode"]);}
			set { this.hardwareCode = value; }
		}
		private string hardwareCode;
		
		///<summary>
		///名称
		///</summary>
		public string HardwareName
		{
			get { return Convert.ToString(_context.Request["HardwareName"]);}
			set { this.hardwareName = value; }
		}
		private string hardwareName;
		
		///<summary>
		///类型
		///</summary>
		public string HardwareCategory
		{
			get { return Convert.ToString(_context.Request["HardwareCategory"]);}
			set { this.hardwareCategory = value; }
		}
		private string hardwareCategory;
		
		///<summary>
		///型号
		///</summary>
		public string Style
		{
			get { return Convert.ToString(_context.Request["Style"]);}
			set { this.style = value; }
		}
		private string style;
		
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
		public string Unit
		{
			get { return Convert.ToString(_context.Request["Unit"]);}
			set { this.unit = value; }
		}
		private string unit;
		
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
