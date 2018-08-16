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
	public class Solution2CabinetParm
	{
		private HttpContext _context;
		public Solution2CabinetParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///产品ID
		///</summary>
		public Guid CabinetID
		{
			get { return Guid.Parse(_context.Request["CabinetID"]);}
			set { this.cabinetID = value; }
		}
		private Guid cabinetID;
		
		///<summary>
		///
		///</summary>
		public Guid SolutionID
		{
			get { return Guid.Parse(_context.Request["SolutionID"]);}
			set { this.solutionID = value; }
		}
		private Guid solutionID;
		
		///<summary>
		///产品名称
		///</summary>
		public string CabinetName
		{
			get { return Convert.ToString(_context.Request["CabinetName"]);}
			set { this.cabinetName = value; }
		}
		private string cabinetName;
		
		///<summary>
		///成品尺寸
		///</summary>
		public string Size
		{
			get { return Convert.ToString(_context.Request["Size"]);}
			set { this.size = value; }
		}
		private string size;
		
		///<summary>
		///主材料款式
		///</summary>
		public string MaterialStyle
		{
			get { return Convert.ToString(_context.Request["MaterialStyle"]);}
			set { this.materialStyle = value; }
		}
		private string materialStyle;
		
		///<summary>
		///
		///</summary>
		public string MaterialCategory
		{
			get { return Convert.ToString(_context.Request["MaterialCategory"]);}
			set { this.materialCategory = value; }
		}
		private string materialCategory;
		
		///<summary>
		///
		///</summary>
		public string Color
		{
			get { return Convert.ToString(_context.Request["Color"]);}
			set { this.color = value; }
		}
		private string color;
		
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
		///
		///</summary>
		public decimal Qty
		{
			get { return Convert.ToDecimal(_context.Request["Qty"]);}
			set { this.qty = value; }
		}
		private decimal qty;
		
		///<summary>
		///文件上传标志
		///</summary>
		public bool FileUploadFlag
		{
			get { return Convert.ToBoolean(_context.Request["FileUploadFlag"]);}
			set { this.fileUploadFlag = value; }
		}
		private bool fileUploadFlag;
		
		///<summary>
		///序号
		///</summary>
		public int Sequence
		{
			get { return Convert.ToInt32(_context.Request["Sequence"]);}
			set { this.sequence = value; }
		}
		private int sequence;
		
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
