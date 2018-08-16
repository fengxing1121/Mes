(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var customerForm = {
        init: function () {
            customerForm.initControls();
            customerForm.events.loadData();
            customerForm.controls.searchData.on('click', customerForm.events.loadData);//加载数据    
            customerForm.controls.newcustomer.on('click', customerForm.events.newcustomer);//新增
            customerForm.controls.savecustomer.on('click', customerForm.events.savecustomer);//保存   
            customerForm.controls.search_partner.on('click', customerForm.events.search_partner);//保存   

            customerForm.events.newcustomer();
            customerForm.events.loadProvince();             
            customerForm.events.loadPartner();
            customerForm.events.verifyright();
        },
        initControls: function () {
            customerForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),//编辑表单
                newcustomer: $('#btn_new'),//新增按钮
                savecustomer: $('#btn_save'),//保存
                search_partner: $('#btn_search_partner')
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {
            loadData: function () {
                customerForm.controls.dgdetail.datagrid({
                    idField: 'CustomerID',
                    url: '/ashx/customerhandler.ashx?Method=SearchCustomers&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    columns: [[
                    { field: 'CustomerName', title: '客户名称', width: 150, align: 'center' },
                    {
                        field: 'p', title: '联系地址', width: 250, halign: 'center', align: 'left', formatter: function (value, row, index) {
                            return  (row.Province) +  (row.City) + row.Address;
                        }
                    },
                    { field: 'LinkMan', title: '联系人', width: 120, sortable: false, align: 'center' },
                    { field: 'Position', title: '职位', width: 120, sortable: false, align: 'center' },
                    { field: 'Tel', title: '固定电话', width: 150, sortable: false, align: 'center' },
                    { field: 'Mobile', title: '移动电话', width: 180, sortable: false, align: 'center' },                     
                    { field: 'Fax', title: '传真', width: 150, sortable: false, align: 'center' },
                    { field: 'Email', title: '邮箱', width: 100, sortable: false, align: 'center' },
                    { field: 'HomePage', title: '网址', width: 100, sortable: false, align: 'center' }
                    ]],
                    onBeforeLoad: function (param) {
                        customerForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        customerForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                        customerForm.events.updateCustomer();
                    }
                });
            },
            loadPartner: function () {
                $('#PartnerID').combogrid({
                    panelWidth: 700,
                    panelHeight: 480,
                    idField: 'PartnerID',
                    textField: 'PartnerName',
                    fitColumns: true,
                    sortName: 'PartnerCode',
                    toolbar: '#tb',
                    url: '/ashx/partnerhandler.ashx?Method=SearchPartners&' + jsNC(),
                    pagination: true,
                    editable: false,
                    nowrap: false,
                    columns: [[
                            { field: 'PartnerCode', title: '商户编号', width: 150, align: 'center' },
                            { field: 'PartnerName', title: '经销商名称', width: 150, align: 'center' },
                            {
                                field: 'p', title: '商户地址', width: 250, halign: 'center', align: 'left', formatter: function (value, row, index) {
                                    return (row.Province) + (row.City) + row.Address
                                }
                            },
                            { field: 'LinkMan', title: '联系人', width: 80, sortable: false, align: 'center' }
                    ]],
                    onBeforeLoad: function (param) {
                        $('#search_form_partner').find('input').each(function (index) { param[this.name] = $(this).val(); });
                    },
                    onSelect: function (index, row) {
                        //customerForm.controls.edit_form.form('load', row);
                    }
                });

            },
            newcustomer: function () {
                $('#edit_form').form('clear');//添加之前先清空表单
                $("#CustomerID").val(customerForm.events.loadNewGuid());
                customerForm.controls.savecustomer.show();//显示保存按钮

            },
            savecustomer: function () {
                if (customerForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/customerhandler.ashx?Method=SaveCustomer',
                        data: customerForm.controls.edit_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    showInfo(returnData.message);
                                    customerForm.controls.dgdetail.datagrid('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },
            updateCustomer: function () {
                var selectedRows = customerForm.controls.dgdetail.datagrid('getSelections');
                var row = customerForm.controls.dgdetail.datagrid('getSelected');
                if (selectedRows.length > 0) {
                    $.ajax({
                        url: '/ashx/customerhandler.ashx?Method=GetCustomer&CustomerID=' + selectedRows[0]['CustomerID'],
                        success: function (data) {
                            customerForm.controls.edit_form.form('load', data);
                            $("#City").combobox('setValue', data.City); //加载城市并获取值

                            if (!customerForm.options.isModify) {
                                customerForm.controls.savecustomer.hide();
                            }
                        }
                    });
                }

            },
            search_partner: function () {
                $('#PartnerID').combogrid("grid").datagrid("reload");
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
            loadProvince: function () {
                $("#Province").combobox({
                    data: citydata,
                    valueField: 'provincecode',
                    textField: 'provincename',
                    required: true,
                    editable: false,
                    loadFilter: function (data) {
                        var defaultItem = [{ provincecode: '', provincename: '请选择省份' }];
                        var province = [];
                        $.each(data, function (i, val) {
                            var item = {};
                            item.provincecode = val.province;
                            item.provincename = val.province;
                            province.push(item);
                        });
                        return defaultItem.concat(province);//defaultItem.concat(data);
                    },
                    onChange: function (newvalue, oldvalue) {
                        customerForm.events.LoadCity(newvalue);
                    },
                    onLoadError: function () {
                    }
                });
            },
            LoadCity: function (province) {
                $("#City").empty();
                $("#City").combobox({
                    data: citydata,
                    valueField: 'cityname',
                    textField: 'cityname',
                    //required: true,
                    editable: true,
                    loadFilter: function (data) {
                        var defaultItem = [{ citycode: '', cityname: '请选择城市' }];
                        var p = data.filter(function (v) {
                            return v.province === province;
                        });
                        var city = [];
                        if (p.length > 0) {
                            $.each(p[0].city, function (i, val) {
                                var item = {};
                                item.citycode = val;
                                item.cityname = val;
                                city.push(item);
                            });
                        }
                        return defaultItem.concat(city);
                    },
                    onChange: function (newvalue, oldvalue) {
                        //customerForm.events.LoadCity(newvalue);
                    },
                    onLoadError: function () {
                    }
                });
            },
            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + customerForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(customerForm.controls.newcustomer, customerForm.controls.savecustomer, data);
                        }
                    }
                });
            }             
        },
        //用于判断是否有编辑权限
        options: {
            isModify: false
        }
    };
    function rightType(eleAdd, eleSave, data) {
        $(eleAdd).hide();
        $(eleSave).hide();

        $(data).each(function (i, obj) {
            switch (obj.PrivilegeItemCode) {
                case 'Add':
                    $(eleAdd).show();
                    $(eleSave).show();
                    break;
                case 'Modify':
                    $(eleSave).show();
                    customerForm.options.isModify = true;
                    break;
                default: break;
            }
        });
    }

    $(function () {
        customerForm.init();
    });

})(jQuery);

