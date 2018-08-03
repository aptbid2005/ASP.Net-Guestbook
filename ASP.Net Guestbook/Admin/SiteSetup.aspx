<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" Inherits="Admin_SiteSetup" Title="Settings" Codebehind="SiteSetup.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <span class="HeaderText">Site Setup</span>
    <hr />
    <div>
        <div style="float: left; padding-right: 5px;">
            <img src="Help.gif" alt="Help" />
        </div>
        All these settings are crutial for the site to work properly. Please know exactly
        what you are doing before making any changes.
    </div>
    <br />
    <div style="text-align: center">
        <asp:Label runat="server" ID="lblMessage" CssClass="SuccessMessage" />
        <asp:Label runat="server" ID="lblerror" CssClass="ErrorMessage" />
    </div>
    <div style="text-align: center">
        <table cellpadding="5" cellspacing="1" border="0" width="100%">
            <tr>
                <td class="GridHeader" style="text-align: right">
                    <strong>Setting:</strong>
                </td>
                <td class="GridAlternatingRow" style="text-align: left">
                    <strong>Value:</strong>
                </td>
                <td class="GridAlternatingRow" style="text-align: left">
                    <strong>Help:</strong>
                </td>
            </tr>
            <tr>
                <td class="GridHeader" style="text-align: right;" valign="top">
                    Site Title:
                </td>
                <td class="GridAlternatingRow" style="text-align: left;" valign="top">
                    <asp:TextBox runat="server" ID="inSiteTitle" Columns="50" />
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <ul>
                        <li>The Title of the site</li></ul>
                </td>
            </tr>
            <tr>
                <td class="GridHeader" style="text-align: right;" valign="top">
                    Guest Book Page Title:
                </td>
                <td class="GridAlternatingRow" style="text-align: left;" valign="top">
                    <asp:TextBox runat="server" ID="inGuestBookTitle" Columns="50" />
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <ul>
                        <li>Title on the Guest book page</li></ul>
                </td>
            </tr>
            <tr>
                <td class="GridHeader" style="text-align: right;" valign="top">
                    Meta Keywords:
                </td>
                <td class="GridAlternatingRow" style="text-align: left;" valign="top">
                    <asp:TextBox runat="server" ID="inKeywords" Columns="35" Rows="2" TextMode="MultiLine" />
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <ul>
                        <li>Adds keywords to the HTML for search engines to use for searches</li></ul>
                </td>
            </tr>
            <tr>
                <td class="GridHeader" style="text-align: right;" valign="top">
                    Meta Description:
                </td>
                <td class="GridAlternatingRow" style="text-align: left;" valign="top">
                    <asp:TextBox runat="server" ID="inDescription" Columns="35" Rows="2" TextMode="MultiLine" />
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <ul>
                        <li>Adds a description to the HTML for search engines to use for listings</li></ul>
                </td>
            </tr>
            <tr>
                <td class="GridHeader" style="text-align: right;" valign="top">
                    Guest Book row count:
                </td>
                <td class="GridAlternatingRow" style="text-align: left;" valign="top">
                    <asp:TextBox runat="server" ID="inGridSize" Columns="2" />
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <ul>
                        <li>The amount of rows to display on the guest book before another page is added.</li></ul>
                </td>
            </tr>
            <tr>
                <td class="GridHeader" style="text-align: right" valign="top">
                    Admin Email:
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <asp:TextBox runat="server" ID="inAdminEmail" Columns="45" />
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <ul>
                        <li>Admin Email to send messages to for various items</li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td class="GridHeader" style="text-align: right" valign="top">
                    Mail Server:
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <asp:TextBox runat="server" ID="inMailServer" Columns="45" />
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <ul>
                        <li>The mail server address for sending mail</li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td class="GridHeader" style="text-align: right;" valign="top">
                    Demo Mode:
                </td>
                <td class="GridAlternatingRow" style="text-align: left;" valign="top">
                    <asp:CheckBox runat="server" ID="chkDemoMode" />
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <ul>
                        <li>If checked site will be in demo mode</li></ul>
                </td>
            </tr>
            <tr>
                <td class="GridHeader" style="text-align: right" valign="top">
                    Show Powered By:
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <asp:CheckBox ID="chkPoweredBy" runat="server" />
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <ul>
                        <li>Show the Powered by The Professional Developer at the bottom of the site</li></ul>
                </td>
            </tr>
            <tr>
                <td class="GridHeader" style="text-align: right" valign="top">
                    Require Post Approval:
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <asp:CheckBox ID="chkRequireApproval" runat="server" />
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <ul>
                        <li>Requires Post to be approved by an admin before going live on the site.</li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td class="GridHeader" style="text-align: right" valign="top">
                    Send Email With New Post:
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <asp:CheckBox ID="chkSendEmail" runat="server" />
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <ul>
                        <li>Sends and email to the admin email with every new post</li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td class="GridHeader" style="text-align: right;" valign="top">
                    Track Errors:
                </td>
                <td class="GridAlternatingRow" style="text-align: left;" valign="top">
                    <asp:CheckBox ID="chkTrackErrors" runat="server" />
                </td>
                <td class="GridAlternatingRow" style="text-align: left">
                    <ul>
                        <li>If Checked, Error messages will be sent to The Professional Developer</li>
                        <li>Any errors will be fixed and a new release sent to our customers.</li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td class="GridHeader" style="text-align: right" valign="top">
                    Language Filter:
                </td>
                <td class="GridAlternatingRow" style="text-align: left" valign="top">
                    <asp:RadioButtonList runat="server" ID="rblFilter" RepeatDirection="horizontal">
                        <asp:ListItem Text="Loose" Value="Loose" />
                        <asp:ListItem Text="Strict" Value="Strict" />
                    </asp:RadioButtonList>
                </td>
                <td class="GridAlternatingRow" style="text-align: left">
                    <ul>
                        <li><strong>Strict</strong> = No word is allowed even if part of another word</li>
                        <li><strong>Loose</strong> = No word is allowed as a stand alone word</li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td class="GridHeader" style="text-align: right">
                </td>
                <td class="GridAlternatingRow" style="text-align: left">
                    <asp:LinkButton ID="btnSave" runat="server" CssClass="PreviewButton" OnClientClick="return confirm('Are you sure you want to save your changes?');void('');"
                        Text="Save" />
                    <asp:LinkButton ID="btnCancel" runat="server" CssClass="PreviewButton">Cancel</asp:LinkButton>
                </td>
                <td class="GridAlternatingRow" style="text-align: left">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>