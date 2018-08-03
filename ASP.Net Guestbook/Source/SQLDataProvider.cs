//INSTANT C# NOTE: Formerly VB web.config imports:
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

using System.Data.SqlClient;
using System.Data;
using System;

namespace DataLayer
{
	public class SQLDataProvider
	{

#region  Class Level Variables 

		private SqlException _SQLEx;
		private string connectionString = ConfigurationManager.ConnectionStrings["GuestBookConnectionString"].ConnectionString;

#endregion

#region  Properties 

		public SqlException SQLError
		{
			get
			{
				return _SQLEx;
			}
			set
			{
				_SQLEx = value;
			}
		}

#endregion

#region  Bad Language Functions 

		public void DeleteBadWord(string Id)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Delete from gb_ExcludedWords where ID = @ID", conn))
				{
					comm.Parameters.AddWithValue("@ID", Id);
					try
					{
						conn.Open();
						comm.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
		}

		public DataTable GetBadWords()
		{
			DataTable dtinfo = new DataTable();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlDataAdapter da = new SqlDataAdapter("Select * from gb_ExcludedWords", conn))
				{
					try
					{
						da.Fill(dtinfo);
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
				}
			}
			return dtinfo;
		}

		public void UpdateBadWord(string BadWord, string ID)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Update gb_ExcludedWords Set ExcludeWord = @ExcludeWord where ID = @ID", conn))
				{
					comm.Parameters.AddWithValue("@ExcludeWord", BadWord);
					comm.Parameters.AddWithValue("@ID", ID);
					try
					{
						conn.Open();
						comm.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
		}

		public void AddNewBadWord(string BadWord)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Insert into gb_ExcludedWords(ExcludeWord)values(@ExcludeWord)", conn))
				{
					comm.Parameters.AddWithValue("@ExcludeWord", BadWord);
					try
					{
						conn.Open();
						comm.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
		}

#endregion

#region  Country and State Functions 

		public DataTable GetCountries()
		{
			DataTable dtinfo = new DataTable();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlDataAdapter da = new SqlDataAdapter("Select * from gb_Countries", conn))
				{
					try
					{
						da.Fill(dtinfo);
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
				}
			}
			return dtinfo;
		}

		public DataTable GetStates()
		{
			DataTable dtinfo = new DataTable();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlDataAdapter da = new SqlDataAdapter("Select * from gb_States", conn))
				{
					try
					{
						da.Fill(dtinfo);
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
				}
			}
			return dtinfo;
		}


#endregion

#region  Guestbook Functions 


		/// <summary>
		/// Deletes a Guestbook entry from the database based on the supplied ID
		/// </summary>
		public void DeleteGuestbookEntry(string ID)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Delete from gb_Guestbook where Id = @Id", conn))
				{
					comm.Parameters.AddWithValue("@Id", ID);
					try
					{
						conn.Open();
						comm.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
		}


		/// <summary>
		/// Gets a particular guestbook entry from the database
		/// </summary>
		public DataTable GetGuestbookDataByID(string ID)
		{
			DataTable dtinfo = new DataTable();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlDataAdapter da = new SqlDataAdapter("Select * from gb_Guestbook where id = @Id", conn))
				{
					da.SelectCommand.Parameters.AddWithValue("@Id", ID);
					try
					{
						da.Fill(dtinfo);
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
				}
			}
			return dtinfo;
		}


		/// <summary>
		/// Gets all Guestbook data from the database based on the approval type passed in
		/// </summary>
		public DataTable GetGuestbookDataByApprovalType(bool ApprovalType)
		{
			DataTable dtinfo = new DataTable();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlDataAdapter da = new SqlDataAdapter("SELECT gb_GuestBook.*, gb_Countries.Name as CountryName, gb_States.Name as StateName " + "FROM (gb_GuestBook INNER JOIN gb_States ON gb_GuestBook.State = gb_States.ID) " + "INNER JOIN gb_Countries ON gb_GuestBook.Country = gb_Countries.ID " + "where gb_GuestBook.Approved = @Approved order by gb_GuestBook.SubmissionDate Desc", conn))
				{
					da.SelectCommand.Parameters.AddWithValue("@Approved", ApprovalType);
					try
					{
						da.Fill(dtinfo);
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
				}
			}
			return dtinfo;
		}


		/// <summary>
		/// Inserts a new Guestbook entry into the database
		/// </summary>
		public void InsertNewGuestbookEntry(string FullName, int Country, int State, string IPAddress, string Email, string HomePageURL, string GuestbookURL, string Gender, string Message, string submissionDate, bool Approved)
		{

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Insert into gb_Guestbook(FullName, Country, State, IPAddress, Email, HomePageURL, GuestbookURL," + "Gender, Message, SubmissionDate, Approved)values(@FullName,@Country,@State,@IPAddress,@Email," + "@HomePageURL,@GuestbookURL,@Gender,@Message,@SubmissionDate,@Approved)", conn))
				{
					comm.Parameters.AddWithValue("@FullName", FullName);
					comm.Parameters.AddWithValue("@Country", Country);
					comm.Parameters.AddWithValue("@State", State);
					comm.Parameters.AddWithValue("@IPAddress", IPAddress);
					comm.Parameters.AddWithValue("@Email", Email);
					comm.Parameters.AddWithValue("@HomePageURL", HomePageURL);
					comm.Parameters.AddWithValue("@GuestbookURL", GuestbookURL);
					comm.Parameters.AddWithValue("@Gender", Gender);
					comm.Parameters.AddWithValue("@Message", Message);
					comm.Parameters.AddWithValue("@SubmissionDate", submissionDate);
					comm.Parameters.AddWithValue("@Approved", Approved);
					try
					{
						conn.Open();
						comm.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
		}


		/// <summary>
		/// Updates a Guestbook entry in the database
		/// </summary>
		public void UpdateGuestBookEntry(string FullName, int Country, int State, string IPAddress, string Email, string Homepage, string Guestbook, string Gender, string Message, string SubmissionDate, bool Approved, int ID)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Update gb_Guestbook set FullName = @FullName, Country = @Country, State = @State, IPAddress = @IPAddress, " + "Email = @Email, HomepageURL = @HomepageURL, GuestbookURL = @GuestbookURL, Gender = @Gender, Message = @Message, " + "SubmissionDate = @SubmissionDate, Approved = @Approved where ID = @ID", conn))
				{
					comm.Parameters.AddWithValue("@FullName", FullName);
					comm.Parameters.AddWithValue("@Country", Country);
					comm.Parameters.AddWithValue("@State", State);
					comm.Parameters.AddWithValue("@IPAddress", IPAddress);
					comm.Parameters.AddWithValue("@Email", Email);
					comm.Parameters.AddWithValue("@HomepageURL", Homepage);
					comm.Parameters.AddWithValue("@GuestbookURL", Guestbook);
					comm.Parameters.AddWithValue("@Gender", Gender);
					comm.Parameters.AddWithValue("@Message", Message);
					comm.Parameters.AddWithValue("@SubmissionDate", SubmissionDate);
					comm.Parameters.AddWithValue("@Approved", Approved);
					comm.Parameters.AddWithValue("@ID", ID);
					try
					{
						conn.Open();
						comm.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
		}

#endregion

#region  Language File Functions 

		public LanguageFile LoadLanguageFile()
		{
			LanguageFile b = new LanguageFile();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Select * from gb_LanguageFile", conn))
				{
					try
					{
						conn.Open();
						SqlDataReader dr = comm.ExecuteReader(CommandBehavior.CloseConnection);

						if (dr.Read() == true)
						{
							b.BacktoGuestbook = dr["BackToGuestbook"].ToString();
							b.BadLanguage = dr["BadLanguage"].ToString();
							b.BlockedIP = dr["BlockedIP"].ToString();
							b.Boldfield = dr["BoldField"].ToString();
							b.Cancel = dr["Cancel"].ToString();
							b.CompleteThisForm = dr["CompleteThisForm"].ToString();
							b.Country = dr["Country"].ToString();
							b.Email = dr["Email"].ToString();
							b.EnterEmailAddress = dr["EnterEmailAddress"].ToString();
							b.EnterFullName = dr["EnterFullName"].ToString();
							b.EnterGuestbook = dr["EnterGuestbook"].ToString();
							b.EnterHomepage = dr["EnterHomepage"].ToString();
							b.EnterMessage = dr["EnterMessage"].ToString();
							b.EnterNosHere = dr["EnterNosHere"].ToString();
							b.EnterVerificationImage = dr["EnterVerificationImage"].ToString();
							b.Female = dr["Female"].ToString();
							b.FullName = dr["FullName"].ToString();
							b.Gender = dr["Gender"].ToString();
							b.Guestbook = dr["Guestbook"].ToString();
							b.Homepage = dr["HomePage"].ToString();
							b.Male = dr["Male"].ToString();
							b.Message = dr["Message"].ToString();
							b.SelectCountry = dr["SelectCountry"].ToString();
							b.SelectState = dr["SelectState"].ToString();
							b.SignOurGuestbook = dr["SignOurGuestbook"].ToString();
							b.State = dr["State"].ToString();
							b.SubmissionDate = dr["SubmissionDate"].ToString();
							b.SubmissionMessage = dr["SubmissionMessage"].ToString();
							b.Submit = dr["Submit"].ToString();
							b.Unspecified = dr["Unspecified"].ToString();
							b.ValidEmailAddress = dr["ValidEmailAddress"].ToString();
							b.ValidGuestbookURL = dr["ValidGuestbookURL"].ToString();
							b.ValidHomepageURL = dr["ValidHomepageURL"].ToString();
							b.VerificationDidNotMatch = dr["VerificationDidNotMatch"].ToString();
							b.VerificationImage = dr["VerificationImage"].ToString();
							b.YourGuestbook = dr["YourGuestbook"].ToString();
							b.YourHomepage = dr["YourHomepage"].ToString();
						}

						dr.Close();
					}
					catch (SqlException ex)
					{
						_SQLEx = ex;
					}
					finally
					{
						if (conn.State == ConnectionState.Open)
						{
							conn.Close();
						}
					}
				}
			}
			return b;
		}

		public bool UpdateLanguageFile(LanguageFile b)
		{
			bool bRet = false;
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Update gb_LanguageFile set YourGuestbook = @YourGuestbook, YourHomepage = @YourHomepage, Email = @Email," + "Homepage = @Homepage, Guestbook = @Guestbook, SignOurGuestbook = @SignOurGuestbook, VerificationImage = @VerificationImage," + "FullName = @FullName, Country = @Country, State = @State, Message = @Message, Gender = @Gender," + "Male = @Male, Female = @Female, Unspecified = @Unspecified, EnterNosHere = @EnterNosHere, CompleteThisForm = @CompleteThisForm," + "BackToGuestbook = @BackToGuestbook, BoldField = @BoldField, EnterFullName = @EnterFullName, EnterEmailAddress = @EnterEmailAddress," + "EnterMessage = @EnterMessage, EnterVerificationImage = @EnterVerificationImage, ValidEmailAddress = @ValidEmailAddress," + "VerificationDidNotMatch = @VerificationDidNotMatch, Cancel = @Cancel, Submit = @Submit, BlockedIP = @BlockedIP," + "SubmissionMessage = @SubmissionMessage, BadLanguage = @BadLanguage, SelectCountry = @SelectCountry, SelectState = @SelectState," + "EnterHomepage = @EnterHomepage, ValidHomepageURL = @ValidHomepageURL, ValidGuestbookURL = @ValidGuestbookURL," + "SubmissionDate = @SubmissionDate, EnterGuestbook = @EnterGuestbook", conn))
				{
					comm.Parameters.AddWithValue("@YourGuestbook", b.YourGuestbook);
					comm.Parameters.AddWithValue("@YourHomepage", b.YourHomepage);
					comm.Parameters.AddWithValue("@Email", b.Email);
					comm.Parameters.AddWithValue("@Homepage", b.Homepage);
					comm.Parameters.AddWithValue("@Guestbook", b.Guestbook);
					comm.Parameters.AddWithValue("@SignOurGuestbook", b.SignOurGuestbook);
					comm.Parameters.AddWithValue("@VerificationImage", b.VerificationImage);
					comm.Parameters.AddWithValue("@FullName", b.FullName);
					comm.Parameters.AddWithValue("@Country", b.Country);
					comm.Parameters.AddWithValue("@State", b.State);
					comm.Parameters.AddWithValue("@Message", b.Message);
					comm.Parameters.AddWithValue("@Gender", b.Gender);
					comm.Parameters.AddWithValue("@Male", b.Male);
					comm.Parameters.AddWithValue("@Female", b.Female);
					comm.Parameters.AddWithValue("@Unspecified", b.Unspecified);
					comm.Parameters.AddWithValue("@EnterNosHere", b.EnterNosHere);
					comm.Parameters.AddWithValue("@CompleteThisForm", b.CompleteThisForm);
					comm.Parameters.AddWithValue("@BackToGuestbook", b.BacktoGuestbook);
					comm.Parameters.AddWithValue("@BoldField", b.Boldfield);
					comm.Parameters.AddWithValue("@EnterFullName", b.EnterFullName);
					comm.Parameters.AddWithValue("@EnterEmailAddress", b.EnterEmailAddress);
					comm.Parameters.AddWithValue("@EnterMessage", b.EnterMessage);
					comm.Parameters.AddWithValue("@EnterVerificationImage", b.EnterVerificationImage);
					comm.Parameters.AddWithValue("@ValidEmailAddress", b.ValidEmailAddress);
					comm.Parameters.AddWithValue("@VerificationDidNotMatch", b.VerificationDidNotMatch);
					comm.Parameters.AddWithValue("@Cancel", b.Cancel);
					comm.Parameters.AddWithValue("@Submit", b.Submit);
					comm.Parameters.AddWithValue("@BlockedIP", b.BlockedIP);
					comm.Parameters.AddWithValue("@SubmissionMessage", b.SubmissionMessage);
					comm.Parameters.AddWithValue("@BadLanguage", b.BadLanguage);
					comm.Parameters.AddWithValue("@SelectCountry", b.SelectCountry);
					comm.Parameters.AddWithValue("@SelectState", b.SelectState);
					comm.Parameters.AddWithValue("@EnterHomepage", b.EnterHomepage);
					comm.Parameters.AddWithValue("@ValidHomepageURL", b.ValidHomepageURL);
					comm.Parameters.AddWithValue("@ValidGuestbookURL", b.ValidGuestbookURL);
					comm.Parameters.AddWithValue("@SubmissionDate", b.SubmissionDate);
					comm.Parameters.AddWithValue("@EnterGuestbook", b.EnterGuestbook);
					try
					{
						conn.Open();
						comm.ExecuteNonQuery();
						bRet = true;
					}
					catch (SqlException ex)
					{
						_SQLEx = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
			return bRet;
		}

#endregion

#region  IP Address Functions 


		/// <summary>
		/// Checks the database for the supplied IPAddress and determines if it is blocked from submitting to the guestbook.
		/// </summary>
		public bool CheckForBlockedIP(string IPAddress)
		{
			bool bRet = false;
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Select ID from gb_ExcludedIPs where IPAddress = @IPAddress", conn))
				{
					comm.Parameters.AddWithValue("@IPAddress", IPAddress);
					try
					{
						conn.Open();
						object b = comm.ExecuteScalar();

						if (b != null)
						{
							bRet = true;
						}
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
					finally
					{
						if (conn.State == ConnectionState.Open)
						{
							conn.Close();
						}
					}
				}
			}
			return bRet;
		}


		/// <summary>
		/// Gets all blocked IPs from the database
		/// </summary>
		public DataTable GetBlockedIPs()
		{
			DataTable dtinfo = new DataTable();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlDataAdapter da = new SqlDataAdapter("Select * from gb_ExcludedIPs", conn))
				{
					try
					{
						da.Fill(dtinfo);
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
				}
			}
			return dtinfo;
		}


		/// <summary>
		/// Allows for admins to remove blocked IP addresses from the database
		/// </summary>
		public void DeleteIPAddress(string ID)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Delete from gb_ExcludedIPs where Id = @Id", conn))
				{
					comm.Parameters.AddWithValue("@Id", ID);
					try
					{
						conn.Open();
						comm.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
		}


		/// <summary>
		/// Updates an IP Address in the database
		/// </summary>
		public void UpdateIPAddress(string IPAddress, string ID)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Update gb_ExcludedIPs Set IPAddress = @IPAddress where Id = @Id", conn))
				{
					comm.Parameters.AddWithValue("@IPAddress", IPAddress);
					comm.Parameters.AddWithValue("@Id", ID);
					try
					{
						conn.Open();
						comm.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
		}


		/// <summary>
		/// Allows for admins to add a new IP Address for which to block from posting on the site
		/// </summary>
		public void InsertsNewIPAddress(string IPAddress)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Insert into gb_ExcludedIPs(IPAddress)values(@IPAddress)", conn))
				{
					comm.Parameters.AddWithValue("@IPAddress", IPAddress);
					try
					{
						conn.Open();
						comm.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
		}

#endregion

#region  Site Settings Functions 

		public SiteSettings LoadSiteSettings()
		{
			SiteSettings b = new SiteSettings();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Select * from gb_SiteSettings", conn))
				{
					try
					{
						conn.Open();
						SqlDataReader dr = comm.ExecuteReader(CommandBehavior.CloseConnection);

						if (dr.Read() == true)
						{
							b.AdminEmail = dr["AdminEmail"].ToString();
							b.DemoMode = Convert.ToBoolean(dr["DemoMode"]);
							b.DisplayCountry = Convert.ToBoolean(dr["DisplayCountry"]);
							b.DisplayEmail = Convert.ToBoolean(dr["DisplayEmail"]);
							b.DisplayFullName = Convert.ToBoolean(dr["DisplayFullName"]);
							b.DisplayGender = Convert.ToBoolean(dr["DisplayGender"]);
							b.DisplayGuestbook = Convert.ToBoolean(dr["DisplayGuestbook"]);
							b.DisplayHomepage = Convert.ToBoolean(dr["DisplayHomepage"]);
							b.DisplayMessage = Convert.ToBoolean(dr["DisplayMessage"]);
							b.DisplayState = Convert.ToBoolean(dr["DisplayState"]);
							b.EnableErrorTracking = Convert.ToBoolean(dr["EnableErrorTracking"]);
							b.GuestbookGridSize = Convert.ToInt16(dr["GuestbookGridSize"]);
							b.GuestBookTitle = Convert.ToString(dr["GuestbookTitle"]);
							b.LanguageFilter = dr["LanguageFilter"].ToString();
							b.MailServer = dr["MailServer"].ToString();
							b.MetaDescription = dr["MetaDescription"].ToString();
							b.MetaKeywords = dr["MetaKeywords"].ToString();
							b.RequireApproval = Convert.ToBoolean(dr["RequireApproval"]);
							b.RequireCountry = Convert.ToBoolean(dr["RequireCountry"]);
							b.RequireEmail = Convert.ToBoolean(dr["RequireEmail"]);
							b.RequireFullName = Convert.ToBoolean(dr["RequireFullName"]);
							b.RequireGender = Convert.ToBoolean(dr["RequireGender"]);
							b.RequireGuestbook = Convert.ToBoolean(dr["RequireGuestbook"]);
							b.RequireHomepage = Convert.ToBoolean(dr["RequireHomepage"]);
							b.RequireMessage = Convert.ToBoolean(dr["RequireMessage"]);
							b.RequireState = Convert.ToBoolean(dr["RequireState"]);
							b.SendEmailWithNewPost = Convert.ToBoolean(dr["SendEmailWithPost"]);
							b.ShowPoweredBy = Convert.ToBoolean(dr["ShowPoweredBy"]);
							b.SiteTitle = Convert.ToString(dr["SiteTitle"]);
						}

						dr.Close();
					}
					catch (SqlException ex)
					{
						throw;
					}
					finally
					{
						if (conn.State == ConnectionState.Open)
						{
							conn.Close();
						}
					}
				}
			}
			return b;
		}

		public bool UpdatingSiteSettings(SiteSettings b)
		{
			bool bRet = true;
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Update gb_SiteSettings Set MetaKeywords = @MetaKeywords, MetaDescription = @MetaDescription, SiteTitle = @SiteTitle, GuestbookTitle = @GuestbookTitle, " + "GuestbookGridSize = @GuestbookGridSize, DemoMode = @DemoMode, LanguageFilter = @LanguageFilter, ShowPoweredBy = @ShowPoweredBy, AdminEmail = @AdminEmail, " + "RequireApproval = @RequireApproval, SendEmailWithPost = @SendEmailWithPost, MailServer = @MailServer, EnableErrorTracking = @EnableErrorTracking, RequireFullName = @RequireFullName, " + "RequireCountry = @RequireCountry, RequireState = @RequireState, RequireEmail = @RequireEmail, RequireHomepage = @RequireHomepage, RequireGuestbook = @RequireGuestbook, " + "RequireGender = @RequireGender, RequireMessage = @RequireMessage, DisplayFullName = @DisplayFullName, DisplayCountry = @DisplayCountry, DisplayState = @DisplayState, " + "DisplayEmail = @DisplayEmail, DisplayHomepage = @DisplayHomepage, DisplayGuestbook = @DisplayGuestbook, DisplayGender = @DisplayGender, DisplayMessage = @DisplayMessage", conn))
				{
					comm.Parameters.AddWithValue("@MetaKeywords", b.MetaKeywords);
					comm.Parameters.AddWithValue("@MetaDescription", b.MetaDescription);
					comm.Parameters.AddWithValue("@SiteTitle", b.SiteTitle);
					comm.Parameters.AddWithValue("@GuestbookTitle", b.GuestBookTitle);
					comm.Parameters.AddWithValue("@GuestbookGridSize", b.GuestbookGridSize);
					comm.Parameters.AddWithValue("@DemoMode", b.DemoMode);
					comm.Parameters.AddWithValue("@LanguageFilter", b.LanguageFilter);
					comm.Parameters.AddWithValue("@ShowPoweredBy", b.ShowPoweredBy);
					comm.Parameters.AddWithValue("@AdminEmail", b.AdminEmail);
					comm.Parameters.AddWithValue("@RequireApproval", b.RequireApproval);
					comm.Parameters.AddWithValue("@SendEmailWithPost", b.SendEmailWithNewPost);
					comm.Parameters.AddWithValue("@MailServer", b.MailServer);
					comm.Parameters.AddWithValue("@EnableErrorTracking", b.EnableErrorTracking);
					comm.Parameters.AddWithValue("@RequireFullName", b.RequireFullName);
					comm.Parameters.AddWithValue("@RequireCountry", b.RequireCountry);
					comm.Parameters.AddWithValue("@RequireState", b.RequireState);
					comm.Parameters.AddWithValue("@RequireEmail", b.RequireEmail);
					comm.Parameters.AddWithValue("@RequireHomepage", b.RequireHomepage);
					comm.Parameters.AddWithValue("@RequireGuestbook", b.RequireGuestbook);
					comm.Parameters.AddWithValue("@RequireGender", b.RequireGender);
					comm.Parameters.AddWithValue("@RequireMessage", b.RequireMessage);
					comm.Parameters.AddWithValue("@DisplayFullName", b.DisplayFullName);
					comm.Parameters.AddWithValue("@DisplayCountry", b.DisplayCountry);
					comm.Parameters.AddWithValue("@DisplayState", b.DisplayState);
					comm.Parameters.AddWithValue("@DisplayEmail", b.DisplayEmail);
					comm.Parameters.AddWithValue("@DisplayHomepage", b.DisplayHomepage);
					comm.Parameters.AddWithValue("@DisplayGuestbook", b.DisplayGuestbook);
					comm.Parameters.AddWithValue("@DisplayGender", b.DisplayGender);
					comm.Parameters.AddWithValue("@DisplayMessage", b.DisplayMessage);
					try
					{
						conn.Open();
						comm.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						bRet = false;
						_SQLEx = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
			return bRet;
		}

#endregion

#region  User Functions 

		/// <summary>
		/// Authenticates a user and returns a boolean value for whether a user is valid or not
		/// </summary>
		public string AuthenticateUser(string UserName, string EncPassword)
		{
			string str = string.Empty;
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Select Guid from gb_UserAccounts where UserName = @UserName and Password = @Password", conn))
				{
					comm.Parameters.AddWithValue("@UserName", UserName);
					comm.Parameters.AddWithValue("@Password", EncPassword);
					try
					{
						conn.Open();
						object b = comm.ExecuteScalar();

						if (b != null)
						{
							str = b.ToString();
						}
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
			return str;
		}


		/// <summary>
		/// Allows for a new admin person to be added to the database
		/// </summary>
		public void AddNewUser(string fullname, string UserName, string Password)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Insert into gb_UserAccounts([Guid], [UserName], [FullName], [Password])values(@Guid, @UserName, @FullName, @Password)", conn))
				{
					comm.Parameters.AddWithValue("@Guid", Guid.NewGuid().ToString());
					comm.Parameters.AddWithValue("@UserName", UserName);
					comm.Parameters.AddWithValue("@FullName", fullname);
					comm.Parameters.AddWithValue("@Password", Password);
					try
					{
						conn.Open();
						comm.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
		}


		/// <summary>
		/// Allows for a users Full Name and Email to be updated.
		/// </summary>
		public void UpdataUserInformation(string Email, string FullName, string ID)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Update gb_UserAccounts Set UserName = @UserName, Fullname = @Fullname where Id = @Id", conn))
				{
					comm.Parameters.AddWithValue("@UserName", Email);
					comm.Parameters.AddWithValue("@Fullname", FullName);
					comm.Parameters.AddWithValue("@Id", ID);
					try
					{
						conn.Open();
						comm.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
		}


		/// <summary>
		/// Allows you to delete a user based on the users database ID, not the GUID
		/// </summary>
		public void DeleteUserByID(string ID)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Delete from gb_UserAccounts where Id = @Id", conn))
				{
					comm.Parameters.AddWithValue("@Id", ID);
					try
					{
						conn.Open();
						comm.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
		}


		/// <summary>
		/// Retrieve all users from the User Accounts table
		/// </summary>
		public DataTable GetUsers()
		{
			DataTable dtinfo = new DataTable();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlDataAdapter da = new SqlDataAdapter("Select * from gb_UserAccounts", conn))
				{
					try
					{
						da.Fill(dtinfo);
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
				}
			}
			return dtinfo;
		}


		/// <summary>
		/// Gets information about a user when passed the users GUID
		/// </summary>
		public DataTable GetUserInfo(string UserID)
		{
			DataTable dtinfo = new DataTable();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlDataAdapter da = new SqlDataAdapter("Select * from gb_UserAccounts where [GUID] = @GUID", conn))
				{
					da.SelectCommand.Parameters.AddWithValue("@GUID", UserID);
					try
					{
						da.Fill(dtinfo);
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
				}
			}
			return dtinfo;
		}


		/// <summary>
		/// Gets a users password from the database based on the users database id
		/// </summary>
		public string ForgotPassword(string ID)
		{
			string str = string.Empty;
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand comm = new SqlCommand("Select Password from gb_UserAccounts where Id = @Id", conn))
				{
					comm.Parameters.AddWithValue("@Id", ID);
					try
					{
						conn.Open();
						object b = comm.ExecuteScalar();

						if (b != null)
						{
							str = b.ToString();
						}
					}
					catch (SqlException ex)
					{
						SQLError = ex;
					}
					finally
					{
						conn.Close();
					}
				}
			}
			return str;
		}

#endregion

	}

}