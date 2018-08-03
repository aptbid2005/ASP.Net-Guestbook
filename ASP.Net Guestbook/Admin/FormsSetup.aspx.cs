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

partial class Admin_FormsSetup : System.Web.UI.Page
{
	private SiteSettings b;

	protected void Page_Load(object sender, System.EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			b = (SiteSettings)Cache["SiteSettings"];
			LoadSettings();
		}
	}

	private void LoadSettings()
	{

		chkFullName.Checked = b.RequireFullName;
		chkCountry.Checked = b.RequireCountry;
		chkState.Checked = b.RequireState;
		chkEmail.Checked = b.RequireEmail;
		chkHomePage.Checked = b.RequireHomepage;
		chkGuestbook.Checked = b.RequireGuestbook;
		chkGender.Checked = b.RequireGender;
		chkMessage.Checked = b.RequireMessage;

		chkDisplayFullName.Checked = b.DisplayFullName;
		chkDisplayCountry.Checked = b.DisplayCountry;
		chkDisplayState.Checked = b.DisplayState;
		chkDisplayEmail.Checked = b.DisplayEmail;
		chkDisplayHomePage.Checked = b.DisplayHomepage;
		chkDisplayGuestbook.Checked = b.DisplayGuestbook;
		chkDisplayGender.Checked = b.DisplayGender;
		chkDisplayMessage.Checked = b.DisplayMessage;

	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
	protected void btnSave_Click(object sender, System.EventArgs e)
	{
		if (b.DemoMode == false)
		{
			SiteSettings ss = b;

			ss.RequireFullName = chkFullName.Checked;
			ss.RequireCountry = chkCountry.Checked;
			ss.RequireState = chkState.Checked;
			ss.RequireEmail = chkEmail.Checked;
			ss.RequireHomepage = chkHomePage.Checked;
			ss.RequireGuestbook = chkGuestbook.Checked;
			ss.RequireGender = chkGender.Checked;
			ss.RequireMessage = chkMessage.Checked;

			ss.DisplayFullName = chkDisplayFullName.Checked;
			ss.DisplayCountry = chkDisplayCountry.Checked;
			ss.DisplayState = chkDisplayState.Checked;
			ss.DisplayEmail = chkDisplayEmail.Checked;
			ss.DisplayHomepage = chkDisplayHomePage.Checked;
			ss.DisplayGuestbook = chkDisplayGuestbook.Checked;
			ss.DisplayGender = chkDisplayGender.Checked;
			ss.DisplayMessage = chkDisplayMessage.Checked;

			DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
			if (data.UpdatingSiteSettings(ss) == true)
			{
				lblMessage.Text = "Settings Saved";
			}
			else
			{
				lblerror.Text = "Error while saving settings";
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