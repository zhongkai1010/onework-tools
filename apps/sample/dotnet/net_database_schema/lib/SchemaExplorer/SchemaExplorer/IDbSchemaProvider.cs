using System;
using System.Data;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x0200005F RID: 95
	public interface IDbSchemaProvider : CodeSmith.Core.Collections.INamedObject
	{
		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060003A5 RID: 933
		string Description { get; }

		// Token: 0x060003A6 RID: 934
		string GetDatabaseName(string connectionString);

		// Token: 0x060003A7 RID: 935
		ExtendedProperty[] GetExtendedProperties(string connectionString, SchemaObjectBase schemaObject);

		// Token: 0x060003A8 RID: 936
		void SetExtendedProperties(string connectionString, SchemaObjectBase schemaObject);

		// Token: 0x060003A9 RID: 937
		TableSchema[] GetTables(string connectionString, DatabaseSchema database);

		// Token: 0x060003AA RID: 938
		ColumnSchema[] GetTableColumns(string connectionString, TableSchema table);

		// Token: 0x060003AB RID: 939
		ViewSchema[] GetViews(string connectionString, DatabaseSchema database);

		// Token: 0x060003AC RID: 940
		ViewColumnSchema[] GetViewColumns(string connectionString, ViewSchema view);

		// Token: 0x060003AD RID: 941
		string GetViewText(string connectionString, ViewSchema view);

		// Token: 0x060003AE RID: 942
		PrimaryKeySchema GetTablePrimaryKey(string connectionString, TableSchema table);

		// Token: 0x060003AF RID: 943
		TableKeySchema[] GetTableKeys(string connectionString, TableSchema table);

		// Token: 0x060003B0 RID: 944
		IndexSchema[] GetTableIndexes(string connectionString, TableSchema table);

		// Token: 0x060003B1 RID: 945
		DataTable GetTableData(string connectionString, TableSchema table);

		// Token: 0x060003B2 RID: 946
		DataTable GetViewData(string connectionString, ViewSchema view);

		// Token: 0x060003B3 RID: 947
		CommandSchema[] GetCommands(string connectionString, DatabaseSchema database);

		// Token: 0x060003B4 RID: 948
		ParameterSchema[] GetCommandParameters(string connectionString, CommandSchema command);

		// Token: 0x060003B5 RID: 949
		string GetCommandText(string connectionString, CommandSchema command);

		// Token: 0x060003B6 RID: 950
		CommandResultSchema[] GetCommandResultSchemas(string connectionString, CommandSchema command);
	}
}
