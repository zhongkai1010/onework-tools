using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SchemaExplorer
{
	// Token: 0x020000A3 RID: 163
	public class PropertyComparer<T> : PropertyComparer, IComparer<T>, IEqualityComparer<T>
	{
		// Token: 0x060005A2 RID: 1442 RVA: 0x00017F78 File Offset: 0x00016F78
		public PropertyComparer(string orderByClause) : base(orderByClause)
		{
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x00017F84 File Offset: 0x00016F84
		public PropertyComparer(string propertyName, ListSortDirection sortDirection) : base(propertyName, sortDirection)
		{
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x00017F90 File Offset: 0x00016F90
		public PropertyComparer(SortExpression[] sortExpressions) : base(sortExpressions)
		{
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x00017F9C File Offset: 0x00016F9C
		public int Compare(T x, T y)
		{
			return base.Compare(x, y);
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x00017FB0 File Offset: 0x00016FB0
		public bool Equals(T x, T y)
		{
			return base.Equals(x, y);
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x00017FC4 File Offset: 0x00016FC4
		public int GetHashCode(T obj)
		{
			return base.GetHashCode(obj);
		}
	}
}
