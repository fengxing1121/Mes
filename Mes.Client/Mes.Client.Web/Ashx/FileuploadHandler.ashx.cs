using Eagle.Data;
using ICSharpCode.SharpZipLib.Zip;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// FileuploadHandler 的摘要说明
    /// </summary>
    public class FileuploadHandler : BaseHttpHandler
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

        public void FileUpload()
        {
            Response.ContentType = "text/plain";
            Response.Charset = "utf-8";
            HttpPostedFile file = Request.Files["Filedata"];

            //对应文件
            string DesignerID = Request.Form["DesignerID"];
            Database db = new Database("BE_RoomDesigner_Proc", "GETNOBYID", 0, 0, DesignerID, "", "");

            string DesignerNo = "DesignerNo";
            if (db.ExecuteScalar() != null)
            {
                DesignerNo = db.ExecuteScalar().ToString();
            }
            if (file.FileName.IndexOf(DesignerNo) == -1)
            {
                throw new Exception("请上传对应的客户设计方案文件");
            }

            string RootPath = Server.MapPath(@"/temp/");
            string ProductID = Request["ProductID"];
            string FileType = Request["FileType"];
            string uploadPath = DateTime.Now.ToString("yyyyMMdd") + "/";
            if (ProductID != null)
            {
                uploadPath = uploadPath + ProductID + "/";
            }
            if (FileType != null)
            {
                uploadPath = uploadPath + FileType + "/";
            }
            string tempSavpath = Path.Combine(RootPath, uploadPath);
            if (file != null)
            {
                if (!Directory.Exists(tempSavpath))
                {
                    Directory.CreateDirectory(tempSavpath);
                }
                string savefile = Path.Combine(tempSavpath, Path.GetFileName(file.FileName));
                file.SaveAs(savefile);
                //List<string> list = UnZipFile(savefile, "");
                //FileHelper.DeleteFile(savefile);
                Response.Write("{\"file_url\":\"" + Path.Combine("/temp/" + uploadPath, Path.GetFileName(file.FileName)) + "\"}");
            }
            else
            {
                Response.Write("0");
            }
        }

        public List<string> UnZipFile(string zipFilePath, string unZipDir)
        {


            List<string> fileUrl = new List<string>();
            try
            {
                if (!File.Exists(zipFilePath))
                {
                    throw new Exception("指定文件不存在.");
                }
                if (unZipDir == string.Empty)
                {
                    unZipDir = zipFilePath.Replace(Path.GetFileName(zipFilePath), Path.GetFileNameWithoutExtension(zipFilePath));
                }
                if (!unZipDir.EndsWith("/"))
                {
                    unZipDir += "/";
                }
                if (!Directory.Exists(unZipDir))
                {
                    Directory.CreateDirectory(unZipDir);
                }

                string xlsPath = "";
                using (ZipInputStream zipInputStream = new ZipInputStream(File.OpenRead(zipFilePath)))
                {
                    ZipEntry zipEntry = null;
                    while ((zipEntry = zipInputStream.GetNextEntry()) != null)
                    {
                        string directoryName = Path.GetDirectoryName(zipEntry.Name);
                        string fileName = Path.GetFileName(zipEntry.Name);
                        if (!string.IsNullOrEmpty(directoryName))
                        {
                            Directory.CreateDirectory(unZipDir + directoryName);
                        }

                        if (fileName != string.Empty)
                        {
                            fileUrl.Add(unZipDir + directoryName + "/" + fileName);

                            using (FileStream streamWrite = File.Create(unZipDir + zipEntry.Name))
                            {
                                int bufferSize = 2048;
                                byte[] buffer = new byte[bufferSize];
                                while (true)
                                {
                                    int bytesRead = zipInputStream.Read(buffer, 0, buffer.Length);
                                    if (bytesRead > 0)
                                    {
                                        streamWrite.Write(buffer, 0, bytesRead);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        if (fileName.IndexOf(".xls") != -1)
                        {
                            //五金BOM表
                            xlsPath = unZipDir + directoryName + "/" + fileName;
                        }
                    }
                }

                if (File.Exists(xlsPath))
                {
                    //五金BOM表
                    DataTable dat = ExcelHelper.InputFromExcel(xlsPath, "板材BOM表");

                    DataTable datNew = dat.DefaultView.ToTable(false, new string[] { "部件号", "部件名称" });

                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
            return fileUrl;
        }

        public void CheckFileExists()
        {

        }
    }
}