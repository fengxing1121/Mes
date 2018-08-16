using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Model.Parm
{
    public class PartnerTransDetailParm
    {
        private HttpContext _context;
        public PartnerTransDetailParm(HttpContext context)
        {
            this._context = context;
        }

        public Guid OrderID 
        {
            get
            {
                return Guid.Parse(_context.Request["OrderID"].ToString());
            }
            set
            {
                this.orderID = value;
            }   
        }
        private Guid orderID;

        public Guid PartnerID 
        {
            get
            {
                return Guid.Parse(_context.Request["PartnerID"].ToString());
            }
            set
            {
                this.partnerID = value;
            }      
        }
        private Guid partnerID;

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