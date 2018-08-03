﻿//INSTANT C# NOTE: Formerly VB web.config imports:
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

partial class Admin_UserManagement : BusinessLayer
{
	private SiteSettings b;

	protected void Page_Load(object sender, System.EventArgs e)
	{
		b = (SiteSettings)Cache["SiteSettings"];

		if (!Page.IsPostBack)
		{
			ViewState["Column"] = "ID";
			ViewState["Direction"] = "Asc";
			LoadData();
		}
	}

	private void LoadData()
	{
		DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
		using (DataView dv = new DataView(data.GetUsers()))
		{
			dv.Sort = ViewState["Column"].ToString() + " " + ViewState["Direction"].ToString();
			GridView1.DataSource = dv;
			GridView1.DataBind();
		}
	}

#region  GridView Functions 

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
	protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		LoadData();
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub GridView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PreRender
	protected void GridView1_PreRender(object sender, System.EventArgs e)
	{
		if (GridView1.Rows.Count > 0)
		{
			lblSort.Visible = true;
		}
		else
		{
			lblSort.Visible = false;
			Alert("There are no users in the database.");
		}
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
	protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
	{
		GridView1.EditIndex = -1;
		LoadData();
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
	protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
	{
		if (b.DemoMode == false)
		{
			string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
			DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
			data.DeleteUserByID(id);

			if (data.SQLError == null)
			{
				LoadData();
			}
			else
			{
				DisplayError("An Error occured while deleting this user.");
			}
		}
		else
		{
			Alert("Sorry, but you are not allowed to delete users in demo mode");
		}
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
	protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
	{
		GridView1.EditIndex = e.NewEditIndex;
		LoadData();
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
	protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
	{
		if (b.DemoMode == false)
		{
			string Email = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim();
			string FullName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim();

			DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
			data.UpdataUserInformation(Email, FullName, GridView1.DataKeys[e.RowIndex].Values[0].ToString());

			if (data.SQLError == null)
			{
				GridView1.EditIndex = -1;
				LoadData();
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
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
	protected void GridView1_SelectedIndexChanging(object sender, System.Web.UI.WebControls.GridViewSelectEventArgs e)
	{
		string id = GridView1.DataKeys[e.NewSelectedIndex].Values[0].ToString();
		string Pass = "";
		DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
		Pass = data.ForgotPassword(id);

		Pass = System.Text.Encoding.Default.GetString(Convert.FromBase64String(Pass));

		try
		{
			using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(ConfigurationManager.AppSettings["AdminEmail"], GridView1.Rows[e.NewSelectedIndex].Cells[2].Text, "Your password for the Guestbook", "Your password is: " + Pass))
			{
				System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["MailServer"]);
				smtp.Send(mail);
			}
		}
		catch (Exception ex)
		{
			DisplayError(ex.Message);
		}

	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
	protected void GridView1_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
	{
		ViewState["Column"] = e.SortExpression;

		if (Convert.ToString(ViewState["Direction"]) == "Asc")
		{
			ViewState["Direction"] = "Desc";
		}
		else
		{
			ViewState["Direction"] = "Asc";
		}

		LoadData();
	}

#endregion



	override protected void OnInit(EventArgs e)
	{
//INSTANT C# NOTE: Converted event handler wireups:
		this.Load += Page_Load;
		GridView1.PageIndexChanging += GridView1_PageIndexChanging;
		GridView1.PreRender += GridView1_PreRender;
		GridView1.RowCancelingEdit += GridView1_RowCancelingEdit;
		GridView1.RowDeleting += GridView1_RowDeleting;
		GridView1.RowEditing += GridView1_RowEditing;
		GridView1.RowUpdating += GridView1_RowUpdating;
		GridView1.SelectedIndexChanging += GridView1_SelectedIndexChanging;
		GridView1.Sorting += GridView1_Sorting;

		base.OnInit(e);
	}
}