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
        public void SaveCustomerFollowUp(Sender sender, SaveCustomerFollowUpArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    CustomerFollowUp obj = new CustomerFollowUp();
                    obj.FollowID = args.CustomerFollowUp.FollowID;
                    if (op.LoadCustomerFollowUpByFollowID(obj) == 0)
                    {
                        args.CustomerFollowUp.Created = DateTime.Now;
                        args.CustomerFollowUp.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.CustomerFollowUp.Modified = DateTime.Now;
                        args.CustomerFollowUp.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertCustomerFollowUp(args.CustomerFollowUp);
                    }
                    else
                    {
                        args.CustomerFollowUp.Modified = DateTime.Now;
                        args.CustomerFollowUp.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateCustomerFollowUpByFollowID(args.CustomerFollowUp);
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
        public CustomerFollowUp GetCustomerFollowUp(Sender sender, Guid FollowID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    CustomerFollowUp obj = new CustomerFollowUp();
                    obj.FollowID = FollowID;
                    if (op.LoadCustomerFollowUpByFollowID(obj) == 0)
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
        public List<CustomerFollowUp> GetCustomerFollowUps(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadCustomerFollowUps();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchCustomerFollowUp(Sender sender, SearchCustomerFollowUpArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchCustomerFollowUp(args);
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
