using Eagle.Data;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mes.Client.Web.View.Download
{
    public partial class Download_skpFile : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string FileID = Request["FileID"];
                if (string.IsNullOrEmpty(FileID))
                {
                    throw new Exception("参数无效。");
                }
                string filePath = String.Empty;
                string fileName = String.Empty;
                using (ProxyBE p = new ProxyBE())
                {
                    //RoomDesignerFile file = p.Client.GetRoomDesignerFile(SenderUser, Guid.Parse(FileID));
                    SolutionFile file = p.Client.GetSolutionFile(SenderUser, Guid.Parse(FileID));
                    if (file == null)
                    {
                        throw new Exception("文件数据丢失，下载失败。");
                    }
                    else
                    {
                        filePath = file.FileUrl;
                        fileName = file.FileName;
                    }

                    try
                    {

                        //以字符流的形式下载文件
                        FileStream fs = new FileStream(filePath, FileMode.Open);
                        byte[] bytes = new byte[(int)fs.Length];
                        fs.Read(bytes, 0, bytes.Length);
                        fs.Close();
                        Response.ContentType = "application/octet-stream;charset=gb2321";

                        //通知浏览器下载文件而不是打开;对中文名称进行编码
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                        Response.BinaryWrite(bytes);
                        Response.Flush();
                        Response.End();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        Response.Flush();
                        Response.End();
                    }



                    //using (ProxySE ps = new ProxySE())
                    //{
                    //    byte[] buffer = ps.Client.GetDocumentFile(SenderUser, filePath);
                    //    if (buffer == null)
                    //    {
                    //        throw new Exception("文件损坏，下载失败。");
                    //    }
                    //    else
                    //    {
                    //        Response.Clear();
                    //        Response.ContentType = "application/octet-stream";
                    //        Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName,Encoding.UTF8));
                    //        Response.BinaryWrite(buffer);
                    //        Response.Flush();
                    //        //Response.End();
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                RedirectErrorPage(ex.Message);
            }
        }
    }
}