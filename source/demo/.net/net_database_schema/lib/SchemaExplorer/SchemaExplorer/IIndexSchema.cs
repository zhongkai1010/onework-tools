using System;
using System.ComponentModel;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000095 RID: 149
	public interface IIndexSchema : CodeSmith.Core.Collections.INamedObject, ISchemaObject
	{
		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000539 RID: 1337
		[Browsable(false)]
		ITableSchema Table { get; }

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x0600053A RID: 1338
		bool IsPrimaryKey { get; }

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x0600053B RID: 1339
		bool IsUnique { get; }

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x0600053C RID: 1340
		bool IsClustered { get; }

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x0600053D RID: 1341
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IMemberColumnSchema> MemberColumns { get; }
	}
}
