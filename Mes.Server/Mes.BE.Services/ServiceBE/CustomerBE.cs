using Mes.BE.Objects;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Mes.BE.Services
{
    public partial class ServiceBE : IServiceBE
    {
        public void SaveCustomer(Sender sender, SaveCustomerArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Customer obj = new Customer();
                    obj.CustomerID = args.Customer.CustomerID;
                    if (op.LoadCustomerByCustomerID(obj) == 0)
                    {
                        args.Customer.Created = DateTime.Now;
                        args.Customer.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.Customer.Modified = DateTime.Now;
                        args.Customer.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertCustomer(args.Customer);
                    }
                    else
                    {
                        args.Customer.Modified = DateTime.Now;
                        args.Customer.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateCustomerByCustomerID(args.Customer);
                    }
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public Customer GetCustomer(Sender sender, Guid CustomerID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Customer obj = new Customer();
                    obj.CustomerID = CustomerID;
                    if (op.LoadCustomerByCustomerID(obj) == 0)
                    {
                        return null;
                    }
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<Customer> GetCustomers(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadCustomers();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchCustomer(Sender sender, SearchCustomerArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchCustomer(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
    }
}
