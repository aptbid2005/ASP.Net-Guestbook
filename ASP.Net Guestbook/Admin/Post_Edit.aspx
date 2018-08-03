<%@ Page Language="C#" AutoEventWireup="false" Inherits="Admin_Post_Edit" Codebehind="Post_Edit.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Post Edit</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body class="PopUps">
    <form id="form1" runat="server">
        <table cellpadding="5" cellspacing="1" border="0" width="100%">
            <tr>
                <td align="right" class="GridHeader">
                    Full Name</td>
                <td class="GridAlternatingRow">
                    <asp:TextBox ID="inFullName" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" class="GridHeader">
                    Country
                </td>
                <td class="GridAlternatingRow">
                    <asp:DropDownList ID="lstCountry" runat="server">
                        <asp:ListItem Selected="True" Value="0">Please select your country</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="GridHeader">
                    State</td>
                <td class="GridAlternatingRow">
                    <asp:DropDownList ID="lstState" runat="server">
                        <asp:ListItem Selected="True" Value="0">Please select your state</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="GridHeader">
                    IP Address</td>
                <td class="GridAlternatingRow">
                    <asp:TextBox ID="inIPAddress" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" class="GridHeader">
                    Email</td>
                <td class="GridAlternatingRow">
                    <asp:TextBox ID="inEmail" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" class="GridHeader">
                    Homepage URL</td>
                <td class="GridAlternatingRow">
                    <asp:TextBox ID="inHomepage" runat="server" Columns="50" /></td>
            </tr>
            <tr>
                <td align="right" class="GridHeader">
                    Guestbook URL</td>
                <td class="GridAlternatingRow">
                    <asp:TextBox ID="inGuestbook" runat="server" Columns="50" /></td>
            </tr>
            <tr>
                <td align="right" class="GridHeader" valign="top">
                    Message</td>
                <td class="GridAlternatingRow">
                    <asp:TextBox runat="server" ID="inMessage" Columns="50" Rows="10" TextMode="MultiLine" /></td>
            </tr>
            <tr>
                <td align="right" class="GridHeader">
                    Submission Date</td>
                <td class="GridAlternatingRow">
                    <asp:TextBox ID="inDate" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" class="GridHeader">
                    Gender</td>
                <td class="GridAlternatingRow">
                    <asp:TextBox ID="inGender" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" class="GridHeader">
                    Approved</td>
                <td class="GridAlternatingRow">
                    <asp:CheckBox ID="chkApproved" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2" align="right" class="GridAlternatingRow">
                    <asp:LinkButton ID="btnSave" runat="server" CssClass="PreviewButton">Save and Close</asp:LinkButton></td>
            </tr>
        </table>
    </form>
</body>
</html>