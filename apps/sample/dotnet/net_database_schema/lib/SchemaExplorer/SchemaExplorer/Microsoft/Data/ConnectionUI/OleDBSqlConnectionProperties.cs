using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #cTc;
using #Nk;
using Microsoft.Win32;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000027 RID: 39
	public class OleDBSqlConnectionProperties : OleDBSpecializedConnectionProperties
	{
		// Token: 0x060001C9 RID: 457 RVA: 0x0000B1F4 File Offset: 0x0000A1F4
		public OleDBSqlConnectionProperties() : base(#Nk.#Mk.#Lk(2555))
		{
			this.#CXc();
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000B20C File Offset: 0x0000A20C
		public override void Reset()
		{
			base.Reset();
			this.#CXc();
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001CB RID: 459 RVA: 0x0000B21C File Offset: 0x0000A21C
		public override bool IsComplete
		{
			get
			{
				return base.IsComplete && base.ConnectionStringBuilder[#Nk.#Mk.#Lk(241)] is string && (base.ConnectionStringBuilder[#Nk.#Mk.#Lk(241)] as string).Length != 0 && ((base.ConnectionStringBuilder[#Nk.#Mk.#Lk(2568)] != null && base.ConnectionStringBuilder[#Nk.#Mk.#Lk(2568)].ToString().Equals(#Nk.#Mk.#Lk(2597), StringComparison.OrdinalIgnoreCase)) || (base.ConnectionStringBuilder[#Nk.#Mk.#Lk(263)] is string && (base.ConnectionStringBuilder[#Nk.#Mk.#Lk(263)] as string).Length != 0));
			}
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000B2F8 File Offset: 0x0000A2F8
		protected override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection properties = base.GetProperties(attributes);
			if (OleDBSqlConnectionProperties.SqlNativeClientRegistered)
			{
				#uVc #uVc = properties.Find(#Nk.#Mk.#Lk(2469), true) as #uVc;
				if (#uVc != null)
				{
					if (!base.DisableProviderSelection)
					{
						#uVc.#gVc(false);
					}
					#uVc.#hVc(typeof(OleDBSqlConnectionProperties.#a5c));
				}
			}
			return properties;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000B350 File Offset: 0x0000A350
		private void #CXc()
		{
			this[#Nk.#Mk.#Lk(2568)] = #Nk.#Mk.#Lk(2597);
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001CE RID: 462 RVA: 0x0000B36C File Offset: 0x0000A36C
		public static List<string> SqlNativeClientProviders
		{
			get
			{
				if (OleDBSqlConnectionProperties.#EXc == null)
				{
					OleDBSqlConnectionProperties.#EXc = new List<string>();
					List<string> registeredProviders = OleDBConnectionProperties.GetRegisteredProviders();
					foreach (string text in registeredProviders)
					{
						if (text.StartsWith(#Nk.#Mk.#Lk(2606)))
						{
							int num = text.IndexOf(#Nk.#Mk.#Lk(2619));
							if (num > 0)
							{
								OleDBSqlConnectionProperties.#EXc.Add(text.Substring(0, num).ToUpperInvariant());
							}
						}
					}
					OleDBSqlConnectionProperties.#EXc.Sort();
				}
				return OleDBSqlConnectionProperties.#EXc;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001CF RID: 463 RVA: 0x0000B41C File Offset: 0x0000A41C
		private static bool SqlNativeClientRegistered
		{
			get
			{
				if (!OleDBSqlConnectionProperties.#FXc)
				{
					RegistryKey registryKey = null;
					try
					{
						OleDBSqlConnectionProperties.#DXc = (OleDBSqlConnectionProperties.SqlNativeClientProviders.Count > 0);
					}
					finally
					{
						if (registryKey != null)
						{
							registryKey.Close();
						}
					}
					OleDBSqlConnectionProperties.#FXc = true;
				}
				return OleDBSqlConnectionProperties.#DXc;
			}
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000B46C File Offset: 0x0000A46C
		// Note: this type is marked as 'beforefieldinit'.
		static OleDBSqlConnectionProperties()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (OleDBSqlConnectionProperties.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Nk.#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Nk.#Mk.#Lk(799));
		}

		// Token: 0x060001D1 RID: 465
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x040000DE RID: 222
		private static bool #DXc;

		// Token: 0x040000DF RID: 223
		private static List<string> #EXc;

		// Token: 0x040000E0 RID: 224
		private static bool #FXc;

		// Token: 0x02000028 RID: 40
		private sealed class #a5c : StringConverter
		{
			// Token: 0x060001D3 RID: 467 RVA: 0x0000B4C8 File Offset: 0x0000A4C8
			public bool #nhb(ITypeDescriptorContext #nq)
			{
				return true;
			}

			// Token: 0x060001D4 RID: 468 RVA: 0x0000B4CC File Offset: 0x0000A4CC
			public bool #ohb(ITypeDescriptorContext #nq)
			{
				return true;
			}

			// Token: 0x060001D5 RID: 469 RVA: 0x0000B4D0 File Offset: 0x0000A4D0
			public TypeConverter.StandardValuesCollection #phb(ITypeDescriptorContext #nq)
			{
				List<string> list = new List<string>();
				list.Add(#Nk.#Mk.#Lk(2555));
				foreach (string item in OleDBSqlConnectionProperties.SqlNativeClientProviders)
				{
					list.Add(item);
				}
				return new TypeConverter.StandardValuesCollection(list);
			}
		}
	}
}
