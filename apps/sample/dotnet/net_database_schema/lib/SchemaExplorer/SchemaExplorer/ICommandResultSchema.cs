using System;
using System.ComponentModel;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x0200007A RID: 122
	public interface ICommandResultSchema : CodeSmith.Core.Collections.INamedObject, ISchemaObject, ISchemaObjectWithOwner, ITabularObject
	{
		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000461 RID: 1121
		[Browsable(false)]
		ICommandSchema Command { get; }

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000462 RID: 1122
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<ICommandResultColumnSchema> Columns { get; }
	}
}
