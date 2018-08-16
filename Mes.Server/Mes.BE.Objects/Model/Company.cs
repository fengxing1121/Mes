using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:24:59。
	/// </summary>
	[Serializable]
	[DataContract(Name = "Company")]
	public class Company
    {
		public Company()
		{
		}
		
		/// <summary>
		///合作商ID
		/// </summary>
		[DataMember(Name = "CompanyID")]
		public Guid CompanyID
        {
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "CompanyCode")]
		public string CompanyCode
        {
			get;
			set;
		}
		
		/// <summary>
		///合作商名称
		/// </summary>
		[DataMember(Name = "CompanyName")]
		public string CompanyName
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
		///详细地址
		/// </summary>
		[DataMember(Name = "Address")]
		public string Address
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
		///固定电话
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
		///
		/// </summary>
		[DataMember(Name = "Fax")]
		public string Fax
		{
			get;
			set;
		}
		
		/// <summary>
		///店铺大小（平方米）
		/// </summary>
		[DataMember(Name = "ShopSize")]
		public int ShopSize
		{
			get;
			set;
		}
		
		/// <summary>
		///合作商类型（1.直营；2.加盟；3.合资）
		/// </summary>
		[DataMember(Name = "ShopType")]
		public string ShopType
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
		///
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

        /// <summary>
        ///经销商等级
        /// </summary>
        [DataMember(Name = "Grade")]
        public string Grade { get; set; }


        /// <summary>
        ///折扣率
        /// </summary>
        [DataMember(Name = "Amount")]
        public decimal Amount { get; set; }
        /// <summary>
        ///折扣率
        /// </summary>
        [DataMember(Name = "Score")]
        public decimal Score { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DataMember(Name = "Sort")]
        public int Sort { get; set; }

    }
}
