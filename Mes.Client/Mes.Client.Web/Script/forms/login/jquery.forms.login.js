$(document).keydown(function (e) {
    if (e.keyCode == 13) {
        $("#btlogin").click();
    }
});
(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var loginForm = {
        edit_form: null,
        init: function () {
            loginForm.initControls();
            loginForm.controls.password.on('keypress', loginForm.events.checkCapsLock);
            loginForm.controls.vfcode.on('click', loginForm.events.getVerifyCode);
            loginForm.controls.confirm.on('click', loginForm.events.onsubmit);
            loginForm.controls.changevfcode.on('click', loginForm.events.getVerifyCode);
            loginForm.events.getVerifyCode();
            // 为IE10以下加入placeholder特性
            loginForm.controls.formWrapper.placeholder();
        },
        initControls: function () {
            var $formWrapper = $('#edit_form');
            loginForm.controls = {
                formWrapper: $formWrapper,
                confirm: $('#btlogin'),
                inputuin: $('#inputuin'),
                password: $('#pp'),
                vfcode: $('#vfcode'),
                verifycode: $('#verifycode'),
                changevfcode: $('#changevfcode')
            }
        },
        events: {
            checkCapsLock: function (e) {
                var $target = $(e.target);
                var isCapsLock = capslock.detect(e);
                var caps_lock_tips = $("#caps_lock_tips");
                if (isCapsLock) {
                    caps_lock_tips.css('display', "block");
                }
                else {
                    caps_lock_tips.css('display', "none");
                }
            },
            HideLockTips: function (e) {
                $("#caps_lock_tips").style.display = "none";
            },
            getVerifyCode: function (e) {
                loginForm.controls.vfcode.attr('src', '/Ashx/VerifyCodeHanler.ashx?pid=CN23000101&f=html&ck=1&r=' + Math.random());
            },
            onsubmit: function (e) {
                var inputUin = loginForm.controls.inputuin.val().toLowerCase();

                if (inputUin == "") {
                    loginForm.showMsg("emptyUserName");
                    loginForm.controls.inputuin.focus();
                    return false;
                }

                if (loginForm.controls.password.val() == "") {
                    loginForm.showMsg("emptyPassword");
                    loginForm.controls.password.focus();
                    return false;
                }

                if (loginForm.controls.password.val().length >= 100) {
                    loginForm.showMsg("errorPassowrdTooLong");
                    loginForm.controls.password.focus();
                    return false;
                }                
                if ($("#VerifyArea").css('display') != "none" && loginForm.controls.verifycode.val() == "") {
                    loginForm.showMsg("emptyVerifyCode");
                    loginForm.controls.verifycode.focus();
                    return false;
                }
                loginForm.controls.confirm.val('正在登录，请稍候...');
                loginForm.controls.confirm.removeClass('green_btn').addClass('gray_btn');
                loginForm.controls.confirm.attr('disabled', true);

                var paramData = {};
                paramData.username = loginForm.controls.inputuin.val();
                paramData.password = loginForm.controls.password.val();
                paramData.verifycode = loginForm.controls.verifycode.val();

                var LoginUrl ="";
                if ($('input[name="loginRoles"]:checked').val() == "factory") {
                    LoginUrl = "/Ashx/loginhandler.ashx?Method=Login&f=12|01|34&r=";
                }
                else{
                    LoginUrl = "/Ashx/partnetLoginHandler.ashx?Method=Login&f=12|01|34&r=";
                }

                $.ajax({
                    url: LoginUrl + (new Date()).getTime().valueOf(),
                    data: paramData,
                    success: function (result) {
                        result = eval('(' + result + ')');                        
                        if (result.isOk == 1) {
                            window.location.href ="/Index.aspx";// "/View/index.aspx";
                        }
                        else {
                            loginForm.events.getVerifyCode();
                            loginForm.controls.confirm.removeClass('gray_btn').addClass('green_btn');
                            loginForm.controls.confirm.attr('disabled', false);
                            loginForm.controls.confirm.val('登录');
                            loginForm.showMsg(result.message);
                        }
                    },
                    error: function () {
                        loginForm.controls.confirm.removeClass('gray_btn').addClass('green_btn');
                        loginForm.controls.confirm.attr('disabled', false);
                        loginForm.controls.confirm.val('登录');
                        loginForm.events.getVerifyCode();
                    }
                });
            }
        },
        showMsg: function (msgId, method, txt) {
            var msg, msgTemplate;
            msg = {
                errorAdminName: "此管理员帐号不存在，请重新输入",
                errorUserName: "您输入的帐号不正确，请重新输入",
                emptyUserName: "请填写您的MES帐号",
                emptyPassword: "请填写密码",
                emptyVerifyCode: "请填写验证码",
                errorPassowrdTooLong: "密码不能超过100个字符",
                errorNamePassowrd: "您填写的帐号或密码不正确，请再次尝试",
                errorVerifyCode: "您填写的验证码不正确",
                errorVerifyCodeOutTime: "验证码超时，请重新获取",
                errorBindNullUin: "帐号为空，请重输",
                errorDisabledUserName: "用户已失效或被管理员限制登录",
                errorLockedUserName: "用户帐号被锁定，限制登录",
                errorLoginOutTimes: "您密码连续输入错误5次，帐号已被锁。",
                errorPassword1: "密码无效。您还剩1次机会。",
                errorPassword2: "密码无效。您还剩2次机会。",
                errorPassword3: "密码无效。您还剩3次机会。",
                errorPassword4: "密码无效。您还剩4次机会。",
                errorExpirty: "企业到期未续费"
            };
            if (method && method == 2) {
                msgTemplate = '<div class=" error" id="%_id_%">%_msg_%</div>';
            }
            else {
                msgTemplate = '<div class=" error" id="%_id_%">%_msg_%</div>';
            }
            if (msgId != undefined && msgId != "") {
                if (!txt) txt = msg[msgId];
                $("#msgContainer").html('');
                if (!txt) {
                    $('#msgContainer').html(msgTemplate.replace(/%_msg_%/ig, msgId).replace(/%_id_%/ig, '10000'));
                }
                else {                    
                    $('#msgContainer').html(msgTemplate.replace(/%_msg_%/ig, txt).replace(/%_id_%/ig, msgId));
                }
                $('#msgContainer').css('display', '');

                return true;
            }
            else {
                return false;
            }
        }
    };

    $(function () {
        loginForm.init();
    });
})(jQuery);
