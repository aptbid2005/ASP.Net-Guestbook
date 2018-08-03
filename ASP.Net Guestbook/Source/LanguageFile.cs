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

public class LanguageFile
{

	private string mYourGuestbook;
	public string YourGuestbook
	{
		get
		{
			return mYourGuestbook;
		}
		set
		{
			mYourGuestbook = value;
		}
	}

	private string mYourHomepage;
	public string YourHomepage
	{
		get
		{
			return mYourHomepage;
		}
		set
		{
			mYourHomepage = value;
		}
	}

	private string mEmail;
	public string Email
	{
		get
		{
			return mEmail;
		}
		set
		{
			mEmail = value;
		}
	}

	private string mHomepage;
	public string Homepage
	{
		get
		{
			return mHomepage;
		}
		set
		{
			mHomepage = value;
		}
	}

	private string mGuestbook;
	public string Guestbook
	{
		get
		{
			return mGuestbook;
		}
		set
		{
			mGuestbook = value;
		}
	}

	private string mSignOurGuestbook;
	public string SignOurGuestbook
	{
		get
		{
			return mSignOurGuestbook;
		}
		set
		{
			mSignOurGuestbook = value;
		}
	}

	private string mVerificationImage;
	public string VerificationImage
	{
		get
		{
			return mVerificationImage;
		}
		set
		{
			mVerificationImage = value;
		}
	}

	private string mFullName;
	public string FullName
	{
		get
		{
			return mFullName;
		}
		set
		{
			mFullName = value;
		}
	}

	private string mCountry;
	public string Country
	{
		get
		{
			return mCountry;
		}
		set
		{
			mCountry = value;
		}
	}

	private string mState;
	public string State
	{
		get
		{
			return mState;
		}
		set
		{
			mState = value;
		}
	}

	private string mMessage;
	public string Message
	{
		get
		{
			return mMessage;
		}
		set
		{
			mMessage = value;
		}
	}

	private string mGender;
	public string Gender
	{
		get
		{
			return mGender;
		}
		set
		{
			mGender = value;
		}
	}

	private string mMale;
	public string Male
	{
		get
		{
			return mMale;
		}
		set
		{
			mMale = value;
		}
	}

	private string mFemale;
	public string Female
	{
		get
		{
			return mFemale;
		}
		set
		{
			mFemale = value;
		}
	}

	private string mUnspecified;
	public string Unspecified
	{
		get
		{
			return mUnspecified;
		}
		set
		{
			mUnspecified = value;
		}
	}

	private string mEnterNosHere;
	public string EnterNosHere
	{
		get
		{
			return mEnterNosHere;
		}
		set
		{
			mEnterNosHere = value;
		}
	}

	private string mCompleteThisForm;
	public string CompleteThisForm
	{
		get
		{
			return mCompleteThisForm;
		}
		set
		{
			mCompleteThisForm = value;
		}
	}

	private string mBacktoGuestbook;
	public string BacktoGuestbook
	{
		get
		{
			return mBacktoGuestbook;
		}
		set
		{
			mBacktoGuestbook = value;
		}
	}

	private string mBoldfield;
	public string Boldfield
	{
		get
		{
			return mBoldfield;
		}
		set
		{
			mBoldfield = value;
		}
	}


	private string mEnterFullName;
	public string EnterFullName
	{
		get
		{
			return mEnterFullName;
		}
		set
		{
			mEnterFullName = value;
		}
	}

	private string mEnterEmailAddress;
	public string EnterEmailAddress
	{
		get
		{
			return mEnterEmailAddress;
		}
		set
		{
			mEnterEmailAddress = value;
		}
	}

	private string mEnterMessage;
	public string EnterMessage
	{
		get
		{
			return mEnterMessage;
		}
		set
		{
			mEnterMessage = value;
		}
	}


	private string mEnterVerificationImage;
	public string EnterVerificationImage
	{
		get
		{
			return mEnterVerificationImage;
		}
		set
		{
			mEnterVerificationImage = value;
		}
	}

	private string mValidEmailAddress;
	public string ValidEmailAddress
	{
		get
		{
			return mValidEmailAddress;
		}
		set
		{
			mValidEmailAddress = value;
		}
	}

	private string mVerificationDidNotMatch;
	public string VerificationDidNotMatch
	{
		get
		{
			return mVerificationDidNotMatch;
		}
		set
		{
			mVerificationDidNotMatch = value;
		}
	}

	private string mCancel;
	public string Cancel
	{
		get
		{
			return mCancel;
		}
		set
		{
			mCancel = value;
		}
	}

	private string mSubmit;
	public string Submit
	{
		get
		{
			return mSubmit;
		}
		set
		{
			mSubmit = value;
		}
	}

	private string mBlockedIP;
	public string BlockedIP
	{
		get
		{
			return mBlockedIP;
		}
		set
		{
			mBlockedIP = value;
		}
	}

	private string mSubmissionMessage;
	public string SubmissionMessage
	{
		get
		{
			return mSubmissionMessage;
		}
		set
		{
			mSubmissionMessage = value;
		}
	}

	private string mBadLanguage;
	public string BadLanguage
	{
		get
		{
			return mBadLanguage;
		}
		set
		{
			mBadLanguage = value;
		}
	}

	private string mSelectCountry;
	public string SelectCountry
	{
		get
		{
			return mSelectCountry;
		}
		set
		{
			mSelectCountry = value;
		}
	}

	private string mSelectState;
	public string SelectState
	{
		get
		{
			return mSelectState;
		}
		set
		{
			mSelectState = value;
		}
	}

	private string mEnterHomepage;
	public string EnterHomepage
	{
		get
		{
			return mEnterHomepage;
		}
		set
		{
			mEnterHomepage = value;
		}
	}

	private string mEnterGuestbook;
	public string EnterGuestbook
	{
		get
		{
			return mEnterGuestbook;
		}
		set
		{
			mEnterGuestbook = value;
		}
	}

	private string mValidHomepageURL;
	public string ValidHomepageURL
	{
		get
		{
			return mValidHomepageURL;
		}
		set
		{
			mValidHomepageURL = value;
		}
	}

	private string mValidGuestbookURL;
	public string ValidGuestbookURL
	{
		get
		{
			return mValidGuestbookURL;
		}
		set
		{
			mValidGuestbookURL = value;
		}
	}

	private string mSubmissionDate;
	public string SubmissionDate
	{
		get
		{
			return mSubmissionDate;
		}
		set
		{
			mSubmissionDate = value;
		}
	}

}