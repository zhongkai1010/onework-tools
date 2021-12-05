using System;
using System.Collections.Generic;

namespace SchemaExplorer
{
	// Token: 0x02000066 RID: 102
	[Serializable]
	public class DataObjectBaseCollection<T> : SchemaObjectCollection<T> where T : IDataObject
	{
		// Token: 0x060003E8 RID: 1000 RVA: 0x0001411C File Offset: 0x0001311C
		public DataObjectBaseCollection()
		{
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00014124 File Offset: 0x00013124
		public DataObjectBaseCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00014130 File Offset: 0x00013130
		public DataObjectBaseCollection(IEnumerable<T> collection) : base(collection)
		{
		}
	}
}
