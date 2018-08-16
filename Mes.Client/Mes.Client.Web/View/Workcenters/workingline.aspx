<%@ Page Title="生产线" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="workingline.aspx.cs" Inherits="Mes.Client.Web.View.Workcenters.workingline" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/workcenters/jquery.forms.workingline.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div region="center" style="border: 0px;" border="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail">
                </table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div class="datagrid-toolbar" style="height: auto;">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">生产线名称:
                                </td>
                                <td class="lbl-caption">
                                    <input style="width: 120px" id="WorkingLineName" name="WorkingLineName" type="text" />
                                </td>
                                <td style="width:100px">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div region="east" split="false" title="生产线资料" style="width: 400px; height: 100%;" border="true">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="true" style="padding: 0px; background: #fff; overflow: hidden;">
                <form id="edit_form" name="edit_form" method="post" style="height: 100%;">
                    <div style="margin-bottom: 5px">
                        <a href="#" class="easyui-linkbutton" iconcls="icon-add" plain="true" id="btn_new">新增</a>
                        <a href="#" class="easyui-linkbutton" iconcls="icon-save" plain="true" id="btn_save">保存</a>
                    </div>
                    <div class="easyui-tabs" border="false" style="height: 100%;">
                        <div title="基本信息" style="padding: 10px;">
                            <div>
                                <input type="hidden" id="WorkingLineID" name="WorkingLineID" />
                            </div>
                            <table cellpadding="3">
                                <tr>
                                    <td class="lbl-caption">生产线名称:
                                    </td>
                                    <td style="width: 120px;">
                                        <input id="WorkingLineName" name="WorkingLineName" type="text" class="easyui-validatebox" required="true"
                                            maxlength="30" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">备注说明:
                                    </td>
                                    <td colspan="3">
                                        <textarea id="Remark" name="Remark" cols="72" rows="3" style="width: 100%; height: 80px;" class="easyui-validatebox"
                                            validtype="length[0,800]" maxlength="800"></textarea>
                                    </td>
                                </tr>
                            </table>
                        </div>

                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
