using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// RoomDesignerFileHandler 的摘要说明
    /// </summary>
    public class RoomDesignerFileHandler : BaseHttpHandler
    {
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

        public void GetRoomDesignerFile()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (string.IsNullOrEmpty(Request["DesignerID"]))
                    {
                        throw new Exception("参数无效");
                    }
                    List<RoomDesignerFile> list = p.Client.GetRoomDesignerFilesByDesignerID(SenderUser, Guid.Parse(Request["DesignerID"]));
                    Response.Write(JSONHelper.Object2JSON(list));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void DownloadRoomDesignerFile()
        {

        }
    }
}