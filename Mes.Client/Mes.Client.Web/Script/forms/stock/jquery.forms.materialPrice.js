(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var AddOrUpdate = "";
    var materialPrice = {
        init: function () {
            materialPrice.initControls();
            materialPrice.events.loadData();               
            materialPrice.events.loadSearchCombobox();                                                       
            materialPrice.controls.searchData.on("click",materialPrice.events.loadData);               
            materialPrice.controls.btn_edit.on("click",materialPrice.events.addOrUpdate);
            materialPrice.events.verifyright();
        },
        initControls: function () {
            materialPrice.controls = {
                pid: getUrlParam('pid'),
                searchData: $("#btn_search_ok"),       
                dgdetail: $("#dgdetail"),                             
                edit_form:$("#edit_form"),
                add_materialPrice: $("#btn_add_ok"),  
                btn_edit: $("#btn_edit"), //编辑按钮
                search_form: $("#search_form")                                     
            };
        },
        events: {
            loadData: function () {
                materialPrice.controls.dgdetail.datagrid({
                    idField: 'MaterialID',
                    url: '/ashx/materialsPriceHandler.ashx?Method=SearchMaterialPrice&' + jsNC(),
                    collapsible: false,
                    fit:true,
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
                      { field: 'Unit', title: '单位', width: 100, hidden: false, sortable: false, align: 'center'},                                     
                      {
                          field: 'Price', title: '单价(元)', width: 100, sortable: false, align: 'center',
                          formatter: function (value,row) {
                              if (value == "")
                                  return "0.00";
                              return value;
                          }
                      }
                      
                    ]],
                    onBeforeLoad:function(param){
                        materialPrice.controls.search_form.find("input").each(function () {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (index, row) {
                        //console.log(row);
                        materialPrice.controls.edit_form.form("load",row);
                        //不等于true，则隐藏保存图标
                        if (!materialPrice.events.options.isModify)
                        {
                            materialPrice.controls.btn_edit.hide();
                        }
                        if (row["Price"]!="") {
                            AddOrUpdate = "update";
                        } else {
                            AddOrUpdate = "add";
                        }
                    },
                    toolbar: [
                       //{ text: "增加", iconCls: "icon-add",id:"btn_add",handler: materialPrice.events.showWindow }
                    ],
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
            },
            newMaterialPrice: function () {
                if (materialPrice.controls.add_form.form("validate")) {
                    $.ajax({
                        url: '/ashx/materialsPriceHandler.ashx?Method=NewMaterialPrice&',
                        method: "post",
                        data: { MaterialID: $("#materialId").val(), Price: $("#price").val() },
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    materialPrice.events.closeWindow();
                                    materialPrice.controls.dgdetail.datagrid("reload");
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },
            addOrUpdate: function () {
                switch (AddOrUpdate)
                {
                    case "add":
                        if (materialPrice.controls.edit_form.form("validate")) {
                            $.ajax({
                                url: '/ashx/materialsPriceHandler.ashx?Method=NewMaterialPrice&',
                                method: "post",
                                data: { MaterialID: $("#MaterialID").val(), Price: $("#Price").val() },
                                success: function (returnData) {
                                    if (returnData) {
                                        if (returnData.isOk == 1) {                                         
                                            materialPrice.controls.dgdetail.datagrid("reload");
                                        } else {
                                            showError(returnData.message);
                                        }
                                    }
                                }
                            });
                        }
                        break;
                    case "update":
                        if (materialPrice.controls.edit_form.form("validate")) {
                            $.ajax({
                                url: '/ashx/materialsPriceHandler.ashx?Method=ModifyMaterialPrice&',
                                method: "post",
                                data: { MaterialID: $("#MaterialID").val(), Price: $("#Price").val() },
                                success: function (returnData) {
                                    if (returnData) {
                                        if (returnData.isOk == 1) {
                                            materialPrice.controls.dgdetail.datagrid("reload");
                                        } else {
                                            showError(returnData.message);
                                        }
                                    }
                                }
                            });
                        }
                        break;
                    default: break;
                }
            },         
            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + materialPrice.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(materialPrice.controls.btn_edit,data);
                        }
                    }
                });
            },
            //用于判断是否有编辑权限
            options: {
                isModify: false
            }
        }
    };
    function rightType(eleSave, data) {      
        $(eleSave).hide();
        $(data).each(function (i, obj) {
            switch (obj.PrivilegeItemCode) {               
                case 'Modify':
                    $(eleSave).show();
                    materialPrice.events.options.isModify = true;
                    break;
                default: break;
            }
        });
    }
    $(function () {
        materialPrice.init();
    });
})(jQuery);

//清空表单
function clearForm(selector) {
    $(':input', selector).val('');
}
