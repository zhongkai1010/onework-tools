using System;
using System.ComponentModel;
using System.Data;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x020000B4 RID: 180
	public interface IViewSchema : CodeSmith.Core.Collections.INamedObject, ISchemaObject, ISchemaObjectWithOwner, ITabularObject
	{
		// Token: 0x06000624 RID: 1572
		DataTable GetViewData();

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000625 RID: 1573
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IViewColumnSchema> Columns { get; }

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000626 RID: 1574
		[Browsable(false)]
		string ViewText { get; }
	}
}
