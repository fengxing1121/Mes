(function ($) {
    document.msCapsLockWarningOff = true;
    var partnerTaskForm = {
        init: function () {
            partnerTaskForm.initControls();
            partnerTaskForm.events.loadTask();
            partnerTaskForm.controls.btn_search_task.on('click',partnerTaskForm.events.SearchTask);
        },
        initControls: function () {
            partnerTaskForm.controls = {
                dgdetail: $('#datagrid'),
                search_form: $("#search_form"),
                btn_search_task: $("#btn_search_task"),
            };
        },
        events: {
            loadTask: function () {
                partnerTaskForm.controls.dgdetail.datagrid({
                    //idField: 'CustomerID',
                    url: '/ashx/PartnerTaskHandler.ashx?Method=SearchHistoryTask&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    singleSelect: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    columns: [[
                        { field: 'TaskID', hidden: true, width: 150, align: 'center' },
                        { field: 'ReferenceID', hidden: true, width: 150, align: 'center' },
                        { field: 'TaskNo', title: '任务编号', width: 120, sortable: false, align: 'center'},
                        { field: 'TaskType', title: '任务类型', width: 120, sortable: false, align: 'center' },
                        {
                            field: 'StepName', title: '步骤', width: 150, sortable: false, align: 'center', formatter: function (value, row, index) {
                                var strReturn = '<a href="javascript:void(0)" class="l-btn-text" onClick="loadstep(\'' + row['TaskID'] + '\',\'' + row['ReferenceID'] + '\');"><span style="color:#0094ff;">' + value + '</span></a>';
                                return strReturn;
                            }
                        },
                        { field: 'Created', title: '创建时间', width: 180, sortable: false, align: 'center' },
                        { field: 'CreatedBy', title: '创建者', width: 150, sortable: false, align: 'center' },
                    ]],
                    onBeforeLoad: function (param) {
                        partnerTaskForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    }
                });
            },
            SearchTask: function () {
                partnerTaskForm.controls.dgdetail.datagrid('reload');
            },
            loadNewGuid: function () {
                var guid = " ";
                for (var i = 1; i <= 32; i++) {
                    var n = Math.floor(Math.random() * 16.0).toString(16);
                    guid += n;
                    if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                        guid += "-";
                }
                return guid;
            },
        }
    };

    $(function () {
        partnerTaskForm.init();
        window.top['TaskRefresh'] = function () {
            partnerTaskForm.controls.dgdetail.datagrid('reload');
        }
    });

})(jQuery);

function loadstep(TaskID, ReferenceID) {
    $.ajax({
        url: '/ashx/solutionhandler.ashx?Method=GetSoluionByReferenceID&ReferenceID=' + ReferenceID + '&' + jsNC(),
        success: function (data) {
            if (data) {
                $('#edit_taskstep_form').form('load',data);
                $('#edit_taskstep_form').find('input[name="Status"]').val(getSolutionStatusName(data.Status));
            }
        }
    });
    $.ajax({
        url: '/ashx/quotehandler.ashx?Method=GetCustomer&ReferenceID=' + ReferenceID + '&' + jsNC(),
        success: function (data) {
            if (data) {
                $('#edit_taskstep_form').form('load', data);
            }
        }
    });
    $('#taskdetail').datagrid({
        //idField: 'CustomerID',
        url: '/ashx/PartnerTaskHandler.ashx?Method=SearchPartTasksStep&' + jsNC(),
        collapsible: false,
        fitColumns: true,
        pagination: true,
        queryParams: { TaskID: TaskID },
        singleSelect: true,
        striped: false,   //设置为true将交替显示行背景。
        pageSize: 20,
        columns: [[
            { field: 'TaskID', hidden: true, width: 150, align: 'center' },
            { field: 'StepNo', title: '编号', width: 120, sortable: false, align: 'center' },
            { field: 'StepName', title: '任务名称', width: 120, sortable: false, align: 'center' },
            { field: 'TargetStep', title: '下一步', width: 150, sortable: false, align: 'center' },
            { field: 'EndedBy', title: '创建者', width: 180, sortable: false, align: 'center' },
            { field: 'Ended', title: '创建时间', width: 150, sortable: false, align: 'center' },
        ]]
    });
    $('#taskstep_window').window('open');
}