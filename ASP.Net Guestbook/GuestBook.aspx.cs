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

partial class GuestBook : BusinessLayer
{
	private SiteSettings b;
	private LanguageFile Lang;

	protected void Page_Load(object sender, EventArgs e)
	{
		// Load Site Settings
		b = (SiteSettings)Cache["SiteSettings"];

		// Load Language File
		Lang = (LanguageFile)Cache["LanguageFile"];

		if (!Page.IsPostBack)
		{
			// Populate the grid with user entries
			LoadGrid();
		}

		lblBookTitle.Text = b.GuestBookTitle;
		GridView1.PageSize = b.GuestbookGridSize;
		lnkSignBook.Text = Lang.SignOurGuestbook;

	}

	private void LoadGrid()
	{
		DataTable dtinfo = null;

		// Get items from Guestbook
		DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
		dtinfo = data.GetGuestbookDataByApprovalType(true);

		if (data.SQLError == null)
		{

			if (dtinfo.Rows.Count > 0)
			{
				// Bind items to grid
				GridView1.DataSource = dtinfo;
				GridView1.DataBind();
			}
		}
		else
		{
			lblError.Text = data.SQLError.Message;
		}

	}

	public string GetMessage(string Message)
	{
		StringBuilder sb = new StringBuilder();
		if (b.DisplayMessage == true)
		{
			sb.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%\">");
			sb.Append("<tr><td align=\"left\" valign=\"top\" style=\"width: 100px;\"><b>");
			sb.Append(Lang.Message);
			sb.Append(": </b></td><td align=\"left\" valign=\"top\" style=\"width: 100%; padding-left: 10px;\">");
			sb.Append(Message);
			sb.Append("</td></tr></table>");
		}
		return sb.ToString();
	}

	public string GetWebInfo(string Homepage, string Guestbook, string email)
	{
		// Dynamically build User Webinfo for display to users
		StringBuilder sb = new StringBuilder();

		if (b.DisplayHomepage == true)
		{
			// Check to see if the user provided a homepage
			if (Homepage.Trim().Length > 0)
			{
				sb.Append("<img src=\"images/home.gif\" alt=\"");
				sb.Append(Lang.Homepage);
				sb.Append("\" /> <a href=\"");
				sb.Append(Homepage);
				sb.Append("\" target=\"_blank\">");
				sb.Append(Lang.Homepage);
				sb.Append("</a> &nbsp; ");
			}
		}

		if (b.DisplayGuestbook == true)
		{
			// Check to see if the user provided a Guestbook
			if (Guestbook.Trim().Length > 0)
			{
				sb.Append("<img src=\"images/Guestbook.gif\" alt=\"");
				sb.Append(Lang.Guestbook);
				sb.Append("\" /> <a href=\"");
				sb.Append(Guestbook);
				sb.Append("\" target=\"_blank\">");
				sb.Append(Lang.Guestbook);
				sb.Append("</a> &nbsp; ");
			}
		}

		if (b.DisplayEmail == true)
		{
			// Check to see if user provided email address
			if (email.Trim().Length > 0)
			{
				if (Regex.IsMatch(email, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*") == true)
				{
					string[] str = email.Split('@');
					sb.Append("<img src=\"images/Email.gif\" alt=\"");
					sb.Append(Lang.Email);
					sb.Append("\" /> <a href=\"javascript:SendUserEmail('");
					sb.Append(str[0]);
					sb.Append("','");
					sb.Append(str[1]);
					sb.Append("');\">");
					sb.Append(Lang.Email);
					sb.Append("</a>");
				}
			}
		}

		return sb.ToString();

	}

	public string GetUserInfo(string FullName, string Country, string State, string Gender)
	{
		StringBuilder sb = new StringBuilder();

		if (b.DisplayFullName == true)
		{
			// Check to see if the user provided a full name
			if (FullName.Trim().Length > 0)
			{
				sb.Append("<b>");
				sb.Append(Lang.FullName);
				sb.Append(":</b> ");
				sb.Append(FullName);
				sb.Append("<br />");
			}
		}

		if (b.DisplayCountry == true)
		{
			// Check to see if the user selected a country
			if (Country.Trim().Length > 0 && !(Country == "None"))
			{
				sb.Append("<b>");
				sb.Append(Lang.Country);
				sb.Append(":</b> ");
				sb.Append(Country);
				sb.Append("<br />");
			}
		}

		if (b.DisplayState == true)
		{
			// Check to see if the user selected a state
			if (State.Trim().Length > 0 && !(State == "None"))
			{
				sb.Append("<b>");
				sb.Append(Lang.State);
				sb.Append(":</b> ");
				sb.Append(State);
				sb.Append("<br />");
			}
		}

		if (b.DisplayGender == true)
		{
			// Check to see if the user selected a Gender
			sb.Append("<b>");
			sb.Append(Lang.Gender);
			sb.Append(":</b> ");
			sb.Append(Gender);
			sb.Append("<br />");
		}

		return sb.ToString();

	}

	public string GetSubmissionDate(DateTime subDate)
	{
		return string.Format("<b>{0}: </b>{1}", Lang.SubmissionDate, subDate);
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
	protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
	{
		// Change the current page of the grid
		GridView1.PageIndex = e.NewPageIndex;
		LoadGrid();
	}


	override protected void OnInit(EventArgs e)
	{
//INSTANT C# NOTE: Converted event handler wireups:
		this.Load += Page_Load;
		GridView1.PageIndexChanging += GridView1_PageIndexChanging;

		base.OnInit(e);
	}
}
