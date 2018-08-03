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

partial class Admin_Analytics : System.Web.UI.Page
{
	protected void Page_Load(object sender, System.EventArgs e)
	{
		lblerror.Text = "";
		lblsuccess.Text = "";

		if (!Page.IsPostBack)
		{
			System.IO.StreamReader sr = new System.IO.StreamReader(Server.MapPath("../textfiles/trackingcode.txt"));
			inCode.Text = sr.ReadToEnd();
			sr.Close();
		}
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub lnkSaveCode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSaveCode.Click
	protected void lnkSaveCode_Click(object sender, System.EventArgs e)
	{
		try
		{
			System.IO.StreamWriter sw = new System.IO.StreamWriter(Server.MapPath("../textfiles/trackingcode.txt"));
			sw.Write(this.inCode.Text.Trim());
			sw.Flush();
			sw.Close();
			lblsuccess.Text = "Tracking Code saved";
		}
		catch (Exception ex)
		{
			lblerror.Text = "Error while saving data: " + ex.Message;
		}

	}


	override protected void OnInit(EventArgs e)
	{
//INSTANT C# NOTE: Converted event handler wireups:
		this.Load += Page_Load;
		lnkSaveCode.Click += lnkSaveCode_Click;

		base.OnInit(e);
	}
}
