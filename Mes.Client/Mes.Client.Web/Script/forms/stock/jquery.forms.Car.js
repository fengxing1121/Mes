(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var CarForm = {
        init: function () {
            CarForm.initControls();
            CarForm.events.loadData();
            CarForm.controls.searchData.on('click', CarForm.events.loadData);//加载数据    
            CarForm.controls.newCar.on('click', CarForm.events.newCar);//新增
            CarForm.controls.saveCar.on('click', CarForm.events.saveCar);//保存  
            CarForm.controls.search_logistics.on('click', CarForm.events.search_logistics); 
            CarForm.events.newCar();
            CarForm.events.verifyright();
            CarForm.events.loadLogistics();
        },
        initControls: function () {
            CarForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),//编辑表单
                newCar: $('#btn_new'),//新增按钮
                saveCar: $('#btn_save'),
                search_logistics: $('#search_logistics')
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {
            loadData: function () {
                CarForm.controls.dgdetail.datagrid({
                    idField: 'CarID',
                    url: '/ashx/CarHandler.ashx?Method=SearchCars&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    columns: [[
                    { field: 'PlateNo', title: '车牌号码', width: 150, align: 'center' },
                    { field: 'CarName', title: '车名', width: 80, sortable: false, align: 'center' },
                    { field: 'CarStyle', title: '车型', width: 120, sortable: false, align: 'center' },
                    { field: 'DriverName', title: '驾驶人', width: 120, sortable: false, align: 'center' },
                    { field: 'Mobile', title: '移动电话', width: 100, sortable: false, align: 'center' },
                    
                    ]],
                    onBeforeLoad: function (param) {
                        CarForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        CarForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                        CarForm.events.updateCar();
                    }
                });
            },

            loadLogistics: function () {
                $('#EnterpriseID').combogrid({
                    panelWidth: 550,
                    panelHeight: 380,
                    idField: 'EnterpriseID',
                    textField: 'EnterpriseName',
                    fitColumns: true,                   
                    toolbar: '#tbLogistics',
                    url: '/ashx/LogisticsEnterpriseHandler.ashx?Method=SearchLogistics&' + jsNC(),
                    pagination: true,
                    editable: false,
                    nowrap: false,
                    columns: [[
                    { field: 'EnterpriseName', title: '物流名称', width: 150, align: 'center' },
                    { field: 'Address', title: '地址', width: 280, sortable: false, align: 'center' },
                    { field: 'LinkMan', title: '联系人', width: 120, sortable: false, align: 'center' },
                    { field: 'Mobile', title: '移动电话', width: 100, sortable: false, align: 'center' },
                    { field: 'Tel', title: '固定电话', width: 100, sortable: false, align: 'center' }
                    ]],
                    onBeforeLoad: function (param) {
                        $('#search_form_logistics').find('input').each(function (index) { param[this.name] = $(this).val(); });
                    },
                    onSelect: function (index, row) {
                        //customerForm.controls.edit_form.form('load', row);
                    }
                });

            },

            newCar: function () {
                $('#edit_form').form('clear');//添加之前先清空表单
                $("#CarID").val(CarForm.events.loadNewGuid());
                CarForm.controls.saveCar.show();//显示保存按钮

            },
            saveCar: function () {
                if (CarForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/CarHandler.ashx?Method=saveCar',
                        data: CarForm.controls.edit_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    CarForm.controls.dgdetail.datagrid('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },

            updateCar: function () {
                var selectedRows = CarForm.controls.dgdetail.datagrid('getSelections');
                if (selectedRows.length > 0) {
                    $.ajax({
                        url: '/ashx/CarHandler.ashx?Method=GetCar&CarID=' + selectedRows[0]['CarID'],
                        success: function (data) {
                            CarForm.controls.edit_form.form('load', data);
                            if (!CarForm.options.isModify) {
                                CarForm.controls.savecustomer.hide();
                            }
                        }
                    });
                }
            },

            search_logistics: function () {
                $('#EnterpriseID').combogrid("grid").datagrid("reload");
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

            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + CarForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(CarForm.controls.newCar, CarForm.controls.saveCar, data);
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
                    CarForm.options.isModify = true;
                    break;
                default: break;
            }
        });
    }

    $(function () {
        CarForm.init();
    });

})(jQuery);

