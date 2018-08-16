<%@ Page Title="物流企业资料" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogisticsEnterprise.aspx.cs" Inherits="Mes.Client.Web.View.Management.WareHouse.LogisticsEnterprise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/stock/jquery.forms.LogisticsEnterprise.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div region="center" style="border: 0px;" border="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail">
                </table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto 60px; border-bottom: solid 1px #93ccf6;">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">物流名称:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px" id="EnterpriseName" name="EnterpriseName" type="text" />
                                </td>

                               
                                <td class="lbl-caption">移动电话:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="Mobile" name="Mobile" type="text" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">地址：
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="AddressText" name="Address" type="text" />
                                </td>

                               
                                 <td class="lbl-caption">固定电话:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="Tel" name="Tel" type="text" />
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
    <div region="east" split="true" title="物流资料" style="width: 400px;">
        <div region="center" border="false" style="padding: 0px; background: #fff; border: 0px solid #ccc; overflow: hidden;">
            <form id="edit_form" name="edit_form" method="post">
                <div style="margin-bottom: 5px">
                    <a href="#" class="easyui-linkbutton" iconcls="icon-add" plain="true" id="btn_new">新增</a>
                    <a href="#" class="easyui-linkbutton" iconcls="icon-save" plain="true" id="btn_save">保存</a>
                </div>
                <div class="easyui-tabs" border="false">
                    <div title="基本信息" style="padding: 10px" fit="true">
                        <div>
                            <input type="hidden" id="EnterpriseID" name="EnterpriseID" />
                        </div>
                        <table cellpadding="3" id="EnterpriseInfo">
                            <tr>
                                <td class="lbl-caption">企业名称:
                                </td>
                                <td style="width: 120px;">
                                    <input id="Text1" name="EnterpriseName" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">地址:
                                </td>
                                <td colspan="3">
                                    <input id="Text2" name="Address" type="text" class="easyui-validatebox" required="true"
                                        maxlength="200" style="width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">联系人:
                                </td>
                                <td>
                                    <input id="LinkMan" name="LinkMan" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" />
                                </td>
                            </tr>

                            <tr>
                                <td class="lbl-caption">移动电话:
                                </td>
                                <td>
                                    <input id="Text4" name="Mobile" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" validtype="mobile" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">固定电话:
                                </td>
                                <td>
                                    <input id="Text3" name="Tel" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" validtype="tel" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
