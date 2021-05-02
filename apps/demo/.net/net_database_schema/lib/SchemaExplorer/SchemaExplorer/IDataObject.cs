using System;
using System.Data;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000062 RID: 98
	public interface IDataObject : CodeSmith.Core.Collections.INamedObject, ISchemaObject
	{
		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060003BE RID: 958
		DbType DataType { get; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060003BF RID: 959
		Type SystemType { get; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060003C0 RID: 960
		string NativeType { get; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060003C1 RID: 961
		int Size { get; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060003C2 RID: 962
		byte Precision { get; }

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060003C3 RID: 963
		int Scale { get; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060003C4 RID: 964
		bool AllowDBNull { get; }

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060003C5 RID: 965
		ISchemaObject Parent { get; }
	}
}
