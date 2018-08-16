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
        public List<WorkingLine> GetAllWorkingLines(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadWorkingLines();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public WorkingLine GetWorkingLine(Sender sender, Guid WorkingLineID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WorkingLine obj = new WorkingLine();
                    obj.WorkingLineID = WorkingLineID;
                    if (op.LoadWorkingLineByWorkingLineID(obj) == 0)
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
        public void SaveWorkingLine(Sender sender, SaveWorkingLineArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    WorkingLine obj = new WorkingLine();
                    obj.WorkingLineID = args.WorkingLine.WorkingLineID;
                    if (op.LoadWorkingLineByWorkingLineID(obj) == 0)
                    {
                        args.WorkingLine.Created = DateTime.Now;
                        args.WorkingLine.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.WorkingLine.Modified = DateTime.Now;
                        args.WorkingLine.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertWorkingLine(args.WorkingLine);
                    }
                    else
                    {
                        args.WorkingLine.Modified = DateTime.Now;
                        args.WorkingLine.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateWorkingLineByWorkingLineID(args.WorkingLine);
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
        public SearchResult SearchWorkingLine(Sender sender, SearchWorkingLineArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchWorkingLine(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool WorkingLineIsDuplicated(Sender sender, WorkingLine WorkingLine)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    WorkingLine obj = new WorkingLine();
                    obj.WorkingLineName = WorkingLine.WorkingLineName;
                    if (op.LoadWorkingLineByWorkingLineName(obj) == 0)
                    {
                        return false;
                    }
                    return obj.WorkingLineID != WorkingLine.WorkingLineID;
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
