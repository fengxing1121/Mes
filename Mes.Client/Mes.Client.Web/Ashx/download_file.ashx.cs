using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// download_file 的摘要说明
    /// </summary>
    public class download_file : BaseHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            try
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["fid"]))
                {
                    Guid pid = new Guid(this.Request.QueryString["fid"].ToString());
                    Response.ClearHeaders();
                    Response.ClearContent();

                    string FilePath = "";
                    using (ProxyBE p = new ProxyBE())
                    {
                        OrderProcessFile doc = p.Client.GetOrderProcessFile(SenderUser, pid);
                        if (doc != null)
                        {
                            FilePath = doc.FilePath;
                        }
                    }
                    //string dcFilePath = doc.FilePath;
                    //Response.AppendHeader("Content-Disposition", "attachment;filename=" + Server.UrlPathEncode(Path.GetFileName(dcFilePath)));
                    //if (File.Exists(dcFilePath))
                    //{
                    //    byte[] buffer = File.ReadAllBytes(dcFilePath);
                    //    if (buffer != null)
                    //    {
                    //        Response.BinaryWrite(buffer);
                    //    }
                    //}


                    //没有SE服务，暂时注释掉
                    //if (!string.IsNullOrEmpty(FilePath))
                    //{
                    //    using (ProxySE se = new ProxySE())
                    //    {
                    //        Response.AppendHeader("Content-Disposition", "attachment;filename=" + Server.UrlPathEncode(Path.GetFileName(FilePath)));

                    //        byte[] buffer = se.Client.GetDocumentFile(SenderUser, FilePath);
                    //        if (buffer != null)
                    //        {
                    //            Response.BinaryWrite(buffer);
                    //        }
                    //    }
                    //}
                }
                Response.End();
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
        }
    }
}