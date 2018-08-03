<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" Inherits="Admin_BadLanguageEditor" Title="Bad Language Editor" Codebehind="BadLanguageEditor.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <span class="HeaderText">Bad Language Editor</span>
        <hr />
    <div>
        <div style="float: left; padding-right: 5px;">
            <img src="Help.gif" alt="Help" />
        </div>
        Add as many words to the list to filter them out of posts. You will also need to
        choose a 'Loose' or 'Strict' search pattern on the 'Site Setup' page.
    </div>
    <br />
    <table cellpadding="5" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="left">
                <asp:Label runat="server" ID="lblSort" Text="Click column header to resort list" />
            </td>
            <td align="right">
                <a href="javascript:window.open('BadLanguageEditor_Manage.aspx',null,'height=75,width=350,toolbars=no,addressbar=no,resizable=yes');void('');"
                    class="PreviewButton">Add New Word</a>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" DataKeyNames="ID"
                    GridLines="None" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                            SortExpression="ID" Visible="False" />
                        <asp:BoundField DataField="ExcludeWord" HeaderText="Exclude Word" SortExpression="ExcludeWord">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:CommandField ShowEditButton="True">
                            <ItemStyle Width="100px" />
                            <ControlStyle CssClass="PreviewButton" />
                        </asp:CommandField>
                        <asp:TemplateField>
                            <HeaderStyle Width="65px" />
                            <ItemStyle Width="65px" />
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandName="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete this word?');void('');"
                                    CssClass="PreviewButton" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GridAlternatingRow" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>