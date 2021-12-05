using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using #Nk;

namespace #cTc
{
	// Token: 0x02000030 RID: 48
	internal sealed class #jYc
	{
		// Token: 0x06000226 RID: 550 RVA: 0x0000E760 File Offset: 0x0000D760
		private #jYc()
		{
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000E768 File Offset: 0x0000D768
		public static DialogResult Show(string #4U, string #TL, MessageBoxIcon #QU)
		{
			MessageBoxOptions options = (MessageBoxOptions)0;
			if (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft)
			{
				options = (MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
			}
			return MessageBox.Show(#TL, #4U, MessageBoxButtons.OK, #QU, MessageBoxDefaultButton.Button1, options);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000E79C File Offset: 0x0000D79C
		// Note: this type is marked as 'beforefieldinit'.
		static #jYc()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (#jYc.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000229 RID: 553
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
