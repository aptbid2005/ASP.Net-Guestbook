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

partial class Admin_IPAddress_new : BusinessLayer
{
	private SiteSettings b;

	protected void Page_Load(object sender, System.EventArgs e)
	{
		b = (SiteSettings)Cache["SiteSettings"];
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub btnSaveAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveAdd.Click
	protected void btnSaveAdd_Click(object sender, System.EventArgs e)
	{
		if (SaveData() == true)
		{
			this.RefreshOpener();
			this.inIPAddress.Text = "";
		}
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub btnSaveClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveClose.Click
	protected void btnSaveClose_Click(object sender, System.EventArgs e)
	{
		if (SaveData() == true)
		{
			this.RefreshOpenerAndClose();
		}
	}

	private bool SaveData()
	{
		bool bRet = true;
		if (b.DemoMode == false)
		{
			DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
			data.InsertsNewIPAddress(this.inIPAddress.Text.Trim());

			if (data.SQLError != null)
			{
				bRet = false;
				DisplayError(data.SQLError.Message);
			}
		}
		else
		{
			Alert("You are not allowed to make changes in demo mode.");
		}
		return bRet;
	}


	override protected void OnInit(EventArgs e)
	{
//INSTANT C# NOTE: Converted event handler wireups:
		this.Load += Page_Load;
		btnSaveAdd.Click += btnSaveAdd_Click;
		btnSaveClose.Click += btnSaveClose_Click;

		base.OnInit(e);
	}
}
