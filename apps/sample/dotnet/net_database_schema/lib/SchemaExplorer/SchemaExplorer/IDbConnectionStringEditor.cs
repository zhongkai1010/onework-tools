using System;

namespace SchemaExplorer
{
	// Token: 0x02000060 RID: 96
	public interface IDbConnectionStringEditor
	{
		// Token: 0x060003B7 RID: 951
		bool ShowEditor(string currentConnectionString);

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060003B8 RID: 952
		string ConnectionString { get; }

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060003B9 RID: 953
		bool EditorAvailable { get; }
	}
}
