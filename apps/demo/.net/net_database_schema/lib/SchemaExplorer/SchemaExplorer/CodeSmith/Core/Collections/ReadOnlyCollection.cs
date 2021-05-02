using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeSmith.Core.Collections
{
	// Token: 0x020000D9 RID: 217
	public class ReadOnlyCollection<T> : IEnumerable, IEnumerable<T>, IReadOnlyCollection<T>
	{
		// Token: 0x060007BD RID: 1981 RVA: 0x00026708 File Offset: 0x00025708
		public ReadOnlyCollection(IEnumerable<T> items)
		{
			this._items = new List<T>(items);
		}

		// Token: 0x170001EC RID: 492
		public T this[int index]
		{
			get
			{
				return this._items[index];
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x060007BF RID: 1983 RVA: 0x0002672C File Offset: 0x0002572C
		public int Count
		{
			get
			{
				return this._items.Count;
			}
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x0002673C File Offset: 0x0002573C
		public IEnumerator<T> GetEnumerator()
		{
			return this._items.GetEnumerator();
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x0002674C File Offset: 0x0002574C
		IEnumerator IEnumerable.#Sl()
		{
			return this._items.GetEnumerator();
		}

		// Token: 0x04000306 RID: 774
		protected readonly IList<T> _items;
	}
}
