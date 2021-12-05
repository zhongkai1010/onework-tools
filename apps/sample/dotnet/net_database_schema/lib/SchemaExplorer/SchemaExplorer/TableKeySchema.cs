using System;
using System.ComponentModel;
using #Nk;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x020000AB RID: 171
	[Serializable]
	public class TableKeySchema : SchemaObjectBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject, ITableKeySchema
	{
		// Token: 0x060005C2 RID: 1474 RVA: 0x000186DC File Offset: 0x000176DC
		public TableKeySchema(string name, TableSchema foreignKeyTable, TableSchema primaryKeyTable, ExtendedProperty[] extendedProperties) : base(foreignKeyTable.Database, name)
		{
			this._name = name;
			this._database = foreignKeyTable.Database;
			this._foreignKeyTable = foreignKeyTable;
			this._primaryKeyTable = primaryKeyTable;
			this._defaultExtendedProperties = extendedProperties;
			this._extendedProperties = new ExtendedPropertyCollection(extendedProperties);
			this._foreignKeyMemberColumns = new MemberColumnSchemaCollection();
			this._primaryKeyMemberColumns = new MemberColumnSchemaCollection();
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x00018744 File Offset: 0x00017744
		public TableKeySchema(DatabaseSchema database, string name, string[] foreignKeyMemberColumns, string foreignKeyTable, string[] primaryKeyMemberColumns, string primaryKeyTable) : this(database, name, foreignKeyMemberColumns, string.Empty, foreignKeyTable, primaryKeyMemberColumns, string.Empty, primaryKeyTable)
		{
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0001876C File Offset: 0x0001776C
		public TableKeySchema(DatabaseSchema database, string name, string[] foreignKeyMemberColumns, string foreignKeyTable, string[] primaryKeyMemberColumns, string primaryKeyTable, ExtendedProperty[] extendedProperties) : this(database, name, foreignKeyMemberColumns, string.Empty, foreignKeyTable, primaryKeyMemberColumns, string.Empty, primaryKeyTable)
		{
			this._defaultExtendedProperties = extendedProperties;
			this._extendedProperties = new ExtendedPropertyCollection(extendedProperties);
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x000187A8 File Offset: 0x000177A8
		public TableKeySchema(DatabaseSchema database, string name, string[] foreignKeyMemberColumns, string foreignKeyTableOwner, string foreignKeyTable, string[] primaryKeyMemberColumns, string primaryKeyTableOwner, string primaryKeyTable) : base(database, name)
		{
			if (foreignKeyTableOwner.Length > 0)
			{
				this._foreignKeyTable = this.Database.Tables[foreignKeyTableOwner, foreignKeyTable];
			}
			else
			{
				this._foreignKeyTable = this.Database.Tables[foreignKeyTable];
			}
			this._foreignKeyMemberColumns = new MemberColumnSchemaCollection();
			foreach (string name2 in foreignKeyMemberColumns)
			{
				this._foreignKeyMemberColumns.Add(new MemberColumnSchema(this._foreignKeyTable.Columns[name2]));
			}
			if (primaryKeyTableOwner.Length > 0)
			{
				this._primaryKeyTable = this.Database.Tables[primaryKeyTableOwner, primaryKeyTable];
			}
			else
			{
				this._primaryKeyTable = this.Database.Tables[primaryKeyTable];
			}
			this._primaryKeyMemberColumns = new MemberColumnSchemaCollection();
			foreach (string name3 in primaryKeyMemberColumns)
			{
				this._primaryKeyMemberColumns.Add(new MemberColumnSchema(this._primaryKeyTable.Columns[name3]));
			}
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x000188C4 File Offset: 0x000178C4
		public TableKeySchema(DatabaseSchema database, string name, string[] foreignKeyMemberColumns, string foreignKeyTableOwner, string foreignKeyTable, string[] primaryKeyMemberColumns, string primaryKeyTableOwner, string primaryKeyTable, ExtendedProperty[] extendedProperties) : this(database, name, foreignKeyMemberColumns, foreignKeyTableOwner, foreignKeyTable, primaryKeyMemberColumns, primaryKeyTableOwner, primaryKeyTable)
		{
			this._defaultExtendedProperties = extendedProperties;
			this._extendedProperties = new ExtendedPropertyCollection(extendedProperties);
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x000188FC File Offset: 0x000178FC
		public override void Refresh()
		{
			base.Refresh();
			this.Database.Refresh();
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x060005C8 RID: 1480 RVA: 0x00018910 File Offset: 0x00017910
		[Browsable(false)]
		public TableSchema ForeignKeyTable
		{
			get
			{
				return this._foreignKeyTable;
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x060005C9 RID: 1481 RVA: 0x00018918 File Offset: 0x00017918
		ITableSchema ITableKeySchema.ForeignKeyTable
		{
			get
			{
				return this.ForeignKeyTable;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x060005CA RID: 1482 RVA: 0x00018920 File Offset: 0x00017920
		[Browsable(false)]
		public MemberColumnSchemaCollection ForeignKeyMemberColumns
		{
			get
			{
				return this._foreignKeyMemberColumns;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x060005CB RID: 1483 RVA: 0x00018928 File Offset: 0x00017928
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IMemberColumnSchema> ITableKeySchema.ForeignKeyMemberColumns
		{
			get
			{
				return this.ForeignKeyMemberColumns;
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x060005CC RID: 1484 RVA: 0x00018930 File Offset: 0x00017930
		[Browsable(false)]
		public TableSchema PrimaryKeyTable
		{
			get
			{
				return this._primaryKeyTable;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x00018938 File Offset: 0x00017938
		ITableSchema ITableKeySchema.PrimaryKeyTable
		{
			get
			{
				return this.PrimaryKeyTable;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x060005CE RID: 1486 RVA: 0x00018940 File Offset: 0x00017940
		[Browsable(false)]
		public MemberColumnSchemaCollection PrimaryKeyMemberColumns
		{
			get
			{
				return this._primaryKeyMemberColumns;
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x060005CF RID: 1487 RVA: 0x00018948 File Offset: 0x00017948
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IMemberColumnSchema> ITableKeySchema.PrimaryKeyMemberColumns
		{
			get
			{
				return this.PrimaryKeyMemberColumns;
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x060005D0 RID: 1488 RVA: 0x00018950 File Offset: 0x00017950
		[Browsable(false)]
		public PrimaryKeySchema PrimaryKey
		{
			get
			{
				return this.PrimaryKeyTable.PrimaryKey;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x060005D1 RID: 1489 RVA: 0x00018960 File Offset: 0x00017960
		IPrimaryKeySchema ITableKeySchema.PrimaryKey
		{
			get
			{
				return this.PrimaryKey;
			}
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x00018968 File Offset: 0x00017968
		public static string FormatFullName(string owner, string tableName, string keyName)
		{
			if (!string.IsNullOrEmpty(owner))
			{
				return string.Format(#Mk.#Lk(12617), owner, tableName, keyName);
			}
			return string.Format(#Mk.#Lk(12145), tableName, keyName);
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x00018998 File Offset: 0x00017998
		public override bool Equals(object obj)
		{
			TableKeySchema tableKeySchema = obj as TableKeySchema;
			return tableKeySchema != null && tableKeySchema.GetHashCode() == this.GetHashCode();
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x000189C0 File Offset: 0x000179C0
		public override int GetHashCode()
		{
			int num = (this.PrimaryKeyTable != null) ? this.PrimaryKeyTable.GetHashCode() : 0;
			int num2 = (!string.IsNullOrWhiteSpace(this.Name)) ? this.Name.ToLowerInvariant().GetHashCode() : 0;
			return num ^ num2;
		}

		// Token: 0x0400022C RID: 556
		private readonly TableSchema _foreignKeyTable;

		// Token: 0x0400022D RID: 557
		private readonly MemberColumnSchemaCollection _foreignKeyMemberColumns;

		// Token: 0x0400022E RID: 558
		private readonly TableSchema _primaryKeyTable;

		// Token: 0x0400022F RID: 559
		private readonly MemberColumnSchemaCollection _primaryKeyMemberColumns;
	}
}
