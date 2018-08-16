<%@ Page Title="我的任务" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="factorytask.aspx.cs" Inherits="Mes.Client.Web.View.Orders.factorytask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        input[readonly] {
            border: none;
            background: #f0f0f0;
        }
        .item {
            width: 100%;
            height: 200px;
            margin-left: 0px;
            margin-top: 0px;
            border: none;
            float: left;
        }
        .img_wrap {
            border: solid 1px #eee;
            width: 320px;
            height: 130px;
            display: table-cell;
            text-align: center;
            vertical-align: middle;
        }
        .img_wrap img {
                max-width: 320px;
                max-height: 160px;
                height: 240px auto;
                width: 160px auto;
                vertical-align: middle;
                text-align: center;
            }
    </style>
    <script src="/Script/forms/orders/jquery.forms.factorytask.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
   <!--任务管理-->
   <div title="任务管理" region="center" border="false">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false" style="background: #fff; border: 0px solid #ccc;">
                <table id="dgFactoryTask"></table>
            </div>
            <div region="north" border="false" style="text-align: left;overflow: hidden;" id="search_window">
                <div class="datagrid-toolbar" style="height: auto;">
                    <form id="search_task_form">
                        <table>
                            <tr>
                                <td class="lbl-caption">任务编号:</td>
                                <td>
                                    <input type="text" name="TaskNo" />
                                </td>
                                <td class="lbl-caption">任务类型:</td>
                                <td>
                                    <input type="text" name="TaskType" style="width: 130px" />
                                </td>
                                <td style="width:100px;text-align:right;">
                                    <a href="javascript:void(0)" class="easyui-linkbutton" id="btn_search_task" icon="icon-search">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>

   <!--任务步骤明细--->
   <div id="taskstep_window" class="easyui-window" closed="true" title="任务明细" data-options="iconCls:'icon-save'" style="width: 850px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="taskdetail"></table>
            </div>
        </div>
   </div>
</asp:Content>
