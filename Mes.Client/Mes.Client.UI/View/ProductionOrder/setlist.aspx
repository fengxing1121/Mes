<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="setlist.aspx.cs" Inherits="Mes.Client.UI.View.ProductionOrder.setlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/easyui/datagrid/datagrid-groupview.js"></script>
    <script src="/Script/forms/ProductionOrder/jquery.forms.setlist.js?ver=1.6115"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="排单区段" region="center" border="false">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false" style="background: #fff; border: 0px solid #ccc;">
                <table id="dgproductionset"></table>
            </div>
                <div region="north" border="false" style="text-align: left;overflow: hidden;" id="search_window">
                <div style=" padding: 5px;" class="datagrid-toolbar">
                    <form id="search_form">
                        <table style="width: 100%;">
                            <tr>
                                 <td class="lbl-caption">开始日期:</td>
                                <td>
                                    <input type="text" id="Started" name="Started" class="easyui-datebox" style="width: 125px;height:25px;" /></td>
                                <td class="lbl-caption">截止日期:</td>
                                <td>
                                    <input type="text" id="Ended" name="Ended" class="easyui-datebox" style="width: 125px;height:25px;" /></td>
                                <td style="text-align: left;">
                                    <a href="javascript:void(0)" class="easyui-linkbutton" id="btn_search_ok" icon="icon-search" style="width: 80px;">搜索</a>
                                </td>
                                <td class="lbl-caption"></td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div region="east" split="true" title="排单明细" style="width:50%">
         <div class="easyui-layout" fit="true">
            <div region="center" border="false" style="background: #fff; border: 0px solid #ccc;">
                <table id="dgDayDetail"></table>
            </div>
        </div>
    </div>
</asp:Content>

