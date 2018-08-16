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
	[DataContract(Name = "OrderStep")]
	public class OrderStep
    {
		public OrderStep()
		{
		}
        /// <summary>
        ///节点主键
        /// </summary>
        [DataMember(Name = "StepID")]
        public Guid StepID
        {
            get;
            set;
        }
        /// <summary>
        ///节点关联的菜单ID
        /// </summary>
        [DataMember(Name = "PrivilegeID")]
		public Guid PrivilegeID
		{
			get;
			set;
		}
		
		/// <summary>
		///节点顺序
		/// </summary>
		[DataMember(Name = "StepNo")]
		public int StepNo
        {
			get;
			set;
		}

        /// <summary>
        ///节点名称
        /// </summary>
        [DataMember(Name = "StepName")]
		public string StepName
        {
			get;
			set;
		}

        /// <summary>
        ///节点编号
        /// </summary>
        [DataMember(Name = "StepCode")]
        public string StepCode
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
		
	}
}
