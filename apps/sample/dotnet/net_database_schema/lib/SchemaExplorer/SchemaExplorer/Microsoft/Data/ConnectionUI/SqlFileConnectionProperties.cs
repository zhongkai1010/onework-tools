using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using #cTc;
using #Nk;
using Microsoft.Win32;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000032 RID: 50
	public class SqlFileConnectionProperties : SqlConnectionProperties
	{
		// Token: 0x06000232 RID: 562 RVA: 0x0000EA70 File Offset: 0x0000DA70
		public SqlFileConnectionProperties() : this(null)
		{
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000EA7C File Offset: 0x0000DA7C
		public SqlFileConnectionProperties(string defaultInstanceName)
		{
			this.#lYc = #Nk.#Mk.#Lk(2619);
			if (defaultInstanceName != null && defaultInstanceName.Length > 0)
			{
				this.#lYc = this.#lYc + #Nk.#Mk.#Lk(3505) + defaultInstanceName;
			}
			else
			{
				SqlFileConnectionProperties.#g5c #g5c = new SqlFileConnectionProperties.#g5c();
				TypeConverter.StandardValuesCollection standardValues = #g5c.GetStandardValues(null);
				if (standardValues.Count > 0)
				{
					this.#lYc = (standardValues[0] as string);
				}
			}
			this.#CXc();
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000EAF8 File Offset: 0x0000DAF8
		public override void Reset()
		{
			base.Reset();
			this.#CXc();
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000235 RID: 565 RVA: 0x0000EB08 File Offset: 0x0000DB08
		public override bool IsComplete
		{
			get
			{
				return base.IsComplete && base.ConnectionStringBuilder[#Nk.#Mk.#Lk(3510)] is string && (base.ConnectionStringBuilder[#Nk.#Mk.#Lk(3510)] as string).Length != 0;
			}
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000EB60 File Offset: 0x0000DB60
		public override void Test()
		{
			string text = base.ConnectionStringBuilder[#Nk.#Mk.#Lk(3510)] as string;
			try
			{
				if (text == null || text.Length == 0)
				{
					throw new InvalidOperationException(#cTc.#Mk.SqlFileConnectionProperties_NoFileSpecified);
				}
				base.ConnectionStringBuilder[#Nk.#Mk.#Lk(3510)] = Path.GetFullPath(text);
				if (!File.Exists(base.ConnectionStringBuilder[#Nk.#Mk.#Lk(3510)] as string))
				{
					throw new InvalidOperationException(#cTc.#Mk.SqlFileConnectionProperties_CannotTestNonExistentMdf);
				}
				base.Test();
			}
			catch (SqlException ex)
			{
				if (ex.Number == -2)
				{
					throw new ApplicationException(ex.Errors[0].Message + Environment.NewLine + #cTc.#Mk.SqlFileConnectionProperties_TimeoutReasons);
				}
				throw;
			}
			finally
			{
				if (text != null && text.Length > 0)
				{
					base.ConnectionStringBuilder[#Nk.#Mk.#Lk(3510)] = text;
				}
			}
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000EC60 File Offset: 0x0000DC60
		protected override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = base.GetProperties(attributes);
			PropertyDescriptor propertyDescriptor = propertyDescriptorCollection.Find(#Nk.#Mk.#Lk(2670), true);
			if (propertyDescriptor != null)
			{
				int num = propertyDescriptorCollection.IndexOf(propertyDescriptor);
				PropertyDescriptor[] array = new PropertyDescriptor[propertyDescriptorCollection.Count];
				propertyDescriptorCollection.CopyTo(array, 0);
				array[num] = new #uVc(propertyDescriptor, new Attribute[]
				{
					new TypeConverterAttribute(typeof(SqlFileConnectionProperties.#g5c))
				});
				(array[num] as #uVc).CanResetValueHandler = new #xVc(this.#mYc);
				(array[num] as #uVc).ResetValueHandler = new #yVc(this.#nYc);
				propertyDescriptorCollection = new PropertyDescriptorCollection(array, true);
			}
			return propertyDescriptorCollection;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000ED04 File Offset: 0x0000DD04
		private void #CXc()
		{
			this[#Nk.#Mk.#Lk(241)] = this.#lYc;
			this[#Nk.#Mk.#Lk(3535)] = true;
			this[#Nk.#Mk.#Lk(3556)] = 30;
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000ED54 File Offset: 0x0000DD54
		private bool #mYc(object #mVc)
		{
			return !(this[#Nk.#Mk.#Lk(241)] is string) || !(this[#Nk.#Mk.#Lk(241)] as string).Equals(this.#lYc, StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000ED94 File Offset: 0x0000DD94
		private void #nYc(object #mVc)
		{
			this[#Nk.#Mk.#Lk(241)] = this.#lYc;
		}

		// Token: 0x04000111 RID: 273
		private string #lYc;

		// Token: 0x02000033 RID: 51
		private sealed class #g5c : StringConverter
		{
			// Token: 0x0600023C RID: 572 RVA: 0x0000EDB4 File Offset: 0x0000DDB4
			public bool #nhb(ITypeDescriptorContext #nq)
			{
				return true;
			}

			// Token: 0x0600023D RID: 573 RVA: 0x0000EDB8 File Offset: 0x0000DDB8
			public bool #ohb(ITypeDescriptorContext #nq)
			{
				return true;
			}

			// Token: 0x0600023E RID: 574 RVA: 0x0000EDBC File Offset: 0x0000DDBC
			public TypeConverter.StandardValuesCollection #phb(ITypeDescriptorContext #nq)
			{
				if (this.#f5c == null)
				{
					string[] array = null;
					if (#JVc.#DVc())
					{
						List<string> list = new List<string>();
						list.AddRange(#JVc.#EVc(#Nk.#Mk.#Lk(19217), 257));
						list.AddRange(#JVc.#EVc(#Nk.#Mk.#Lk(19217), 513));
						array = list.ToArray();
					}
					else
					{
						RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(#Nk.#Mk.#Lk(19217));
						if (registryKey != null)
						{
							using (registryKey)
							{
								array = registryKey.GetValueNames();
							}
						}
					}
					if (array != null)
					{
						for (int i = 0; i < array.Length; i++)
						{
							if (string.Equals(array[i], #Nk.#Mk.#Lk(19298), StringComparison.OrdinalIgnoreCase))
							{
								array[i] = #Nk.#Mk.#Lk(2619);
							}
							else
							{
								array[i] = #Nk.#Mk.#Lk(19315) + array[i];
							}
						}
						this.#f5c = new TypeConverter.StandardValuesCollection(array);
					}
					else
					{
						this.#f5c = new TypeConverter.StandardValuesCollection(new string[0]);
					}
				}
				return this.#f5c;
			}

			// Token: 0x04000112 RID: 274
			private TypeConverter.StandardValuesCollection #f5c;
		}
	}
}
