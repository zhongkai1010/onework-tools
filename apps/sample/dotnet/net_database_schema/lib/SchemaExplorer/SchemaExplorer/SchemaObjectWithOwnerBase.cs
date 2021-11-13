using System;
using #Nk;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000054 RID: 84
	[Serializable]
	public abstract class SchemaObjectWithOwnerBase : SchemaObjectBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject, ISchemaObjectWithOwner
	{
		// Token: 0x0600033A RID: 826 RVA: 0x00012FD0 File Offset: 0x00011FD0
		public SchemaObjectWithOwnerBase(DatabaseSchema database, string name, string owner) : base(database, name)
		{
			this._owner = owner;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00012FE4 File Offset: 0x00011FE4
		public SchemaObjectWithOwnerBase(DatabaseSchema database, string name, string owner, DateTime dateCreated) : base(database, name, dateCreated)
		{
			this._owner = owner;
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00012FF8 File Offset: 0x00011FF8
		public SchemaObjectWithOwnerBase(DatabaseSchema database, string name, string owner, ExtendedProperty[] extendedProperties) : base(database, name, extendedProperties)
		{
			this._owner = owner;
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0001300C File Offset: 0x0001200C
		public SchemaObjectWithOwnerBase(DatabaseSchema database, string name, string owner, DateTime dateCreated, ExtendedProperty[] extendedProperties) : base(database, name, dateCreated, extendedProperties)
		{
			this._owner = owner;
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600033E RID: 830 RVA: 0x00013024 File Offset: 0x00012024
		public string Owner
		{
			get
			{
				return this._owner;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600033F RID: 831 RVA: 0x0001302C File Offset: 0x0001202C
		public override string FullName
		{
			get
			{
				return SchemaObjectBase.FormatFullName(this.Owner, this.Name);
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000340 RID: 832 RVA: 0x00013040 File Offset: 0x00012040
		public override string SortName
		{
			get
			{
				if (!string.IsNullOrEmpty(this.Owner))
				{
					return string.Format(#Mk.#Lk(8266), this.Name, this.Owner);
				}
				return this.Name;
			}
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00013074 File Offset: 0x00012074
		public override string ToString()
		{
			return SchemaObjectBase.FormatFullName(this.Owner, this.Name);
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00013088 File Offset: 0x00012088
		public override int GetHashCode()
		{
			int num = (this.Database != null) ? this.Database.GetHashCode() : 0;
			int num2 = (!string.IsNullOrWhiteSpace(this.Name)) ? this.Name.ToLowerInvariant().GetHashCode() : 0;
			int num3 = (!string.IsNullOrWhiteSpace(this.Owner)) ? this.Owner.ToLowerInvariant().GetHashCode() : 0;
			return num ^ num2 ^ num3;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x000130F4 File Offset: 0x000120F4
		public override bool Equals(object obj)
		{
			SchemaObjectWithOwnerBase schemaObjectWithOwnerBase = obj as SchemaObjectWithOwnerBase;
			return schemaObjectWithOwnerBase != null && schemaObjectWithOwnerBase.GetHashCode() == this.GetHashCode();
		}

		// Token: 0x04000157 RID: 343
		protected readonly string _owner;
	}
}
