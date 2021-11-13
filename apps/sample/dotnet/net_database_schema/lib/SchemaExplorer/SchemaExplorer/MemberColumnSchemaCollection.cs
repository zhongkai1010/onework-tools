using System;
using System.Collections.Generic;

namespace SchemaExplorer
{
	// Token: 0x0200009A RID: 154
	[Serializable]
	public class MemberColumnSchemaCollection : SchemaObjectCollection<MemberColumnSchema>
	{
		// Token: 0x06000571 RID: 1393 RVA: 0x00017814 File Offset: 0x00016814
		public MemberColumnSchemaCollection()
		{
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x0001781C File Offset: 0x0001681C
		public MemberColumnSchemaCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x00017828 File Offset: 0x00016828
		public MemberColumnSchemaCollection(IEnumerable<MemberColumnSchema> collection) : base(collection)
		{
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x00017834 File Offset: 0x00016834
		public virtual bool Contains(ColumnSchema value)
		{
			return this.IndexOf(value) >= 0;
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x00017844 File Offset: 0x00016844
		public virtual int IndexOf(ColumnSchema value)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base[i].Column == value)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x00017874 File Offset: 0x00016874
		public static implicit operator ColumnSchemaCollection(MemberColumnSchemaCollection memberColumns)
		{
			ColumnSchemaCollection columnSchemaCollection = new ColumnSchemaCollection();
			foreach (MemberColumnSchema memberColumnSchema in memberColumns)
			{
				columnSchemaCollection.Add(memberColumnSchema.Column);
			}
			return columnSchemaCollection;
		}
	}
}
