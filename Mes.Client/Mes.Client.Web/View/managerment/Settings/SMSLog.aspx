<%@ Page Title="手机注册短信记录" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SMSLog.aspx.cs" Inherits="Mes.Client.Web.View.Management.Settings.SMSLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/setting/SMSLog.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div title="手机注册短信记录" region="center" style="border: 0px;" border="false">
        <!--搜索界面-->
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail"></table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto 50px;" class="datagrid-toolbar">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">创建日期：</td>
                                <td>
                                    <input type="text" id="CreatedDateFrom" name="CreatedFrom" class="easyui-datebox" style="width: 125px;height:25px;" /></td>
                                <td>至：</td>
                                <td>
                                    <input type="text" id="CreatedDateTo" name="CreatedTo" class="easyui-datebox" style="width: 125px;height:25px;" /></td>
                                <td class="lbl-caption" style="text-align: left">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search" style="width: 80px;">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
            <div id="edit_window" class="easyui-window" closed="true" title="审核明细" data-options="iconCls:'icon-save'"
                style="width: 850px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="center" border="false">
                        <table id="dgsteps"></table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
