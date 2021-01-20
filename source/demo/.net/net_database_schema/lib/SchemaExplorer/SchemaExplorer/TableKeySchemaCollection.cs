using System;
using System.Collections.Generic;

namespace SchemaExplorer
{
	// Token: 0x020000AC RID: 172
	[Serializable]
	public class TableKeySchemaCollection : SchemaObjectCollection<TableKeySchema>
	{
		// Token: 0x060005D5 RID: 1493 RVA: 0x00018A08 File Offset: 0x00017A08
		public TableKeySchemaCollection()
		{
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x00018A10 File Offset: 0x00017A10
		public TableKeySchemaCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x00018A1C File Offset: 0x00017A1C
		public TableKeySchemaCollection(IEnumerable<TableKeySchema> collection) : base(collection)
		{
		}
	}
}
