using System;
using System.Collections;
using #Nk;

namespace SchemaExplorer
{
	// Token: 0x020000A9 RID: 169
	public class TableDependancyComparer : IComparer
	{
		// Token: 0x060005B9 RID: 1465 RVA: 0x00018650 File Offset: 0x00017650
		public TableDependancyComparer()
		{
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x00018660 File Offset: 0x00017660
		public TableDependancyComparer(TableSortOrder tableSortOrder)
		{
			this.#x1c = tableSortOrder;
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060005BB RID: 1467 RVA: 0x00018678 File Offset: 0x00017678
		public TableSortOrder TableSortOrder
		{
			get
			{
				return this.#x1c;
			}
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x00018680 File Offset: 0x00017680
		public int Compare(object x, object y)
		{
			TableSchema tableSchema = x as TableSchema;
			TableSchema tableSchema2 = y as TableSchema;
			if (tableSchema == null || tableSchema2 == null)
			{
				throw new ArgumentException(#Mk.#Lk(13273));
			}
			if (tableSchema == tableSchema2)
			{
				return 0;
			}
			if (this.#x1c == TableSortOrder.DependantsLast)
			{
				if (!tableSchema.IsDependantOf(tableSchema2))
				{
					return 1;
				}
				return -1;
			}
			else
			{
				if (!tableSchema.IsDependantOf(tableSchema2))
				{
					return -1;
				}
				return 1;
			}
		}

		// Token: 0x0400022B RID: 555
		private readonly TableSortOrder #x1c = TableSortOrder.DependantsLast;
	}
}
