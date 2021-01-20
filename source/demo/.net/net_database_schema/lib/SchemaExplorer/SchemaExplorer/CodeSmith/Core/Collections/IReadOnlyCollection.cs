using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeSmith.Core.Collections
{
	// Token: 0x02000052 RID: 82
	public interface IReadOnlyCollection<out T> : IEnumerable, IEnumerable<T>
	{
		// Token: 0x170000D0 RID: 208
		T this[int index]
		{
			get;
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000338 RID: 824
		int Count { get; }
	}
}
