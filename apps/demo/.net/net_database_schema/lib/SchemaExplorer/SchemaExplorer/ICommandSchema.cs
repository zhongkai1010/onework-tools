using System;
using System.ComponentModel;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x0200007D RID: 125
	public interface ICommandSchema : CodeSmith.Core.Collections.INamedObject, ISchemaObject, ISchemaObjectWithOwner
	{
		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600046D RID: 1133
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IParameterSchema> Parameters { get; }

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600046E RID: 1134
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<ICommandResultSchema> CommandResults { get; }

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600046F RID: 1135
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IParameterSchema> InputParameters { get; }

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000470 RID: 1136
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IParameterSchema> OutputParameters { get; }

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000471 RID: 1137
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IParameterSchema> InputOutputParameters { get; }

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000472 RID: 1138
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IParameterSchema> AllInputParameters { get; }

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000473 RID: 1139
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IParameterSchema> AllOutputParameters { get; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000474 RID: 1140
		[Browsable(false)]
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IParameterSchema> NonReturnValueParameters { get; }

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000475 RID: 1141
		[Browsable(false)]
		IParameterSchema ReturnValueParameter { get; }

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000476 RID: 1142
		[Browsable(false)]
		string CommandText { get; }
	}
}
