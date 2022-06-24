using System;

namespace ThunderMine
{
	// Token: 0x02000006 RID: 6
	internal class ApplicationSettings
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000024C2 File Offset: 0x000006C2
		// (set) Token: 0x06000030 RID: 48 RVA: 0x000024C9 File Offset: 0x000006C9
		public static bool Status { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000024D1 File Offset: 0x000006D1
		// (set) Token: 0x06000032 RID: 50 RVA: 0x000024D8 File Offset: 0x000006D8
		public static bool DeveloperMode { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000024E0 File Offset: 0x000006E0
		// (set) Token: 0x06000034 RID: 52 RVA: 0x000024E7 File Offset: 0x000006E7
		public static string Hash { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000024EF File Offset: 0x000006EF
		// (set) Token: 0x06000036 RID: 54 RVA: 0x000024F6 File Offset: 0x000006F6
		public static string Version { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000024FE File Offset: 0x000006FE
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00002505 File Offset: 0x00000705
		public static string Update_Link { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000039 RID: 57 RVA: 0x0000250D File Offset: 0x0000070D
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002514 File Offset: 0x00000714
		public static bool Freemode { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600003B RID: 59 RVA: 0x0000251C File Offset: 0x0000071C
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00002523 File Offset: 0x00000723
		public static bool Login { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600003D RID: 61 RVA: 0x0000252B File Offset: 0x0000072B
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00002532 File Offset: 0x00000732
		public static string Name { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600003F RID: 63 RVA: 0x0000253A File Offset: 0x0000073A
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002541 File Offset: 0x00000741
		public static bool Register { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002549 File Offset: 0x00000749
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00002550 File Offset: 0x00000750
		public static string TotalUsers { get; set; }
	}
}
