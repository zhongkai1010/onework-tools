using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000026 RID: 38
	public class OleDBSpecializedConnectionProperties : OleDBConnectionProperties
	{
		// Token: 0x060001C3 RID: 451 RVA: 0x0000B120 File Offset: 0x0000A120
		public OleDBSpecializedConnectionProperties(string provider)
		{
			this.#aQc = provider;
			this.#CXc();
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000B138 File Offset: 0x0000A138
		public override void Reset()
		{
			base.Reset();
			this.#CXc();
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000B148 File Offset: 0x0000A148
		protected override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			bool disableProviderSelection = base.DisableProviderSelection;
			PropertyDescriptorCollection properties;
			try
			{
				base.DisableProviderSelection = true;
				properties = base.GetProperties(attributes);
			}
			finally
			{
				base.DisableProviderSelection = disableProviderSelection;
			}
			return properties;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0000B188 File Offset: 0x0000A188
		private void #CXc()
		{
			this[#Mk.#Lk(2469)] = this.#aQc;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000B1A0 File Offset: 0x0000A1A0
		// Note: this type is marked as 'beforefieldinit'.
		static OleDBSpecializedConnectionProperties()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (OleDBSpecializedConnectionProperties.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x060001C8 RID: 456
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x040000DD RID: 221
		private string #aQc;
	}
}
