using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x0200002E RID: 46
	public class OracleConnectionProperties : AdoDotNetConnectionProperties
	{
		// Token: 0x0600020E RID: 526 RVA: 0x0000DCC4 File Offset: 0x0000CCC4
		public OracleConnectionProperties() : base(#Mk.#Lk(1671))
		{
			this.#CXc();
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000DCDC File Offset: 0x0000CCDC
		public override void Reset()
		{
			base.Reset();
			this.#CXc();
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000210 RID: 528 RVA: 0x0000DCEC File Offset: 0x0000CCEC
		public override bool IsComplete
		{
			get
			{
				return base.ConnectionStringBuilder[#Mk.#Lk(241)] is string && (base.ConnectionStringBuilder[#Mk.#Lk(241)] as string).Length != 0 && ((bool)base.ConnectionStringBuilder[#Mk.#Lk(2568)] || (base.ConnectionStringBuilder[#Mk.#Lk(263)] is string && (base.ConnectionStringBuilder[#Mk.#Lk(263)] as string).Length != 0));
			}
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000DD94 File Offset: 0x0000CD94
		protected override string ToTestString()
		{
			bool flag = (bool)base.ConnectionStringBuilder[#Mk.#Lk(3385)];
			bool flag2 = !base.ConnectionStringBuilder.ShouldSerialize(#Mk.#Lk(3385));
			base.ConnectionStringBuilder[#Mk.#Lk(3385)] = false;
			string connectionString = base.ConnectionStringBuilder.ConnectionString;
			base.ConnectionStringBuilder[#Mk.#Lk(3385)] = flag;
			if (flag2)
			{
				base.ConnectionStringBuilder.Remove(#Mk.#Lk(3385));
			}
			return connectionString;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000DE34 File Offset: 0x0000CE34
		private void #CXc()
		{
			this[#Mk.#Lk(3398)] = true;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000DE4C File Offset: 0x0000CE4C
		// Note: this type is marked as 'beforefieldinit'.
		static OracleConnectionProperties()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (OracleConnectionProperties.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000214 RID: 532
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
