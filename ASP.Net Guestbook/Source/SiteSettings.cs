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

public class SiteSettings
{

	private string mMetaKeywords;
	public string MetaKeywords
	{
		get
		{
			return mMetaKeywords;
		}
		set
		{
			mMetaKeywords = value;
		}
	}

	private string mMetaDescription;
	public string MetaDescription
	{
		get
		{
			return mMetaDescription;
		}
		set
		{
			mMetaDescription = value;
		}
	}

	private string mSiteTitle;
	public string SiteTitle
	{
		get
		{
			return mSiteTitle;
		}
		set
		{
			mSiteTitle = value;
		}
	}

	private string mGuestbookTitle;
	public string GuestBookTitle
	{
		get
		{
			return mGuestbookTitle;
		}
		set
		{
			mGuestbookTitle = value;
		}
	}

	private Int16 mGuestbookGridSize;
	public Int16 GuestbookGridSize
	{
		get
		{
			return mGuestbookGridSize;
		}
		set
		{
			mGuestbookGridSize = value;
		}
	}

	private bool mDemoMode;
	public bool DemoMode
	{
		get
		{
			return mDemoMode;
		}
		set
		{
			mDemoMode = value;
		}
	}

	private string mLanguageFilter;
	public string LanguageFilter
	{
		get
		{
			return mLanguageFilter;
		}
		set
		{
			mLanguageFilter = value;
		}
	}

	private bool mShowPoweredBy;
	public bool ShowPoweredBy
	{
		get
		{
			return mShowPoweredBy;
		}
		set
		{
			mShowPoweredBy = value;
		}
	}

	private string mAdminEmail;
	public string AdminEmail
	{
		get
		{
			return mAdminEmail;
		}
		set
		{
			mAdminEmail = value;
		}
	}

	private bool mRequireApproval;
	public bool RequireApproval
	{
		get
		{
			return mRequireApproval;
		}
		set
		{
			mRequireApproval = value;
		}
	}

	private bool mSendEmailWithNewPost;
	public bool SendEmailWithNewPost
	{
		get
		{
			return mSendEmailWithNewPost;
		}
		set
		{
			mSendEmailWithNewPost = value;
		}
	}

	private string mMailServer;
	public string MailServer
	{
		get
		{
			return mMailServer;
		}
		set
		{
			mMailServer = value;
		}
	}

	private bool mEnableErrorTracking;
	public bool EnableErrorTracking
	{
		get
		{
			return mEnableErrorTracking;
		}
		set
		{
			mEnableErrorTracking = value;
		}
	}

	private bool mRequireFullName;
	public bool RequireFullName
	{
		get
		{
			return mRequireFullName;
		}
		set
		{
			mRequireFullName = value;
		}
	}

	private bool mRequireCountry;
	public bool RequireCountry
	{
		get
		{
			return mRequireCountry;
		}
		set
		{
			mRequireCountry = value;
		}
	}

	private bool mRequireState;
	public bool RequireState
	{
		get
		{
			return mRequireState;
		}
		set
		{
			mRequireState = value;
		}
	}

	private bool mRequireEmail;
	public bool RequireEmail
	{
		get
		{
			return mRequireEmail;
		}
		set
		{
			mRequireEmail = value;
		}
	}

	private bool mRequireHomepage;
	public bool RequireHomepage
	{
		get
		{
			return mRequireHomepage;
		}
		set
		{
			mRequireHomepage = value;
		}
	}

	private bool mRequireGuestbook;
	public bool RequireGuestbook
	{
		get
		{
			return mRequireGuestbook;
		}
		set
		{
			mRequireGuestbook = value;
		}
	}

	private bool mRequireGender;
	public bool RequireGender
	{
		get
		{
			return mRequireGender;
		}
		set
		{
			mRequireGender = value;
		}
	}

	private bool mRequireMessage;
	public bool RequireMessage
	{
		get
		{
			return mRequireMessage;
		}
		set
		{
			mRequireMessage = value;
		}
	}

	private bool mDisplayFullName;
	public bool DisplayFullName
	{
		get
		{
			return mDisplayFullName;
		}
		set
		{
			mDisplayFullName = value;
		}
	}

	private bool mDisplayCountry;
	public bool DisplayCountry
	{
		get
		{
			return mDisplayCountry;
		}
		set
		{
			mDisplayCountry = value;
		}
	}

	private bool mDisplayState;
	public bool DisplayState
	{
		get
		{
			return mDisplayState;
		}
		set
		{
			mDisplayState = value;
		}
	}

	private bool mDisplayEmail;
	public bool DisplayEmail
	{
		get
		{
			return mDisplayEmail;
		}
		set
		{
			mDisplayEmail = value;
		}
	}

	private bool mDisplayHomepage;
	public bool DisplayHomepage
	{
		get
		{
			return mDisplayHomepage;
		}
		set
		{
			mDisplayHomepage = value;
		}
	}

	private bool mDisplayGuestbook;
	public bool DisplayGuestbook
	{
		get
		{
			return mDisplayGuestbook;
		}
		set
		{
			mDisplayGuestbook = value;
		}
	}

	private bool mDisplayGender;
	public bool DisplayGender
	{
		get
		{
			return mDisplayGender;
		}
		set
		{
			mDisplayGender = value;
		}
	}

	private bool mDisplayMessage;
	public bool DisplayMessage
	{
		get
		{
			return mDisplayMessage;
		}
		set
		{
			mDisplayMessage = value;
		}
	}

}