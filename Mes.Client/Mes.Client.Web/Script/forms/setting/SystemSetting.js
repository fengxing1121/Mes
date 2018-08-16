(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var settingForm = {
        init: function () {
            settingForm.initControls();
            settingForm.controls.btn_save.on('click', settingForm.events.btn_save);//保存             
            settingForm.controls.savedata = new Object();
            settingForm.controls.edit_form.find('input[type=text]').change(function () {
                var name = $(this).attr('name') == undefined ? $(this).attr('numberboxname') : $(this).attr('name');
                settingForm.controls.savedata[name] = $(this).val();
            });

            settingForm.controls.edit_form.find('input[type=checkbox]').change(function () {
                settingForm.controls.savedata[$(this).attr('name')] = $(this).is(':checked');
            });
            settingForm.events.InitCombobox();
            settingForm.events.LoadCombobox();

            settingForm.events.verifyright();

        },
        initControls: function () {
            settingForm.controls = {
                pid: getUrlParam('pid'),
                savedata: null,
                nullvalue: null,
                edit_form: $('#edit_form'),
                btn_save: $('#btn_save'),
                actionUrl: '/ashx/workcenterhandler.ashx'
            }
        },
        events: {
            btn_save: function () {
                if (Object.keys(settingForm.controls.savedata).length > 0) {
                    settingForm.events.Save();
                }
                else {
                    $.messager.alert('错误信息', '没有任何已编辑的数据', 'error');
                }
            },

            InitCombobox: function () {
                $('#Key_WorkFlow_PagageCode,#Key_WorkFlow_CleanCode,#Key_WorkFlow_EdgeDescCode,#Key_WorkFlow_NormalMadeCode,#Key_WorkFlow_SpecialMadeCode,#Key_WorkFlow_NormalDrillingHoleCode,#Key_WorkFlow_SpecialDrillingHoleCode,#Key_WorkFlow_NormalGroovingCode,#Key_WorkFlow_SpecialGroovingCode').combobox({
                    url: settingForm.controls.actionUrl + '?Method=GetWorkFlows&' + jsNC(),
                    textField: 'WorkFlowName',
                    valueField: 'WorkFlowID',
                    editable: false,
                    onChange: function (newValue, oldValue) {
                        settingForm.controls.savedata[this.id] = newValue;
                    }
                });
            },
            Save: function () {
                var kv = [];
                //将KeyCode和Value转化为KeyValue形式
                for (var i in settingForm.controls.savedata) {
                    kv.push({ Key: i, Value: escape(settingForm.controls.savedata[i]) });
                }
                //序列化对象为Json字符串
                var sd = JSON.stringify(kv);
                settingForm.controls.nullvalue = "";
                $.ajax({
                    url: '/ashx/systemsettingshandler.ashx',
                    type: 'post',
                    data: { Method: 'Save', SaveData: sd },
                    success: function (data) {
                        if (data.isOk == 1) {
                            showInfo(data.message);
                            settingForm.controls.savedata = [];
                        }
                    }
                });
            },
            LoadCombobox: function () {
                $.ajax({
                    url: '/ashx/systemsettingshandler.ashx',
                    type: 'post',
                    data: { Method: 'GetKeyValues' },
                    success: function (data) {
                        $.each(data.rows, function (index, row) {
                            var input = settingForm.controls.edit_form.find($('#' + row.Key));
                            if (input.length > 0) {
                                if (input[0].className.indexOf('easyui-combobox') >= 0) {
                                    input.combobox('setValue', row.Value);
                                }
                                else if (input[0].className.indexOf('easyui-textbox') >= 0) {
                                    input.val(row.Value);
                                }
                                else if (input[0].className.indexOf('easyui-datebox') >= 0) {
                                    input.val(row.Value);
                                }
                                else if (input[0].type == 'text') {
                                    input.val(row.Value);
                                }
                                else if (input[0].type == 'checkbox') {
                                    input.attr('checked', row.Value);
                                }
                            }
                        });
                    }
                });
            },

            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + settingForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(data);
                        }
                    }
                });
            }
        }

    };

    function rightType(data) {
        settingForm.controls.btn_save.hide();
        $(data).each(function (i, obj) {
            switch (obj.PrivilegeItemCode) {                 
                case 'Modify':
                    settingForm.controls.btn_save.show();
                    break;
                default: break;
            }
        });
    }

    $(function () {
        settingForm.init();
    });

})(jQuery);

