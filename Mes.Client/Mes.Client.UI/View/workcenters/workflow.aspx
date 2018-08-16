<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="workflow.aspx.cs" Inherits="Mes.Client.UI.View.workcenters.workflow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/workcenters/jquery.forms.workflow.js?ver=1.211"></script>
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
                                <td class="lbl-caption">工序编号:
                                </td>
                                <td class="lbl-caption">
                                    <input style="width: 120px" id="SearchWorkFlowCode" name="WorkFlowCode" type="text" />
                                </td>
                                <td class="lbl-caption">工序名称：
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="SearchWorkFlowName" name="WorkFlowName" type="text" />
                                </td>
                                <td style="width: 100px">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div region="east" split="true" title="工序资料管理" style="width: 400px;" border="true">
        <div region="center" border="true" style="padding: 0px; background: #fff; border: 0px solid #ccc; overflow: hidden;">
            <form id="edit_form" name="edit_form" method="post">
                <div style="margin-bottom: 5px">
                    <a href="#" class="easyui-linkbutton" iconcls="icon-add" plain="true" id="btn_new">新工序</a>
                    <a href="#" class="easyui-linkbutton" iconcls="icon-save" plain="true" id="btn_save">保存</a>
                </div>
                <div class="easyui-tabs" border="false">
                    <div title="基本信息" style="padding: 10px" fit="true">
                        <div>
                            <input type="hidden" id="WorkFlowID" name="WorkFlowID" />
                        </div>
                        <table cellpadding="3">
                            <tr>
                                <td class="lbl-caption">工序编号:
                                </td>
                                <td style="width: 120px;">
                                    <input id="WorkFlowCode" name="WorkFlowCode" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">工序名称:
                                </td>
                                <td style="width: 120px;">
                                    <input id="WorkFlowName" name="WorkFlowName" type="text" class="easyui-validatebox" required="true"  maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">工序图片:
                                </td>
                                <td style="width: 120px;">
                                    <input id="ImageUrl" name="ImageUrl" type="text" class="easyui-validatebox" required="true"  />
                                </td>
                            </tr>
                           <tr>
                                <td class="lbl-caption">排序:
                                </td>
                                <td colspan="3">
                                    <input id="SortNo" name="SortNo" type="text" class="easyui-validatebox" required="true"
                                        maxlength="200" style="width: 100%;" />
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
</asp:Content>

