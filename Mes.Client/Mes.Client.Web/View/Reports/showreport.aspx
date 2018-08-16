<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showreport.aspx.cs" Inherits="Mes.Client.Web.View.Reports.showreport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Script/easyui/themes/default/easyui.css" rel="stylesheet" />  
    <script src="/Script/easyui/jquery.min.js"></script>
    <script src="/Script/easyui/jquery.easyui.min.js"></script>    
</head>
<body class="easyui-layout">
    <div region="center"  style="text-align: center; overflow-y: scroll;">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="rptView" runat="server"
                Width="100%" Height="100%" ProcessingMode="Remote" ShowDocumentMapButton="False" DocumentMapCollapsed="True" SizeToReportContent="true">
                <ServerReport Timeout="60000"></ServerReport>
            </rsweb:ReportViewer>
        </form>
    </div>
</body>
</html>
