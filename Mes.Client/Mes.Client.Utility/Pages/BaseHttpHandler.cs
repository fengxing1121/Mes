using Mes.Client.Model.Constants;
using Mes.Client.Model.Pages;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using MES.Libraries;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace Mes.Client.Utility.Pages
{
    [Serializable]
    /// <summary>
    /// 一般处理基础类
    /// </summary>
    public class BaseHttpHandler : IHttpHandler, IRequiresSessionState
    {
        public HttpRequest Request;
        public HttpResponse Response;
        public HttpSessionState Session;
        public HttpServerUtility Server;
        public HttpCookie Cookie;
        public Guid CategoryRootID = Guid.Empty;
        public PagingParm pagingParm;
        public const string UserLoginUrl = "/login.aspx"; //工厂登录入口
        public const string PartnerLoginUrl = "/partnerLogin.aspx"; //经销商登录入口

        public virtual void ProcessRequest(HttpContext context)
        {
            Request = context.Request;
            Response = context.Response;
            Session = context.Session;
            Server = context.Server;
            pagingParm = new PagingParm(context);

            //排除LoginHandler、、SafeHandler、UserRegister
            string url = Request.FilePath.ToLower();
            if (url.IndexOf("loginhandler") > -1 || url.IndexOf("partnetloginhandler") > -1 || url.IndexOf("verifycodehanler") > -1 || url.IndexOf("safecodehanler") > -1)
            {
                return;
            }
            if (CurrentUser == null || OnlineUser.GetOnlineUser(CurrentUser.UserID) == null)
            {
                Response.Write("TimeOut");
                Response.End();
                //Response.Write("<script>top.window.location.href = '/login.aspx'</script>");
                //Response.End();
            }
        }

        public Sender SenderUser
        {
            get
            {
                Sender sender = new Sender();
                sender.UserCode = CurrentUser.UserCode;
                sender.UserName = CurrentUser.UserName;
                sender.IdentityHostName = Request.LogonUserIdentity.Name;
                sender.IPAddress = Request.UserHostAddress;
                return sender;
            }
        }

        public SessionUser CurrentUser
        {
            get
            {
                SessionUser su = (SessionUser)Session["CustomPage_CurrentUser"];
                if (su == null)
                {
                    Session["CustomPage_CurrentUser"] = new SessionUser();
                    su = (SessionUser)Session["CustomPage_CurrentUser"];
                }
                return su;
            }
            set { Session["CustomPage_CurrentUser"] = value; }
        }

        public PageBase PageBase
        {
            get
            {
                return new PageBase(Request);
            }
        }

        public class ResponseResult
        {
            /// <summary>
            /// 错误代码
            /// </summary>
            [JsonProperty(PropertyName = "returncode")]
            public int ReturnCode { set; get; }

            /// <summary>
            /// 错误代码描述
            /// </summary>
            [JsonProperty(PropertyName = "returnmsg")]
            public string ReturnMsg { set; get; }

            /// <summary>
            /// josn数据对像
            /// </summary>
            [JsonProperty(PropertyName = "jsonobj")]
            public string JsonObj { set; get; }
        }

        /// <summary>
        /// 输出：{isOk:1,message:"操作成功"}
        /// </summary>
        public void WriteSuccess()
        {
            WriteMessage(1, "操作成功！");
        }

        /// <summary>
        /// 输出：{isOk:0,message:"操作失败"}
        /// </summary>
        /// <param name="ex">错误</param>
        public void WriteError(string message, Exception ex)
        {
            if (ex == null)
                SaveError(new Exception(message));
            else
                SaveError(ex);
            WriteMessage(0, message);
        }

        /// <summary>
        /// 输出：{isOk:0,message:"操作成功"}
        /// </summary>
        /// <param name="ex">错误</param>
        public void WriteError(string message)
        {
            SaveError(new Exception(message));
            WriteMessage(0, message);
        }

        /// <summary>
        /// 输出：{isOk:1,message:"操作成功"}
        /// </summary>
        /// <param name="Status">0失败，1成功</param>
        /// <param name="Message">消息内容</param>
        public void WriteMessage(int Status, string message)
        {
            message = message.Replace("'", "");
            message = message.Replace("\r", "");
            message = message.Replace("\n", "");
            message = message.Replace("\t", "");
            message = message.Replace("\b", "");
            message = message.Replace("\'", "'");
            message = message.Replace("\"", "");
            Response.Write(JSONHelper.ToResultJson(Status, message));
            //Response.Write("<script>alert(\"" + message +"\")</script>");
        }

        /// <summary>
        /// 输出：{isOk:1,message:"操作成功",total:0,rows:[]}
        /// </summary>
        /// <param name="Status">0失败，1成功</param>
        /// <param name="Message">消息内容</param>
        public void WriteMessageByList(int Status, string message)
        {
            message = message.Replace("\r", "\\r");
            message = message.Replace("\n", "\\n");
            message = message.Replace("\t", "\\t");
            message = message.Replace("\b", "\\b");
            message = message.Replace("\'", "\\\'");
            message = message.Replace("\"", "\\\"");
            Response.Write(JSONHelper.ToResultJsonAndRow(Status, message));
        }

        /// <summary>
        /// 输出：{isOk:1,message:"操作成功",total:0,rows:[]}
        /// </summary>
        /// <param name="Status">0失败，1成功</param>
        /// <param name="Message">消息内容</param>
        public void WriteErrorByList(string message)
        {
            message = message.Replace("\r", "\\r");
            message = message.Replace("\n", "\\n");
            message = message.Replace("\t", "\\t");
            message = message.Replace("\b", "\\b");
            message = message.Replace("\'", "\\\'");
            message = message.Replace("\"", "\\\"");
            Response.Write(JSONHelper.ToResultJsonAndRow(0, message));
        }

        /// <summary>
        /// 输入日志
        /// </summary>
        /// <param name="Message"></param>
        public void WriteLog(string Message, Guid SourceID)
        {
            //SysLog modelLog = new SysLog();
            //modelLog.AddTime = DateTime.Now;
            //modelLog.AddUserID = 2;
            //modelLog.IP = Request.UserHostAddress;
            //modelLog.Message = Message;
            //modelLog.Page = Request.RawUrl;
            //bllLog.Add(modelLog);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void SaveError(Exception ex)
        {
            StringBuilder temp = new StringBuilder();
            StreamWriter sw;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string path = string.Empty;
            string filename = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            path = Server.MapPath("~/Error");
            //如果目录不存在则创建 
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            System.IO.FileInfo file = new System.IO.FileInfo(path + "/" + filename);
            sw = new System.IO.StreamWriter(file.FullName, true);//文件不存在就创建,true表示追加 
            temp.AppendLine("--------------------------------------------------------------------------------------------------------------------------");
            temp.AppendLine("错误时间:" + DateTime.Now.ToString());
            temp.AppendLine("错误消息:" + ex.Message);
            temp.AppendLine("导致错误的应用程序或对象的名称:" + ex.Source);
            temp.AppendLine("堆栈内容:" + ex.StackTrace);
            temp.AppendLine("引发异常的方法:" + ex.TargetSite);
            temp.AppendLine("错误页面" + Request.RawUrl);
            temp.AppendLine("--------------------------------------------------------------------------------------------------------------------------");
            sw.WriteLine(temp.ToString());
            sw.Close();
            PLogger.LogError(temp.ToString());
        }

        /// <summary>
        /// 获取一个自动编号
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetNumber(string key)
        {
            string reStr = string.Empty;
            try
            {
                StringBuilder str = new StringBuilder();
                string year = Convert.ToString(DateTime.Now.Year);
                string mothor = DateTime.Now.Month < 10 ? Convert.ToString("0" + DateTime.Now.Month) : Convert.ToString(DateTime.Now.Month);
                string day = DateTime.Now.Day < 10 ? Convert.ToString("0" + DateTime.Now.Day) : Convert.ToString(DateTime.Now.Day);
                str.Append(key);
                str.Append(year);
                str.Append(mothor);
                str.Append(day);
                using (ProxyBE p = new ProxyBE())
                {
                    int num = p.Client.GetIncrease(SenderUser, str.ToString());
                    reStr = str.ToString() + num.ToString("#000");
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
            return reStr;
        }

        #region 系统参数配置
        /// <summary>
        /// 用户默认密码
        /// </summary>
        public string UserDefaultPassword
        {
            get
            {
                KeyValue kv = null;
                using (ProxyBE ae = new ProxyBE())
                {
                    kv = ae.Client.GetKeyValue(SenderUser, PageBase.KEY_USER_DEFAULT_PASSWORD);
                    if (kv == null)
                    {
                        kv = new KeyValue();
                        kv.Key = PageBase.KEY_USER_DEFAULT_PASSWORD;
                        kv.Value = "123456";
                        //kv.Description = "默认密码";
                        ae.Client.SaveKeyValue(SenderUser, kv);
                    }
                }
                return kv.Value;
            }
        }

        /// <summary>
        /// 首次登录必须修改密码
        /// </summary>
        public bool MustChangePasswordAtFirstLogin
        {
            get
            {
                KeyValue kv = null;
                using (ProxyBE ae = new ProxyBE())
                {
                    kv = ae.Client.GetKeyValue(SenderUser, PageBase.KEY_MUST_CHANGE_PASSWORD_AT_FIRST_LOGIN);
                    if (kv == null)
                    {
                        kv = new KeyValue();
                        kv.Key = PageBase.KEY_MUST_CHANGE_PASSWORD_AT_FIRST_LOGIN;
                        kv.Value = false.ToString();
                        //kv.Description = "第一次登录必须修改密码";
                        ae.Client.SaveKeyValue(SenderUser, kv);
                    }
                }
                return bool.Parse(kv.Value);
            }
        }
        /// <summary>
        /// 密码过期天数
        /// </summary>
        public int DaysPasswordExpired
        {
            get
            {
                KeyValue kv = null;
                using (ProxyBE ae = new ProxyBE())
                {
                    kv = ae.Client.GetKeyValue(SenderUser, PageBase.KEY_DAYS_PASSWORD_EXPIRED);
                    if (kv == null)
                    {
                        kv = new KeyValue();

                        kv.Key = PageBase.KEY_DAYS_PASSWORD_EXPIRED;
                        kv.Value = "0";
                        //kv.Description = "密码过期天数";
                        ae.Client.SaveKeyValue(PageBase.SenderUser, kv);
                    }
                }
                return int.Parse(kv.Value);
            }
        }
        /// <summary>
        /// 密码强度校验
        /// </summary>
        public bool MustVerifyPasswordStrength
        {
            get
            {
                KeyValue kv = null;
                using (ProxyBE ae = new ProxyBE())
                {
                    kv = ae.Client.GetKeyValue(SenderUser, PageBase.KEY_MUST_VERIFY_PASSWORD_STRENGTH);
                    if (kv == null)
                    {
                        kv = new KeyValue();

                        kv.Key = PageBase.KEY_MUST_VERIFY_PASSWORD_STRENGTH;
                        kv.Value = false.ToString();
                        //kv.Description = "校验密码强度";
                        ae.Client.SaveKeyValue(SenderUser, kv);
                    }
                }
                return bool.Parse(kv.Value);
            }
        }
        /// <summary>
        /// 密码不能重复
        /// </summary>
        public int PasswordCanNotSameCount
        {
            get
            {
                KeyValue kv = null;
                using (ProxyBE ae = new ProxyBE())
                {
                    kv = ae.Client.GetKeyValue(SenderUser, PageBase.KEY_PASSWORD_CAN_NOT_SAME_COUNT);
                    if (kv == null)
                    {
                        kv = new KeyValue();

                        kv.Key = PageBase.KEY_PASSWORD_CAN_NOT_SAME_COUNT;
                        kv.Value = "0";
                        //kv.Description = "新密码不可以和最后N次密码相同";
                        ae.Client.SaveKeyValue(SenderUser, kv);
                    }
                }
                return int.Parse(kv.Value);
            }
        }
        /// <summary>
        /// 登录错误次数
        /// </summary>
        public int LoginErrorCount
        {
            get
            {
                KeyValue kv = null;
                using (ProxyBE ae = new ProxyBE())
                {
                    kv = ae.Client.GetKeyValue(SenderUser, PageBase.KEY_LOGIN_ERROR_COUNT);
                    if (kv == null)
                    {
                        kv = new KeyValue();

                        kv.Key = PageBase.KEY_LOGIN_ERROR_COUNT;
                        kv.Value = "0";
                        //kv.Description = "连续输入密码错误次数锁定用户";
                        ae.Client.SaveKeyValue(SenderUser, kv);
                    }
                }
                return int.Parse(kv.Value);
            }
        }
        /// <summary>
        /// 清洗工序代码
        /// </summary>
        public string WorkFlow_CleanCode
        {
            get
            {
                KeyValue kv = null;
                using (ProxyBE ae = new ProxyBE())
                {
                    kv = ae.Client.GetKeyValue(SenderUser, PageBase.KEY_WORKFLOW_CLEAN_CODE);
                    if (kv == null)
                    {
                        kv = new KeyValue();

                        kv.Key = PageBase.KEY_WORKFLOW_CLEAN_CODE;
                        kv.Value = "";
                        //kv.Description = "清洗工序代码";
                        ae.Client.SaveKeyValue(SenderUser, kv);
                    }
                }
                return kv.Value;
            }
        }
        /// <summary>
        /// 封边工序代码
        /// </summary>
        public string WorkFlow_EdgedescCode
        {
            get
            {
                KeyValue kv = null;
                using (ProxyBE ae = new ProxyBE())
                {
                    kv = ae.Client.GetKeyValue(SenderUser, PageBase.KEY_WORKFLOW_KEYEDGEDESC_CODE);
                    if (kv == null)
                    {
                        kv = new KeyValue();

                        kv.Key = PageBase.KEY_WORKFLOW_KEYEDGEDESC_CODE;
                        kv.Value = "";
                        //kv.Description = "封边工序代码";
                        ae.Client.SaveKeyValue(SenderUser, kv);
                    }
                }
                return kv.Value;
            }
        }
        /// <summary>
        /// 常规打孔工序代码
        /// </summary>
        public string WorkFlow_NormalDrillingHoleCode
        {
            get
            {
                KeyValue kv = null;
                using (ProxyBE ae = new ProxyBE())
                {
                    kv = ae.Client.GetKeyValue(SenderUser, PageBase.KEY_WORKFLOW_NORMALDRILLINGHOLE_CODE);
                    if (kv == null)
                    {
                        kv = new KeyValue();

                        kv.Key = PageBase.KEY_WORKFLOW_NORMALDRILLINGHOLE_CODE;
                        kv.Value = "";
                        //kv.Description = "常规打孔工序代码";
                        ae.Client.SaveKeyValue(SenderUser, kv);
                    }
                }
                return kv.Value;
            }
        }
        /// <summary>
        /// 开槽工序代码
        /// </summary>
        public string WorkFlow_NormalGroovingCode
        {
            get
            {
                KeyValue kv = null;
                using (ProxyBE ae = new ProxyBE())
                {
                    kv = ae.Client.GetKeyValue(SenderUser, PageBase.KEY_WORKFLOW_NORMALGROOVING_CODE);
                    if (kv == null)
                    {
                        kv = new KeyValue();

                        kv.Key = PageBase.KEY_WORKFLOW_NORMALGROOVING_CODE;
                        kv.Value = "";
                        //kv.Description = "开槽工序代码";
                        ae.Client.SaveKeyValue(SenderUser, kv);
                    }
                }
                return kv.Value;
            }
        }
        /// <summary>
        /// 常规开料工序代码
        /// </summary>
        public string WorkFlow_NormalMadeCode
        {
            get
            {
                KeyValue kv = null;
                using (ProxyBE ae = new ProxyBE())
                {
                    kv = ae.Client.GetKeyValue(SenderUser, PageBase.KEY_WORKFLOW_NORMALMADE_CODE);
                    if (kv == null)
                    {
                        kv = new KeyValue();

                        kv.Key = PageBase.KEY_WORKFLOW_NORMALMADE_CODE;
                        kv.Value = "";
                        //kv.Description = "常规开料工序代码";
                        ae.Client.SaveKeyValue(SenderUser, kv);
                    }
                }
                return kv.Value;
            }
        }
        /// <summary>
        /// 包装工序代码
        /// </summary>
        public string WorkFlow_PagageCode
        {
            get
            {
                KeyValue kv = null;
                using (ProxyBE ae = new ProxyBE())
                {
                    kv = ae.Client.GetKeyValue(SenderUser, PageBase.KEY_WORKFLOW_PAGAGE_CODE);
                    if (kv == null)
                    {
                        kv = new KeyValue();

                        kv.Key = PageBase.KEY_WORKFLOW_PAGAGE_CODE;
                        kv.Value = "";
                        //kv.Description = "包装工序代码";
                        ae.Client.SaveKeyValue(SenderUser, kv);
                    }
                }
                return kv.Value;
            }
        }
        /// <summary>
        /// 异形打孔工序代码
        /// </summary>
        public string WorkFlow_SpecialDrillingHoleCode
        {
            get
            {
                KeyValue kv = null;
                using (ProxyBE ae = new ProxyBE())
                {
                    kv = ae.Client.GetKeyValue(SenderUser, PageBase.KEY_WORKFLOW_SPECIALDRILLINGHOLE_CODE);
                    if (kv == null)
                    {
                        kv = new KeyValue();

                        kv.Key = PageBase.KEY_WORKFLOW_SPECIALDRILLINGHOLE_CODE;
                        kv.Value = "";
                        //kv.Description = "异形打孔工序代码";
                        ae.Client.SaveKeyValue(SenderUser, kv);
                    }
                }
                return kv.Value;
            }
        }
        /// <summary>
        /// 异形开槽工序代码
        /// </summary>
        public string WorkFlow_SpecialGroovingCode
        {
            get
            {
                KeyValue kv = null;
                using (ProxyBE ae = new ProxyBE())
                {
                    kv = ae.Client.GetKeyValue(SenderUser, PageBase.KEY_WORKFLOW_SPECIALGROOVING_CODE);
                    if (kv == null)
                    {
                        kv = new KeyValue();

                        kv.Key = PageBase.KEY_WORKFLOW_SPECIALGROOVING_CODE;
                        kv.Value = "";
                        //kv.Description = "异形开槽工序代码";
                        ae.Client.SaveKeyValue(SenderUser, kv);
                    }
                }
                return kv.Value;
            }
        }
        /// <summary>
        /// 异形开料工序代码
        /// </summary>
        public string WorkFlow_SpecialMadeCode
        {
            get
            {
                KeyValue kv = null;
                using (ProxyBE ae = new ProxyBE())
                {
                    kv = ae.Client.GetKeyValue(SenderUser, PageBase.KEY_WORKFLOW_SPECIALMADE_CODE);
                    if (kv == null)
                    {
                        kv = new KeyValue();

                        kv.Key = PageBase.KEY_WORKFLOW_SPECIALMADE_CODE;
                        kv.Value = "";
                        //kv.Description = "异形开料工序代码";
                        ae.Client.SaveKeyValue(SenderUser, kv);
                    }
                }
                return kv.Value;
            }
        }
        #endregion

        #region 返回处理结果

        /// <summary>
        /// 返回处理结果
        /// </summary>
        public class ResultData
        {
            /// <summary>
            /// 成功、失败代码1,0
            /// </summary>
            public int Code { get; set; }
            /// <summary>
            /// 提示信息
            /// </summary>
            public string Msg { get; set; }
            /// <summary>
            /// 返回的数据集
            /// </summary>
            public object Data { get; set; }
        }

        public void WriteJsonSuccess(string msg = Const.SuccessMsg, object data = null)
        {
            ResultData resultData = new ResultData
            {
                Code = Const.Success,
                Msg = msg,
                Data = data,
            };

            Response.Write(JSONHelper.SerializeObject(resultData));
        }

        public void WriteJsonError(string msg = Const.ErrorMsg, object data = null)
        {
            ResultData resultData = new ResultData
            {
                Code = Const.Error,
                Msg = msg,
                Data = data,
            };

            Response.Write(JSONHelper.SerializeObject(resultData));
        }

        #endregion
    }
}
