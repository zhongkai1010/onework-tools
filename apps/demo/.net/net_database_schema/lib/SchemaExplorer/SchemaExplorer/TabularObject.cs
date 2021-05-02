using System;
using System.Linq;

namespace SchemaExplorer
{
	// Token: 0x02000074 RID: 116
	public class TabularObject : TabularObjectBase
	{
		// Token: 0x0600044B RID: 1099 RVA: 0x00014ED4 File Offset: 0x00013ED4
		public TabularObject(ITabularObject tabularObject) : base((DatabaseSchema)tabularObject.Database, tabularObject.Name, tabularObject.Owner, tabularObject.DateCreated, tabularObject.DefaultExtendedProperties.Cast<ExtendedProperty>().ToArray<ExtendedProperty>())
		{
		}
	}
}
