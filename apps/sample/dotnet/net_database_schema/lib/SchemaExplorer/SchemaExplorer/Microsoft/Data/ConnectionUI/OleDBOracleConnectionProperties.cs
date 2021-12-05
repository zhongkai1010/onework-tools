using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000029 RID: 41
	public class OleDBOracleConnectionProperties : OleDBSpecializedConnectionProperties
	{
		// Token: 0x060001D6 RID: 470 RVA: 0x0000B540 File Offset: 0x0000A540
		public OleDBOracleConnectionProperties() : base(#Mk.#Lk(2624))
		{
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x0000B554 File Offset: 0x0000A554
		public override bool IsComplete
		{
			get
			{
				return base.IsComplete && base.ConnectionStringBuilder[#Mk.#Lk(241)] is string && (base.ConnectionStringBuilder[#Mk.#Lk(241)] as string).Length != 0 && base.ConnectionStringBuilder[#Mk.#Lk(263)] is string && (base.ConnectionStringBuilder[#Mk.#Lk(263)] as string).Length != 0;
			}
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000B5EC File Offset: 0x0000A5EC
		// Note: this type is marked as 'beforefieldinit'.
		static OleDBOracleConnectionProperties()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (OleDBOracleConnectionProperties.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x060001D9 RID: 473
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
