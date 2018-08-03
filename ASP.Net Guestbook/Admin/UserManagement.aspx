<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" Inherits="Admin_UserManagement" Title="User Management" Codebehind="UserManagement.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <span class="HeaderText">User Management</span>
            <hr />
        <div>
            <div style="float: left; padding-right: 5px;">
                <img src="Help.gif" alt="Help" />
            </div>
            Users added to this section will be able to administer the site and make any changes
            they deem necessary. Be Selective.
        </div>
        <br />
        <table cellpadding="5" cellspacing="1" border="0" width="100%">
            <tr>
                <td align="left">
                    <asp:Label runat="server" ID="lblSort">Click a column header to resort list</asp:Label>
                </td>
                <td align="right">
                    <a href="javascript:window.open('user_edit.aspx',null,'height=200,width=350,toolbars=no,addressbar=no,resizable=yes');void('');"
                        class="PreviewButton">Add New User</a>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label runat="server" ID="lblerror" CssClass="ErrorMessage" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:GridView runat="server" ID="GridView1" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" DataKeyNames="ID,Guid"
                        GridLines="None" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                SortExpression="ID" Visible="False" />
                            <asp:BoundField DataField="Guid" HeaderText="Guid" SortExpression="Guid" Visible="False" />
                            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password"
                                Visible="False" />
                            <asp:CommandField SelectText="Forgot Password" ShowSelectButton="True">
                                <ControlStyle CssClass="PreviewButton" />
                            </asp:CommandField>
                            <asp:CommandField ShowEditButton="True">
                                <ControlStyle CssClass="PreviewButton" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemStyle HorizontalAlign="Center" Width="65px" />
                                <ItemTemplate>
                                    <asp:LinkButton CssClass="PreviewButton" Text="Delete" runat="server" ID="btnDelete"
                                        CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this user?');void('');" />
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