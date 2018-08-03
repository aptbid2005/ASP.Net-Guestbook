﻿//INSTANT C# NOTE: Formerly VB web.config imports:
using System;
using System.Web.UI.WebControls;
using System.Data;

partial class Admin_BadLanguageEditor : BusinessLayer
{
	private SiteSettings b = new SiteSettings();

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
		using (DataView dv = new DataView(data.GetBadWords()))
		{
			dv.Sort = ViewState["Column"].ToString() + " " + ViewState["Direction"].ToString();
			GridView1.DataSource = dv;
			GridView1.DataBind();
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
			string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
			DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
			data.DeleteBadWord(id);

			if (data.SQLError != null)
			{
				DisplayError(data.SQLError.Message);
			}
			else
			{
				LoadData();
			}
		}
		else
		{
			Alert("You are not allowed to make changes in demo mode.");
		}
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
	protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		LoadData();
	}

//INSTANT C# WARNING: Strict 'Handles' conversion only applies to 'WithEvents' fields declared in the same class - the event will be wired in 'SubscribeToEvents':
//ORIGINAL LINE: Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
	protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
	{
		if (b.DemoMode == false)
		{
			string BadWord = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim();

			DataLayer.SQLDataProvider data = new DataLayer.SQLDataProvider();
			data.UpdateBadWord(BadWord, Convert.ToString(GridView1.DataKeys[e.RowIndex].Value));

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


	override protected void OnInit(EventArgs e)
	{
//INSTANT C# NOTE: Converted event handler wireups:
		this.Load += Page_Load;
		GridView1.RowEditing += GridView1_RowEditing;
		GridView1.RowCancelingEdit += GridView1_RowCancelingEdit;
		GridView1.RowDeleting += GridView1_RowDeleting;
		GridView1.PageIndexChanging += GridView1_PageIndexChanging;
		GridView1.RowUpdating += GridView1_RowUpdating;
		GridView1.Sorting += GridView1_Sorting;

		base.OnInit(e);
	}
}