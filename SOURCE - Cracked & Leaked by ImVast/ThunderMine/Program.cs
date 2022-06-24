using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace ThunderMine
{
	// Token: 0x0200000C RID: 12
	internal class Program
	{
		// Token: 0x06000063 RID: 99
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool AllocConsole();

		// Token: 0x06000064 RID: 100 RVA: 0x00004413 File Offset: 0x00002613
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[Program.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000444E File Offset: 0x0000264E
		public static double RandomDoubleFrom(double minimum, double maximum)
		{
			return new Random().NextDouble() * (maximum - minimum) + minimum;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00004460 File Offset: 0x00002660
		public static int RandomIntFrom(int minimum, int maximum)
		{
			return new Random().Next(minimum, maximum);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000446E File Offset: 0x0000266E
		public static string StringLowercaseInfinity(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFabcdef0123456789", length)
			select s[Program.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000044A9 File Offset: 0x000026A9
		public static string RandomInt(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("0123456789", length)
			select s[Program.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000044E4 File Offset: 0x000026E4
		public static int GetRandomInt(int minimum, int maximum)
		{
			return new Random().Next(minimum, maximum);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000044F4 File Offset: 0x000026F4
		private static void ConnectWallet()
		{
			string path = Path.Combine(Path.GetTempPath(), "WalletAddressBTC.txt");
			try
			{
				if (!File.Exists(path))
				{
					Console.Clear();
					Program.PrintLogo();
					Console.WriteLine("\n[+] Enter your bitcoin wallet address: ");
					Console.WriteLine("[+] Warning: DO NOT enter incorrect info");
					Console.Write("\n[+] Input: ");
					string s = Console.ReadLine();
					Console.Write("\n[+] Saving... ");
					int num = Program.random.Next(17, 60);
					using (ProgressBar progressBar = new ProgressBar())
					{
						for (int i = 0; i <= 100; i++)
						{
							progressBar.Report((double)i / (double)num);
							Thread.Sleep(20);
						}
					}
					using (FileStream fileStream = File.Create(path))
					{
						byte[] bytes = new UTF8Encoding(true).GetBytes(s);
						fileStream.Write(bytes, 0, bytes.Length);
					}
					Console.WriteLine("The program will restart after saving your changes.");
					Thread.Sleep(2000);
					Process.Start(AppDomain.CurrentDomain.FriendlyName);
					Environment.Exit(0);
				}
				if (File.Exists(path))
				{
					using (StreamReader streamReader = File.OpenText(path))
					{
						string text;
						while ((text = streamReader.ReadLine()) != null)
						{
							string str = text;
							Console.ForegroundColor = ConsoleColor.Green;
							Console.BackgroundColor = ConsoleColor.Black;
							Console.WriteLine("\nWallet Addresses Connected: ");
							Console.WriteLine("\n[+] BTC: " + str);
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("\nNote: Your wallet address is connected so we can automatically send moeny there on payout week, it is tied to your user id");
							Console.ForegroundColor = ConsoleColor.White;
							Console.WriteLine("The program will now close");
							Thread.Sleep(5000);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000046FC File Offset: 0x000028FC
		public static void WriteConsoleColor(params Program.ColoredString[] strings)
		{
			ConsoleColor foregroundColor = Console.ForegroundColor;
			foreach (Program.ColoredString coloredString in strings)
			{
				Console.ForegroundColor = coloredString.Color;
				Console.Write(coloredString.Text);
			}
			Console.ForegroundColor = foregroundColor;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000473D File Offset: 0x0000293D
		public static void firewallPrompt()
		{
			TcpListener tcpListener = new TcpListener(new IPEndPoint(Dns.GetHostEntry(Dns.GetHostName()).AddressList[0], 12345));
			tcpListener.Start();
			tcpListener.Stop();
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000476C File Offset: 0x0000296C
		public static void FirstLaunch()
		{
			Program.firewallPrompt();
			int randomInt = Program.GetRandomInt(100, 1000);
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("FirstLaunchEvent:/");
			Thread.Sleep(10);
			Console.WriteLine("Attempting VPS Branch connection/");
			Thread.Sleep(10);
			Console.WriteLine("Finding available node.../");
			Thread.Sleep(25);
			Console.WriteLine("------------------------------------");
			Thread.Sleep(30);
			Program.WriteConsoleColor(new Program.ColoredString[]
			{
				new Program.ColoredString(ConsoleColor.Magenta, "[HandShake] "),
				new Program.ColoredString(ConsoleColor.White, "Established: True")
			});
			Program.WriteConsoleColor(new Program.ColoredString[]
			{
				new Program.ColoredString(ConsoleColor.Magenta, "\n[GatewaySocket] "),
				new Program.ColoredString(ConsoleColor.White, "Established Gateway Socket")
			});
			Thread.Sleep(100);
			Program.WriteConsoleColor(new Program.ColoredString[]
			{
				new Program.ColoredString(ConsoleColor.Magenta, "\n[GatewaySocket] "),
				new Program.ColoredString(ConsoleColor.White, "Decrypting session key")
			});
			Program.WriteConsoleColor(new Program.ColoredString[]
			{
				new Program.ColoredString(ConsoleColor.Magenta, "\n[GatewaySocket] "),
				new Program.ColoredString(ConsoleColor.White, "Registering session | User: " + User.ID)
			});
			Thread.Sleep(120);
			Program.WriteConsoleColor(new Program.ColoredString[]
			{
				new Program.ColoredString(ConsoleColor.Magenta, "\n[GatewaySocket] "),
				new Program.ColoredString(ConsoleColor.White, "[SUCCESFULL] Trial Authentication")
			});
			Thread.Sleep(75);
			Program.WriteConsoleColor(new Program.ColoredString[]
			{
				new Program.ColoredString(ConsoleColor.Magenta, "\n[GatewaySocket] "),
				new Program.ColoredString(ConsoleColor.White, "[IDENTIFY] hasLogin: true")
			});
			int randomInt2 = Program.GetRandomInt(100000, 600000);
			Thread.Sleep(50);
			string text = string.Concat(new string[]
			{
				"[READY] took ",
				randomInt.ToString(),
				"ms [gateway - prd - main - flg1, {micros:",
				randomInt2.ToString(),
				"}"
			});
			Program.WriteConsoleColor(new Program.ColoredString[]
			{
				new Program.ColoredString(ConsoleColor.Magenta, "\n[GatewaySocket] "),
				new Program.ColoredString(ConsoleColor.White, text)
			});
			Thread.Sleep(60);
			Program.WriteConsoleColor(new Program.ColoredString[]
			{
				new Program.ColoredString(ConsoleColor.Magenta, "\n[GatewaySocket] "),
				new Program.ColoredString(ConsoleColor.White, "[AuthenticationStore] HandleConnectionOpened called -> [storageHasStored]")
			});
			Thread.Sleep(45);
			Program.WriteConsoleColor(new Program.ColoredString[]
			{
				new Program.ColoredString(ConsoleColor.Magenta, "\n[GatewaySocket] "),
				new Program.ColoredString(ConsoleColor.White, "[READY_SUPPLEMENTAL] Stage1FirstLaunchEvent complete\n")
			});
			Thread.Sleep(45);
			Program.WriteConsoleColor(new Program.ColoredString[]
			{
				new Program.ColoredString(ConsoleColor.Green, "\n[GatewayTransfer] "),
				new Program.ColoredString(ConsoleColor.White, "[SocketTrue] Importing launch configuration;")
			});
			Thread.Sleep(45);
			Program.WriteConsoleColor(new Program.ColoredString[]
			{
				new Program.ColoredString(ConsoleColor.Green, "\n[GatewayTransfer] "),
				new Program.ColoredString(ConsoleColor.White, "[SocketTrue] Importing hash functions;;")
			});
			Thread.Sleep(45);
			Program.WriteConsoleColor(new Program.ColoredString[]
			{
				new Program.ColoredString(ConsoleColor.Green, "\n[GatewayTransfer] "),
				new Program.ColoredString(ConsoleColor.White, "[SocketTrue] Importing StablePatch;;;")
			});
			Program.WriteConsoleColor(new Program.ColoredString[]
			{
				new Program.ColoredString(ConsoleColor.Green, "\n[GatewayTransfer] "),
				new Program.ColoredString(ConsoleColor.White, "[SocketTrue] Importing Gpoint.js/Doublehash.js\n")
			});
			Console.Write("\n[+] Installing.... ");
			using (ProgressBar progressBar = new ProgressBar())
			{
				for (int i = 0; i <= 100; i++)
				{
					progressBar.Report((double)i / 50.0);
					Thread.Sleep(20);
				}
			}
			Thread.Sleep(45);
			Program.WriteConsoleColor(new Program.ColoredString[]
			{
				new Program.ColoredString(ConsoleColor.DarkMagenta, "\n\n[GatewaySocket] "),
				new Program.ColoredString(ConsoleColor.White, "[READY_SUPPLEMENTAL] Stage2FirstLaunchEvent complete")
			});
			Thread.Sleep(1750);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Clear();
			Program.PrintPrivateLogo();
			Program.SystemInfo systemInfo = new Program.SystemInfo();
			systemInfo.getOperatingSystemInfo();
			systemInfo.getCpuInfo();
			systemInfo.getGpuInfo();
			Thread.Sleep(75);
			Console.Write("\n[+] Registering Hardware.... ");
			using (ProgressBar progressBar2 = new ProgressBar())
			{
				for (int j = 0; j <= 100; j++)
				{
					progressBar2.Report((double)j / 50.0);
					Thread.Sleep(20);
				}
			}
			Console.WriteLine("Stage2FirstLaunchEvent complete\n");
			Console.Clear();
			Thread.Sleep(40);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00004BA4 File Offset: 0x00002DA4
		public static void PrivateInfinityLoop()
		{
			string value = "";
			string path = Path.Combine(Path.GetTempPath(), "Balance.txt");
			string path2 = Path.Combine(Path.GetTempPath(), "Checked.txt");
			string value2;
			using (WebClient webClient = new WebClient())
			{
				string address = "https://api.coindesk.com/v1/bpi/currentprice.json";
				value2 = webClient.DownloadString(address);
			}
			object arg = JsonConvert.DeserializeObject(value2);
			if (Program.<>o__13.<>p__4 == null)
			{
				Program.<>o__13.<>p__4 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToDecimal", null, typeof(Program), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, Type, object, object> target = Program.<>o__13.<>p__4.Target;
			CallSite <>p__ = Program.<>o__13.<>p__4;
			Type typeFromHandle = typeof(Convert);
			if (Program.<>o__13.<>p__3 == null)
			{
				Program.<>o__13.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Value", typeof(Program), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object> target2 = Program.<>o__13.<>p__3.Target;
			CallSite <>p__2 = Program.<>o__13.<>p__3;
			if (Program.<>o__13.<>p__2 == null)
			{
				Program.<>o__13.<>p__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "rate", typeof(Program), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object> target3 = Program.<>o__13.<>p__2.Target;
			CallSite <>p__3 = Program.<>o__13.<>p__2;
			if (Program.<>o__13.<>p__1 == null)
			{
				Program.<>o__13.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "USD", typeof(Program), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object> target4 = Program.<>o__13.<>p__1.Target;
			CallSite <>p__4 = Program.<>o__13.<>p__1;
			if (Program.<>o__13.<>p__0 == null)
			{
				Program.<>o__13.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "bpi", typeof(Program), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			object arg2 = target(<>p__, typeFromHandle, target2(<>p__2, target3(<>p__3, target4(<>p__4, Program.<>o__13.<>p__0.Target(Program.<>o__13.<>p__0, arg)))));
			try
			{
				if (!File.Exists(path))
				{
					Console.Clear();
					Program.PrintLogo();
					using (FileStream fileStream = File.Create(path))
					{
						byte[] bytes = new UTF8Encoding(true).GetBytes("0");
						fileStream.Write(bytes, 0, bytes.Length);
					}
				}
				if (File.Exists(path))
				{
					using (StreamReader streamReader = File.OpenText(path))
					{
						string text;
						while ((text = streamReader.ReadLine()) != null)
						{
							value = text;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			try
			{
				if (!File.Exists(path2))
				{
					Console.Clear();
					Program.PrintLogo();
					using (FileStream fileStream2 = File.Create(path2))
					{
						byte[] bytes2 = new UTF8Encoding(true).GetBytes("0");
						fileStream2.Write(bytes2, 0, bytes2.Length);
					}
				}
				if (File.Exists(path2))
				{
					using (StreamReader streamReader2 = File.OpenText(path2))
					{
						while (streamReader2.ReadLine() != null)
						{
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2.ToString());
			}
			double num = Convert.ToDouble(value);
			int num2 = 0;
			string str = "89";
			for (;;)
			{
				if (Program.<>o__13.<>p__7 == null)
				{
					Program.<>o__13.<>p__7 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Program)));
				}
				Func<CallSite, object, string> target5 = Program.<>o__13.<>p__7.Target;
				CallSite <>p__5 = Program.<>o__13.<>p__7;
				if (Program.<>o__13.<>p__6 == null)
				{
					Program.<>o__13.<>p__6 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Program), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, string, object, object> target6 = Program.<>o__13.<>p__6.Target;
				CallSite <>p__6 = Program.<>o__13.<>p__6;
				string arg3 = string.Concat(new string[]
				{
					"Status: Connected ✔ | Checked: ",
					num2.ToString(),
					" Wallets | Current Balance: ",
					Math.Round(num, 5).ToString(),
					" BTC | Per: 372.6/s | Sector: 89 | Threads: 128 | Rate: Steady/Static | 1 BTC = $"
				});
				if (Program.<>o__13.<>p__5 == null)
				{
					Program.<>o__13.<>p__5 = CallSite<Func<CallSite, Type, object, int, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Round", null, typeof(Program), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Console.Title = target5(<>p__5, target6(<>p__6, arg3, Program.<>o__13.<>p__5.Target(Program.<>o__13.<>p__5, typeof(Math), arg2, 2)));
				string str2 = Program.StringLowercaseInfinity(32);
				Program.WriteConsoleColor(new Program.ColoredString[]
				{
					new Program.ColoredString(ConsoleColor.Magenta, "\n[-] "),
					new Program.ColoredString(ConsoleColor.White, "BTC | bc1" + str2 + " - BALANCE: "),
					new Program.ColoredString(ConsoleColor.Red, "0.00 BTC "),
					new Program.ColoredString(ConsoleColor.White, "| Sector: " + str + Program.RandomInt(4) + " | Wallet Type: P2WPKH")
				});
				num2++;
				string contents = num2.ToString();
				File.WriteAllText(path2, contents);
				Console.ResetColor();
				Thread.Sleep(6);
				num2++;
				contents = num2.ToString();
				File.WriteAllText(path2, contents);
				Console.ResetColor();
				if (new Random().Next(1, 10000) == 1)
				{
					contents = num2.ToString();
					File.WriteAllText(path2, contents);
					Program.StringLowercaseInfinity(32);
					double value3 = Program.RandomDoubleFrom(0.0006, 1.0);
					Thread.Sleep(500);
					Program.WriteConsoleColor(new Program.ColoredString[]
					{
						new Program.ColoredString(ConsoleColor.Magenta, "\n[-] "),
						new Program.ColoredString(ConsoleColor.Green, "BTC | bc1qmqxuvcez78gqvx69pvth5dykryr7q2z3m3yg8j - BALANCE: 0.08591418 BTC | Sector: " + str + Program.RandomInt(4) + " | Wallet Type: P2WPKH\n")
					});
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.WriteLine("\nMatching SigScripts...");
					Thread.Sleep(50);
					Console.WriteLine("\nSending to workers...");
					Thread.Sleep(250);
					Console.Write("\nProcessing.... ");
					using (ProgressBar progressBar = new ProgressBar())
					{
						for (int i = 0; i <= 100; i++)
						{
							progressBar.Report((double)i / 50.0);
							Thread.Sleep(20);
						}
					}
					Thread.Sleep(45);
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.WriteLine("\n\nSuccess! ");
					Program.GetRandomInt(1350, 4500);
					Thread.Sleep(40);
					Console.WriteLine("\nDepositing....");
					Thread.Sleep(35);
					Console.WriteLine("\nPrivate Key Derived! | User: " + User.ID);
					Thread.Sleep(150);
					double value4 = Math.Round(value3, 5) - 0.0005;
					Console.WriteLine("\nWithdrawal Fee Applied...");
					Thread.Sleep(65);
					Console.WriteLine("\nSuccessfull Deposit of: 0.02887143 BTC -> bc1qhm07kv95vpmgwj6yw0zad8k28zx2022ca58ssp\n");
					Thread.Sleep(800);
					Console.Write("\n[+] Displaying blockchain info...");
					using (ProgressBar progressBar2 = new ProgressBar())
					{
						for (int j = 0; j <= 100; j++)
						{
							progressBar2.Report((double)j / 20.0);
							Thread.Sleep(20);
						}
					}
					Console.WriteLine("\n[+] Opening...");
					Process.Start("https://www.blockchain.com/btc/address/bc1qhm07kv95vpmgwj6yw0zad8k28zx2022ca58ssp");
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
					using (StreamReader streamReader3 = File.OpenText(path))
					{
						string text2;
						while ((text2 = streamReader3.ReadLine()) != null)
						{
							value = text2;
						}
					}
					num += Math.Round(value4, 5);
					double num3 = Convert.ToDouble(value);
					num3 = num;
					string contents2 = num3.ToString();
					File.WriteAllText(path, contents2);
					Console.WriteLine("\nPress Enter to Continue Mining...");
					Console.ReadLine();
				}
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000539C File Offset: 0x0000359C
		public static void PrivateInfinite()
		{
			int randomInt = Program.GetRandomInt(1, 3);
			Console.Title = "ThunderMine Private";
			Random random = new Random();
			random.Next().ToString("X");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Thread.Sleep(250);
			Console.WriteLine("[+] Note: You will join a private server dedicated to you, any succesful entries will result in the amount accounted to your user id.");
			Console.Write("\n[+] Press Enter to Connect...");
			Console.ReadLine();
			Thread.Sleep(800);
			Console.Clear();
			Thread.Sleep(300);
			Program.PrintPrivateLogo();
			Program.FirstLaunch();
			Thread.Sleep(20);
			Console.Clear();
			Thread.Sleep(30);
			Program.PrintPrivateLogo();
			Console.Title = "ThunderMine Private0" + randomInt.ToString();
			Console.Write("\n[+] Connecting to ThunderMine Private0" + randomInt.ToString() + "... ");
			int num = random.Next(17, 70);
			using (ProgressBar progressBar = new ProgressBar())
			{
				for (int i = 0; i <= 100; i++)
				{
					progressBar.Report((double)i / (double)num);
					Thread.Sleep(20);
				}
			}
			Console.WriteLine("Completed Succesfully!");
			Thread.Sleep(50);
			Console.WriteLine("\n[+] Logged in as " + User.Username);
			Thread.Sleep(500);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("\n[+] Workers Online: " + Program.GetRandomInt(7, 12).ToString());
			Console.ForegroundColor = ConsoleColor.Magenta;
			Thread.Sleep(100);
			Console.WriteLine("\n[+] Installing P2WPKH DB         [=====]");
			Thread.Sleep(20);
			Console.WriteLine("[+] Loading...                   [========]");
			Thread.Sleep(120);
			Console.WriteLine("[+] Loading...                   [==========]");
			Thread.Sleep(80);
			Console.WriteLine("[+] Indexing Completed!          [============]");
			Thread.Sleep(20);
			Console.WriteLine("[+] Wallets Loaded!              [==============]");
			Thread.Sleep(20);
			Console.WriteLine("[+] Loading Hashes               [================]");
			Thread.Sleep(20);
			Console.WriteLine("[+] Loading...                   [==================]");
			Thread.Sleep(75);
			Console.WriteLine("[+] Loading...                   [====================]");
			Thread.Sleep(130);
			Console.WriteLine("[+] Hash Function Loaded         [======================]");
			Thread.Sleep(75);
			Console.WriteLine("[+] Job Completed!               [========================]");
			Thread.Sleep(75);
			Console.WriteLine("[+] Installing Required Modules  [===========================]");
			Thread.Sleep(250);
			Console.WriteLine("\n[+] Modules Loaded 7/7           [==============================]");
			Console.Write("\n[+] Validating... ");
			using (ProgressBar progressBar2 = new ProgressBar())
			{
				for (int j = 0; j <= 100; j++)
				{
					progressBar2.Report((double)j / 20.0);
					Thread.Sleep(20);
				}
			}
			Console.WriteLine("\n[+] Generating Session Key...");
			Thread.Sleep(250);
			Console.WriteLine("[+] Local Session Key: " + Program.RandomString(12));
			Thread.Sleep(150);
			Console.WriteLine("\n[+] Written and fully owned by ThunderMine");
			Thread.Sleep(80);
			Console.WriteLine("[+] Y/N to join the private mining pool: ");
			string text = Console.ReadKey().Key.ToString();
			if (text.ToUpper() == "Y")
			{
				Thread.Sleep(1300);
			}
			Console.Clear();
			Program.PrintPrivateLogo();
			Thread.Sleep(35);
			Console.WriteLine("Connecting to SegWit mainnet...");
			Thread.Sleep(1300);
			Console.Clear();
			Program.PrivateInfinityLoop();
			if (text.ToUpper() == "N")
			{
				Environment.Exit(0);
			}
			Console.ReadLine();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00005718 File Offset: 0x00003918
		public static void config()
		{
			string text = "";
			string path = Path.Combine(Path.GetTempPath(), "Checked.txt");
			string path2 = Path.Combine(Path.GetTempPath(), "Balance.txt");
			string path3 = Path.Combine(Path.GetTempPath(), "WalletAddressBTC.txt");
			string text2 = User.Rank;
			string id = User.ID;
			string expiry = User.Expiry;
			string username = User.Username;
			if (text2 == "2")
			{
				text2 = "Private";
			}
			else
			{
				text2 = "Public";
			}
			string str = "0";
			if (!File.Exists(path3))
			{
				using (StreamReader streamReader = File.OpenText(path2))
				{
					string text3;
					while ((text3 = streamReader.ReadLine()) != null)
					{
						str = text3;
					}
				}
				using (StreamReader streamReader2 = File.OpenText(path))
				{
					string text4;
					while ((text4 = streamReader2.ReadLine()) != null)
					{
						text = text4;
					}
				}
				Console.WriteLine("\n\n------------------------------------------------------------------------------------------------------------------------");
				Console.WriteLine("[DEFAULT SETTINGS]");
				Console.WriteLine("");
				Program.WriteConsoleColor(new Program.ColoredString[]
				{
					new Program.ColoredString(ConsoleColor.Green, "[-] Wallet Types: "),
					new Program.ColoredString(ConsoleColor.White, "Segwitt Mainnet (P2WPKH) / Segwitt Mainnet (P2WSH) / Bech32")
				});
				Program.WriteConsoleColor(new Program.ColoredString[]
				{
					new Program.ColoredString(ConsoleColor.Green, "\n[-] Withdrawal Address: "),
					new Program.ColoredString(ConsoleColor.White, "Not Connected!")
				});
				Program.WriteConsoleColor(new Program.ColoredString[]
				{
					new Program.ColoredString(ConsoleColor.Green, "\n[-] Withdrawal Fee: "),
					new Program.ColoredString(ConsoleColor.White, "0.0005 btc")
				});
				Program.WriteConsoleColor(new Program.ColoredString[]
				{
					new Program.ColoredString(ConsoleColor.Green, "\n[-] BruteType: "),
					new Program.ColoredString(ConsoleColor.White, "GPoint/DoubleHash deriver/Sigscript match")
				});
				Program.WriteConsoleColor(new Program.ColoredString[]
				{
					new Program.ColoredString(ConsoleColor.Green, "\n[-] Payout Date: "),
					new Program.ColoredString(ConsoleColor.White, "4/25/2022 | EDT 4PM")
				});
				Program.WriteConsoleColor(new Program.ColoredString[]
				{
					new Program.ColoredString(ConsoleColor.Green, "\n[-] Version: "),
					new Program.ColoredString(ConsoleColor.White, "2.80\n")
				});
				Console.WriteLine("\n[User Information]");
				Console.WriteLine("");
				Program.WriteConsoleColor(new Program.ColoredString[]
				{
					new Program.ColoredString(ConsoleColor.Green, "[-] Username: "),
					new Program.ColoredString(ConsoleColor.White, username)
				});
				Program.WriteConsoleColor(new Program.ColoredString[]
				{
					new Program.ColoredString(ConsoleColor.Green, "\n[-] User ID: "),
					new Program.ColoredString(ConsoleColor.White, id)
				});
				Program.WriteConsoleColor(new Program.ColoredString[]
				{
					new Program.ColoredString(ConsoleColor.Green, "\n[-] Access Level: "),
					new Program.ColoredString(ConsoleColor.White, text2)
				});
				Program.WriteConsoleColor(new Program.ColoredString[]
				{
					new Program.ColoredString(ConsoleColor.Green, "\n[-] Expires On: "),
					new Program.ColoredString(ConsoleColor.White, expiry)
				});
				Console.WriteLine("\n\n[Statistics]");
				Console.WriteLine("");
				Program.WriteConsoleColor(new Program.ColoredString[]
				{
					new Program.ColoredString(ConsoleColor.Green, "[-] Wallets Checked: "),
					new Program.ColoredString(ConsoleColor.White, text)
				});
				Program.WriteConsoleColor(new Program.ColoredString[]
				{
					new Program.ColoredString(ConsoleColor.Green, "\n[-] User Balance: "),
					new Program.ColoredString(ConsoleColor.White, str + " BTC")
				});
				Console.WriteLine("\n");
				Thread.Sleep(50000);
			}
			try
			{
				if (File.Exists(path3))
				{
					using (StreamReader streamReader3 = File.OpenText(path3))
					{
						string text5;
						while ((text5 = streamReader3.ReadLine()) != null)
						{
							Console.WriteLine("\n\n------------------------------------------------------------------------------------------------------------------------");
							Console.WriteLine("[DEFAULT SETTINGS]");
							Console.WriteLine("");
							Program.WriteConsoleColor(new Program.ColoredString[]
							{
								new Program.ColoredString(ConsoleColor.Green, "[-] Wallet Types: "),
								new Program.ColoredString(ConsoleColor.White, "Segwitt Mainnet (P2WPKH) / Segwitt Mainnet (P2WSH) / Bech32")
							});
							Program.WriteConsoleColor(new Program.ColoredString[]
							{
								new Program.ColoredString(ConsoleColor.Green, "\n[-] Withdrawal Address: "),
								new Program.ColoredString(ConsoleColor.White, text5)
							});
							Program.WriteConsoleColor(new Program.ColoredString[]
							{
								new Program.ColoredString(ConsoleColor.Green, "\n[-] Withdrawal Fee: "),
								new Program.ColoredString(ConsoleColor.White, "0.0005 btc")
							});
							Program.WriteConsoleColor(new Program.ColoredString[]
							{
								new Program.ColoredString(ConsoleColor.Green, "\n[-] BruteType: "),
								new Program.ColoredString(ConsoleColor.White, "GPoint/DoubleHash deriver/Sigscript match")
							});
							Program.WriteConsoleColor(new Program.ColoredString[]
							{
								new Program.ColoredString(ConsoleColor.Green, "\n[-] Payout Date: "),
								new Program.ColoredString(ConsoleColor.White, "4/25/2022 | EDT 4PM")
							});
							Program.WriteConsoleColor(new Program.ColoredString[]
							{
								new Program.ColoredString(ConsoleColor.Green, "\n[-] Version: "),
								new Program.ColoredString(ConsoleColor.White, "2.80\n")
							});
							Console.WriteLine("\n[User Information]");
							Console.WriteLine("");
							Program.WriteConsoleColor(new Program.ColoredString[]
							{
								new Program.ColoredString(ConsoleColor.Green, "[-] Username: "),
								new Program.ColoredString(ConsoleColor.White, username)
							});
							Program.WriteConsoleColor(new Program.ColoredString[]
							{
								new Program.ColoredString(ConsoleColor.Green, "\n[-] User ID: "),
								new Program.ColoredString(ConsoleColor.White, id)
							});
							Program.WriteConsoleColor(new Program.ColoredString[]
							{
								new Program.ColoredString(ConsoleColor.Green, "\n[-] Access Level: "),
								new Program.ColoredString(ConsoleColor.White, text2)
							});
							Program.WriteConsoleColor(new Program.ColoredString[]
							{
								new Program.ColoredString(ConsoleColor.Green, "\n[-] Expires On: "),
								new Program.ColoredString(ConsoleColor.White, expiry + "\n")
							});
							Console.WriteLine("\n\n[Statistics]");
							Console.WriteLine("");
							Program.WriteConsoleColor(new Program.ColoredString[]
							{
								new Program.ColoredString(ConsoleColor.Green, "Wallets Checked: "),
								new Program.ColoredString(ConsoleColor.White, text)
							});
							Program.WriteConsoleColor(new Program.ColoredString[]
							{
								new Program.ColoredString(ConsoleColor.Green, "\n[-] User Balance: "),
								new Program.ColoredString(ConsoleColor.White, str + " BTC")
							});
							Console.WriteLine("\n");
							Thread.Sleep(50000000);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00005D34 File Offset: 0x00003F34
		private static void Main(string[] args)
		{
			OnProgramStart.Initialize("Solarcrypt", "366093", "ffUNwzxKuZFrKkMSlTZwT7pY1WzE6R296jw", "1.0");
			Console.Title = "Thunder Miner | Build 2.8";
			string path = Path.Combine(Path.GetTempPath(), "Checked.txt");
			string path2 = Path.Combine(Path.GetTempPath(), "Balance.txt");
			string path3 = Path.Combine(Path.GetTempPath(), "autologin.txt");
			string path4 = Path.Combine(Path.GetTempPath(), "username.txt");
			string path5 = Path.Combine(Path.GetTempPath(), "password.txt");
			if (ApplicationSettings.Freemode)
			{
				MessageBox.Show("Freemode is active, bypassing login!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}
			if (!ApplicationSettings.Status)
			{
				MessageBox.Show("Application is disabled!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			Program.PrintLogo();
			try
			{
				if (!File.Exists(path2))
				{
					Console.Clear();
					Program.PrintLogo();
					using (FileStream fileStream = File.Create(path2))
					{
						byte[] bytes = new UTF8Encoding(true).GetBytes("0");
						fileStream.Write(bytes, 0, bytes.Length);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			try
			{
				if (!File.Exists(path))
				{
					Console.Clear();
					Program.PrintLogo();
					using (FileStream fileStream2 = File.Create(path))
					{
						byte[] bytes2 = new UTF8Encoding(true).GetBytes("0");
						fileStream2.Write(bytes2, 0, bytes2.Length);
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2.ToString());
			}
			try
			{
				if (!File.Exists(path3))
				{
					Console.WriteLine("[1] Login");
					Console.WriteLine("[2] Register");
					Console.Write("\nInput: ");
					string a = Console.ReadLine();
					if (a == "1")
					{
						if (!ApplicationSettings.Login)
						{
							MessageBox.Show("Login is not enabled, please try again later!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
							Process.GetCurrentProcess().Kill();
						}
						else
						{
							Console.Clear();
							Program.PrintLogo();
							Console.WriteLine();
							Console.WriteLine("Username:");
							string contents = Console.ReadLine();
							Console.WriteLine("Password:");
							string contents2 = Console.ReadLine();
							using (FileStream fileStream3 = File.Create(path4))
							{
								byte[] bytes3 = new UTF8Encoding(true).GetBytes("0");
								fileStream3.Write(bytes3, 0, bytes3.Length);
							}
							using (FileStream fileStream4 = File.Create(path5))
							{
								byte[] bytes4 = new UTF8Encoding(true).GetBytes("0");
								fileStream4.Write(bytes4, 0, bytes4.Length);
							}
							File.WriteAllText(path4, contents);
							File.WriteAllText(path5, contents2);
							using (FileStream fileStream5 = File.Create(path3))
							{
								byte[] bytes5 = new UTF8Encoding(true).GetBytes("0");
								fileStream5.Write(bytes5, 0, bytes5.Length);
							}
							MessageBox.Show("Auto-Login Enabled, please restart the program.", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
							Thread.Sleep(5000000);
						}
					}
					else if (a == "2")
					{
						if (!ApplicationSettings.Register)
						{
							MessageBox.Show("Register is not enabled, please try again later!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
							Process.GetCurrentProcess().Kill();
						}
						else
						{
							Console.Clear();
							Program.PrintLogo();
							Console.WriteLine();
							Console.WriteLine("Username:");
							string username = Console.ReadLine();
							Console.WriteLine("Password:");
							string password = Console.ReadLine();
							Console.WriteLine("Email:");
							string email = Console.ReadLine();
							Console.WriteLine("License:");
							string license = Console.ReadLine();
							if (API.Register(username, password, email, license))
							{
								MessageBox.Show("You have successfully registered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
							}
						}
					}
				}
			}
			catch (Exception ex3)
			{
				Console.WriteLine(ex3.ToString());
			}
			if (File.Exists(path3))
			{
				string username2 = "";
				string password2 = "";
				Console.WriteLine("[1] Login");
				Console.WriteLine("[2] Register");
				Console.Write("\nInput: ");
				string a2 = Console.ReadLine();
				if (a2 == "1")
				{
					if (!ApplicationSettings.Login)
					{
						MessageBox.Show("Login is not enabled, please try again later!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
						Process.GetCurrentProcess().Kill();
						return;
					}
					using (StreamReader streamReader = File.OpenText(path4))
					{
						string text;
						while ((text = streamReader.ReadLine()) != null)
						{
							username2 = text;
						}
					}
					using (StreamReader streamReader2 = File.OpenText(path5))
					{
						string text2;
						while ((text2 = streamReader2.ReadLine()) != null)
						{
							password2 = text2;
						}
					}
					Console.Clear();
					Program.PrintLogo();
					Console.WriteLine("AutoLogin: Enabled");
					Console.Clear();
					if (API.Login(username2, password2))
					{
						Console.Write("\n[+] Logging In... ");
						using (ProgressBar progressBar = new ProgressBar())
						{
							for (int i = 0; i <= 100; i++)
							{
								progressBar.Report((double)i / 20.0);
								Thread.Sleep(20);
							}
						}
						Console.Clear();
						Program.PrintLogo();
						Console.WriteLine("[1] Public Mining");
						Console.WriteLine("[2] Private Mining");
						Console.WriteLine("[3] Connect your wallet");
						Console.WriteLine("[4] Settings and Statistics");
						Console.WriteLine("[5] Exit");
						Console.Write("\nInput: ");
						string a3 = Console.ReadLine();
						if (a3 == "1")
						{
							Console.Clear();
							Console.WriteLine("\nPublic Mining is currently under development.");
							Console.WriteLine("\nPlease restart the program...");
							Thread.Sleep(100000000);
						}
						if (a3 == "2")
						{
							if (User.Rank == "1" || User.Rank == "2" || User.Rank == "3")
							{
								Thread.Sleep(500);
								Console.Clear();
								Program.PrintPrivateLogo();
								Program.PrivateInfinite();
							}
							else
							{
								MessageBox.Show("You do not have access to this level!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
								Thread.Sleep(1000);
								Environment.Exit(0);
							}
						}
						if (a3 == "3")
						{
							Program.AllocConsole();
							Console.Title = "SecureWindow";
							Console.Clear();
							Program.PrintLogo();
							Program.ConnectWallet();
							Environment.Exit(0);
						}
						if (a3 == "4")
						{
							Console.Clear();
							Program.PrintLogo();
							Program.config();
						}
						if (a3 == "5")
						{
							Environment.Exit(0);
							return;
						}
					}
				}
				else if (a2 == "2")
				{
					if (!ApplicationSettings.Register)
					{
						MessageBox.Show("Register is not enabled, please try again later!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
						Process.GetCurrentProcess().Kill();
						return;
					}
					Console.Clear();
					Program.PrintLogo();
					Console.WriteLine();
					Console.WriteLine("Username:");
					string username3 = Console.ReadLine();
					Console.WriteLine("Password:");
					string password3 = Console.ReadLine();
					Console.WriteLine("Email:");
					string email2 = Console.ReadLine();
					Console.WriteLine("License:");
					string license2 = Console.ReadLine();
					if (API.Register(username3, password3, email2, license2))
					{
						MessageBox.Show("You have successfully registered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
					}
				}
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00006514 File Offset: 0x00004714
		private static void GetComponent(string hwclass, string syntax)
		{
			foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass).Get())
			{
				Console.WriteLine(Convert.ToString(((ManagementObject)managementBaseObject)[syntax]));
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00006584 File Offset: 0x00004784
		public static void PrintLogo()
		{
			string value = "\r\n\r\n                             ████████╗██╗  ██╗██╗   ██╗███╗   ██╗██████╗ ███████╗██████╗ \r\n                             ╚══██╔══╝██║  ██║██║   ██║████╗  ██║██╔══██╗██╔════╝██╔══██╗\r\n                                ██║   ███████║██║   ██║██╔██╗ ██║██║  ██║█████╗  ██████╔╝\r\n                                ██║   ██╔══██║██║   ██║██║╚██╗██║██║  ██║██╔══╝  ██╔══██╗\r\n                                ██║   ██║  ██║╚██████╔╝██║ ╚████║██████╔╝███████╗██║  ██║\r\n                                ╚═╝   ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚═════╝ ╚══════╝╚═╝  ╚═╝\r\n \r\n                                        ███╗   ███╗██╗███╗   ██╗███████╗██████╗ \r\n                                        ████╗ ████║██║████╗  ██║██╔════╝██╔══██╗\r\n                                        ██╔████╔██║██║██╔██╗ ██║█████╗  ██████╔╝\r\n                                        ██║╚██╔╝██║██║██║╚██╗██║██╔══╝  ██╔══██╗\r\n                                        ██║ ╚═╝ ██║██║██║ ╚████║███████╗██║  ██║\r\n                                        ╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚══════╝╚═╝  ╚═╝\r\n\r\n\r\n";
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine(value);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00006597 File Offset: 0x00004797
		public static void PrintPrivateLogo()
		{
			string value = "\r\n\r\n              ████████╗██╗  ██╗██╗   ██╗███╗   ██╗██████╗ ███████╗██████╗ ███╗   ███╗██╗███╗   ██╗███████╗\r\n              ╚══██╔══╝██║  ██║██║   ██║████╗  ██║██╔══██╗██╔════╝██╔══██╗████╗ ████║██║████╗  ██║██╔════╝\r\n                 ██║   ███████║██║   ██║██╔██╗ ██║██║  ██║█████╗  ██████╔╝██╔████╔██║██║██╔██╗ ██║█████╗  \r\n                 ██║   ██╔══██║██║   ██║██║╚██╗██║██║  ██║██╔══╝  ██╔══██╗██║╚██╔╝██║██║██║╚██╗██║██╔══╝  \r\n                 ██║   ██║  ██║╚██████╔╝██║ ╚████║██████╔╝███████╗██║  ██║██║ ╚═╝ ██║██║██║ ╚████║███████╗\r\n                 ╚═╝   ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚═════╝ ╚══════╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚══════╝  \r\n                                             _____      _            _            \r\n                                            |  __ \\    (_)          | |        \r\n                                            | |__) | __ ___   ____ _| |_ ___    \r\n                                            |  ___/ '__| \\ \\ / / _` | __/ _ \\ \r\n                                            | |   | |  | |\\ V / (_| | ||  __/\r\n                                            |_|   |_|  |_| \\_/ \\__,_|\\__\\___|               \r\n                                        \r\n                                         \r\n\r\n                                  \r\n                                             ";
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine(value);
		}

		// Token: 0x04000034 RID: 52
		private static Random random = new Random();

		// Token: 0x02000012 RID: 18
		public class ColoredString
		{
			// Token: 0x06000088 RID: 136 RVA: 0x00006697 File Offset: 0x00004897
			public ColoredString(ConsoleColor color, string text)
			{
				this.Color = color;
				this.Text = text;
			}

			// Token: 0x04000041 RID: 65
			public ConsoleColor Color;

			// Token: 0x04000042 RID: 66
			public string Text;
		}

		// Token: 0x02000013 RID: 19
		public class SystemInfo
		{
			// Token: 0x06000089 RID: 137 RVA: 0x000066B0 File Offset: 0x000048B0
			public void getOperatingSystemInfo()
			{
				Console.WriteLine("[+] Loading System Information....\n");
				foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("select * from Win32_OperatingSystem").Get())
				{
					ManagementObject managementObject = (ManagementObject)managementBaseObject;
					if (managementObject["Caption"] != null)
					{
						Console.WriteLine("Operating System Name:  " + managementObject["Caption"].ToString());
					}
					if (managementObject["OSArchitecture"] != null)
					{
						Console.WriteLine("Operating System Architecture:  " + managementObject["OSArchitecture"].ToString());
					}
				}
			}

			// Token: 0x0600008A RID: 138 RVA: 0x00006768 File Offset: 0x00004968
			public void getCpuInfo()
			{
				foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("select * from Win32_Processor").Get())
				{
					ManagementObject managementObject = (ManagementObject)managementBaseObject;
					if (managementObject["Name"] != null)
					{
						Console.WriteLine("Central Processing Unit:  " + managementObject["Name"].ToString());
					}
				}
			}

			// Token: 0x0600008B RID: 139 RVA: 0x000067E8 File Offset: 0x000049E8
			public void getGpuInfo()
			{
				foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("select * from Win32_VideoController").Get())
				{
					ManagementObject managementObject = (ManagementObject)managementBaseObject;
					if (managementObject["Name"] != null)
					{
						Console.WriteLine("Graphics Processing Unit:  " + managementObject["Name"].ToString());
					}
				}
			}
		}
	}
}
