<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" Inherits="Admin_IPFilter" Title="IP Filter" Codebehind="IPFilter.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <span class="HeaderText">IP Filter</span>
            <hr />
        <div>
            <div style="float: left; padding-right: 5px;">
                <img src="Help.gif" alt="Help" />
            </div>
            Add as many IP addresses to the list to prevent people from posting to your site.
        </div>
        <br />
        <table cellpadding="5" cellspacing="0" border="0" width="100%">
            <tr>
                <td align="right">
                    <a href="javascript:window.open('IPAddress_new.aspx',null,'width=350,height=60,resizable=yes,toolbars=no,addressbar=no');void('');" class="PreviewButton">Add New IP Address</a>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label runat="server" ID="lblError" CssClass="ErrorMessage" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView runat="server" ID="GridView1" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" DataKeyNames="ID"
                        GridLines="None" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                SortExpression="ID" Visible="False" />
                            <asp:BoundField DataField="IPAddress" HeaderText="IPAddress" SortExpression="IPAddress">
                                <ItemStyle HorizontalAlign="left" />
                                <HeaderStyle HorizontalAlign="left" />
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True">
                                <ItemStyle Width="95px" />
                                <ControlStyle CssClass="PreviewButton" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <HeaderStyle Width="65px" />
                                <ItemStyle Width="65px" />
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CssClass="PreviewButton"
                                        OnClientClick="return confirm('Are you sure you want to delete this IP address.');void('');"
                                        CommandName="Delete" />
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