(function ($) {
    document.msCapsLockWarningOff = true;
    var bomForm = {
        init: function () {
            bomForm.initControls();
            bomForm.events.loadData();
            bomForm.events.loadCombobox();
            bomForm.controls.searchData.on('click', bomForm.events.loadData);//加载数据
            bomForm.controls.NewComponentType.on('click', bomForm.events.NewComponentType);//新增
            bomForm.controls.SaveComponentType.on('click', bomForm.events.SaveComponentType);//保存
            bomForm.controls.Status.on('click', bomForm.events.SetStatus);//是否禁用

        },
        initControls: function () {
            bomForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#datagrid'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),
                NewComponentType: $('#btn_add'),
                SaveComponentType: $('#btn_save'),
                Status: $("#Status")
            }
        },
        events: {
            loadData: function () {
                bomForm.controls.dgdetail.datagrid({
                    sortName: "ComponentTypeName",
                    sortOrder: "asc",
                    idField: 'ComponentTypeID',
                    url: '/ashx/ComponentTypeHandler.ashx?Method=List',
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                    { field: 'ComponentTypeName', title: '组件类型名称', width: 100, sortable: true, align: 'center' },
                    { field: 'ComponentTypeCode', title: '组件类型编码', width: 250, sortable: true, align: 'center' },
                    { field: 'ParentID', title: '父节点', width: 150, sortable: true, align: 'center' },
                    {
                        field: 'Status', title: '状态', width: 80, sortable: true, align: 'center'
                        , formatter: function (value, rowData, rowIndex) {
                            if (value == 'False') {
                                return "";
                            } else {
                                return "<span style='color:red;'>√</span>";
                            }
                        }
                    }
                    ]],
                    onBeforeLoad: function (param) {
                        param.DepartmentID = bomForm.controls.edit_form.find('#ComponentTypeID').val();
                        bomForm.controls.search_form.find('input').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                        bomForm.events.UpdateBomComponent();
                    }
                });
            },
            NewComponentType: function () {
                $.ajax({
                    url: '/ashx/ComponentTypeHandler.ashx?Method=NewComponentType&' + jsNC(),
                    success: function (result) {
                        bomForm.controls.edit_form.form('load', result['Data']);
                        bomForm.controls.SaveComponentType.show();
                    }
                });
            },
            SaveComponentType: function () {
                if (bomForm.controls.edit_form.form('validate')) {
                    $.invokeApi('/ashx/ComponentTypeHandler.ashx?Method=SaveComponentType', bomForm.controls.edit_form.serialize(), null, 'get', function (result) {
                        if (result) {
                            if (result['Code'] == 1) {
                                showInfo(result['Msg']);
                                bomForm.controls.dgdetail.datagrid('reload');
                                bomForm.events.loadCombobox();
                                bomForm.events.NewComponentType();
                            } else {
                                showError(returnData['Msg']);
                            }
                        }
                    });
                }
            },
            UpdateBomComponent: function () {
                var selectedRows = bomForm.controls.dgdetail.datagrid('getSelections');
                if (selectedRows.length > 0) {
                    $.ajax({
                        url: '/ashx/ComponentTypeHandler.ashx?Method=GetComponentType&ComponentTypeID=' + selectedRows[0]['ComponentTypeID'],
                        success: function (result) {
                            bomForm.controls.edit_form.form('load', result['Data']);
                            bomForm.controls.edit_form.find('#Status').prop('checked', result['Data']["Status"] == 'True' ? true : false);
                            bomForm.controls.edit_form.find('#Status').val(result['Data']["Status"]);
                        }
                    });
                }
            },
            loadCombobox: function () {
                $("#ParentID").empty();
                $("#ParentID").combobox({
                    url: '/ashx/ComponentTypeHandler.ashx?Method=LoadBomComponentTypes',
                    textField: 'ComponentTypeName',
                    valueField: 'ComponentTypeID',
                    loadFilter: function (data) {
                        var defaultItem = [{ ComponentTypeID: '0', ComponentTypeName: '根节点', selected: true }];
                        var province = [];
                        $.each(data, function (i, val) {
                            var item = {};
                            item.ComponentTypeID = val.ComponentTypeID;
                            item.ComponentTypeName = val.ComponentTypeName;
                            province.push(item);
                        });
                        return defaultItem.concat(province);
                    }
                });
                //$("#ParentID").combobox('setValue', '');
            },
            SetStatus: function () {
                if ($(this)[0].checked == true)
                    $(this).val("true");
                else
                    $(this).val("false");
            },
        },
        options: {
            isModify: false
        }
    };

    $(function () {
        bomForm.init();
    });
})(jQuery);