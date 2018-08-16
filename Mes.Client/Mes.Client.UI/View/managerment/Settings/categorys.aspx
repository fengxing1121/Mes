<%@ Page Title="数据字典管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="categorys.aspx.cs" Inherits="Mes.Client.UI.View.Management.Settings.categorys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/setting/jquery.forms.categorys.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div region="center" style="border: 0px;" border="false">
        <div class="easyui-layout" fit="true">
            <div id="div_category" region="west" title="数据字典" style="width: 400px;">
                <div>
                    <ul id="category_tree">
                    </ul>
                </div>
            </div>
            <div region="center" title="数据字典管理">
                <div class="easyui-layout" fit="true">
                    <div region="center" border="false" style="padding: 0px; background: #fff; border: 0px solid #ccc; overflow: hidden;">
                        <form id="edit_form" method="post">
                            <div style="margin-bottom: 5px;">
                                <a id="btn_edit_new" icon="icon-add" class="easyui-linkbutton" href="javascript:void(0)">新增</a>
                                <a id="btn_edit_save" icon="icon-save" class="easyui-linkbutton" href="javascript:void(0)">保存</a>
                                <a id="btn_delete" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">删除</a>
                            </div>
                            <div>
                                <input type="hidden" id="CategoryID" name="CategoryID" />
                            </div>
                            <table cellpadding="3">
                                <tr>
                                    <td class="lbl-caption">所属父级:
                                    </td>
                                    <td>
                                        <input id="ParentID" name="ParentID" class="easyui-combotree" style="width: 400px;" required="true" />                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">字典编码:
                                    </td>
                                    <td>
                                        <input type="text" id="CategoryCode" name="CategoryCode" class="easyui-validatebox" style="width: 400px;" required="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">字典名称:
                                    </td>
                                    <td>
                                        <input type="text" id="CategoryName" name="CategoryName" class="easyui-validatebox" style="width: 400px;" required="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">快捷编码:
                                    </td>
                                    <td>
                                        <input type="text" id="ShortName" name="ShortName" class="easyui-validatebox" style="width: 400px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">排序:
                                    </td>
                                    <td>
                                        <input type="text" id="Sequence" name="Sequence" class="easyui-validatebox" style="width: 400px;" required="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">是否禁用:
                                    </td>
                                    <td>
                                        <input type="checkbox" id="IsDisabled" name="IsDisabled" value="false" />
                                    </td>
                                </tr>
                            </table>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
