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
        public List<WorkCenter> GetAllWorkCenters(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadWorkCenters();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public WorkCenter GetWorkCenter(Sender sender, Guid WorkCenterID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WorkCenter obj = new WorkCenter();
                    obj.WorkCenterID = WorkCenterID;
                    if (op.LoadWorkCenterByWorkCenterID(obj) == 0)
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
        public WorkCenter GetWorkCenterByWorkCenterCode(Sender sender, string WorkCenterCode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WorkCenter obj = new WorkCenter();
                    obj.WorkCenterCode = WorkCenterCode;
                    if (op.LoadWorkCenterByWorkCenterCode(obj) == 0)
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
        public void SaveWorkCenter(Sender sender, SaveWorkCenterArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    WorkCenter obj = new WorkCenter();
                    obj.WorkCenterID = args.WorkCenter.WorkCenterID;
                    if (op.LoadWorkCenterByWorkCenterID(obj) == 0)
                    {
                        args.WorkCenter.Created = DateTime.Now;
                        args.WorkCenter.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.WorkCenter.Modified = DateTime.Now;
                        args.WorkCenter.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertWorkCenter(args.WorkCenter);

                    }
                    else
                    {
                        args.WorkCenter.Modified = DateTime.Now;
                        args.WorkCenter.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateWorkCenterByWorkCenterID(args.WorkCenter);
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
        public SearchResult SearchWorkCenter(Sender sender, SearchWorkCenterArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchWorkCenter(args);
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
