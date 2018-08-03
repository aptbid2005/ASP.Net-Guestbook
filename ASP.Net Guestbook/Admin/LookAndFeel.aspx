<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" Inherits="Admin_LookAndFeel" Title="Look and Feel" Codebehind="LookAndFeel.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <span class="HeaderText">Look & Feel</span>
    <hr />
    <div>
        <div style="float: left; padding-right: 5px;">
            <img src="Help.gif" alt="Help" />
        </div>
        Here you will be able to change the look and feel of the Guestbooks. Feel
        free to experiment, if you don't like it just click Start Over, this will return
        you back to the default look and feel.
    </div>
    <br />
    <table cellpadding="5" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center">
                <asp:Label runat="server" ID="lblerror" CssClass="ErrorMessage" />
                <asp:Label runat="server" ID="lblsuccess" CssClass="SuccessMessage" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <b class="ErrorMessage">Any changes that are made in this section will effect the look
                    and feel of your web site.</b>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox runat="server" ID="inCSS" Width="98%" Rows="50" TextMode="multiLine" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton runat="server" ID="btnSave" Text="Save" CssClass="PreviewButton"
                    OnClientClick="return confirm('Are you sure you want to save your work? \nYou may need to refresh your browser afterwards to see the changes.');void('');" />
                <asp:LinkButton runat="server" ID="btnCancel" Text="Cancel" CssClass="PreviewButton" />
                <asp:LinkButton ID="btnRevert" runat="server" CssClass="PreviewButton" Text="Start Over"
                    OnClientClick="return confirm('Are you sure you want to start over? \nYou may need to refresh your browser afterwards to see the changes.');void('');" />
            </td>
        </tr>
    </table>
</asp:Content>