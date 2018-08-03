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

partial class Admin_SiteSetup : System.Web.UI.Page
{
	private SiteSettings b;

	protected void Page_Load(object sender, System.EventArgs e)
	{
		lblerror.Text = "";
		lblMessage.Text = "";

		if (!Page.IsPostBack)
		{
			b = (SiteSettings)Cache["SiteSettings"];
			LoadSettings();
		}
	}

	private void LoadSettings()
	{
		inDescription.Text = b.MetaDescription;
		inGridSize.Text = b.GuestbookGridSize.ToString();
		inGuestBookTitle.Text = b.GuestBookTitle;
		inKeywords.Text = b.MetaKeywords;
		inSiteTitle.Text = b.SiteTitle;
		inAdminEmail.Text = b.AdminEmail;
		inMailServer.Text = b.MailServer;
		chkDemoMode.Checked = b.DemoMode;
		chkPoweredBy.Checked = b.ShowPoweredBy;
		chkRequireApproval.Checked = b.RequireApproval;
		chkSendEmail.Checked = b.SendEmailWithNewPost;
		chkTrackErrors.Checked = b.EnableErrorTracking;
		rblFilter.SelectedValue = b.LanguageFilter;
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
	protected void btnSave_Click(object sender, System.EventArgs e)
	{
		if (b.DemoMode == false)
		{

			b.MetaDescription = inDescription.Text;
			b.GuestbookGridSize = Convert.ToInt16(inGridSize.Text);
			b.GuestBookTitle = inGuestBookTitle.Text;
			b.MetaKeywords = inKeywords.Text;
			b.SiteTitle = inSiteTitle.Text;
			b.AdminEmail = inAdminEmail.Text;
			b.MailServer = inMailServer.Text;
			b.DemoMode = chkDemoMode.Checked;
			b.ShowPoweredBy = chkPoweredBy.Checked;
			b.RequireApproval = chkRequireApproval.Checked;
			b.SendEmailWithNewPost = chkSendEmail.Checked;
			b.EnableErrorTracking = chkTrackErrors.Checked;
			b.LanguageFilter = rblFilter.SelectedValue;

			DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
			if (data.UpdatingSiteSettings(b) == true)
			{
				Cache["SiteSettings"] = b;
				lblMessage.Text = "Your settings have been saved";
			}
			else
			{
				lblerror.Text = "An error occured while saving your settings";
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
		btnSave.Click += btnSave_Click;

		base.OnInit(e);
	}
}