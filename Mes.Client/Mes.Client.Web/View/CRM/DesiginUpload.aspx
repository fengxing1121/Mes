<%@ Page Title="客户量尺" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DesiginUpload.aspx.cs" Inherits="Mes.Client.Web.View.CRM.DesiginUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../../Content/css/ext_icons.css" rel="stylesheet" />
    <link href="../../Script/stream-v1/stream-v1.css" rel="stylesheet" />
    <script src="../../Script/stream-v1/stream-v1.js"></script>
    <script src="../../Script/forms/crm/jquery.forms.roomdesigner.js"></script>
    <style type="text/css">
        .btn_download:hover {
            cursor: pointer;
        }

        .btn_download {
            width: 180px;
            height: 35px;
            font-size: 13px;
            font-family: NSimSun;
            text-align: center;
            line-height: 40px;
            display: block;
            background: #87CEFF;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            border-radius: 3px;
        }

        .item {
            width: 100%;
            height: 800px;
            margin-left: 0px;
            margin-top: 0px;
            border: none;
            float: left;
        }

        .img_wrap {
            border: solid 1px #eee;
            width: 300px;
            height: 80px;
            display: table-cell;
            text-align: center;
            vertical-align: middle;
        }

            .img_wrap img {
                max-width: 320px;
                max-height: 160px;
                height: 80px auto;
                width: 150px auto;
                vertical-align: middle;
                text-align: center;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="客户量尺列表" region="center" style="border: 0px;" border="false">
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
                                <td class="lbl-caption">客户名称:</td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="SearchCustomerID" name="CustomerName" type="text" />
                                </td>
                                <td class="lbl-caption">设计者</td>
                                <td style="width: 120px;">
                                    <input type="text" style="width: 120px" id="SearchDesigner" name="Designer" />
                                </td>
                                <td class="lbl-caption">状态:</td>
                                <td>
                                    <select id="Select1" name="Status" style="width: 100%;" editable="false" class="easyui-combobox" required="true">
                                        <option value="">全部</option>
                                        <option value="N">待设计</option>
                                        <option value="C">已设计</option>
                                    </select>
                                </td>
                                <td colspan="2" style="text-align: left">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search" style="width: 80px;">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>

            <!--添加客户量尺-->
            <div id="edit_window" class="easyui-window" closed="true" title="客户量尺" data-options="iconCls:'icon-save'" fit="true" style="background: #fff;" minimizable="false" maximizable="false">
                <form id="edit_form" method="post" enctype="multipart/form-data" style="height: 100%; width: 100%;">
                    <div class="easyui-layout" fit="true" border="false">
                        <div region="north" border="false">
                            <div>
                                <input type="hidden" id="DesignerID" name="DesignerID" />
                                <input type="hidden" id="RoomDesignerFiles" name="RoomDesignerFiles" />
                            </div>
                            <table style="width: 100%; padding: 4px;">
                                <tr>
                                    <td class="lbl-caption" style="width: 80px;">ID:</td>
                                    <td>
                                        <input type="text" style="width: 100%; height: 27px;" id="DesignerNo" name="DesignerNo" class="easyui-combogrid" editable="false" required="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption" style="width: 120px;">客户名称:</td>
                                    <td>
                                        <input type="text" style="width: 100%; height: 27px;" id="CustomerID" name="CustomerID" class="easyui-combogrid" editable="false" required="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">房间数:</td>
                                    <td>
                                        <input type="text" id="Rooms" name="Rooms" class="easyui-validatebox" style="width: 100%;" required="true" />
                                    </td>
                                    <td class="lbl-caption">客厅和餐厅数:</td>
                                    <td>
                                        <input type="text" id="SittingAndDiningRoom" name="SittingAndDiningRoom" class="easyui-validatebox" style="width: 100%;" required="true" />
                                        <%-- <select id="SittingAndDiningRoom" name="SittingAndDiningRoom" style="width: 100%;height:27px;" class="easyui-combobox" required="true">
                                                <option value=""></option>
                                                <option value="一房一厅">一房一厅</option>
                                                <option value="一房两厅">一房两厅</option>
                                                <option value="二房一厅">二房一厅</option>
                                                <option value="三房一厅">三房一厅</option>
                                                <option value="三房两厅">三房两厅</option>
                                            </select>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">房屋面积:</td>
                                    <td>
                                        <input type="text" id="TotalAreal" name="TotalAreal" class="easyui-validatebox" style="width: 100%;" required="true" />
                                    </td>
                                    <td class="lbl-caption">家庭人员: </td>
                                    <td>
                                        <input type="text" id="FamilyMembers" name="FamilyMembers" class="easyui-validatebox" style="width: 100%;" required="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">预算(万元):</td>
                                    <td>
                                        <input type="text" id="Budget" name="Budget" class="easyui-validatebox" style="width: 100%;" required="true" />
                                    </td>
                                    <td class="lbl-caption">量尺日期:</td>
                                    <td>
                                        <input type="text" id="Designed" name="Designed" class="easyui-datebox" style="width: 100%;" required="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">所住小区名称: </td>
                                    <td colspan="5">
                                        <input type="text" id="VillageName" name="VillageName" style="width: 100%;" class="easyui-validatebox" required="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">栋数（号数）:</td>
                                    <td>
                                        <input type="text" id="Building" name="Building" style="width: 100%;" class="easyui-validatebox" required="true" />
                                    </td>
                                    <td class="lbl-caption">所在单元: </td>
                                    <td>
                                        <select id="Unit" name="Unit" style="width: 100%; height: 27px;" class="easyui-combobox" required="true">
                                            <option value=""></option>
                                            <option value="一">一单元</option>
                                            <option value="二">二单元</option>
                                            <option value="三">三单元</option>
                                            <option value="四">四单元</option>
                                            <option value="五">五单元</option>
                                            <option value="六">六单元</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">房号:</td>
                                    <td>
                                        <input type="text" id="RoomNo" name="RoomNo" style="width: 100%;" class="easyui-validatebox" required="true" />
                                    </td>
                                    <td class="lbl-caption">喜欢颜色:</td>
                                    <td>
                                        <input type="text" id="Color" name="Color" style="width: 100%;" class="easyui-validatebox" required="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">装修风格: </td>
                                    <td>
                                        <input type="text" id="Style" name="Style" style="width: 100%;" class="easyui-validatebox" required="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">备注: </td>
                                    <td colspan="5">
                                        <textarea id="Remark" name="Remark" cols="5" rows="5" style="width: 100%; height: 50px;"></textarea>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div region="center" border="false" style="padding: 0px; overflow: hidden;" title="上传文件">
                            <div class="item">
                                <div id="i_select_files"></div>
                                <div id="i_stream_files_queue" style="height: 150px;"></div>
                                <div id="i_stream_message_container" class="stream-main-upload-box" style="overflow: auto; height: 200px; display: none;"></div>
                            </div>
                        </div>
                        <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 30px;">
                            <a id="btn_edit_save" icon="icon-save" class="easyui-linkbutton" href="javascript:void(0)">保存</a>
                            <a id="btn_edit_cancel" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <!--客户下拉选择-->
    <div id="tb" style="padding: 5px; height: auto">
        <form id="search_form_customer">
            <table>
                <tr>
                    <td class="lbl-caption">客户名称: </td>
                    <td style="text-align: left">
                        <input type="text" id="CustomerNames" name="CustomerName" />
                    </td>
                    <td class="lbl-caption">联系人: </td>
                    <td style="text-align: left">
                        <input type="text" id="LinkMan" name="LinkMan" />
                    </td>
                    <td class="lbl-caption">移动电话:
                    </td>
                    <td style="width: 120px;">
                        <input style="width: 120px; height: 22px;" id="Mobile" name="Mobile" type="text" />
                    </td>
                </tr>
                <tr>
                    <td class="lbl-caption">省份:
                    </td>
                    <td style="width: 120px;">
                        <input style="width: 120px; height: 22px;" id="ProvinceText" name="Province" type="text" />
                    </td>

                    <td class="lbl-caption">城市：
                    </td>
                    <td style="width: 120px;">
                        <input style="width: 120px; height: 22px;" id="City" name="City" type="text" />
                    </td>

                    <td class="lbl-caption">地址：
                    </td>
                    <td style="width: 120px;">
                        <input style="width: 120px; height: 22px;" id="Address" name="Address" type="text" />
                    </td>

                    <td colspan="2" style="text-align: left">
                        <a href="javascript:void(0)" id="btn_search_customer" icon="icon-search" style="width: 80px;">搜索</a>
                    </td>

                </tr>
            </table>
        </form>
    </div>
    <script src="../../Script/stream-v1/stream.config.js"></script>
</asp:Content>
