<%@ Page Title="方案详情" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SolutionShow.aspx.cs" Inherits="Mes.Client.Web.View.CRM.SolutionShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../../Content/css/ext_icons.css" rel="stylesheet" />
    <link href="../../Script/uploadify/uploadify.css" rel="stylesheet" />
    <script src="../../Script/easyui/datagrid/datagrid-bufferview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-defaultview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-detailview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-groupview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-scrollview.js"></script>
    <script src="../../Script/forms/crm/jquery.forms.solutionshow.js"></script>
    <script src="../../Script/uploadify/jquery.uploadify.min.js"></script>
    <style type="text/css">
        input[readonly] {
            border: none;
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
            height: 160px;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div region="north" border="false">
        <div style="text-align: right; padding-right: 50px; padding-top: 5px;">
            <%-- <a id="btn_upload_splitfile" icon="icon-save" style="width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">重新上传文件</a>
            <a id="btn_quote" icon="icon-save" style="width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">生成报价单</a>
            <a id="btn_cancel" icon="icon-cancel" style="width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">取消方案</a>--%>
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
                        <td class="lbl-caption">方案状态:
                        </td>
                        <td>
                            <input type="text" id="Status" name="Status" style="width: 100%;" value="新增方案" placeholder="新增方案" readonly="true" />
                        </td>
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
            <div title="产品明细" fit="true" border="false">
                <table id="dgcabinet">
                </table>
            </div>
            <div title="板件明细" fit="true" border="false">
                <table id="dgdetail">
                </table>
            </div>
            <div title="五金明细" fit="true" border="false">
                <table id="dgHardware">
                </table>
            </div>
            <div title="拆单文件" fit="true" border="false">
                <table id="skpfile"></table>
            </div>
        </div>
    </div>

    <!--上传方案文件-->
    <div id="upload_window" class="easyui-window" closed="true" title="上传方案文件" data-options="iconCls:'icon-save'"
        style="width: 340px; height: 240px; background: #fff;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false" style="overflow: hidden;">
                <form id="upload_form" method="post" style="overflow: hidden;" enctype="multipart/form-data">
                    <div class="item">
                        <input type="hidden" id="SolutionFileUrl" name="SolutionFileUrl" />
                        <input type="hidden" id="CabinetID" name="CabinetID" />
                        <div class="img_wrap">
                            <img id="imgSolution" src="/Content/images/solution_bg.png" />
                        </div>
                        <div id="Solution_queue" name="Solution_queue" style="position: absolute; top: 80px; width: 320px; z-index: 999; max-height: 160px;"></div>
                    </div>
                </form>
            </div>
            <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 30px;">
                <input type="file" name="solution_uploadify" id="solution_uploadify" />
                <a id="btn_close" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
            </div>
        </div>
    </div>

    <div id="view_window_sub" class="easyui-window" closed="true" title="板件浏览器" data-options="iconCls:'icon-save'"
        style="width: 900px; height: 580px; background: #fff;" minimizable="true" maximizable="true">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <iframe src="#" id="iframeView_sub" name="iframeView_sub" width="100%" height="99%" frameborder="0"></iframe>
            </div>
        </div>
    </div>
    <a href="#" target="_blank" id="btndown"></a>
</asp:Content>
