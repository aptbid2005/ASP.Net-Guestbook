<%@ Page Language="C#" AutoEventWireup="false" Inherits="Admin_IPAddress_new" Codebehind="IPAddress_new.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New IP Address</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body class="PopUps">
    <form id="form1" runat="server">
        <table border="0" cellpadding="5" cellspacing="1" style="width: 100%">
            <tr>
                <td align="right" class="GridHeader">
                    IP Address:</td>
                <td class="GridAlternatingRow">
                    <asp:TextBox ID="inIPAddress" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="inIPAddress"
                        ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" class="GridAlternatingRow" colspan="2">
                    <asp:LinkButton ID="btnSaveAdd" runat="server" CssClass="PreviewButton">Save Add More</asp:LinkButton>
                    <asp:LinkButton ID="btnSaveClose" runat="server" CssClass="PreviewButton">Save and Close</asp:LinkButton></td>
            </tr>
        </table>
    </form>
</body>
</html>