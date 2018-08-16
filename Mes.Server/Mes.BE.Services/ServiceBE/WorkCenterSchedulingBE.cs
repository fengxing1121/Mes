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
        public List<WorkCenterScheduling> GetAllWorkCenterSchedulings(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadWorkCenterSchedulings();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public WorkCenterScheduling GetWorkCenterScheduling(Sender sender, Guid WorkID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WorkCenterScheduling obj = new WorkCenterScheduling();
                    obj.WorkID = WorkID;
                    if (op.LoadWorkCenterSchedulingByWorkID(obj) == 0)
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
        public void SaveWorkCenterScheduling(Sender sender, SaveWorkCenterSchedulingArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    WorkCenterScheduling obj = new WorkCenterScheduling();
                    obj.WorkID = args.WorkCenterScheduling.WorkID;
                    if (op.LoadWorkCenterSchedulingByWorkID(obj) == 0)
                    {
                        args.WorkCenterScheduling.Created = DateTime.Now;
                        args.WorkCenterScheduling.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.WorkCenterScheduling.Modified = DateTime.Now;
                        args.WorkCenterScheduling.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertWorkCenterScheduling(args.WorkCenterScheduling);
                    }
                    else
                    {
                        args.WorkCenterScheduling.Modified = DateTime.Now;
                        args.WorkCenterScheduling.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateWorkCenterSchedulingByWorkID(args.WorkCenterScheduling);
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
        public List<WorkCenterScheduling> GetWorkCenterSchedulingWorkCenterID(Sender sender, Guid WorkCenterID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadWorkCenterSchedulingsByWorkCenterID(WorkCenterID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchWorkCenterScheduling(Sender sender, SearchWorkCenterSchedulingArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchWorkCenterScheduling(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public WorkCenterScheduling GetLastWorkCenterSchedulingByWorkCenterID(Sender sender, Guid WorkCenterID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WorkCenterScheduling obj = new WorkCenterScheduling();
                    obj.WorkCenterID = WorkCenterID;
                    if (op.LoadLastWorkCenterSchedulingByWorkCenterID(obj) == 0)
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
