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
        public void SavePartner(Sender sender, SavePartnerArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Partner obj = new Partner();
                    obj.PartnerID = args.Partner.PartnerID;
                    if (op.LoadPartnerByPartnerID(obj) == 0)
                    {
                        //string key = "P";
                        //int index = this.GetIncrease(sender, key);
                        //args.Partner.PartnerCode = key + index.ToString("0000");
                        args.Partner.Created = DateTime.Now;
                        args.Partner.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.Partner.Modified = DateTime.Now;
                        args.Partner.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertPartner(args.Partner);
                    }
                    else
                    {
                        args.Partner.Modified = DateTime.Now;
                        args.Partner.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdatePartnerByPartnerID(args.Partner);
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

        public Partner GetPartner(Sender sender, Guid PartnerID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Partner obj = new Partner();
                    obj.PartnerID = PartnerID;
                    if (op.LoadPartnerByPartnerID(obj) == 0)
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
        public Company GetCompany(Sender sender, Guid CompanyID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Company obj = new Company();
                    obj.CompanyID = CompanyID;
                    if (op.LoadCompanyByCompanyID(obj) == 0)
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
        public List<Partner> GetPartners(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPartners();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchCompany(Sender sender, SearchCompanyArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchCompany(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchPartner(Sender sender, SearchPartnerArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchPartner(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public Partner GetPartnerByMobile(Sender sender, string mobile)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Partner obj = new Partner();
                    obj.Mobile = mobile;
                    if (op.LoadPartnerByMobile(obj) == 0)
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
    }
}
