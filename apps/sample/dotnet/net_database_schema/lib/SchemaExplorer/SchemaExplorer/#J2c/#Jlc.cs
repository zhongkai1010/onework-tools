using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using #Nk;

namespace #J2c
{
	// Token: 0x020000C8 RID: 200
	internal sealed class #Jlc : ListView
	{
		// Token: 0x060006B8 RID: 1720 RVA: 0x0001CD74 File Offset: 0x0001BD74
		protected override void OnHandleCreated(EventArgs #tm)
		{
			base.OnHandleCreated(#tm);
			if (!base.DesignMode && Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
			{
				#qgc.#Flc(base.Handle, #Mk.#Lk(15715), null);
			}
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x0001CDD0 File Offset: 0x0001BDD0
		// Note: this type is marked as 'beforefieldinit'.
		static #Jlc()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (#Jlc.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x060006BB RID: 1723
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
