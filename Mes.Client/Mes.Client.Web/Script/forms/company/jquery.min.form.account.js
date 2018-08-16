(function ($) {
    var buy_form = {
        init: function () {
            this.initcontrols();
            this.controls.buy.on('click', this.events.openbuyform);
            this.controls.buysubmit.on('click', this.events.onbuysubmit);
            this.controls.buyreject.on('click', this.events.closebuyform);
            this.controls.charge.on('click', this.events.openchargeform);
            this.controls.chargesubmit.on('click', this.events.onchargesubmit);
            this.controls.chargereject.on('click', this.events.closechargeform);
            this.controls.month.slider({
                showTip: true,
                min: 1,
                max: 14,
                step: 1,
                height: 80,
                rule: [1, '|', 2, '|', 3, '|', 4, '|', 5, '|', '半年', '|', 7, '|', 8, '|', 9, '|', 10, '|', 11, '|', '1年', '|', '2年', '|', '3年'],
                tipFormatter: function (value) {
                    switch (value) {
                        case 3:
                            return '一个季度';
                        case 6:
                            return '半年';
                        case 12:
                            return '1年';
                        case 13:
                            return '2年'
                        case 14:
                            return '3年';
                        default:
                            return value + '个月';
                    }
                }
            });
            buy_form.controls.userqty.combobox({
                editable: false,
                required: true,
                onChange: function (newvalue, oldvalue) {
                    buy_form.controls.amount.textbox('setValue', newvalue);
                }
            });
        },
        initcontrols: function () {            
            buy_form.controls = {                
                buy: $('#btn_buy'),
                buysubmit: $('#btn_buy_submit'),
                buyreject: $('#btn_buy_reject'),
                charge: $('#btn_charge'),
                chargesubmit: $('#btn_charge_submit'),
                chargereject: $('#btn_charge_reject'),
                buy_window: $("#buy_window"),
                buy_form: $("#buy_form"),
                charge_window: $("#charge_window"),
                charge_form: $("#charge_form"),
                month: $('#BuyMonth'),
                userqty: $('#UserQty'),
                amount: $('#Amount'),
                systemErrorTips: $("#buy_form").find('.ui-tips'),
            }
        },
        showSystemErrorTips: function (errorMsg) {
            buy_form.controls.systemErrorTips.removeClass('hidden')
                .find('.info-msg')
                .html(errorMsg);

            buy_form.systemErrorTimer = setTimeout(function () {
                buy_form.hideSystemErrorTips();
            }, 5000);
        },
        hideSystemErrorTips: function () {
            if (buy_form.systemErrorTimer) {
                clearTimeout(buy_form.systemErrorTimer);
            }
            buy_form.controls.systemErrorTips.addClass('hidden')
                .find('.info-msg')
                .html('');
        },
        events: {
            onbuysubmit: function () {
                var formData = buy_form.controls.buy_form.serialize();
                var url = '/ashx/companyhandler.ashx?Method=Buy&v=' + Math.random();
                $.post(
                    url,
                    formData,
                    function (data) {
                        if (typeof (data.result) !== 'undefined' && data.result === 'error') {
                            // 系统级错误    
                            var errmsg = "";
                            registerForm.showSystemErrorTips(registerForm.configs.ErrorCode[data.errorCode]);
                        }
                        else if (typeof (data.result) !== 'undefined' && data.result === 'success') {
                            buy_form.showSystemErrorTips('购买成功！');
                            setTimeout(function () {
                                buy_form.events.closebuyform();
                            }, 3000);                            
                        }
                        else {
                            buy_form.showSystemErrorTips('请求失败，请刷新页面重试');
                        }
                    }, 'json')
                    .done(function () {
                        //buy_form.controls.btnregister.removeClass('z-ui-btn-loading');                        
                    })
                    .error(function () {
                        buy_form.showSystemErrorTips(buy_form.configs.ErrorCode[10000]);
                    });
            },
            onchargesubmit: function () {
            },
            openbuyform: function () {
                buy_form.controls.buy_form.form('clear');
                buy_form.controls.userqty.combobox('setValue', 5);
                buy_form.controls.month.slider('setValue', 12);
                buy_form.controls.buy_window.window('open');
            },
            closebuyform: function () {
                buy_form.controls.buy_window.window('close');
            },
            openchargeform: function () {
                buy_form.controls.charge_form.form('clear');
                buy_form.controls.charge_window.window('open');
            },
            closechargeform: function () {
                buy_form.controls.charge_window.window('close');
            }
        },
        configs: {
            ErrorCode: {
                10000: '网络连接超时，请检查网络是否正常',
                10001: '购买失败！系统发生异常错误。请稍候再试。',
                22001: '购买失败！帐户余额不足，请充值后再购买。',
                22002: '您的帐户异常，禁止购买。',
                22003: '续费失败'
            },
        }
    };
    $(function () {
        buy_form.init();
    });
})(jQuery);