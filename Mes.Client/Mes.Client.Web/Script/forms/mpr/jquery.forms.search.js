/*!
 @Name：板件浏览器
 @Author：刘胜伟
 @Date：2018-01-22
 @License：
 */

function IsNullOrEmpty(value) {
    if (value == undefined || value == null || value.length == 0) {
        return true;
    } else {
        return false;
    };
};

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
                        };
                    };
                } else {
                    for (var i = 0; i < args.length; i++) {
                        if (args[i] != undefined) {
                            var reg = new RegExp("({[" + i + "]})", "g");
                            result = result.replace(reg, args[i]);
                        };
                    };
                };
            };
            return result;
        }
    })
})(jQuery);


function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
};
function jsNC() {
    return "nocache=" + (new Date()).getTime();
};

$(function () {
    var ItemID = getUrlParam('ItemID');
    if (IsNullOrEmpty(ItemID)) {
        alert('参数错误');
        return;
    };
    $.ajax({
        type: "post",
        dataType: "json",
        data: { ItemID: ItemID, action: "pathurl" },
        url: '/ashx/MprHandle.ashx?Method=SearchFilePathUrl&' + jsNC(),
        success: function (result) {
            console.log(result);
            if (result.returncode == 1) {
                var model = JSON.parse(result.jsonobj);
                var html = "";
                $.each(JSON.parse(model.data), function (i, obj) {
                    if (i == 0) {
                        SearchMprtext(obj.filePath);
                        html += $.formatstring('<label><input class="btncheck" type="radio" name="radio" checked="" value="{0}">{1}</label>&nbsp;&nbsp;', [obj.filePath, obj.fileName]);
                    }
                    else {
                        html += $.formatstring('<label><input class="btncheck"  type="radio" name="radio" value="{0}">{1}</label>&nbsp;&nbsp;', [obj.filePath, obj.fileName]);
                    };
                });
                if (model.total > 1)
                    $("#panel_radio").html(html).show();
            }
            else {
                alert(result.returnmsg);
                closeview_window();
            };
        },
        error: function (e) {
            alert(JSON.stringify(e));
            closeview_window();
        },
    });

    $("#panel_radio").on("click", ".btncheck", function () {
        SearchMprtext($(this).val());
    });

});

function SearchMprtext(mprPath) {
    $.ajax({
        type: "post",
        dataType: "json",
        data: { mprPath: mprPath, action: "text" },
        url: '/ashx/MprHandle.ashx?Method=SearchMprtext&' + jsNC(),
        success: function (result) {
            console.log(result);
            if (result.returncode == 1) {
                console.log(result.jsonobj);
                $("#txtContext").val(result.jsonobj);
                $("#BtnSearch").click();
            }
            else {
                alert(result.returnmsg);
                closeview_window();
            };
        },
        error: function (e) {
            alert(JSON.stringify(e));
            closeview_window();
        },
    });
};

function closeview_window() {
    parent.$('#view_window').dialog('close');
};