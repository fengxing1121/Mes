using LitJson;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;

namespace Mes.Client.UI.Ashx
{
    /// <summary>
    /// SystemSettingsHandler 的摘要说明
    /// </summary>
    public class SystemSettingsHandler : BaseHttpHandler
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

        public void Save()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    //接收前台对象
                    using (ProxyBE op = new ProxyBE())
                    {
                        string SaveData = Request["SaveData"];
                        JsonData sj = JsonMapper.ToObject(SaveData);
                        if (sj.Count > 0)
                        {
                            //遍历对象元素，保存
                            foreach (JsonData item in sj)
                            {
                                KeyValue keyvalue = p.Client.GetKeyValue(SenderUser, item["Key"].ToString());
                                if (keyvalue == null)
                                {
                                    keyvalue = new KeyValue();
                                    keyvalue.Key = item["Key"].ToString();
                                }
                                keyvalue.Value = item["Value"].ToString();
                                op.Client.SaveKeyValue(SenderUser, keyvalue);
                            }
                            WriteSuccess();
                        }
                        else
                        {
                            WriteError("没有获取到任何行。");
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }

        public void GetKeyValues()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    List<KeyValue> lists_kv = p.Client.GetKeyValues(SenderUser);
                    Response.Write(JSONHelper.Object2DataSetJson(lists_kv));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
    }
}