'use strict';
document.msCapsLockWarningOff = true;
var quoteForm = {
    init: function () {
        quoteForm.initControls();
        quoteForm.controls.searchData.on('click', quoteForm.events.loadData);//加载数据
        quoteForm.events.loadData();
    },
    initControls: function () {
        quoteForm.controls = {
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
            quoteForm.controls.dgdetail.datagrid({
                idField: 'QuoteID',
                url: '/ashx/quotehandler.ashx?Method=SearchQuotes&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                singleSelect:true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[                                  
                    {
                        field: 'QuoteNo', title: '报价单号', width: 180, align: 'center',
                        formatter: function (value, row, index) {
                            var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onclick="showdetail(\'' + [row.SolutionID, row.QuoteID, row.QuoteNo] + '\');"><span style="color:#0094ff;">' + row.QuoteNo + '</span></a>';
                            return strReturn;
                        }
                    },
                    { field: 'SolutionCode', title: '方案编号', width: 180, align: 'center' },
                    { field: 'SolutionName', title: '方案名称', width: 150, align: 'center' },
                    { field: 'CustomerName', title: '客户名称', width: 150, align: 'center' },
                    { field: 'LinkMan', title: '联系人', width: 120, align: 'center' },
                    { field: 'Mobile', title: '联系电话', width: 130, align: 'center' },//
                    { field: 'TotalAmount', title: '报价总额(元)', width: 120, align: 'center' },
                    { field: 'DiscountPercent', title: '折扣率', width: 120, align: 'center' },
                    { field: 'DiscountAmount', title: '折扣金额(元)', width: 120, align: 'center' },
                    { field: 'ExpiryDate',title: '失效日期', width: 150, sortable: false, align: 'center' },
                    { field: 'Created', title: '创建时间', width: 150, sortable: false, align: 'center' },
                    {
                        field: 'Status', title: '状态', width: 150, sortable: false, align: 'center', formatter: function (value, row, index) {
                            return getQuoteMainStatusName(value);
                        }
                    }
                ]],
                toolbar: [
                   //{ text: '新增报价', iconCls: 'icon-add', handler: quoteForm.events.newquote }
                   //{ text: '确认', iconCls: 'icon-add',handler:quoteForm.events.certainQuoteDetailStatus},
                   //{ text: '取消', iconCls: 'icon-cancel', handler: quoteForm.events.cancelQuoteDetailStatus}
                ],
                onBeforeLoad: function (param) {
                    quoteForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    quoteForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                },
                onSelect: function (rowIndex, rowData) {
                    //quoteForm.events.modifyquote();
                }
            })
        },    
        newquote: function () {
            top.addTab("新增报价", "/View/crm/newquote.aspx?" + jsNC(), 'table');
        }
    }   
};
$(function () {
    quoteForm.init();
    window.top["Quote"] = function () {
        $("#dgdetail").datagrid("reload");
    };
});

function showdetail(id) {
    var ids = id.split(',');
    top.addTab("报价详情", "/View/crm/quoteshow.aspx?sid=" + ids[0] + "&qid=" + ids[1] + "&qno=" + ids[2], 'table');
}


