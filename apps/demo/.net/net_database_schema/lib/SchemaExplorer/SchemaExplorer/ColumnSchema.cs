using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000063 RID: 99
	[Serializable]
	public class ColumnSchema : DataObjectBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject, IColumnSchema, IDataObject
	{
		// Token: 0x060003C6 RID: 966 RVA: 0x00013DB4 File Offset: 0x00012DB4
		internal ColumnSchema()
		{
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00013DBC File Offset: 0x00012DBC
		public ColumnSchema(TableSchema table, string name, DbType dataType, string nativeType, int size, byte precision, int scale, bool allowDBNull) : base(table, name, dataType, nativeType, size, precision, scale, allowDBNull)
		{
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00013DDC File Offset: 0x00012DDC
		public ColumnSchema(TableSchema table, string name, DbType dataType, string nativeType, int size, byte precision, int scale, bool allowDBNull, ExtendedProperty[] extendedProperties) : base(table, name, dataType, nativeType, size, precision, scale, allowDBNull, extendedProperties)
		{
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x00013E00 File Offset: 0x00012E00
		[Browsable(false)]
		public virtual TableSchema Table
		{
			get
			{
				return this._parent as TableSchema;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060003CA RID: 970 RVA: 0x00013E10 File Offset: 0x00012E10
		ITableSchema IColumnSchema.Table
		{
			get
			{
				return this.Table;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060003CB RID: 971 RVA: 0x00013E18 File Offset: 0x00012E18
		public virtual bool IsPrimaryKeyMember
		{
			get
			{
				return this.Table.HasPrimaryKey && this.Table.PrimaryKey.MemberColumns.Contains(this.Name);
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060003CC RID: 972 RVA: 0x00013E44 File Offset: 0x00012E44
		public virtual bool IsForeignKeyMember
		{
			get
			{
				return this.Table.ForeignKeys.Any(new Func<TableKeySchema, bool>(this.#g0c));
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060003CD RID: 973 RVA: 0x00013E64 File Offset: 0x00012E64
		public virtual bool IsUnique
		{
			get
			{
				return this.Table.Indexes.Any(new Func<IndexSchema, bool>(this.#h0c));
			}
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00013E84 File Offset: 0x00012E84
		[CompilerGenerated]
		private bool #g0c(TableKeySchema #6d)
		{
			return #6d.ForeignKeyMemberColumns.Contains(this);
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00013E94 File Offset: 0x00012E94
		[CompilerGenerated]
		private bool #h0c(IndexSchema #6d)
		{
			return #6d.IsUnique && #6d.MemberColumns.Count == 1 && #6d.MemberColumns.Contains(this);
		}
	}
}
