'use strict';
document.msCapsLockWarningOff = true;
var solutionForm = {
    init: function () {
        solutionForm.initControls();
        solutionForm.controls.searchData.on('click', solutionForm.events.loadData);//加载数据
        solutionForm.events.loadData();
    },
    initControls: function () {
        solutionForm.controls = {
            pid: getUrlParam('pid'),
            searchData: $('#btn_search_ok'),//查询按钮
            dgdetail: $('#dgdetail'),//填充数据
            search_form: $('#search_form'),//查询表单
            edit_form: $('#edit_form'),//编辑表单                
        }
        $('#btn_search_ok').linkbutton();
    },
    events: {
        loadData: function () {
            solutionForm.controls.dgdetail.datagrid({
                idField: 'SolutionID',
                url: '/ashx/solutionhandler.ashx?Method=SearchSolutions&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[
                    {
                        field: 'DesignerNo', title: '订单编号', width: 120, align: 'center', formatter: function (value, row, index) {
                            var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onclick="showdetail(\'' + row['SolutionID'] + '\');"><span style="color:#0094ff;">' + value + '</span></a>';
                            return strReturn;
                        }
                    },
                    { field: 'KJLDesignID', title: '方案ID', width: 120, align: 'center' },
                    { field: 'PartnerName', title: '经销商门店', width: 120, sortable: false, align: 'center' },
                    { field: 'DesignerName', title: '经销商', width: 120, sortable: false, align: 'center' },
                    { field: 'CustomerName', title: '经销商客户', width: 150, align: 'center' },
                    { field: 'LinkMan', title: '联系人', width: 120, align: 'center' },
                    { field: 'Mobile', title: '联系电话', width: 120, align: 'center' },
                    { field: 'Designer', title: '设计师', width: 120, sortable: false, align: 'center' },
                    //{
                    //    field: 'Status', title: '状态', width: 120, sortable: false, align: 'center', formatter: function (value, row, index) {
                    //        return getSolutionStatusName(value);
                    //    }
                    //},
                    { field: 'Modified', title: '更新时间', width: 150, sortable: false, align: 'center' },
                ]],
                toolbar: [
                  //{ text: '新增方案', iconCls: 'icon-add', handler: solutionForm.events.newsolution }
                ],
                onBeforeLoad: function (param) {
                    solutionForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    solutionForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                },
                onSelect: function (rowIndex, rowData) {
                    //solutionForm.events.modifysolution();
                }
            })
        },
        newsolution: function () {
            top.addTab("新增方案", "/View/crm/newsolution.aspx?" + jsNC(), 'table');
        }
    }
};
$(function () {
    solutionForm.init();
    window.top["Solution"] = function () {
         $("#dgdetail").datagrid("reload");
    };
});

function showdetail(sid) {
    var source=getUrlParam('source');
    if (source == null)//ems
        top.addTab("方案详情", "/View/crm/solutionshow.aspx?SolutionID=" + sid + "&" + jsNC(), 'table');
    else
        window.location.href = "/View/crm/solutionshow.aspx?SolutionID=" + sid + "&source=crm&v=" + jsNC();
}


