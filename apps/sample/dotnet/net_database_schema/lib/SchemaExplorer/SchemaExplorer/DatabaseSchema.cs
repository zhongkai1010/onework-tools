using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using #n1c;
using #Nk;
using CodeSmith.Core.Collections;
using CodeSmith.Engine;

namespace SchemaExplorer
{
	// Token: 0x02000068 RID: 104
	[Serializable]
	public class DatabaseSchema : SchemaObjectBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject, IDatabaseSchema
	{
		// Token: 0x060003FC RID: 1020 RVA: 0x000142EC File Offset: 0x000132EC
		static DatabaseSchema()
		{
			string codeSmithDataDirectory = Configuration.Instance.CodeSmithDataDirectory;
			string value = AppDomain.CurrentDomain.GetData(#Mk.#Lk(11642)) as string;
			if (Directory.Exists(codeSmithDataDirectory) && string.IsNullOrEmpty(value))
			{
				AppDomain.CurrentDomain.SetData(#Mk.#Lk(11642), codeSmithDataDirectory);
			}
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00014344 File Offset: 0x00013344
		public DatabaseSchema()
		{
			if (!CodeSmithLicense.AllowSDKFeature)
			{
				if (!CodeSmithLicense.ValidatePublisher(this))
				{
					throw new InvalidPublisherException();
				}
				if (!CodeSmithLicense.IsAnyEdition(CodeSmithEditions.All))
				{
					throw new FeatureNotAllowedException(#Mk.#Lk(11512), #Mk.#Lk(11663));
				}
			}
			this._database = this;
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x000143B0 File Offset: 0x000133B0
		public DatabaseSchema(IDbSchemaProvider provider, string connectionString)
		{
			if (!CodeSmithLicense.AllowSDKFeature)
			{
				if (!CodeSmithLicense.ValidatePublisher(this))
				{
					throw new InvalidPublisherException();
				}
				if (!CodeSmithLicense.IsAnyEdition(CodeSmithEditions.All))
				{
					throw new FeatureNotAllowedException(#Mk.#Lk(11512), #Mk.#Lk(11663));
				}
			}
			this._database = this;
			this.#aQc = provider;
			this._providerType = provider.GetType();
			this._connectionString = connectionString;
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00014438 File Offset: 0x00013438
		[Obsolete("Use DataSourceManager.GetProviders instead.")]
		public IDbSchemaProviderCollection GetProviders()
		{
			IDbSchemaProviderCollection dbSchemaProviderCollection = new IDbSchemaProviderCollection();
			IEnumerable<SchemaProvider> providers = DataSourceManager.GetProviders();
			foreach (SchemaProvider schemaProvider in providers)
			{
				IDbSchemaProvider dbSchemaProvider = schemaProvider.CreateProvider();
				if (dbSchemaProvider != null)
				{
					dbSchemaProviderCollection.Add(dbSchemaProvider);
				}
			}
			if (dbSchemaProviderCollection.Count == 0)
			{
				providers = DataSourceManager.GetProviders(true);
				foreach (SchemaProvider schemaProvider2 in providers)
				{
					IDbSchemaProvider dbSchemaProvider2 = schemaProvider2.CreateProvider();
					if (dbSchemaProvider2 != null)
					{
						dbSchemaProviderCollection.Add(dbSchemaProvider2);
					}
				}
			}
			return dbSchemaProviderCollection;
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x000144F4 File Offset: 0x000134F4
		public override string ToString()
		{
			if (this.Provider == null || string.IsNullOrWhiteSpace(this.ConnectionString))
			{
				return string.Empty;
			}
			return this.Name;
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x00014518 File Offset: 0x00013518
		[Obsolete("User DataSourceManager.GetProviders instead.")]
		public IDbSchemaProvider GetProvider(string name)
		{
			DatabaseSchema.#Wj #Wj = new DatabaseSchema.#Wj();
			#Wj.#5n = name;
			IEnumerable<SchemaProvider> providers = DataSourceManager.GetProviders();
			SchemaProvider schemaProvider = providers.FirstOrDefault(new Func<SchemaProvider, bool>(#Wj.#15c));
			if (schemaProvider != null)
			{
				return schemaProvider.CreateProvider();
			}
			return null;
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x00014558 File Offset: 0x00013558
		// (set) Token: 0x06000403 RID: 1027 RVA: 0x0001458C File Offset: 0x0001358C
		[Browsable(false)]
		public IDbSchemaProvider Provider
		{
			get
			{
				if (this.#aQc == null && this._providerType != null)
				{
					this.#aQc = (IDbSchemaProvider)Activator.CreateInstance(this._providerType);
				}
				return this.#aQc;
			}
			set
			{
				this.#S0c();
				this.#aQc = value;
				this._providerType = this.#aQc.GetType();
				this.#Q0c = null;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000404 RID: 1028 RVA: 0x000145B4 File Offset: 0x000135B4
		[Browsable(false)]
		internal IDbSchemaProvider CachedProvider
		{
			get
			{
				if (this.#Q0c == null && this.#aQc != null)
				{
					this.#Q0c = new CachedSchemaProviderProxy(this.#aQc);
				}
				return this.#Q0c;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x000145E0 File Offset: 0x000135E0
		// (set) Token: 0x06000406 RID: 1030 RVA: 0x000145E8 File Offset: 0x000135E8
		[Browsable(false)]
		[ReadOnly(true)]
		public string ConnectionString
		{
			get
			{
				return this._connectionString;
			}
			set
			{
				this.#S0c();
				this._connectionString = value;
			}
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x000145F8 File Offset: 0x000135F8
		public override void Refresh()
		{
			base.Refresh();
			this.#S0c();
			#s1c.Instance.#ppc();
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x00014610 File Offset: 0x00013610
		private void #S0c()
		{
			this._commands = null;
			this._tables = null;
			this._views = null;
			this._gotDatabaseName = false;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00014630 File Offset: 0x00013630
		internal void #T0c()
		{
			if (this.Provider == null)
			{
				throw new InvalidOperationException(#Mk.#Lk(11676));
			}
			if (string.IsNullOrWhiteSpace(this.ConnectionString))
			{
				throw new InvalidOperationException(#Mk.#Lk(11749));
			}
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x00014668 File Offset: 0x00013668
		public override bool Equals(object obj)
		{
			DatabaseSchema databaseSchema = obj as DatabaseSchema;
			return databaseSchema != null && databaseSchema.ConnectionString == this.ConnectionString && databaseSchema.Provider.GetType().FullName == this.Provider.GetType().FullName;
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x000146BC File Offset: 0x000136BC
		public override int GetHashCode()
		{
			string text = string.Empty;
			if (this.Provider != null)
			{
				text = (this.Provider.GetType().FullName ?? string.Empty);
			}
			return (this.ConnectionString ?? string.Empty).ToLowerInvariant().GetHashCode() ^ text.ToLowerInvariant().GetHashCode();
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x0600040C RID: 1036 RVA: 0x00014718 File Offset: 0x00013718
		public override string Name
		{
			get
			{
				if (!this._gotDatabaseName)
				{
					this.#T0c();
					this._databaseName = this.Provider.GetDatabaseName(this.ConnectionString);
					this._gotDatabaseName = true;
				}
				return this._databaseName;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x0001474C File Offset: 0x0001374C
		[Browsable(false)]
		public TableSchemaCollection Tables
		{
			get
			{
				this.#V0c();
				return this._tables;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600040E RID: 1038 RVA: 0x0001475C File Offset: 0x0001375C
		IReadOnlySchemaObjectWithOwnerCollection<ITableSchema> IDatabaseSchema.Tables
		{
			get
			{
				return this.Tables;
			}
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00014764 File Offset: 0x00013764
		private void #V0c()
		{
			if (this._tables != null)
			{
				return;
			}
			this.#T0c();
			this._tables = new TableSchemaCollection(this.CachedProvider.GetTables(this.ConnectionString, this));
			if (CodeSmithLicense.IsTrial && !CodeSmithLicense.IsFullTrial && !this.#W0c(this._tables))
			{
				throw new FeatureNotAllowedException(string.Format(#Mk.#Lk(11834), #m1c.Names));
			}
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x000147D4 File Offset: 0x000137D4
		private bool #W0c(IEnumerable<TableSchema> #hnc)
		{
			DatabaseSchema.#bMb #bMb = new DatabaseSchema.#bMb();
			StringBuilder stringBuilder = new StringBuilder();
			TableSchemaCollection tableSchemaCollection = new TableSchemaCollection(#hnc);
			tableSchemaCollection.Sort(new PropertyComparer(#Mk.#Lk(12136), ListSortDirection.Ascending));
			foreach (TableSchema tableSchema in tableSchemaCollection)
			{
				stringBuilder.Append(tableSchema.Name.ToLower().Trim());
			}
			#bMb.#zy = StringUtil.CalculateMd5Hash(stringBuilder.ToString());
			string[] source = #m1c.HashCodes;
			return source.Any(new Func<string, bool>(#bMb.#25c));
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x00014888 File Offset: 0x00013888
		[Browsable(false)]
		public ViewSchemaCollection Views
		{
			get
			{
				this.#Y0c();
				return this._views;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000412 RID: 1042 RVA: 0x00014898 File Offset: 0x00013898
		IReadOnlySchemaObjectWithOwnerCollection<IViewSchema> IDatabaseSchema.Views
		{
			get
			{
				return this.Views;
			}
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x000148A0 File Offset: 0x000138A0
		private void #Y0c()
		{
			if (this._views != null)
			{
				return;
			}
			this.#T0c();
			this._views = new ViewSchemaCollection(this.CachedProvider.GetViews(this.ConnectionString, this));
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x000148D0 File Offset: 0x000138D0
		[Browsable(false)]
		public CommandSchemaCollection Commands
		{
			get
			{
				this.#00c();
				return this._commands;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x000148E0 File Offset: 0x000138E0
		IReadOnlySchemaObjectWithOwnerCollection<ICommandSchema> IDatabaseSchema.Commands
		{
			get
			{
				return this.Commands;
			}
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x000148E8 File Offset: 0x000138E8
		private void #00c()
		{
			if (this._commands != null)
			{
				return;
			}
			this.#T0c();
			this._commands = new CommandSchemaCollection(this.CachedProvider.GetCommands(this.ConnectionString, this));
		}

		// Token: 0x0400017E RID: 382
		[NonSerialized]
		private IDbSchemaProvider #aQc;

		// Token: 0x0400017F RID: 383
		private Type _providerType;

		// Token: 0x04000180 RID: 384
		[NonSerialized]
		private IDbSchemaProvider #Q0c;

		// Token: 0x04000181 RID: 385
		private string _connectionString = string.Empty;

		// Token: 0x04000182 RID: 386
		private TableSchemaCollection _tables;

		// Token: 0x04000183 RID: 387
		private ViewSchemaCollection _views;

		// Token: 0x04000184 RID: 388
		private CommandSchemaCollection _commands;

		// Token: 0x04000185 RID: 389
		private string _databaseName = string.Empty;

		// Token: 0x04000186 RID: 390
		private bool _gotDatabaseName;

		// Token: 0x02000069 RID: 105
		[CompilerGenerated]
		private sealed class #Wj
		{
			// Token: 0x06000418 RID: 1048 RVA: 0x00014920 File Offset: 0x00013920
			internal bool #15c(SchemaProvider #lfb)
			{
				return #lfb.DisplayName == this.#5n;
			}

			// Token: 0x04000187 RID: 391
			public string #5n;
		}

		// Token: 0x0200006A RID: 106
		[CompilerGenerated]
		private sealed class #bMb
		{
			// Token: 0x0600041A RID: 1050 RVA: 0x0001493C File Offset: 0x0001393C
			internal bool #25c(string #6d)
			{
				return #6d == this.#zy;
			}

			// Token: 0x04000188 RID: 392
			public string #zy;
		}
	}
}
