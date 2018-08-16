using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-10-18 16:58:03。
	/// </summary>
	public class WorkShift2WorkShopParm
	{
		private HttpContext _context;
		public WorkShift2WorkShopParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///班组ID
		///</summary>
		public Guid WorkShiftID
		{
			get { return Guid.Parse(_context.Request["WorkShiftID"]);}
			set { this.workShiftID = value; }
		}
		private Guid workShiftID;
		
		///<summary>
		///车间ID
		///</summary>
		public Guid WorkShopID
		{
			get { return Guid.Parse(_context.Request["WorkShopID"]);}
			set { this.workShopID = value; }
		}
		private Guid workShopID;
	}
}
