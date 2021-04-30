using System;
using System.ComponentModel;
using System.Data;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x0200008E RID: 142
	public interface IExtendedProperty : INotifyPropertyChanged, CodeSmith.Core.Collections.INamedObject
	{
		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600050E RID: 1294
		// (set) Token: 0x0600050F RID: 1295
		object Value { get; set; }

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000510 RID: 1296
		DbType DataType { get; }

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000511 RID: 1297
		// (set) Token: 0x06000512 RID: 1298
		[Bindable(false)]
		PropertyStateEnum PropertyState { get; set; }
	}
}
