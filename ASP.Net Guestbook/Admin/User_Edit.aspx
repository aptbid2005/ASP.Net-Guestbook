<%@ Page Language="C#" AutoEventWireup="false" Inherits="Admin_User_Edit" Codebehind="User_Edit.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit a User</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body class="PopUps">
    <form id="form1" runat="server">
        <table border="0" cellpadding="5" cellspacing="1" style="width: 100%">
            <tr>
                <td align="right" class="GridHeader">
                    Email Address:</td>
                <td align="left" class="GridAlternatingRow">
                    <asp:TextBox ID="inEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="inEmail"
                        ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="inEmail"
                        ErrorMessage="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        Display="Dynamic"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td align="right" class="GridHeader">
                    Full Name:</td>
                <td align="left" class="GridAlternatingRow">
                    <asp:TextBox ID="inFullName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="inFullName"
                        ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" class="GridHeader">
                    Password</td>
                <td align="left" class="GridAlternatingRow">
                    <asp:TextBox ID="inPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="GridHeader">
                    Retype Password:</td>
                <td align="left" class="GridAlternatingRow">
                    <asp:TextBox ID="inRePassword" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="inPassword"
                        ControlToValidate="inRePassword" ErrorMessage="Passwords Do Not Match" Display="Dynamic"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td align="right" colspan="2" class="GridAlternatingRow">
                    <asp:LinkButton ID="btnSaveAddMore" runat="server" CssClass="PreviewButton">Save Add More</asp:LinkButton>
                    <asp:LinkButton ID="btnSaveAndClose" runat="server" CssClass="PreviewButton">Save and Close</asp:LinkButton></td>
            </tr>
        </table>
    </form>
</body>
</html>