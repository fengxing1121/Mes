<%@ Page Title="系统设置" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SystemSettings.aspx.cs" Inherits="Mes.Client.UI.View.Management.Settings.SystemSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style>
        body
        {            
            margin: 40px auto;
            font-family: 'trebuchet MS', 'Lucida sans', Arial;
            font-size: 14px;
            color: #444;
        }

        table
        {
            *border-collapse: collapse; /* IE7 and lower */
            border-spacing: 0;
            width: 100%;
        }

        .bordered
        {
            border: solid #ccc 1px;
            -moz-border-radius: 6px;
            -webkit-border-radius: 6px;
            /*border-radius: 6px;*/
            -webkit-box-shadow: 0 1px 1px #ccc;
            -moz-box-shadow: 0 1px 1px #ccc;
            box-shadow: 0 1px 1px #ccc;
        }

            .bordered tr:hover
            {
                background: #fbf8e9;
                -o-transition: all 0.1s ease-in-out;
                -webkit-transition: all 0.1s ease-in-out;
                -moz-transition: all 0.1s ease-in-out;
                -ms-transition: all 0.1s ease-in-out;
                transition: all 0.1s ease-in-out;
            }

            .bordered td, .bordered th
            {
                border-left: 1px solid #ccc;
                border-top: 1px solid #ccc;
                height: 25px;
                padding: 2px;
                text-align: left;
            }

                .bordered td:nth-child(2)
                {
                    text-align: right;
                }

            .bordered th
            {
                background-color: #dce9f9;
                background-image: -webkit-gradient(linear, left top, left bottom, from(#ebf3fc), to(#dce9f9));
                background-image: -webkit-linear-gradient(top, #ebf3fc, #dce9f9);
                background-image: -moz-linear-gradient(top, #ebf3fc, #dce9f9);
                background-image: -ms-linear-gradient(top, #ebf3fc, #dce9f9);
                background-image: -o-linear-gradient(top, #ebf3fc, #dce9f9);
                background-image: linear-gradient(top, #ebf3fc, #dce9f9);
                -webkit-box-shadow: 0 1px 0 rgba(255,255,255,.8) inset;
                -moz-box-shadow: 0 1px 0 rgba(255,255,255,.8) inset;
                box-shadow: 0 1px 0 rgba(255,255,255,.8) inset;
                border-top: none;
                text-shadow: 0 1px 0 rgba(255,255,255,.5);
            }

                .bordered td:first-child, .bordered th:first-child
                {
                    border-left: none;
                } 
         

        .zebra td, .zebra th
        {
            /*padding: 10px;*/
            border-bottom: 1px solid #f2f2f2;
        }

        .zebra tbody tr:nth-child(even)
        {
            background: #f5f5f5;
            -webkit-box-shadow: 0 1px 0 rgba(255,255,255,.8) inset;
            -moz-box-shadow: 0 1px 0 rgba(255,255,255,.8) inset;
            box-shadow: 0 1px 0 rgba(255,255,255,.8) inset;
        }

        .zebra th
        {
            text-align: left;
            text-shadow: 0 1px 0 rgba(255,255,255,.5);
            border-bottom: 1px solid #ccc;
            background-color: #eee;
            background-image: -webkit-gradient(linear, left top, left bottom, from(#f5f5f5), to(#eee));
            background-image: -webkit-linear-gradient(top, #f5f5f5, #eee);
            background-image: -moz-linear-gradient(top, #f5f5f5, #eee);
            background-image: -ms-linear-gradient(top, #f5f5f5, #eee);
            background-image: -o-linear-gradient(top, #f5f5f5, #eee);
            background-image: linear-gradient(top, #f5f5f5, #eee);
        }

        
        .zebra tfoot td
        {
            border-bottom: 0;
            border-top: 1px solid #fff;
            background-color: #f1f1f1;
        }

        
    </style>
    <script src="/Script/forms/setting/SystemSetting.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div class="easyui-layout" fit="true">
        <div region="center" border="false">
            <div class="easyui-panel" title="参数设置" fit="true">
                <form id="edit_form" style="width: 100%;">
                    <table id="dg" class="bordered" style="width: 100%;">
                        <%--class="easyui-datagrid" fit="false" striped="false" nowrap="true" pagination="false" fitcolumns="true" rownumbers="true" title="系统参数配置" --%>
                        <thead>
                            <tr>
                                <th field='op' style="width: 200px;" align="center"></th>
                                <th field='Remark' style="width: 200px;" halign="center" align="right">参数名称</th>
                                <th field='Value' style="width: auto;" align="left">参数值</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>工序代码配置</td>
                                <td>普通开料工序代码：</td>
                                <td>
                                    <input type="text" class="easyui-combobox" id="Key_WorkFlow_NormalMadeCode" name="Key_WorkFlow_NormalMadeCode" /></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>异形开料工序代码：</td>
                                <td>
                                    <input type="text" class="easyui-combobox" id="Key_WorkFlow_SpecialMadeCode" name="Key_WorkFlow_SpecialMadeCode" value="" /></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>普通打孔工序代码：</td>
                                <td>
                                    <input type="text" class="easyui-combobox" id="Key_WorkFlow_NormalDrillingHoleCode" name="Key_WorkFlow_NormalDrillingHoleCode" value="" /></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>异形打孔工序代码：</td>
                                <td>
                                    <input type="text" class="easyui-combobox" id="Key_WorkFlow_SpecialDrillingHoleCode" name="Key_WorkFlow_SpecialDrillingHoleCode" value="" /></td>

                            </tr>
                            <tr>
                                <td></td>
                                <td>普通开槽工序代码：</td>
                                <td>
                                    <input type="text" class="easyui-combobox" id="Key_WorkFlow_NormalGroovingCode" name="Key_WorkFlow_NormalGroovingCode" value="" /></td>

                            </tr>
                            <tr>
                                <td></td>
                                <td>异形开槽工序代码：</td>
                                <td>
                                    <input type="text" class="easyui-combobox" id="Key_WorkFlow_SpecialGroovingCode" name="Key_WorkFlow_SpecialGroovingCode" value="" /></td>

                            </tr>
                            <tr>
                                <td></td>
                                <td>封边工序代码：</td>
                                <td>
                                    <input type="text" class="easyui-combobox" id="Key_WorkFlow_EdgeDescCode" name="Key_WorkFlow_EdgeDescCode" value="" /></td>

                            </tr>
                            <tr>
                                <td></td>
                                <td>清洁工序代码：</td>
                                <td>
                                    <input type="text" class="easyui-combobox" id="Key_WorkFlow_CleanCode" name="Key_WorkFlow_CleanCode" value="" /></td>

                            </tr>
                            <tr>
                                <td></td>
                                <td>包装工序代码：</td>
                                <td>
                                    <input type="text" class="easyui-combobox" id="Key_WorkFlow_PagageCode" name="Key_WorkFlow_PagageCode" value="" /></td>

                            </tr>
                            <tr>
                                <td>用户安全设置</td>
                                <td>用户初始密码</td>
                                <td>
                                    <input id="KeyUserDefaultPassword" type="text" name="KeyUserDefaultPassword" value="123456" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>密码过期天数(0天表示密码永不过期)</td>
                                <td>
                                    <input id="KeyDaysPasswordExpired" type="text" name="KeyDaysPasswordExpired" value="0" min="0" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>密码连续错误次数(0表示不限制)</td>
                                <td>
                                    <input id="KeyLoginErrorCount" type="text" name="KeyLoginErrorCount" value="0" min="0" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>密码N次后可重复使用(0表示不限制)</td>
                                <td>
                                    <input id="KeyPasswordCanNotSameCount" type="text" name="KeyPasswordCanNotSameCount" value="0" min="0" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>用户第一次登录必须修改密码</td>
                                <td>
                                    <input id="KeyMustChangePasswordAtFirstLogin" type="checkbox" name="KeyMustChangePasswordAtFirstLogin" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>是否密码强度校验</td>
                                <td>
                                    <input id="KeyMustVerifyPasswordStrength" type="checkbox" name="KeyMustVerifyPasswordStrength" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>订单前缀字符</td>
                                <td>
                                    <input id="OrderPrefix" type="text" name="OrderPrefix" value="" maxlength="4" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>是否开通短信验证</td>
                                <td>
                                    <input id="KeyIsSMSCheck" type="checkbox" name="KeyIsSMSCheck" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div style="width: 80px; margin: 10px auto;"><a id="btn_save" name="save" class="easyui-linkbutton" icon="icon-save" href="javascript:void(0)">保存</a></div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
