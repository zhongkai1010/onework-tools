using System;
using System.Collections.Generic;

namespace SchemaExplorer
{
	// Token: 0x020000B0 RID: 176
	[Serializable]
	public class TableSchemaCollection : SchemaObjectWithOwnerCollection<TableSchema>
	{
		// Token: 0x06000612 RID: 1554 RVA: 0x00019018 File Offset: 0x00018018
		public TableSchemaCollection()
		{
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x00019020 File Offset: 0x00018020
		public TableSchemaCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x0001902C File Offset: 0x0001802C
		public TableSchemaCollection(IEnumerable<TableSchema> collection) : base(collection)
		{
		}
	}
}
