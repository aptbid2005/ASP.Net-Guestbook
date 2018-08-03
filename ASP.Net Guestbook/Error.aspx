<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" Inherits="_Error" Codebehind="Error.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset>
        <span class="HeaderText">Error</span><div class="hr">
            <hr />
        </div>
        <a href="Default.aspx" class="PreviewButton">Back to Guestbook</a>
        <br /> <br />
        <div>
            We're sorry but we have encountered an unexpected error. An error report has been
            generated and sent to the development team for correction. Thank you for your patience
            and we appologize for any inconvenience this may have caused you.
            <br />
            <br />
            Some issues may be resolved by cleaning out your cookies and refreshing your browser.</div>
    </fieldset>
</asp:Content>