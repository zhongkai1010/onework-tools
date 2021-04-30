using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeSmith.Core.Collections
{
	// Token: 0x02000051 RID: 81
	public interface IReadOnlyNamedObjectCollection<out T> : IEnumerable, IEnumerable<T>, IReadOnlyCollection<T> where T : INamedObject
	{
		// Token: 0x170000CF RID: 207
		T this[string name]
		{
			get;
		}

		// Token: 0x06000335 RID: 821
		bool Contains(string name);

		// Token: 0x06000336 RID: 822
		int IndexOf(string name);
	}
}
