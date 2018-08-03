<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" Inherits="Admin_HeaderAndFooter" Title="Header & Footer" CodeBehind="HeaderAndFooter.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <span class="HeaderText">Header and Footer</span>
    <hr />
    <div>
        <div style="float: left; padding-right: 5px;">
            <img src="Help.gif" alt="Help" />
        </div>
        In this section you can copy and paste HTML or Javascript in to the appropriate
            box so that this main site will have either a header or a footer.
    </div>
    <br />
    <div style="text-align: center">
        <asp:Label runat="server" ID="lblerror" CssClass="ErrorMessage" />
    </div>
    <div style="text-align: center;">
        <table cellpadding="5" cellspacing="1" border="0">
            <tr>
                <td class="GridHeader" align="left">
                    <b>Header:</b>
                </td>
            </tr>
            <tr>
                <td class="GridAlternatingRow">
                    <asp:Literal runat="server" ID="litHeader" />
                </td>
            </tr>
            <tr>
                <td class="GridAlternatingRow">
                    <asp:TextBox runat="server" ID="inHeader" TextMode="multiLine" Rows="10" Columns="75" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton runat="server" ID="lnkHeaderPreview" Text="Preview Header" CssClass="PreviewButton" OnClick="lnkHeaderPreview_Click" />
                    <asp:LinkButton runat="server" ID="lnkHeaderSave" Text="Save Header" CssClass="PreviewButton" OnClick="lnkHeaderSave_Click"
                        OnClientClick="return confirm('Are you sure you want to save the Header information?');void(0);" />
                </td>
            </tr>
            <tr>
                <td>
                    <div class="hr">
                        <hr />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="GridHeader" align="left">
                    <b>Footer:</b>
                </td>
            </tr>
            <tr>
                <td class="GridAlternatingRow">
                    <asp:Literal runat="server" ID="litFooter" />
                </td>
            </tr>
            <tr>
                <td class="GridAlternatingRow">
                    <asp:TextBox runat="server" ID="inFooter" TextMode="multiLine" Rows="10" Columns="75" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton runat="server" ID="lnkFooterPreview" Text="Preview Footer" CssClass="PreviewButton" OnClick="lnkFooterPreview_Click" />
                    <asp:LinkButton runat="server" ID="lnkFooterSave" Text="Save Footer" CssClass="PreviewButton" OnClick="lnkFooterSave_Click"
                        OnClientClick="return confirm('Are you sure you want to save the Footer information?');void(0);" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
