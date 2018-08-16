using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class PartnerRoleParm
    {
        private HttpContext _context=null;

        public PartnerRoleParm(HttpContext context) 
        {
            this._context = context;
        }

        public Guid GroupID 
        {
            get { return Guid.Parse(_context.Request["GroupID"]); }
            set { this.groupID = value; }
        }
        private Guid groupID;

        public Guid RoleID 
        {
            get { return Guid.Parse(_context.Request["RoleID"]); }
            set { this.roleID = value; }
        }
        private Guid roleID;

        public string RoleName 
        {
            get { return Convert.ToString(_context.Request["RoleName"]); }
            set { this.roleName = value; }
        }
        private string roleName;

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