using System;
using System.Collections.Generic;
using System.ComponentModel;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x0200009F RID: 159
	[Serializable]
	public class PrimaryKeySchema : SchemaObjectBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject, IPrimaryKeySchema
	{
		// Token: 0x06000585 RID: 1413 RVA: 0x000179B8 File Offset: 0x000169B8
		public PrimaryKeySchema(TableSchema table, string name) : base(table.Database, name)
		{
			this._table = table;
			this._memberColumns = new MemberColumnSchemaCollection();
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x000179DC File Offset: 0x000169DC
		public PrimaryKeySchema(TableSchema table, string name, IEnumerable<string> memberColumns) : this(table, name)
		{
			this._memberColumns = new MemberColumnSchemaCollection();
			foreach (string name2 in memberColumns)
			{
				this._memberColumns.Add(new MemberColumnSchema(this.Table.Columns[name2]));
			}
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00017A54 File Offset: 0x00016A54
		public PrimaryKeySchema(TableSchema table, string name, ExtendedProperty[] extendedProperties) : this(table, name)
		{
			this._defaultExtendedProperties = extendedProperties;
			this._extendedProperties = new ExtendedPropertyCollection(extendedProperties);
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00017A74 File Offset: 0x00016A74
		public PrimaryKeySchema(TableSchema table, string name, IEnumerable<string> memberColumns, ExtendedProperty[] extendedProperties) : this(table, name, memberColumns)
		{
			this._defaultExtendedProperties = extendedProperties;
			this._extendedProperties = new ExtendedPropertyCollection(extendedProperties);
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x00017A94 File Offset: 0x00016A94
		public override void Refresh()
		{
			base.Refresh();
			this.Table.Refresh();
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x0600058A RID: 1418 RVA: 0x00017AA8 File Offset: 0x00016AA8
		[Browsable(false)]
		public TableSchema Table
		{
			get
			{
				return this._table;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x0600058B RID: 1419 RVA: 0x00017AB0 File Offset: 0x00016AB0
		ITableSchema IPrimaryKeySchema.Table
		{
			get
			{
				return this.Table;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x0600058C RID: 1420 RVA: 0x00017AB8 File Offset: 0x00016AB8
		[Browsable(false)]
		public MemberColumnSchemaCollection MemberColumns
		{
			get
			{
				return this._memberColumns;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x0600058D RID: 1421 RVA: 0x00017AC0 File Offset: 0x00016AC0
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IMemberColumnSchema> IPrimaryKeySchema.MemberColumns
		{
			get
			{
				return this.MemberColumns;
			}
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00017AC8 File Offset: 0x00016AC8
		public override bool Equals(object obj)
		{
			PrimaryKeySchema primaryKeySchema = obj as PrimaryKeySchema;
			return primaryKeySchema != null && primaryKeySchema.GetHashCode() == this.GetHashCode();
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00017AF0 File Offset: 0x00016AF0
		public override int GetHashCode()
		{
			return this.Table.GetHashCode() ^ this.Name.ToLowerInvariant().GetHashCode();
		}

		// Token: 0x040001DE RID: 478
		private readonly TableSchema _table;

		// Token: 0x040001DF RID: 479
		private readonly MemberColumnSchemaCollection _memberColumns;
	}
}
