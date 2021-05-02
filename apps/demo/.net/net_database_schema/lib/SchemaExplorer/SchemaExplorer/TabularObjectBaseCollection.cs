using System;
using System.Collections.Generic;

namespace SchemaExplorer
{
	// Token: 0x02000076 RID: 118
	[Serializable]
	public class TabularObjectBaseCollection : SchemaObjectWithOwnerCollection<ITabularObject>
	{
		// Token: 0x06000454 RID: 1108 RVA: 0x00014FD4 File Offset: 0x00013FD4
		public TabularObjectBaseCollection()
		{
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00014FDC File Offset: 0x00013FDC
		public TabularObjectBaseCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00014FE8 File Offset: 0x00013FE8
		public TabularObjectBaseCollection(IEnumerable<ITabularObject> collection) : base(collection)
		{
		}
	}
}
