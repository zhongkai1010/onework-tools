using System;
using System.ComponentModel;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x020000B1 RID: 177
	public interface IViewColumnSchema : CodeSmith.Core.Collections.INamedObject, ISchemaObject, IDataObject
	{
		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000615 RID: 1557
		[Browsable(false)]
		IViewSchema View { get; }
	}
}
