<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" Inherits="SignBook" Codebehind="SignBook.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset>
        <asp:Label runat="server" ID="lblSignOurGuestbook" CssClass="HeaderText" />
        <div class="hr">
            <hr />
        </div>
        <table cellpadding="5" width="100%">
            <tr>
                <td align="left">
                    <asp:hyperlink runat="server" ID="lnkBackToGuestbook" CssClass="PreviewButton" NavigateUrl="~/Guestbook.aspx" />
                </td>
                <td align="right">
                    <asp:Label runat="server" ID="lblBoldField" Font-Bold="true" />
                </td>
            </tr>
        </table>
        <div>
            <asp:Label runat="server" ID="lblError" CssClass="ErrorMessage" />
            <asp:Label runat="server" ID="lblSuccess" CssClass="SuccessMessage" />
        </div>
        <div>
            <table border="0" cellpadding="5" cellspacing="1" style="width: 100%">
                <tr>
                    <td align="right" class="GridHeader" valign="top" style="width: 150px;">
                        <asp:Label runat="server" ID="lblFullname"  />
                    </td>
                    <td class="GridAlternatingRow">
                        <asp:TextBox ID="inFullName" runat="server" Columns="35"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="GridHeader" valign="top" style="width: 150px;">
                        <asp:Label runat="server" ID="lblCountry"  />
                    </td>
                    <td class="GridAlternatingRow">
                        <asp:DropDownList ID="lstCountries" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="GridHeader" valign="top" style="width: 150px;">
                        <asp:Label runat="server" ID="lblState" />
                    </td>
                    <td class="GridAlternatingRow">
                        <asp:DropDownList ID="lstStates" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="GridHeader" valign="top" style="width: 150px;">
                        <asp:Label runat="server" ID="lblEmail"  />
                    </td>
                    <td class="GridAlternatingRow">
                        <asp:TextBox ID="inEmail" runat="server" Columns="45"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="GridHeader" valign="top" style="width: 150px;">
                        <asp:Label runat="server" ID="lblHomepage"  />
                    </td>
                    <td class="GridAlternatingRow">
                        <asp:TextBox ID="inHomePage" runat="server" Columns="50"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="inHomePage_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="inHomePage" WatermarkText="http://" WatermarkCssClass="WaterMark">
                        </cc1:TextBoxWatermarkExtender>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="GridHeader" valign="top" style="width: 150px;">
                        <asp:Label runat="server" ID="lblGuestbook" />
                    </td>
                    <td class="GridAlternatingRow">
                        <asp:TextBox ID="inGuestbookURL" runat="server" Columns="50"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="inGuestbookURL_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="inGuestbookURL" WatermarkText="http://" WatermarkCssClass="WaterMark">
                        </cc1:TextBoxWatermarkExtender>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="GridHeader" valign="top" style="width: 150px;">
                        <asp:Label runat="server" ID="lblGender" />
                    </td>
                    <td class="GridAlternatingRow">
                        <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" class="GridHeader" style="width: 150px;">
                        <asp:Label ID="lblMessage" runat="server" ></asp:Label>
                    </td>
                    <td class="GridAlternatingRow">
                        <cc2:Editor ID="inMessage" runat="server" Height="500px" />
                    </td>
                </tr>
                <tr id="trDate" runat="server">
                    <td align="right" class="GridHeader" valign="top" style="width: 150px;">
                        <asp:Label runat="server" ID="lblSubmissionDate" Font-Bold="true" /><br />
                    </td>
                    <td class="GridAlternatingRow">
                        <asp:TextBox runat="server" ID="inSubDate" />
                        <cc1:CalendarExtender ID="inSubDate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="inSubDate">
                        </cc1:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="GridHeader" valign="top" style="width: 150px;">
                        <asp:Label runat="server" ID="lblVerificationImage" Font-Bold="true" />
                        <br />
                        <asp:Image ID="imgVerify" runat="server" ImageUrl="image.aspx" AlternateText="Verify Image" />
                    </td>
                    <td class="GridAlternatingRow">
                        <asp:TextBox ID="inVerify" runat="server"></asp:TextBox><br />
                        <asp:Label runat="server" ID="lblFormError" CssClass="ErrorMessage" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" class="GridHeader" style="width: 150px;">
                    </td>
                    <td class="GridAlternatingRow" valign="top">
                        <asp:HyperLink runat="server" ID="btnCancel" CssClass="PreviewButton" NavigateUrl="~/Guestbook.aspx" />
                        <asp:LinkButton ID="btnSubmit" runat="server" CssClass="PreviewButton" />
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
</asp:Content>