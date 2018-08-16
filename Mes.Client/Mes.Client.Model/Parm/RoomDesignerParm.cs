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
	public class RoomDesignerParm
	{
		private HttpContext _context;
		public RoomDesignerParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///
		///</summary>
		public Guid DesignerID
		{
			get { return Guid.Parse(_context.Request["DesignerID"]);}
			set { this.designerID = value; }
		}
		private Guid designerID;
		
		///<summary>
		///
		///</summary>
		public Guid CustomerID
		{
			get { return Guid.Parse(_context.Request["CustomerID"]);}
			set { this.customerID = value; }
		}
		private Guid customerID;
		
		///<summary>
		///设计师（员工ID）
		///</summary>
		public Guid Designer
		{
			get { return Guid.Parse(_context.Request["Designer"]);}
			set { this.designer = value; }
		}
		private Guid designer;
		
		///<summary>
		///量尺时间
		///</summary>
		public DateTime Designed
		{
			get {
                return string.IsNullOrEmpty(_context.Request["Designed"])?DateTime.Now:Convert.ToDateTime(_context.Request["Designed"]);
            }
			set { this.designed = value; }
		}
		private DateTime designed;
		
		///<summary>
		///房间数
		///</summary>
		public int Rooms
		{
            get
            {
                return string.IsNullOrEmpty(_context.Request["Rooms"]) ?0: Convert.ToInt32(_context.Request["Rooms"]);
            }
            set { this.rooms = value; }
		}
		private int rooms;
		
		///<summary>
		///客厅和餐厅数
		///</summary>
		public int SittingAndDiningRoom
		{
            get
            {
                return string.IsNullOrEmpty(_context.Request["SittingAndDiningRoom"]) ? 0 : Convert.ToInt32(_context.Request["SittingAndDiningRoom"]);
            }
            set { this.sittingAndDiningRoom = value; }
		}
		private int sittingAndDiningRoom;
		
		///<summary>
		///房屋面积
		///</summary>
		public int TotalAreal
		{
            get
            {
                return string.IsNullOrEmpty(_context.Request["TotalAreal"]) ? 0 : Convert.ToInt32(_context.Request["TotalAreal"]);
            }
            set { this.totalAreal = value; }
		}
		private int totalAreal;
		
		///<summary>
		///
		///</summary>
		public int FamilyMembers
		{
            get
            {
                return string.IsNullOrEmpty(_context.Request["FamilyMembers"]) ? 0 : Convert.ToInt32(_context.Request["FamilyMembers"]);
            }
            set { this.familyMembers = value; }
		}
		private int familyMembers;
		
		///<summary>
		///预算
		///</summary>
		public decimal Budget
		{
            get
            {
                return string.IsNullOrEmpty(_context.Request["Budget"]) ? 0 : Convert.ToDecimal(_context.Request["Budget"]);
            }
            set { this.budget = value; }
		}
		private decimal budget;
		
		///<summary>
		///所住小区名称
		///</summary>
		public string VillageName
		{
			get { return Convert.ToString(_context.Request["VillageName"]);}
			set { this.villageName = value; }
		}
		private string villageName;
		
		///<summary>
		///栋数(号数)
		///</summary>
		public string Building
		{
			get { return Convert.ToString(_context.Request["Building"]);}
			set { this.building = value; }
		}
		private string building;
		
		///<summary>
		///所在单元
		///</summary>
		public string Unit
		{
			get { return Convert.ToString(_context.Request["Unit"]);}
			set { this.unit = value; }
		}
		private string unit;
		
		///<summary>
		///房号
		///</summary>
		public string RoomNo
		{
			get { return Convert.ToString(_context.Request["RoomNo"]);}
			set { this.roomNo = value; }
		}
		private string roomNo;
		
		///<summary>
		///喜欢颜色
		///</summary>
		public string Color
		{
			get { return Convert.ToString(_context.Request["Color"]);}
			set { this.color = value; }
		}
		private string color;
		
		///<summary>
		///装修风格
		///</summary>
		public string Style
		{
			get { return Convert.ToString(_context.Request["Style"]);}
			set { this.style = value; }
		}
		private string style;
		
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
		///状态（N，新客户；C：已取消；F，已成交；W,跟进中)
		///</summary>
		public string Status
		{
			get { return Convert.ToString(_context.Request["Status"]);}
			set { this.status = value; }
		}
		private string status;
		
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
