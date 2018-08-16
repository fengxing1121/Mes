using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class TransportDetailParm
    {
        private HttpContext _context;
        public TransportDetailParm(HttpContext context)
		{
			this._context = context;
		}
		 
		///<summary>
		///运输ID
		///</summary>
        public Guid TransportID
		{
            get { return Guid.Parse(_context.Request["TransportID"]); }
            set { this.transportID = value; }
		}
        private Guid transportID;

        ///<summary>
        ///订单ID
        ///</summary>
        public Guid OrderID
        {
            get { return Guid.Parse(_context.Request["OrderID"]); }
            set { this.orderID = value; }
        }
        private Guid orderID;
    }
}