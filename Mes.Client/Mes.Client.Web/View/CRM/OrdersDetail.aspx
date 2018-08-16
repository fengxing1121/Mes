<%@ Page Title="订单详情" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrdersDetail.aspx.cs" Inherits="Mes.Client.Web.View.CRM.OrdersDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../../Script/forms/crm/jquery.forms.ordersdetail.js"></script>
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
                background: #ff6a00;
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

        input[readonly] {
            border: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="订单详情" region="north" border="false" style="height: 200px; width: 100%; overflow: hidden;">
        <div style="width: 100%">
            <form id="search_form">
                <div>
                    <input type="hidden" id="OrderID" name="OrderID" />
                </div>
                <table style="width: 100%; height: 50px;">
                    <tr>
                        <td style="width: 80px; text-align: right;">订单编号:</td>
                        <td>
                            <input type="text" id="OrderNo" name="OrderNo" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">订单类型:</td>
                        <td>
                            <input id="OrderType" type="text" name="OrderType" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">订单状态:</td>
                        <td>
                            <input type="text" id="Status" name="Status" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">报价单号:</td>
                        <td>
                            <input type="text" id="PurchaseNo" name="PurchaseNo" style="width: 100%;" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right;">产品类型:
                        </td>
                        <td>
                            <input type="text" id="CabinetType" name="CabinetType" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">是否正标:
                        </td>
                        <td>
                            <input type="text" id="IsStandard" name="IsStandard" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">是否外购:
                        </td>
                        <td>
                            <input type="text" id="IsOutsourcing" name="IsOutsourcing" style="width: 100%;" />
                        </td>
                        <td style="width: 80px; text-align: right;">开始生产:
                        </td>
                        <td>
                            <input type="text" id="ManufactureDate" name="ManufactureDate" style="width: 100%;" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; text-align: right;">客户名称:
                        </td>
                        <td>
                            <input type="text" id="CustomerName" name="CustomerName" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">联系电话:
                        </td>
                        <td>
                            <input type="text" id="Mobile" name="Mobile" style="width: 100%;" />
                        </td>
                        <td style="width: 80px; text-align: right;">客户地址:
                        </td>
                        <td colspan="4">
                            <input type="text" id="Address" name="Address" style="width: 100%;" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; text-align: right;">联系人:
                        </td>
                        <td>
                            <input type="text" id="LinkMan" name="LinkMan" style="width: 100%;" />
                        </td>
                        <td style="width: 80px; text-align: right;">订货日期:
                        </td>
                        <td>
                            <input type="text" id="BookingDate" name="BookingDate" style="width: 100%;" />
                        </td>
                        <td style="width: 80px; text-align: right;">交货日期:
                        </td>
                        <td>
                            <input type="text" id="ShipDate" name="ShipDate" style="width: 100%;" />
                        </td>
                        <td style="width: 80px; text-align: right;">创建时间:
                        </td>
                        <td>
                            <input type="text" id="Created" name="Created" style="width: 100%;" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; text-align: right;">备注:
                        </td>
                        <td colspan="3">
                            <textarea id="Remark" name="Remark" cols="4" rows="4" style="width: 100%; height: 50px;"></textarea>
                        </td>
                        <td style="width: 100px; text-align: right;">外部单号:
                        </td>
                        <td>
                            <input type="text" id="OutOrderNo" name="OutOrderNo" style="width: 100%;" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
</asp:Content>
