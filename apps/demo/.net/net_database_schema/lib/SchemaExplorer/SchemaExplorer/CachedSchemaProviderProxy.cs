using System;
using System.Data;
using #n1c;
using #Nk;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x0200005E RID: 94
	public class CachedSchemaProviderProxy : CodeSmith.Core.Collections.INamedObject, IDbSchemaProvider, IDbConnectionStringEditor
	{
		// Token: 0x0600038C RID: 908 RVA: 0x00013AA0 File Offset: 0x00012AA0
		public CachedSchemaProviderProxy(IDbSchemaProvider provider)
		{
			this.#aQc = provider;
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x0600038D RID: 909 RVA: 0x00013AB0 File Offset: 0x00012AB0
		public IDbSchemaProvider Provider
		{
			get
			{
				return this.#aQc;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x0600038E RID: 910 RVA: 0x00013AB8 File Offset: 0x00012AB8
		public IDbConnectionStringEditor ConnectionStringEditor
		{
			get
			{
				return this.#aQc as IDbConnectionStringEditor;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600038F RID: 911 RVA: 0x00013AC8 File Offset: 0x00012AC8
		public string Name
		{
			get
			{
				return this.#aQc.Name;
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000390 RID: 912 RVA: 0x00013AD8 File Offset: 0x00012AD8
		public string Description
		{
			get
			{
				return this.#aQc.Description;
			}
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00013AE8 File Offset: 0x00012AE8
		public string GetDatabaseName(string connectionString)
		{
			return this.#aQc.GetDatabaseName(connectionString);
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00013AF8 File Offset: 0x00012AF8
		public ExtendedProperty[] GetExtendedProperties(string connectionString, SchemaObjectBase schemaObject)
		{
			return this.#aQc.GetExtendedProperties(connectionString, schemaObject);
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00013B08 File Offset: 0x00012B08
		public void SetExtendedProperties(string connectionString, SchemaObjectBase schemaObject)
		{
			this.#aQc.SetExtendedProperties(connectionString, schemaObject);
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00013B18 File Offset: 0x00012B18
		public TableSchema[] GetTables(string connectionString, DatabaseSchema database)
		{
			if (#s1c.Instance.#r1c(connectionString.GetHashCode() + #Mk.#Lk(8369)))
			{
				return #s1c.Instance.#q1c(connectionString.GetHashCode() + #Mk.#Lk(8369)) as TableSchema[];
			}
			TableSchema[] tables = this.#aQc.GetTables(connectionString, database);
			#s1c.Instance.#p1c(connectionString.GetHashCode() + #Mk.#Lk(8369), tables);
			return tables;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00013BAC File Offset: 0x00012BAC
		public ColumnSchema[] GetTableColumns(string connectionString, TableSchema table)
		{
			return this.#aQc.GetTableColumns(connectionString, table);
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00013BBC File Offset: 0x00012BBC
		public ViewSchema[] GetViews(string connectionString, DatabaseSchema database)
		{
			if (#s1c.Instance.#r1c(connectionString.GetHashCode() + #Mk.#Lk(8386)))
			{
				return #s1c.Instance.#q1c(connectionString.GetHashCode() + #Mk.#Lk(8386)) as ViewSchema[];
			}
			ViewSchema[] views = this.#aQc.GetViews(connectionString, database);
			#s1c.Instance.#p1c(connectionString.GetHashCode() + #Mk.#Lk(8386), views);
			return views;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00013C50 File Offset: 0x00012C50
		public ViewColumnSchema[] GetViewColumns(string connectionString, ViewSchema view)
		{
			return this.#aQc.GetViewColumns(connectionString, view);
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00013C60 File Offset: 0x00012C60
		public string GetViewText(string connectionString, ViewSchema view)
		{
			return this.#aQc.GetViewText(connectionString, view);
		}

		// Token: 0x06000399 RID: 921 RVA: 0x00013C70 File Offset: 0x00012C70
		public PrimaryKeySchema GetTablePrimaryKey(string connectionString, TableSchema table)
		{
			return this.#aQc.GetTablePrimaryKey(connectionString, table);
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00013C80 File Offset: 0x00012C80
		public TableKeySchema[] GetTableKeys(string connectionString, TableSchema table)
		{
			return this.#aQc.GetTableKeys(connectionString, table);
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00013C90 File Offset: 0x00012C90
		public IndexSchema[] GetTableIndexes(string connectionString, TableSchema table)
		{
			return this.#aQc.GetTableIndexes(connectionString, table);
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00013CA0 File Offset: 0x00012CA0
		public DataTable GetTableData(string connectionString, TableSchema table)
		{
			return this.#aQc.GetTableData(connectionString, table);
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00013CB0 File Offset: 0x00012CB0
		public DataTable GetViewData(string connectionString, ViewSchema view)
		{
			return this.#aQc.GetViewData(connectionString, view);
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00013CC0 File Offset: 0x00012CC0
		public CommandSchema[] GetCommands(string connectionString, DatabaseSchema database)
		{
			if (#s1c.Instance.#r1c(connectionString.GetHashCode() + #Mk.#Lk(8399)))
			{
				return #s1c.Instance.#q1c(connectionString.GetHashCode() + #Mk.#Lk(8399)) as CommandSchema[];
			}
			CommandSchema[] commands = this.#aQc.GetCommands(connectionString, database);
			#s1c.Instance.#p1c(connectionString.GetHashCode() + #Mk.#Lk(8399), commands);
			return commands;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00013D54 File Offset: 0x00012D54
		public ParameterSchema[] GetCommandParameters(string connectionString, CommandSchema command)
		{
			return this.#aQc.GetCommandParameters(connectionString, command);
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x00013D64 File Offset: 0x00012D64
		public string GetCommandText(string connectionString, CommandSchema command)
		{
			return this.#aQc.GetCommandText(connectionString, command);
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00013D74 File Offset: 0x00012D74
		public CommandResultSchema[] GetCommandResultSchemas(string connectionString, CommandSchema command)
		{
			return this.#aQc.GetCommandResultSchemas(connectionString, command);
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00013D84 File Offset: 0x00012D84
		public bool ShowEditor(string currentConnectionString)
		{
			return this.ConnectionStringEditor.ShowEditor(currentConnectionString);
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x00013D94 File Offset: 0x00012D94
		public string ConnectionString
		{
			get
			{
				return this.ConnectionStringEditor.ConnectionString;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x00013DA4 File Offset: 0x00012DA4
		public bool EditorAvailable
		{
			get
			{
				return this.ConnectionStringEditor.EditorAvailable;
			}
		}

		// Token: 0x04000170 RID: 368
		private readonly IDbSchemaProvider #aQc;
	}
}
