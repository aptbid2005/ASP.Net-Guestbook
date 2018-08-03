To log into the Admin site browse to http://<YourGuestbookURL>/Admin

UserID:     Admin
Password:   Admin

Please be sure to change this accounts password once you log in.


DATABASE SETTINGS:
The MSSQL_Guestbook.zip file in the App_data folder, unzip and attach the mdf and ldf to your server.


Example Connection Strings:

Data Source=<< Server Name or IP Here >>;Persist Security Info=True;pwd=<< Password here >>;User ID=<< User ID Here >>;Initial Catalog=Guestbook;
Provider Name = System.Data.SqlClient