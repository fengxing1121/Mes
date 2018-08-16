using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility.Pages;
using Mes.Client.Utility.Enum;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Text;
using Mes.Client.Model.Pages;

namespace Mes.Client.UI.Ashx
{
    /// <summary>
    /// LoginHandler 的摘要说明
    /// </summary>
    public class LoginHandler : BaseHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            if (!string.IsNullOrEmpty(method))
            {
                //parm = new PrivilegeParm(context);
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

        public void Login()
        {
            try
            {
                string UserCode = Request["username"];
                string Password = Request["password"];
                string VerifyCode = Request["verifycode"];

                if (string.IsNullOrEmpty(UserCode))
                {
                    throw new Exception("用户名不能为空");
                }

                if (VerifyCode.ToLower() != Session["LoginVerifyCode"].ToString().ToLower())
                {
                    throw new PException("验证码不正确");
                }

                using (ProxyBE be = new ProxyBE())
                {
                    #region 登录
                    User user = be.Client.GetUserByUserCode(null, UserCode);

                    if (user == null)
                    {
                        throw new PException("errorUserName");
                    }
                    if (user.IsLocked)
                    {
                        throw new PException("errorLockedUserName");
                    }
                    if (user.IsDisabled)
                    {
                        throw new PException("errorDisabledUserName");
                    }
                    if (user.LoginErrorCount >= 5)
                    {
                        throw new PException("errorLoginOutTimes");
                    }

                    SaveUserArgs args = new SaveUserArgs();
                    //记录当前登录时间
                    if (CEncrypt.EncryptString(Password) != user.Password)
                    {
                        user.LoginErrorCount += 1;
                        PException ex = null;
                        if (user.LoginErrorCount >= 5)
                        {
                            user.IsLocked = true;
                            ex = new PException("errorLoginOutTimes");
                        }
                        else
                        {
                            ex = new PException("errorPassword{0}", 5 - user.LoginErrorCount);
                        }
                        args.User = user;
                        be.Client.SaveUser(base.SenderUser, args);
                        throw ex;
                    }


                    args.User = user;
                    user.LoginErrorCount = 0;
                    user.LastLoginTime = DateTime.Now;
                    be.Client.SaveUser(base.SenderUser, args);

                    SessionUser su = new SessionUser();
                    su.UserCode = user.UserCode;
                    //用户类型
                    su.UserType = (int)UserType.U;
                    //su.LoginUrl = UserLoginUrl;
                    su.UserID = user.UserID;
                    su.UserName = user.UserName;
                    su.IsSystemUser = user.IsSystem;
                    su.LastLoginTime = user.LastLoginTime;
                    su.CompanyID = user.CompanyID;
                    OnlineUser.Lock(su);
                    this.CurrentUser = su;
                    #endregion

                    #region 加载权限项
                    List<Role> userRoles = be.Client.GetRolesByUserID(null, user.UserID);
                    su.Roles = userRoles;

                    List<PrivilegeItem> privilegeItems = be.Client.GetPrivilegeItemByUserID(null, user.UserID);
                    var privilegeItemS = from pi in privilegeItems select pi.PrivilegeItemID;
                    su.PrivilegeItemIDs = privilegeItemS.ToList<Guid>();

                    List<Privilege> privileges = be.Client.GetPrivilegesByUserID(null, user.UserID);
                    var privilegeS = from pl in privileges select pl.PrivilegeID;
                    su.PrivilegeIDs = privilegeS.ToList<Guid>();

                    Dictionary<string, List<string>> PrivilegeCodesDir = new Dictionary<string, List<string>>();
                    foreach (var item in privileges)
                    {
                        if (PrivilegeCodesDir.ContainsKey(item.PrivilegeCode.ToLower())) continue;
                        List<string> itemCodes = new List<string>();
                        var plItems = privilegeItems.Where(pl => pl.PrivilegeID.ToString() == item.PrivilegeID.ToString() && pl.IsDisabled == false).ToList();
                        if (plItems != null)
                        {
                            foreach (var itemPrivilegeItems in plItems)
                            {
                                itemCodes.Add(itemPrivilegeItems.PrivilegeItemCode.ToLower());
                            }
                        }
                        PrivilegeCodesDir.Add(item.PrivilegeCode.ToLower(), itemCodes);
                    }
                    su.PrivilegeCodes = PrivilegeCodesDir;
                    #endregion

                    StringBuilder sb = new StringBuilder();
                    sb.Append('{');
                    sb.Append(string.Format("\"isOk\":\"{0}\",\"message\":\"{1}\",\"url\":\"{2}\"", 1, "success", "/Index.aspx"));
                    sb.Append('}');
                    Response.Write(sb.ToString());
                    //WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message);
            }
        }

        public void ModifyPassword()
        {
            try
            {

                if (CurrentUser == null || CurrentUser.UserID == Guid.Empty)
                {
                    throw new Exception("未获取到用户信息，请先登录");
                }
                using (ProxyBE be = new ProxyBE())
                {
                    #region 登录
                    User user = be.Client.GetUserByUserCode(null, CurrentUser.UserCode);
                    string Password = Request["Password"].ToString();
                    user.Password = CEncrypt.EncryptString(Password);

                    SaveUserArgs args = new SaveUserArgs();
                    args.User = user;
                    be.Client.SaveUser(SenderUser, args);
                    #endregion
                }

                //StringBuilder sb = new StringBuilder();
                //sb.Append("{");
                //sb.AppendFormat("'isOk':{0}", 1);
                //sb.AppendFormat(",'message':'{0}'", "success");
                //sb.AppendFormat(",'url':'{0}'", url);
                //sb.Append("}");
                //Response.Write(sb.ToString());
                Response.Write("{\"result\":\"success\",\"errorCode\":0}");
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message);
            }
        }

        public void LoginOut()
        {
            try
            {
                OnlineUser.Unlock(CurrentUser.UserID);
                CurrentUser = null;
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}