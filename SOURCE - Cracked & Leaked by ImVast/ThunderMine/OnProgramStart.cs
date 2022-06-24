using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows;

namespace ThunderMine
{
	// Token: 0x02000007 RID: 7
	internal class OnProgramStart
	{
		// Token: 0x06000044 RID: 68 RVA: 0x00002560 File Offset: 0x00000760
		public static void Initialize(string name, string aid, string secret, string version)
		{
			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(aid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version) || name.Contains("APPNAME"))
			{
				MessageBox.Show("Failed to initialize your application correctly in Program.cs!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			OnProgramStart.AID = aid;
			OnProgramStart.Secret = secret;
			OnProgramStart.Version = version;
			OnProgramStart.Name = name;
			string[] array = new string[0];
			using (WebClient webClient = new WebClient())
			{
				try
				{
					webClient.Proxy = null;
					Security.Start();
					Encoding @default = Encoding.Default;
					WebClient webClient2 = webClient;
					string apiUrl = Constants.ApiUrl;
					NameValueCollection nameValueCollection = new NameValueCollection();
					nameValueCollection["token"] = Encryption.EncryptService(Constants.Token);
					nameValueCollection["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString());
					nameValueCollection["aid"] = Encryption.APIService(OnProgramStart.AID);
					nameValueCollection["session_id"] = Constants.IV;
					nameValueCollection["api_id"] = Constants.APIENCRYPTSALT;
					nameValueCollection["api_key"] = Constants.APIENCRYPTKEY;
					nameValueCollection["session_key"] = Constants.Key;
					nameValueCollection["secret"] = Encryption.APIService(OnProgramStart.Secret);
					nameValueCollection["type"] = Encryption.APIService("start");
					array = Encryption.DecryptService(@default.GetString(webClient2.UploadValues(apiUrl, nameValueCollection))).Split("|".ToCharArray());
					string a = array[2];
					if (!(a == "success"))
					{
						if (a == "binderror")
						{
							MessageBox.Show(Encryption.Decode("RmFpbGVkIHRvIGJpbmQgdG8gc2VydmVyLCBjaGVjayB5b3VyIEFJRCAmIFNlY3JldCBpbiB5b3VyIGNvZGUh"), OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
							Process.GetCurrentProcess().Kill();
							return;
						}
						if (a == "banned")
						{
							MessageBox.Show("This application has been banned for violating the TOS" + Environment.NewLine + "Contact us at support@auth.gg", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
							Process.GetCurrentProcess().Kill();
							return;
						}
					}
					else
					{
						Constants.Initialized = true;
						if (array[3] == "Enabled")
						{
							ApplicationSettings.Status = true;
						}
						if (array[4] == "Enabled")
						{
							ApplicationSettings.DeveloperMode = false;
						}
						ApplicationSettings.Hash = array[5];
						ApplicationSettings.Version = array[6];
						ApplicationSettings.Update_Link = array[7];
						if (array[8] == "Enabled")
						{
							ApplicationSettings.Freemode = true;
						}
						if (array[9] == "Enabled")
						{
							ApplicationSettings.Login = true;
						}
						ApplicationSettings.Name = array[10];
						if (array[11] == "Enabled")
						{
							ApplicationSettings.Register = true;
						}
						ApplicationSettings.TotalUsers = array[13];
						if (ApplicationSettings.DeveloperMode)
						{
							MessageBox.Show("Application is in Developer Mode, bypassing integrity and update check!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
						}
						else
						{
							array[12] == "Enabled";
							if (ApplicationSettings.Version != OnProgramStart.Version)
							{
								MessageBox.Show("Update " + ApplicationSettings.Version + " available, redirecting to update!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
								Process.Start(ApplicationSettings.Update_Link);
								Process.GetCurrentProcess().Kill();
							}
						}
						if (!ApplicationSettings.Status)
						{
							MessageBox.Show("Looks like this application is disabled, please try again later!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
							Process.GetCurrentProcess().Kill();
						}
					}
					Security.End();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
					Process.GetCurrentProcess().Kill();
				}
			}
		}

		// Token: 0x0400002C RID: 44
		public static string AID;

		// Token: 0x0400002D RID: 45
		public static string Secret;

		// Token: 0x0400002E RID: 46
		public static string Version;

		// Token: 0x0400002F RID: 47
		public static string Name;

		// Token: 0x04000030 RID: 48
		public static string Salt;
	}
}
