using System;
using System.Collections.Generic;

namespace ThunderMine
{
	// Token: 0x02000003 RID: 3
	internal class App
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000022C8 File Offset: 0x000004C8
		public static string GrabVariable(string name)
		{
			string result;
			try
			{
				if (User.ID != null || User.HWID != null || User.IP != null || !Constants.Breached)
				{
					result = App.Variables[name];
				}
				else
				{
					Constants.Breached = true;
					result = "User is not logged in, possible breach detected!";
				}
			}
			catch
			{
				result = "N/A";
			}
			return result;
		}

		// Token: 0x04000009 RID: 9
		public static string Error = null;

		// Token: 0x0400000A RID: 10
		public static Dictionary<string, string> Variables = new Dictionary<string, string>();
	}
}
