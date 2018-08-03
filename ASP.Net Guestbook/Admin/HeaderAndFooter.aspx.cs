using System;

partial class Admin_HeaderAndFooter : BusinessLayer
{
	private SiteSettings b;

	protected void Page_Load(object sender, EventArgs e)
	{
	    this.b = (SiteSettings)Cache["SiteSettings"];

	    if (Page.IsPostBack)
	        return;

	    this.inFooter.Text = System.IO.File.ReadAllText(Server.MapPath("../TextFiles/Footer.txt"));
	    this.litFooter.Text = this.inFooter.Text;
	    this.inHeader.Text = System.IO.File.ReadAllText(Server.MapPath("../TextFiles/Header.txt"));
	    this.litHeader.Text = this.inHeader.Text;
	}

	protected void lnkHeaderPreview_Click(object sender, EventArgs e)
	{
	    this.litHeader.Text = this.inHeader.Text.Trim();
	}

	protected void lnkFooterPreview_Click(object sender, EventArgs e)
	{
	    this.litFooter.Text = this.inFooter.Text.Trim();
	}

	protected void lnkHeaderSave_Click(object sender, EventArgs e)
	{
		if (this.b.DemoMode == false)
		{
			if (this.inHeader.Text.Length > 0)
			{
				System.IO.File.WriteAllText(Server.MapPath("../TextFiles/Header.txt"), this.inHeader.Text.Trim());
			}
		}
		else
		{
			Alert("Sorry, you are not allowed to change this setting while in Demo Mode.");
		}
	}

	protected void lnkFooterSave_Click(object sender, EventArgs e)
	{
		if (this.b.DemoMode == false)
		{
			if (this.inFooter.Text.Length > 0)
			{
				System.IO.File.WriteAllText(Server.MapPath("../TextFiles/Footer.txt"), this.inFooter.Text.Trim());
			}
		}
		else
		{
			Alert("Sorry, you are not allowed to change this setting while in Demo Mode.");
		}
	}

}
