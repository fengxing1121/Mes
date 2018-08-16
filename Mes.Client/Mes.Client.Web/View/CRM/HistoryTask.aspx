<%@ Page Title="任务历史记录" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistoryTask.aspx.cs" Inherits="Mes.Client.Web.View.CRM.HistoryTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../../Script/forms/crm/jquery.forms.historytask.js"></script>
    <style>
        input[readonly] {
            border: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <!--任务管理-->
    <div title="任务管理" region="center" border="false">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false" style="background: #fff; border: 0px solid #ccc;">
                <table id="datagrid"></table>
            </div>
            <div region="north" border="false" style="text-align: left; height: 70px; overflow: hidden;" id="search_window">
                <div style="height: 60px; padding: 5px;" class="datagrid-toolbar">
                    <form id="search_form">
                        <table style="width: 100%; height: 50px;">
                            <tr>
                                <td class="lbl-caption">任务编号:</td>
                                <td>
                                    <input type="text" name="TaskNo" />
                                </td>
                                <td class="lbl-caption">任务类型:</td>
                                <td>
                                    <input type="text" name="TaskType" style="width: 130px" />
                                </td>
                                <td style="text-align: left;">
                                    <a href="javascript:void(0)" class="easyui-linkbutton" id="btn_search_task" icon="icon-search" style="width: 80px;">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!--任务步骤明细--->
    <div id="taskstep_window" class="easyui-window" closed="true" title="任务明细" data-options="iconCls:'icon-save'" fit="true" minimizable="false" maximizable="false">
        <form id="edit_taskstep_form" method="post" enctype="multipart/form-data" style="height: 100%; width: 100%;">
            <div class="easyui-layout" border="false" fit="true">
                <div region="north" border="false">
                    <table style="width: 100%; overflow: hidden;">
                        <tr>
                            <td class="lbl-caption">方案编号:</td>
                            <td>
                                <input type="text" name="SolutionCode" class="easyui-validatebox" style="width: 200px;" readonly="true" />
                            </td>
                            <td class="lbl-caption" style="width: 100px;">方案名称:</td>
                            <td>
                                <input type="text" name="SolutionName" class="easyui-validatebox" style="width: 200px;" readonly="true" />
                            </td>
                            <td class="lbl-caption" style="width: 100px;">设计师:</td>
                            <td>
                                <input type="text" name="Designer" style="width: 200px;" readonly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">客户名称:</td>
                            <td colspan="3">
                                <input type="text" name="CustomerName" style="width: 200px; height: 25px;" readonly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">联系电话:</td>
                            <td>
                                <input type="text" name="Mobile" style="width: 200px;" readonly="true" />
                            </td>
                            <td class="lbl-caption">联系人:</td>
                            <td>
                                <input type="text" name="LinkMan" style="width: 200px;" readonly="true" />
                            </td>
                            <td class="lbl-caption">方案状态:</td>
                            <td>
                                <input type="text" name="Status" style="width: 200px;" readonly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">客户地址:</td>
                            <td colspan="4">
                                <input type="text" name="Address" style="width: 100%;" readonly="true" />
                            </td>
                        </tr>
                        <tr></tr>
                        <tr></tr>
                        <tr></tr>
                    </table>
                </div>
                <div region="center" border="false" style="padding: 0px; overflow: hidden;">
                    <div class="easyui-tabs" fit="true" border="false">
                        <div title="步骤明细" fit="true" border="false">
                            <table id="taskdetail"></table>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
