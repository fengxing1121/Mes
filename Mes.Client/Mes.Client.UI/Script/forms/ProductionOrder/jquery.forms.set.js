/*!
 @Name：参数设置
 @Author：刘胜伟
 @Remark： 
 @Date：2018-07-05
 @License：MES  
 */

$(function () {
    $("#btnOk").click(function () {
        weekAverage(true);
    });
    $("#btnreset").click(function () {
        if (confirm("确认重置页面吗？")) {
            hDays = [];
            window.location.reload();
        }
    });
    $("#btnsubmit").click(function () {
        var totalareal = $("#txttotalareal").val();
        var weeks = [];

        if (hDays.length == 0) {
            alert("请设置标准工作日！");
            return false;
        };
        if (totalareal.length == 0) {
            alert("请设置销售预测总量！");
            $("#txttotalareal").focus();
            return false;
        };
        if (totalareal < 0) {
            alert("销售预测总量设置错误！");
            $("#txttotalareal").focus();
            return false;
        };
        $(".trweek").each(function (index) {
            var i = index + 1;
            var MaxCapacity = $(this).find("input").val();
            if ($(this).is(":hidden")) return true;//continue

            if (MaxCapacity.length == 0) {
                alert("请设置第" + i + "周排产量比例");
                $(this).find("input").focus();
                return false;//break
            }
            var models = {
                WeekNo: i,
                MaxCapacity: MaxCapacity,
            };
            weeks.push(models);
        });
        $.ajax({
            type: "post",
            datatype: 'json',
            url: '/ashx/ProductionSetHandler.ashx?Method=SaveProductionSet',
            data: { calendars: JSON.stringify(hDays), totalareal: totalareal, weeks: JSON.stringify(weeks) },
            success: function (obj) {
                if (obj.isOk == 1) {
                    alert("设置成功！");
                    //parent.refreshTabs("排单参数设置");
                    parent.closeTabs();
                }
                else {
                    alert(obj.message);
                }
            },
        });
    });

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
                alert('加载数据错误！原因：' + XMLHttpRequest.responseText);
            }
        }
    });
});

//计算周比列平均值
function weekAverage(IsBtnClick) {
   
    var totalareal = $("#txttotalareal").val();
    if (totalareal.length == 0) return;
    $.ajax({
        type: "post",
        datatype: 'json',
        url: '/ashx/ProductionSetHandler.ashx?Method=GetweekAverage',
        data: { calendars: JSON.stringify(hDays), totalareal: totalareal },
        success: function (obj) {
            if (obj.total > 0) {
                $.each(obj.rows, function (index, row) {
                    var element = $(".trweek").eq(row.weekno - 1);
                    var txtweeks = element.find("input").val();
                    if (txtweeks> 0 && txtweeks != row.maxcapacity && IsBtnClick) {
                        weekManual();
                        return false;
                    }
                    element.find("td").eq(2).empty().append(getWeekText(row.maxcapacity, row.totalareal, row.weekdaycount, row.dayaverage));
                    element.find("input").val(row.maxcapacity);
                    //element.find("tr").eq(0).find("td").eq(0).find("span").text(row.maxcapacity + "%");
                });
            }
        },
    });
};

//计算周比列手工值
function weekManual() {
    var totalareal = $("#txttotalareal").val();
    var weeks = [];

    if (hDays.length == 0) {
        alert("请设置标准工作日！");
        return false;
    };
    if (totalareal.length == 0) {
        alert("请设置销售预测总量！");
        $("#txttotalareal").focus();
        return false;
    };
    if (totalareal < 0) {
        alert("销售预测总量设置错误！");
        $("#txttotalareal").focus();
        return false;
    };
    $(".trweek").each(function (index) {
        var i = index + 1;
        var MaxCapacity = $(this).find("input").val();
        if ($(this).is(":hidden")) return true;//continue

        if (MaxCapacity.length == 0) {
            alert("请设置第" + i + "周排产量比例");
            $(this).find("input").focus();
            return false;//break
        }
        var models = {
            WeekNo: i,
            MaxCapacity: MaxCapacity,
        };
        weeks.push(models);
    });
    $.ajax({
        type: "post",
        datatype: 'json',
        url: '/ashx/ProductionSetHandler.ashx?Method=GetweekManual',
        data: { calendars: JSON.stringify(hDays), totalareal: totalareal, weeks: JSON.stringify(weeks) },
        success: function (obj) {
            if (obj.total > 0) {
                $.each(obj.rows, function (index, row) {
                    var html = '<span>实际本周排产比列设置：';
                    html += '       <span style="color:#0000FF;font-weight:bolder;">' + row.maxcapacity + '%</span>，预计本周排单总量：';
                    html += '       <span style="color:#0000FF;font-weight:bolder;">' + row.totalareal + '㎡</span>，';
                    html += '       <span style="color:#0000FF;font-weight:bolder;">' + row.weekdaycount + '天</span>中每天排单量';
                    html += '       <span style="color:#0000FF;font-weight:bolder;">' + row.dayaverage + '㎡</span>';
                    html += '</span>';
                    var element = $(".trweek").eq(row.weekno - 1);
                    element.find("td").eq(3).empty().append(html);

                });
            }
            else {
                alert(obj.message);
            }
        }
    });
};

function settotalarealHtml() {
    var temp = [];
    for (var i = 0; i < hDays.length; i++) {
        if (temp.indexOf(hDays[i].weekno) == -1) temp.push(hDays[i].weekno);
    }
    $(".totalarealInfo").html(getMonthText(temp.length, hDays.length));
    $(".trweek").each(function (index) {
        $(this).find("td").eq(3).empty();
    });
    weekAverage(false);
}

function clearWeekAverage() {

    $(".trweek").each(function (index) {
        $(this).hide();
        $(this).find("input").val("");
        $(this).find("td").eq(2).empty().append(getWeekText("_", "_", "_", "_"));
        $(this).find("p").empty();
    });

    $("#txttotalareal").val("");
    $(".totalarealInfo").html(getMonthText(0,0));
};

function getMonthText(weeks, days) {
    return '您的本月排班中总共有<span style="color:red;font-weight:bolder;">' + weeks + '周</span>，合计有<span style="color:red;font-weight:bolder;">' + days + '个工作日</span>，请合理填写月销售总量';
};

function getWeekText(parameter1, parameter2, parameter3, parameter4) {
    var html = '<span>建议本周排产比列设置：';
    html += '       <span style="color:red;font-weight:bolder;">' + parameter1 + '%</span>，预计本周排单总量：';
    html += '       <span style="color:red;font-weight:bolder;">' + parameter2 + '㎡</span>，';
    html += '       <span style="color:red;font-weight:bolder;">' + parameter3 + '天</span>中每天排单量';
    html += '       <span style="color:red;font-weight:bolder;">' + parameter4 + '㎡</span>';
    html += '</span>';
    return html;
};

//$("input[type=range]").oninput(function ()
//{
//    var element = $(this);
//    alert(element.val());
//});
function OnInput(event) {
    $("#" + event.target.id).parent().find("span").text(event.target.value + "%");
}
