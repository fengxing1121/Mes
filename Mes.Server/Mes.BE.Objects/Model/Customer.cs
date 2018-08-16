using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:24:55。
	/// </summary>
	[Serializable]
	[DataContract(Name = "Customer")]
	public class Customer
	{
		public Customer()
		{
		}
		
		/// <summary>
		///客户ID
		/// </summary>
		[DataMember(Name = "CustomerID")]
		public Guid CustomerID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "PartnerID")]
		public Guid PartnerID
		{
			get;
			set;
		}
		
		/// <summary>
		///客户名称
		/// </summary>
		[DataMember(Name = "CustomerName")]
		public string CustomerName
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Province")]
		public string Province
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "City")]
		public string City
		{
			get;
			set;
		}
		
		/// <summary>
		///联系人
		/// </summary>
		[DataMember(Name = "LinkMan")]
		public string LinkMan
		{
			get;
			set;
		}
		
		/// <summary>
		///联系人职位
		/// </summary>
		[DataMember(Name = "Position")]
		public string Position
		{
			get;
			set;
		}
		
		/// <summary>
		///地址
		/// </summary>
		[DataMember(Name = "Address")]
		public string Address
		{
			get;
			set;
		}
		
		/// <summary>
		///电话
		/// </summary>
		[DataMember(Name = "Tel")]
		public string Tel
		{
			get;
			set;
		}
		
		/// <summary>
		///手机
		/// </summary>
		[DataMember(Name = "Mobile")]
		public string Mobile
		{
			get;
			set;
		}
		
		/// <summary>
		///传真
		/// </summary>
		[DataMember(Name = "Fax")]
		public string Fax
		{
			get;
			set;
		}
		
		/// <summary>
		///邮箱
		/// </summary>
		[DataMember(Name = "Email")]
		public string Email
		{
			get;
			set;
		}
		
		/// <summary>
		///主页
		/// </summary>
		[DataMember(Name = "HomePage")]
		public string HomePage
		{
			get;
			set;
		}
		
		/// <summary>
		///备注说明
		/// </summary>
		[DataMember(Name = "Remark")]
		public string Remark
		{
			get;
			set;
		}
		
		/// <summary>
		///创建时间
		/// </summary>
		[DataMember(Name = "Created")]
		public DateTime Created
		{
			get;
			set;
		}
		
		/// <summary>
		///创建人
		/// </summary>
		[DataMember(Name = "CreatedBy")]
		public string CreatedBy
		{
			get;
			set;
		}
		
		/// <summary>
		///修改时间
		/// </summary>
		[DataMember(Name = "Modified")]
		public DateTime Modified
		{
			get;
			set;
		}
		
		/// <summary>
		///修改人
		/// </summary>
		[DataMember(Name = "ModifiedBy")]
		public string ModifiedBy
		{
			get;
			set;
		}

        [DataMember(Name = "PartnerName")]
        public string PartnerName
        {
            get;
            set;
        }
    }
}
