var EmptyGuid = '00000000-0000-0000-0000-000000000000';
$.extend($.fn.datagrid.defaults, {
    fit: true,
    nowrap: false,
    striped: true,
    rownumbers: true,
    singleSelect: true,
    pagination: true,
    pageSize: 20,
    sortOrder: 'ASC',
    border: false,
    striped: false,
    pageList: [10, 20, 30, 40, 50],
    onLoadSuccess: function (data) {
        $(this).datagrid('clearSelections');
    },
    onLoadError: function (XMLHttpRequest, textStatus, errorThrown) {
        if (XMLHttpRequest.status == "0") return;
        var substr = XMLHttpRequest.responseText;
        if (substr === "TimeOut") {
            showError("登录超时，3秒后将返回登录页面....");
            setTimeout(function () {
                top.window.location.href = '/partnerLogin.aspx';
            }, 3000);
        }
        else {
            showError('加载数据错误！原因：' + XMLHttpRequest.responseText);
        }
    }
});

function htmlEncode(str) {
    var ele = document.createElement('div');
    ele.appendChild(document.createTextNode(str));
    return ele.innerHTML;
}
function htmlDecode(str) {
    var s = "";
    if (str.length == 0) return "";
    s = str.replace(/\&gt;/g, "&");
    s = s.replace(/\&lt;/g, "<");
    s = s.replace(/\&gt;/g, ">");
    s = s.replace(/\&nbsp;/g, " ");
    s = s.replace(/\&#39;/g, "\'");
    s = s.replace(/\&quot;/g, "\"");
    s = s.replace(/<br>/g, "\n");
    return s;
}

$.extend($.fn.datagrid.defaults.editors, {
    my97: {
        init: function (container, options) {
            var input = $('<input class="Wdate" onclick="WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm:ss\',readOnly:true});"  />').appendTo(container);
            return input;
        },
        getValue: function (target) {
            return $(target).val();
        },
        setValue: function (target, value) {
            $(target).val(value);
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    },
    datetimebox: {//datetimebox就是你要自定义editor的名称
        init: function (container, options) {
            var input = $('<input class="easyuidatetimebox">').appendTo(container);
            return input.datetimebox({
                formatter: function (date) {
                    return new Date(date).format("yyyy-MM-dd hh:mm:ss");
                }
            });
        },
        getValue: function (target) {
            return $(target).parent().find('input.combo-value').val();
        },
        setValue: function (target, value) {
            $(target).datetimebox("setValue", value);
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    }
});

$.extend($.fn.datagrid.methods, {
    addToolbarItem: function (jq, items) {
        return jq.each(function () {
            var toolbar = $(this).parent().prev("div.datagrid-toolbar");
            for (var i = 0; i < items.length; i++) {
                var item = items[i];
                if (item === "-") {
                    toolbar.append('<div class="datagrid-btn-separator"></div>');
                } else {
                    var btn = $("<a href=\"javascript:void(0)\"></a>");
                    btn[0].onclick = eval(item.handler || function () { });
                    btn.css("float", "left").appendTo(toolbar).linkbutton($.extend({}, item, { plain: true }));
                }
            }
            toolbar = null;
        });
    },
    removeToolbarItem: function (jq, param) {
        return jq.each(function () {
            var btns = $(this).parent().prev("div.datagrid-toolbar").children("a");
            var cbtn = null;
            if (typeof param == "number") {
                cbtn = btns.eq(param);
            } else if (typeof param == "string") {
                var text = null;
                btns.each(function () {
                    text = $(this).data().linkbutton.options.text;
                    if (text == param) {
                        cbtn = $(this);
                        text = null;
                        return;
                    }
                });
            }
            if (cbtn) {
                var prev = cbtn.prev()[0];
                var next = cbtn.next()[0];
                if (prev && next && prev.nodeName == "DIV" && prev.nodeName == next.nodeName) {
                    $(prev).remove();
                } else if (next && next.nodeName == "DIV") {
                    $(next).remove();
                } else if (prev && prev.nodeName == "DIV") {
                    $(prev).remove();
                }
                cbtn.remove();
                cbtn = null;
            }
        });
    },
    addToobar: function (jq, pl) {
        return jq.each(function () {
            var toolbar = $(this).parent().prev("div.datagrid-toolbar");
            toolbar.append($(pl).innerHTML);
            toolbar = null;
        });
    }

});
$.extend($.fn.linkbutton.methods, {
    enable: function (jq) {
        return jq.each(function (n, obj) {
            var state = $.data(obj, "linkbutton");
            state.options.disabled = false;
            if (state.href) {
                $(obj).attr("href", state.href);
            }
            if (state.onclick) {
                obj.onclick = state.onclick;
            }
            if (state.events) {
                for (var i = 0; i < state.events.length; i++) {
                    $(obj).bind(state.events[i].type, state.events[i].handler);
                }
            }
            $(obj).removeClass("l-btn-disabled");
        });
    }
});

$.extend($.fn.linkbutton.methods, {
    disable: function (jq) {
        return jq.each(function (n, obj) {
            var state = $.data(obj, "linkbutton");
            state.options.disabled = true;
            var href = $(obj).attr("href");
            if (href) {
                state.href = href;
                $(obj).attr("href", "javascript:void(0)");
            }
            if (obj.onclick) {
                obj.onclick = obj.onclick;
                obj.onclick = null;
            }
            //事件处理
            var events = $(obj).data("events");
            if (events) {
                var clicks = events.click;//暂时只处理click事件
                state.events = state.events || [];
                $.extend(state.events, clicks);
                $(obj).unbind("click");
            }

            $(obj).addClass("l-btn-disabled");
        });
    }
});
$.extend($.fn.window.defaults, {
    modal: true,
    //closed: true,
    shadow: false,
    collapsible: false,
    minimizable: false,
    maximizable: false
});

$.extend($.fn.tree.defaults, {
    onLoadError: function (XMLHttpRequest, textStatus, errorThrown) {
        if (XMLHttpRequest.status == "0") return;
        var substr = XMLHttpRequest.responseText;
        if (substr === "TimeOut") {
            showError("登录超时，3秒后将返回登录页面....");
            setTimeout(function () {
                top.window.location.href = '/partnerLogin.aspx';
            }, 3000);
        }
        else {
            showError('加载数据错误！原因：' + XMLHttpRequest.responseText);
        }
    }
});

$.extend($.fn.datagrid.defaults.editors, {
    combogrid: {
        init: function (container, options) {
            var input = $('<inputtype="text" class="datagrid-editable-input">').appendTo(container);
            input.combogrid(options);
            return input;
        },
        destroy: function (target) {
            $(target).combogrid('destroy');
        },
        getValue: function (target) {
            return $(target).combogrid('getValue');
        },
        setValue: function (target, value) {
            $(target).combogrid('setValue', value);
        },
        resize: function (target, width) {
            $(target).combogrid('resize', width);
        }
    }
});

$.ajaxSetup({
    global: false,
    type: "POST",
    dataType: 'json',
    //请求失败遇到异常触发
    error: function (XMLHttpRequest, textStatus, errorThrown) {
        if (textStatus == 200) return;
        if (XMLHttpRequest.responseText == '') return;
        if (XMLHttpRequest.status == "0") return;
        var substr = XMLHttpRequest.responseText;
        if (substr === "TimeOut") {
            showError("登录超时，3秒后将返回登录页面....");
            setTimeout(function () {
                top.window.location.href = '/partnerLogin.aspx';
            }, 3000);
        }
        else {
            showError('加载数据错误！原因：' + XMLHttpRequest.responseText);
        }
    }
});

function showError(message) {
    $.messager.alert('错误信息', message, 'error');
}
function showInfo(message) {
    $.messager.alert("提示信息", message, "info");
}

String.prototype.format = function () {
    var args = arguments;
    return this.replace(/\{(\d+)\}/g,
         function (m, i) {
             return args[i];
         });
}
String.format = function () {
    if (arguments.length == 0)
        return null;

    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;
}
/*===============================================================*/

/*===================EasyUI通用验证扩展开始===================*/
$.extend($.fn.validatebox.defaults.rules, {
    CHS: {
        validator: function (value, param) {
            return /^[\u0391-\uFFE5]+$/.test(value);
        },
        message: '请输入汉字'
    },
    Date: {
        validator: function (value, param) {
            return /^\d{4}(-|\/)\d{1,2}(-|\/)\d{1,2}(\s\d{1,2}:\d{1,2}:\d{1,2})?$/.test(value);
        },
        message: '请输入合法时间'
    },
    ZIP: {
        validator: function (value, param) {
            return /^[1-9]\d{5}$/.test(value);
        },
        message: '邮政编码不存在'
    },
    QQ: {
        validator: function (value, param) {
            return /^[1-9]\d{4,10}$/.test(value);
        },
        message: 'QQ号码不正确'
    },
    mobile: {
        validator: function (value, param) {
            return /^((\(\d{2,3}\))|(\d{3}\-))?1\d{10}$/.test(value);
        },
        message: '手机号码不正确'
    },
    tel: {
        validator: function (value, param) {
            return /^((0\d{2,3}-?)|(\(0\d{2,3}\)))\d{7,8}$/.test(value);
        },
        message: '电话号码不正确。格式：(020)88888888,020-8888888,02088888888'
    },
    email: {
        validator: function (value, param) {
            return /^(\w-*\.*)+@(\w-?)+(\.\w{2,})+$/.test(value);
        },
        message: '请输入正确的email地址。'
    },
    loginName: {
        validator: function (value, param) {
            return /^[\u0391-\uFFE5\w]+$/.test(value);
        },
        message: '登录名称只允许汉字、英文字母、数字及下划线。'
    },
    safepass: {
        validator: function (value, param) {
            return safePassword(value);
        },
        message: '密码由字母和数字组成，至少6位'
    },
    equalTo: {
        validator: function (value, param) {
            return value == $(param[0]).val();
        },
        message: '两次输入的字符不一致。'
    },
    number: {
        validator: function (value, param) {
            return /^\d+$/.test(value);
        },
        message: '请输入数字'
    },
    amount: {
        validator: function (value, param) {
            return /^(-)?(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/.test(value);
        },
        message: '请输入正确金额格式'
    },

    idcard: {
        validator: function (value, param) {
            return idCard(value);
        },
        message: '请输入正确的身份证号码'
    },
    safePassword: {
        validator: function (value, param) {
            return !(/^(([A-Z]*|[a-z]*|\d*|[-_\~!@#\$%\^&\*\.\(\)\[\]\{\}<>\?\\\/\'\"]*)|.{0,5})$|\s/.test(value));
        },
        message: '密码由字母和数字组成，至少6位'
    },
    idcard2: {
        validator: function (idcard, param) {
            var idcard = value;
            var Errors = new Array(
            "验证通过!",
            "身份证号码位数不对!",
            "身份证号码出生日期超出范围或含有非法字符!",
            "身份证号码校验错误!",
            "身份证地区非法!"
            );
            var area = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南", 42: "湖北", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外" }

            var idcard, Y, JYM;
            var S, M;
            var idcard_array = new Array();
            idcard_array = idcard.split("");
            //地区检验
            if (area[parseInt(idcard.substr(0, 2))] == null) {
                alert(Errors[4]);
                return false;
            }
            //身份号码位数及格式检验
            switch (idcard.length) {
                case 15:
                    if ((parseInt(idcard.substr(6, 2)) + 1900) % 4 == 0 || ((parseInt(idcard.substr(6, 2)) + 1900) % 100 == 0 && (parseInt(idcard.substr(6, 2)) + 1900) % 4 == 0)) {
                        ereg = /^[1-9][0-9]{5}[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}$/; //测试出生日期的合法性
                    } else {
                        ereg = /^[1-9][0-9]{5}[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))[0-9]{3}$/; //测试出生日期的合法性
                    }
                    if (ereg.test(idcard)) return true;
                    else {
                        alert(Errors[2]);
                        return false;
                    }
                    break;
                case 18:
                    //18位身份号码检测
                    //出生日期的合法性检查 
                    //闰年月日:((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))
                    //平年月日:((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))
                    if (parseInt(idcard.substr(6, 4)) % 4 == 0 || (parseInt(idcard.substr(6, 4)) % 100 == 0 && parseInt(idcard.substr(6, 4)) % 4 == 0)) {
                        ereg = /^[1-9][0-9]{5}(19|20)[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}[0-9Xx]$/; //闰年出生日期的合法性正则表达式
                    } else {
                        ereg = /^[1-9][0-9]{5}(19|20)[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))[0-9]{3}[0-9Xx]$/; //平年出生日期的合法性正则表达式
                    }
                    if (ereg.test(idcard)) {//测试出生日期的合法性
                        //计算校验位
                        S = (parseInt(idcard_array[0]) + parseInt(idcard_array[10])) * 7
                        + (parseInt(idcard_array[1]) + parseInt(idcard_array[11])) * 9
                        + (parseInt(idcard_array[2]) + parseInt(idcard_array[12])) * 10
                        + (parseInt(idcard_array[3]) + parseInt(idcard_array[13])) * 5
                        + (parseInt(idcard_array[4]) + parseInt(idcard_array[14])) * 8
                        + (parseInt(idcard_array[5]) + parseInt(idcard_array[15])) * 4
                        + (parseInt(idcard_array[6]) + parseInt(idcard_array[16])) * 2
                        + parseInt(idcard_array[7]) * 1
                        + parseInt(idcard_array[8]) * 6
                        + parseInt(idcard_array[9]) * 3;
                        Y = S % 11;
                        M = "F";
                        JYM = "10X98765432";
                        M = JYM.substr(Y, 1); //判断校验位
                        if (M == idcard_array[17]) return true; //检测ID的校验位
                        else {
                            alert(Errors[3]);
                            return false;
                        }
                    }
                    else {
                        alert(Errors[2]);
                        return false;
                    }
                    break;
                default:
                    alert(Errors[1]);
                    return false;
                    break;
            }
        },
        message: '身份证号非法'
    },
    idCard: {
        validator: function (value, param) {
            if (value.length == 18 && 18 != value.length) return false;
            var number = value.toLowerCase();
            var d, sum = 0, v = '10x98765432', w = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2], a = '11,12,13,14,15,21,22,23,31,32,33,34,35,36,37,41,42,43,44,45,46,50,51,52,53,54,61,62,63,64,65,71,81,82,91';
            var re = number.match(/^(\d{2})\d{4}(((\d{2})(\d{2})(\d{2})(\d{3}))|((\d{4})(\d{2})(\d{2})(\d{3}[x\d])))$/);
            if (re == null || a.indexOf(re[1]) < 0) return false;
            if (re[2].length == 9) {
                number = number.substr(0, 6) + '19' + number.substr(6);
                d = ['19' + re[4], re[5], re[6]].join('-');
            } else d = [re[9], re[10], re[11]].join('-');
            // if (!isDateTime.call(d, 'yyyy-MM-dd')) return false;
            for (var i = 0; i < 17; i++) sum += number.charAt(i) * w[i];
            return (re[2].length == 9 || number.charAt(17) == v.charAt(sum % 11));
        },
        message: '身份证号非法'
    },
    isDateTime:
    {
        validator: function (value, param) {
            format = param[0] || 'yyyy-MM-dd';
            var input = this, o = {}, d = new Date();
            var f1 = format.split(/[^a-z]+/gi), f2 = input.split(/\D+/g), f3 = format.split(/[a-z]+/gi), f4 = input.split(/\d+/g);
            var len = f1.length, len1 = f3.length;
            if (len != f2.length || len1 != f4.length) return false;
            for (var i = 0; i < len1; i++) if (f3[i] != f4[i]) return false;
            for (var i = 0; i < len; i++) o[f1[i]] = f2[i];
            o.yyyy = s(o.yyyy, o.yy, d.getFullYear(), 9999, 4);
            o.MM = s(o.MM, o.M, d.getMonth() + 1, 12);
            o.dd = s(o.dd, o.d, d.getDate(), 31);
            o.hh = s(o.hh, o.h, d.getHours(), 24);
            o.mm = s(o.mm, o.m, d.getMinutes());
            o.ss = s(o.ss, o.s, d.getSeconds());
            o.ms = s(o.ms, o.ms, d.getMilliseconds(), 999, 3);
            if (o.yyyy + o.MM + o.dd + o.hh + o.mm + o.ss + o.ms < 0) return false;
            if (o.yyyy < 100) o.yyyy += (o.yyyy > 30 ? 1900 : 2000);
            d = new Date(o.yyyy, o.MM - 1, o.dd, o.hh, o.mm, o.ss, o.ms);
            var reVal = d.getFullYear() == o.yyyy && d.getMonth() + 1 == o.MM && d.getDate() == o.dd && d.getHours() == o.hh && d.getMinutes() == o.mm && d.getSeconds() == o.ss && d.getMilliseconds() == o.ms;
            return reVal && reObj ? d : reVal;
            function s(s1, s2, s3, s4, s5) {
                s4 = s4 || 60, s5 = s5 || 2;
                var reVal = s3;
                if (s1 != undefined && s1 != '' || !isNaN(s1)) reVal = s1 * 1;
                if (s2 != undefined && s2 != '' && !isNaN(s2)) reVal = s2 * 1;
                return (reVal == s1 && s1.length != s5 || reVal > s4) ? -10000 : reVal;
            }
        },
        message: '身份证号非法'
    }

});
/*===================EasyUI通用验证扩展结束===================*/


// 判断闰年

Date.prototype.isLeapYear = function () {

    return (0 == this.getYear() % 4 && ((this.getYear() % 100 != 0) || (this.getYear() % 400 == 0)));

}


// 日期格式化

// 格式 YYYY/yyyy/YY/yy 表示年份

// MM/M 月份

// W/w 星期

// dd/DD/d/D 日期

// hh/HH/h/H 时间

// mm/m 分钟

// ss/SS/s/S 秒
Date.prototype.Format = function (formatStr) {

    var str = formatStr;

    var Week = ['日', '一', '二', '三', '四', '五', '六'];

    str = str.replace(/yyyy|YYYY/, this.getFullYear());

    str = str.replace(/yy|YY/, (this.getYear() % 100) > 9 ? (this.getYear() % 100).toString() : '0' + (this.getYear() % 100));

    str = str.replace(/MM/, this.getMonth() > 9 ? this.getMonth().toString() : '0' + this.getMonth());

    str = str.replace(/M/g, this.getMonth());

    str = str.replace(/w|W/g, Week[this.getDay()]);

    str = str.replace(/dd|DD/, this.getDate() > 9 ? this.getDate().toString() : '0' + this.getDate());

    str = str.replace(/d|D/g, this.getDate());

    str = str.replace(/hh|HH/, this.getHours() > 9 ? this.getHours().toString() : '0' + this.getHours());

    str = str.replace(/h|H/g, this.getHours());

    str = str.replace(/mm/, this.getMinutes() > 9 ? this.getMinutes().toString() : '0' + this.getMinutes());

    str = str.replace(/m/g, this.getMinutes());

    str = str.replace(/ss|SS/, this.getSeconds() > 9 ? this.getSeconds().toString() : '0' + this.getSeconds());

    str = str.replace(/s|S/g, this.getSeconds());

    return str;

}

//+---------------------------------------------------

//| 求两个时间的天数差 日期格式为 YYYY-MM-dd

//+---------------------------------------------------

function daysBetween(DateOne, DateTwo) {

    var OneMonth = DateOne.substring(5, DateOne.lastIndexOf('-'));

    var OneDay = DateOne.substring(DateOne.length, DateOne.lastIndexOf('-') + 1);

    var OneYear = DateOne.substring(0, DateOne.indexOf('-'));

    var TwoMonth = DateTwo.substring(5, DateTwo.lastIndexOf('-'));

    var TwoDay = DateTwo.substring(DateTwo.length, DateTwo.lastIndexOf('-') + 1);

    var TwoYear = DateTwo.substring(0, DateTwo.indexOf('-'));

    var cha = ((Date.parse(OneMonth + '/' + OneDay + '/' + OneYear) - Date.parse(TwoMonth + '/' + TwoDay + '/' + TwoYear)) / 86400000);

    return Math.abs(cha);

}

//+---------------------------------------------------

//| 日期计算

//+---------------------------------------------------

Date.prototype.DateAdd = function (strInterval, Number) {
    var dtTmp = this.pattern("yyyy/MM/dd");
    switch (strInterval) {
        case 's': return new Date(Date.parse(dtTmp) + (1000 * Number));

        case 'n': return new Date(Date.parse(dtTmp) + (60000 * Number));

        case 'h': return new Date(Date.parse(dtTmp) + (3600000 * Number));

        case 'd': return new Date(Date.parse(dtTmp) + (86400000 * Number));

        case 'w': return new Date(Date.parse(dtTmp) + ((86400000 * 7) * Number));

        case 'q': return new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + Number * 3, dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());

        case 'm': return new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + Number, dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());

        case 'y': return new Date((dtTmp.getFullYear() + Number), dtTmp.getMonth(), dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());

    }

}

//+---------------------------------------------------

//| 比较日期差 dtEnd 格式为日期型或者 有效日期格式字符串

//+---------------------------------------------------

Date.prototype.DateDiff = function (strInterval, dtEnd) {

    var dtStart = this;

    if (typeof dtEnd == 'string')//如果是字符串转换为日期型
    {

        dtEnd = StringToDate(dtEnd);

    }

    switch (strInterval) {

        case 's': return parseInt((dtEnd - dtStart) / 1000);

        case 'n': return parseInt((dtEnd - dtStart) / 60000);

        case 'h': return parseInt((dtEnd - dtStart) / 3600000);

        case 'd': return parseInt((dtEnd - dtStart) / 86400000);

        case 'w': return parseInt((dtEnd - dtStart) / (86400000 * 7));

        case 'm': return (dtEnd.getMonth() + 1) + ((dtEnd.getFullYear() - dtStart.getFullYear()) * 12) - (dtStart.getMonth() + 1);

        case 'y': return dtEnd.getFullYear() - dtStart.getFullYear();

    }

}

/**

 * 对Date的扩展，将 Date 转化为指定格式的String

 * 月(M)、日(d)、12小时(h)、24小时(H)、分(m)、秒(s)、周(E)、季度(q) 可以用 1-2 个占位符

 * 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)

 * eg:

 * (new Date()).pattern("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423

 * (new Date()).pattern("yyyy-MM-dd E HH:mm:ss") ==> 2009-03-10 二 20:09:04

 * (new Date()).pattern("yyyy-MM-dd EE hh:mm:ss") ==> 2009-03-10 周二 08:09:04

 * (new Date()).pattern("yyyy-MM-dd EEE hh:mm:ss") ==> 2009-03-10 星期二 08:09:04

 * (new Date()).pattern("yyyy-M-d h:m:s.S") ==> 2006-7-2 8:9:4.18

使用：(eval(value.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-M-d h:m:s.S");

 */

Date.prototype.pattern = function (fmt) {

    var o = {

        "M+": this.getMonth() + 1, //月份

        "d+": this.getDate(), //日

        "h+": this.getHours() % 12 == 0 ? 12 : this.getHours() % 12, //小时

        "H+": this.getHours(), //小时

        "m+": this.getMinutes(), //分

        "s+": this.getSeconds(), //秒

        "q+": Math.floor((this.getMonth() + 3) / 3), //季度

        "S": this.getMilliseconds() //毫秒

    };

    var week = {

        "0": "/u65e5",

        "1": "/u4e00",

        "2": "/u4e8c",

        "3": "/u4e09",

        "4": "/u56db",

        "5": "/u4e94",

        "6": "/u516d"

    };

    if (/(y+)/.test(fmt)) {

        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));

    }

    if (/(E+)/.test(fmt)) {

        fmt = fmt.replace(RegExp.$1, ((RegExp.$1.length > 1) ? (RegExp.$1.length > 2 ? "/u661f/u671f" : "/u5468") : "") + week[this.getDay() + ""]);

    }

    for (var k in o) {

        if (new RegExp("(" + k + ")").test(fmt)) {

            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));

        }

    }

    return fmt;

}

function ShowOrHide(TagName, value) {
    var obj = document.getElementById(TagName);
    obj.style.display = value;
}


function getDate(strDate) {
    var st = strDate;
    var a = st.split(" ");
    var b = a[0].split("-");
    var c = a[1].split(":");
    var date = new Date(b[0], b[1], b[2], c[0], c[1], c[2])
    return date;
}
function myparser(s) {
    if (!s) return new Date();
    var time = (s.split(' '));
    var ss = (time[0].split('-'));

    var y = parseInt(ss[0], 10);
    var m = parseInt(ss[1], 10);
    var d = parseInt(ss[2], 10);

    if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
        return new Date(y, m - 1, d);
    } else {
        return new Date();
    }
}

//+---------------------------------------------------

//| 日期输出字符串，重载了系统的toString方法

//+---------------------------------------------------

Date.prototype.toString = function (showWeek) {

    var myDate = this;

    var str = myDate.toLocaleDateString();

    if (showWeek) {
        var Week = ['日', '一', '二', '三', '四', '五', '六'];
        str += ' 星期' + Week[myDate.getDay()];

    }
    return str;
}
//+---------------------------------------------------

//| 字符串转成日期类型

//| 格式 MM/dd/YYYY MM-dd-YYYY YYYY/MM/dd YYYY-MM-dd

//+---------------------------------------------------

function StringToDate(DateStr) {

    var converted = Date.parse(DateStr);

    var myDate = new Date(converted);

    if (isNaN(myDate)) {

        //var delimCahar = DateStr.indexOf('/')!=-1?'/':'-';

        var arys = DateStr.split('-');

        myDate = new Date(arys[0], --arys[1], arys[2]);

    }

    return myDate;
}
//判断两个时间的大小
function validTime(startTime, endTime) {
    var arr1 = startTime.split("-");
    var arr2 = endTime.split("-");
    var date1 = new Date(parseInt(arr1[0]), parseInt(arr1[1]) - 1, parseInt(arr1[2]), 0, 0, 0);
    var date2 = new Date(parseInt(arr2[0]), parseInt(arr2[1]) - 1, parseInt(arr2[2]), 0, 0, 0);
    if (date1.getTime() > date2.getTime()) {
        alert('结束日期不能小于开始日期', this);
        return false;
    } else {
        return true;
    }
    return false;
}

//获取URL参数
function getUrlParam(name) {

    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象

    var r = window.location.search.substr(1).match(reg);  //匹配目标参数

    if (r != null) return unescape(r[2]); return null; //返回参数值

}

//打开新的Tab页
function OpTab(title, url) {
    top.addTab(title, url, "con icon-sys");
}

//格式化日期
Date.prototype.format = function (format) {
    var o = {
        "M+": this.getMonth() + 1,   //month   
        "d+": this.getDate(),         //day   
        "h+": this.getHours(),       //hour   
        "m+": this.getMinutes(),   //minute   
        "s+": this.getSeconds(),   //second   
        "q+": Math.floor((this.getMonth() + 3) / 3),     //quarter   
        "S": this.getMilliseconds()   //millisecond   
    }
    if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
        (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o) if (new RegExp("(" + k + ")").test(format))
        format = format.replace(RegExp.$1,
            RegExp.$1.length == 1 ? o[k] :
                ("00" + o[k]).substr(("" + o[k]).length));
    return format;
};

//身份证验证
function isIdCardNo(num) {
    var factorArr = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1);
    var error;
    var varArray = new Array();
    var intValue;
    var lngProduct = 0;
    var intCheckDigit;
    var intStrLen = num.length;
    var idNumber = num;
    // initialize 
    if ((intStrLen != 15) && (intStrLen != 18)) {
        //error = "输入身份证号码长度不对！"; 
        //alert(error); 
        //frmAddUser.txtIDCard.focus(); 
        return false;
    }
    // check and set value 
    for (i = 0; i < intStrLen; i++) {
        varArray[i] = idNumber.charAt(i);
        if ((varArray[i] < '0' || varArray[i] > '9') && (i != 17)) {
            //error = "错误的身份证号码！."; 
            //alert(error); 
            //frmAddUser.txtIDCard.focus(); 
            return false;
        } else if (i < 17) {
            varArray[i] = varArray[i] * factorArr[i];
        }
    }
    if (intStrLen == 18) {
        //check date 
        var date8 = idNumber.substring(6, 14);
        if (checkDate(date8) == false) {
            //error = "身份证中日期信息不正确！."; 
            //alert(error); 
            return false;
        }
        // calculate the sum of the products 
        for (i = 0; i < 17; i++) {
            lngProduct = lngProduct + varArray[i];
        }
        // calculate the check digit 
        intCheckDigit = 12 - lngProduct % 11;
        switch (intCheckDigit) {
            case 10:
                intCheckDigit = 'X';
                break;
            case 11:
                intCheckDigit = 0;
                break;
            case 12:
                intCheckDigit = 1;
                break;
        }
        // check last digit 
        if (varArray[17].toUpperCase() != intCheckDigit) {
            //error = "身份证效验位错误!...正确为： " + intCheckDigit + "."; 
            //alert(error); 
            return false;
        }
    }
    else { //length is 15 
        //check date 
        var date6 = idNumber.substring(6, 12);
        if (checkDate(date6) == false) {
            //alert("身份证日期信息有误！."); 
            return false;
        }
    }
    //alert ("Correct."); 
    return true;
}
function checkDate(date) {
    return true;
}
//判断当前用户是否拥有某菜单的某权限项
//传入参数PrivilegeCode：菜单权限编码
//    PrivilegeItemCode:菜单项权限编码
//       handleFunction:回调函数
//异步返回格式是'true'或‘false’
//调用方法例子：
//function handleAAA(data) {
//    alert(data);//这里写成功返回的后续处理
//}
//CheckUserPower(菜单权限编码,菜单项权限编码,handleAAA);
function CheckUserPower(PrivilegeCode, PrivilegeItemCode, handleFunction) {
    $.ajax({
        url: '../ashx/UserPower.ashx?Method=CheckUserPower&PrivilegeCode=' + PrivilegeCode + '&PrivilegeItemCode=' + PrivilegeItemCode + '&' + jsNC(),
        cache: true,
        type: "get",
        success: handleFunction
    })
}
//返回当前用户拥有某菜单的权限项集合
//传入参数PrivilegeCode：菜单权限编码
//       handleFunction:回调函数
//异步返回格式是List<string>的JSON格式,菜单项权限编码全部小写
//比如：{"total":4,"rows":["add","view","delete","edit"]}
//调用方法例子：
//function handleAAA(data) {
//    alert(data);//这里写成功返回的后续处理
//}
//CheckUserPowers(菜单权限编码,handleAAA);
function CheckUserPowers(PrivilegeCode, handleFunction) {
    $.ajax({
        url: '../ashx/UserPower.ashx?Method=CheckUserPowers&PrivilegeCode=' + PrivilegeCode + '&' + jsNC(),

        type: "get",
        success: handleFunction
    })
}
//JS日期类型的addDays
Date.prototype.addDays = function (d) {
    this.setDate(this.getDate() + d);
};
//格式化日期
Date.prototype.Formats = function (strformat) {
    var str = "";
    var o = {
        "Y": this.getFullYear(),//year
        "M": (parseInt(this.getMonth()) + 1).toString().length == 2 ? parseInt(this.getMonth()) + 1 : '0' + (parseInt(this.getMonth()) + 1),   //month   
        "d": this.getDate().toString().length == 2 ? this.getDate() : '0' + this.getDate(),         //day   
        "h": this.getHours().toString().length == 2 ? this.getHours() : '0' + this.getHours(),       //hour   
        "m": this.getMinutes().toString().length == 2 ? this.getMinutes() : '0' + this.getMinutes(),   //minute   
        "s": this.getSeconds().toString().length == 2 ? this.getSeconds() : '0' + this.getSeconds(),   //second   
        "q": Math.floor((this.getMonth() + 3) / 3),     //quarter   
        "S": this.getMilliseconds()   //millisecond   
    }
    var r = this.getMonth();
    if (o.Y.toString() == 'NaN')
        o.Y = '';
    if (o.M == '0NaN')
        o.M = '';
    if (o.d == '0NaN')
        o.d = '';
    if (o.h == '0NaN')
        o.h = '';
    if (o.m == '0NaN')
        o.m = '';
    if (o.s == '0NaN')
        o.s = '';
    //yy
    if (strformat.toLocaleLowerCase() == 'yyyy')
        str = o.Y;
    //yyyymm
    if (strformat.toLocaleLowerCase() == 'yyyy-mm')
        str = o.Y + '-' + o.M
    if (strformat.toLocaleLowerCase() == 'yyyy/mm')
        str = o.Y + '/' + o.M
    if (strformat.toLocaleLowerCase() == 'yyyy年mm月')
        //yyyymmdd
        str = o.Y + '年' + o.M + '月'
    if (strformat.toLocaleLowerCase() == 'yyyy-mm-dd')
        str = o.Y + '-' + o.M + '-' + o.d;
    if (strformat.toLocaleLowerCase() == 'yyyy/mm/dd')
        str = o.Y + '/' + o.M + '/' + o.d;
    if (strformat.toLocaleLowerCase() == 'yyyy年mm月dd日')
        str = o.Y + '年' + o.M + '月' + o.d + '日';
    //yyyymmdd hh
    if (strformat.toLocaleLowerCase() == 'yyyy-mm-dd hh')
        str = o.Y + '-' + o.M + '-' + o.d + ' ' + o.h;
    if (strformat.toLocaleLowerCase() == 'yyyy/mm/dd hh')
        str = o.Y + '/' + o.M + '/' + o.d + ' ' + o.h;
    if (strformat.toLocaleLowerCase() == 'yyyy年mm月dd日 hh时')
        str = o.Y + '年' + o.M + '月' + o.d + '日 ' + o.h + '时';
    //yyyymmdd hh:mm
    if (strformat.toLocaleLowerCase() == 'yyyy-mm-dd hh:mm')
        str = o.Y + '-' + o.M + '-' + o.d + ' ' + o.h + ':' + o.m;
    if (strformat.toLocaleLowerCase() == 'yyyy/mm/dd hh:mm')
        str = o.Y + '/' + o.M + '/' + o.d + ' ' + o.h + ':' + o.m;
    if (strformat.toLocaleLowerCase() == 'yyyy年mm月dd日 hh时mm秒')
        str = o.Y + '年' + o.M + '月' + o.d + '日 ' + o.h + '时' + o.m + '分';
    //yyyymmdd hh:mm:ss
    if (strformat.toLocaleLowerCase() == 'yyyy-mm-dd hh:mm:ss')
        str = o.Y + '-' + o.M + '-' + o.d + ' ' + o.h + ':' + o.m + ':' + o.s;
    if (strformat.toLocaleLowerCase() == 'yyyy/mm/dd hh:mm:ss')
        str = o.Y + '/' + o.M + '/' + o.d + ' ' + o.h + ':' + o.m + ':' + o.s;
    if (strformat.toLocaleLowerCase() == 'yyyy年mm月dd日 hh时ss秒')
        str = o.Y + '年' + o.M + '月' + o.d + '日 ' + o.h + '时' + o.m + '分' + o.s + '秒';
    //mm
    if (strformat.toLocaleLowerCase() == 'mm')
        str = o.M;
    //mmdd
    if (strformat.toLocaleLowerCase() == 'mm-dd')
        str = o.M + '-' + o.d;
    if (strformat.toLocaleLowerCase() == '/mm/dd')
        str = o.M + '/' + o.d;
    if (strformat.toLocaleLowerCase() == 'mm月dd日')
        str = o.M + '月' + o.d + '日 ';
    //mmdd hh
    if (strformat.toLocaleLowerCase() == 'mm-dd hh')
        str = o.M + '-' + o.d + ' ' + o.h;
    if (strformat.toLocaleLowerCase() == 'mm/dd hh')
        str = o.M + '/' + o.d + ' ' + o.h;
    if (strformat.toLocaleLowerCase() == 'mm月dd日 hh时')
        str = o.M + '月' + o.d + '日 ' + o.h + '时';
    //mmdd hh:mm
    if (strformat.toLocaleLowerCase() == 'mm-dd hh:mm')
        str = o.M + '-' + o.d + ' ' + o.h + ':' + o.m;
    if (strformat.toLocaleLowerCase() == 'mm/dd hh:mm')
        str = o.M + '/' + o.d + ' ' + o.h + ':' + o.m;
    if (strformat.toLocaleLowerCase() == 'mm月dd日 hh时mm分')
        str = o.M + '月' + o.d + '日 ' + o.h + '时' + o.m + '分';

    //mmdd hh:mm:ss
    if (strformat.toLocaleLowerCase() == 'mm-dd hh:mm:ss')
        str = o.M + '-' + o.d + ' ' + o.h + ':' + o.m + ':' + o.s;
    if (strformat.toLocaleLowerCase() == 'mm/dd hh:mm:ss')
        str = o.M + '/' + o.d + ' ' + o.h + ':' + o.m + ':' + o.s;
    if (strformat.toLocaleLowerCase() == 'mm月dd日 hh时mm分ss秒')
        str = o.M + '月' + o.d + '日 ' + o.h + '时' + o.m + '分' + o.s + '秒';

    //hh:mm
    if (strformat.toLocaleLowerCase() == 'hh:mm')
        str = o.h + ':' + o.m;
    if (strformat.toLocaleLowerCase() == 'hh时mm分')
        str = o.h + '时' + o.m + '分';
    //hh:mm:ss
    if (strformat.toLocaleLowerCase() == 'hh:mm:ss')
        str = o.h + ':' + o.m + ':' + o.s;
    if (strformat.toLocaleLowerCase() == 'hh时mm分ss秒')
        str = o.h + '时' + o.m + '分' + o.s + '秒';
    //dd
    if (strformat.toLocaleLowerCase() == 'dd')
        str = o.d;
    // hh
    if (strformat.toLocaleLowerCase() == 'hh')
        str = o.h;
    // ss
    if (strformat.toLocaleLowerCase() == 'ss')
        str = o.s;
    //mm
    if (strformat.toLocaleLowerCase() == 'mm')
        str = o.m;
    if (str == '::' || str == '--')
        str = '';
    return str;
}

function jsNC() {
    return "nocache=" + (new Date()).getTime();
}

function NewGuid() {
    var guid = "";
    $.ajax({
        url: '/ashx/commonhandler.ashx?Method=NewGuid&' + jsNC(),
        async: false,
        type: 'post',
        success: function (data) {
            if (data.ID == undefined) {
                data = eval('(' + data + ')');
            }
            guid = data.ID;
        }
    })
    return guid;
}

//按键禁止
$(document).keydown(function (event) {
    //event = window.event || event;
    //if ((event.altKey) &&
    //  ((event.keyCode == 37) ||   //屏蔽 Alt+ 方向键 ←   
    //   (event.keyCode == 39)))   //屏蔽 Alt+ 方向键 →   
    //{
    //    event.returnValue = false;
    //    return false;
    //}
    ////if (event.keyCode == 8) {
    ////    return false; //屏蔽退格删除键    
    ////}
    //if (event.keyCode == 116) {
    //    event.keyCode = 0;
    //    // $("body").append('<input type="text" />');
    //    return false; //屏蔽F5刷新键   
    //}
    //if ((event.ctrlKey) && (event.keyCode == 82)) {
    //    return false; //屏蔽alt+R   
    //}
});

$(function () {
    //$('body').bind('contextmenu', function () {
    //    return false;
    //});
})


