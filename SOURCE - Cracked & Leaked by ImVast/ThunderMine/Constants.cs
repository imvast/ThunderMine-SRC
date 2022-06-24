using System;
using System.Linq;
using System.Security.Principal;

namespace ThunderMine
{
	// Token: 0x02000004 RID: 4
	internal class Constants
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002342 File Offset: 0x00000542
		// (set) Token: 0x0600000B RID: 11 RVA: 0x00002349 File Offset: 0x00000549
		public static string Token { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002351 File Offset: 0x00000551
		// (set) Token: 0x0600000D RID: 13 RVA: 0x00002358 File Offset: 0x00000558
		public static string Date { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002360 File Offset: 0x00000560
		// (set) Token: 0x0600000F RID: 15 RVA: 0x00002367 File Offset: 0x00000567
		public static string APIENCRYPTKEY { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000010 RID: 16 RVA: 0x0000236F File Offset: 0x0000056F
		// (set) Token: 0x06000011 RID: 17 RVA: 0x00002376 File Offset: 0x00000576
		public static string APIENCRYPTSALT { get; set; }

		// Token: 0x06000012 RID: 18 RVA: 0x0000237E File Offset: 0x0000057E
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
			select s[Constants.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000023B9 File Offset: 0x000005B9
		public static string HWID()
		{
			return WindowsIdentity.GetCurrent().User.Value;
		}

		// Token: 0x0400000F RID: 15
		public static bool Breached = false;

		// Token: 0x04000010 RID: 16
		public static bool Started = false;

		// Token: 0x04000011 RID: 17
		public static string IV = null;

		// Token: 0x04000012 RID: 18
		public static string Key = null;

		// Token: 0x04000013 RID: 19
		public static string ApiUrl = "https://api.auth.gg/csharp/";

		// Token: 0x04000014 RID: 20
		public static bool Initialized = false;

		// Token: 0x04000015 RID: 21
		public static Random random = new Random();
	}
}
