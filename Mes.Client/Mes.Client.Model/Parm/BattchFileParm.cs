using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-01-11 14:40:28。
	/// </summary>
	public class BattchFileParm
	{
		private HttpContext _context;
		public BattchFileParm(HttpContext context)
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
		///
		///</summary>
		public string BattchNum
		{
			get { return Convert.ToString(_context.Request["BattchNum"]);}
			set { this.battchNum = value; }
		}
		private string battchNum;
		
		///<summary>
		///
		///</summary>
		public Guid WorkingLineID
		{
			get { return Guid.Parse(_context.Request["WorkingLineID"]);}
			set { this.workingLineID = value; }
		}
		private Guid workingLineID;
		
		///<summary>
		///
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
		public bool IsDownload
		{
			get { return Convert.ToBoolean(_context.Request["IsDownload"]);}
			set { this.isDownload = value; }
		}
		private bool isDownload;
		
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
