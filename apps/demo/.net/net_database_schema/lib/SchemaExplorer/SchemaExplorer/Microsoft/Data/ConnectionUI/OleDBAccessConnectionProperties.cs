using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #cTc;
using #Nk;
using Microsoft.Win32;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x0200002A RID: 42
	public class OleDBAccessConnectionProperties : OleDBSpecializedConnectionProperties
	{
		// Token: 0x060001DA RID: 474 RVA: 0x0000B640 File Offset: 0x0000A640
		public OleDBAccessConnectionProperties() : base(#Nk.#Mk.#Lk(2637))
		{
			this.#JXc = false;
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0000B65C File Offset: 0x0000A65C
		public override void Reset()
		{
			base.Reset();
			this.#JXc = false;
		}

		// Token: 0x17000057 RID: 87
		public override object this[string propertyName]
		{
			set
			{
				base[propertyName] = value;
				if (string.Equals(propertyName, #Nk.#Mk.#Lk(2469), StringComparison.OrdinalIgnoreCase))
				{
					if (value != null && value != DBNull.Value)
					{
						this.#LXc(base.ConnectionStringBuilder, EventArgs.Empty);
					}
					else
					{
						this.#JXc = false;
					}
				}
				if (string.Equals(propertyName, #Nk.#Mk.#Lk(241), StringComparison.Ordinal))
				{
					this.#MXc(base.ConnectionStringBuilder, EventArgs.Empty);
				}
			}
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0000B6E0 File Offset: 0x0000A6E0
		public override void Remove(string propertyName)
		{
			base.Remove(propertyName);
			if (string.Equals(propertyName, #Nk.#Mk.#Lk(2469), StringComparison.OrdinalIgnoreCase))
			{
				this.#JXc = false;
			}
			if (string.Equals(propertyName, #Nk.#Mk.#Lk(241), StringComparison.Ordinal))
			{
				this.#MXc(base.ConnectionStringBuilder, EventArgs.Empty);
			}
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0000B734 File Offset: 0x0000A734
		public override void Reset(string propertyName)
		{
			base.Reset(propertyName);
			if (string.Equals(propertyName, #Nk.#Mk.#Lk(2469), StringComparison.OrdinalIgnoreCase))
			{
				this.#JXc = false;
			}
			if (string.Equals(propertyName, #Nk.#Mk.#Lk(241), StringComparison.Ordinal))
			{
				this.#MXc(base.ConnectionStringBuilder, EventArgs.Empty);
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001DF RID: 479 RVA: 0x0000B788 File Offset: 0x0000A788
		public override bool IsComplete
		{
			get
			{
				return base.IsComplete && base.ConnectionStringBuilder[#Nk.#Mk.#Lk(241)] is string && (base.ConnectionStringBuilder[#Nk.#Mk.#Lk(241)] as string).Length != 0;
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0000B7E0 File Offset: 0x0000A7E0
		public override void Test()
		{
			string text = base.ConnectionStringBuilder[#Nk.#Mk.#Lk(241)] as string;
			if (text == null || text.Length == 0)
			{
				throw new InvalidOperationException(#cTc.#Mk.OleDBAccessConnectionProperties_MustSpecifyDataSource);
			}
			base.Test();
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0000B824 File Offset: 0x0000A824
		public override string ToDisplayString()
		{
			string text = null;
			if (base.ConnectionStringBuilder.ContainsKey(#Nk.#Mk.#Lk(281)) && base.ConnectionStringBuilder.ShouldSerialize(#Nk.#Mk.#Lk(281)))
			{
				text = (base.ConnectionStringBuilder[#Nk.#Mk.#Lk(281)] as string);
				base.ConnectionStringBuilder.Remove(#Nk.#Mk.#Lk(281));
			}
			string result = base.ToDisplayString();
			if (text != null)
			{
				base.ConnectionStringBuilder[#Nk.#Mk.#Lk(281)] = text;
			}
			return result;
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0000B8B4 File Offset: 0x0000A8B4
		protected override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = base.GetProperties(attributes);
			if (OleDBAccessConnectionProperties.Access12ProviderRegistered)
			{
				#uVc #uVc = propertyDescriptorCollection.Find(#Nk.#Mk.#Lk(2469), true) as #uVc;
				if (#uVc != null)
				{
					if (!base.DisableProviderSelection)
					{
						#uVc.#gVc(false);
					}
					#uVc.#hVc(typeof(OleDBAccessConnectionProperties.#b5c));
					#uVc.AddValueChanged(base.ConnectionStringBuilder, new EventHandler(this.#LXc));
				}
				PropertyDescriptor propertyDescriptor = propertyDescriptorCollection.Find(#Nk.#Mk.#Lk(2670), true);
				if (propertyDescriptor != null)
				{
					int num = propertyDescriptorCollection.IndexOf(propertyDescriptor);
					PropertyDescriptor[] array = new PropertyDescriptor[propertyDescriptorCollection.Count];
					propertyDescriptorCollection.CopyTo(array, 0);
					array[num] = new #uVc(propertyDescriptor);
					array[num].AddValueChanged(base.ConnectionStringBuilder, new EventHandler(this.#MXc));
					propertyDescriptorCollection = new PropertyDescriptorCollection(array, true);
				}
			}
			PropertyDescriptor propertyDescriptor2 = propertyDescriptorCollection.Find(#Nk.#Mk.#Lk(281), true);
			if (propertyDescriptor2 != null)
			{
				int num2 = propertyDescriptorCollection.IndexOf(propertyDescriptor2);
				PropertyDescriptor[] array2 = new PropertyDescriptor[propertyDescriptorCollection.Count];
				propertyDescriptorCollection.CopyTo(array2, 0);
				array2[num2] = new #uVc(propertyDescriptor2, new Attribute[]
				{
					PasswordPropertyTextAttribute.Yes
				});
				propertyDescriptorCollection = new PropertyDescriptorCollection(array2, true);
			}
			return propertyDescriptorCollection;
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x0000B9E0 File Offset: 0x0000A9E0
		private static bool Access12ProviderRegistered
		{
			get
			{
				if (!OleDBAccessConnectionProperties.#IXc)
				{
					RegistryKey registryKey = null;
					try
					{
						registryKey = Registry.ClassesRoot.OpenSubKey(#Nk.#Mk.#Lk(2687));
						OleDBAccessConnectionProperties.#HXc = (registryKey != null);
					}
					finally
					{
						if (registryKey != null)
						{
							registryKey.Close();
						}
					}
					OleDBAccessConnectionProperties.#IXc = true;
				}
				return OleDBAccessConnectionProperties.#HXc;
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000BA3C File Offset: 0x0000AA3C
		private void #LXc(object #sm, EventArgs #tm)
		{
			if (OleDBAccessConnectionProperties.Access12ProviderRegistered)
			{
				this.#JXc = true;
			}
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0000BA4C File Offset: 0x0000AA4C
		private void #MXc(object #sm, EventArgs #tm)
		{
			if (OleDBAccessConnectionProperties.Access12ProviderRegistered && !this.#JXc)
			{
				string text = this[#Nk.#Mk.#Lk(241)] as string;
				if (text != null)
				{
					text = text.Trim().ToUpperInvariant();
					if (text.EndsWith(#Nk.#Mk.#Lk(2720), StringComparison.Ordinal))
					{
						base[#Nk.#Mk.#Lk(2469)] = #Nk.#Mk.#Lk(2687);
						return;
					}
					base[#Nk.#Mk.#Lk(2469)] = #Nk.#Mk.#Lk(2637);
				}
			}
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0000BAD8 File Offset: 0x0000AAD8
		// Note: this type is marked as 'beforefieldinit'.
		static OleDBAccessConnectionProperties()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (OleDBAccessConnectionProperties.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Nk.#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Nk.#Mk.#Lk(799));
		}

		// Token: 0x060001E7 RID: 487
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x040000E1 RID: 225
		private static bool #HXc;

		// Token: 0x040000E2 RID: 226
		private static bool #IXc;

		// Token: 0x040000E3 RID: 227
		private bool #JXc;

		// Token: 0x0200002B RID: 43
		private sealed class #b5c : StringConverter
		{
			// Token: 0x060001E9 RID: 489 RVA: 0x0000BB34 File Offset: 0x0000AB34
			public bool #nhb(ITypeDescriptorContext #nq)
			{
				return true;
			}

			// Token: 0x060001EA RID: 490 RVA: 0x0000BB38 File Offset: 0x0000AB38
			public bool #ohb(ITypeDescriptorContext #nq)
			{
				return true;
			}

			// Token: 0x060001EB RID: 491 RVA: 0x0000BB3C File Offset: 0x0000AB3C
			public TypeConverter.StandardValuesCollection #phb(ITypeDescriptorContext #nq)
			{
				return new TypeConverter.StandardValuesCollection(new string[]
				{
					#Nk.#Mk.#Lk(2637),
					#Nk.#Mk.#Lk(2687)
				});
			}

			// Token: 0x060001EC RID: 492 RVA: 0x0000BB64 File Offset: 0x0000AB64
			// Note: this type is marked as 'beforefieldinit'.
			static #b5c()
			{
				bool flag = false;
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				if (OleDBAccessConnectionProperties.#b5c.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Nk.#Mk.#Lk(774)))
				{
					return;
				}
				throw new SecurityException(#Nk.#Mk.#Lk(799));
			}

			// Token: 0x060001ED RID: 493
			[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
			[return: MarshalAs(UnmanagedType.Bool)]
			private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
		}
	}
}
