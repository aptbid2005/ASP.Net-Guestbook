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
using System.Data;

partial class Admin_Post_Edit : BusinessLayer
{
	private SiteSettings b;

	protected void Page_Load(object sender, System.EventArgs e)
	{
		b = (SiteSettings)Cache["SiteSettings"];
		if (!Page.IsPostBack)
		{
			LoadCountries();
			LoadStates();
			LoadDetails(Request.Params["ID"]);
		}
	}

	private void LoadCountries()
	{
		DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
		lstCountry.DataTextField = "Name";
		lstCountry.DataValueField = "ID";
		lstCountry.DataSource = data.GetCountries();
		lstCountry.DataBind();
	}

	private void LoadStates()
	{
		DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
		lstState.DataTextField = "Name";
		lstState.DataValueField = "ID";
		lstState.DataSource = data.GetStates();
		lstState.DataBind();
	}

	private void LoadDetails(string id)
	{
		DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
		DataTable dtinfo = data.GetGuestbookDataByID(id);

		if (dtinfo.Rows.Count > 0)
		{
			System.Data.DataRow tempVar = dtinfo.Rows[0];
			inFullName.Text = tempVar["FullName"].ToString();
			inIPAddress.Text = tempVar["IPAddress"].ToString();
			inEmail.Text = tempVar["Email"].ToString();
			inMessage.Text = tempVar["Message"].ToString();
			inDate.Text = tempVar["SubmissionDate"].ToString();
			inGender.Text = tempVar["Gender"].ToString();
			chkApproved.Checked = tempVar["Approved"];
			lstCountry.Items.FindByValue(tempVar["Country"].ToString()).Selected = true;
			lstState.Items.FindByValue(tempVar["State"].ToString()).Selected = true;
			inHomepage.Text = tempVar["HomePageURL"].ToString();
			inGuestbook.Text = tempVar["GuestBookURL"].ToString();
		}
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
	protected void btnSave_Click(object sender, System.EventArgs e)
	{
		if (b.DemoMode == false)
		{
			DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
			// Update row with new values
			data.UpdateGuestBookEntry(inFullName.Text.Trim(), Convert.ToInt32(lstCountry.SelectedValue), lstState.SelectedValue, inIPAddress.Text, inEmail.Text, inHomepage.Text, inGuestbook.Text, inGender.Text, inMessage.Text, inDate.Text, chkApproved.Checked, Convert.ToInt32(Request.Params["ID"]));

			if (data.SQLError == null)
			{
				RefreshOpenerAndClose();
			}
			else
			{
				DisplayError(data.SQLError.Message);
			}
		}
		else
		{
			Alert("Sorry, you are not allowed to update in demo mode.");
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