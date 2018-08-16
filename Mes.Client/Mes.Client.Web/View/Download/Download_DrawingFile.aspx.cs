using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;

namespace Mes.Client.Web.View.Download
{
    public partial class Download_DrawingFile : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 下载文件
            try
            {
                string FileID = Request["FileID"];
                if (string.IsNullOrEmpty(FileID))
                {
                    throw new Exception("无效参数调用。");
                }
                string filePath = String.Empty;
                string fileName = String.Empty;
                using (ProxyBE pb = new ProxyBE())
                {
                    OrderProcessFile op = pb.Client.GetOrderProcessFile(SenderUser, new Guid(FileID));
                    if (op != null)
                    {
                        filePath = op.FilePath;
                        fileName = op.FileName;
                    }
                    else
                    {
                        throw new Exception("文件数据丢失，下载失败。");
                    }
                }

                //暂无SE服务，暂时注释
                //using (ProxySE ps = new ProxySE())
                //{
                //    byte[] buffer = ps.Client.GetDocumentFile(SenderUser, filePath);
                //    if (buffer != null)
                //    {
                //        Response.Clear();
                //        Response.ContentType = "application/octet-stream";
                //        //通知浏览器下载文件而不是打开
                //        Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName));
                //        Response.BinaryWrite(buffer);
                //        Response.Flush();
                //        Response.End();
                //    }
                //    else
                //    {
                //        throw new Exception("文件已经损坏，下载失败。");
                //    }
                //}
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                RedirectErrorPage(ex.Message);
            }
            #endregion
        }
    }
}