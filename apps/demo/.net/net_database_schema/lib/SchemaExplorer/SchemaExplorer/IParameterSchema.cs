using System;
using System.ComponentModel;
using System.Data;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x0200009B RID: 155
	public interface IParameterSchema : CodeSmith.Core.Collections.INamedObject, ISchemaObject, IDataObject
	{
		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000577 RID: 1399
		[Browsable(false)]
		ICommandSchema Command { get; }

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000578 RID: 1400
		ParameterDirection Direction { get; }
	}
}
