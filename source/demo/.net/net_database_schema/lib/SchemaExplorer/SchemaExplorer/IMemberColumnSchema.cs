using System;
using System.ComponentModel;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000098 RID: 152
	public interface IMemberColumnSchema : CodeSmith.Core.Collections.INamedObject, ISchemaObject, IColumnSchema, IDataObject
	{
		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000552 RID: 1362
		[Browsable(false)]
		IColumnSchema Column { get; }

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000553 RID: 1363
		[Browsable(false)]
		CodeSmith.Core.Collections.INamedObjectCollection<IExtendedProperty> ColumnExtendedProperties { get; }
	}
}
