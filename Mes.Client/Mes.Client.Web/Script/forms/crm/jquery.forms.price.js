(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var materialsForm = {
        init: function () {
            materialsForm.initControls();
            materialsForm.events.loadData();
            materialsForm.controls.searchData.on('click', materialsForm.events.loadData);//加载数据             
            materialsForm.events.loadSearchCobobox();
        },
        initControls: function () {
            materialsForm.controls = {
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form')//查询表单                
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {
            loadData: function () {
                //初始化数据    
                materialsForm.controls.dgdetail.datagrid({
                    idField: 'MaterialID',
                    url: '/ashx/materialpricehandler.ashx?Method=SearchMaterialPrice&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                     { field: 'Category', title: '材料类型', width: 150, align: 'center' },
                      { field: 'SubCategory', title: '子类型', width: 150, align: 'center' },
                      { field: 'MaterialCode', title: '材料编号', width: 120, sortable: false, align: 'center' },
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
                      { field: 'MinPurchaseQty', title: '最小采购量', width: 150, align: 'center' },
                      { field: 'MinDelivery', title: '最小交期', width: 120, sortable: false, align: 'center' },
                      { field: 'Price', title: '单价', width: 100, sortable: false, align: 'center' },
                      {
                          field: 'Unit', title: '单位', width: 100, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                              if (value == '元/平方米')
                                  return '<span>元/M<Sup>2</Sup></span>';
                              else if (value == '元/立方米')
                                  return '<span>元/M<Sup>3</Sup></span>';
                              else
                                  return value;
                          }
                      }
                    ]],
                    onBeforeLoad: function (param) {
                        materialsForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        materialsForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                    }
                });
            },
            loadSearchCobobox: function () {
                $('#SearchCategoryID').combobox({
                    url: '/ashx/materialhandler.ashx?Method=GetCategories&' + jsNC(),
                    textField: 'CategoryName',
                    valueField: 'CategoryName',
                    onSelect: function (record) {
                        $('#SearchSubCategoryID').combobox({
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
        materialsForm.init();
    });

})(jQuery);
