using System;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000008 RID: 8
	public interface IDataConnectionProperties
	{
		// Token: 0x0600004C RID: 76
		void Add(string propertyName);

		// Token: 0x0600004D RID: 77
		bool Contains(string propertyName);

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600004E RID: 78
		bool IsComplete { get; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600004F RID: 79
		bool IsExtensible { get; }

		// Token: 0x06000050 RID: 80
		void Parse(string s);

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000051 RID: 81
		// (remove) Token: 0x06000052 RID: 82
		event EventHandler PropertyChanged;

		// Token: 0x06000053 RID: 83
		void Remove(string propertyName);

		// Token: 0x06000054 RID: 84
		void Reset();

		// Token: 0x06000055 RID: 85
		void Reset(string propertyName);

		// Token: 0x06000056 RID: 86
		void Test();

		// Token: 0x1700000F RID: 15
		object this[string propertyName]
		{
			get;
			set;
		}

		// Token: 0x06000059 RID: 89
		string ToDisplayString();

		// Token: 0x0600005A RID: 90
		string ToFullString();
	}
}
