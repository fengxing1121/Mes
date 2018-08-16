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
        public SpecialCompanent GetSpecialCompanent(Sender sender, Guid SpecialID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    SpecialCompanent obj = new SpecialCompanent();
                    obj.SpecialID = SpecialID;

                    if (op.LoadSpecialCompanentBySpecialID(obj) == 0)
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
        public void SaveSpecialCompanent(Sender sender, SaveSpecialCompanentArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    SpecialCompanent obj = new SpecialCompanent();
                    obj.SpecialID = args.SpecialCompanent.SpecialID;
                    if (op.LoadSpecialCompanentBySpecialID(obj) == 0)
                    {
                        args.SpecialCompanent.Created = DateTime.Now;
                        args.SpecialCompanent.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.SpecialCompanent.Modified = DateTime.Now;
                        args.SpecialCompanent.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertSpecialCompanent(args.SpecialCompanent);
                    }
                    else
                    {
                        args.SpecialCompanent.Modified = DateTime.Now;
                        args.SpecialCompanent.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateSpecialCompanentBySpecialID(args.SpecialCompanent);
                    }

                    if (args.SpecialCompanent2WorkFlows != null)
                    {
                        op.DeleteSpecialCompanent2WorkFlowsBySpecialID(args.SpecialCompanent.SpecialID);
                        foreach (SpecialCompanent2WorkFlow item in args.SpecialCompanent2WorkFlows)
                        {
                            op.InsertSpecialCompanent2WorkFlow(item);
                        }
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
        public List<SpecialCompanent> GetSpecialCompanents(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadSpecialCompanents();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<SpecialCompanent2WorkFlow> GetSpecialCompanent2WorkFlows(Sender sender, Guid SpecialID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadSpecialCompanent2WorkFlowsBySpecialID(SpecialID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchSpecialCompanent(Sender sender, SearchSpecialCompanentArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchSpecialCompanent(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchSpecialCompanent2WorkFlow(Sender sender, SearchSpecialCompanent2WorkFlowArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchSpecialCompanent2WorkFlow(args);
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
