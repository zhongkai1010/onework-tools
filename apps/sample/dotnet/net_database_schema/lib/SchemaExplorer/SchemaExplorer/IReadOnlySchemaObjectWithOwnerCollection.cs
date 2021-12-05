using System;
using System.Collections;
using System.Collections.Generic;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000057 RID: 87
	public interface IReadOnlySchemaObjectWithOwnerCollection<out T> : IEnumerable, IEnumerable<T>, CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<T>, CodeSmith.Core.Collections.IReadOnlyCollection<T>, IReadOnlySchemaObjectCollection<T> where T : ISchemaObjectWithOwner
	{
		// Token: 0x170000E1 RID: 225
		T this[string owner, string name]
		{
			get;
		}

		// Token: 0x06000366 RID: 870
		bool Contains(string owner, string name);

		// Token: 0x06000367 RID: 871
		int IndexOf(string owner, string name);
	}
}
