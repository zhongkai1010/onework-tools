using System;
using System.Collections.Generic;

namespace SchemaExplorer
{
	// Token: 0x0200009D RID: 157
	[Serializable]
	public class ParameterSchemaCollection : SchemaObjectCollection<ParameterSchema>
	{
		// Token: 0x06000580 RID: 1408 RVA: 0x00017998 File Offset: 0x00016998
		public ParameterSchemaCollection()
		{
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x000179A0 File Offset: 0x000169A0
		public ParameterSchemaCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x000179AC File Offset: 0x000169AC
		public ParameterSchemaCollection(IEnumerable<ParameterSchema> collection) : base(collection)
		{
		}
	}
}
