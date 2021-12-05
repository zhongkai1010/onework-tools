using System;
using System.ComponentModel;
using System.Data;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x020000AD RID: 173
	public interface ITableSchema : CodeSmith.Core.Collections.INamedObject, ISchemaObject, ISchemaObjectWithOwner, ITabularObject
	{
		// Token: 0x060005D8 RID: 1496
		DataTable GetTableData();

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x060005D9 RID: 1497
		[Browsable(false)]
		bool HasPrimaryKey { get; }

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x060005DA RID: 1498
		[Browsable(false)]
		IPrimaryKeySchema PrimaryKey { get; }

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x060005DB RID: 1499
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<ITableKeySchema> Keys { get; }

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x060005DC RID: 1500
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<ITableKeySchema> ForeignKeys { get; }

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x060005DD RID: 1501
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<ITableKeySchema> PrimaryKeys { get; }

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x060005DE RID: 1502
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IIndexSchema> Indexes { get; }

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x060005DF RID: 1503
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IColumnSchema> Columns { get; }

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x060005E0 RID: 1504
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IColumnSchema> NonPrimaryKeyColumns { get; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x060005E1 RID: 1505
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IColumnSchema> NonKeyColumns { get; }

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x060005E2 RID: 1506
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IColumnSchema> NonForeignKeyColumns { get; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x060005E3 RID: 1507
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IColumnSchema> ForeignKeyColumns { get; }
	}
}
