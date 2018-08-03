<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" Inherits="Posts" Title="Post Moderation" Codebehind="Posts.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <span class="HeaderText">Post Moderation</span>
            <hr />
        <div>
            <div style="float: left; padding-right: 5px;">
                <img src="Help.gif" alt="Help" />
            </div>
            In this section you will be able to manage posts from users.</div>
        <br />
        <table cellpadding="5" cellspacing="1" width="100%">
            <tr align="center">
                <td align="right" style="width: 50%">
                    Show me all posts that have a status of:
                </td>
                <td align="left" style="width: 50%">
                    <asp:RadioButtonList runat="server" ID="rblStatus" RepeatDirection="Horizontal" AutoPostBack="True">
                        <asp:ListItem Selected="True" Text="Inactive" Value="False"></asp:ListItem>
                        <asp:ListItem Text="Active" Value="True"></asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
        </table>
        <table cellpadding="5" cellspacing="1" width="100%">
            <tr>
                <td align="center">
                    <asp:GridView runat="server" ID="GridView1" AllowPaging="True" AutoGenerateColumns="False"
                        CellPadding="5" CellSpacing="1" DataKeyNames="ID" GridLines="None" Width="100%"
                        ShowHeader="False">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                SortExpression="ID" Visible="False" />
                            <asp:TemplateField>
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <table cellpadding="7" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td align="left" valign="top" style="width: 225px;">
                                                <b>Full Name: </b>
												<%#Eval("FullName")%>
                                                <br />
                                                <b>Country: </b>
												<%#Eval("Country")%>
                                                <br />
                                                <b>State: </b>
												<%#Eval("State")%>
                                                <br />
                                                <b>IP Address:</b>
												<%#Eval("IPAddress")%>
                                                <br />
                                                <b>Email:</b>
												<%#Eval("Email")%>
                                                <br />
                                                <b>Homepage URL:</b>
												<%#Eval("HomepageURL")%>
                                                <br />
                                                <b>Guestbook URL:</b>
												<%#Eval("GuestbookURL")%>
                                                <br />
                                                <b>Gender:</b>
												<%#Eval("Gender")%>
                                                <br />
                                                <b>Date:</b>
												<%#string.Format("{0:d}", Eval("SubmissionDate"))%>
                                            </td>
                                            <td align="left" valign="top" style="width: 450px;">
												<%#Eval("Message")%>
                                            </td>
                                            <td align="right" valign="top" style="width: 65px;">
												<a href="javascript:window.open('Post_Edit.aspx?id=<%#Eval("ID")%>',null,'height=560,width=560,toolbars=no,resizable=yes');void('');"
                                                    class="PreviewButton">Edit</a><br />
                                                <br />
                                                <asp:LinkButton runat="server" ID="btnDelete" CommandName="Delete" CssClass="PreviewButton"
                                                    Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this post?');void('');" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="hr">
                                        <hr />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GridAlternatingRow" />
                        <PagerStyle HorizontalAlign="Right" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
</asp:Content>