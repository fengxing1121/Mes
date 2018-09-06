/*
公共函数处理模块
*/

var OrderStatus;
function SetOrderStatus() {
    $.ajax({
        type: "post",
        dataType: "json",
        url: '/ashx/categoryhandler.ashx?Method=GetOrderStatus',
        success: function (obj) {
            OrderStatus = obj;
        }
    });
}
SetOrderStatus();

//获取订单状态
function GetOrderStatusName(value) {

    for (var i = 0; i < OrderStatus.length; i++) {
        if (IsNullOrEmpty(OrderStatus[i].CategoryCode)) continue;
        //console.log(OrderStatus[i].CategoryCode);
        //console.log(value);
        if (OrderStatus[i].CategoryCode == value) return OrderStatus[i].CategoryName;
    }
    return "";
}

//定义节点全局变量
var partneraddorder = "partneraddorder";//新增订单
var partnerordersconfirm = "partnerordersconfirm";//订单初审
var importorder = "importorder";//订单导入
var addorder = "addorder";//工厂新增订单
var ordersconfirm = "ordersconfirm";//订单初审
var ordersdesign = "ordersdesign";//提交设计
var ordersprice = "ordersprice";//销售报价
var ordersreview = "ordersreview";//财务审核

var ComponentTypeID = 8;//柜体ID(全局变量，生产订单专用)
var CabinetsName = "柜体";

function GetOrderStepNo(StepCode) {
    var StepNo = 0;
    switch (StepCode) {
        case partneraddorder: StepNo = 1; break;
        case partnerordersconfirm: StepNo = 2; break;
        case importorder: StepNo = 3; break;
        case addorder: StepNo = 3; break;
        case ordersconfirm: StepNo = 4; break;
        case ordersdesign: StepNo = 5; break;
        case ordersprice: StepNo = 6; break;
        case ordersreview: StepNo = 7; break;
    }
    return StepNo;
}


//将序列化成json格式后日期(毫秒数)转成日期格式
function ChangeDateFormat(cellval) {
    var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
    var hour = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
    var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
    var seconds = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
    return date.getFullYear() + "-" + month + "-" + currentDate + " " + hour + ":" + minutes + ":" + seconds;
}
//产品状态：CabinetStatus-N 正常  U申请改单  C申请消单 D产品已取消或已删除
function GetOrderProductstatusName(value) {
    console.log(value.trim().toUpperCase());
    switch (value.trim().toUpperCase()) {
        case 'N':
            return "正常";
        case 'U':
            return "正在申请改单";
        case 'C':
            return '正在申请消单'
        case 'D':
            return '已取消'
        default:
            return '无效状态'
    }
}

function GetProductionStatus(value) {
    switch (value) {
        case 'N':
            return "未排单";
        case 'Y':
            return "已排单";
        case 'K':
            return '已转工单'
    }
}
//日期去掉中文格式
function removeCN(str) {
    var reg = /[\u4E00-\u9FA5]/g;
    var strAfter = str.replace(reg, '');
    return strAfter;
}

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
                top.window.location.href = '/View/Account/login.aspx';
            }, 3000);
        }
        else {
            showError('加载数据错误！原因：' + XMLHttpRequest.responseText);
        }
    }
});

//判断字符串是否为空
function IsNullOrEmpty(value) {
    if (value == undefined || value == null || value.length == 0) {
        return true;
    } else {
        return false;
    }
};

//英文占1个字符，中文汉字占2个字符
function get_length(str) {
    var len = 0;
    for (var i = 0; i < str.length; i++) {
        if (str.charCodeAt(i) > 127 || str.charCodeAt(i) == 94) {
            len += 2;
        } else {
            len++;
        }
    }
    return len;
};
//字符串截取 一个中文汉字算两个字符
function cut_str(val, max) {
    var returnValue = '';
    var byteValLen = 0;
    for (var i = 0; i < val.length; i++) {
        if (val[i].match(/[^\x00-\xff]/ig) != null)
            byteValLen += 2;
        else
            byteValLen += 1;
        if (byteValLen > max)
            break;
        returnValue += val[i];
    }
    return returnValue;
};

//2018-03-16T16:02:06.05
function getdateTime(value) {
    if (value == undefined || value == "0001-01-01T00:00:00")
        return "";
    try {
        if (value.indexOf("T") != -1) {
            var array = value.split("T");
            if (array.length > 0) {
                var splite2 = array[1].split(":");
                return (array[0] + " " + splite2[0] + ":" + splite2[1]);
            }
        }
    }
    catch (err) {
        console.log('日期转化错误：' + value);
    }
    return "";
};

function InsertIframe(parameter) {
    var PrintUrl = "";
    var lodopImgPath = $("#lodopImg").attr("src");
    console.log(lodopImgPath);

    if (lodopImgPath.indexOf("http://www.c-lodop.com") >= 0) {
        PrintUrl = "http://www.c-lodop.com/View/Print/Index.aspx" + parameter + "&isconfig=true";
    }
    else {
        PrintUrl = "/View/Print/Index.aspx" + parameter;
    }

    var iframe_ = '<iframe src="' + PrintUrl + '" style="display:none;"></iframe>';
    console.log(iframe_);
    $("body").append(iframe_);
};

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

function showError(message) {
    parent.$.messager.alert('错误信息', message, 'error');
}
function showInfo(message) {
    parent.$.messager.alert("提示信息", message, "info");
}

//用此方式则不能在$.ajax中用error: function (e) {alert(JSON.stringify(e));}抛异常，否则无效
$.ajaxSetup({
    global: false,
    type: "POST",
    dataType: 'json',
    error: function (XMLHttpRequest, textStatus, errorThrown) {
        var substr = XMLHttpRequest.responseText;
        if (substr === "TimeOut") {
            alert("登录超时！请重新登陆！");
            top.window.location.href = '/view/Account/login.aspx';
        }
        else {
            showError('加载数据错误！原因：' + XMLHttpRequest.responseText);
        }
    }
});

(function ($) {
    $.extend({
        formatstring: function (source, args) {
            var result = source;
            if (typeof (args) == "object") {
                if (args.length == undefined) {
                    for (var key in args) {
                        if (args[key] != undefined) {
                            var reg = new RegExp("({" + key + "})", "g");
                            result = result.replace(reg, args[key]);
                        }
                    }
                } else {
                    for (var i = 0; i < args.length; i++) {
                        if (args[i] != undefined) {
                            var reg = new RegExp("({[" + i + "]})", "g");
                            result = result.replace(reg, args[i]);
                        }
                    }
                }
            }
            return result;
        },
        /**
        * ajax调用后端api
        * @param {String} url
        * @param {Object} postData
        * @param {boolean} async
        * @param {String} method
        * @param {String} callback
        */
        invokeApi: function (url, param, async, method, callback) {
            if (async === null || async === undefined || async === '') {
                async = true;
            }
            if (method === null || method === undefined || method === '') {
                method = 'post';
            }
            $.ajax({
                url: url,
                type: method,
                async: async,
                data: param,
                dataType: 'json',
                beforeSend: function () {
                    var win = $.messager.progress({
                        title: '请稍后',
                        msg: '正在处理中...'
                    });
                },
                success: function (result) {
                    if (callback === null || callback === undefined || callback === '') {
                        if (result['isOk'] == 1) {
                            showInfo(result.message);
                        } else {
                            showError(result.message);
                        }
                    } else {
                        callback(result); //回调函数
                    }
                }, error: function (XMLHttpRequest, textStatus, errorThrown) {
                    if (status == 404) {
                        showError('请求地址出错!');
                    } else if (status == 302) {
                        showError('连接网页出错!');
                    } else if (textStatus == "timeout") {
                        showError('请求超时!');
                    } else {
                        showError('请求异常!');
                    }
                }, complete: function (XMLHttpRequest, textStatus) {
                    $.messager.progress('close');
                }
            })
        }
    })
})(jQuery);

//alert($.formatstring("为什么{0}没有format", ["javascript"]));