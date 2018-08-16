(function () {
    var FactoryTaskForm = {
        init: function () {
            FactoryTaskForm.initControls();
            FactoryTaskForm.events.loadTask();
            FactoryTaskForm.controls.btn_search_task.on('click', FactoryTaskForm.events.SearchTask);
        },
        initControls: function () {
            FactoryTaskForm.controls = {
                dgFactoryTask: $('#dgFactoryTask'),
                search_task_form: $('#search_task_form'),
                btn_search_task: $('#btn_search_task'),
            }
        },
        events: {
            loadTask: function () {
                FactoryTaskForm.controls.dgFactoryTask.datagrid({
                    //idField: 'CustomerID',
                    url: '/ashx/PartnerTaskHandler.ashx?Method=SearchPartnerTask&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    singleSelect: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    columns: [[
                        { field: 'TaskID', hidden: true, width: 150, align: 'center' },
                        {
                            field: 'TaskNo', title: '任务编号', width: 120, sortable: false, align: 'center',
                            formatter: function (value, row, index) {
                                var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="任务详情" onClick="load(\'' + row['StepName'] + '\',\'' + row['TaskID'] + '\',\'' + row['TaskNo'] + '\',\'' + row['TaskType'] + '\',\'' + row['ReferenceID'] + '\');"><span style="color:#0094ff;">' + row['TaskNo'] + '</span></a>';
                                return strReturn;
                            }
                        },
                        { field: 'TaskType', title: '任务类型', width: 120, sortable: false, align: 'center' },
                        {
                            field: 'StepName', title: '步骤', width: 150, sortable: false, align: 'center', formatter: function (value, row, index) {
                                var strReturn = '<a href="javascript:void(0)" class="l-btn-text" onClick="loadstep(\'' + row['TaskID'] + '\');"><span style="color:#0094ff;">' + value + '</span></a>';
                                return strReturn;
                            }
                        },
                        { field: 'Created', title: '创建时间', width: 180, sortable: false, align: 'center' },
                        { field: 'CreatedBy', title: '创建者', width: 150, sortable: false, align: 'center' },
                    ]],
                    toolbar: [
                         //{ text: '分配任务', iconCls: 'icon-add', handler: partnerTaskForm.events.assignTask},
                         //{ text: '任务详情', iconCls: 'icon-add', handler: partnerTaskForm.events.taskDetail},
                    ],
                    onBeforeLoad: function (param) {
                        FactoryTaskForm.controls.search_task_form.find('input').each(function (index) {
                            if (this.name != "") {
                                param[this.name] = $(this).val();
                            }
                        });
                    }
                });
            },

            SearchTask: function () {
                FactoryTaskForm.controls.dgFactoryTask.datagrid('reload');
            },
        }
    };
    $(function () {
        FactoryTaskForm.init();
    });
})(jQuery);

//任务明细
function loadstep(TaskID) {
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

function load(StepName, TaskID, TaskNo, TaskType, ReferenceID) {
    switch ($.trim(StepName)) {       
        case "方案审核":
            $.ajax({
                url: '/ashx/solutionhandler.ashx?Method=GetSolutionByDesignerID',
                data: { DesignerID: ReferenceID },
                datatype: "json",
                success: function (data) {
                    if (data) {
                        top.addTab("方案审核", "/View/orders/factorytask_solutionshow.aspx?TaskID=" + TaskID + "&ReferenceID=" + ReferenceID + "&SolutionID=" + data.SolutionID, 'table');
                    }
                    else {
                        showError('方案数据有误。');
                    }
                }
            });
            break;
        default:
    }
}