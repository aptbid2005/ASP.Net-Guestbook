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

partial class Admin_Login : BusinessLayer
{
	private SiteSettings b;

	protected void Page_Load(object sender, System.EventArgs e)
	{
		b = (SiteSettings)Cache["SiteSettings"];
		// Set focus on the username textbox
		inUserName.Focus();

		if (!Page.IsPostBack)
		{
			// if site is in demo mode then pre-populate the textboxes
			if (b.DemoMode == true)
			{
				this.inUserName.Text = "Admin";
				this.inPassword.Attributes.Add("value", "Admin");
			}
		}
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
	protected void btnLogin_Click(object sender, System.EventArgs e)
	{
		// Check user input
		if (CheckUserInput() == true)
		{

			string UserID = "";

			// Encrypt password
			string EncPass = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(inPassword.Text.Trim()));

			DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
			// Validate against database
			UserID = data.AuthenticateUser(inUserName.Text.Trim(), EncPass);

			if (data.SQLError != null)
			{
				lblerror.Text = data.SQLError.Message;
				return;
			}

			if (UserID.Length > 0)
			{
				// Redirect to requested page
				FormsAuthentication.RedirectFromLoginPage(UserID, false);
			}
			else
			{
				// User Login error so display the error to the user
				Alert("Please check your user name and / or password.");
			}

		}
	}

	private bool CheckUserInput()
	{
		bool tempCheckUserInput = false;
		tempCheckUserInput = true;
		string str = "";

		if (!(inUserName.Text.Length > 0))
		{
			str = "You must enter a user name.\\n";
			tempCheckUserInput = false;
		}

		if (!(inPassword.Text.Length > 0))
		{
			str += "You must enter a password.\\n";
			tempCheckUserInput = false;
		}

		if (str.Length > 0)
		{
			Alert(str);
		}

		return tempCheckUserInput;
	}


	override protected void OnInit(EventArgs e)
	{
//INSTANT C# NOTE: Converted event handler wireups:
		this.Load += Page_Load;
		btnLogin.Click += btnLogin_Click;

		base.OnInit(e);
	}
}
