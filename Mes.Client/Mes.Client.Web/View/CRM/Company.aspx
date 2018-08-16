<%@ Page Title="工厂管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="Mes.Client.Web.View.CRM.Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../../Script/common/region_select.js"></script>
    <script src="../../Script/forms/crm/jquery.forms.company.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div region="center" style="border: 0px;" border="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail"></table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto; border-bottom: solid 1px #93ccf6;">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">工厂名称:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px" id="CompanyName" name="CompanyName" type="text" />
                                </td>
                                <td class="lbl-caption">移动电话:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="Mobile" name="Mobile" type="text" />
                                </td>
                                <td class="lbl-caption">地址：
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="Address" name="Address" type="text" />
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
    <div region="east" split="true" title="商户资料管理" style="width: 400px;" border="true">
        <div region="center" border="true" style="padding: 0px; background: #fff; border: 0px solid #ccc; overflow: hidden;">
            <form id="edit_form" name="edit_form" method="post">
                <div style="margin-bottom: 5px">
                    <a href="#" class="easyui-linkbutton" iconcls="icon-add" plain="true" id="btn_new">新商户</a>
                    <a href="#" class="easyui-linkbutton" iconcls="icon-save" plain="true" id="btn_save">保存</a>
                </div>
                <div class="easyui-tabs" border="false">
                    <div title="基本信息" style="padding: 10px" fit="true">
                        <div>
                            <input type="hidden" id="PartnerID" name="PartnerID" />
                        </div>
                        <table cellpadding="3" id="tbPartnerInfo">
                            <tr style="display: none;">
                                <td style="width: 120px; display: none">
                                    <input style="width: 120px" id="CompanyID" name="CompanyID" type="text" />
                                </td>
                                <td class="lbl-caption">商户类型:
                                </td>
                                <td style="width: 130px;">
                                    <select id="ShopType" name="ShopType" type="text" class="easyui-combobox" style="width: 125px;">
                                        <option value="1">直营店</option>
                                        <option value="2">加盟店</option>
                                        <option value="3" selected="">合资店</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">工厂名称:<span style="color: red;">*</span>
                                </td>
                                <td style="width: 120px;">
                                    <input name="CompanyName" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">联系人:<span style="color: red;">*</span>
                                </td>
                                <td>
                                    <input id="LinkMan" name="LinkMan" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">移动电话:<span style="color: red;">*</span>
                                </td>
                                <td>
                                    <input id="Mobile" name="Mobile" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" validtype="mobile" />
                                </td>
                            </tr>
                            <%--<tr style="display:none;">
                                <td class="lbl-caption">固定电话:
                                </td>
                                <td>
                                    <input id="Tel" name="Tel" type="text" class="easyui-validatebox" 
                                        maxlength="30" validtype="tel"/>
                                </td>
                            </tr>--%>
                            <tr>
                                <td class="lbl-caption">邮箱:
                                </td>
                                <td>
                                    <input id="Email" name="Email" type="text" class="easyui-validatebox" validtype="email" />
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">所属省份:
                                </td>
                                <td>
                                    <select id="Province" name="Province" style="width: 125px;" class="easyui-combobox">
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">所属城市:
                                </td>
                                <td>
                                    <select id="City" name="City" style="width: 125px;" class="easyui-combobox">
                                    </select>
                                </td>
                            </tr>
                            <%--区县预留 onchange="LoadCounty();--%>
                            <%--<tr>
                                <td class="lbl-caption">所属区/县:
                                </td>
                                <td>
                                    <select id="County" name="county" style="width: 100%;"  >
                                        <option id='chooseCounty' value='-1'>请选择区/县</option>
                                    </select>                                  
                                </td>
                            </tr>--%>
                            <tr>
                                <td class="lbl-caption">详细地址:
                                </td>
                                <td colspan="3">
                                    <input name="Address" type="text" class="easyui-validatebox"
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
                            <tr>
                                <td class="lbl-caption">拆单账号:
                                </td>
                                <td style="width: 120px;">
                                    <input id="CompanyCode" name="CompanyCode" type="text" class="easyui-validatebox"
                                        maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">是否禁用:
                                </td>
                                <td>
                                    <select id="Status" name="Status" style="width: 43%;" class="easyui-combobox">
                                        <option value="S">是</option>
                                        <option value="N">否</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">排序:
                                </td>
                                <td colspan="3">
                                    <input name="Sort" type="text"
                                        maxlength="20" style="width: 20%;" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
