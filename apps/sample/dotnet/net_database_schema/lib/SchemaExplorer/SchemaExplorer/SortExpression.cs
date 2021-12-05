using System;
using System.Collections;
using System.ComponentModel;

namespace SchemaExplorer
{
	// Token: 0x020000A1 RID: 161
	public struct SortExpression
	{
		// Token: 0x06000593 RID: 1427 RVA: 0x00017B6C File Offset: 0x00016B6C
		public SortExpression(string propertyName)
		{
			this.PropertyName = propertyName;
			this.SortDirection = ListSortDirection.Ascending;
			this.PropertyDescriptor = null;
			this.#e1c = new Hashtable();
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x00017B90 File Offset: 0x00016B90
		public SortExpression(string propertyName, ListSortDirection sortDirection)
		{
			this.PropertyName = propertyName;
			this.SortDirection = sortDirection;
			this.PropertyDescriptor = null;
			this.#e1c = new Hashtable();
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x00017BB4 File Offset: 0x00016BB4
		public object GetPropertyValue(object obj)
		{
			if (this.PropertyDescriptor == null)
			{
				return null;
			}
			if (this.#e1c == null)
			{
				this.#e1c = new Hashtable(100);
			}
			if (this.#e1c.Contains(obj))
			{
				return this.#e1c[obj];
			}
			object value = this.PropertyDescriptor.GetValue(obj);
			this.#e1c.Add(obj, value);
			return value;
		}

		// Token: 0x04000218 RID: 536
		public PropertyDescriptor PropertyDescriptor;

		// Token: 0x04000219 RID: 537
		public string PropertyName;

		// Token: 0x0400021A RID: 538
		public ListSortDirection SortDirection;

		// Token: 0x0400021B RID: 539
		private Hashtable #e1c;
	}
}
