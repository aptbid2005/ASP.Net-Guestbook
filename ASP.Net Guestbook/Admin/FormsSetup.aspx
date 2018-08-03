<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" Inherits="Admin_FormsSetup" Title="Forms Setup" Codebehind="FormsSetup.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <span class="HeaderText">Forms Setup</span>
            <hr />
        <div>
            <div style="float: left; padding-right: 5px;">
                <img src="Help.gif" alt="Help" />
            </div>
        </div>
        <div>
            This page will enable you to customize your forms allowing you to collect/show only the
            information you want from/to your visitors. Items will only display on the homepage if a value is provided.
        </div>
        <br />
        <div style="text-align: center">
            <asp:Label runat="server" ID="lblMessage" />
            <asp:Label runat="server" ID="lblerror" CssClass="ErrorMessage" />
        </div>
        <div style="text-align: center">
            <table cellpadding="5" cellspacing="1" border="0">
                <tr>
                    <td class="GridHeader" style="text-align: right">
                        <strong>Form Field:</strong></td>
                    <td class="GridAlternatingRow" style="text-align: left">
                        <strong>Required on Sign book page:</strong></td>
                    <td class="GridAlternatingRow" style="text-align: left">
                        <strong>Displayed on homepage:</strong></td>
                </tr>
                <tr>
                    <td class="GridHeader" style="text-align: right; height: 30px;" valign="top">
                        Full Name:
                    </td>
                    <td class="GridAlternatingRow" style="text-align: left; height: 30px;" valign="top">
                        <asp:CheckBox runat="server" ID="chkFullName" />
                    </td>
                    <td class="GridAlternatingRow" style="text-align: left; height: 30px;" valign="top">
                        <asp:CheckBox runat="server" ID="chkDisplayFullName" /></td>
                </tr>
                <tr>
                    <td class="GridHeader" style="text-align: right;" valign="top">
                        Country:
                    </td>
                    <td class="GridAlternatingRow" style="text-align: left;" valign="top">
                        <asp:CheckBox runat="server" ID="chkCountry" />
                    </td>
                    <td class="GridAlternatingRow" style="text-align: left" valign="top">
                        <asp:CheckBox runat="server" ID="chkDisplayCountry" /></td>
                </tr>
                <tr>
                    <td class="GridHeader" style="text-align: right" valign="top">
                        State:</td>
                    <td class="GridAlternatingRow" style="text-align: left" valign="top">
                        <asp:CheckBox ID="chkState" runat="server" /></td>
                    <td class="GridAlternatingRow" style="text-align: left" valign="top">
                        <asp:CheckBox runat="server" ID="chkDisplayState" /></td>
                </tr>
                <tr>
                    <td class="GridHeader" style="text-align: right" valign="top">
                        Email:</td>
                    <td class="GridAlternatingRow" style="text-align: left" valign="top">
                        <asp:CheckBox ID="chkEmail" runat="server" /></td>
                    <td class="GridAlternatingRow" style="text-align: left" valign="top">
                        <asp:CheckBox runat="server" ID="chkDisplayEmail" /></td>
                </tr>
                <tr>
                    <td class="GridHeader" style="text-align: right" valign="top">
                        Home Page:</td>
                    <td class="GridAlternatingRow" style="text-align: left" valign="top">
                        <asp:CheckBox ID="chkHomePage" runat="server" /></td>
                    <td class="GridAlternatingRow" style="text-align: left" valign="top">
                        <asp:CheckBox runat="server" ID="chkDisplayHomePage" /></td>
                </tr>
                <tr>
                    <td class="GridHeader" style="text-align: right;" valign="top">
                        Guestbook:</td>
                    <td class="GridAlternatingRow" style="text-align: left;" valign="top">
                        <asp:CheckBox ID="chkGuestbook" runat="server" />
                    </td>
                    <td class="GridAlternatingRow" style="text-align: left" valign="top">
                        <asp:CheckBox runat="server" ID="chkDisplayGuestbook" /></td>
                </tr>
                <tr>
                    <td class="GridHeader" style="text-align: right" valign="top">
                        Gender:</td>
                    <td class="GridAlternatingRow" style="text-align: left" valign="top">
                        <asp:CheckBox ID="chkGender" runat="server" /></td>
                    <td class="GridAlternatingRow" style="text-align: left" valign="top">
                        <asp:CheckBox runat="server" ID="chkDisplayGender" /></td>
                </tr>
                <tr>
                    <td class="GridHeader" style="text-align: right" valign="top">
                        Message:</td>
                    <td class="GridAlternatingRow" style="text-align: left" valign="top"><asp:CheckBox ID="chkMessage" runat="server" /></td>
                    <td class="GridAlternatingRow" style="text-align: left" valign="top">
                        <asp:CheckBox runat="server" ID="chkDisplayMessage" /></td>
                </tr>
                <tr>
                    <td class="GridHeader" style="text-align: right">
                    </td>
                    <td class="GridAlternatingRow" style="text-align: left" colspan="2">
                        <asp:LinkButton ID="btnSave" runat="server" CssClass="PreviewButton" OnClientClick="return confirm('Are you sure you want to save your changes?');void('');"
                            Text="Save" />
                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="PreviewButton">Cancel</asp:LinkButton></td>
                </tr>
            </table>
        </div>
</asp:Content>