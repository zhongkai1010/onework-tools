using System;
using System.ComponentModel;
using System.Xml.Serialization;
using #Nk;

namespace SchemaExplorer
{
	// Token: 0x02000087 RID: 135
	[Serializable]
	public class DataSource : INotifyPropertyChanged, IEquatable<DataSource>
	{
		// Token: 0x060004C3 RID: 1219 RVA: 0x00015ED4 File Offset: 0x00014ED4
		public DataSource()
		{
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00015F00 File Offset: 0x00014F00
		private DataSource(string name, string connectionString, bool isSelected)
		{
			this._name = name;
			this.OriginalName = name;
			this._connectionString = connectionString;
			this._isSelected = isSelected;
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00015F50 File Offset: 0x00014F50
		public DataSource(string name, string connectionString, string providerType) : this(name, connectionString, providerType, false)
		{
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00015F5C File Offset: 0x00014F5C
		public DataSource(string name, string connectionString, string providerType, bool isSelected) : this(name, connectionString, isSelected)
		{
			if (string.IsNullOrWhiteSpace(providerType))
			{
				throw new ArgumentNullException(#Mk.#Lk(12158), #Mk.#Lk(12175));
			}
			this._providerTypeName = providerType;
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x00015F94 File Offset: 0x00014F94
		public DataSource(string name, string connectionString, Type providerType) : this(name, connectionString, providerType, false)
		{
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00015FA0 File Offset: 0x00014FA0
		public DataSource(string name, string connectionString, Type providerType, bool isSelected) : this(name, connectionString, isSelected)
		{
			if (providerType == null)
			{
				throw new ArgumentNullException(#Mk.#Lk(12158), #Mk.#Lk(12175));
			}
			this._providerType = providerType;
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00015FD8 File Offset: 0x00014FD8
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x00015FE0 File Offset: 0x00014FE0
		public override bool Equals(object obj)
		{
			return obj != null && (this == obj || (!(obj.GetType() != typeof(DataSource)) && this.Equals((DataSource)obj)));
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x00016014 File Offset: 0x00015014
		public bool Equals(DataSource other)
		{
			return other != null && (this == other || object.Equals(other._name, this._name));
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00016034 File Offset: 0x00015034
		public override int GetHashCode()
		{
			if (this._name == null)
			{
				return 0;
			}
			return this._name.GetHashCode();
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0001604C File Offset: 0x0001504C
		public static bool operator ==(DataSource left, DataSource right)
		{
			return object.Equals(left, right);
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00016058 File Offset: 0x00015058
		public static bool operator !=(DataSource left, DataSource right)
		{
			return !object.Equals(left, right);
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x00016064 File Offset: 0x00015064
		// (set) Token: 0x060004D0 RID: 1232 RVA: 0x0001606C File Offset: 0x0001506C
		[XmlAttribute(AttributeName = "name")]
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				if (this._name == value)
				{
					return;
				}
				this._name = value;
				this.RaisePropertyChanged(#Mk.#Lk(12136));
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x00016094 File Offset: 0x00015094
		// (set) Token: 0x060004D2 RID: 1234 RVA: 0x0001609C File Offset: 0x0001509C
		[XmlIgnore]
		public string OriginalName { get; set; }

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060004D3 RID: 1235 RVA: 0x000160A8 File Offset: 0x000150A8
		// (set) Token: 0x060004D4 RID: 1236 RVA: 0x000160B0 File Offset: 0x000150B0
		[XmlAttribute(AttributeName = "connectionString")]
		public string ConnectionString
		{
			get
			{
				return this._connectionString;
			}
			set
			{
				if (this._connectionString == value)
				{
					return;
				}
				this._connectionString = value;
				this.RaisePropertyChanged(#Mk.#Lk(12228));
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x000160D8 File Offset: 0x000150D8
		// (set) Token: 0x060004D6 RID: 1238 RVA: 0x000160E0 File Offset: 0x000150E0
		[XmlAttribute(AttributeName = "selected")]
		[DefaultValue(false)]
		public bool IsSelected
		{
			get
			{
				return this._isSelected;
			}
			set
			{
				if (this._isSelected == value)
				{
					return;
				}
				this._isSelected = value;
				this.RaisePropertyChanged(#Mk.#Lk(12253));
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x00016104 File Offset: 0x00015104
		// (set) Token: 0x060004D8 RID: 1240 RVA: 0x00016168 File Offset: 0x00015168
		[XmlIgnore]
		public Type ProviderType
		{
			get
			{
				if (!this._providerTypeChecked && this._providerType == null && !string.IsNullOrEmpty(this._providerTypeName))
				{
					try
					{
						this._providerType = Type.GetType(this._providerTypeName);
					}
					finally
					{
						this._providerTypeChecked = true;
					}
				}
				return this._providerType;
			}
			set
			{
				this._providerType = value;
				if (this._providerType != null && !string.IsNullOrEmpty(this._providerType.AssemblyQualifiedName))
				{
					this.ProviderTypeName = this._providerType.AssemblyQualifiedName;
				}
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x000161A4 File Offset: 0x000151A4
		// (set) Token: 0x060004DA RID: 1242 RVA: 0x000161B4 File Offset: 0x000151B4
		[XmlIgnore]
		public SchemaProvider SchemaProvider
		{
			get
			{
				return this.ProviderTypeName;
			}
			set
			{
				if (this.ProviderTypeName == value)
				{
					return;
				}
				this.ProviderTypeName = value;
				this.RaisePropertyChanged(#Mk.#Lk(12270));
				this.RaisePropertyChanged(#Mk.#Lk(12291));
				this.RaisePropertyChanged(#Mk.#Lk(12316));
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060004DB RID: 1243 RVA: 0x00016214 File Offset: 0x00015214
		// (set) Token: 0x060004DC RID: 1244 RVA: 0x00016268 File Offset: 0x00015268
		[XmlAttribute(AttributeName = "providerType")]
		public string ProviderTypeName
		{
			get
			{
				if (!string.IsNullOrEmpty(this._providerTypeName))
				{
					return this._providerTypeName;
				}
				if (this._providerType != null && !string.IsNullOrEmpty(this._providerType.AssemblyQualifiedName))
				{
					return this._providerType.AssemblyQualifiedName;
				}
				return string.Empty;
			}
			set
			{
				if (this._providerTypeName == value)
				{
					return;
				}
				this._providerTypeName = value;
				this.RaisePropertyChanged(#Mk.#Lk(12270));
				this.RaisePropertyChanged(#Mk.#Lk(12291));
				this.RaisePropertyChanged(#Mk.#Lk(12316));
			}
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x000162BC File Offset: 0x000152BC
		public DatabaseSchema CreateInstance()
		{
			if (this._providerType == null && !string.IsNullOrEmpty(this._providerTypeName))
			{
				try
				{
					this._providerType = Type.GetType(this._providerTypeName);
				}
				catch (Exception innerException)
				{
					throw new ApplicationException(string.Format(#Mk.#Lk(12333), this._providerTypeName), innerException);
				}
			}
			if (this._providerType != null)
			{
				DatabaseSchema databaseSchema = new DatabaseSchema();
				try
				{
					IDbSchemaProvider provider = (IDbSchemaProvider)Activator.CreateInstance(this._providerType);
					databaseSchema.Provider = provider;
					databaseSchema.ConnectionString = this._connectionString;
				}
				catch (Exception innerException2)
				{
					throw new ApplicationException(string.Format(#Mk.#Lk(12402), this._providerType.FullName), innerException2);
				}
				return databaseSchema;
			}
			return null;
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00016390 File Offset: 0x00015390
		public bool TestConnection()
		{
			DatabaseSchema databaseSchema = this.CreateInstance();
			return databaseSchema != null && databaseSchema.Tables.Count >= 0;
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060004DF RID: 1247 RVA: 0x000163BC File Offset: 0x000153BC
		// (remove) Token: 0x060004E0 RID: 1248 RVA: 0x000163F4 File Offset: 0x000153F4
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x060004E1 RID: 1249 RVA: 0x0001642C File Offset: 0x0001542C
		protected void RaisePropertyChanged(string name)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00016450 File Offset: 0x00015450
		protected void RaisePropertyChanged(PropertyChangedEventArgs e)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(this, e);
			}
		}

		// Token: 0x040001C2 RID: 450
		private string _name = string.Empty;

		// Token: 0x040001C3 RID: 451
		private string _connectionString = string.Empty;

		// Token: 0x040001C4 RID: 452
		private string _providerTypeName = string.Empty;

		// Token: 0x040001C5 RID: 453
		private Type _providerType;

		// Token: 0x040001C6 RID: 454
		private bool _providerTypeChecked;

		// Token: 0x040001C8 RID: 456
		private bool _isSelected;
	}
}
