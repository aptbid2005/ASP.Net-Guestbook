<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="false" Inherits="Admin_Analytics" Title="Visitor Tracking - Analytics" Codebehind="Analytics.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <span class="HeaderText">Visitor Tracking Code</span>
    <hr />
    <div>
        <div style="float: left; padding-right: 5px;">
            <img src="Help.gif" alt="Help" />
        </div>
        In this section you can copy and paste any code that you may use for tracking visitors
        to your website. This can be Google analytics, Statcounter or any other analytic
        software service that you may use.</div>
    <br />
    <div style="text-align: center">
        <asp:Label runat="server" ID="lblerror" CssClass="ErrorMessage" />
        <asp:Label ID="lblsuccess" runat="server" CssClass="SuccessMessage"></asp:Label></div>
    <div style="text-align: center;">
        <table cellpadding="5" cellspacing="1" border="0">
            <tr>
                <td class="GridHeader" align="left">
                    <b>Visitor Tracking Code:</b>
                </td>
            </tr>
            <tr>
                <td class="GridAlternatingRow">
                    <asp:TextBox runat="server" ID="inCode" TextMode="multiLine" Rows="10" Columns="75" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;<asp:LinkButton runat="server" ID="lnkSaveCode" Text="Save Code" CssClass="PreviewButton" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>