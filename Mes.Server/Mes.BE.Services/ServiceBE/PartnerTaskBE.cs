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
        #region  经销商任务
        public PartnerTask GetPartnerTask(Sender sender, Guid TaskID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PartnerTask obj = new PartnerTask();
                    obj.TaskID = TaskID;
                    if (op.LoadPartnerTaskByTaskID(obj) == 0)
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
        public void SavePartnerTask(Sender sender, SavePartnerTaskArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {

                    PartnerTask ta = new PartnerTask();
                    ta.TaskID = args.PartnerTask.TaskID;
                    if (op.LoadPartnerTaskByTaskID(ta) == 0)
                    {
                        #region 新任务
                        args.PartnerTask.TaskNo =""; //设置任务编号
                        PartnerTaskStep ts = new PartnerTaskStep();
                        ts.StepID = Guid.NewGuid();
                        ts.TaskID = args.PartnerTask.TaskID;
                        ts.StepNo = 1;
                        ts.StepName = args.CurrentStep;
                        ts.Action = args.Action;
                        ts.TargetStep = args.NextStep;

                        ts.Started = DateTime.Now;
                        ts.StartedBy = sender.UserCode + "." + sender.UserName;
                        ts.Ended = ts.Started;
                        ts.EndedBy = ts.StartedBy;
                        ts.Remark = args.ActionRemarks;
                        ts.RemarkType = args.ActionRemarksType;

                        args.PartnerTask.StepNo = ts.StepNo + 1;
                        args.PartnerTask.StepName = ts.TargetStep;
                        args.PartnerTask.Created = ts.Started;
                        args.PartnerTask.CreatedBy = ts.StartedBy;
                        args.PartnerTask.Modified = ts.Ended;
                        args.PartnerTask.ModifiedBy = ts.EndedBy;

                        op.InsertPartnerTask(args.PartnerTask);
                        op.InsertPartnerTaskStep(ts);
                        if (!string.IsNullOrEmpty(args.NextResource))
                        {
                            PartnerTaskResource newTR = new PartnerTaskResource();
                            newTR.TaskID = ta.TaskID;
                            newTR.Resource = args.NextResource;
                            newTR.Request = "";
                            newTR.Started = args.PartnerTask.Modified;
                            newTR.StartedBy = args.PartnerTask.ModifiedBy;
                            op.InsertPartnerTaskResource(newTR);
                        }
                        #endregion
                    }
                    else
                    {
                        #region 审批步骤任务
                        PartnerTaskResource tr = new PartnerTaskResource();
                        tr.TaskID = args.PartnerTask.TaskID;
                        tr.Resource = args.Resource;
                        if (op.LoadPartnerTaskResourceByTaskID(tr) == 0)
                        {
                            throw new Exception(string.Format("任务资源不存在.TaskID:{0}, Resource:{1}", args.PartnerTask.TaskID, args.Resource));
                        }

                        PartnerTaskStep ts = new PartnerTaskStep();
                        ts.StepID = Guid.NewGuid();
                        ts.TaskID = ta.TaskID;
                        ts.StepNo = ta.StepNo;
                        ts.StepName = ta.StepName;
                        ts.Action = args.Action;
                        if (string.IsNullOrEmpty(args.NextStep))
                        {
                            ts.TargetStep = ta.StepName;
                        }
                        else
                        {
                            ts.TargetStep = args.NextStep;
                        }

                        ts.Started = tr.Started;
                        ts.StartedBy = tr.StartedBy;
                        ts.Ended = DateTime.Now;
                        ts.EndedBy = sender.UserCode + "." + sender.UserName;
                        ts.Remark = args.ActionRemarks;
                        ts.RemarkType = args.ActionRemarksType;

                        args.PartnerTask.StepNo = ts.StepNo + 1;
                        args.PartnerTask.StepName = ts.TargetStep;
                        args.PartnerTask.Modified = ts.Ended;
                        args.PartnerTask.ModifiedBy = ts.EndedBy;
                        op.UpdatePartnerTaskByTaskID(args.PartnerTask);
                        op.InsertPartnerTaskStep(ts);
                        if (string.IsNullOrEmpty(args.NextStep))
                        {
                            op.DeletePartnerTaskResourceByTaskID(tr.TaskID);
                        }
                        else
                        {
                            op.DeletePartnerTaskResourcesByTaskID(tr.TaskID);
                            if (!string.IsNullOrEmpty(args.NextResource))
                            {
                                PartnerTaskResource newTR = new PartnerTaskResource();
                                newTR.TaskID = ta.TaskID;
                                newTR.Resource = args.NextResource;
                                newTR.Request = "";
                                newTR.Started = ta.Modified;
                                newTR.StartedBy = ta.ModifiedBy;
                                op.InsertPartnerTaskResource(newTR);
                            }
                        }
                        #endregion
                    }

                    #region 量尺
                    if (args.RoomDesigner != null)
                    {
                        RoomDesigner obj = new RoomDesigner();
                        obj.DesignerID = args.RoomDesigner.DesignerID;
                        if (op.LoadRoomDesignerByDesignerID(obj) == 0)
                        {
                            args.RoomDesigner.Created = DateTime.Now;
                            args.RoomDesigner.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                            args.RoomDesigner.Modified = DateTime.Now;
                            args.RoomDesigner.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                            op.InsertRoomDesigner(args.RoomDesigner);
                        }
                        else
                        {
                            args.RoomDesigner.Modified = DateTime.Now;
                            args.RoomDesigner.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                            op.UpdateRoomDesignerByDesignerID(args.RoomDesigner);
                        }
                    }

                    if (args.RoomDesignerFiles != null)
                    {
                        foreach (RoomDesignerFile file in args.RoomDesignerFiles)
                        {
                            RoomDesignerFile temp = new RoomDesignerFile();
                            temp.FileID = file.FileID;
                            if (op.LoadRoomDesignerFileByFileID(temp) == 0)
                            {
                                file.Created = DateTime.Now;
                                file.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                                file.Modified = DateTime.Now;
                                file.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                                op.InsertRoomDesignerFile(file);
                            }
                            else
                            {
                                file.Modified = DateTime.Now;
                                file.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                                op.UpdateRoomDesignerFileByFileID(file);
                            }
                        }
                    }
                    #endregion

                    #region 方案
                    if (args.Solution != null)
                    {
                        Solution obj = new Solution();
                        obj.SolutionID = args.Solution.SolutionID;
                        if (op.LoadSolutionBySolutionID(obj) == 0)
                        {
                            args.Solution.Created = DateTime.Now;
                            args.Solution.CreatedBy = sender.UserCode + "." + sender.UserName;
                            args.Solution.Modified = DateTime.Now;
                            args.Solution.ModifiedBy = sender.UserCode + "." + sender.UserName;
                            op.InsertSolution(args.Solution);
                        }
                        else
                        {
                            args.Solution.Modified = DateTime.Now;
                            args.Solution.ModifiedBy = sender.UserCode + "." + sender.UserName;
                            op.UpdateSolutionBySolutionID(args.Solution);
                        }
                    }

                    if (args.SolutionFiles != null)
                    {
                        foreach (SolutionFile file in args.SolutionFiles)
                        {
                            SolutionFile obj = new SolutionFile();
                            obj.FileID = file.FileID;
                            if (op.LoadSolutionFileByFileID(obj) == 0)
                            {
                                file.Created = DateTime.Now;
                                file.CreatedBy = sender.UserCode + "." + sender.UserName;
                                file.Modified = DateTime.Now;
                                file.ModifiedBy = sender.UserCode + "." + sender.UserName;
                                op.InsertSolutionFile(file);
                            }
                            else
                            {
                                file.Modified = DateTime.Now;
                                file.ModifiedBy = sender.UserCode + "." + sender.UserName;
                                op.UpdateSolutionFileByFileID(file);
                            }
                        }
                    }
                    #endregion

                    #region 方案报价
                    if (args.QuoteMain != null)
                    {
                        QuoteMain main = new QuoteMain();
                        main.QuoteID = args.QuoteMain.QuoteID;
                        if (op.LoadQuoteMainByQuoteID(main) == 0)
                        {
                            op.InsertQuoteMain(args.QuoteMain);
                        }
                        else
                        {
                            op.UpdateQuoteMainByQuoteID(args.QuoteMain);
                        }
                    }
                    if (args.QuoteDetails != null)
                    {
                        op.DeleteQuoteDetailsByQuoteID(args.QuoteMain.QuoteID);
                        foreach (QuoteDetail item in args.QuoteDetails)
                        {
                            op.InsertQuoteDetail(item);
                        }
                    }
                    #endregion
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchPartnerTask(Sender sender, SearchPartnerTaskArgs args)
        {
            try
            {
                using (ObjectProxy p = new ObjectProxy())
                {
                    return p.SearchPartnerTasks(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PartnerTaskStep> GetPartnerTaskStepByTaskID(Sender sender, Guid TaskID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPartnerTaskStepsByTaskID(TaskID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        #endregion
    }
}
