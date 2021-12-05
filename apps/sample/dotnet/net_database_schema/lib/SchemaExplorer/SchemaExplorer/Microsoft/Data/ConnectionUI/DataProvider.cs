using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using #cTc;
using #Nk;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000012 RID: 18
	public class DataProvider
	{
		// Token: 0x060000FA RID: 250 RVA: 0x00007010 File Offset: 0x00006010
		public DataProvider(string name, string displayName, string shortDisplayName) : this(name, displayName, shortDisplayName, null, null)
		{
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00007020 File Offset: 0x00006020
		public DataProvider(string name, string displayName, string shortDisplayName, string description) : this(name, displayName, shortDisplayName, description, null)
		{
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00007030 File Offset: 0x00006030
		public DataProvider(string name, string displayName, string shortDisplayName, string description, Type targetConnectionType)
		{
			if (name == null)
			{
				throw new ArgumentNullException(#Nk.#Mk.#Lk(1534));
			}
			this.#Ro = name;
			this.#sUc = displayName;
			this.#tUc = shortDisplayName;
			this.#Wq = description;
			this.#uUc = targetConnectionType;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00007070 File Offset: 0x00006070
		public DataProvider(string name, string displayName, string shortDisplayName, string description, Type targetConnectionType, Type connectionPropertiesType) : this(name, displayName, shortDisplayName, description, targetConnectionType)
		{
			if (connectionPropertiesType == null)
			{
				throw new ArgumentNullException(#Nk.#Mk.#Lk(1543));
			}
			this.#xUc = new Dictionary<string, Type>();
			this.#xUc.Add(string.Empty, connectionPropertiesType);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000070C4 File Offset: 0x000060C4
		public DataProvider(string name, string displayName, string shortDisplayName, string description, Type targetConnectionType, Type connectionUIControlType, Type connectionPropertiesType) : this(name, displayName, shortDisplayName, description, targetConnectionType, connectionPropertiesType)
		{
			if (connectionUIControlType == null)
			{
				throw new ArgumentNullException(#Nk.#Mk.#Lk(1576));
			}
			this.#wUc = new Dictionary<string, Type>();
			this.#wUc.Add(string.Empty, connectionUIControlType);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00007118 File Offset: 0x00006118
		public DataProvider(string name, string displayName, string shortDisplayName, string description, Type targetConnectionType, IDictionary<string, Type> connectionUIControlTypes, Type connectionPropertiesType) : this(name, displayName, shortDisplayName, description, targetConnectionType, connectionPropertiesType)
		{
			this.#wUc = connectionUIControlTypes;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00007134 File Offset: 0x00006134
		public DataProvider(string name, string displayName, string shortDisplayName, string description, Type targetConnectionType, IDictionary<string, string> dataSourceDescriptions, IDictionary<string, Type> connectionUIControlTypes, Type connectionPropertiesType) : this(name, displayName, shortDisplayName, description, targetConnectionType, connectionUIControlTypes, connectionPropertiesType)
		{
			this.#vUc = dataSourceDescriptions;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00007150 File Offset: 0x00006150
		public DataProvider(string name, string displayName, string shortDisplayName, string description, Type targetConnectionType, IDictionary<string, string> dataSourceDescriptions, IDictionary<string, Type> connectionUIControlTypes, IDictionary<string, Type> connectionPropertiesTypes) : this(name, displayName, shortDisplayName, description, targetConnectionType)
		{
			this.#vUc = dataSourceDescriptions;
			this.#wUc = connectionUIControlTypes;
			this.#xUc = connectionPropertiesTypes;
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00007178 File Offset: 0x00006178
		public static DataProvider SqlDataProvider
		{
			get
			{
				if (DataProvider.#oUc == null)
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					dictionary.Add(DataSource.SqlDataSource.Name, #cTc.#Mk.DataProvider_Sql_DataSource_Description);
					dictionary.Add(#Nk.#Mk.#Lk(1609), #cTc.#Mk.DataProvider_Sql_FileDataSource_Description);
					Dictionary<string, Type> dictionary2 = new Dictionary<string, Type>();
					dictionary2.Add(DataSource.SqlDataSource.Name, typeof(SqlConnectionUIControl));
					dictionary2.Add(#Nk.#Mk.#Lk(1609), typeof(SqlFileConnectionUIControl));
					dictionary2.Add(string.Empty, typeof(SqlConnectionUIControl));
					Dictionary<string, Type> dictionary3 = new Dictionary<string, Type>();
					dictionary3.Add(#Nk.#Mk.#Lk(1609), typeof(SqlFileConnectionProperties));
					dictionary3.Add(string.Empty, typeof(SqlConnectionProperties));
					DataProvider.#oUc = new DataProvider(#Nk.#Mk.#Lk(1642), #cTc.#Mk.DataProvider_Sql, #cTc.#Mk.DataProvider_Sql_Short, #cTc.#Mk.DataProvider_Sql_Description, typeof(SqlConnection), dictionary, dictionary2, dictionary3);
				}
				return DataProvider.#oUc;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00007278 File Offset: 0x00006278
		public static DataProvider OracleDataProvider
		{
			get
			{
				if (DataProvider.#pUc == null)
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					dictionary.Add(DataSource.OracleDataSource.Name, #cTc.#Mk.DataProvider_Oracle_DataSource_Description);
					Dictionary<string, Type> dictionary2 = new Dictionary<string, Type>();
					dictionary2.Add(string.Empty, typeof(OracleConnectionUIControl));
					DataProvider.#pUc = new DataProvider(#Nk.#Mk.#Lk(1671), #cTc.#Mk.DataProvider_Oracle, #cTc.#Mk.DataProvider_Oracle_Short, #cTc.#Mk.DataProvider_Oracle_Description, typeof(OracleConnection), dictionary, dictionary2, typeof(OracleConnectionProperties));
				}
				return DataProvider.#pUc;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00007300 File Offset: 0x00006300
		public static DataProvider OleDBDataProvider
		{
			get
			{
				if (DataProvider.#qUc == null)
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					dictionary.Add(DataSource.SqlDataSource.Name, #cTc.#Mk.DataProvider_OleDB_SqlDataSource_Description);
					dictionary.Add(DataSource.OracleDataSource.Name, #cTc.#Mk.DataProvider_OleDB_OracleDataSource_Description);
					dictionary.Add(DataSource.AccessDataSource.Name, #cTc.#Mk.DataProvider_OleDB_AccessDataSource_Description);
					Dictionary<string, Type> dictionary2 = new Dictionary<string, Type>();
					dictionary2.Add(DataSource.SqlDataSource.Name, typeof(SqlConnectionUIControl));
					dictionary2.Add(DataSource.OracleDataSource.Name, typeof(OracleConnectionUIControl));
					dictionary2.Add(DataSource.AccessDataSource.Name, typeof(AccessConnectionUIControl));
					dictionary2.Add(string.Empty, typeof(OleDBConnectionUIControl));
					Dictionary<string, Type> dictionary3 = new Dictionary<string, Type>();
					dictionary3.Add(DataSource.SqlDataSource.Name, typeof(OleDBSqlConnectionProperties));
					dictionary3.Add(DataSource.OracleDataSource.Name, typeof(OleDBOracleConnectionProperties));
					dictionary3.Add(DataSource.AccessDataSource.Name, typeof(OleDBAccessConnectionProperties));
					dictionary3.Add(string.Empty, typeof(OleDBConnectionProperties));
					DataProvider.#qUc = new DataProvider(#Nk.#Mk.#Lk(1704), #cTc.#Mk.DataProvider_OleDB, #cTc.#Mk.DataProvider_OleDB_Short, #cTc.#Mk.DataProvider_OleDB_Description, typeof(OleDbConnection), dictionary, dictionary2, dictionary3);
				}
				return DataProvider.#qUc;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00007464 File Offset: 0x00006464
		public static DataProvider OdbcDataProvider
		{
			get
			{
				if (DataProvider.#rUc == null)
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					dictionary.Add(DataSource.OdbcDataSource.Name, #cTc.#Mk.DataProvider_Odbc_DataSource_Description);
					Dictionary<string, Type> dictionary2 = new Dictionary<string, Type>();
					dictionary2.Add(string.Empty, typeof(OdbcConnectionUIControl));
					DataProvider.#rUc = new DataProvider(#Nk.#Mk.#Lk(1729), #cTc.#Mk.DataProvider_Odbc, #cTc.#Mk.DataProvider_Odbc_Short, #cTc.#Mk.DataProvider_Odbc_Description, typeof(OdbcConnection), dictionary, dictionary2, typeof(OdbcConnectionProperties));
				}
				return DataProvider.#rUc;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000106 RID: 262 RVA: 0x000074EC File Offset: 0x000064EC
		public string Name
		{
			get
			{
				return this.#Ro;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000107 RID: 263 RVA: 0x000074F4 File Offset: 0x000064F4
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

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000108 RID: 264 RVA: 0x0000750C File Offset: 0x0000650C
		public string ShortDisplayName
		{
			get
			{
				return this.#tUc;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00007514 File Offset: 0x00006514
		public string Description
		{
			get
			{
				return this.GetDescription(null);
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600010A RID: 266 RVA: 0x00007520 File Offset: 0x00006520
		public Type TargetConnectionType
		{
			get
			{
				return this.#uUc;
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00007528 File Offset: 0x00006528
		public virtual string GetDescription(DataSource dataSource)
		{
			if (this.#vUc != null && dataSource != null && this.#vUc.ContainsKey(dataSource.Name))
			{
				return this.#vUc[dataSource.Name];
			}
			return this.#Wq;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00007560 File Offset: 0x00006560
		public IDataConnectionUIControl CreateConnectionUIControl()
		{
			return this.CreateConnectionUIControl(null);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000756C File Offset: 0x0000656C
		public virtual IDataConnectionUIControl CreateConnectionUIControl(DataSource dataSource)
		{
			string key;
			if ((this.#wUc != null && dataSource != null && this.#wUc.ContainsKey(key = dataSource.Name)) || this.#wUc.ContainsKey(key = string.Empty))
			{
				return Activator.CreateInstance(this.#wUc[key]) as IDataConnectionUIControl;
			}
			return null;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000075C8 File Offset: 0x000065C8
		public IDataConnectionProperties CreateConnectionProperties()
		{
			return this.CreateConnectionProperties(null);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000075D4 File Offset: 0x000065D4
		public virtual IDataConnectionProperties CreateConnectionProperties(DataSource dataSource)
		{
			string key;
			if (this.#xUc != null && ((dataSource != null && this.#xUc.ContainsKey(key = dataSource.Name)) || this.#xUc.ContainsKey(key = string.Empty)))
			{
				return Activator.CreateInstance(this.#xUc[key]) as IDataConnectionProperties;
			}
			return null;
		}

		// Token: 0x0400005E RID: 94
		private static DataProvider #oUc;

		// Token: 0x0400005F RID: 95
		private static DataProvider #pUc;

		// Token: 0x04000060 RID: 96
		private static DataProvider #qUc;

		// Token: 0x04000061 RID: 97
		private static DataProvider #rUc;

		// Token: 0x04000062 RID: 98
		private string #Ro;

		// Token: 0x04000063 RID: 99
		private string #sUc;

		// Token: 0x04000064 RID: 100
		private string #tUc;

		// Token: 0x04000065 RID: 101
		private string #Wq;

		// Token: 0x04000066 RID: 102
		private Type #uUc;

		// Token: 0x04000067 RID: 103
		private IDictionary<string, string> #vUc;

		// Token: 0x04000068 RID: 104
		private IDictionary<string, Type> #wUc;

		// Token: 0x04000069 RID: 105
		private IDictionary<string, Type> #xUc;
	}
}
