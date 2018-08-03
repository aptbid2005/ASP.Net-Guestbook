//INSTANT C# NOTE: Formerly VB web.config imports:
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

partial class Admin_LanguageFile : System.Web.UI.Page
{
	private SiteSettings b;
	private LanguageFile lang;

	protected void Page_Load(object sender, System.EventArgs e)
	{
		b = (SiteSettings)Cache["SiteSettings"];

		lblerror.Text = "";
		lblsuccess.Text = "";
		if (!Page.IsPostBack)
		{
			lang = (LanguageFile)Cache["LanguageFile"];

			this.inBacktoGuestbook.Text = lang.BacktoGuestbook;
			this.inBadLanguage.Text = lang.BadLanguage;
			this.inBlockedIP.Text = lang.BlockedIP;
			this.inBoldFields.Text = lang.Boldfield;
			this.inCancel.Text = lang.Cancel;
			this.inCompleteForm.Text = lang.CompleteThisForm;
			this.inCountry.Text = lang.Country;
			this.inEmail.Text = lang.Email;
			this.inEnterEmailAddress.Text = lang.EnterEmailAddress;
			this.inEnterFullName.Text = lang.EnterFullName;
			this.inEnterGuestbook.Text = lang.EnterGuestbook;
			this.inEnterHomepage.Text = lang.EnterHomepage;
			this.inEnterMessage.Text = lang.EnterMessage;
			this.inEnterNos.Text = lang.EnterNosHere;
			this.inEnterVerificationText.Text = lang.EnterVerificationImage;
			this.inFemale.Text = lang.Female;
			this.inFullName.Text = lang.FullName;
			this.inGuestbook.Text = lang.Guestbook;
			this.inGender.Text = lang.Gender;
			this.inHomepage.Text = lang.Homepage;
			this.inInvalidVerification.Text = lang.VerificationDidNotMatch;
			this.inMale.Text = lang.Male;
			this.inMessage.Text = lang.Message;
			this.inSelectCountry.Text = lang.SelectCountry;
			this.inSelectState.Text = lang.SelectState;
			this.inSignBook.Text = lang.SignOurGuestbook;
			this.inState.Text = lang.State;
			this.inSubmissionDate.Text = lang.SubmissionDate;
			this.inSubmissionMessage.Text = lang.SubmissionMessage;
			this.inSubmit.Text = lang.Submit;
			this.inUnspecified.Text = lang.Unspecified;
			this.inValidEmail.Text = lang.ValidEmailAddress;
			this.inValidGuestbook.Text = lang.ValidGuestbookURL;
			this.inValidHomepage.Text = lang.ValidHomepageURL;
			this.inVerificationImage.Text = lang.VerificationImage;
			this.inYourGuestbook.Text = lang.YourGuestbook;
			this.inYourHomepage.Text = lang.YourHomepage;

		}
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub btnSaveChanges_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveChanges.Click
	protected void btnSaveChanges_Click(object sender, System.EventArgs e)
	{
		if (b.DemoMode == false)
		{
			LanguageFile b = new LanguageFile();
			b.BacktoGuestbook = this.inBacktoGuestbook.Text;
			b.BadLanguage = this.inBadLanguage.Text;
			b.BlockedIP = this.inBlockedIP.Text;
			b.Boldfield = this.inBoldFields.Text;
			b.Cancel = this.inCancel.Text;
			b.CompleteThisForm = this.inCompleteForm.Text;
			b.Country = this.inCountry.Text;
			b.Email = this.inEmail.Text;
			b.EnterEmailAddress = this.inEnterEmailAddress.Text;
			b.EnterFullName = this.inEnterFullName.Text;
			b.EnterGuestbook = this.inEnterGuestbook.Text;
			b.EnterHomepage = this.inEnterHomepage.Text;
			b.EnterMessage = this.inEnterMessage.Text;
			b.EnterNosHere = this.inEnterNos.Text;
			b.EnterVerificationImage = this.inEnterVerificationText.Text;
			b.Female = this.inFemale.Text;
			b.FullName = this.inFullName.Text;
			b.Guestbook = this.inGuestbook.Text;
			b.Gender = this.inGender.Text;
			b.Homepage = this.inHomepage.Text;
			b.VerificationDidNotMatch = this.inInvalidVerification.Text;
			b.Male = this.inMale.Text;
			b.Message = this.inMessage.Text;
			b.SelectCountry = this.inSelectCountry.Text;
			b.SelectState = this.inSelectState.Text;
			b.SignOurGuestbook = this.inSignBook.Text;
			b.State = this.inState.Text;
			b.SubmissionDate = this.inSubmissionDate.Text;
			b.SubmissionMessage = this.inSubmissionMessage.Text;
			b.Submit = this.inSubmit.Text;
			b.Unspecified = this.inUnspecified.Text;
			b.ValidEmailAddress = this.inValidEmail.Text;
			b.ValidGuestbookURL = this.inValidGuestbook.Text;
			b.ValidHomepageURL = this.inValidHomepage.Text;
			b.VerificationImage = this.inVerificationImage.Text;
			b.YourGuestbook = this.inYourGuestbook.Text;
			b.YourHomepage = this.inYourHomepage.Text;

			DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
			if (data.UpdateLanguageFile(b) == true)
			{
				Cache["LanguageFile"] = b;
				Response.Redirect("LanguageFile.aspx");
			}
			else
			{
				lblerror.Text = "Error while updating lanaguage file.";
			}
		}
		else
		{
			lblerror.Text = "You are not allowed to change these settings in demo mode.";
		}
	}


	override protected void OnInit(EventArgs e)
	{
//INSTANT C# NOTE: Converted event handler wireups:
		this.Load += Page_Load;
		btnSaveChanges.Click += btnSaveChanges_Click;

		base.OnInit(e);
	}
}
