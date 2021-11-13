using System;
using System.ComponentModel;
using CodeSmith.Core.Collections;
using CodeSmith.Engine.Json;
using SchemaExplorer.Serialization;

namespace SchemaExplorer
{
	// Token: 0x02000043 RID: 67
	[JsonConverter(typeof(DatabaseSchemaSerializer))]
	public interface ISchemaObject : CodeSmith.Core.Collections.INamedObject
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060002FD RID: 765
		DateTime DateCreated { get; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060002FE RID: 766
		// (set) Token: 0x060002FF RID: 767
		[Description("The description of the schema object. The description can be set if the provider supports it.")]
		string Description { get; set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000300 RID: 768
		[Description("Used to store any additional information about the schema object. The meta data can be set if the provider supports it.")]
		CodeSmith.Core.Collections.INamedObjectCollection<IExtendedProperty> ExtendedProperties { get; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000301 RID: 769
		IExtendedProperty[] DefaultExtendedProperties { get; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000302 RID: 770
		[Browsable(false)]
		IDatabaseSchema Database { get; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000303 RID: 771
		// (set) Token: 0x06000304 RID: 772
		bool DeepLoad { get; set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000305 RID: 773
		// (set) Token: 0x06000306 RID: 774
		bool IncludeFunctions { get; set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000307 RID: 775
		string FullName { get; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000308 RID: 776
		string SortName { get; }

		// Token: 0x06000309 RID: 777
		void Refresh();
	}
}
