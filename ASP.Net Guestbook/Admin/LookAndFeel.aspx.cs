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
using System.Xml;

partial class Admin_LookAndFeel : BusinessLayer
{
	private SiteSettings b;

	protected void Page_Load(object sender, System.EventArgs e)
	{
		b = (SiteSettings)Cache["SiteSettings"];
		if (!Page.IsPostBack)
		{
			if (System.IO.File.Exists(Server.MapPath("../StyleSheet.css")) == true)
			{
				inCSS.Text = System.IO.File.ReadAllText(Server.MapPath("../StyleSheet.css"));
			}
			else
			{
				lblerror.Text = "Style Sheet has been remove, deleted or renamed.";
			}
		}
	}

	private void LoadCurrentStyles()
	{
		if (System.IO.File.Exists(Server.MapPath("../StyleSheet.css")) == true)
		{
			inCSS.Text = System.IO.File.ReadAllText(Server.MapPath("../StyleSheet.css"));
		}
		else
		{
			lblerror.Text = "Style Sheet has been remove, deleted or renamed.";
		}
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
	protected void btnSave_Click(object sender, System.EventArgs e)
	{
		if (b.DemoMode == false)
		{
			Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText(Server.MapPath("../StyleSheet.css"), inCSS.Text.Trim(), false);
			lblsuccess.Text = "Settings saved.";
			LoadCurrentStyles();
		}
		else
		{
			Alert("You are not allowed to make changes in demo mode.");
		}
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub btnRevert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRevert.Click
	protected void btnRevert_Click(object sender, System.EventArgs e)
	{
		string backup = System.IO.File.ReadAllText(Server.MapPath("../StyleSheetBackup.txt"));
		Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText(Server.MapPath("../StyleSheet.css"), backup, false);
		LoadCurrentStyles();
	}


	override protected void OnInit(EventArgs e)
	{
//INSTANT C# NOTE: Converted event handler wireups:
		this.Load += Page_Load;
		btnSave.Click += btnSave_Click;
		btnRevert.Click += btnRevert_Click;

		base.OnInit(e);
	}
}
