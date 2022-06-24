using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ThunderMine
{
	// Token: 0x0200000A RID: 10
	internal class Encryption
	{
		// Token: 0x06000058 RID: 88 RVA: 0x00003F98 File Offset: 0x00002198
		public static string APIService(string value)
		{
			string @string = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
			byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(@string));
			byte[] bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)));
			return Encryption.EncryptString(value, key, bytes);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003FF8 File Offset: 0x000021F8
		public static string EncryptService(string value)
		{
			string @string = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
			byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(@string));
			byte[] bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)));
			string str = Encryption.EncryptString(value, key, bytes);
			int length = int.Parse(OnProgramStart.AID.Substring(0, 2));
			return str + Security.Obfuscate(length);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004074 File Offset: 0x00002274
		public static string DecryptService(string value)
		{
			string @string = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
			byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(@string));
			byte[] bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)));
			return Encryption.DecryptString(value, key, bytes);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000040D4 File Offset: 0x000022D4
		public static string EncryptString(string plainText, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Key = key;
			aes.IV = iv;
			MemoryStream memoryStream = new MemoryStream();
			ICryptoTransform transform = aes.CreateEncryptor();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] bytes = Encoding.ASCII.GetBytes(plainText);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			byte[] array = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(array, 0, array.Length);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004150 File Offset: 0x00002350
		public static string DecryptString(string cipherText, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Key = key;
			aes.IV = iv;
			MemoryStream memoryStream = new MemoryStream();
			ICryptoTransform transform = aes.CreateDecryptor();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			string result = string.Empty;
			try
			{
				byte[] array = Convert.FromBase64String(cipherText);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.FlushFinalBlock();
				byte[] array2 = memoryStream.ToArray();
				result = Encoding.ASCII.GetString(array2, 0, array2.Length);
			}
			finally
			{
				memoryStream.Close();
				cryptoStream.Close();
			}
			return result;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000041EC File Offset: 0x000023EC
		public static string Decode(string text)
		{
			text = text.Replace('_', '/').Replace('-', '+');
			int num = text.Length % 4;
			if (num != 2)
			{
				if (num == 3)
				{
					text += "=";
				}
			}
			else
			{
				text += "==";
			}
			return Encoding.UTF8.GetString(Convert.FromBase64String(text));
		}
	}
}
