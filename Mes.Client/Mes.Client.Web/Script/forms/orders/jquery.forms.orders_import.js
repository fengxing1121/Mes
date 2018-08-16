/*!
 @Name：导入订单（新版特性：1.支持批量上传 2.支持H5上传无需设置繁琐Flash）
 @Author：刘胜伟
 @Remark：新增
 @Date：2018-04-12
 @License：MES  
 */

var t = null;
var min = 0; //分
var sec = 0; //秒
var hour = 0; //小时

var ArrayPath = [];//上传文件路径

//删除数据集合中的对象
function delArrayPathById(id) {
    for (var i = 0; i < ArrayPath.length; i++) {
        if (ArrayPath[i].id == id) {
            ArrayPath.splice(i, 1);
        }
    };
};


(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var OrderImportForm = {
        init: function () {
            OrderImportForm.initControls();
            OrderImportForm.controls.btn_order_save.on('click', OrderImportForm.events.SaveOrder);
        },
        initControls: function () {
            OrderImportForm.controls = {
                pid: getUrlParam('pid'),
                btn_order_save: $('#btn_order_save'),
                loading: $('#Loding_window'),
            }
        },
        events: {
            SaveOrder: function () {
                if (ArrayPath.length < 1) {
                    showError("请先上传订单文件！");
                    return;
                }
                //var parmsObj = getUrlParms();
                //if (parmsObj.DesignID == undefined || parmsObj.DesignID == "") {
                //    showError("设计方案ID无效！");
                //    return;
                //}
                t = null;
                hour = 0;
                min = 0;
                sec = 0;
                setInterval(function () { t = OrderImportForm.events.timedCount(); }, 1000);
                OrderImportForm.controls.loading.window('open');
                console.log(JSON.stringify(ArrayPath));
                var designID = $('#upload_splitfile_form').find('input[name="DesignID"]').val();
                $.ajax({
                    url: '/ashx/OrdersHandler.ashx?Method=ConversionOrderNew&' + jsNC(),
                    data: { OrderFileUrl: JSON.stringify(ArrayPath), DesignID: designID },
                    success: function (obj) {
                        console.log(JSON.stringify(obj));
                        if (obj.isOk) {
                            $("#" + ArrayPath[0].id).remove();
                            delArrayPathById(ArrayPath[0].id);
                            console.log(JSON.stringify(ArrayPath));
                            OrderImportForm.events.closeLodingWindow();
                            showInfo(obj.message);
                        } else {
                            OrderImportForm.events.closeLodingWindow();
                            showError(obj.message);
                        }
                    }, error: function (XMLHttpRequest, textStatus, errorThrown) {
                        // 状态码
                        console.log(XMLHttpRequest.status);
                        // 状态
                        console.log(XMLHttpRequest.readyState);
                        // 错误信息   
                        console.log(textStatus);
                    }
                });
            },
            timedCount: function () {
                if (sec == 60) {
                    sec = 0;
                    min += 1;
                }
                if (min == 60) {
                    min = 0;
                    hour += 1;
                }
                $('.runtime').html('已经运行：' + cast(hour) + ':' + cast(min) + ':' + cast(sec));
                sec = sec + 1
            },
            stopCount: function () {
                clearTimeout(t)
            },
            closeLodingWindow: function () {
                setTimeout(function () {
                    OrderImportForm.events.stopCount();
                    OrderImportForm.controls.loading.window('close');
                }, 1000);
            }
        },
    };
    $(function () {
        OrderImportForm.init();
    });

})(jQuery);

function cast(obj) {
    if (obj.toString().length == 1)
        return '0' + obj.toString();
    else
        return obj.toString();
}

function getUrlParms() {
    var url = location.search;
    var parmObj = {};
    if (url.indexOf('?') != -1) {
        var str = url.substr(1),
        strs = str.split('&');
        for (var i = 0; i < strs.length; i++) {
            parmObj[strs[i].split('=')[0]] = unescape(strs[i].split('=')[1]);
        }
    }
    return parmObj;
}

