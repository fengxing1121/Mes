<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="Mes.Client.Web.View.Account.Login2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="renderer" content="webkit" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>欢迎使用MES生产管理系统-用户登陆</title>
    <link rel="shortcut icon" href="../../Content/images/meiwu.png" type="image/x-icon"/>
    <link href="../../Content/css/login/login.css?ver=1.2" rel="stylesheet" />
    <link href="../../Content/css/login/login_common.css" rel="stylesheet" />
    <script src="../../Script/jquery-1.11.0.min.js"></script>
    <script src="../../Script/forms/jquery.min.capslock.js"></script>
    <script src="../../Script/forms/jquery.min.placeholder.js"></script>
    <script src="../../Script/forms/login/jquery.forms.login.js"></script>
</head>
<body class="txt_center ">
    <div name="Header">
        <div class="wd900 getuserdata topheight" id="topDataTd">
            <div>
                <a href="#">
                    <img src="/Content/images/meiwu_200.png" class="meslogo" title="MES首页" alt="MES" /></a>
            </div>
            <div class="navPageBottom topLink right addrtitle">
<%--                <a href="../../Index.aspx" class="toptitle">首页</a>--%>
<%--                <a href="PartnerLogin.aspx" class="toptitle">门店登录</a>--%>
                <%--<span>服务电话：020-34003323</span>--%>
            </div>
        </div>
    </div>
    <div class="loginWrap">
        <div class="wd810">
            <form name="edit_form" id="edit_form" method="post">
                <div class="right_panel">
                    <div class="title"></div>
                    <div id="loginby_wx" class="wx_login_wrap" style="position: absolute;">
                        <div id="qr_shadow" style="display: none; position: absolute; background-color: #000000; filter: alpha(opacity=70); -moz-opacity: 0.7; opacity: 0.7; width: 289px; height: 289px; margin-left: 8px; margin-top: 23px;"></div>
                        <div id="qr_con" class="loginType">
                            <img src="" width="300" height="300" alt="" />
                        </div>
                        <div id="refresh_try" style="display: none; font-size: 14px; text-align: center; padding-top: 5px; text-decoration: underline;"><a style="color: #F9F8F8;" href="#" onclick="window.name=&#39;&#39;;">尝试刷新</a></div>
                    </div>
                </div>
                <div class="left_panel">
                    <div class="ret_msg" id="returnMsg"></div>
                    <div class="login_panel">
                        <div class="title">登录MES</div>
                        <div class="items_panel">
                            <div class="err_tips" id="msgContainer"></div>
                            <div class="item">
                                <label class="input_tips" id="uin_tip" onclick="document.form1.inputuin.focus();">MES帐号</label>
                                <div>
                                    <input class="input_item" id="inputuin" name="inputuin" value="" placeholder="MES帐号" />
                                    <label class="hint">请填写MES帐号。</label>
                                </div>
                            </div>
                            <div class="item">
                                <label class="input_tips" id="pwd_tip" onclick="document.getElementById(&#39;pp&#39;).focus();">密码</label><div>
                                    <input class="input_item" type="password" id="pp" value="" placeholder="密码" />
                                </div>
                                <div class="lock_tips" id="caps_lock_tips" style="display: none;"><span class="lock_tips_row"></span><span>注意：大写锁定已打开</span></div>
                            </div>
                            <div id="VerifyArea" class="verify_wrap" style="display: block;">
                                <div class="item">
                                    <label class="input_tips" id="verify_tip" onclick="document.form1.verifycode.focus();">验证码</label><div>
                                        <img id="vfcode" src="#" style="float: right; cursor: pointer; border: 1px solid #e4eef9; height: 40px;" />
                                        <input class="input_item" autocomplete="off" maxlength="4" id="verifycode" name="verifycode" value="" placeholder="验证码" style="width: 158px;" />
                                    </div>
                                    <div class="change_wrap">
                                        <label><input  type="radio" name="loginRoles" checked="checked" value="factory"/>工厂登陆</label>
                                         <label><input  type="radio" name="loginRoles" value="partner"/>门店登陆</label>
                                </div>
                            </div>
                            <div class="item">

                                <%--<div class="autologin_choice" id="sss">
                                    <input type="checkbox" id="ss" name="ss" value="1" tabindex="7" />
                                    <label for="ss" style="width:140px;">5天内自动登录</label>
                                    <script type="text/javascript">
                                        document.getElementById("ss").onmouseover = function () {
                                            document.getElementById("auto_login_tips").style.display = "block";
                                            document.getElementById("auto_login_tips").style.visibility = "visible";
                                        };
                                        document.getElementById("ss").onmouseout = function () {
                                            document.getElementById("auto_login_tips").style.display = "none";
                                            document.getElementById("auto_login_tips").style.visibility = "hidden";
                                        };
                                    </script>
                                    <div id="auto_login_tips" style="display: none; visibility: hidden; position: absolute; width: 190px; background: #aaa; left: 5px; top: 30px; background: #fdfde4; color: #d88708; padding: 5px 0 5px 5px;">
                                        <div>为了您的帐号安全，请勿在网吧或公用电脑上使用此功能！</div>
                                    </div>
                                </div>--%>
                                <div class="forget_pwd_wrap">
                                  <%--  <a href="resetpwd.aspx">忘记密码？</a>--%>
                                </div>
                            </div>
                            <div>
                                <input type="button" class="green_btn" value="登 录" id="btlogin" name="btlogin" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="middle_line"></div>
            </form>
        </div>
    </div>
    <div id="tipsContainer" style="display: none;">
        <div id="tipsTop" class="tipsWrap topPos size14" style="display: none;"><span class="msg"></span></div>
        <div id="tipsMsg" class="tipsWrap tipsCenter size14" style="display: none;"><span class="msg"></span></div>
        <div id="tipsProcess" class="tipsWrap tipsCenter size14" style="display: none;"><span class="msg" style="background-color: gray;"></span></div>
        <div id="tipsError" class="tipsWrap tipsCenter size14" style="display: none;"><span class="msg" style="background-color: orange;"></span></div>
    </div>
    <div style="clear: both;"></div>
    <div class="wd txt_center">
        <div class="navPageBottom">
            <a href="http://www.lyinfotec.cn" target="_blank">关于我们</a>
            <a href="#">服务条款</a>
            <a href="#">帮助中心</a>
            <a href="#">用户手册</a>
        </div>
        <div class="copyright cLight">2016-<%=DateTime.Now.Year %> gzmeiwu.com Inc. All Rights Reserved&nbsp;&nbsp; </div>
    </div>
</body>
</html>
