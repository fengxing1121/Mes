using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class PartnerUserGroupParm
    {
        private HttpContext _context=null;

        public PartnerUserGroupParm(HttpContext context) 
        {
            this._context = context;
        }

        public Guid GroupID 
        {
            get { return Guid.Parse(_context.Request["GroupID"]); }
            set { this.groupID = value; }
        }
        private Guid groupID;

        public string GroupName 
        {
            get { return Convert.ToString(_context.Request["GroupName"]); }
            set { this.groupName = value; }
        }
        private string groupName;

        public string Description 
        {
            get { return Convert.ToString(_context.Request["Description"]); }
            set { this.description = value; }
        }
        private string description;

        public bool IsDisabled 
        {
            get { return Convert.ToBoolean(_context.Request["IsDisabled"]); }
            set { this.isDisabled = value; }
        }
        private bool isDisabled;

        public bool IsLocked
        {
            get { return Convert.ToBoolean(_context.Request["IsDisabled"]); }
            set { this.isLocked = value; }
        }
        private bool isLocked;
    }
}