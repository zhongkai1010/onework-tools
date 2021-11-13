using System;
using System.ComponentModel;

namespace CodeSmith.Core.Collections
{
	// Token: 0x0200003D RID: 61
	public interface INamedObject
	{
		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060002EA RID: 746
		[Description("The Name of the schema object.")]
		string Name { get; }
	}
}
