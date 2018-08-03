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

partial class Posts : BusinessLayer
{
	private SiteSettings b;

	protected void Page_Load(object sender, System.EventArgs e)
	{
		b = (SiteSettings)Cache["SiteSettings"];
		if (!Page.IsPostBack)
		{
			LoadData();
		}
	}

#region  GridView Functions 

	private void LoadData()
	{
		DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
		GridView1.DataSource = data.GetGuestbookDataByApprovalType(rblStatus.SelectedValue);
		GridView1.DataBind();
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
	protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		LoadData();
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
	protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
	{
		if (b.DemoMode == false)
		{
			string id = GridView1.DataKeys(e.RowIndex).Value.ToString();

			DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
			data.DeleteGuestbookEntry(id);

			if (data.SQLError == null)
			{
				Alert("Post Deleted.");
				LoadData();
			}
			else
			{
				Alert("An Error occured while deleting post.");
			}
		}
		else
		{
			Alert("You are not allowed to delete while in demo mode.");
		}
	}

#endregion

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub rblStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblStatus.SelectedIndexChanged
	protected void rblStatus_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		LoadData();
	}


	override protected void OnInit(EventArgs e)
	{
//INSTANT C# NOTE: Converted event handler wireups:
		this.Load += Page_Load;
		GridView1.PageIndexChanging += GridView1_PageIndexChanging;
		GridView1.RowDeleting += GridView1_RowDeleting;
		rblStatus.SelectedIndexChanged += rblStatus_SelectedIndexChanged;

		base.OnInit(e);
	}
}