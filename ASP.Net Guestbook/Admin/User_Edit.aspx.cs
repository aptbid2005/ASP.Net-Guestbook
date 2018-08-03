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

partial class Admin_User_Edit : BusinessLayer
{
	private SiteSettings b;

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub btnSaveAddMore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveAddMore.Click
	protected void btnSaveAddMore_Click(object sender, System.EventArgs e)
	{
		b = (SiteSettings)Cache["SiteSettings"];
		if (SaveData() == true)
		{
			this.RefreshOpener();
			ClearForm();
		}
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub btnSaveAndClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveAndClose.Click
	protected void btnSaveAndClose_Click(object sender, System.EventArgs e)
	{
		if (SaveData() == true)
		{
			this.RefreshOpenerAndClose();
		}
	}

	private bool SaveData()
	{
		bool bRet = false;
		if (b.DemoMode == false)
		{
			DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
			string password = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(inRePassword.Text.Trim()));
			data.AddNewUser(this.inFullName.Text.Trim(), this.inEmail.Text.Trim(), password);

			if (data.SQLError == null)
			{
				bRet = true;
			}
			else
			{
				DisplayError(data.SQLError.Message);
			}

		}
		else
		{
			Alert("You are not allowed to make changes in demo mode.");
		}
		return bRet;
	}

	private void ClearForm()
	{
		this.inEmail.Text = "";
		this.inFullName.Text = "";
		this.inPassword.Text = "";
		this.inRePassword.Text = "";
	}


	override protected void OnInit(EventArgs e)
	{
//INSTANT C# NOTE: Converted event handler wireups:
		btnSaveAddMore.Click += btnSaveAddMore_Click;
		btnSaveAndClose.Click += btnSaveAndClose_Click;

		base.OnInit(e);
	}
}