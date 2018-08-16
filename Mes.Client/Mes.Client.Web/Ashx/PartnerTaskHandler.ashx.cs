using Eagle.Data;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Enum;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// PartnerTaskHandler 的摘要说明
    /// </summary>
    public class PartnerTaskHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                foreach (MethodInfo mi in this.GetType().GetMethods())
                {
                    if (mi.Name.ToLower() == method.ToLower())
                    {
                        mi.Invoke(this, null);
                        break;
                    }
                }
            }
        }
        #endregion

        public void SearchPartnerTask()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchPartnerTaskArgs args = new SearchPartnerTaskArgs();
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    args.OrderBy = "Created desc";

                    //工厂
                    if (CurrentUser.UserType == (int)UserType.U)
                    {
                        args.Resource = "方案审核组";
                        args.StepNo = "3,4,5,6,7";

                        //string filterList = "fumanduo";
                        //if (filterList.IndexOf(CurrentUser.UserCode) != -1)
                        //    args.UserCodes = filterList;
                    }
                    //经销商
                    if (CurrentUser.UserType == (int)UserType.D)
                    {
                        args.Resource = CurrentUser.UserCode;
                        if (CurrentUser.PartnerID != Guid.Empty)
                        {
                            args.PartnerID = CurrentUser.PartnerID;
                        }
                        //args.StepNo = "1,2";
                        args.StepNo = "2";
                    }

                    if (!string.IsNullOrEmpty(Request["TaskType"]))
                    {
                        args.TaskType = Request["TaskType"].ToString();
                    }

                    if (!string.IsNullOrEmpty(Request["TaskNo"]))
                    {
                        args.TaskNo = Request["TaskNo"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["StepName"]))
                    {
                        args.StepNames = new List<string>();
                        args.StepNames.Add(Request["StepName"].ToString());
                    }
                    args.CompanyID = CurrentUser.CompanyID;//Liu
                    SearchResult sr = p.Client.SearchPartnerTask(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SearchHistoryTask()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchPartnerTaskArgs args = new SearchPartnerTaskArgs();
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    args.OrderBy = "Created desc";

                    if (!string.IsNullOrEmpty(Request["TaskType"]))
                    {
                        args.TaskType = Request["TaskType"].ToString();
                    }
                    if (CurrentUser.PartnerID != Guid.Empty)
                    {
                        args.PartnerID = CurrentUser.PartnerID;
                    }
                    if (!string.IsNullOrEmpty(Request["TaskNo"]))
                    {
                        args.TaskNo = Request["TaskNo"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["StepName"]))
                    {
                        args.StepNames = new List<string>();
                        args.StepNames.Add(Request["StepName"].ToString());
                    }
                    SearchResult sr = p.Client.SearchPartnerTask(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }



        //陈工URL
        public void ChenSaveUrl()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["DesignerNo"]))
                {
                    throw new Exception("DesignerNo：参数无效");
                }
                if (string.IsNullOrEmpty(Request["Process"]))
                {
                    throw new Exception("Process：参数无效");
                }
                if (string.IsNullOrEmpty(Request["SaveUrl"]))
                {
                    throw new Exception("SaveUrl：参数无效");
                }
                string DesignerNo = Request["DesignerNo"];
                string SaveUrl = Request["SaveUrl"];
                int Process = Int32.Parse(Request["Process"]);
                Database db = new Database("BE_PartnerTaskResource_Proc", "UPCHENURL", Process, 0, DesignerNo, SaveUrl, "");
                int result = db.ExecuteNoQuery();
                if (result == 1)
                    Response.Write("Success");
                else
                    Response.Write(result);
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        //陈工触发拆单
        public void ChenSplitGetZip()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["DesignerID"]))
                {
                    throw new Exception("DesignerID：参数无效");
                }

                Response.Write(1);

                string DesignerID = Request["DesignerID"];

                //solutionhandler sh = new solutionhandler();
                //sh.SolutionFileUrl = "";
                //sh.SaveSolution();//解析





                //TASK状态
                Database dbCheck = new Database("BE_PartnerTask_Proc", "UPSTEPNO3", 4, 0, DesignerID, "生成报价明细", "P");
                int rst = dbCheck.ExecuteNoQuery();


                //string DesignerNo = Request["DesignerNo"];
                //string SaveUrl = Request["SaveUrl"];
                //int Process = Int32.Parse(Request["Process"]);
                //Database db = new Database("BE_PartnerTaskResource_Proc", "UPCHENURL", Process, 0, DesignerNo, SaveUrl, "");
                //int result = db.ExecuteNoQuery();
                //if (result == 1)
                //    Response.Write("Success");
                //else
                //    Response.Write(result);
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SavePartnerTask()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (string.IsNullOrEmpty(Request["TaskID"]))
                    {
                        throw new Exception("TaskID：参数无效");
                    }
                    if (string.IsNullOrEmpty(Request["UserCode"]))
                    {
                        throw new Exception("UserCode:参数无效");
                    }
                    if (string.IsNullOrEmpty(Request["StepName"]))
                    {
                        throw new Exception("StepName:参数无效");
                    }
                    if (string.IsNullOrEmpty(Request["ReferenceID"]))
                    {
                        throw new Exception("ReferenceID:参数无效");
                    }

                    //Database dbCheck = new Database("BE_Solution_Proc", "CHECKSL", 0, 0, Request["ReferenceID"].ToString(), "", "");
                    //string result= dbCheck.ExecuteScalar().ToString();
                    //if (result=="0")
                    //{
                    //    WriteError("请先提交拆单！");
                    //    return;
                    //}

                    PartnerTask task = p.Client.GetPartnerTask(SenderUser, Guid.Parse(Request["TaskID"].ToString()));
                    if (task != null)
                    {
                        SavePartnerTaskArgs args = new SavePartnerTaskArgs();
                        args.PartnerTask = task;
                        args.NextStep = "待工厂拆单处理";
                        //args.CurrentStep = "设计方案";
                        args.Resource = "店长组";//当前处理组
                        args.NextResource = Request["UserCode"].ToString();//下一个组
                        args.ActionRemarksType = "";
                        args.ActionRemarks = Request["Remark"].ToString();
                        //args.Action = "分配量尺数据，给设计师设计方案";
                        args.Action = "酷家乐设计，提交拆单请求";

                        RoomDesigner roomDesiger = p.Client.GetRoomDesigner(SenderUser, Guid.Parse(Request["ReferenceID"].ToString()));
                        roomDesiger.Status = "C";//已分派
                        args.RoomDesigner = roomDesiger;

                        p.Client.SavePartnerTask(SenderUser, args);
                        WriteSuccess();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SearchPartTasksStep()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["TaskID"]))
                {
                    throw new Exception("参数无效");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    List<PartnerTaskStep> list = p.Client.GetPartnerTaskStepByTaskID(SenderUser, Guid.Parse(Request["TaskID"].ToString()));
                    list.Sort((x, y) => x.StepNo.CompareTo(y.StepNo));
                    Response.Write(JSONHelper.Object2DataSetJson(list));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void UploadSolutionFile()
        {
            try
            {
                #region 文件上传
                Response.ContentType = "text/plain";
                Response.Charset = "utf-8";
                HttpPostedFile file = null;
                try
                {
                    file = Request.Files["Filedata"];
                }
                catch
                {
                    throw new Exception("文件上传无效。");
                }
                if (string.IsNullOrEmpty(Request["ReferenceID"]))
                {
                    throw new Exception("参数无效。");
                }
                string PartnerID = Convert.ToString(CurrentUser.PartnerID);
                string TaskID = Request["TaskID"];
                string FileType = Request["FileType"];
                string SavePath = DateTime.Now.ToString("yyyyMMdd") + "\\";

                //yyyyMMdd/PartnerID/文件类型(SolutionFile)/TaskID/FileName

                if (!string.IsNullOrEmpty(PartnerID))
                {
                    SavePath = Path.Combine(SavePath, PartnerID);
                }
                if (!string.IsNullOrEmpty(TaskID))
                {
                    SavePath = Path.Combine(SavePath, TaskID);
                }
                if (!string.IsNullOrEmpty(FileType))
                {
                    SavePath = Path.Combine(SavePath, FileType);
                }
                SavePath = Path.Combine(SavePath, Path.GetFileName(file.FileName));

                //通过SE上传文件,SE服务缺失，暂时注释
                //using (ProxySE ps = new ProxySE())
                //{
                //    byte[] buffer = new byte[file.ContentLength];
                //    Stream sr = file.InputStream;
                //    sr.Read(buffer, 0, file.ContentLength);
                //    ps.Client.UploadDoumentFile(SenderUser, SavePath, buffer);
                //}
                #endregion

                using (ProxyBE p = new ProxyBE())
                {
                    #region 方案文件
                    Solution solution = p.Client.GetSolutionByDesignerID(SenderUser, Guid.Parse(Request["ReferenceID"].ToString()));
                    SearchSolutionFileArgs fielArgs = new SearchSolutionFileArgs();
                    fielArgs.SolutionID = solution.SolutionID;
                    SearchResult sr = p.Client.SearchSolutionFile(SenderUser, fielArgs);
                    List<Guid> FileIDs = new List<Guid>();
                    if (sr.Total > 0)
                    {
                        foreach (DataRow row in sr.DataSet.Tables[0].Rows)
                        {
                            FileIDs.Add(new Guid(row["FileID"].ToString()));
                        }
                    }
                    if (solution == null)
                    {
                        throw new Exception("方案无效。");
                    }
                    if (FileIDs.Count > 0)
                    {
                        foreach (Guid item in FileIDs)
                        {
                            p.Client.DeleteSolutionFile(SenderUser, item);
                        }
                    }
                    SolutionFile solutionFile = new SolutionFile();
                    solutionFile.FileID = Guid.NewGuid();
                    solutionFile.SolutionID = solution.SolutionID;
                    solutionFile.SourceID = solution.SolutionID;
                    solutionFile.SourceType = "S";
                    solutionFile.Status = "N";
                    solutionFile.FileName = Path.GetFileName(SavePath);
                    solutionFile.FileUrl = SavePath;

                    SaveSolutionFileArgs solutionFileAgrs = new SaveSolutionFileArgs();
                    solutionFileAgrs.SolutionFile = solutionFile;
                    p.Client.SaveSolutionFile(SenderUser, solutionFileAgrs);
                    #endregion

                    #region 任务流程
                    PartnerTask task = p.Client.GetPartnerTask(SenderUser, Guid.Parse(TaskID));
                    if (task != null)
                    {
                        SavePartnerTaskArgs taskArgs = new SavePartnerTaskArgs();
                        taskArgs.PartnerTask = task;
                        task.StepName = "生成报价明细";
                        taskArgs.NextStep = "生成报价明细";
                        taskArgs.Resource = CurrentUser.UserCode;//当前处理组
                        taskArgs.NextResource = "CPT";//下一个组
                        taskArgs.Action = "设计师重新上传方案";
                        taskArgs.ActionRemarksType = "";
                        taskArgs.ActionRemarks = "设计师重新上传方案";
                        p.Client.SavePartnerTask(SenderUser, taskArgs);
                        WriteSuccess();
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}