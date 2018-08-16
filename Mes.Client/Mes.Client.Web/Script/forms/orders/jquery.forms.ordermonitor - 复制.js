'use strict';
document.msCapsLockWarningOff = true;
var orderMonitorForm = {
    init: function () {
        orderMonitorForm.initControls();
        orderMonitorForm.events.loadSchedulingData();
        orderMonitorForm.controls.refresh.on('click', orderMonitorForm.events.loadSchedulingData);//刷新 
    },
    initControls: function () {
        orderMonitorForm.controls = {
            orderid: getUrlParam('orderid'),
            listinfo: $('#listinfo'),
            dgschedule: $('#dgschedule'),
            workflow_window: $('#workflow_window'),
            refresh: $('#btn_refresh')
        }
    },
    events: {
        loadSchedulingData: function () {
            $.ajax({
                url: '/ashx/ordershandler.ashx?Method=SearchOrderScheduling&orderid=' + orderMonitorForm.controls.orderid,
                success: function (data) {
                    var list = '';
                    var value = "";
                    orderMonitorForm.controls.listinfo.html('');
                    $.each(data.rows, function (i, obj) {
                        list += '<li style="float: left; padding-right: 20px; padding-left: 20px;">';
                        list += '  <div style="width: 350px; height: 400px; padding-right: 15px;">';
                        list += '     <div style="height: 200px;">'
                        list += '        <div style="height: 200px; width: 300px; background: url(' + obj.ImageUrl + ') no-repeat center; background-size: contain; float: left;"></div>';
                        list += '     </div>';

                        list += '    <div style="line-height: 22px;"><span style="font-size: 20px; padding-left: 20px;">' + obj.WorkFlowName + '</span></div>';
                        list += '    <div style="clear: both; height: 2px; border-bottom: 2px solid #eee;"></div>';
                        list += '    <div>';
                        list += '        <ul style="padding-left:0px">';
                        list += '           <li style="line-height: 25px;"><span class="icon table_add">&nbsp;</span>板件数量:' + obj.TotalQty + '</li>';
                        list += '           <li style="line-height: 25px;"><span class="icon date_link">&nbsp;</span>预计生产天数：' + obj.ProductionPeriod + '</li>';
                        list += '           <li style="line-height: 25px;"><span class="icon date">&nbsp;</span>预计生产日期：' + obj.Estimated + '</li>';
                        list += '           <li style="line-height: 25px;"><span class="icon date_go">&nbsp;</span>实际生产日期：' + obj.MadeStarted + '</li>';

                        if (obj.MadeTotalQty == "") {
                            list += '           <li style="line-height: 25px;"><span class="icon car">&nbsp;</span>已生产：' + 0 + '</li>'; //已生产
                        }
                        else {
                            list += '           <li style="line-height: 25px;"><span class="icon car">&nbsp;</span>已生产：' + obj.MadeTotalQty + '</li>'; //已生产
                        }
                        value = ((obj.MadeTotalQty / obj.TotalQty) * 100).toFixed(1); //完成比
                        list += '           <li style="line-height: 25px;">';
                        list += '             <div style="width: 300px;">';
                        list += '                <div style="float: left;">';
                        if (value == 0) {
                            list += '                   <span class="icon chart_bar">&nbsp;</span><span>完成比：' + "未开始" + '</span>';
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
                        //if (i==2) {
                        //    return false;
                        //}
                    });
                    orderMonitorForm.controls.listinfo.append(list);
                }
            });
        },
        loadWorkflowState: function () {
            ordersForm.controls.dgdetail.datagrid({
                sortName: 'BattchNum',
                idField: 'WorkFlowID',
                url: '/ashx/ordershandler.ashx?Method=SearchOrders&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[                
                { field: 'WorkFlowName', title: '当前工序', width: 120, sortable: false, halign: 'center', align: 'center' },
                { field: 'BattchNum', title: '批次号', width: 120, sortable: false, halign: 'center', align: 'center' },
                { field: 'TotalQty', title: '批次板数', width: 80, sortable: false, align: 'center' },
                { field: 'TotalAreal', title: '合计面积', width: 80, sortable: false, halign: 'center', align: 'center' },
                { field: 'MadeTotalQty', title: '已生产数', width: 80, sortable: false, align: 'center' },
                {
                    field: 'MadeStarted', title: '开始时间', width: 120, sortable: false, halign: 'center', align: 'center', formatter: function (value, row, index) {
                        if (value != undefined || value != '') {
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                        return '';
                    }
                },
                {
                    field: 'ProductionPeriod', title: '生产周期', width: 80, sortable: false, align: 'center', formatter: function (value, row, index) {
                        if (value != undefined || value != '') {
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                        return '';
                    }
                },
                {
                    field: 'Estimated', title: '预计完成', width: 120, sortable: false, align: 'center', formatter: function (value, row, index) {
                        if (value != undefined || value != '') {
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                        return '';
                    }
                }
                ]]
            });
        }
    }
};
$(function () {
    orderMonitorForm.init();
});

