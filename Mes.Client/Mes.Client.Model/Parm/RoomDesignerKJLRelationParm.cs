using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-10-18 16:58:01。
	/// </summary>
	public class RoomDesignerKJLRelationParm
    {
		private HttpContext _context;
		public RoomDesignerKJLRelationParm(HttpContext context)
		{
			this._context = context;
		}
		
		public Guid ID
        {
			get { return Guid.Parse(_context.Request["ID"]);}
			set { this.id = value; }
		}
		private Guid id;
		
		public int DesignerNo
        {
			get { return Convert.ToInt32(_context.Request["DesignNo"]);}
			set { this.designerNo = value; }
		}
		private int designerNo;
		
		public string KJLDesignID
        {
			get { return Convert.ToString(_context.Request["DesignID"]);}
			set { this.kjlDesignID = value; }
		}
		private string kjlDesignID;
		
		public bool Status
		{
			get { return  Convert.ToBoolean(_context.Request["Status"]);}
			set { this.status = value; }
		}
		private bool status;
		
		
		public DateTime Created
		{
			get { return  Convert.ToDateTime(_context.Request["Created"]);}
			set { this.created = value; }
		}
		private DateTime created;
		
		public string CreatedBy
		{
			get { return Convert.ToString(_context.Request["CreatedBy"]);}
			set { this.createdBy = value; }
		}
		private string createdBy;
	}
}
