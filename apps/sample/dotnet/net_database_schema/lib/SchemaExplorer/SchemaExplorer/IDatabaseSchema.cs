using System;
using System.ComponentModel;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x0200006B RID: 107
	public interface IDatabaseSchema : CodeSmith.Core.Collections.INamedObject, ISchemaObject
	{
		// Token: 0x17000119 RID: 281
		// (get) Token: 0x0600041B RID: 1051
		// (set) Token: 0x0600041C RID: 1052
		[Browsable(false)]
		IDbSchemaProvider Provider { get; set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600041D RID: 1053
		// (set) Token: 0x0600041E RID: 1054
		[Browsable(false)]
		[ReadOnly(true)]
		string ConnectionString { get; set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600041F RID: 1055
		[Browsable(false)]
		IReadOnlySchemaObjectWithOwnerCollection<ITableSchema> Tables { get; }

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000420 RID: 1056
		[Browsable(false)]
		IReadOnlySchemaObjectWithOwnerCollection<IViewSchema> Views { get; }

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000421 RID: 1057
		[Browsable(false)]
		IReadOnlySchemaObjectWithOwnerCollection<ICommandSchema> Commands { get; }
	}
}
