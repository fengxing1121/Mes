<%@ Page Title="产品报价" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuoteSet.aspx.cs" Inherits="Mes.Client.Web.View.CRM.QuoteSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../../Script/forms/crm/jquery.forms.quote.js"></script>
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
                                <td class="lbl-caption">客户名称:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px" id="CustomerName" name="CustomerName" type="text" />
                                </td>

                                <td class="lbl-caption">方案编号:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="SolutionCode" name="SolutionCode" type="text" />
                                </td>
                                <td class="lbl-caption">方案名称:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="SolutionName" name="SolutionName" type="text" />
                                </td>
                                <td class="lbl-caption">报价单号:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="QuoteNo" name="QuoteNo" type="text" />
                                </td>
                                <td style="text-align: left">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search" style="width: 80px;">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
