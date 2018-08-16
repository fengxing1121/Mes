<%@ Page Title="客户跟进" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FollowUp.aspx.cs" Inherits="Mes.Client.Web.View.CRM.FollowUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../../Script/forms/crm/jquery.forms.followup.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <!--搜索界面-->
    <div region="center" style="border: 0px;" border="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail">
                </table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto; border-bottom: solid 1px #93ccf6;">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">客户名称:
                                </td>
                                <td class="lbl-caption">
                                    <input style="width: 120px" id="SearchCustomerID" name="CustomerName" type="text" />
                                </td>
                                <td class="lbl-caption">跟进主题:
                                </td>
                                <td class="lbl-caption">
                                    <input style="width: 120px" id="SearchTitle" name="Title" type="text" />
                                </td>
                                <td class="lbl-caption">跟进方式:
                                </td>
                                <td>
                                    <select id="Select1" name="FollowType" style="width: 100%;" class="easyui-combobox" required="true">
                                        <option value="">全部</option>
                                        <option value="直接登门">直接登门</option>
                                        <option value="邀约登门">邀约登门</option>
                                        <option value="电话跟进">电话跟进</option>
                                        <option value="手机短信">手机短信</option>
                                        <option value="其他">其他</option>
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

            <!--添加客户跟进-->
            <div id="edit_window" class="easyui-window" closed="true" title="客户跟进" data-options="iconCls:'icon-save'"
                style="width: 800px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="center" border="false">
                        <form id="edit_form" method="post">
                            <div region="center" border="false" style="padding: 0px; overflow: hidden;">
                                <div>
                                    <input type="hidden" id="FollowID" name="FollowID" />
                                </div>
                                <table style="width: 100%; height: 100%; padding: 5px;">
                                    <tr>
                                        <td class="lbl-caption" style="width: 120px;">客户名称:
                                        </td>
                                        <td colspan="3">
                                            <input type="text" style="width: 100%;" id="CustomerID" name="CustomerID" class="easyui-combogrid" editable="false" required="true" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">跟进方式: </td>
                                        <td>
                                            <select id="FollowType" name="FollowType" style="width: 100%;" class="easyui-combobox" required="true">
                                                <option value="">请选择</option>
                                                <%-- <option value="跟进方式">跟进方式</option>--%>
                                                <option value="直接登门">直接登门</option>
                                                <option value="邀约登门">邀约登门</option>
                                                <option value="电话跟进">电话跟进</option>
                                                <option value="手机短信">手机短信</option>
                                                <option value="其他">其他</option>
                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">跟进主题:
                                        </td>
                                        <td colspan="5">
                                            <textarea id="Title" name="Title" cols="3" rows="3" style="width: 100%; height: 40px;" required="true"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">跟进内容:
                                        </td>
                                        <td colspan="5">
                                            <textarea id="Remark" name="Remark" cols="5" rows="5" style="width: 100%; height: 80px;" required="true"></textarea>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">重要信息及结果:
                                        </td>
                                        <td colspan="5">
                                            <textarea id="ImportantResult" name="ImportantResult" cols="5" rows="5" style="width: 100%; height: 80px;" required="true"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">建议及应对策略:
                                        </td>
                                        <td colspan="5">
                                            <textarea id="Suggest" name="Suggest" cols="5" rows="5" style="width: 100%; height: 80px;" required="true"></textarea>
                                        </td>

                                    </tr>


                                </table>
                            </div>
                        </form>
                    </div>
                    <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 30px;">
                        <a id="btn_edit_save" icon="icon-save" class="easyui-linkbutton" href="javascript:void(0)">保存</a>
                        <a id="btn_edit_cancel" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
                    </div>
                </div>
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
</asp:Content>
