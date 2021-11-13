using System;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000049 RID: 73
	public interface ISchemaObjectWithOwner : CodeSmith.Core.Collections.INamedObject, ISchemaObject
	{
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000317 RID: 791
		string Owner { get; }
	}
}
