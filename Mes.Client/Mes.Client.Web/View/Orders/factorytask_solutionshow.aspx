<%@ Page Title="方案审核" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="factorytask_solutionshow.aspx.cs" Inherits="Mes.Client.Web.View.Orders.factorytask_solutionshow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
     <style type="text/css">
        input[readonly]
        {
            border: none;
        }
        .item
        {
            width: 100%;
            height: 200px;
            margin-left: 0px;
            margin-top: 0px;
            border: none;
            float: left;
        }
        .img_wrap
        {
            border: solid 1px #eee;
            width: 320px;
            height: 160px;
            display: table-cell;
            text-align: center;
            vertical-align: middle;
        }
        .img_wrap img
            {
                max-width: 320px;
                max-height: 160px;
                height: 240px auto;
                width: 160px auto;
                vertical-align: middle;
                text-align: center;
       }
    </style>
    <script src="/Script/forms/orders/jquery.forms.factorytask_solutionshow.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div region="north" border="false">
        <div style="text-align: right; padding-right: 50px; padding-top: 5px;">
            <a id="btn_verify_ok" icon="icon-save" style="width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">审核通过</a>
            <a id="btn_undo" icon="icon-undo" style="width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">重新上传方案</a>
        </div>
        <div style="width: 100%;">
            <form id="edit_form" method="post" enctype="multipart/form-data" style="height: 100%;">
                <input type="hidden" id="SolutionID" name="SolutionID" />
                <table style="width: 100%; height: auto; padding: 5px;">
                    <tr>
                        <td class="lbl-caption" style="width: 120px;">方案编号:</td>
                        <td>
                            <input type="text" id="SolutionCode" name="SolutionCode" class="easyui-validatebox" style="width: 200px;" readonly="true" />
                        </td>
                        <td class="lbl-caption" style="width: 120px;">方案名称:</td>
                        <td>
                            <input type="text" id="SolutionName" name="SolutionName" class="easyui-validatebox" style="width: 200px;" readonly="true" />
                        </td>
                        <td class="lbl-caption" style="width: 120px;">设计师:</td>
                        <td>
                            <input type="text" id="Designer" name="Designer" style="width: 200px;" readonly="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl-caption">客户名称:
                        </td>
                        <td colspan="3">
                            <input type="text" style="width: 100%; height: 25px;" id="CustomerName" name="CustomerName" readonly="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl-caption">联系电话:
                        </td>
                        <td>
                            <input type="text" id="Mobile" name="Mobile" style="width: 200px;" readonly="true" />
                        </td>
                        <td class="lbl-caption">联系人:
                        </td>
                        <td>
                            <input type="text" id="LinkMan" name="LinkMan" style="width: 200px;" readonly="true" />
                        </td>
                       <%-- <td class="lbl-caption">方案状态:
                        </td>
                        <td>
                            <input type="text" id="Status" name="Status" style="width: 100%;" value="新增方案" placeholder="新增方案" readonly="true" />
                        </td>--%>
                    </tr>
                    <tr>
                        <td class="lbl-caption">客户地址:
                        </td>
                        <td colspan="7">
                            <input type="text" id="Address" name="Address" style="width: 100%;" readonly="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl-caption" style="vertical-align: top;">方案备注:
                        </td>
                        <td colspan="5">
                            <textarea id="Remark" name="Remark" cols="5" rows="5" style="width: 100%; height: 80px; border: none;" readonly="readonly"></textarea>
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>

    <div region="center" border="false">
        <div class="easyui-tabs" fit="true" border="false" id="tt">
            <div title="方案明细" fit="true" border="false">
                <table id="dgcabinet"> </table>
            </div>
            <div title="板件明细" fit="true" border="false">
                <table id="dgdetail"> </table>
            </div>
            <div title="五金明细" fit="true" border="false">
                <table id="dgHardware"></table>
            </div>
            <div title="spk文件" fit="true" border="false">
                <table id="skpfile"></table>
            </div>
        </div>
    </div>
</asp:Content>
