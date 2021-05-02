using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using #Nk;
using ActiproSoftware.Windows.Controls.PropertyGrid.Editors;
using CodeSmith.Core.Collections;
using CodeSmith.Engine;
using SchemaExplorer.Design;
using SchemaExplorer.Serialization;
using SchemaExplorer.TypeConverters;

namespace SchemaExplorer
{
	// Token: 0x02000055 RID: 85
	[PropertySerializer(typeof(SchemaObjectFactorySerializer))]
	[TypeConverter(typeof(SchemaObjectFactoryTypeConverter))]
	[Editor(typeof(SchemaObjectEditor), typeof(PropertyEditor))]
	[PropertyRefresher(typeof(MethodPropertyRefresher))]
	[Serializable]
	public abstract class SchemaObjectBase : CodeSmith.Core.Collections.NamedObjectBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject
	{
		// Token: 0x06000344 RID: 836 RVA: 0x0001311C File Offset: 0x0001211C
		internal SchemaObjectBase()
		{
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00013130 File Offset: 0x00012130
		public SchemaObjectBase(DatabaseSchema database, string name) : base(name)
		{
			this._database = database;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0001314C File Offset: 0x0001214C
		public SchemaObjectBase(DatabaseSchema database, string name, DateTime dateCreated) : base(name)
		{
			this._database = database;
			this._dateCreated = dateCreated;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00013170 File Offset: 0x00012170
		public SchemaObjectBase(DatabaseSchema database, string name, ExtendedProperty[] extendedProperties) : this(database, name)
		{
			this._defaultExtendedProperties = (extendedProperties ?? new ExtendedProperty[0]);
			this._extendedProperties = new ExtendedPropertyCollection(extendedProperties);
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00013198 File Offset: 0x00012198
		public SchemaObjectBase(DatabaseSchema database, string name, DateTime dateCreated, ExtendedProperty[] extendedProperties) : this(database, name, dateCreated)
		{
			this._defaultExtendedProperties = (extendedProperties ?? new ExtendedProperty[0]);
			this._extendedProperties = new ExtendedPropertyCollection(extendedProperties);
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000349 RID: 841 RVA: 0x000131C4 File Offset: 0x000121C4
		public DateTime DateCreated
		{
			get
			{
				return this._dateCreated;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600034A RID: 842 RVA: 0x000131CC File Offset: 0x000121CC
		// (set) Token: 0x0600034B RID: 843 RVA: 0x0001320C File Offset: 0x0001220C
		[Description("The description of the schema object. The description can be set if the provider supports it.")]
		public virtual string Description
		{
			get
			{
				if (this.ExtendedProperties.Contains(#Mk.#Lk(13252)))
				{
					return this.ExtendedProperties[#Mk.#Lk(13252)].Value.ToString();
				}
				return string.Empty;
			}
			set
			{
				if (this.ExtendedProperties.Contains(#Mk.#Lk(13252)))
				{
					if ((string)this.ExtendedProperties[#Mk.#Lk(13252)].Value == value)
					{
						return;
					}
					this.ExtendedProperties[#Mk.#Lk(13252)].Value = value;
					this.ExtendedProperties[#Mk.#Lk(13252)].PropertyState = PropertyStateEnum.Dirty;
				}
				else
				{
					this.ExtendedProperties.Add(new ExtendedProperty(#Mk.#Lk(13252), value, DbType.String, PropertyStateEnum.New));
				}
				this.Database.Provider.SetExtendedProperties(this.Database.ConnectionString, this);
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600034C RID: 844 RVA: 0x000132CC File Offset: 0x000122CC
		// (set) Token: 0x0600034D RID: 845 RVA: 0x000132DC File Offset: 0x000122DC
		[Description("Used to store any additional information about the schema object. The meta data can be set if the provider supports it.")]
		public virtual ExtendedPropertyCollection ExtendedProperties
		{
			get
			{
				this.#t1c();
				return this._extendedProperties;
			}
			protected set
			{
				this._extendedProperties = value;
			}
		}

		// Token: 0x0600034E RID: 846 RVA: 0x000132E8 File Offset: 0x000122E8
		private void #t1c()
		{
			if (this._gotExtendedProperties)
			{
				return;
			}
			this.Database.#T0c();
			if (this._extendedProperties == null)
			{
				this._extendedProperties = new ExtendedPropertyCollection(this.Database.Provider.GetExtendedProperties(this.Database.ConnectionString, this));
			}
			else
			{
				ExtendedProperty[] extendedProperties = this.Database.Provider.GetExtendedProperties(this.Database.ConnectionString, this);
				foreach (ExtendedProperty extendedProperty in extendedProperties)
				{
					int num = this._extendedProperties.IndexOf(extendedProperty.Name);
					if (num >= 0)
					{
						this._extendedProperties[num] = extendedProperty;
					}
					else
					{
						this._extendedProperties.Add(extendedProperty);
					}
				}
			}
			if (this._extendedProperties == null)
			{
				this._extendedProperties = new ExtendedPropertyCollection();
			}
			this._gotExtendedProperties = true;
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600034F RID: 847 RVA: 0x000133BC File Offset: 0x000123BC
		CodeSmith.Core.Collections.INamedObjectCollection<IExtendedProperty> ISchemaObject.ExtendedProperties
		{
			get
			{
				this.#t1c();
				if (this._interfaceExtendedProperties == null)
				{
					this._interfaceExtendedProperties = new WrappedNamedObjectCollection<IExtendedProperty, ExtendedProperty>(this._extendedProperties);
				}
				return this._interfaceExtendedProperties;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000350 RID: 848 RVA: 0x000133E4 File Offset: 0x000123E4
		IExtendedProperty[] ISchemaObject.DefaultExtendedProperties
		{
			get
			{
				return this._defaultExtendedProperties ?? new ExtendedProperty[0];
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000351 RID: 849 RVA: 0x000133F8 File Offset: 0x000123F8
		[Browsable(false)]
		public virtual DatabaseSchema Database
		{
			get
			{
				return this._database;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000352 RID: 850 RVA: 0x00013400 File Offset: 0x00012400
		IDatabaseSchema ISchemaObject.Database
		{
			get
			{
				return this.Database;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000353 RID: 851 RVA: 0x00013408 File Offset: 0x00012408
		// (set) Token: 0x06000354 RID: 852 RVA: 0x00013410 File Offset: 0x00012410
		public bool DeepLoad
		{
			get
			{
				return this._deepLoad;
			}
			set
			{
				this._deepLoad = value;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000355 RID: 853 RVA: 0x0001341C File Offset: 0x0001241C
		// (set) Token: 0x06000356 RID: 854 RVA: 0x00013424 File Offset: 0x00012424
		public bool IncludeFunctions
		{
			get
			{
				return this._includeFunctions;
			}
			set
			{
				this._includeFunctions = value;
			}
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00013430 File Offset: 0x00012430
		public virtual void Refresh()
		{
			this._extendedProperties = ((((ISchemaObject)this).DefaultExtendedProperties != null) ? new ExtendedPropertyCollection(((ISchemaObject)this).DefaultExtendedProperties.Cast<ExtendedProperty>()) : new ExtendedPropertyCollection());
			this._gotExtendedProperties = false;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00013460 File Offset: 0x00012460
		public virtual void MarkLoaded()
		{
			this._gotExtendedProperties = true;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0001346C File Offset: 0x0001246C
		public ExtendedPropertyCollection GetLoadedExtendedProperties()
		{
			return this._extendedProperties ?? new ExtendedPropertyCollection();
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600035A RID: 858 RVA: 0x00013480 File Offset: 0x00012480
		public virtual string FullName
		{
			get
			{
				return this.Name;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600035B RID: 859 RVA: 0x00013488 File Offset: 0x00012488
		public virtual string SortName
		{
			get
			{
				return this.Name;
			}
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00013490 File Offset: 0x00012490
		public static string FormatFullName(string owner, string name)
		{
			if (!string.IsNullOrEmpty(owner))
			{
				return string.Format(#Mk.#Lk(12145), owner, name);
			}
			return name;
		}

		// Token: 0x0600035D RID: 861 RVA: 0x000134B0 File Offset: 0x000124B0
		public override int GetHashCode()
		{
			int num = (this.Database != null) ? this.Database.GetHashCode() : 0;
			int num2 = (!string.IsNullOrWhiteSpace(this.Name)) ? this.Name.ToLowerInvariant().GetHashCode() : 0;
			return num ^ num2;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x000134F8 File Offset: 0x000124F8
		public override bool Equals(object obj)
		{
			SchemaObjectBase schemaObjectBase = obj as SchemaObjectBase;
			return schemaObjectBase != null && schemaObjectBase.GetHashCode() == this.GetHashCode();
		}

		// Token: 0x04000158 RID: 344
		protected readonly DateTime _dateCreated = DateTime.MinValue;

		// Token: 0x04000159 RID: 345
		protected DatabaseSchema _database;

		// Token: 0x0400015A RID: 346
		protected ExtendedPropertyCollection _extendedProperties;

		// Token: 0x0400015B RID: 347
		private CodeSmith.Core.Collections.INamedObjectCollection<IExtendedProperty> _interfaceExtendedProperties;

		// Token: 0x0400015C RID: 348
		protected bool _gotExtendedProperties;

		// Token: 0x0400015D RID: 349
		private bool _deepLoad;

		// Token: 0x0400015E RID: 350
		private bool _includeFunctions;

		// Token: 0x0400015F RID: 351
		protected ExtendedProperty[] _defaultExtendedProperties;
	}
}
