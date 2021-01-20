using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x020000AE RID: 174
	[Serializable]
	public class TableSchema : TabularObjectBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject, ISchemaObjectWithOwner, ITabularObject, ITableSchema
	{
		// Token: 0x060005E4 RID: 1508 RVA: 0x00018A28 File Offset: 0x00017A28
		public TableSchema(DatabaseSchema database, string name, string owner, DateTime dateCreated) : base(database, name, owner, dateCreated)
		{
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x00018A38 File Offset: 0x00017A38
		public TableSchema(DatabaseSchema database, string name, string owner, DateTime dateCreated, ExtendedProperty[] extendedProperties) : base(database, name, owner, dateCreated, extendedProperties)
		{
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x00018A48 File Offset: 0x00017A48
		public override void Refresh()
		{
			base.Refresh();
			this._primaryKeyChecked = false;
			this._primaryKey = null;
			this._keys = null;
			this._indexes = null;
			this.Columns = null;
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x060005E7 RID: 1511 RVA: 0x00018A74 File Offset: 0x00017A74
		[Browsable(false)]
		public bool HasPrimaryKey
		{
			get
			{
				this.#E1c();
				return this._primaryKey != null;
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x060005E8 RID: 1512 RVA: 0x00018A88 File Offset: 0x00017A88
		// (set) Token: 0x060005E9 RID: 1513 RVA: 0x00018ABC File Offset: 0x00017ABC
		[Browsable(false)]
		public PrimaryKeySchema PrimaryKey
		{
			get
			{
				this.#E1c();
				if (this._primaryKey == null)
				{
					throw new ApplicationException(string.Format(#Mk.#Lk(13314), this.Name));
				}
				return this._primaryKey;
			}
			set
			{
				this._primaryKey = value;
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x060005EA RID: 1514 RVA: 0x00018AC8 File Offset: 0x00017AC8
		IPrimaryKeySchema ITableSchema.PrimaryKey
		{
			get
			{
				this.#E1c();
				return this.PrimaryKey;
			}
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x00018AD8 File Offset: 0x00017AD8
		private void #E1c()
		{
			if (this._primaryKeyChecked || this._primaryKey != null)
			{
				return;
			}
			this.Database.#T0c();
			PrimaryKeySchema tablePrimaryKey = this.Database.Provider.GetTablePrimaryKey(this.Database.ConnectionString, this);
			if (tablePrimaryKey != null)
			{
				this._primaryKey = tablePrimaryKey;
			}
			this._primaryKeyChecked = true;
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x00018B30 File Offset: 0x00017B30
		// (set) Token: 0x060005ED RID: 1517 RVA: 0x00018B40 File Offset: 0x00017B40
		[Browsable(false)]
		public ColumnSchemaCollection Columns
		{
			get
			{
				this.#G1c();
				return this._columns;
			}
			set
			{
				this._columns = value;
				this._dataObjects = value;
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x00018B50 File Offset: 0x00017B50
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IColumnSchema> ITableSchema.Columns
		{
			get
			{
				return this.Columns;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x00018B58 File Offset: 0x00017B58
		public override CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IDataObject> DataObjects
		{
			get
			{
				this.#G1c();
				return base.DataObjects;
			}
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x00018B68 File Offset: 0x00017B68
		private void #G1c()
		{
			if (this._columns != null)
			{
				return;
			}
			this.Database.#T0c();
			this.Columns = new ColumnSchemaCollection(this.Database.Provider.GetTableColumns(this.Database.ConnectionString, this));
			this._foreignKeyColumns = null;
			this._nonPrimaryKeyColumns = null;
			this._nonKeyColumns = null;
			this._nonForeignKeyColumns = null;
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x00018BCC File Offset: 0x00017BCC
		[Browsable(false)]
		public ColumnSchemaCollection NonPrimaryKeyColumns
		{
			get
			{
				this.#G1c();
				if (this._nonPrimaryKeyColumns == null)
				{
					this._nonPrimaryKeyColumns = new ColumnSchemaCollection(this._columns.Where(new Func<ColumnSchema, bool>(TableSchema.<>c.<>9.#35c)));
				}
				return this._nonPrimaryKeyColumns;
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x00018C24 File Offset: 0x00017C24
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IColumnSchema> ITableSchema.NonPrimaryKeyColumns
		{
			get
			{
				return this.NonPrimaryKeyColumns;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x060005F3 RID: 1523 RVA: 0x00018C2C File Offset: 0x00017C2C
		[Browsable(false)]
		public ColumnSchemaCollection NonKeyColumns
		{
			get
			{
				this.#G1c();
				if (this._nonKeyColumns == null)
				{
					this._nonKeyColumns = new ColumnSchemaCollection(this._columns.Where(new Func<ColumnSchema, bool>(TableSchema.<>c.<>9.#45c)));
				}
				return this._nonKeyColumns;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x00018C84 File Offset: 0x00017C84
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IColumnSchema> ITableSchema.NonKeyColumns
		{
			get
			{
				return this.NonKeyColumns;
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x00018C8C File Offset: 0x00017C8C
		[Browsable(false)]
		public ColumnSchemaCollection NonForeignKeyColumns
		{
			get
			{
				this.#G1c();
				if (this._nonForeignKeyColumns == null)
				{
					this._nonForeignKeyColumns = new ColumnSchemaCollection(this._columns.Where(new Func<ColumnSchema, bool>(TableSchema.<>c.<>9.#55c)));
				}
				return this._nonForeignKeyColumns;
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x00018CE4 File Offset: 0x00017CE4
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IColumnSchema> ITableSchema.NonForeignKeyColumns
		{
			get
			{
				return this.NonForeignKeyColumns;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x00018CEC File Offset: 0x00017CEC
		[Browsable(false)]
		public ColumnSchemaCollection ForeignKeyColumns
		{
			get
			{
				this.#G1c();
				if (this._foreignKeyColumns == null)
				{
					this._foreignKeyColumns = new ColumnSchemaCollection(this._columns.Where(new Func<ColumnSchema, bool>(TableSchema.<>c.<>9.#65c)));
				}
				return this._foreignKeyColumns;
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x060005F8 RID: 1528 RVA: 0x00018D44 File Offset: 0x00017D44
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IColumnSchema> ITableSchema.ForeignKeyColumns
		{
			get
			{
				return this.ForeignKeyColumns;
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x060005F9 RID: 1529 RVA: 0x00018D4C File Offset: 0x00017D4C
		// (set) Token: 0x060005FA RID: 1530 RVA: 0x00018D5C File Offset: 0x00017D5C
		[Browsable(false)]
		public TableKeySchemaCollection Keys
		{
			get
			{
				this.#M1c();
				return this._keys;
			}
			set
			{
				this._keys = value;
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x060005FB RID: 1531 RVA: 0x00018D68 File Offset: 0x00017D68
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<ITableKeySchema> ITableSchema.Keys
		{
			get
			{
				return this.Keys;
			}
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00018D70 File Offset: 0x00017D70
		private void #M1c()
		{
			if (this._keys != null)
			{
				return;
			}
			this.Database.#T0c();
			this._keys = new TableKeySchemaCollection(this.Database.Provider.GetTableKeys(this.Database.ConnectionString, this));
			this._foreignKeys = null;
			this._primaryKeys = null;
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x060005FD RID: 1533 RVA: 0x00018DC8 File Offset: 0x00017DC8
		[Browsable(false)]
		public TableKeySchemaCollection ForeignKeys
		{
			get
			{
				this.#M1c();
				if (this._foreignKeys == null)
				{
					this._foreignKeys = new TableKeySchemaCollection(this._keys.Where(new Func<TableKeySchema, bool>(this.#T1c)).ToList<TableKeySchema>());
				}
				return this._foreignKeys;
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x060005FE RID: 1534 RVA: 0x00018E08 File Offset: 0x00017E08
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<ITableKeySchema> ITableSchema.ForeignKeys
		{
			get
			{
				return this.ForeignKeys;
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x060005FF RID: 1535 RVA: 0x00018E10 File Offset: 0x00017E10
		[Browsable(false)]
		public TableKeySchemaCollection PrimaryKeys
		{
			get
			{
				this.#M1c();
				if (this._primaryKeys == null)
				{
					this._primaryKeys = new TableKeySchemaCollection(this._keys.Where(new Func<TableKeySchema, bool>(this.#U1c)).ToList<TableKeySchema>());
				}
				return this._primaryKeys;
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000600 RID: 1536 RVA: 0x00018E50 File Offset: 0x00017E50
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<ITableKeySchema> ITableSchema.PrimaryKeys
		{
			get
			{
				return this.PrimaryKeys;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000601 RID: 1537 RVA: 0x00018E58 File Offset: 0x00017E58
		// (set) Token: 0x06000602 RID: 1538 RVA: 0x00018E68 File Offset: 0x00017E68
		[Browsable(false)]
		public IndexSchemaCollection Indexes
		{
			get
			{
				this.#Q1c();
				return this._indexes;
			}
			set
			{
				this._indexes = value;
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000603 RID: 1539 RVA: 0x00018E74 File Offset: 0x00017E74
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IIndexSchema> ITableSchema.Indexes
		{
			get
			{
				return this.Indexes;
			}
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x00018E7C File Offset: 0x00017E7C
		private void #Q1c()
		{
			if (this._indexes != null)
			{
				return;
			}
			this.Database.#T0c();
			this._indexes = new IndexSchemaCollection(this.Database.Provider.GetTableIndexes(this.Database.ConnectionString, this));
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x00018EBC File Offset: 0x00017EBC
		public bool IsDependantOf(ITableSchema table)
		{
			List<ITableSchema> #S1c = new List<ITableSchema>();
			return this.#R1c(table, #S1c);
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x00018ED8 File Offset: 0x00017ED8
		private bool #R1c(ITableSchema #07b, ICollection<ITableSchema> #S1c)
		{
			foreach (ITableKeySchema tableKeySchema in #07b.ForeignKeys)
			{
				TableKeySchema tableKeySchema2 = (TableKeySchema)tableKeySchema;
				TableSchema primaryKeyTable = tableKeySchema2.PrimaryKeyTable;
				if (primaryKeyTable.Equals(this))
				{
					return true;
				}
				if (!#S1c.Contains(primaryKeyTable))
				{
					#S1c.Add(primaryKeyTable);
					if (this.#R1c(primaryKeyTable, #S1c))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x00018F58 File Offset: 0x00017F58
		public DataTable GetTableData()
		{
			return this.GetData();
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x00018F60 File Offset: 0x00017F60
		[CompilerGenerated]
		private bool #T1c(TableKeySchema #6Mb)
		{
			return #6Mb.ForeignKeyTable == this;
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00018F6C File Offset: 0x00017F6C
		[CompilerGenerated]
		private bool #U1c(TableKeySchema #6Mb)
		{
			return #6Mb.PrimaryKeyTable == this;
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x00018F78 File Offset: 0x00017F78
		// Note: this type is marked as 'beforefieldinit'.
		static TableSchema()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (TableSchema.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x0600060B RID: 1547
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x04000230 RID: 560
		private PrimaryKeySchema _primaryKey;

		// Token: 0x04000231 RID: 561
		private bool _primaryKeyChecked;

		// Token: 0x04000232 RID: 562
		private TableKeySchemaCollection _keys;

		// Token: 0x04000233 RID: 563
		private IndexSchemaCollection _indexes;

		// Token: 0x04000234 RID: 564
		private ColumnSchemaCollection _columns;

		// Token: 0x04000235 RID: 565
		private TableKeySchemaCollection _foreignKeys;

		// Token: 0x04000236 RID: 566
		private TableKeySchemaCollection _primaryKeys;

		// Token: 0x04000237 RID: 567
		private ColumnSchemaCollection _foreignKeyColumns;

		// Token: 0x04000238 RID: 568
		private ColumnSchemaCollection _nonPrimaryKeyColumns;

		// Token: 0x04000239 RID: 569
		private ColumnSchemaCollection _nonKeyColumns;

		// Token: 0x0400023A RID: 570
		private ColumnSchemaCollection _nonForeignKeyColumns;
	}
}
