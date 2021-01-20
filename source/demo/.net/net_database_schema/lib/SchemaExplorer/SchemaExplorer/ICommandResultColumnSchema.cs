using System;
using System.ComponentModel;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000077 RID: 119
	public interface ICommandResultColumnSchema : CodeSmith.Core.Collections.INamedObject, ISchemaObject, IDataObject
	{
		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000457 RID: 1111
		[Browsable(false)]
		ICommandSchema Command { get; }
	}
}
