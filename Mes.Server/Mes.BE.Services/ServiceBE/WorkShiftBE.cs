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
        public List<WorkShift> GetAllWorkShifts(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadWorkShifts();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public WorkShift GetWorkShift(Sender sender, Guid WorkShiftID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WorkShift obj = new WorkShift();
                    obj.WorkShiftID = WorkShiftID;
                    if (op.LoadWorkShiftByWorkShiftID(obj) == 0)
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
        public WorkShift GetWorkShiftByWorkShiftCode(Sender sender, string WorkShiftCode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WorkShift obj = new WorkShift();

                    obj.WorkShiftCode = WorkShiftCode;
                    if (op.LoadWorkShiftByWorkShiftCode(obj) == 0)
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
        public void SaveWorkShift(Sender sender, SaveWorkShiftArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    WorkShift obj = new WorkShift();
                    obj.WorkShiftID = args.WorkShift.WorkShiftID;
                    if (op.LoadWorkShiftByWorkShiftID(obj) == 0)
                    {
                        args.WorkShift.Created = DateTime.Now;
                        args.WorkShift.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.WorkShift.Modified = DateTime.Now;
                        args.WorkShift.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertWorkShift(args.WorkShift);
                    }
                    else
                    {
                        args.WorkShift.Modified = DateTime.Now;
                        args.WorkShift.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateWorkShiftByWorkShiftID(args.WorkShift);
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
        public SearchResult SearchWorkShift(Sender sender, SearchWorkShiftArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchWorkShift(args);
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
