<%@ Page Language="C#" AutoEventWireup="false" Inherits="Admin_Login" Codebehind="Login.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signin</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <br />
        <fieldset style="margin: 0 auto; width: 350px;" class="Content">
            <span class="HeaderText">Login</span><div class="hr"><hr /></div>
            <div style="text-align: center;">
                <asp:Label runat="server" ID="lblerror" CssClass="ErrorMessage" />
            </div>
            <table cellpadding="5" width="100%">
                <tr>
                    <td align="center">
                        <asp:Panel runat="server" ID="pnl1" DefaultButton="btnLogin">
                            <table cellpadding="5" cellspacing="1" border="0" style="width: 273px">
                                <tr>
                                    <td class="GridHeader" align="right">
                                        User Name:
                                    </td>
                                    <td class="GridAlternatingRow" align="left">
                                        <asp:TextBox ID="inUserName" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="GridHeader" align="right">
                                        Password:
                                    </td>
                                    <td class="GridAlternatingRow" align="left">
                                        <asp:TextBox ID="inPassword" TextMode="Password" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right">
                                        <asp:LinkButton runat="server" ID="btnLogin" CssClass="PreviewButton" Text="Signin" />
                                        <a href="../GuestBook.aspx" class="PreviewButton">Cancel</a>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </fieldset>
    </form>
</body>
</html>