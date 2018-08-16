using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class TransportMainParm
    {
        private HttpContext _context;
        public TransportMainParm(HttpContext context)
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
		///运输单号
		///</summary>
        public string TransportNo
		{
            get { return Convert.ToString(_context.Request["TransportNo"]); }
            set { this.transportNo = value; }
		}
        private string transportNo;
		
		///<summary>
		///车ID
		///</summary>
        public Guid CarID
		{
            get { return Guid.Parse(_context.Request["CarID"]); }
            set { this.carID = value; }
		}
        private Guid carID;
		
		///<summary>
		///出发地
		///</summary>
        public string Source
		{
            get { return Convert.ToString(_context.Request["Source"]); }
            set { this.source = value; }
		}
        private string source;

        ///<summary>
        ///目的地
        ///</summary>
        public string Target
        {
            get { return Convert.ToString(_context.Request["Target"]); }
            set { this.target = value; }
        }
        private string target;
		///<summary>
		///运输费用
		///</summary>
        public decimal Price
		{
            get { return Convert.ToDecimal(_context.Request["Price"]); }
            set { this.price = value; }
		}
        private decimal price;
		
		///<summary>
		///创建时间
		///</summary>
		public DateTime Created
		{
			get { return  Convert.ToDateTime(_context.Request["Created"]);}
			set { this.created = value; }
		}
		private DateTime created;
		
		///<summary>
		///创建人
		///</summary>
		public string CreatedBy
		{
			get { return Convert.ToString(_context.Request["CreatedBy"]);}
			set { this.createdBy = value; }
		}
		private string createdBy;
		 
    }
}