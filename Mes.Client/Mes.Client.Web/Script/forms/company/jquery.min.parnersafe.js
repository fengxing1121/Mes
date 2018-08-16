(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var ctx = '';
    $.smartValidation.addMethod('checkpwd', function ($el) {
        var val = $el.val(),
            name = $el.attr('name'),
            result = PasswordRules.validate(val);

        if (result.success) {
            delete this.validatorMessages[name]['checkpwd'];
        }
        else {
            this.validatorMessages[name]['checkpwd'] = result.message;
        }

        return result.success;
    });
    var safeForm = {
        domain: '.meiwusoft.com',
        search_form: null,
        search_window: null,
        edit_window: null,
        edit_form: null,
        init: function () {
            safeForm.initControls();
            safeForm.controls.password.on('keyup', safeForm.events.checkStrength);
            safeForm.controls.password.on('keypress', safeForm.events.checkCapsLock);
            safeForm.controls.confirmPwd.on('keypress', safeForm.events.checkConfirmPwdCapsLock);
            safeForm.controls.getsmsverifycode.on('click', safeForm.sms.sendSms);
            safeForm.controls.smsverifycode.on('focus', safeForm.sms.focusVerifyCode);
            safeForm.controls.changevfcode.on('click', safeForm.events.getVerifyCode);
            safeForm.controls.smsverifycode.on('click', safeForm.sms.sendSms);
            safeForm.controls.formWrapper.placeholder();

            var Config = $.extend(true, {}, safeForm.configs.formAccount, 0);
            safeForm.formValidation = safeForm.controls.moForm.smartValidator(Config);
            safeForm.events.getVerifyCode();
        },
        initControls: function () {
            var $formWrapper = $('#reg-form-wrapper');
            safeForm.controls = {
                formWrapper: $formWrapper,
                btnAccNext: $('#btnAccNext'),
                btnAccVerify: $('#btnAccVerify'),
                btnConfirm: $('#btnConfirm'),
                verify_form: $('#verify_form'),
                reset_form: $('#safreset_form'),
                password: $('#Password'),
                confirmPwd: $('#confirmPassword'),
                smsverifycode: $('#SMSVerifyCode'),
                imgverifycode: $('#ImgVerifyCode'),
                moForm: $('#edit_form'),
                vfcode: $('#vfcode'),
                changevfcode: $('#changevfcode'),
                getsmsverifycode: $('#getSMSVerifyCode'),
                systemErrorTips: $formWrapper.find('.ui-tips1'),
            }
        },
        showSystemErrorTips: function (errorMsg) {
            safeForm.controls.systemErrorTips.removeClass('hidden')
                .find('.info-msg')
                .html(errorMsg);

            safeForm.systemErrorTimer = setTimeout(function () {
                safeForm.hideSystemErrorTips();
            }, 5000);
        },
        hideSystemErrorTips: function () {
            if (safeForm.systemErrorTimer) {
                clearTimeout(safeForm.systemErrorTimer);
            }

            safeForm.controls.systemErrorTips.addClass('hidden')
                .find('.info-msg')
                .html('');
        },
        sms: {
            countdown: function ($el, cookieTime) {
                var time = 60;
                var countdownHtml = '<span class="countdown-time f-pink">' + time + '</span>秒后重新获取';
                var tempHtml;

                $el.html(countdownHtml).removeClass('ui-btn-secondary').addClass('ui-btn-disable');

                safeForm.smsTimer = setInterval(function () {
                    time--;
                    if (time === 0) {
                        if (cookieTime === 0) {
                            $el.html('获取验证码').addClass('ui-btn-disable').removeClass('ui-btn-secondary');
                        }
                        else {
                            $el.html('获取验证码').removeClass('ui-btn-disable').addClass('ui-btn-secondary');
                        }
                        clearInterval(safeForm.smsTimer);
                    }
                    else if (time > 0) {
                        tempHtml = '<span class="countdown-time f-pink">' + time + '</span>秒后重新获取';
                        $el.html(tempHtml);
                    }
                }, 1000);
            },
            stopCountdown: function ($form) {
                var $btn = safeForm.controls.getsmsverifycode;
                $btn.html('获取验证码').removeClass('ui-btn-disable').addClass('ui-btn-secondary');

                if (safeForm.smsTimer) {
                    clearInterval(safeForm.smsTimer);
                }
            },
            sendSms: function (e) {
                e.stopPropagation();
                var $target = $(e.target);

                // 不是短信发送按钮
                if (!$target.hasClass('btn-verify-code')) {
                    return;
                }

                var $form = $target.parents('form');
                var $phone = $form.find('.ipt-phone');
                var $verifyInput = $form.find('.ipt-verify-code');
                var $customInfoTips = $target.parents('.ui-form-item-group').find('.custom-tooltips-info');
                var key = 'times_' + $.trim($phone.val());
                var cookieTime = MEIWUAI.cookie.get(key);
                var leftCookieTime;
                var validation = safeForm.formValidation;

                // 移除验证码的错误样式
                validation.hideError($verifyInput);
                validation.removeErrorState($verifyInput);

                if (cookieTime === '0') {
                    validation.showCustomTips($customInfoTips, safeForm.configs.smsInfoTips['exceedLimited']);
                }

                function handleSmsData(data) {
                    if (data.head.result == 'success') {
                        // 把发送电话写入cookie
                        if (cookieTime == '') {
                            validation.showCustomTips($customInfoTips, safeForm.configs.smsInfoTips['other']);
                            // 过期时间为24小时
                            leftCookieTime = 9;
                            // 过期时间为24小时
                            leftCookieTime = 9;
                            MEIWUAI.cookie.set(key, leftCookieTime, safeForm.domain, null, 24);
                        }
                        else {
                            leftCookieTime = parseInt(cookieTime) - 1;

                            switch (cookieTime) {
                                case '3':
                                case '2':
                                case '1':
                                    validation.showCustomTips($customInfoTips, safeForm.configs.smsInfoTips[cookieTime]);
                                    MEIWUAI.cookie.set(key, leftCookieTime, safeForm.domain, null, 24);
                                    break;
                                default:
                                    validation.showCustomTips($customInfoTips, safeForm.configs.smsInfoTips['other']);
                                    MEIWUAI.cookie.set(key, leftCookieTime, safeForm.domain, null, 24);
                            }

                        }
                        safeForm.sms.countdown($target, leftCookieTime);
                        $phone.data('pvssid', data.body.data);
                    }
                    else {
                        var errmsg = safeForm.configs.smsErrorCode[data.head.code];
                        errmsg = errmsg === undefined ? safeForm.configs.smsInfoTips['occurError'] : errmsg;
                        validation.showCustomTips($customInfoTips, errmsg);
                    }
                }

                // 检查短信按钮是否可用或手机短信是否已发完
                if (!$target.hasClass('ui-btn-disable') && cookieTime !== '0') {
                    $phone.data('pvssid', '');

                    $.ajax({
                        "type": "POST",
                        "url": "/ashx/userregister.ashx",
                        cache: false,
                        datatype: 'json',
                        data: { phone: $.trim($phone.val()), Method: 'send_verify', type: 'phone' },
                        success: function (data) {
                            data = eval('(' + data + ')');
                            handleSmsData(data);
                        },
                        error: function (e) {
                            validation.showCustomTips($customInfoTips, safeForm.configs.smsInfoTips['occurError']);
                        }
                    });
                }
            },
            // 当改变手机号码时，设置发送短信按钮状态
            setSmsButtonStatus: function ($form, isPhoneValid) {
                var $phone = $form.find('.ipt-phone');
                var key = 'times_' + $.trim($phone.val());
                var cookieTime = MEIWUAI.cookie.get(key);
                var $btn = $form.find('.btn-verify-code');

                safeForm.sms.stopCountdown($form);

                if (isPhoneValid) {
                    if (cookieTime === '0') {
                        $btn.removeClass('ui-btn-secondary').addClass('ui-btn-disable');
                    }
                }
                else {
                    $btn.removeClass('ui-btn-secondary').addClass('ui-btn-disable')
                }
            },
            focusVerifyCode: function (e) {
                var $target = $(e.target);
                var $form = $target.parents('form');
                var $customInfoTips = $target.parents('.ui-form-item-group').find('.custom-tooltips-info');
                var validation = safeForm.formValidation;
                validation.hideCustomTips($customInfoTips);
            }
        },
        data: {
            checkUserCode: function (data, userType, $form) {
                var result = {};
                var errorCodeMap;

                if (typeof (data.result) != 'undefined' && data.result == 'haslogin') {
                    // 调用core.js里的方法
                    if (clsoseMessenger()) {
                        return false;
                    }
                    redirect2Src();
                    return;
                }
                errorCodeMap = safeForm.configs.mobileCheckerErrorCode;

                if (typeof data.result !== 'undefined' && data.result === 'success') {
                    result.valid = true;
                    if ($form) {
                        safeForm.sms.setSmsButtonStatus($form, true);
                    }
                }
                else if (typeof data.result !== 'undefined' && data.result === 'error') {
                    result.valid = errorCodeMap[data.errorCode][0];
                    result.msg = errorCodeMap[data.errorCode][1];

                    if ($form) {
                        safeForm.sms.setSmsButtonStatus($form, errorCodeMap[data.errorCode][0]);
                    }
                }
                else {
                    result.valid = false;
                    result.msg = '系统发生错误，请重试';

                    if ($form) {
                        safeForm.sms.setSmsButtonStatus($form, false);
                    }
                }
                return result;
            },
            checkVerifyCode: function (data, $form) {
                var result = {};
                var errorCodeMap;

                if (typeof (data.result) != 'undefined' && data.result == 'exists') {
                    // 调用core.js里的方法
                    if (clsoseMessenger()) {
                        return false;
                    }
                    redirect2Src();
                    return;
                }
                errorCodeMap = safeForm.configs.VerifyErrorCode;

                if (typeof data.result !== 'undefined' && data.result === 'success') {
                    result.valid = true;
                }
                else if (typeof data.result !== 'undefined' && data.result === 'error') {
                    result.valid = errorCodeMap[data.errorCode][0];
                    result.msg = errorCodeMap[data.errorCode][1];
                }
                else {
                    result.valid = false;
                    result.msg = '系统发生错误，请重试';
                }
                return result;
            }
        },
        events: {
            checkStrength: function (e) {
                var $target = $(e.target),
                    $form = $target.parents('form'),
                    $indicator = $form.find('.strength-indicator'),
                    result = PasswordRules.validate($target.val());

                $target.parents('.control-group').addClass('mb0');
                $indicator.show();
                $indicator.removeClass('login-pwd-w login-pwd-m login-pwd-s');
                $indicator.addClass('login-pwd-' + result.strength);
            },
            checkCapsLock: function (e) {
                var isCapsLock = capslock.detect(e),
                    $target = $(e.target),
                    $infoTips;

                // 未验证或已通过验证, 则显示大小写已开启
                if ($target.data('verified') === undefined || $target.data('verified') === true) {
                    $infoTips = $target.parents('.ui-form-item-group').find('.validator-tooltips-info');

                    if (isCapsLock) {
                        $infoTips.find('.validator-msg').html('键盘大写锁定已打开，请注意大小写');
                        if (!$infoTips.hasClass('z-ui-tooltips-in')) {
                            $infoTips.addClass('z-ui-tooltips-in');
                        }
                    }
                    else {
                        $infoTips.find('.validator-msg').html('密码由8-20位字母，数字和符号至少两种以上字符组合，区分大小写');
                    }
                }
            },
            checkConfirmPwdCapsLock: function (e) {
                var isCapsLock = capslock.detect(e),
                    $target = $(e.target),
                    $infoTips;

                // 未验证或已通过验证, 则显示大小写已开启
                if ($target.data('verified') === undefined || $target.data('verified') === true) {
                    $infoTips = $target.parents('.ui-form-item-group').find('.custom-tooltips-info');

                    if (isCapsLock) {
                        $infoTips.find('.validator-msg').html('键盘大写锁定已打开，请注意大小写');
                        if (!$infoTips.hasClass('z-ui-tooltips-in')) {
                            $infoTips.addClass('z-ui-tooltips-in');
                        }
                    }
                    else {
                        $infoTips.removeClass('z-ui-tooltips-in z-ui-tooltips-out');
                    }
                }
            },
            getVerifyCode: function (e) {
                safeForm.controls.vfcode.attr('src','/ashx/verifycode.ashx?pid=CN23000101&f=html&ck=1&r=' + Math.random());
            },
            setVerifyForm: function (args) {
                var verifyConfig = $.extend(true, {}, safeForm.configs.formVerify, 0);
                safeForm.verifyValidation = safeForm.controls.verify_form.smartValidator(verifyConfig);
                $('#reg-form-wrapper').find('.account').addClass('hidden');
                $('#reg-form-wrapper').find('.verify').removeClass('hidden');
                safeForm.controls.verify_form.find("#Mobile").html(args.Mobile);
                safeForm.controls.verify_form.find("#Token").val(args.Token);
                safeForm.controls.verify_form.find("#UserCode").html(args.UserCode);
                safeForm.controls.verify_form.find("#UserID").val(args.UserID);

                var lis = $('.rn-reg-t-wrapper ul li');
                $(lis[0]).removeClass('current').addClass('prev');
                $(lis[1]).removeClass('next').addClass('current');
                $(lis[2]).removeClass('nnext').addClass('next');
            },
            setSafeResetForm: function (args) {
                var resetConfig = $.extend(true, {}, safeForm.configs.formReset, 0);
                safeForm.resetValidation = safeForm.controls.reset_form.smartValidator(resetConfig);
                $('#reg-form-wrapper').find('.account').addClass('hidden');
                $('#reg-form-wrapper').find('.verify').addClass('hidden');
                $('#reg-form-wrapper').find('.safreset').removeClass('hidden');
                safeForm.controls.reset_form.find("#Token").val(args.Token);
                safeForm.controls.reset_form.find("#UserID").val(args.UserID);
                var lis = $('.rn-reg-t-wrapper ul li');
                $(lis[0]).removeClass('prev').addClass('r0');
                $(lis[1]).removeClass('current').addClass('r85');
                $(lis[2]).removeClass('next').addClass('current');
                $(lis[3]).removeClass('next').addClass('l41');
            },
            jumpErrorForm: function () {
                $('#reg-form-wrapper').find('.account').addClass('hidden');
                $('#reg-form-wrapper').find('.verify').addClass('hidden');
                $('#reg-form-wrapper').find('.safreset').addClass('hidden');
                $('#reg-form-wrapper').find('.safeerror').removeClass('hidden');
                var lis = $('.rn-reg-t-wrapper ul li');
                $(lis[0]).removeClass('current').addClass('r0');
                $(lis[1]).removeClass('r85').addClass('r0');
                $(lis[2]).removeClass('current').addClass('r85');
                $(lis[3]).removeClass('next').addClass('current');
                $(lis[4]).removeClass('nnext').addClass('l41');
            },
            jumpSuccessForm: function () {
                $('#reg-form-wrapper').find('.account').addClass('hidden');
                $('#reg-form-wrapper').find('.verify').addClass('hidden');
                $('#reg-form-wrapper').find('.safreset').addClass('hidden');
                $('#reg-form-wrapper').find('.safeerror').addClass('hidden');
                $('#reg-form-wrapper').find('.safesuccess').removeClass('hidden');

                //set title class
                var lis = $('.rn-reg-t-wrapper ul li');
                $(lis[0]).removeClass('current').addClass('r0');
                $(lis[1]).removeClass('r85').addClass('r0');
                $(lis[2]).removeClass('current').addClass('r85');
                $(lis[3]).removeClass('next').addClass('current');
                $(lis[4]).removeClass('nnext').addClass('l41');
            }
        },
        configs: {
            formAccount: {
                rules: {
                    'ImgVerifyCode': {
                        'required': true,
                        'regex': /^[a-zA-Z0-9]{4}$/
                    },
                    'UserCode': {
                        'required': true,
                        'regex': /^[a-zA-Z]{1}([a-zA-Z0-9._]){2,21}$/
                    }
                },
                messages: {
                    'UserCode': {
                        'required': '帐号不能为空'
                    },
                    'ImgVerifyCode': {
                        'required': '请输入验证码'
                    }
                },
                infos: {
                    'UserCode': '请输入您的帐号',
                    'ImgVerifyCode': '请输入4位图片验证码'
                },
                onsubmit: function () {
                    var channel, bindToken;
                    var url, formData, isGenderChecked, isAgreeChecked, gender, agree;
                    formData = safeForm.controls.moForm.serialize();
                    url = '/ashx/safehandler.ashx?Method=PartnerSafeVerify&v=' + Math.random();
                    safeForm.controls.moForm.find('.custom-tooltips-info').removeClass('z-ui-tooltips-in z-ui-tooltips-out');
                    $.post(
                        url,
                        formData,
                        function (data) {
                            var $el, $warningTips, tempHtml;
                            if (typeof (data.result) !== 'undefined' && data.result === 'error') {
                                // 系统级错误
                                if (data.errorCode === 10 || data.errorCode === 11 || data.errorCode === 31) {
                                    safeForm.showSystemErrorTips(safeForm.configs.VerifyErrorCode[data.errorCode]);
                                }
                                else if (data.errorCode === 33) {
                                    safeForm.showSystemErrorTips(safeForm.configs.VerifyErrorCode[data.errorCode]);
                                    //跳转至返回页面
                                    safeForm.events.jumpErrorForm();
                                }
                                else {
                                    $el = $(safeForm.configs.VerifyErrorCode[data.errorCode][0]);
                                    tempHtml = safeForm.configs.VerifyErrorCode[data.errorCode][1];
                                    // 显示错误
                                    safeForm.formValidation.showError($el, tempHtml);
                                }
                            }
                            else if (typeof (data.result) !== 'undefined' && data.result === 'success') {
                                //
                                safeForm.events.setVerifyForm(data.data);
                            }
                            else {
                                safeForm.showSystemErrorTips('请求失败，请刷新页面重试');
                            }
                        }, 'json')
                        .done(function () {
                            safeForm.controls.btnAccNext.removeClass('z-ui-btn-loading');
                        })
                        .error(function () {
                            safeForm.showSystemErrorTips(safeForm.configs.mobileFormErrorCode[10]);
                        });
                }
            },
            formVerify: {
                onsubmit: function () {
                    var channel, bindToken;
                    var url, formData, isGenderChecked, isAgreeChecked, gender, agree;
                    formData = safeForm.controls.verify_form.serialize();
                    url = '/ashx/safehandler.ashx?Method=PartnerSendSMS&v=' + Math.random();
                    // 隐藏custom tips
                    safeForm.controls.verify_form.find('.custom-tooltips-info').removeClass('z-ui-tooltips-in z-ui-tooltips-out');
                    $.post(
                        url,
                        formData,
                        function (data) {
                            var $el, $warningTips, tempHtml;
                            if (typeof (data.result) !== 'undefined' && data.result === 'error') {
                                // 系统级错误
                                if (data.errorCode === 10 || data.errorCode === 11 || data.errorCode === 31) {
                                    safeForm.showSystemErrorTips(safeForm.configs.VerifyErrorCode[data.errorCode]);
                                }
                                else if (data.errorCode === 33) {
                                    safeForm.showSystemErrorTips(safeForm.configs.VerifyErrorCode[data.errorCode]);
                                    //跳转至返回页面
                                    safeForm.events.jumpErrorForm();
                                }
                                else {
                                    $el = $(safeForm.configs.VerifyErrorCode[data.errorCode][0]);
                                    tempHtml = safeForm.configs.VerifyErrorCode[data.errorCode][1];
                                    // 显示错误
                                    safeForm.verifyValidation.showError($el, tempHtml);
                                }
                            }
                            else if (typeof (data.result) !== 'undefined' && data.result === 'success') {
                                safeForm.events.setSafeResetForm(data.data);
                            }
                            else {
                                safeForm.showSystemErrorTips('请求失败，请刷新页面重试');
                            }
                        }, 'json')
                        .done(function () {
                            safeForm.controls.btnAccVerify.removeClass('z-ui-btn-loading');
                        })
                        .error(function () {
                            safeForm.showSystemErrorTips(safeForm.configs.mobileFormErrorCode[10]);
                        });
                }
            },
            formReset: {
                rules: {
                    'SMSVerifyCode': {
                        'required': true,
                        'regex': /^[a-zA-Z0-9]{4}$/
                    },
                    'Password': {
                        'required': true,
                        'checkpwd': true
                    },
                    'confirmPassword': {
                        'required': true,
                        'equalTo': '#Password'
                    }
                },
                messages: {
                    'SMSVerifyCode': {
                        'required': '请输入4位数字手机验证码',
                        'regex': '请输入4位数字手机验证码'
                    },
                    'Password': {
                        'required': '密码不能为空'
                    },
                    'confirmPassword': {
                        'required': '请输入确认密码',
                        'equalTo': '两次输入的密码不一致，请重新输入'
                    }
                },
                infos: {
                    'Password': '密码由8-20位字母，数字和符号至少两种以上字符组合，区分大小写',
                    'SMSVerifyCode': '请输入4位数字手机验证码'
                },
                onsubmit: function () {
                    var channel, bindToken;
                    var url, formData, isGenderChecked, isAgreeChecked, gender, agree;
                    formData = safeForm.controls.reset_form.serialize();
                    url = '/ashx/safehandler.ashx?Method=PartnerResetPwdByMobile&v=' + Math.random();
                    // 隐藏custom tips
                    safeForm.controls.reset_form.find('.custom-tooltips-info').removeClass('z-ui-tooltips-in z-ui-tooltips-out');
                    $.post(
                        url,
                        formData,
                        function (data) {
                            var $el, $warningTips, tempHtml;
                            if (typeof (data.result) !== 'undefined' && data.result === 'error') {
                                // 系统级错误
                                if (data.errorCode === 10 || data.errorCode === 11 || data.errorCode === 31) {
                                    safeForm.showSystemErrorTips(safeForm.configs.VerifyErrorCode[data.errorCode]);
                                }
                                else if (data.errorCode === 33) {
                                    safeForm.showSystemErrorTips(safeForm.configs.VerifyErrorCode[data.errorCode]);
                                    //跳转至返回页面
                                    safeForm.events.jumpErrorForm();
                                }
                                else {
                                    $el = $(safeForm.configs.VerifyErrorCode[data.errorCode][0]);
                                    tempHtml = safeForm.configs.VerifyErrorCode[data.errorCode][1];
                                    // 显示错误
                                    safeForm.resetValidation.showError($el, tempHtml);
                                }
                            }
                            else if (typeof (data.result) !== 'undefined' && data.result === 'success') {
                                //修改完成
                                safeForm.events.jumpSuccessForm();
                            }
                            else {
                                safeForm.showSystemErrorTips('请求失败，请刷新页面重试');
                            }
                        }, 'json')
                        .done(function () {
                            safeForm.controls.btnConfirm.removeClass('z-ui-btn-loading');
                        })
                        .error(function () {
                            safeForm.showSystemErrorTips(safeForm.configs.mobileFormErrorCode[10]);
                        });
                }
            },
            smsErrorCode: {
                22001: '该手机获取验证码已达上限，请隔日重试',
                20205: '该手机获取验证码已达上限，请隔日重试',
                22101: '手机号码输入错误，无法获取验证码'
            },
            smsInfoTips: {
                '3': '校验码已发出，请注意查收短信，今日还可获取<span class="f-pink">2次</span>验证码',
                '2': '校验码已发出，请注意查收短信，今日还可获取<span class="f-pink">1次</span>验证码',
                '1': '校验码已发出，请注意查收短信，今日获取次数已达上限',
                'other': '验证码已发送，请查收短信',
                'exceedLimited': '该手机获取验证码已达上限，请隔日重试',
                'occurError': '获取验证码失败，请重试'
            },
            mobileFormErrorCode: {
                6: ['#Password', '密码需要md5加密传输'],
                10: '系统发生错误，请重试',
                25: ['#SMSVerifyCode', '未获取短信验证码'],
                26: ['#SMSVerifyCode', '短信验证码无效'],
                27: ['#SMSVerifyCode', '验证码已过期'],
                23: ['#ImgVerifyCode', '验证码错误'],
                30: ['#UserCode', '帐号不存在'],
                31: '非法数据提交',
                33: '手机未验证，请联系管理员重置密码'
            },
            mobileCheckerErrorCode: {
                10: [false, '系统发生错误，请重试'],
                30: [false, '帐号不能为空'],
                31: '非法数据提交',
                33: '手机未验证，请联系管理员重置密码'
            },
            VerifyErrorCode: {
                10: '系统发生错误，请重试',
                22: ['#ImgVerifyCode', '未获取验证码'],
                23: ['#ImgVerifyCode', '验证码错误'],
                24: ['#ImgVerifyCode', '验证码已过期'],
                30: ['#UserCode', '帐号不存在'],
                31: '非法数据提交',
                33: '手机未验证，请联系管理员重置密码'
            }
        }
    };

    $(function () {
        safeForm.init();
    });
})(jQuery);