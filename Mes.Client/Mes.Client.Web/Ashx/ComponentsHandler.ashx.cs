using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// ComponentsHandler 的摘要说明
    /// </summary>
    public class ComponentsHandler : BaseHttpHandler
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
            else
            {
                throw new Exception("Method paramters is null or empty.");
            }
        }
        #endregion

        public void SearchParts()
        {
            Response.Write(JSONHelper.Dataset2Json(null));
        }
    }
}