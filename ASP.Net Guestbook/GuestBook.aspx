<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" Inherits="GuestBook" Codebehind="GuestBook.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function SendUserEmail(ID,D) 
			{ 
                document.location.href = "mailto:" + ID + "@" + D; 
			}
    </script>

    <fieldset>
        <asp:Label runat="server" ID="lblBookTitle" CssClass="HeaderText" />
        <div class="hr">
            <hr />
        </div>
        <table cellpadding="5" cellspacing="0" border="0" width="100%">
            <tr>
                <td align="right">
                    <asp:hyperlink runat="server" ID="lnkSignBook" navigateurl="~/Signbook.aspx" cssclass="PreviewButton" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label runat="server" ID="lblError" CssClass="ErrorMessage" />
                    <asp:Label runat="server" ID="lblStats" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="ID" GridLines="None" ShowHeader="False" CssClass="GuestBookList"
                        CellPadding="5" CellSpacing="1">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td align="left" valign="top" style="width: 50%">
												<%#GetSubmissionDate(System.Convert.ToDateTime(Eval("SubmissionDate")))%>
                                                <br />
												<%#GetUserInfo(System.Convert.ToString(Eval("FullName")), System.Convert.ToString(Eval("CountryName")), System.Convert.ToString(Eval("StateName")), System.Convert.ToString(Eval("Gender")))%>
                                            </td>
                                            <td align="right" valign="top" style="width: 50%">
												<%#GetWebInfo(System.Convert.ToString(Eval("HomepageURL")), System.Convert.ToString(Eval("GuestBookURL")), System.Convert.ToString(Eval("Email")))%>
                                            </td>
                                        </tr>
                                    </table>
									<%#GetMessage(System.Convert.ToString(Eval("Message")))%>
                                    <br />
                                    <div class="hr">
                                        <hr />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" />
                        <AlternatingRowStyle CssClass="GridAlternatingRow" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>