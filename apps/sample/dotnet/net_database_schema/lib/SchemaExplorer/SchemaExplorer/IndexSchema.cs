using System;
using System.ComponentModel;
using #Nk;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000096 RID: 150
	[Serializable]
	public class IndexSchema : SchemaObjectBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject, IIndexSchema
	{
		// Token: 0x0600053E RID: 1342 RVA: 0x000173A8 File Offset: 0x000163A8
		public IndexSchema(TableSchema table, string name, bool isPrimaryKey, bool isUnique, bool isClustered) : base(table.Database, name)
		{
			this._table = table;
			this._isPrimaryKey = isPrimaryKey;
			this._isUnique = isUnique;
			this._isClustered = isClustered;
			this._memberColumns = new MemberColumnSchemaCollection();
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x000173E0 File Offset: 0x000163E0
		public IndexSchema(TableSchema table, string name, bool isPrimaryKey, bool isUnique, bool isClustered, ExtendedProperty[] extendedProperties) : this(table, name, isPrimaryKey, isUnique, isClustered)
		{
			this._defaultExtendedProperties = extendedProperties;
			this._extendedProperties = new ExtendedPropertyCollection(extendedProperties);
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x00017404 File Offset: 0x00016404
		public IndexSchema(TableSchema table, string name, bool isPrimaryKey, bool isUnique, bool isClustered, string[] memberColumns) : this(table, name, isPrimaryKey, isUnique, isClustered)
		{
			this._memberColumns = new MemberColumnSchemaCollection();
			foreach (string name2 in memberColumns)
			{
				this._memberColumns.Add(new MemberColumnSchema(this.Table.Columns[name2]));
			}
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x00017460 File Offset: 0x00016460
		public IndexSchema(TableSchema table, string name, bool isPrimaryKey, bool isUnique, bool isClustered, string[] memberColumns, ExtendedProperty[] extendedProperties) : this(table, name, isPrimaryKey, isUnique, isClustered, memberColumns)
		{
			this._defaultExtendedProperties = extendedProperties;
			this._extendedProperties = new ExtendedPropertyCollection(extendedProperties);
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00017488 File Offset: 0x00016488
		public override void Refresh()
		{
			base.Refresh();
			this.Table.Refresh();
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000543 RID: 1347 RVA: 0x0001749C File Offset: 0x0001649C
		[Browsable(false)]
		public TableSchema Table
		{
			get
			{
				return this._table;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000544 RID: 1348 RVA: 0x000174A4 File Offset: 0x000164A4
		ITableSchema IIndexSchema.Table
		{
			get
			{
				return this._table;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000545 RID: 1349 RVA: 0x000174AC File Offset: 0x000164AC
		public bool IsPrimaryKey
		{
			get
			{
				return this._isPrimaryKey;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x000174B4 File Offset: 0x000164B4
		public bool IsUnique
		{
			get
			{
				return this._isUnique;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000547 RID: 1351 RVA: 0x000174BC File Offset: 0x000164BC
		public bool IsClustered
		{
			get
			{
				return this._isClustered;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000548 RID: 1352 RVA: 0x000174C4 File Offset: 0x000164C4
		[Browsable(false)]
		public MemberColumnSchemaCollection MemberColumns
		{
			get
			{
				return this._memberColumns;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000549 RID: 1353 RVA: 0x000174CC File Offset: 0x000164CC
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IMemberColumnSchema> IIndexSchema.MemberColumns
		{
			get
			{
				return this.MemberColumns;
			}
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x000174D4 File Offset: 0x000164D4
		public static string FormatFullName(string owner, string tableName, string indexName)
		{
			if (!string.IsNullOrEmpty(owner))
			{
				return string.Format(#Mk.#Lk(12617), owner, tableName, indexName);
			}
			return string.Format(#Mk.#Lk(12145), tableName, indexName);
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x00017504 File Offset: 0x00016504
		public override bool Equals(object obj)
		{
			IndexSchema indexSchema = obj as IndexSchema;
			return indexSchema != null && indexSchema.GetHashCode() == this.GetHashCode();
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0001752C File Offset: 0x0001652C
		public override int GetHashCode()
		{
			return this.Table.GetHashCode() ^ this.Name.ToLowerInvariant().GetHashCode();
		}

		// Token: 0x040001D6 RID: 470
		private readonly TableSchema _table;

		// Token: 0x040001D7 RID: 471
		private readonly MemberColumnSchemaCollection _memberColumns;

		// Token: 0x040001D8 RID: 472
		private readonly bool _isPrimaryKey;

		// Token: 0x040001D9 RID: 473
		private readonly bool _isUnique;

		// Token: 0x040001DA RID: 474
		private readonly bool _isClustered;
	}
}
