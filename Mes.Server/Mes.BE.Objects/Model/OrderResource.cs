//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Data;
//using System.Runtime.Serialization;

//using MES.Libraries;

//namespace Mes.BE.Objects
//{
//	/// <summary>
//	/// 代码工具生成，不可以手工修改。2017-05-17 15:24:58。
//	/// </summary>
//	[Serializable]
//	[DataContract(Name = "OrderResource")]
//	public class OrderResource
//	{
//		public OrderResource()
//		{
//		}
		
//		/// <summary>
//		///任务ID
//		/// </summary>
//		[DataMember(Name = "OrderID")]
//		public Guid OrderID
//		{
//			get;
//			set;
//		}
		
//		/// <summary>
//		///任务处理资源（角色/用户)
//		/// </summary>
//		[DataMember(Name = "Resource")]
//		public string Resource
//		{
//			get;
//			set;
//		}
		
//		/// <summary>
//		///任务开始时间
//		/// </summary>
//		[DataMember(Name = "Started")]
//		public DateTime Started
//		{
//			get;
//			set;
//		}
		
//		/// <summary>
//		///任务开始处理人
//		/// </summary>
//		[DataMember(Name = "StartedBy")]
//		public string StartedBy
//		{
//			get;
//			set;
//		}
//    }
//}
