using System;
using System.Text;
using System.Threading;

// Token: 0x02000002 RID: 2
public class ProgressBar : IDisposable, IProgress<double>
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public ProgressBar()
	{
		this.timer = new Timer(new TimerCallback(this.TimerHandler));
		if (!Console.IsOutputRedirected)
		{
			this.ResetTimer();
		}
	}

	// Token: 0x06000002 RID: 2 RVA: 0x000020A6 File Offset: 0x000002A6
	public void Report(double value)
	{
		value = Math.Max(0.0, Math.Min(1.0, value));
		Interlocked.Exchange(ref this.currentProgress, value);
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000020D4 File Offset: 0x000002D4
	private void TimerHandler(object state)
	{
		Timer obj = this.timer;
		lock (obj)
		{
			if (!this.disposed)
			{
				int num = (int)(this.currentProgress * 10.0);
				int num2 = (int)(this.currentProgress * 100.0);
				string format = "[{0}{1}] {2,3}% {3}";
				object[] array = new object[4];
				array[0] = new string('#', num);
				array[1] = new string('-', 10 - num);
				array[2] = num2;
				int num3 = 3;
				string text = "|/-\\";
				int num4 = this.animationIndex;
				this.animationIndex = num4 + 1;
				array[num3] = text[num4 % "|/-\\".Length];
				string text2 = string.Format(format, array);
				this.UpdateText(text2);
				this.ResetTimer();
			}
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000021B4 File Offset: 0x000003B4
	private void UpdateText(string text)
	{
		int num = 0;
		int num2 = Math.Min(this.currentText.Length, text.Length);
		while (num < num2 && text[num] == this.currentText[num])
		{
			num++;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('\b', this.currentText.Length - num);
		stringBuilder.Append(text.Substring(num));
		int num3 = this.currentText.Length - text.Length;
		if (num3 > 0)
		{
			stringBuilder.Append(' ', num3);
			stringBuilder.Append('\b', num3);
		}
		Console.Write(stringBuilder);
		this.currentText = text;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002259 File Offset: 0x00000459
	private void ResetTimer()
	{
		this.timer.Change(this.animationInterval, TimeSpan.FromMilliseconds(-1.0));
	}

	// Token: 0x06000006 RID: 6 RVA: 0x0000227C File Offset: 0x0000047C
	public void Dispose()
	{
		Timer obj = this.timer;
		lock (obj)
		{
			this.disposed = true;
			this.UpdateText(string.Empty);
		}
	}

	// Token: 0x04000001 RID: 1
	private const int blockCount = 10;

	// Token: 0x04000002 RID: 2
	private readonly TimeSpan animationInterval = TimeSpan.FromSeconds(0.03333333333333333);

	// Token: 0x04000003 RID: 3
	private const string animation = "|/-\\";

	// Token: 0x04000004 RID: 4
	private readonly Timer timer;

	// Token: 0x04000005 RID: 5
	private double currentProgress;

	// Token: 0x04000006 RID: 6
	private string currentText = string.Empty;

	// Token: 0x04000007 RID: 7
	private bool disposed;

	// Token: 0x04000008 RID: 8
	private int animationIndex;
}
