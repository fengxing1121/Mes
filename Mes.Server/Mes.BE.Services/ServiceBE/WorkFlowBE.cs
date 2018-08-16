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
        public WorkFlow GetWorkFlow(Sender sender, Guid WorkFlowID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WorkFlow obj = new WorkFlow();
                    obj.WorkFlowID = WorkFlowID;
                    if (op.LoadWorkFlow(obj) == 0)
                        return null;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<WorkFlow> GetAllWorkFlows(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadWorkFlows();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<WorkFlow> GetWorkFlowByWorkFlowID(Sender sender, Guid WorkFlowID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WorkFlow obj = new WorkFlow();
                    obj.WorkFlowID = WorkFlowID;
                    return op.LoadWorkFlowByWorkFlowID(obj);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public SearchResult SearchWorkFlow(Sender sender, SearchWorkFlowArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchWorkFlow(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public void SaveWorkFlow(Sender sender, WorkFlow obj)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    WorkFlow model = new WorkFlow();
                    model.WorkFlowID = obj.WorkFlowID;
                    if (op.LoadWorkFlow(model) == 0)
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertWorkFlow(obj);
                    }
                    else
                    {
                        obj.Created = DateTime.Now;
                        obj.CreatedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateWorkFlowByWorkFlowID(obj);
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
    }
}

