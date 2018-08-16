using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
    /// <summary>
    /// 代码工具生成，不可以手工修改。2016-10-18 16:57:58。
    /// </summary>
    public class ComponentTypeParm
    {
        private HttpContext _context;
        public ComponentTypeParm(HttpContext context)
        {
            this._context = context;
        }

        ///<summary>
        ///组件类型ID
        ///</summary>
        public int ComponentTypeID
        {
            get { return Convert.ToInt32(_context.Request["ComponentTypeID"]); }
            set { this.componentTypeID = value; }
        }
        private int componentTypeID;

        ///<summary>
        ///组件类型名称
        ///</summary>
        public string ComponentTypeName
        {
            get { return Convert.ToString(_context.Request["ComponentTypeName"]); }
            set { this.componentTypeName = value; }
        }
        private string componentTypeName;

        ///<summary>
        ///组件类型编码(A、B、C)
        ///</summary>
        public string ComponentTypeCode
        {
            get { return Convert.ToString(_context.Request["ComponentTypeCode"]); }
            set { this.componentTypeCode = value; }
        }
        private string componentTypeCode;

        /// <summary>
        /// 组件类型父节点
        /// </summary>
        public int ParentID
        {
            get { return Convert.ToInt32(_context.Request["ParentID"]); }
            set { this.parentID = value; }
        }
        private int parentID;

        ///<summary>
        ///禁用标志
        ///</summary>
        public bool Status
        {
            get { return Convert.ToBoolean(_context.Request["Status"]); }
            set { this.status = value; }
        }
        private bool status;

        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime Created
        {
            get { return Convert.ToDateTime(_context.Request["Created"]); }
            set { this.created = value; }
        }
        private DateTime created;

        ///<summary>
        ///创建人
        ///</summary>
        public string CreatedBy
        {
            get { return Convert.ToString(_context.Request["CreatedBy"]); }
            set { this.createdBy = value; }
        }
        private string createdBy;
    }
}
