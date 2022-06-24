using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading;

namespace ThunderMine
{
	// Token: 0x0200000B RID: 11
	internal class InfoManager
	{
		// Token: 0x0600005F RID: 95 RVA: 0x00004255 File Offset: 0x00002455
		public InfoManager()
		{
			this.lastGateway = this.GetGatewayMAC();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000426C File Offset: 0x0000246C
		public static IPAddress GetDefaultGateway()
		{
			return (from a in (from n in NetworkInterface.GetAllNetworkInterfaces()
			where n.OperationalStatus == OperationalStatus.Up
			where n.NetworkInterfaceType != NetworkInterfaceType.Loopback
			select n).SelectMany(delegate(NetworkInterface n)
			{
				IPInterfaceProperties ipproperties = n.GetIPProperties();
				if (ipproperties == null)
				{
					return null;
				}
				return ipproperties.GatewayAddresses;
			}).Select(delegate(GatewayIPAddressInformation g)
			{
				if (g == null)
				{
					return null;
				}
				return g.Address;
			})
			where a != null
			select a).FirstOrDefault<IPAddress>();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004338 File Offset: 0x00002538
		private string GetArpTable()
		{
			string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
			string result;
			using (Process process = Process.Start(new ProcessStartInfo
			{
				FileName = pathRoot + "Windows\\System32\\arp.exe",
				Arguments = "-a",
				UseShellExecute = false,
				RedirectStandardOutput = true,
				CreateNoWindow = true
			}))
			{
				using (StreamReader standardOutput = process.StandardOutput)
				{
					result = standardOutput.ReadToEnd();
				}
			}
			return result;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000043D0 File Offset: 0x000025D0
		private string GetGatewayMAC()
		{
			string arg = InfoManager.GetDefaultGateway().ToString();
			return new Regex(string.Format("({0} [\\W]*) ([a-z0-9-]*)", arg)).Match(this.GetArpTable()).Groups[2].ToString();
		}

		// Token: 0x04000032 RID: 50
		private Timer timer;

		// Token: 0x04000033 RID: 51
		private string lastGateway;
	}
}
