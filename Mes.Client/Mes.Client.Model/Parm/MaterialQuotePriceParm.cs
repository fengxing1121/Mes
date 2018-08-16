using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class MaterialQuotePriceParm
    {
        private HttpContext _context;
        public MaterialQuotePriceParm(HttpContext context) 
        {
            this._context = context;
        }

        public Guid MaterialID 
        {
            get { return Guid.Parse(_context.Request["MaterialID"]); }
            set { this.materialID = value; }
        }
        private Guid materialID;

        public decimal Price 
        {
            get { return Convert.ToDecimal(_context.Request["Price"]);}
            set { this.price = value; }
        }
        private decimal price;
    }
}