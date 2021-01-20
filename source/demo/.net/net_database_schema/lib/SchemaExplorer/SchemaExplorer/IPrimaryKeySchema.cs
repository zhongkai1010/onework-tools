using System;
using System.ComponentModel;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x0200009E RID: 158
	public interface IPrimaryKeySchema : CodeSmith.Core.Collections.INamedObject, ISchemaObject
	{
		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000583 RID: 1411
		[Browsable(false)]
		ITableSchema Table { get; }

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000584 RID: 1412
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IMemberColumnSchema> MemberColumns { get; }
	}
}
