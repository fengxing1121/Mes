using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:25:01。
	/// </summary>
	[Serializable]
	[DataContract(Name = "RoomDesigner")]
	public class RoomDesigner
	{
		public RoomDesigner()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "DesignerID")]
		public Guid DesignerID
		{
			get;
			set;
		}

        /// <summary>
        ///设计编码
        /// </summary>
        [DataMember(Name = "DesignerNo")]
        public string DesignerNo
        {
            get;
            set;
        }
        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "CustomerID")]
		public Guid CustomerID
		{
			get;
			set;
		}
		
		/// <summary>
		///设计师（员工ID）
		/// </summary>
		[DataMember(Name = "Designer")]
		public Guid Designer
		{
			get;
			set;
		}
		
		/// <summary>
		///量尺时间
		/// </summary>
		[DataMember(Name = "Designed")]
		public DateTime Designed
		{
			get;
			set;
		}
		
		/// <summary>
		///房间数
		/// </summary>
		[DataMember(Name = "Rooms")]
		public int Rooms
		{
			get;
			set;
		}
		
		/// <summary>
		///客厅和餐厅数
		/// </summary>
		[DataMember(Name = "SittingAndDiningRoom")]
		public int SittingAndDiningRoom
		{
			get;
			set;
		}
		
		/// <summary>
		///房屋面积
		/// </summary>
		[DataMember(Name = "TotalAreal")]
		public int TotalAreal
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "FamilyMembers")]
		public int FamilyMembers
		{
			get;
			set;
		}
		
		/// <summary>
		///预算
		/// </summary>
		[DataMember(Name = "Budget")]
		public decimal Budget
		{
			get;
			set;
		}
		
		/// <summary>
		///所住小区名称
		/// </summary>
		[DataMember(Name = "VillageName")]
		public string VillageName
		{
			get;
			set;
		}
		
		/// <summary>
		///栋数(号数)
		/// </summary>
		[DataMember(Name = "Building")]
		public string Building
		{
			get;
			set;
		}
		
		/// <summary>
		///所在单元
		/// </summary>
		[DataMember(Name = "Unit")]
		public string Unit
		{
			get;
			set;
		}
		
		/// <summary>
		///房号
		/// </summary>
		[DataMember(Name = "RoomNo")]
		public string RoomNo
		{
			get;
			set;
		}
		
		/// <summary>
		///喜欢颜色
		/// </summary>
		[DataMember(Name = "Color")]
		public string Color
		{
			get;
			set;
		}
		
		/// <summary>
		///装修风格
		/// </summary>
		[DataMember(Name = "Style")]
		public string Style
		{
			get;
			set;
		}
		
		/// <summary>
		///备注
		/// </summary>
		[DataMember(Name = "Remark")]
		public string Remark
		{
			get;
			set;
		}
		
		/// <summary>
		///状态（N，新客户；C：已取消；F，已成交；W,跟进中)
		/// </summary>
		[DataMember(Name = "Status")]
		public string Status
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Created")]
		public DateTime Created
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "CreatedBy")]
		public string CreatedBy
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Modified")]
		public DateTime Modified
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "ModifiedBy")]
		public string ModifiedBy
		{
			get;
			set;
		}
	}
}
