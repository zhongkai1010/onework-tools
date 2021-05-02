using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using #cTc;
using #Nk;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000007 RID: 7
	public class AdoDotNetConnectionProperties : ICustomTypeDescriptor, IDataConnectionProperties
	{
		// Token: 0x06000027 RID: 39 RVA: 0x0000311C File Offset: 0x0000211C
		public AdoDotNetConnectionProperties(string providerName)
		{
			this.#dTc = providerName;
			DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
			this.#eTc = factory.CreateConnectionStringBuilder();
			this.#eTc.BrowsableConnectionString = false;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003158 File Offset: 0x00002158
		public virtual void Reset()
		{
			this.#eTc.Clear();
			this.OnPropertyChanged(EventArgs.Empty);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003170 File Offset: 0x00002170
		public virtual void Parse(string s)
		{
			this.#eTc.ConnectionString = s;
			this.OnPropertyChanged(EventArgs.Empty);
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002A RID: 42 RVA: 0x0000318C File Offset: 0x0000218C
		public virtual bool IsExtensible
		{
			get
			{
				return !this.#eTc.IsFixedSize;
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000319C File Offset: 0x0000219C
		public virtual void Add(string propertyName)
		{
			if (!this.#eTc.ContainsKey(propertyName))
			{
				this.#eTc.Add(propertyName, string.Empty);
				this.OnPropertyChanged(EventArgs.Empty);
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000031C8 File Offset: 0x000021C8
		public virtual bool Contains(string propertyName)
		{
			return this.#eTc.ContainsKey(propertyName);
		}

		// Token: 0x17000009 RID: 9
		public virtual object this[string propertyName]
		{
			get
			{
				if (propertyName == null)
				{
					throw new ArgumentNullException(#Nk.#Mk.#Lk(836));
				}
				object obj = null;
				if (!this.#eTc.TryGetValue(propertyName, out obj))
				{
					return null;
				}
				if (this.#eTc.ShouldSerialize(propertyName))
				{
					return this.#eTc[propertyName];
				}
				object obj2 = this.#eTc[propertyName];
				if (obj2 != null)
				{
					return obj2;
				}
				return DBNull.Value;
			}
			set
			{
				if (propertyName == null)
				{
					throw new ArgumentNullException(#Nk.#Mk.#Lk(836));
				}
				this.#eTc.Remove(propertyName);
				if (value == DBNull.Value)
				{
					this.OnPropertyChanged(EventArgs.Empty);
					return;
				}
				object objA = null;
				this.#eTc.TryGetValue(propertyName, out objA);
				this.#eTc[propertyName] = value;
				if (object.Equals(objA, value))
				{
					this.#eTc.Remove(propertyName);
				}
				this.OnPropertyChanged(EventArgs.Empty);
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000032C0 File Offset: 0x000022C0
		public virtual void Remove(string propertyName)
		{
			if (this.#eTc.ContainsKey(propertyName))
			{
				this.#eTc.Remove(propertyName);
				this.OnPropertyChanged(EventArgs.Empty);
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000030 RID: 48 RVA: 0x000032E8 File Offset: 0x000022E8
		// (remove) Token: 0x06000031 RID: 49 RVA: 0x00003320 File Offset: 0x00002320
		public event EventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#ml;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#ml, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#ml;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#ml, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003358 File Offset: 0x00002358
		public virtual void Reset(string propertyName)
		{
			if (this.#eTc.ContainsKey(propertyName))
			{
				this.#eTc.Remove(propertyName);
				this.OnPropertyChanged(EventArgs.Empty);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00003380 File Offset: 0x00002380
		public virtual bool IsComplete
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003384 File Offset: 0x00002384
		public virtual void Test()
		{
			string text = this.ToTestString();
			if (text == null || text.Length == 0)
			{
				throw new InvalidOperationException(#cTc.#Mk.AdoDotNetConnectionProperties_NoProperties);
			}
			DbConnection dbConnection = null;
			DbProviderFactory factory = DbProviderFactories.GetFactory(this.#dTc);
			dbConnection = factory.CreateConnection();
			try
			{
				dbConnection.ConnectionString = text;
				dbConnection.Open();
				this.Inspect(dbConnection);
			}
			finally
			{
				dbConnection.Dispose();
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000033F0 File Offset: 0x000023F0
		public override string ToString()
		{
			return this.ToFullString();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000033F8 File Offset: 0x000023F8
		public virtual string ToFullString()
		{
			return this.#eTc.ConnectionString;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003408 File Offset: 0x00002408
		public virtual string ToDisplayString()
		{
			PropertyDescriptorCollection properties = this.GetProperties(new Attribute[]
			{
				PasswordPropertyTextAttribute.Yes
			});
			List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
			foreach (object obj in properties)
			{
				PropertyDescriptor propertyDescriptor = (PropertyDescriptor)obj;
				string displayName = propertyDescriptor.DisplayName;
				if (this.ConnectionStringBuilder.ShouldSerialize(displayName))
				{
					list.Add(new KeyValuePair<string, object>(displayName, this.ConnectionStringBuilder[displayName]));
					this.ConnectionStringBuilder.Remove(displayName);
				}
			}
			string connectionString;
			try
			{
				connectionString = this.ConnectionStringBuilder.ConnectionString;
			}
			finally
			{
				foreach (KeyValuePair<string, object> keyValuePair in list)
				{
					if (keyValuePair.Value != null)
					{
						this.ConnectionStringBuilder[keyValuePair.Key] = keyValuePair.Value;
					}
				}
			}
			return connectionString;
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000038 RID: 56 RVA: 0x0000352C File Offset: 0x0000252C
		public DbConnectionStringBuilder ConnectionStringBuilder
		{
			get
			{
				return this.#eTc;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00003534 File Offset: 0x00002534
		protected virtual PropertyDescriptor DefaultProperty
		{
			get
			{
				return TypeDescriptor.GetDefaultProperty(this.#eTc, true);
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003544 File Offset: 0x00002544
		protected virtual PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			return TypeDescriptor.GetProperties(this.#eTc, attributes);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003554 File Offset: 0x00002554
		protected virtual void OnPropertyChanged(EventArgs e)
		{
			if (this.#ml != null)
			{
				this.#ml(this, e);
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000356C File Offset: 0x0000256C
		protected virtual string ToTestString()
		{
			return this.#eTc.ConnectionString;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000357C File Offset: 0x0000257C
		protected virtual void Inspect(DbConnection connection)
		{
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003580 File Offset: 0x00002580
		string ICustomTypeDescriptor.#huc()
		{
			return TypeDescriptor.GetClassName(this.#eTc, true);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003590 File Offset: 0x00002590
		string ICustomTypeDescriptor.#iuc()
		{
			return TypeDescriptor.GetComponentName(this.#eTc, true);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000035A0 File Offset: 0x000025A0
		AttributeCollection ICustomTypeDescriptor.#guc()
		{
			return TypeDescriptor.GetAttributes(this.#eTc, true);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000035B0 File Offset: 0x000025B0
		object ICustomTypeDescriptor.#muc(Type #nuc)
		{
			return TypeDescriptor.GetEditor(this.#eTc, #nuc, true);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000035C0 File Offset: 0x000025C0
		TypeConverter ICustomTypeDescriptor.#juc()
		{
			return TypeDescriptor.GetConverter(this.#eTc, true);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000035D0 File Offset: 0x000025D0
		PropertyDescriptor ICustomTypeDescriptor.#luc()
		{
			return this.DefaultProperty;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000035D8 File Offset: 0x000025D8
		PropertyDescriptorCollection ICustomTypeDescriptor.#puc()
		{
			return this.GetProperties(new Attribute[0]);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000035E8 File Offset: 0x000025E8
		PropertyDescriptorCollection ICustomTypeDescriptor.#puc(Attribute[] #0Sb)
		{
			return this.GetProperties(#0Sb);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000035F4 File Offset: 0x000025F4
		EventDescriptor ICustomTypeDescriptor.#kuc()
		{
			return TypeDescriptor.GetDefaultEvent(this.#eTc, true);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003604 File Offset: 0x00002604
		EventDescriptorCollection ICustomTypeDescriptor.#ouc()
		{
			return TypeDescriptor.GetEvents(this.#eTc, true);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003614 File Offset: 0x00002614
		EventDescriptorCollection ICustomTypeDescriptor.#ouc(Attribute[] #0Sb)
		{
			return TypeDescriptor.GetEvents(this.#eTc, #0Sb, true);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003624 File Offset: 0x00002624
		object ICustomTypeDescriptor.#quc(PropertyDescriptor #ruc)
		{
			return this.#eTc;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000362C File Offset: 0x0000262C
		// Note: this type is marked as 'beforefieldinit'.
		static AdoDotNetConnectionProperties()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (AdoDotNetConnectionProperties.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Nk.#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Nk.#Mk.#Lk(799));
		}

		// Token: 0x0600004B RID: 75
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x0400001F RID: 31
		[CompilerGenerated]
		private EventHandler #ml;

		// Token: 0x04000020 RID: 32
		private string #dTc;

		// Token: 0x04000021 RID: 33
		private DbConnectionStringBuilder #eTc;
	}
}
