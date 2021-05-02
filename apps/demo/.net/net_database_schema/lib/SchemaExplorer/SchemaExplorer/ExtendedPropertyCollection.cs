using System;
using System.Collections.Generic;
using System.ComponentModel;
using ActiproSoftware.Windows.Controls.PropertyGrid.Editors;
using CodeSmith.Core.Collections;
using SchemaExplorer.Design;

namespace SchemaExplorer
{
	// Token: 0x02000090 RID: 144
	[TypeConverter(typeof(ExtendedPropertyCollectionTypeConverter))]
	[Editor(typeof(SchemaObjectEditor), typeof(PropertyEditor))]
	[Serializable]
	public class ExtendedPropertyCollection : CodeSmith.Core.Collections.NamedObjectCollection<ExtendedProperty>
	{
		// Token: 0x06000526 RID: 1318 RVA: 0x0001722C File Offset: 0x0001622C
		public ExtendedPropertyCollection()
		{
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x00017234 File Offset: 0x00016234
		public ExtendedPropertyCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x00017240 File Offset: 0x00016240
		public ExtendedPropertyCollection(IEnumerable<ExtendedProperty> collection) : base(collection)
		{
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0001724C File Offset: 0x0001624C
		public virtual object Clone()
		{
			return new ExtendedPropertyCollection(this);
		}
	}
}
