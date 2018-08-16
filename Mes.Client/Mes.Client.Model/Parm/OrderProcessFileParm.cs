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
	public class OrderProcessFileParm
	{
		private HttpContext _context;
		public OrderProcessFileParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///
		///</summary>
		public Guid FileID
		{
			get { return Guid.Parse(_context.Request["FileID"]);}
			set { this.fileID = value; }
		}
		private Guid fileID;
		
		///<summary>
		///文件类型（BOM文件\五金文件\加工后置文件\效果图)
		///</summary>
		public string FileType
		{
			get { return Convert.ToString(_context.Request["FileType"]);}
			set { this.fileType = value; }
		}
		private string fileType;
		
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
		///
		///</summary>
		public string FileName
		{
			get { return Convert.ToString(_context.Request["FileName"]);}
			set { this.fileName = value; }
		}
		private string fileName;
		
		///<summary>
		///
		///</summary>
		public string FilePath
		{
			get { return Convert.ToString(_context.Request["FilePath"]);}
			set { this.filePath = value; }
		}
		private string filePath;
		
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
