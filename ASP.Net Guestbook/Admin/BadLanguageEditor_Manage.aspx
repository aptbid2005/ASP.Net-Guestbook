<%@ Page Language="C#" AutoEventWireup="false"
    Inherits="Admin_BadLanguageEditor_Manage" Codebehind="BadLanguageEditor_Manage.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Bad Language</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body class="PopUps">
    <form id="form1" runat="server">
        <table cellpadding="5" cellspacing="1" border="0" width="100%">
            <tr>
                <td class="GridHeader" align="right">
                    Bad Word:</td>
                <td class="GridAlternatingRow" align="left">
                    <asp:TextBox runat="server" ID="inBadWord" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="inBadWord"
                        Display="Dynamic" ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="right" class="GridAlternatingRow" >
                    <asp:LinkButton runat="server" ID="btnSave" Text="Save and Close" CssClass="PreviewButton" />
                    <asp:LinkButton runat="server" ID="btnSaveAndMore" Text="Save Add More" CssClass="PreviewButton" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>