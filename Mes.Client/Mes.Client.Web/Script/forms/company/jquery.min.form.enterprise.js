(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var enterpriseForm = {
        init: function () {
            enterpriseForm.initControls();
            enterpriseForm.events.loadData();
            enterpriseForm.controls.searchData.on('click', enterpriseForm.events.loadData);//加载数据   
        },
        initControls: function () {
            enterpriseForm.controls = {               
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#datagrid'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),
                spendgrid: $('#spendgrid'),//消费明细                
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {

            loadData: function () {
                enterpriseForm.controls.dgdetail.datagrid({
                    sortName: "CompanyCode",
                    sortOrder: "asc",
                    idField: 'CompanyID',
                    url: '/ashx/CompanyHandler.ashx?Method=SearchCompany',
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                    { field: 'CompanyCode', title: '企业编号', width: 100, sortable: true, align: 'center' },
                    { field: 'CompanyName', title: '企业名称', width: 250, sortable: true, align: 'center' },
                    {
                        field: 'p', title: '企业地址', width: 250, halign: 'center', align: 'left', formatter: function (value, row, index) {
                            return (row.Province) + (row.City) + row.Address;
                        }
                    },
                    { field: 'Email', title: '邮箱', width: 150, sortable: true, align: 'center' },
                    { field: 'Mobile', title: '联系电话', width: 150, sortable: true, align: 'center' },
                    { field: 'LinkMan', title: '联系人', width: 150, sortable: true, align: 'center' },
                    {
                        field: 'Created', title: '创建日期', width: 120, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                    },
                     
                    ]],
                    onBeforeLoad: function (param) {                         
                        enterpriseForm.controls.search_form.find('input').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                        enterpriseForm.events.GetCompanyInfo();
                        enterpriseForm.events.SetCompanyID(rowData.CompanyID);
                    }

                });
            },
            GetCompanyInfo: function ()
            {
                var selectedRows = enterpriseForm.controls.dgdetail.datagrid('getSelections');               
                if (selectedRows.length > 0) {
                    $.ajax({
                        url: '/ashx/CompanyHandler.ashx?Method=GetCompanyInfo&CompanyID=' + selectedRows[0]['CompanyID'],
                        success: function (data) {
                            enterpriseForm.controls.edit_form.form('load', data);
                            $("#EnterpriseAddress").val(data.Province+data.City+data.Address);
                            $("#Status").val(enterpriseForm.events.loadStatus(data.Status));//转换状态中文名称
                             
                        }
                    });
                }
            },



            SetCompanyID: function (param) {
                if (param == "") return;
                enterpriseForm.controls.edit_form.find('#CompanyID').val(param);
                //enterpriseForm.events.loadSpendDetail();
            },

            //消费明细
            loadSpendDetail: function () {
                var CompanyID = enterpriseForm.controls.edit_form.find('#CompanyID').val();
                enterpriseForm.controls.spendgrid.datagrid({
                    sortOrder: "asc",
                    idField: 'CompanyID',
                    url: '/ashx/CompanyHandler.ashx?Method=CompanySpend&CompanyID=' + CompanyID,
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                    { field: 'ServiceLevel', title: '服务等级', width: 100, sortable: true, align: 'center' },
                    { field: 'UserQty', title: '用户数量', width: 250, sortable: true, align: 'center' },
                    { field: 'BuyMonth', title: '购买月数', width: 150, sortable: true, align: 'center' },
                   {
                       field: 'Started', title: '开始日期', width: 120, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) { 
                           if (value == undefined) return "";
                           return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                       }
                   },
                   {
                       field: 'Expired', title: '到期日期', width: 120, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                           if (value == undefined) return "";
                           return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                       }
                   },

                    ]], 
                });
            },

            loadStatus: function (value) {
                switch (value) {
                    case 'R':
                        return '审核中';
                        break;
                    case 'T':
                        return '试用企业';
                        break;
                    case 'S':
                        return '停用';
                        break;                    
                    default:
                        return '审核中';
                }
            },
 
        },
        
    };
     
    $(function () {
        enterpriseForm.init();
    });

})(jQuery);

