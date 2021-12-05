using System;
using System.ComponentModel;
using System.Data;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000072 RID: 114
	public interface ITabularObject : CodeSmith.Core.Collections.INamedObject, ISchemaObject, ISchemaObjectWithOwner
	{
		// Token: 0x06000448 RID: 1096
		DataTable GetData();

		// Token: 0x1700011E RID: 286
		[Browsable(false)]
		IDataObject this[int index]
		{
			get;
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600044A RID: 1098
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IDataObject> DataObjects { get; }
	}
}
