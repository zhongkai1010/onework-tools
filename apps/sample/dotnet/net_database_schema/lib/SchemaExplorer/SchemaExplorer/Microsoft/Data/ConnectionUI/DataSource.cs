using System;
using System.Collections;
using System.Collections.Generic;
using #cTc;
using #Nk;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000010 RID: 16
	public class DataSource
	{
		// Token: 0x060000E2 RID: 226 RVA: 0x00006BA0 File Offset: 0x00005BA0
		private DataSource()
		{
			this.#sUc = #cTc.#Mk.DataSource_UnspecifiedDisplayName;
			this.#EUc = new DataSource.#J4c(this);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00006BC0 File Offset: 0x00005BC0
		public DataSource(string name, string displayName)
		{
			if (name == null)
			{
				throw new ArgumentNullException(#Nk.#Mk.#Lk(1534));
			}
			this.#Ro = name;
			this.#sUc = displayName;
			this.#EUc = new DataSource.#J4c(this);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00006BF8 File Offset: 0x00005BF8
		public static void AddStandardDataSources(DataConnectionDialog dialog)
		{
			dialog.DataSources.Add(DataSource.SqlDataSource);
			dialog.DataSources.Add(DataSource.SqlFileDataSource);
			dialog.DataSources.Add(DataSource.OracleDataSource);
			dialog.DataSources.Add(DataSource.AccessDataSource);
			dialog.DataSources.Add(DataSource.OdbcDataSource);
			dialog.UnspecifiedDataSource.Providers.Add(DataProvider.SqlDataProvider);
			dialog.UnspecifiedDataSource.Providers.Add(DataProvider.OracleDataProvider);
			dialog.UnspecifiedDataSource.Providers.Add(DataProvider.OleDBDataProvider);
			dialog.UnspecifiedDataSource.Providers.Add(DataProvider.OdbcDataProvider);
			dialog.DataSources.Add(dialog.UnspecifiedDataSource);
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00006CBC File Offset: 0x00005CBC
		public static DataSource SqlDataSource
		{
			get
			{
				if (DataSource.#yUc == null)
				{
					DataSource.#yUc = new DataSource(#Nk.#Mk.#Lk(1754), #cTc.#Mk.DataSource_MicrosoftSqlServer);
					DataSource.#yUc.Providers.Add(DataProvider.SqlDataProvider);
					DataSource.#yUc.Providers.Add(DataProvider.OleDBDataProvider);
					DataSource.#yUc.DefaultProvider = DataProvider.SqlDataProvider;
				}
				return DataSource.#yUc;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x00006D28 File Offset: 0x00005D28
		public static DataSource SqlFileDataSource
		{
			get
			{
				if (DataSource.#zUc == null)
				{
					DataSource.#zUc = new DataSource(#Nk.#Mk.#Lk(1609), #cTc.#Mk.DataSource_MicrosoftSqlServerFile);
					DataSource.#zUc.Providers.Add(DataProvider.SqlDataProvider);
				}
				return DataSource.#zUc;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00006D64 File Offset: 0x00005D64
		public static DataSource OracleDataSource
		{
			get
			{
				if (DataSource.#AUc == null)
				{
					DataSource.#AUc = new DataSource(#Nk.#Mk.#Lk(1779), #cTc.#Mk.DataSource_Oracle);
					DataSource.#AUc.Providers.Add(DataProvider.OracleDataProvider);
					DataSource.#AUc.Providers.Add(DataProvider.OleDBDataProvider);
					DataSource.#AUc.DefaultProvider = DataProvider.OracleDataProvider;
				}
				return DataSource.#AUc;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x00006DD0 File Offset: 0x00005DD0
		public static DataSource AccessDataSource
		{
			get
			{
				if (DataSource.#BUc == null)
				{
					DataSource.#BUc = new DataSource(#Nk.#Mk.#Lk(1788), #cTc.#Mk.DataSource_MicrosoftAccess);
					DataSource.#BUc.Providers.Add(DataProvider.OleDBDataProvider);
				}
				return DataSource.#BUc;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00006E0C File Offset: 0x00005E0C
		public static DataSource OdbcDataSource
		{
			get
			{
				if (DataSource.#CUc == null)
				{
					DataSource.#CUc = new DataSource(#Nk.#Mk.#Lk(1809), #cTc.#Mk.DataSource_MicrosoftOdbcDsn);
					DataSource.#CUc.Providers.Add(DataProvider.OdbcDataProvider);
				}
				return DataSource.#CUc;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00006E48 File Offset: 0x00005E48
		public string Name
		{
			get
			{
				return this.#Ro;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00006E50 File Offset: 0x00005E50
		public string DisplayName
		{
			get
			{
				if (this.#sUc == null)
				{
					return this.#Ro;
				}
				return this.#sUc;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00006E68 File Offset: 0x00005E68
		// (set) Token: 0x060000ED RID: 237 RVA: 0x00006EB8 File Offset: 0x00005EB8
		public DataProvider DefaultProvider
		{
			get
			{
				int count = this.#EUc.Count;
				if (count == 0)
				{
					return null;
				}
				if (count == 1)
				{
					IEnumerator<DataProvider> enumerator = this.#EUc.GetEnumerator();
					enumerator.MoveNext();
					return enumerator.Current;
				}
				if (this.#Ro == null)
				{
					return null;
				}
				return this.#DUc;
			}
			set
			{
				if (this.#EUc.Count == 1 && this.#DUc != value)
				{
					throw new InvalidOperationException(#cTc.#Mk.DataSource_CannotChangeSingleDataProvider);
				}
				if (value != null && !this.#EUc.Contains(value))
				{
					throw new InvalidOperationException(#cTc.#Mk.DataSource_DataProviderNotFound);
				}
				this.#DUc = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00006F0C File Offset: 0x00005F0C
		public ICollection<DataProvider> Providers
		{
			get
			{
				return this.#EUc;
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00006F14 File Offset: 0x00005F14
		internal static DataSource #FUc()
		{
			return new DataSource();
		}

		// Token: 0x04000052 RID: 82
		public const string MicrosoftSqlServerFileName = "MicrosoftSqlServerFile";

		// Token: 0x04000053 RID: 83
		private static DataSource #yUc;

		// Token: 0x04000054 RID: 84
		private static DataSource #zUc;

		// Token: 0x04000055 RID: 85
		private static DataSource #AUc;

		// Token: 0x04000056 RID: 86
		private static DataSource #BUc;

		// Token: 0x04000057 RID: 87
		private static DataSource #CUc;

		// Token: 0x04000058 RID: 88
		private string #Ro;

		// Token: 0x04000059 RID: 89
		private string #sUc;

		// Token: 0x0400005A RID: 90
		private DataProvider #DUc;

		// Token: 0x0400005B RID: 91
		private ICollection<DataProvider> #EUc;

		// Token: 0x02000011 RID: 17
		private sealed class #J4c : ICollection<DataProvider>, IEnumerable<DataProvider>, IEnumerable
		{
			// Token: 0x060000F0 RID: 240 RVA: 0x00006F1C File Offset: 0x00005F1C
			public #J4c(DataSource source)
			{
				this.#jqb = new List<DataProvider>();
				this.#I4c = source;
			}

			// Token: 0x17000032 RID: 50
			// (get) Token: 0x060000F1 RID: 241 RVA: 0x00006F38 File Offset: 0x00005F38
			public int Count
			{
				get
				{
					return this.#jqb.Count;
				}
			}

			// Token: 0x17000033 RID: 51
			// (get) Token: 0x060000F2 RID: 242 RVA: 0x00006F48 File Offset: 0x00005F48
			public bool IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x060000F3 RID: 243 RVA: 0x00006F4C File Offset: 0x00005F4C
			public void Add(DataProvider item)
			{
				if (item == null)
				{
					throw new ArgumentNullException(#Nk.#Mk.#Lk(19179));
				}
				if (!this.#jqb.Contains(item))
				{
					this.#jqb.Add(item);
				}
			}

			// Token: 0x060000F4 RID: 244 RVA: 0x00006F7C File Offset: 0x00005F7C
			public bool Contains(DataProvider #Ul)
			{
				return this.#jqb.Contains(#Ul);
			}

			// Token: 0x060000F5 RID: 245 RVA: 0x00006F8C File Offset: 0x00005F8C
			public bool Remove(DataProvider #Ul)
			{
				bool result = this.#jqb.Remove(#Ul);
				if (#Ul == this.#I4c.#DUc)
				{
					this.#I4c.#DUc = null;
				}
				return result;
			}

			// Token: 0x060000F6 RID: 246 RVA: 0x00006FC4 File Offset: 0x00005FC4
			public void Clear()
			{
				this.#jqb.Clear();
				this.#I4c.#DUc = null;
			}

			// Token: 0x060000F7 RID: 247 RVA: 0x00006FE0 File Offset: 0x00005FE0
			public void #B4c(DataProvider[] #Xl, int #Yl)
			{
				this.#jqb.CopyTo(#Xl, #Yl);
			}

			// Token: 0x060000F8 RID: 248 RVA: 0x00006FF0 File Offset: 0x00005FF0
			public IEnumerator<DataProvider> GetEnumerator()
			{
				return this.#jqb.GetEnumerator();
			}

			// Token: 0x060000F9 RID: 249 RVA: 0x00007000 File Offset: 0x00006000
			IEnumerator IEnumerable.#Sl()
			{
				return this.#jqb.GetEnumerator();
			}

			// Token: 0x0400005C RID: 92
			private ICollection<DataProvider> #jqb;

			// Token: 0x0400005D RID: 93
			private DataSource #I4c;
		}
	}
}
