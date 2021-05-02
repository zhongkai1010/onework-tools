using System;
using System.Collections.Generic;

namespace SchemaExplorer
{
	// Token: 0x0200007C RID: 124
	[Serializable]
	public class CommandResultSchemaCollection : SchemaObjectWithOwnerCollection<CommandResultSchema>
	{
		// Token: 0x0600046A RID: 1130 RVA: 0x0001517C File Offset: 0x0001417C
		public CommandResultSchemaCollection()
		{
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00015184 File Offset: 0x00014184
		public CommandResultSchemaCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00015190 File Offset: 0x00014190
		public CommandResultSchemaCollection(IEnumerable<CommandResultSchema> collection) : base(collection)
		{
		}
	}
}
