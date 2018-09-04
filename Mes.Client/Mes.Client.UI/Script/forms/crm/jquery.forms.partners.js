(function ($) {
    'use strict';
    var addOrUpdate = "add";
    document.msCapsLockWarningOff = true;
    var partnerForm = {
        init: function () {
            partnerForm.initControls();
            partnerForm.events.loadData();
            partnerForm.controls.searchData.on('click', partnerForm.events.loadData);//加载数据    
            partnerForm.controls.newpartner.on('click', partnerForm.events.newpartner);//新增
            partnerForm.controls.savepartner.on('click', partnerForm.events.savepartner);//保存    
            partnerForm.events.newpartner();
            partnerForm.events.loadProvince();
            partnerForm.events.verifyright();
        },
        initControls: function () {
            partnerForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),//编辑表单
                newpartner: $('#btn_new'),//新增按钮
                savepartner: $('#btn_save')//保存
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {
            loadData: function () {
                partnerForm.controls.dgdetail.datagrid({
                    idField: 'PartnerID',
                    url: '/ashx/partnerhandler.ashx?Method=SearchPartners&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    columns: [[
                                { field: 'PartnerCode', title: '门店编号', width: 80, align: 'center' },
                                { field: 'PartnerName', title: '门店名称', width: 150, align: 'center' },
                                { field: 'LinkMan', title: '联系人', width: 120, sortable: false, align: 'center' },
                                { field: 'Mobile', title: '移动电话', width: 120, sortable: false, align: 'center' },
                                {
                                    field: 'Created', title: '注册日期', width: 85, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                                        if (value == undefined) return "";
                                        return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                                    }
                                },
                                { field: 'Tel', title: '业务员', width: 120, sortable: false, align: 'center' },
                                {
                                    field: 'p', title: '地址', width: 250, halign: 'center', align: 'left', formatter: function (value, row, index) {
                                        return (row.Province) + (row.City) + row.Address
                                    }
                                },
                    ]],
                    onBeforeLoad: function (param) {
                        partnerForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        partnerForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                        partnerForm.events.updatesupplier();
                        addOrUpdate = "update";
                    }
                });
            },
            newpartner: function () {
                $('#edit_form').form('clear');//添加之前先清空表单
                $("#PartnerID").val(partnerForm.events.loadNewGuid());
                //$('#City').combobox('setValue', '');
                partnerForm.controls.savepartner.show();//显示保存按钮
                addOrUpdate = "add";
            },
            savepartner: function () {
                if (partnerForm.controls.edit_form.form('validate')) {
                    switch (addOrUpdate) {
                        case "add":
                            $.ajax({
                                url: '/ashx/partnerhandler.ashx?Method=SavePartner',
                                data: partnerForm.controls.edit_form.serialize(),
                                success: function (returnData) {
                                    if (returnData) {
                                        if (returnData.isOk == 1) {
                                            showInfo(returnData.message);
                                            partnerForm.controls.dgdetail.datagrid('reload');
                                        } else {
                                            showError(returnData.message);
                                        }
                                    }
                                }
                            });
                            break;
                        case "update":
                            $.ajax({
                                url: '/ashx/partnerhandler.ashx?Method=ModifyPartner',
                                data: partnerForm.controls.edit_form.serialize(),
                                success: function (returnData) {
                                    if (returnData) {
                                        if (returnData.isOk == 1) {
                                            showInfo(returnData.message);
                                            partnerForm.controls.dgdetail.datagrid('reload');
                                        } else {
                                            showError(returnData.message);
                                        }
                                    }
                                }
                            });
                            break;
                        default:
                            break;
                    }
                }
            },
            updatesupplier: function () {
                var selectedRows = partnerForm.controls.dgdetail.datagrid('getSelections');
                var row = partnerForm.controls.dgdetail.datagrid('getSelected');
                if (selectedRows.length > 0) {
                    $.ajax({
                        url: '/ashx/partnerhandler.ashx?Method=GetPartner&PartnerID=' + selectedRows[0]['PartnerID'],
                        success: function (data) {
                            partnerForm.controls.edit_form.form('load', data);
                            partnerForm.controls.edit_form.find("#CompanyID").val(data.CompanyID); //加载公司并获取值
                            partnerForm.controls.edit_form.find("#City").combobox('setValue', data.City); //加载城市并获取值
                            if (!partnerForm.options.isModify) {
                                partnerForm.controls.savepartner.hide();
                            }
                        }
                    });
                }
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
                partnerForm.controls.edit_form.find("#Province").combobox({
                    data: citydata,
                    valueField: 'provincecode',
                    textField: 'provincename',
                    //required: true,
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
                        return defaultItem.concat(province);
                    },
                    onChange: function (newvalue, oldvalue) {
                        partnerForm.events.LoadCity(newvalue);
                    },
                    onLoadError: function () {
                    }
                });
            },
            LoadCity: function (province) {
                partnerForm.controls.edit_form.find("#City").combobox('clear');
                partnerForm.controls.edit_form.find("#City").combobox({
                    data: citydata,
                    valueField: 'cityname',
                    textField: 'cityname',
                    //required: true,
                    editable: false,
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
                partnerForm.controls.edit_form.find("#City").combobox('setValue', '');
            },
            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + partnerForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(partnerForm.controls.newpartner, partnerForm.controls.savepartner, data);
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
                    partnerForm.options.isModify = true;
                    break;
                default: break;
            }
        });
    }

    $(function () {
        partnerForm.init();
    });

})(jQuery);