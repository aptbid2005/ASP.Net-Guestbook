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

partial class Admin_Admin : System.Web.UI.MasterPage
{
//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
	protected void btnLogout_Click(object sender, System.EventArgs e)
	{
		FormsAuthentication.SignOut();
		FormsAuthentication.RedirectToLoginPage();
	}


	override protected void OnInit(EventArgs e)
	{
//INSTANT C# NOTE: Converted event handler wireups:
		btnLogout.Click += btnLogout_Click;

		base.OnInit(e);
	}
}