using Mes.Client.Model;
using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// RoomDesignerHandler 的摘要说明
    /// </summary>
    public class RoomDesignerHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        RoomDesignerParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new RoomDesignerParm(context);
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

        public void SearchRoomDesigners()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchRoomDesignerArgs sargs = new SearchRoomDesignerArgs();
                    sargs.OrderBy = "[Created] desc";

                    //Where
                    if (!string.IsNullOrEmpty(Request["CustomerName"]))
                    {
                        sargs.CustomerName = Request["CustomerName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(parm.Status))
                    {
                        sargs.Status = parm.Status.Split(',').ToList();
                    }
                    if (CurrentUser.PartnerID != Guid.Empty)
                    {
                        sargs.PartnerID = CurrentUser.PartnerID;
                    }
                    //if (!string.IsNullOrEmpty(CurrentUser.Position)) 
                    //{
                    //    if (CurrentUser.Position.Equals("量尺",StringComparison.CurrentCultureIgnoreCase))
                    //    {

                    //    }
                    //}
                    if (CurrentUser.UserID != Guid.Empty)
                    {
                        sargs.Designer = Convert.ToString(CurrentUser.UserID);
                    }
                    sargs.RowNumberFrom = pagingParm.RowNumberFrom;
                    sargs.RowNumberTo = pagingParm.RowNumberTo;
                    SearchResult sr = p.Client.SearchRoomDesigner(SenderUser, sargs);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SaveRoomDesigner()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    #region RoomDesigner

                    if (parm.CustomerID == Guid.Empty)
                    {
                        throw new Exception("请选择客户。");
                    }

                    RoomDesigner roomdesigner = p.Client.GetRoomDesigner(null, parm.DesignerID);
                    if (roomdesigner == null)
                    {
                        roomdesigner = new RoomDesigner();
                        roomdesigner.DesignerID = parm.DesignerID;
                    }
                    roomdesigner.CustomerID = parm.CustomerID;
                    roomdesigner.Designer = CurrentUser.UserID;//经销商ID
                    roomdesigner.Designed =parm.Designed;
                    roomdesigner.Rooms = parm.Rooms;
                    roomdesigner.SittingAndDiningRoom = parm.SittingAndDiningRoom;
                    roomdesigner.TotalAreal = parm.TotalAreal;
                    roomdesigner.FamilyMembers = parm.FamilyMembers;
                    roomdesigner.Budget = parm.Budget;
                    roomdesigner.VillageName = parm.VillageName;
                    roomdesigner.Building = parm.Building;
                    roomdesigner.Unit = parm.Unit;
                    roomdesigner.RoomNo = parm.RoomNo;
                    roomdesigner.Color = parm.Color;
                    roomdesigner.Style = parm.Style;
                    roomdesigner.Status = "N";//待分派 
                    roomdesigner.Remark = parm.Remark;
                    roomdesigner.DesignerNo ="0";

                    //产生任务
                    PartnerTask task = new PartnerTask();
                    task.ReferenceID = roomdesigner.DesignerID;
                    task.TaskID = Guid.NewGuid();
                    task.TaskNo = p.Client.GetTaskNo(SenderUser);
                    task.TaskType = "方案设计"; //任务类型
                    task.PartnerID = CurrentUser.PartnerID;
                    task.StepName = "新建量尺";//步骤
                    task.StepNo = 1;

                    #endregion

                    #region RoomDesignerFile
                    List<RoomDesignerFile> list = new List<RoomDesignerFile>();
                    RoomDesignerFile rdFile = null;

                    IList<filemodel> ArrayPath = new List<filemodel>();
                    if (!string.IsNullOrEmpty(Request["RoomDesignerFiles"]))
                    {
                        ArrayPath = JSONHelper.JSONToObject<IList<filemodel>>(Request["RoomDesignerFiles"]);
                    }
                    //PartnerID/yyyyMM/文件类型(RoomDesignerFile)/DesignerID/FileName

                    string ServerPath = Server.MapPath("/");
                    if (ArrayPath.Count > 0)
                    {
                        for (var i = 0; i < ArrayPath.Count; i++)
                        {
                            string filePath = System.Web.HttpUtility.UrlDecode(ArrayPath[i].filePath);
                            rdFile = new RoomDesignerFile();
                            rdFile.FileID = Guid.NewGuid();
                            rdFile.DesignerID = roomdesigner.DesignerID;
                            rdFile.Title = "";
                            rdFile.FileName = Path.GetFileName(ServerPath + filePath);
                            rdFile.Remark = "";
                            rdFile.FileURL = filePath;
                            //string SavePath = DateTime.Now.ToString("yyyyMM");
                            //SavePath = Path.Combine(SavePath, CurrentUser.PartnerID.ToString());
                            //SavePath = Path.Combine(SavePath, "RoomDesignerFile");
                            //SavePath = Path.Combine(SavePath, roomdesigner.DesignerID.ToString());
                            //SavePath = Path.Combine(SavePath, rdFile.FileName);
                            //rdFile.FileURL = SavePath;
                            //UploadFile(RoomDesignerFileUrl, SavePath);
                            list.Add(rdFile);
                        }
                    }
                    #endregion

                    #region 任务流程
                    SavePartnerTaskArgs args = new SavePartnerTaskArgs();
                    args.RoomDesigner = roomdesigner;
                    args.PartnerTask = task;
                    args.NextResource = "店长组"; //谁处理
                    //args.NextStep = "分派设计师";
                    args.NextStep = "待酷家乐设计";
                    args.CurrentStep = "新建量尺";
                    args.Resource = "";//分配者
                    args.ActionRemarksType = "";//意见类型
                    args.ActionRemarks = "";//审批意见
                    //args.Action = "提交量尺数据,给店长分配任务";
                    args.Action = "酷家乐设计,提交工厂拆单";

                    args.RoomDesignerFiles = list;
                    p.Client.SavePartnerTask(SenderUser, args);
                    WriteSuccess();
                    #endregion
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }

        public void SaveDesignUpload()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    //Solution solution = p.Client.GetSolution(SenderUser, parm.SolutionID);
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }

        public void UpdateRoomDesigner()
        {

            try
            {
                Guid DesignerID = new Guid(Request["DesignerID"]);
                using (ProxyBE p = new ProxyBE())
                {
                    RoomDesigner rd = p.Client.GetRoomDesigner(SenderUser, DesignerID);
                    if (rd != null)
                    {
                        Response.Write(JSONHelper.Object2Json(rd));
                    }
                    else
                    {
                        Response.Write(JSONHelper.Object2Json(null));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }

        }

        public void FileUpLoad()
        {
            try
            {
                #region 文件上传
                Response.ContentType = "text/plain";
                Response.Charset = "utf-8";
                HttpPostedFile file = Request.Files["Filedata"];
                string RootPath = Server.MapPath(@"/temp/");
                string FileType = Request["FileType"].ToString();
                string Type = Request["Type"].ToString();

                if (!string.IsNullOrEmpty(Type))
                {
                    if (Type.ToLower() != ".zip")
                    {
                        Response.Write("{\"file_url\":\"" + "" + "\",\"message\":\"" + "只能选择格式(.zip)压缩文件" + "\",\"isOk\":\"" + 0 + "\"}");
                        return;
                    }
                }

                //yyyyMMdd//文件类型(RoomDesignerFile)//FileName
                string UploadPath = DateTime.Now.ToString("yyyyMMdd") + "/";
                if (!string.IsNullOrEmpty(FileType))
                {
                    UploadPath = Path.Combine(UploadPath, FileType).Replace("\\", "/");
                }
                string tempSavePath = Path.Combine(RootPath, UploadPath).Replace("\\", "/");
                if (file != null)
                {
                    if (!Directory.Exists(tempSavePath))
                    {
                        Directory.CreateDirectory(tempSavePath);
                    }
                    string SavePath = Path.Combine(tempSavePath, Path.GetFileName(file.FileName)).Replace("\\", "/");
                    file.SaveAs(SavePath);

                    string url = "";
                    List<string> FileUrls = ZipHelper.UnZipFile(SavePath);
                    List<string> list = new List<string>();
                    foreach (string item in FileUrls)
                    {
                        int i = item.IndexOf("temp");
                        list.Add("/" + item.Substring(i));
                    }
                    foreach (string item in list)
                    {
                        url += item + ",";
                    }
                    if (!string.IsNullOrEmpty(url))
                    {
                        int index = url.LastIndexOf(',');
                        url = url.Substring(0, index);
                    }

                    //FileHelper.DeleteFile(SavePath);
                    Response.Write("{\"file_url\":\"" + url + "\",\"message\":\"" + "文件上传成功" + "\",\"isOk\":\"" + 1 + "\"}");
                }
                else
                {
                    Response.Write("{\"file_url\":\"" + "" + "\",\"message\":\"" + "文件上传失败" + "\",\"isOk\":\"" + 0 + "\"}");
                }
                #endregion
            }
            catch (Exception ex)
            {
                Response.Write("{\"file_url\":\"" + "" + "\",\"message\":\"" + ex.Message + "\",\"isOk\":\"" + 0 + "\"}");
                PLogger.LogError(ex);
            }
        }

        private void UploadFile(string sourcefile, string savepath)
        {
            try
            {
                //通过BE上传文件，暂无BE，暂时注释
                //using (ProxySE ps = new ProxySE())
                //{
                //    using (FileStream fs = new FileStream(sourcefile, FileMode.Open))
                //    {
                //        byte[] buffer = new byte[fs.Length];
                //        fs.Read(buffer, 0, buffer.Length);
                //        ps.Client.UploadDoumentFile(SenderUser, savepath, buffer);
                //    }
                //    File.Delete(sourcefile);
                //}
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetRoomDesigner()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["ReferenceID"]))
                {
                    throw new Exception("ReferenceID:调用参数无效。");
                }
                using (ProxyBE op = new ProxyBE())
                {
                    RoomDesigner roomDesigner = op.Client.GetRoomDesigner(SenderUser, Guid.Parse(Request["ReferenceID"]));
                    string No = roomDesigner.DesignerNo;
                    if (roomDesigner != null)
                    {
                        Response.Write(JSONHelper.Object2JSON(roomDesigner));
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message);
            }

        }

        public void ExistsRoomDesignersByDesignerNo()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["designNo"]))
                {
                    throw new Exception("designNo:设计号参数无效。");
                }
                using (ProxyBE op = new ProxyBE())
                {
                    bool result = op.Client.ExistsRoomDesignersByDesignerNo(SenderUser, Convert.ToInt32((Request["designNo"])));
                    if (result)
                    {
                        WriteSuccess();
                    }
                    else
                    {
                        WriteError("该设计号不存在");
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message);
            }
        }

        public void SaveRoomDesigner1()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    if (Request["DesignerNo"] == null)
                    {
                        throw new Exception("设计号不能为空");
                    }
                    if (Request["DesignID"] == null)
                    {
                        throw new Exception("方案ID不能为空");
                    }
                    SaveRoomDesignerKJLRelationArgs args = new SaveRoomDesignerKJLRelationArgs();
                    RoomDesignerKJLRelation model = new RoomDesignerKJLRelation();
                    //model.DesignerNo = parm.DesignerNo;
                    //model.KJLDesignID = parm.KJLDesignID;

                    args.RoomDesignerKJLRelation = model;
                    p.Client.SaveRoomDesignerKJLRelation(SenderUser, args);
                    WriteSuccess();
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }
    }
}