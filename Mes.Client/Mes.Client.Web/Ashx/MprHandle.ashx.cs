using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// MprHandle 的摘要说明
    /// </summary>
    public class MprHandle : BaseHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"] ?? "";
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "text": SearchMprtext(context); break;
                    case "pathurl": SearchFilePathUrl(context); break;
                }
            }
        }

        /// <summary>
        /// 查询文本内容
        /// </summary>
        public void SearchMprtext(HttpContext context)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                string mprPath = context.Request["mprPath"];
                if (!string.IsNullOrEmpty(mprPath))
                {
                    string Readpath = System.Web.HttpContext.Current.Server.MapPath("/") + mprPath;
                    string txt = File.ReadAllText(Readpath, Encoding.Default);
                    result.ReturnCode = 1;
                    result.JsonObj = txt;
                }
                else
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "参数错误";
                }
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = ex.Message;
            }
            context.Response.Write(JSONHelper.ToJson(result));
        }

        /// <summary>
        /// 获取板件mpr文件树
        /// </summary>
        public void SearchFilePathUrl(HttpContext context)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                string ItemID = context.Request["ItemID"];
                if (!string.IsNullOrEmpty(ItemID))
                {
                    SolutionDetail SolutionDetail;
                    using (ProxyBE be = new ProxyBE())
                    {
                        SolutionDetail = be.Client.GetSolutionDetail(null, new Guid(ItemID));
                    }

                    if (SolutionDetail == null || string.IsNullOrEmpty(SolutionDetail.FilePathUrl))
                    {
                        result.ReturnCode = -1;
                        result.ReturnMsg = SolutionDetail == null ? "未查询到板件数据" : "板件未上传mpr文件";
                        context.Response.Write(JSONHelper.ToJson(result));
                        return;
                    }

                    IList<FileModel> list = new List<FileModel>();
                    var arrayPath = SolutionDetail.FilePathUrl.TrimEnd(',').Split(',');
                    for (int i = 0; i < arrayPath.Length; i++)
                    {
                        string Readpath = System.Web.HttpContext.Current.Server.MapPath("/") + arrayPath[i];
                        if (System.IO.File.Exists(Readpath))
                        {
                            FileInfo fileinfo = new FileInfo(Readpath);
                            list.Add(new FileModel()
                            {
                                filePath = arrayPath[i],
                                fileName = fileinfo.Name,
                            });
                        }
                    }
                    if (list.Count > 0)
                    {
                        result.ReturnCode = 1;
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        dic.Add("total", list.Count.ToString());
                        dic.Add("data", JSONHelper.ToJson(list));
                        result.JsonObj = JSONHelper.ToJson(dic);
                    }
                    else
                    {
                        result.ReturnCode = -1;
                        result.ReturnMsg = "mpr文件不存在或已删除";
                    }
                }
                else
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "参数错误";
                }
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = ex.Message;
            }
            context.Response.Write(JSONHelper.ToJson(result));
        }

        public class FileModel
        {
            public string filePath { get; set; }

            public string fileName { get; set; }
        }
    }
}