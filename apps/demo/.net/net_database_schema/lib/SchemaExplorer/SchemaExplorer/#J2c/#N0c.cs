using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;

namespace #J2c
{
	// Token: 0x020000CF RID: 207
	internal sealed class #N0c
	{
		// Token: 0x06000718 RID: 1816 RVA: 0x00020D70 File Offset: 0x0001FD70
		public #N0c(Type providerType, string name)
		{
			this.#kz = providerType;
			this.#5n = name;
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x00020D88 File Offset: 0x0001FD88
		public override string ToString()
		{
			return this.#5n;
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x00020D90 File Offset: 0x0001FD90
		// Note: this type is marked as 'beforefieldinit'.
		static #N0c()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (#N0c.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x0600071B RID: 1819
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x040002AD RID: 685
		public Type #kz;

		// Token: 0x040002AE RID: 686
		public string #5n;
	}
}
