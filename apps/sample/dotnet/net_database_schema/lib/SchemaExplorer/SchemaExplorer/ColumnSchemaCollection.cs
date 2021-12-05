using System;
using System.Collections.Generic;

namespace SchemaExplorer
{
	// Token: 0x02000065 RID: 101
	[Serializable]
	public class ColumnSchemaCollection : DataObjectBaseCollection<ColumnSchema>
	{
		// Token: 0x060003E5 RID: 997 RVA: 0x000140FC File Offset: 0x000130FC
		public ColumnSchemaCollection()
		{
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00014104 File Offset: 0x00013104
		public ColumnSchemaCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00014110 File Offset: 0x00013110
		public ColumnSchemaCollection(IEnumerable<ColumnSchema> collection) : base(collection)
		{
		}
	}
}
