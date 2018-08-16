using Mes.Client.Model.Pages;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility.Enum;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Mes.Client.UI.Ashx
{
    /// <summary>
    /// PartnetLoginHandler 的摘要说明
    /// </summary>
    public class PartnetLoginHandler : BaseHttpHandler
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
                    throw new PException("验证码错误");
                }

                using (ProxyBE p = new ProxyBE())
                {
                    #region 登录
                    PartnerUser partner = p.Client.GetPartnerUserByUserCode(null, UserCode);
                    if (partner == null)
                    {
                        throw new PException("用户不存在");
                    }
                    if (partner.IsLocked)
                    {
                        throw new PException("帐号被锁");
                    }
                    if (partner.IsDisabled)
                    {
                        throw new PException("帐号禁用");
                    }
                    if (partner.LoginErrorCount >= 5)
                    {
                        throw new PException("密码错误次数过多，帐号已被锁定，请联系管理员");
                    }
                    SavePartnerUserArgs args = new SavePartnerUserArgs();
                    if (CEncrypt.EncryptString(Password) != partner.Password)
                    {
                        partner.LoginErrorCount += 1;
                        PException ex = null;
                        if (partner.LoginErrorCount >= 5)
                        {
                            //登录错误次数过多 帐号锁定
                            partner.IsLocked = true;
                            ex = new PException("密码错误次数过多，帐号已被锁定，请联系管理员");
                        }
                        else
                        {
                            //剩余登录次数
                            ex = new PException("密码错误，您还有{0}机会", 5 - partner.LoginErrorCount);
                        }
                        args.PartnerUser = partner;
                        p.Client.SavePartnerUser(base.SenderUser, args);
                        throw ex;
                    }

                    args.PartnerUser = partner;
                    partner.LoginErrorCount = 0;
                    partner.LastLoginTime = DateTime.Now;
                    p.Client.SavePartnerUser(base.SenderUser, args);
                    #endregion

                    #region Session

                    SessionUser su = new SessionUser();
                    su.UserCode = partner.UserCode;
                    su.UserID = partner.UserID;
                    su.PartnerID = partner.PartnerID;
                    su.Position = partner.Position;
                    //su.LoginUrl = PartnerLoginUrl;
                    su.UserName = partner.UserName;
                    su.UserType = (int)UserType.D;
                    su.IsSystemUser = partner.IsSystem;
                    su.LastLoginTime = partner.LastLoginTime;
                    su.IsFinishInfo = partner.IsFinishInfo;
                    OnlineUser.Lock(su);
                    this.CurrentUser = su;

                    #endregion

                    #region 加载权限
                    //privilegeItem               
                    List<PrivilegeItem> privilegeItems = p.Client.GetPrivilegeItemByPartnerUserID(null, partner.UserID);
                    var privilegeItemS = from pi in privilegeItems select pi.PrivilegeItemID;
                    su.PrivilegeItemIDs = privilegeItemS.ToList<Guid>();

                    //privileges
                    List<Privilege> privileges = p.Client.GetPrivilegesByPartnerUserID(null, partner.UserID);
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
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message);
            }
        }

        public void ModifyPwd()
        {
            try
            {
                if (this.CurrentUser.UserID != Guid.Empty || this.CurrentUser != null)
                {
                    using (ProxyBE p = new ProxyBE())
                    {
                        PartnerUser user = p.Client.GetPartnerUserByUserCode(SenderUser, CurrentUser.UserCode);
                        string Password = Request["Password"].ToString();
                        user.Password = CEncrypt.EncryptString(Password);

                        SavePartnerUserArgs args = new SavePartnerUserArgs();
                        args.PartnerUser = user;
                        p.Client.SavePartnerUser(SenderUser, args);
                    }
                }
                this.Response.Write("{\"result\":\"success\",\"errorCode\":0}");
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message, ex);
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

        public void Userexist()
        {
            try
            {
                string UserCode = Request["username"];

                using (ProxyBE p = new ProxyBE())
                {
                    PartnerUser partner = p.Client.GetPartnerUserByUserCode(null, UserCode);
                    if (partner == null)
                    {
                        Response.Write("false");
                    }
                    else
                    {
                        Response.Write("true");
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message);
            }
        }
    }
}