using System;
using System.Collections.Generic;

namespace SchemaExplorer
{
	// Token: 0x02000086 RID: 134
	[Obsolete("Please use DataObjectBaseCollection{T} instead.")]
	[Serializable]
	public class DataObjectBaseCollection : SchemaObjectCollection<DataObjectBase>
	{
		// Token: 0x060004C0 RID: 1216 RVA: 0x00015EB4 File Offset: 0x00014EB4
		public DataObjectBaseCollection()
		{
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00015EBC File Offset: 0x00014EBC
		public DataObjectBaseCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00015EC8 File Offset: 0x00014EC8
		public DataObjectBaseCollection(IEnumerable<DataObjectBase> collection) : base(collection)
		{
		}
	}
}
