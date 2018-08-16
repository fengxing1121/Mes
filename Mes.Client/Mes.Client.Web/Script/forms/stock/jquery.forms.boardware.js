(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var boardwareForm = {
        init: function () {
            boardwareForm.initControls();
            boardwareForm.events.loadData();
            boardwareForm.controls.searchData.on('click', boardwareForm.events.loadData);//加载数据           
            boardwareForm.events.loadCombobox();
        },
        initControls: function () {
            boardwareForm.controls = {
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form')//查询表单
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {

            loadData: function () {
                boardwareForm.controls.dgdetail.datagrid({
                    idField: 'MaterialID',
                    url: '/ashx/warehousehandler.ashx?Method=SearchMaterials&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                    { field: 'Category', title: '材料类型', width: 150, align: 'center' },
                    { field: 'SubCategory', title: '子类型', width: 150, align: 'center' },
                    { field: 'MaterialCode', title: '材料编号', width: 150, sortable: false, align: 'center' },
                    { field: 'MaterialName', title: '材料名称', width: 150, sortable: false, align: 'center' },
                    { field: 'Style', title: '型号/款式', width: 150, sortable: false, align: 'center' },
                    { field: 'Color', title: '颜色', width: 150, sortable: false, align: 'center' },
                    {
                        field: 'Deepth', title: '厚度', width: 100, sortable: false, align: 'center', formatter: function (value, row, index) {
                            if (value == 0)
                                return "-";
                            else
                                return value;
                        }
                    },
                    { field: 'Unit', title: '单位', width: 150, sortable: false, align: 'center' },
                    { field: 'SafetyStock_Qty', title: '安全库存', width: 120, sortable: false, align: 'center' },
                    { field: 'Withholding_Qty', title: '预扣数量', width: 120, sortable: false, align: 'center' },
                    { field: 'WarehouseID', title: '仓库', width: 120, sortable: false, align: 'center' },
                    { field: 'LocationCode', title: '存储位置', width: 120, sortable: false, align: 'center' },
                    { field: 'Qty', title: '库存数量', width: 120, sortable: false, align: 'center' },
                    ]],
                    //toolbar: [
                    //    { text: '添加材料', iconCls: 'icon-add', handler: newlocations }
                    //],
                    onBeforeLoad: function (param) {
                        boardwareForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        boardwareForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    }
                });
            },

            loadCombobox: function () {
                $('#CategoryID').combobox({
                    url: '/ashx/materialhandler.ashx?Method=GetCategories&' + jsNC(),
                    textField: 'CategoryName',
                    valueField: 'CategoryName',
                    onSelect: function (record) {
                        $('#SubCategoryID').combobox({
                            url: '/ashx/materialhandler.ashx?Method=GetSubCategories&id=' + record.CategoryID,
                            textField: 'CategoryName',
                            valueField: 'CategoryName'
                        });
                    }
                });
            }

        }

    };
    $(function () {
        boardwareForm.init();
    });

})(jQuery);

