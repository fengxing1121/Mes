using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class ProductWarehouseMainParm
    {
        private HttpContext _context;
        public ProductWarehouseMainParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///
		///</summary>
		public Guid InID
		{
			get { return Guid.Parse(_context.Request["InID"]);}
			set { this.inID = value; }
		}
		private Guid inID;
		
		///<summary>
		///单号
		///</summary>
		public string BillNo
		{
			get { return Convert.ToString(_context.Request["BillNo"]);}
			set { this.billNo = value; }
		}
		private string billNo;
		 
		///<summary>
		///订单ID
		///</summary>
        public Guid OrderID
		{
            get { return Guid.Parse(_context.Request["OrderID"]); }
            set { this.orderID = value; }
		}
        private Guid orderID;
		 
		
		///<summary>
		///
		///</summary>
		public DateTime Created
		{
			get { return  Convert.ToDateTime(_context.Request["Created"]);}
			set { this.created = value; }
		}
		private DateTime created;
		
		///<summary>
		///
		///</summary>
		public string CreatedBy
		{
			get { return Convert.ToString(_context.Request["CreatedBy"]);}
			set { this.createdBy = value; }
		}
		private string createdBy;
		
		///<summary>
		///
		///</summary>
		public DateTime Modified
		{
			get { return  Convert.ToDateTime(_context.Request["Modified"]);}
			set { this.modified = value; }
		}
		private DateTime modified;
		
		///<summary>
		///
		///</summary>
		public string ModifiedBy
		{
			get { return Convert.ToString(_context.Request["ModifiedBy"]);}
			set { this.modifiedBy = value; }
		}
		private string modifiedBy;
    }
}