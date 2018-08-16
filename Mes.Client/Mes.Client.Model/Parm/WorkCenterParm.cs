using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-12-20 14:41:26。
	/// </summary>
	public class WorkCenterParm
	{
		private HttpContext _context;
		public WorkCenterParm(HttpContext context)
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
		///设备ID
		///</summary>
		public Guid WorkCenterID
		{
			get { return Guid.Parse(_context.Request["WorkCenterID"]);}
			set { this.workCenterID = value; }
		}
		private Guid workCenterID;
		
		///<summary>
		///生产车间ID
		///</summary>
		public Guid WorkShopID
		{
			get { return Guid.Parse(_context.Request["WorkShopID"]);}
			set { this.workShopID = value; }
		}
		private Guid workShopID;
		
		///<summary>
		///设备编号
		///</summary>
		public string WorkCenterCode
		{
			get { return Convert.ToString(_context.Request["WorkCenterCode"]);}
			set { this.workCenterCode = value; }
		}
		private string workCenterCode;
		
		///<summary>
		///设备名称
		///</summary>
		public string WorkCenterName
		{
			get { return Convert.ToString(_context.Request["WorkCenterName"]);}
			set { this.workCenterName = value; }
		}
		private string workCenterName;
		
		///<summary>
		///对应生产工序ID
		///</summary>
		public Guid WorkFlowID
		{
			get { return Guid.Parse(_context.Request["WorkFlowID"]);}
			set { this.workFlowID = value; }
		}
		private Guid workFlowID;
		
		///<summary>
		///最大产能（小时）
		///</summary>
		public int MaxCapacity
		{
			get { return Convert.ToInt32(_context.Request["MaxCapacity"]);}
			set { this.maxCapacity = value; }
		}
		private int maxCapacity;
		
		///<summary>
		///最大产能计算方式
		///</summary>
		public string CountCapacityType
		{
			get { return Convert.ToString(_context.Request["CountCapacityType"]);}
			set { this.countCapacityType = value; }
		}
		private string countCapacityType;
		
		///<summary>
		///
		///</summary>
		public string Style
		{
			get { return Convert.ToString(_context.Request["Style"]);}
			set { this.style = value; }
		}
		private string style;
		
		///<summary>
		///
		///</summary>
		public string Model
		{
			get { return Convert.ToString(_context.Request["Model"]);}
			set { this.model = value; }
		}
		private string model;
		
		///<summary>
		///备注
		///</summary>
		public string Remark
		{
			get { return Convert.ToString(_context.Request["Remark"]);}
			set { this.remark = value; }
		}
		private string remark;
		
		///<summary>
		///排序编号
		///</summary>
		public int Sequence
		{
			get { return Convert.ToInt32(_context.Request["Sequence"]);}
			set { this.sequence = value; }
		}
		private int sequence;
		
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
