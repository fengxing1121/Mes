/*!
 @Name：监控面板
 @Author：刘胜伟
 @Date：2018-01-22
 @License：MES  
 */

'use strict';
document.msCapsLockWarningOff = true;

var orderMonitorForm = {
    init: function () {
        orderMonitorForm.initControls();
        orderMonitorForm.events.loadSchedulingData();
    },
    initControls: function () {
        orderMonitorForm.controls = {
            orderid: getUrlParam('orderid'),
            listinfo: $('#listinfo'),
            dgorder: $('#dgorder'),
            dgCabinet: $('#dgCabinet')
        }
    },
    events: {
        loadSchedulingData: function () {
            orderMonitorForm.controls.listinfo.empty();
            $.ajax({
                url: '/ashx/ordershandler.ashx?Method=GetOrdermonitorByWorkFlow&' + jsNC(),
                data: { CabinetNum: $('#CabinetNum').val(), OrderID: orderMonitorForm.controls.orderid },
                datatype: "json",
                success: function (data) {
                    var TotalCabinetQty = 0;
                    if (data) {
                        var list = '';
                        var value = "";
                        $.each(data.rows, function (i, obj) {
                            list += '<li style="float: left; padding-right: 20px; padding-left: 20px;" data-workid="' + obj.WorkFlowID + '" data-workname="' + obj.WorkFlowName + '">';
                            list += '  <div style="width: 350px; height: 400px; padding-right: 15px;">';
                            list += '     <div style="height: 200px;">'
                            list += '        <div style="height: 200px; width: 300px; background: url(' + obj.ImageUrl + ') no-repeat center; background-size: contain; float: left;"></div>';
                            list += '     </div>';

                            list += '    <div style="line-height: 22px;"><span style="font-size: 20px; padding-left: 20px;"> ' + obj.WorkFlowName + '</span></div>';
                            list += '    <div style="clear: both; height: 2px; border-bottom: 2px solid #eee;"></div>';
                            list += '    <div>';
                            list += '         <ul style="padding-left:0px">';
                            list += '           <li class="window-state" style="line-height: 25px;cursor:pointer;"><span class="icon monitor_add">&nbsp;</span>待完成：<span style=\'' + (obj.MadeStarted > 0 ? 'color:red;font-weight:bold;font-size: large;' : '') + '\'>' + (obj.MadeStarted > 0 ? obj.MadeStarted : '无') + '</span></li>';
                            list += '           <li class="window-state" style="line-height: 25px;cursor:pointer;"><span class="icon computer">&nbsp;</span>已完成：' + obj.Estimated + '</li>';
                            list += '           <li style="line-height: 25px;width:100%;"><span class="icon table">&nbsp;</span>排产时间：<span>' + GetOrderSchedulingDt(obj) + '</span></li>';
                            value = ((obj.Estimated / obj.TotalQty) * 100).toFixed(1);//完成比：(待生产/总数)*100
                            list += '           <li style="line-height: 25px;width:100%;">';
                            list += '             <div style="width: 300px;">';
                            list += '                <div style="float: left;">';
                            if (value == 0 || value == "NaN") {
                                list += '                   <span class="icon chart_bar">&nbsp;</span><span>完成比：未开始</span>';
                                list += '                </div> ';
                            }
                            else {
                                list += '                   <span class="icon chart_bar">&nbsp;</span><span>完成比：</span>';
                                list += '                </div> ';
                                list += '                <div style="width: 200px; height: 20px; border: 1px solid #ccc; float: left;">';
                                list += '                   <div style="width: ' + value + '%; height: 100%; background: #00CC00; color: #000000; line-height: 20px; padding-left: 10px;"> ' + value + '%</div>';
                                list += '                </div>';
                            }
                            list += '            </div>';
                            list += '           </li>';

                            list += '        </ul>';
                            list += '    </div>';
                            list += '  </div>';
                            list += '</li>';
                            TotalCabinetQty = obj.TotalCabinetQty;
                        });
                        orderMonitorForm.controls.listinfo.append(list);

                        //绑定
                        $("#listinfo").on("click", "li>div>div>ul>li", function () {
                            var $parent = $(this).parent().parent().parent().parent();
                            var workid = $parent.attr("data-workid");
                            var workname = $parent.attr("data-workname");

                            if (!IsNullOrEmpty(workid) && !IsNullOrEmpty(workname) && $(this).index() < 2) {
                                orderMonitorForm.events.loadCabinet(workid, workname, $(this).index());
                            }
                        });
                        $(document).ready(function () {
                            $(".panel-title").text("产品合计：" + TotalCabinetQty + "件");
                        });

                    }
                }
            });
        },
        loadCabinet: function (WorkFlowID, WorkFlowName, MadeQty) {

            $('#edit_window').window({
                title: WorkFlowName + (MadeQty == 0 ? '-待生产' : '-已生产')
            }).window('open');

            orderMonitorForm.controls.dgCabinet.datagrid({
                sortName: 'Sequence',
                idField: 'CabinetID',
                url: '/ashx/ordershandler.ashx?Method=GetCabinetsByOrderWorkFlow',
                collapsible: false,
                fitColumns: true,
                pagination: false,
                striped: false,
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[
                 {
                     field: 'CreatedBy', title: (WorkFlowName + '(处理)人'), hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                         return MadeQty == 0 ? "待扫描" : value;
                     }
                 },
                {
                    field: 'Created', title: (WorkFlowName + '(完成)日期'), width: 150, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        return MadeQty == 0 ? "待扫描" : (new Date(value.replace("T", " "))).Formats("yyyy-MM-dd HH:mm");
                    }
                },
                // { field: 'ItemType', title: '类型', sortable: false, halign: 'center', align: 'center' },
                //{ field: 'ItemGroup', title: '组号', sortable: false, halign: 'center', align: 'center' },
                { field: 'ItemName', title: '板件名称', width: 200, sortable: false, align: 'center' },
                { field: 'MaterialType', title: '材质', width: 110, sortable: false, halign: 'center', align: 'center' },
                { field: 'BarcodeNo', title: '板件号', sortable: false, halign: 'center', align: 'center' },

                ]],
                onBeforeLoad: function (param) {
                    param['OrderID'] = orderMonitorForm.controls.orderid;
                    param['WorkFlowID'] = WorkFlowID;
                    param['MadeQty'] = MadeQty;
                },
                onLoadSuccess: function (data) {
                    if (data.total == 0) {
                        var body = $(this).data().datagrid.dc.body2;
                        body.find('table tbody').append('<tr><td colspan="10" style="height: 35px;border-left: #ccc dotted 1px; text-align: center;"><h1>该工序暂未流入产品</h1></td></tr>');
                    }

                }
            });
        }
    }
};
$(function () {
    orderMonitorForm.init();
});

//获取排产时间
function GetOrderSchedulingDt(obj) {
    console.log(JSON.stringify(obj));
    if (obj.WorkFlowName == "发货") return "无需填写";
    else if (obj.Started != "0001-01-01" && obj.Ended != "0001-01-01") return obj.Started + "至" + obj.Ended;
    else if (obj.Started != "0001-01-01" && obj.Ended == "0001-01-01") return obj.Started + "至(结束时间未填写)";
    else if (obj.Started == "0001-01-01" && obj.Ended != "0001-01-01") return "(开始时间未填写)至" + obj.Ended;
    else return "未填写";
}