using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// BattchFileHandler 的摘要说明
    /// </summary>
    public class BattchFileHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        BattchFileParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                base.ProcessRequest(context);
                string method = Request["Method"] ?? "";
                parm = new BattchFileParm(context);
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
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        #endregion

        public void SearchBattchFiles()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchBattchFileArgs args = new SearchBattchFileArgs();
                    args.OrderBy = "BattchNum desc";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;

                    if (!string.IsNullOrEmpty(parm.BattchNum))
                    {
                        args.BattchNum = parm.BattchNum;
                    }
                    if (!string.IsNullOrEmpty(Request["IsDownload"]))
                    {
                        args.IsDownload = parm.IsDownload;
                    }
                    if (!string.IsNullOrEmpty(Request["WorkingLineID"]))
                    {
                        args.WorkingLineID = parm.WorkingLineID;
                    }
                    if (!string.IsNullOrEmpty(Request["WorkCenterName"]))
                    {
                        args.WorkCenterName = Request["WorkCenterName"];
                    }
                    SearchResult sr = p.Client.SearchBattchFile(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }

        public void UploadBattchFile()
        {
            try
            {
                #region CUT文件
                string filePath = Config.StorageFolder;
                IList<HttpPostedFile> cutFiles = Request.Files.GetMultiple("cutFile");

                string BattchNum = Request["BattchNum"];
                string WorkingLineID = Request["WorkingLineID"];

                if (string.IsNullOrEmpty(WorkingLineID))
                {
                    throw new Exception("请选择生产线。");
                }
                if (string.IsNullOrEmpty(BattchNum))
                {
                    throw new Exception("请输入批次号。");
                }

                if (cutFiles.Count == 0)
                {
                    throw new Exception("请选择CUT文件。");
                }
                foreach (HttpPostedFile cutFile in cutFiles)
                {
                    string savepath = Path.Combine(filePath, "BattchFiles");
                    savepath = Path.Combine(savepath, "CUT");
                    savepath = Path.Combine(savepath, BattchNum);
                    if (!Directory.Exists(savepath))
                    {
                        Directory.CreateDirectory(savepath);
                    }
                    savepath = Path.Combine(savepath, Path.GetFileName(cutFile.FileName));
                    if (File.Exists(savepath))
                    {
                        File.Delete(savepath);
                    }
                    cutFile.SaveAs(savepath);

                    using (ProxyBE pb = new ProxyBE())
                    {
                        BattchFile bf = new BattchFile();
                        bf.FileID = Guid.NewGuid();
                        bf.FileType = "CUT";
                        bf.FileName = Path.GetFileNameWithoutExtension(savepath);
                        bf.FilePath = savepath;
                        bf.IsDownload = false;
                        bf.BattchNum = BattchNum;
                        bf.DeviceID = new Guid(WorkingLineID);

                        if (pb.Client.BattchFileIsDuplicated(SenderUser, bf))
                        {
                            throw new Exception("批次上传文件已经存在。");
                        }
                        SaveBattchFileArgs args = new SaveBattchFileArgs();
                        args.BattchFile = bf;
                        pb.Client.SaveBattchFile(SenderUser, args);
                    }
                }
                #endregion
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void DeleteBattchFile()
        {
            try
            {
                string FileID = Request["FileID"];
                if (string.IsNullOrEmpty(FileID))
                {
                    throw new Exception("无效参数调用。");
                }
                using (ProxyBE pb = new ProxyBE())
                {
                    pb.Client.DeleteBattchFileByFileID(SenderUser, new Guid(FileID));
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }

        public void DownloadBattchFile()
        {
            try
            {
                string FileID = Request["FileID"];
                if (string.IsNullOrEmpty(FileID))
                {
                    throw new Exception("无效参数调用。");
                }

                string filePath = "";
                string fileName = "";
                string fileType = "";
                using (ProxyBE pb = new ProxyBE())
                {
                    BattchFile bf = pb.Client.GetBattchFile(SenderUser, new Guid(FileID));

                    if (bf != null)
                    {
                        filePath = bf.FilePath;
                        fileName = bf.FileName;
                        fileType = bf.FileType;
                    }
                    else
                    {
                        throw new Exception("文件数据丢失，下载失败。");
                    }

                    if (!File.Exists(filePath))
                    {
                        throw new Exception("文件已经损坏，下载失败。");
                    }
                    FileStream fs = new FileStream(filePath, FileMode.Open);
                    byte[] bytes = new byte[(int)fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    fs.Close();
                    Response.ContentType = "application/octet-stream";
                    //通知浏览器下载文件而不是打开
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName + "." + fileType, Encoding.UTF8));
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    //Response.End();

                    //下载完成之后，把是否状态改变

                    SaveBattchFileArgs args = new SaveBattchFileArgs();
                    args.BattchFile = bf;
                    bf.IsDownload = true;
                    bf.ModifiedBy = SenderUser.UserCode + "." + SenderUser.UserName;
                    pb.Client.SaveBattchFile(SenderUser, args);
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}