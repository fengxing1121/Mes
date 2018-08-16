<%@ Page Title="入库详情" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WarehouseInDetail.aspx.cs" Inherits="Mes.Client.Web.View.Management.WareHouse.WarehouseInDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
        <style>
        #content ul li {
            float: left;
            list-style: none;
            margin: 5px;
        }

        #content .item ul li > a:hover {
            background: #eaf2ff;
            color: #000000;
        }

        #div_content ul li {
            float: left;
            list-style: none;
            margin-left: 5px;
        }

            #div_content ul li:hover {
                background: #fbf8e9;
                color: #000000;
                -o-transition: all 0.1s ease-in-out;
                -webkit-transition: all 0.1s ease-in-out;
                -moz-transition: all 0.1s ease-in-out;
                -ms-transition: all 0.1s ease-in-out;
                transition: all 0.1s ease-in-out;
                cursor: pointer;
            }

        #div_content .active {
            background: #ff6a00;
        }

        #div_content .item {
            width: 120px;
            height: 22px;
            float: left;
            border: 1px solid #eee;
            line-height: 22px;
            text-align: center;
        }
    </style>
     <script src="/Script/forms/stock/jquery.forms.warehouse_in_detail.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="入库详情" region="north" border="false" style="height: 175px; width: 100%; overflow: hidden;" collapsible="false">
        <div style="width: 100%">
            <form id="search_form">
                <div>
                    <input type="hidden" id="InID" name="InID" />
                    <%--<input type="hidden" id="CabinetNum" name="CabinetNum" />--%>
                </div>
                <table style="width: 100%; height: 50px;">
                    <tr>
                        <td style="width: 80px; text-align: right;">入库单号:
                        </td>
                        <td>
                            <input type="text" id="BillNo" name="BillNo" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">批次号：
                        </td>
                        <td>
                            <input id="BattchNo" type="text" name="BattchNo" style="width: 100%;" />
                        </td>
                        <td style="width: 80px; text-align: right;">入库日期:
                        </td>
                        <td>
                            <input type="text" id="CheckInDate" name="CheckInDate" style="width: 100%;" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; text-align: right;">供应商名称:
                        </td>
                        <td>
                            <input type="text" id="SupplierID" name="SupplierName" style="width: 100%;" />
                        </td>

                        <td style="width: 80px; text-align: right;">经手人:
                        </td>
                        <td>
                            <input type="text" id="HandlerMan" name="HandlerMan" style="width: 100%;" />
                        </td>
                    </tr>
                    <tr>

                        <td class="lbl-caption">备注:
                        </td>
                        <td colspan="5">
                            <textarea  id="Remark" name="Remark" cols="5" rows="5" style="width: 100%; height:80px;"></textarea>
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <div region="center" border="false" ">
        <div class="easyui-layout" fit="true">

            <div region="center" border="false">
                <div class="easyui-tabs" fit="true" border="false" id="tt" style="padding: 5px;">
                    <div title="入库明细" fit="true" border="false">
                        <table id="dgdetail">
                        </table>
                    </div>                   
                </div>
            </div>
        </div>
    </div>

</asp:Content>
