using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #cTc;
using #Nk;
using Microsoft.Win32;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000025 RID: 37
	public class OleDBConnectionProperties : AdoDotNetConnectionProperties
	{
		// Token: 0x060001BA RID: 442 RVA: 0x0000AE44 File Offset: 0x00009E44
		public OleDBConnectionProperties() : base(#Nk.#Mk.#Lk(1704))
		{
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001BB RID: 443 RVA: 0x0000AE58 File Offset: 0x00009E58
		// (set) Token: 0x060001BC RID: 444 RVA: 0x0000AE60 File Offset: 0x00009E60
		public bool DisableProviderSelection
		{
			get
			{
				return this.#AXc;
			}
			set
			{
				this.#AXc = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001BD RID: 445 RVA: 0x0000AE6C File Offset: 0x00009E6C
		public override bool IsComplete
		{
			get
			{
				return base.ConnectionStringBuilder[#Nk.#Mk.#Lk(2469)] is string && (base.ConnectionStringBuilder[#Nk.#Mk.#Lk(2469)] as string).Length != 0;
			}
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000AEBC File Offset: 0x00009EBC
		protected override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = base.GetProperties(attributes);
			if (this.#AXc)
			{
				PropertyDescriptor propertyDescriptor = propertyDescriptorCollection.Find(#Nk.#Mk.#Lk(2469), true);
				if (propertyDescriptor != null)
				{
					int num = propertyDescriptorCollection.IndexOf(propertyDescriptor);
					PropertyDescriptor[] array = new PropertyDescriptor[propertyDescriptorCollection.Count];
					propertyDescriptorCollection.CopyTo(array, 0);
					array[num] = new #uVc(propertyDescriptor, new Attribute[]
					{
						ReadOnlyAttribute.Yes
					});
					(array[num] as #uVc).CanResetValueHandler = new #xVc(this.#BXc);
					propertyDescriptorCollection = new PropertyDescriptorCollection(array, true);
				}
			}
			return propertyDescriptorCollection;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000AF44 File Offset: 0x00009F44
		public static List<string> GetRegisteredProviders()
		{
			Type typeFromCLSID = Type.GetTypeFromCLSID(#qgc.#0Vc);
			OleDbDataReader enumerator = OleDbEnumerator.GetEnumerator(typeFromCLSID);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			using (enumerator)
			{
				while (enumerator.Read())
				{
					int num = (int)enumerator[#Nk.#Mk.#Lk(2482)];
					if (num == 1 || num == 3)
					{
						dictionary[enumerator[#Nk.#Mk.#Lk(2499)] as string] = null;
					}
				}
			}
			List<string> list = new List<string>(dictionary.Count);
			RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(#Nk.#Mk.#Lk(2520));
			using (registryKey)
			{
				foreach (KeyValuePair<string, string> keyValuePair in dictionary)
				{
					RegistryKey registryKey3 = registryKey.OpenSubKey(keyValuePair.Key + #Nk.#Mk.#Lk(2529));
					if (registryKey3 != null)
					{
						using (registryKey3)
						{
							list.Add(registryKey3.GetValue(null) as string);
						}
					}
				}
			}
			list.Sort();
			while (list.Contains(#Nk.#Mk.#Lk(2542)))
			{
				list.Remove(#Nk.#Mk.#Lk(2542));
			}
			return list;
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0000B0C8 File Offset: 0x0000A0C8
		private bool #BXc(object #mVc)
		{
			return false;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000B0CC File Offset: 0x0000A0CC
		// Note: this type is marked as 'beforefieldinit'.
		static OleDBConnectionProperties()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (OleDBConnectionProperties.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Nk.#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Nk.#Mk.#Lk(799));
		}

		// Token: 0x060001C2 RID: 450
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x040000DC RID: 220
		private bool #AXc;
	}
}
