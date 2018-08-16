(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var materialPrice = {
        init: function () {
            materialPrice.initControls();
            materialPrice.events.loadData();
            materialPrice.events.loadSearchCombobox();
            materialPrice.controls.searchData.on("click", materialPrice.events.loadData);
        },
        initControls: function () {
            materialPrice.controls = {
                pid: getUrlParam('pid'),
                searchData: $("#btn_search_ok"),
                dgdetail: $("#dgdetail"),
                edit_form: $("#edit_form"),
                search_form: $("#search_form")
            };
        },
        events: {
            loadData: function () {
                materialPrice.controls.dgdetail.datagrid({
                    idField: 'MaterialID',
                    url: '/ashx/materialsPriceHandler.ashx?Method=SearchMaterialPrice&' + jsNC(),
                    collapsible: false,
                    fit: true,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                      { field: 'Category', title: '材料类型', width: 100, align: 'center' },
                      { field: 'SubCategory', title: '子类型', width: 100, align: 'center' },
                      { field: 'MaterialCode', title: '材料编号', width: 100, sortable: false, align: 'center' },
                      { field: 'MaterialName', title: '材料名称', width: 130, sortable: false, align: 'center' },
                      { field: 'Style', title: '型号/款式', width: 120, sortable: false, align: 'center' },
                      { field: 'Color', title: '颜色', width: 100, sortable: false, align: 'center' },
                      { field: 'Unit', title: '单位', width: 100, hidden: false, sortable: false, align: 'center' },
                      {
                          field: 'QuotedPrice', title: '单价(元)', width: 100, sortable: false, align: 'center',
                          formatter: function (value, row) {
                              if (value == "")
                                  return "0.00";
                              return value;
                          }
                      }
                    ]],
                    onBeforeLoad: function (param) {
                        materialPrice.controls.search_form.find("input").each(function () {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    }
                });
            },
            loadSearchCombobox: function () {
                $("#SearchCategoryID").combobox({
                    url: '/ashx/materialhandler.ashx?Method=GetCategories&' + jsNC(),
                    textField: 'CategoryName',
                    valueField: 'CategoryName',
                    onSelect: function (record) {
                        $("#SearchSubCategoryID").combobox({
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
        materialPrice.init();
    });
})(jQuery);

