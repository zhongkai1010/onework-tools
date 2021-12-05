using System;
using System.ComponentModel;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x020000AA RID: 170
	public interface ITableKeySchema : CodeSmith.Core.Collections.INamedObject, ISchemaObject
	{
		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060005BD RID: 1469
		[Browsable(false)]
		ITableSchema ForeignKeyTable { get; }

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060005BE RID: 1470
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IMemberColumnSchema> ForeignKeyMemberColumns { get; }

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060005BF RID: 1471
		[Browsable(false)]
		ITableSchema PrimaryKeyTable { get; }

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x060005C0 RID: 1472
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IMemberColumnSchema> PrimaryKeyMemberColumns { get; }

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060005C1 RID: 1473
		[Browsable(false)]
		IPrimaryKeySchema PrimaryKey { get; }
	}
}
