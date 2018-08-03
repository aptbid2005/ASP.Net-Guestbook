//INSTANT C# NOTE: Formerly VB web.config imports:
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

using System.Data;
using System;

partial class SignBook : BusinessLayer
{
	private SiteSettings b;
	private LanguageFile Lang;

	protected void Page_Load(object sender, EventArgs e)
	{
		// Load Site Settings
		b = (SiteSettings)Cache["SiteSettings"];

		// Load Language File
		Lang = (LanguageFile)Cache["LanguageFile"];

		lblError.Text = "";
		lblSuccess.Text = "";

		if (User.Identity.IsAuthenticated == true)
		{
			trDate.Visible = true;
			inSubDate.Text = DateTime.Now.ToShortDateString();
		}
		else
		{
			trDate.Visible = false;
		}

		SetRequiredFields();

		// Check to see if this user is on the blocked IP List
		DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();

		if (data.CheckForBlockedIP(Request.UserHostAddress) == true)
		{
			// Users IP has been blocked so disable form
			btnSubmit.Visible = false;
			Alert(Lang.BlockedIP);
		}

		if (!Page.IsPostBack)
		{
			rblGender.Items.Add(new ListItem(Lang.Male, Lang.Male));
			rblGender.Items.Add(new ListItem(Lang.Female, Lang.Female));
			rblGender.Items.Add(new ListItem(Lang.Unspecified, Lang.Unspecified));

			LoadCountries();
			LoadStates();

			lblSignOurGuestbook.Text = Lang.SignOurGuestbook;
			lnkBackToGuestbook.Text = Lang.BacktoGuestbook;
			lblBoldField.Text = "*" + Lang.Boldfield;
			lblFullname.Text = Lang.FullName;
			lblCountry.Text = Lang.Country;
			lblState.Text = Lang.State;
			lblEmail.Text = Lang.Email;
			lblHomepage.Text = Lang.Homepage;
			lblGuestbook.Text = Lang.Guestbook;
			lblGender.Text = Lang.Gender;
			lblMessage.Text = Lang.Message;
			lblSubmissionDate.Text = Lang.SubmissionDate;
			lblVerificationImage.Text = Lang.VerificationImage;
			lblFormError.Text = Lang.CompleteThisForm;
			btnCancel.Text = Lang.Cancel;
			btnSubmit.Text = Lang.Submit;

		}

	}

	private void LoadCountries()
	{
		DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
		lstCountries.DataTextField = "Name";
		lstCountries.DataValueField = "ID";
		lstCountries.DataSource = data.GetCountries();
		lstCountries.DataBind();
	}

	private void LoadStates()
	{
		DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
		lstStates.DataTextField = "Name";
		lstStates.DataValueField = "ID";
		lstStates.DataSource = data.GetStates();
		lstStates.DataBind();
	}

	private void SetRequiredFields()
	{
		// Check if Require FullName is enabled
		if (b.RequireFullName == true)
		{
			// change font-weight
			lblFullname.Font.Bold = true;
		}
		else
		{
			// change font-weight
			lblFullname.Font.Bold = false;
		}

		// Check if Require Country is enabled
		if (b.RequireCountry == true)
		{
			// change font-weight
			lblCountry.Font.Bold = true;
		}
		else
		{
			// change font-weight
			lblCountry.Font.Bold = false;
		}

		// Check if Require State is enabled
		if (b.RequireState == true)
		{
			// change font-weight
			lblState.Font.Bold = true;
		}
		else
		{
			// change font-weight
			lblState.Font.Bold = false;
		}

		// Check if Require Email is enabled
		if (b.RequireEmail == true)
		{
			// change font-weight
			lblEmail.Font.Bold = true;
		}
		else
		{
			// change font-weight
			lblEmail.Font.Bold = false;
		}

		// Check if Require Homepage is enabled
		if (b.RequireHomepage == true)
		{
			// change font-weight
			lblHomepage.Font.Bold = true;
		}
		else
		{
			// change font-weight
			lblHomepage.Font.Bold = false;
		}

		// Check if Require Guestbook is enabled
		if (b.RequireGuestbook == true)
		{
			// change font-weight
			lblGuestbook.Font.Bold = true;
		}
		else
		{
			// change font-weight
			lblGuestbook.Font.Bold = false;
		}

		// Check if Require Gender is enabled
		if (b.RequireGender == true)
		{
			// change font-weight
			lblGender.Font.Bold = true;
		}
		else
		{
			// change font-weight
			lblGender.Font.Bold = false;
		}

		// Check if Require message is enabled
		if (b.RequireMessage == true)
		{
			// change font-weight
			lblMessage.Font.Bold = true;
		}
		else
		{
			// change font-weight
			lblMessage.Font.Bold = false;
		}

	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		// I check all my forms manaully because a user can have 
		// javascript turned off and bypass .Net Validation controls
		if (CheckPage() == true)
		{
			// Check if Require Message is Turned on
			bool Required = false;

			// If admin allows posts to pass through without checking first
			if (b.RequireApproval == true)
			{
				Required = true;
			}

			string HomePage = "";
			string GuestBookPage = "";

			// Check to see if the user entered a homepage url
			if (inHomePage.Text.Length > 7)
			{
				HomePage = inHomePage.Text.Trim();
			}

			// Check to see if the user entered a guestbook url
			if (inGuestbookURL.Text.Length > 7)
			{
				GuestBookPage = inGuestbookURL.Text.Trim();
			}

			bool Approved = false;
			// Have to do some reverse logic for post approval based on require approval
			if (Required == false)
			{
				Approved = true;
			}

			// Remove single quote to prevent script injection
			string Message = inMessage.Content.Trim;
			Message = Message.Replace("'", "");

			DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
			// Insert new record into the database
			data.InsertNewGuestbookEntry(inFullName.Text.Trim(), Convert.ToInt32(lstCountries.SelectedValue), Convert.ToInt32(lstStates.SelectedValue), Request.UserHostAddress, inEmail.Text.Trim(), HomePage, GuestBookPage, rblGender.SelectedValue, Message, DateTime.Now, Approved);

			if (data.SQLError == null)
			{

				if (b.SendEmailWithNewPost == true)
				{
					SendEmailToAdmin();
				}

				// Check if posts require admin approval
				if (Required == false)
				{

					// Invalidate Guestbook cache so new entry will show up in Guestbook
					Cache.Remove("dsGuestbook");

					// Send back to Guestbook page
					Response.Redirect("GuestBook.aspx");
				}
				else
				{
					// Post need approval so display to user so they don't get confused.
					lblSuccess.Text = string.Format("<ul><li>{0}</li></ul>", Lang.SubmissionMessage);
					ClearForm();
				}
			}
			else
			{
				// Something happened so let the user know.
				DisplayError(data.SQLError.Message);
			}
		}

	}

	private void ClearForm()
	{
		this.inEmail.Text = "";
		this.inFullName.Text = "";
		this.inGuestbookURL.Text = "";
		this.inHomePage.Text = "";
		this.inMessage.Content = "";
		this.lstCountries.SelectedIndex = 0;
		this.lstStates.SelectedIndex = 0;
		this.rblGender.SelectedIndex = 2;
		this.inVerify.Text = "";
	}

	private void SendEmailToAdmin()
	{
		try
		{
			using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(b.MailServer))
			{
				smtp.Send(b.AdminEmail, b.AdminEmail, "Someone has submitted to your guestbook", "Someone has submitted to your guestbook.");
			}
		}
		catch (Exception ex)
		{

		}
	}

	private bool CheckPage()
	{
		bool tempCheckPage = false;
		tempCheckPage = true;
		DataTable dtinfo = null;
		string Words = "";
		StringBuilder sb = new StringBuilder();

		// Get bad words from the database
		DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
		dtinfo = data.GetBadWords();

		// Loop through the bad words and construct the RegEx expression
		foreach (DataRow dr in dtinfo.Rows)
		{
			if (b.LanguageFilter == "Strict")
			{
				Words += Convert.ToString(dr[1].ToString() + "|");
			}
			else
			{
				Words += string.Format(" {0} |", dr[1]);
			}
		}

		// Add a space to the beginning and end of message to be able to search first and last word
		string Message = string.Format(" {0} ", inMessage.Content.Trim);

		// Check for match against regex expression
		if (Regex.IsMatch(Message, Words.TrimEnd('|')) == true)
		{
			sb.Append("<li>");
			sb.Append(Lang.BadLanguage);
			sb.Append("</li>");
			tempCheckPage = false;
		}

		if (b.RequireFullName == true)
		{
			// Check the full Name
			if (inFullName.Text.Trim().Length == 0)
			{
				sb.Append("<li>");
				sb.Append(Lang.EnterFullName);
				sb.Append("</li>");
				tempCheckPage = false;
			}
		}

		if (b.RequireCountry == true)
		{
			if (!(lstCountries.SelectedIndex > 0))
			{
				sb.Append("<li>");
				sb.Append(Lang.SelectCountry);
				sb.Append("</li>");
				tempCheckPage = false;
			}
		}

		if (b.RequireState == true)
		{
			if (!(lstStates.SelectedIndex > 0))
			{
				sb.Append("<li>");
				sb.Append(Lang.SelectState);
				sb.Append("</li>");
				tempCheckPage = false;
			}
		}

		if (b.RequireEmail)
		{
			// Check the Email if provided
			if (inEmail.Text.Trim().Length > 0)
			{
				// Check to make sure the email address entered is valid
				if (Regex.IsMatch(inEmail.Text.Trim(), "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*") == false)
				{
					sb.Append("<li>");
					sb.Append(Lang.ValidEmailAddress);
					sb.Append("</li>");
					tempCheckPage = false;
				}
			}
			else
			{
				sb.Append("<li>");
				sb.Append(Lang.EnterEmailAddress);
				sb.Append("</li>");
			}
		}

		if (b.RequireHomepage == true)
		{
			if (!(this.inHomePage.Text.Trim().Length > 7))
			{
				sb.Append("<li>");
				sb.Append(Lang.EnterHomepage);
				sb.Append("</li>");
				tempCheckPage = false;
			}
		}

		if (b.RequireGuestbook == true)
		{
			if (!(this.inGuestbookURL.Text.Trim().Length > 7))
			{
				sb.Append("<li>");
				sb.Append(Lang.EnterGuestbook);
				sb.Append("</li>");
				tempCheckPage = false;
			}
		}

		// Check to see if user entered a homepage 
		if (this.inHomePage.Text.Trim().Length > 7)
		{
			// check to make sure the homepage entered is a valid url
			if (Regex.IsMatch(inHomePage.Text.Trim(), "http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?") == false)
			{
				sb.Append("<li>");
				sb.Append(Lang.ValidHomepageURL);
				sb.Append("</li>");
				tempCheckPage = false;
			}
		}

		// Check to see if the user entered a guestbook
		if (this.inGuestbookURL.Text.Length > 7)
		{
			// check to make sure the guestbook entered is a valid url
			if (Regex.IsMatch(inGuestbookURL.Text.Trim(), "http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?") == false)
			{
				sb.Append("<li>");
				sb.Append(Lang.ValidGuestbookURL);
				sb.Append("</li>");
				tempCheckPage = false;
			}
		}

		// check to make sure a message is provided if admin requires messages with posts
		if (b.RequireMessage == true)
		{
			if (inMessage.Content.Trim.Length == 0)
			{
				sb.Append("<li>");
				sb.Append(Lang.EnterMessage);
				sb.Append("</li>");
				tempCheckPage = false;
			}
		}

		// Make sure the user provided the Verification Number
		if (inVerify.Text.Trim().Length == 0)
		{
			sb.Append("<li>");
			sb.Append(Lang.EnterVerificationImage);
			sb.Append("</li>");
			tempCheckPage = false;
		}
		else
		{
			// Make sure that the number provided is in fact the number in the image
			if (!(string.Compare(inVerify.Text.Trim(), Session["NewID"].ToString()) == 0))
			{
				sb.Append("<li>");
				sb.Append(Lang.VerificationDidNotMatch);
				sb.Append("</li>");
				tempCheckPage = false;
			}
		}

		// Check to see if there was any errors and if so display out to the user
		if (sb.ToString().Trim().Length > 0)
		{
			lblError.Text = string.Format("<ul>{0}</ul>", sb.ToString());
		}

		return tempCheckPage;
	}


	override protected void OnInit(EventArgs e)
	{
//INSTANT C# NOTE: Converted event handler wireups:
		this.Load += Page_Load;
		btnSubmit.Click += btnSubmit_Click;

		base.OnInit(e);
	}
}