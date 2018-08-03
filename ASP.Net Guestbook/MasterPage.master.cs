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

partial class MasterPage : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, System.EventArgs e)
	{
		SiteSettings b = (SiteSettings)Cache["SiteSettings"];

		SiteTitle.Text = b.SiteTitle;
		MetaKeywords.Content = b.MetaKeywords;
		MetaDescription.Content = b.MetaDescription;

		if (b.ShowPoweredBy == true)
		{
			lblPoweredBy.Text = "Powered by: <a href=\"http://www.theprodev.com/\" target=\"_blank\">The Professional Developer</a>";
		}

		litHeader.Text = System.IO.File.ReadAllText(Server.MapPath("textfiles/header.txt")) + "<br />";
		litFooter.Text = "<br />" + System.IO.File.ReadAllText(Server.MapPath("textfiles/footer.txt"));

		if (b.DemoMode == true)
		{
			litDemo.Text = "<div style=\"text-align: center;\"><a href=\"Admin/\">Click here to see how you can manage the guestbook and all its features!</a></div><br />";
		}

		try
		{
			System.IO.StreamReader sr = new System.IO.StreamReader(Server.MapPath("textfiles/trackingcode.txt"));
			litTrackingCode.Text = sr.ReadToEnd();
			sr.Close();
		}
		catch (Exception ex)
		{

		}

	}


	override protected void OnInit(EventArgs e)
	{
//INSTANT C# NOTE: Converted event handler wireups:
		this.Load += Page_Load;

		base.OnInit(e);
	}
}

