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
using System.Drawing;

partial class Image : System.Web.UI.Page
{
	protected void Page_Load(object sender, System.EventArgs e)
	{
		Bitmap b = new Bitmap(75, 20);
		Graphics g = Graphics.FromImage(b);
		Font f = new Font("Arial", 12);
		SolidBrush FC = new SolidBrush(System.Drawing.Color.Black);
		SolidBrush Bc = new SolidBrush(System.Drawing.Color.White);
		g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
		g.FillRectangle(Bc, 0, 0, 75, 20);
		Random r = new Random();
		Session["NewID"] = r.Next(112, 2005);
		g.DrawString(Session["NewID"].ToString(), f, FC, 0, 0);
		b.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
	}


	override protected void OnInit(EventArgs e)
	{
//INSTANT C# NOTE: Converted event handler wireups:
		this.Load += Page_Load;

		base.OnInit(e);
	}
}
