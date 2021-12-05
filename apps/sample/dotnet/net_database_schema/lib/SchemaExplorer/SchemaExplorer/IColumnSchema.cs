using System;
using System.ComponentModel;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000061 RID: 97
	public interface IColumnSchema : CodeSmith.Core.Collections.INamedObject, ISchemaObject, IDataObject
	{
		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060003BA RID: 954
		[Browsable(false)]
		ITableSchema Table { get; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060003BB RID: 955
		bool IsPrimaryKeyMember { get; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060003BC RID: 956
		bool IsForeignKeyMember { get; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060003BD RID: 957
		bool IsUnique { get; }
	}
}
