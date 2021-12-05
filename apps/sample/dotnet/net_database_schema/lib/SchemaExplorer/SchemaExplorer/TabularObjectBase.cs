using System;
using System.ComponentModel;
using System.Data;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000075 RID: 117
	[Serializable]
	public abstract class TabularObjectBase : SchemaObjectWithOwnerBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject, ISchemaObjectWithOwner, ITabularObject
	{
		// Token: 0x0600044C RID: 1100 RVA: 0x00014F0C File Offset: 0x00013F0C
		public TabularObjectBase(DatabaseSchema database, string name, string owner) : base(database, name, owner)
		{
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00014F18 File Offset: 0x00013F18
		public TabularObjectBase(DatabaseSchema database, string name, string owner, DateTime dateCreated) : base(database, name, owner, dateCreated)
		{
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00014F28 File Offset: 0x00013F28
		public TabularObjectBase(DatabaseSchema database, string name, string owner, ExtendedProperty[] extendedProperties) : base(database, name, owner, extendedProperties)
		{
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00014F38 File Offset: 0x00013F38
		public TabularObjectBase(DatabaseSchema database, string name, string owner, DateTime dateCreated, ExtendedProperty[] extendedProperties) : base(database, name, owner, dateCreated, extendedProperties)
		{
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00014F48 File Offset: 0x00013F48
		public virtual DataTable GetData()
		{
			if (this is ITableSchema)
			{
				return this.Database.Provider.GetTableData(this.Database.ConnectionString, this as TableSchema);
			}
			if (this is IViewSchema)
			{
				return this.Database.Provider.GetViewData(this.Database.ConnectionString, this as ViewSchema);
			}
			return null;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00014FAC File Offset: 0x00013FAC
		public override void Refresh()
		{
			base.Refresh();
			this._dataObjects = null;
		}

		// Token: 0x17000120 RID: 288
		[Browsable(false)]
		public IDataObject this[int index]
		{
			get
			{
				return this.DataObjects[index];
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x00014FCC File Offset: 0x00013FCC
		[Browsable(false)]
		public virtual CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IDataObject> DataObjects
		{
			get
			{
				return this._dataObjects;
			}
		}

		// Token: 0x04000199 RID: 409
		protected CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IDataObject> _dataObjects;
	}
}
