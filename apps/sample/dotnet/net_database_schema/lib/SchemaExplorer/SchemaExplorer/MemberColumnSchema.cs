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
	// Token: 0x02000099 RID: 153
	[Serializable]
	public class MemberColumnSchema : ColumnSchema, CodeSmith.Core.Collections.INamedObject, ISchemaObject, IColumnSchema, IDataObject, IMemberColumnSchema
	{
		// Token: 0x06000554 RID: 1364 RVA: 0x000175C0 File Offset: 0x000165C0
		public MemberColumnSchema(ColumnSchema memberColumn)
		{
			this.Column = memberColumn;
			this._extendedProperties = new ExtendedPropertyCollection();
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x000175DC File Offset: 0x000165DC
		public MemberColumnSchema(ColumnSchema memberColumn, ExtendedProperty[] extendedProperties)
		{
			this.Column = memberColumn;
			this._defaultExtendedProperties = (extendedProperties ?? new ExtendedProperty[0]);
			this._extendedProperties = new ExtendedPropertyCollection(extendedProperties);
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x00017608 File Offset: 0x00016608
		public override void Refresh()
		{
			base.Refresh();
			this.Column.Table.Refresh();
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000557 RID: 1367 RVA: 0x00017620 File Offset: 0x00016620
		// (set) Token: 0x06000558 RID: 1368 RVA: 0x00017628 File Offset: 0x00016628
		[Browsable(false)]
		public ColumnSchema Column { get; private set; }

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000559 RID: 1369 RVA: 0x00017634 File Offset: 0x00016634
		IColumnSchema IMemberColumnSchema.Column
		{
			get
			{
				return this.Column;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x0600055A RID: 1370 RVA: 0x0001763C File Offset: 0x0001663C
		[Browsable(false)]
		public ExtendedPropertyCollection ColumnExtendedProperties
		{
			get
			{
				return this.Column.ExtendedProperties;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x0001764C File Offset: 0x0001664C
		CodeSmith.Core.Collections.INamedObjectCollection<IExtendedProperty> IMemberColumnSchema.ColumnExtendedProperties
		{
			get
			{
				return ((ISchemaObject)this.Column).ExtendedProperties;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x0001765C File Offset: 0x0001665C
		// (set) Token: 0x0600055D RID: 1373 RVA: 0x00017690 File Offset: 0x00016690
		[Description("Used to store any additional information about the schema object. The meta data can be set if the provider supports it.")]
		public override ExtendedPropertyCollection ExtendedProperties
		{
			get
			{
				if (!this._areExtendedPropertiesMerged)
				{
					base.ExtendedProperties = SchemaUtility.MergeExtendedProperties(base.ExtendedProperties, this.Column.ExtendedProperties);
					this._areExtendedPropertiesMerged = true;
				}
				return base.ExtendedProperties;
			}
			protected set
			{
				base.ExtendedProperties = value;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x0600055E RID: 1374 RVA: 0x0001769C File Offset: 0x0001669C
		[Browsable(false)]
		public override TableSchema Table
		{
			get
			{
				return this.Column.Table;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x0600055F RID: 1375 RVA: 0x000176AC File Offset: 0x000166AC
		public override ISchemaObject Parent
		{
			get
			{
				return this.Column.Parent;
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000560 RID: 1376 RVA: 0x000176BC File Offset: 0x000166BC
		public override bool IsPrimaryKeyMember
		{
			get
			{
				return this.Column.IsPrimaryKeyMember;
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000561 RID: 1377 RVA: 0x000176CC File Offset: 0x000166CC
		public override bool IsForeignKeyMember
		{
			get
			{
				return this.Column.IsForeignKeyMember;
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000562 RID: 1378 RVA: 0x000176DC File Offset: 0x000166DC
		public override bool IsUnique
		{
			get
			{
				return this.Column.IsUnique;
			}
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x000176EC File Offset: 0x000166EC
		public override bool Equals(object obj)
		{
			return this.Column.Equals(obj);
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x000176FC File Offset: 0x000166FC
		public override int GetHashCode()
		{
			return this.Column.Table.GetHashCode() ^ this.Column.Name.GetHashCode();
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000565 RID: 1381 RVA: 0x00017720 File Offset: 0x00016720
		public override DbType DataType
		{
			get
			{
				return this.Column.DataType;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000566 RID: 1382 RVA: 0x00017730 File Offset: 0x00016730
		public override Type SystemType
		{
			get
			{
				return this.Column.SystemType;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000567 RID: 1383 RVA: 0x00017740 File Offset: 0x00016740
		public override string NativeType
		{
			get
			{
				return this.Column.NativeType;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000568 RID: 1384 RVA: 0x00017750 File Offset: 0x00016750
		public override int Size
		{
			get
			{
				return this.Column.Size;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000569 RID: 1385 RVA: 0x00017760 File Offset: 0x00016760
		public override byte Precision
		{
			get
			{
				return this.Column.Precision;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x0600056A RID: 1386 RVA: 0x00017770 File Offset: 0x00016770
		public override int Scale
		{
			get
			{
				return this.Column.Scale;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x0600056B RID: 1387 RVA: 0x00017780 File Offset: 0x00016780
		public override bool AllowDBNull
		{
			get
			{
				return this.Column.AllowDBNull;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x0600056C RID: 1388 RVA: 0x00017790 File Offset: 0x00016790
		public override string Name
		{
			get
			{
				return this.Column.Name;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x0600056D RID: 1389 RVA: 0x000177A0 File Offset: 0x000167A0
		public override string Description
		{
			get
			{
				return this.Column.Description;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x000177B0 File Offset: 0x000167B0
		[Browsable(false)]
		public override DatabaseSchema Database
		{
			get
			{
				return this.Column.Database;
			}
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x000177C0 File Offset: 0x000167C0
		// Note: this type is marked as 'beforefieldinit'.
		static MemberColumnSchema()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (MemberColumnSchema.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000570 RID: 1392
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x040001DB RID: 475
		private bool _areExtendedPropertiesMerged;
	}
}
