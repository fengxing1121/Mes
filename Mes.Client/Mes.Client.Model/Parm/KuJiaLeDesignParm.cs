using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class KuJiaLeDesignParm
    {
        private HttpContext _context;
        public KuJiaLeDesignParm(HttpContext context)
        {
            this._context = context;
        }

        private int dest;
        public int Dest
        {
            get { return Convert.ToInt32(_context.Request["Dest"]); }
            set { this.dest = value; }
        }

        public string designId;
        public string DesignId
        {
            get { return Convert.ToString(_context.Request["DesignId"]); }
            set { this.designId = value; }
        }

        public string planId;
        public string PlanId
        {
            get { return Convert.ToString(_context.Request["PlanId"]); }
            set { this.planId = value; }
        }
    }
}