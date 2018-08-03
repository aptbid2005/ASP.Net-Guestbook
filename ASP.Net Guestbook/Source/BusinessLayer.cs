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

public class BusinessLayer : System.Web.UI.Page
{
	protected void Alert(string Message)
	{
		ClientScript.RegisterStartupScript(Type.GetType("System.String"), "onLoad", "<script type=\"text/javascript\">alert('" + Message + "');void('');</script>");
	}

	protected void DisplayError(string Message)
	{
		ClientScript.RegisterStartupScript(Type.GetType("System.String"), "onLoad", "<script type=\"text/javascript\">alert('An error occured: \\n\\n" + Message + "');void('');</script>");
	}

	protected void RefreshOpenerAndClose()
	{
		ClientScript.RegisterStartupScript(Type.GetType("System.String"), "onLoad", "<script type=\"text/javascript\">opener.document.location.reload();void('');self.close();</script>");
	}

	protected void RefreshOpener()
	{
		ClientScript.RegisterStartupScript(Type.GetType("System.String"), "onLoad", "<script type=\"text/javascript\">opener.document.location.reload();void('');self.focus();</script>");
	}


}