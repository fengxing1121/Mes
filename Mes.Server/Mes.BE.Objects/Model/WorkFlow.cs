using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// [BE_WorkFlow]工序档案
    /// </summary>
    [Serializable]
    [DataContract(Name = "WorkFlow")]
    public class WorkFlow
    {
        public WorkFlow()
        {

        }

        /// <summary>
        ///主键ID
        /// </summary>
        [DataMember(Name = "WorkFlowID")]
        public Guid WorkFlowID { set; get; }

        /// <summary>
        ///工序编号
        /// </summary>
        [DataMember(Name = "WorkFlowCode")]
        public string WorkFlowCode { set; get; }

        /// <summary>
        ///工序名称
        /// </summary>
        [DataMember(Name = "WorkFlowName")]
        public string WorkFlowName { set; get; }

        /// <summary>
        ///图片
        /// </summary>
        [DataMember(Name = "ImageUrl")]
        public string ImageUrl { set; get; }

        /// <summary>
        ///备注
        /// </summary>
        [DataMember(Name = "Remark")]
        public string Remark { set; get; }

        /// <summary>
        ///排序
        /// </summary>
        [DataMember(Name = "SortNo")]
        public int SortNo { set; get; }

        /// <summary>
        ///创建时间
        /// </summary>
        [DataMember(Name = "Created")]
        public DateTime Created { set; get; }

        /// <summary>
        ///创建人
        /// </summary>
        [DataMember(Name = "CreatedBy")]
        public string CreatedBy { set; get; }

    }
}

