<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportsView.aspx.cs" Inherits="Mes.Client.Web.View.Reports.reportsView" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>报表预览</title>
    <link href="/Script/easyui/themes/default/easyui.css" rel="stylesheet" />  
    <script src="/Script/easyui/jquery.min.js"></script>
    <script src="/Script/easyui/jquery.easyui.min.js"></script>    
</head>
<body class="easyui-layout">
    <div region="center" style="border: 0px; overflow-y: scroll;" border="false">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="rptView" runat="server" Height="100%" ProcessingMode="Remote" ShowDocumentMapButton="False" DocumentMapCollapsed="True" SizeToReportContent="true">
                <ServerReport Timeout="60000"></ServerReport>
            </rsweb:ReportViewer>
        </form>
    </div>
</body>
</html>
