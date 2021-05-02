using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x020000B5 RID: 181
	[Serializable]
	public class ViewSchema : TabularObjectBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject, ISchemaObjectWithOwner, ITabularObject, IViewSchema
	{
		// Token: 0x06000627 RID: 1575 RVA: 0x000191A0 File Offset: 0x000181A0
		public ViewSchema(DatabaseSchema database, string name, string owner, DateTime dateCreated) : base(database, name, owner, dateCreated)
		{
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x000191B8 File Offset: 0x000181B8
		public ViewSchema(DatabaseSchema database, string name, string owner, DateTime dateCreated, ExtendedProperty[] extendedProperties) : base(database, name, owner, dateCreated, extendedProperties)
		{
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x000191D4 File Offset: 0x000181D4
		public override void Refresh()
		{
			base.Refresh();
			this.Columns = null;
			this._viewText = string.Empty;
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x000191F0 File Offset: 0x000181F0
		public DataTable GetViewData()
		{
			return this.GetData();
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x0600062B RID: 1579 RVA: 0x000191F8 File Offset: 0x000181F8
		// (set) Token: 0x0600062C RID: 1580 RVA: 0x00019208 File Offset: 0x00018208
		[Browsable(false)]
		public ViewColumnSchemaCollection Columns
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

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x0600062D RID: 1581 RVA: 0x00019218 File Offset: 0x00018218
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IViewColumnSchema> IViewSchema.Columns
		{
			get
			{
				return this.Columns;
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x0600062E RID: 1582 RVA: 0x00019220 File Offset: 0x00018220
		public override CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IDataObject> DataObjects
		{
			get
			{
				this.#G1c();
				return base.DataObjects;
			}
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x00019230 File Offset: 0x00018230
		private void #G1c()
		{
			if (this._columns != null)
			{
				return;
			}
			this.Database.#T0c();
			this.Columns = new ViewColumnSchemaCollection(this.Database.Provider.GetViewColumns(this.Database.ConnectionString, this));
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000630 RID: 1584 RVA: 0x00019270 File Offset: 0x00018270
		[Browsable(false)]
		public string ViewText
		{
			get
			{
				if (this._viewText == string.Empty)
				{
					this.Database.#T0c();
					this._viewText = this.Database.Provider.GetViewText(this.Database.ConnectionString, this);
				}
				return this._viewText;
			}
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x000192C4 File Offset: 0x000182C4
		// Note: this type is marked as 'beforefieldinit'.
		static ViewSchema()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (ViewSchema.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000632 RID: 1586
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x04000240 RID: 576
		private string _viewText = string.Empty;

		// Token: 0x04000241 RID: 577
		private ViewColumnSchemaCollection _columns;
	}
}
