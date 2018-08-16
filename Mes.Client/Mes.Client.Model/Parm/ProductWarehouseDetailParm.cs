using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class ProductWarehouseDetailParm
    {
        private HttpContext _context;
        public ProductWarehouseDetailParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///
		///</summary>
		public Guid DetailID
		{
			get { return Guid.Parse(_context.Request["DetailID"]);}
			set { this.detailID = value; }
		}
		private Guid detailID;
		
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
		///包ID
		///</summary>
        public Guid PackageID
		{
            get { return Guid.Parse(_context.Request["PackageID"]); }
            set { this.packageID = value; }
		}
        private Guid packageID;
		 
		///<summary>
		///仓位ID
		///</summary>
		public Guid LocationID
		{
			get { return Guid.Parse(_context.Request["LocationID"]);}
			set { this.locationID = value; }
		}
		private Guid locationID;

        ///<summary>
        ///
        ///</summary>
        public DateTime Created
        {
            get { return Convert.ToDateTime(_context.Request["Created"]); }
            set { this.created = value; }
        }
        private DateTime created;

        ///<summary>
        ///
        ///</summary>
        public string CreatedBy
        {
            get { return Convert.ToString(_context.Request["CreatedBy"]); }
            set { this.createdBy = value; }
        }
        private string createdBy;
		
    }
}