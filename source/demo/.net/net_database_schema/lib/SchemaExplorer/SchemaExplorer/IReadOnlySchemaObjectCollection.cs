using System;
using System.Collections;
using System.Collections.Generic;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000053 RID: 83
	public interface IReadOnlySchemaObjectCollection<out T> : IEnumerable, IEnumerable<T>, CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<T>, CodeSmith.Core.Collections.IReadOnlyCollection<T> where T : ISchemaObject
	{
		// Token: 0x06000339 RID: 825
		void Refresh();
	}
}
