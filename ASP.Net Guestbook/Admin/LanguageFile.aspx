<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" Inherits="Admin_LanguageFile" Title="Language File" Codebehind="LanguageFile.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <span class="HeaderText">Language File</span>
    <hr />
     <div>
        <div style="float: left; padding-right: 5px;">
            <img src="Help.gif" alt="Help" />
        </div>
        With the language file you will be able to set the text on the Guestbook in your own language.
    </div>
    <br />
    <asp:Label ID="lblerror" runat="server" CssClass="ErrorMessage"></asp:Label>
    <asp:Label ID="lblsuccess" runat="server" CssClass="SuccessMessage"></asp:Label><br />
    <table border="0" cellpadding="5" cellspacing="1" style="width: 100%">
        <tr>
            <td class="GridHeader">
                English (Default)</td>
            <td class="GridHeader">
                Your Languge Equivalant</td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Your Guestbook</td>
            <td>
                <asp:TextBox ID="inYourGuestbook" runat="server" Columns="45" MaxLength="45"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Your Homepage</td>
            <td>
                <asp:TextBox ID="inYourHomepage" runat="server" Columns="45" MaxLength="45"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Email</td>
            <td>
                <asp:TextBox ID="inEmail" runat="server" Columns="25" MaxLength="25"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Sign Our Guestbook</td>
            <td>
                <asp:TextBox ID="inSignBook" runat="server" Columns="50" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Verification Image</td>
            <td>
                <asp:TextBox ID="inVerificationImage" runat="server" Columns="45" 
                    MaxLength="45" ></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Submission Date</td>
            <td>
                <asp:TextBox ID="inSubmissionDate" runat="server" Columns="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Homepage</td>
            <td>
                <asp:TextBox ID="inHomepage" runat="server" Columns="25" MaxLength="25"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Guestbook</td>
            <td>
                <asp:TextBox ID="inGuestbook" runat="server" Columns="25" MaxLength="25"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Full Name</td>
            <td>
                <asp:TextBox ID="inFullName" runat="server" Columns="25" MaxLength="25"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Country</td>
            <td>
                <asp:TextBox ID="inCountry" runat="server" Columns="20" MaxLength="20"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                State</td>
            <td>
                <asp:TextBox ID="inState" runat="server" Columns="15" MaxLength="15"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Message</td>
            <td>
                <asp:TextBox ID="inMessage" runat="server" Columns="25" MaxLength="25"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Gender</td>
            <td>
                <asp:TextBox ID="inGender" runat="server" Columns="15" MaxLength="15"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Male</td>
            <td>
                <asp:TextBox ID="inMale" runat="server" Columns="10" MaxLength="10"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Female</td>
            <td>
                <asp:TextBox ID="inFemale" runat="server" Columns="15" MaxLength="15"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Unspecified</td>
            <td>
                <asp:TextBox ID="inUnspecified" runat="server" Columns="20" MaxLength="20"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Enter #'s Here</td>
            <td>
                <asp:TextBox ID="inEnterNos" runat="server" Columns="30" MaxLength="30"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Enter the characters as shown in the image to the left to complete this form</td>
            <td>
                <asp:TextBox ID="inCompleteForm" runat="server" Columns="75" MaxLength="80"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Back to Guestbook</td>
            <td>
                <asp:TextBox ID="inBacktoGuestbook" runat="server" Columns="40" MaxLength="40"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Bold denotes required field</td>
            <td>
                <asp:TextBox ID="inBoldFields" runat="server" Columns="50" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Please enter your Full Name</td>
            <td>
                <asp:TextBox ID="inEnterFullName" runat="server" Columns="50" MaxLength="50" ></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Please enter your Email Address</td>
            <td>
                <asp:TextBox ID="inEnterEmailAddress" runat="server" Columns="50" 
                    MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Please enter a message</td>
            <td>
                <asp:TextBox ID="inEnterMessage" runat="server" Columns="50" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                You must enter the verification image text</td>
            <td>
                <asp:TextBox ID="inEnterVerificationText" runat="server" Columns="50" 
                    MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Please enter a valid email address</td>
            <td>
                <asp:TextBox ID="inValidEmail" runat="server" Columns="50" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Your verification number did not match</td>
            <td>
                <asp:TextBox ID="inInvalidVerification" runat="server" Columns="50" 
                    MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Cancel</td>
            <td>
                <asp:TextBox ID="inCancel" runat="server" Columns="10" MaxLength="10"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Submit</td>
            <td>
                <asp:TextBox ID="inSubmit" runat="server" Columns="10" MaxLength="10"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Sorry, but your IP address has been blocked from posting to this Guestbook</td>
            <td>
                <asp:TextBox ID="inBlockedIP" runat="server" Columns="75" MaxLength="75"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Thank you for your submission. An administrator must approve your post before it 
                will appear on this site</td>
            <td>
                <asp:TextBox ID="inSubmissionMessage" runat="server" Columns="75" 
                    MaxLength="150" ></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Your post contains language that is not allowed. Please correct and try again</td>
            <td>
                <asp:TextBox ID="inBadLanguage" runat="server" Columns="80" MaxLength="80"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Please select your Country</td>
            <td>
                <asp:TextBox ID="inSelectCountry" runat="server" Columns="40" MaxLength="40"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Please select your State</td>
            <td>
                <asp:TextBox ID="inSelectState" runat="server" Columns="40" MaxLength="40"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Please enter your Homepage</td>
            <td>
                <asp:TextBox ID="inEnterHomepage" runat="server" Columns="40" MaxLength="40"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Please enter your Guestbook</td>
            <td>
                <asp:TextBox ID="inEnterGuestbook" runat="server" Columns="40" MaxLength="40"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Please enter a valid Homepage URL</td>
            <td>
                <asp:TextBox ID="inValidHomepage" runat="server" Columns="40" MaxLength="40"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="GridAlternatingRow">
                Please enter a valid Guestbook URL</td>
            <td>
                <asp:TextBox ID="inValidGuestbook" runat="server" Columns="40" MaxLength="40"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:LinkButton ID="btnSaveChanges" runat="server" CssClass="PreviewButton">Save Changes</asp:LinkButton></td>
        </tr>
    </table>
</asp:Content>