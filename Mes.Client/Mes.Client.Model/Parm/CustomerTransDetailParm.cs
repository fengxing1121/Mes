using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class CustomerTransDetailParm
    {
        private HttpContext _context;
        public CustomerTransDetailParm(HttpContext context)
        {
            this._context = context;
        }

        public Guid QuoteID 
        {
            get
            {
                return Guid.Parse(_context.Request["QuoteID"]);
            }
            set
            {
                this.quoteID = value;
            }
        }
        private Guid quoteID;

        public Guid CustomerID 
        {
            get 
            {
                return Guid.Parse(_context.Request["CustomerID"].ToString());
            }
            set 
            {
                this.customerID = value;
            }
        }
        private Guid customerID;

        public string Payee 
        {           
            get 
            {
                return _context.Request["Payee"].ToString();
            }
            set 
            {
                this.payee = value;
            }
        }
        private string payee;

        public decimal Amount 
        {
            get
            {
                return decimal.Parse(_context.Request["Amount"].ToString());
            }
            set
            {
                this.amount = value;
            }
        }
        private decimal amount;

        public string VoucherNo 
        {
            get
            {
                return _context.Request["VoucherNo"].ToString();
            }
            set
            {
                this.voucherNo = value;
            }
        }
        private string voucherNo;

        public DateTime TransDate 
        {
            get
            {
                return DateTime.Parse(_context.Request["TransDate"]);
            }
            set
            {
                this.transDate = value;
            }
        }
        private DateTime transDate;
    }
}