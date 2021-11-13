using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using #Nk;
using CodeSmith.Engine;

namespace SchemaExplorer
{
	// Token: 0x02000081 RID: 129
	public class Configuration : ConfigurationBase
	{
		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x00015900 File Offset: 0x00014900
		public IList<SchemaProvider> SchemaProviders
		{
			get
			{
				return DataSourceManager.SchemaProviders;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x00015908 File Offset: 0x00014908
		public DataSourceCollection DataSourceCollection
		{
			get
			{
				return DataSourceManager.DataSources;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x00015910 File Offset: 0x00014910
		// (set) Token: 0x060004A6 RID: 1190 RVA: 0x00015918 File Offset: 0x00014918
		public DataSource LastSelectedDataSource
		{
			get
			{
				return DataSourceManager.GetSelected();
			}
			set
			{
				if (value == null)
				{
					return;
				}
				DataSourceManager.SetSelected(value);
			}
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0001592C File Offset: 0x0001492C
		private string #M0c(string #N0c)
		{
			if (#N0c.StartsWith(#Mk.#Lk(10855), StringComparison.OrdinalIgnoreCase))
			{
				return Configuration.#z0c;
			}
			if (#N0c.StartsWith(#Mk.#Lk(10900), StringComparison.OrdinalIgnoreCase))
			{
				return Configuration.#A0c;
			}
			if (#N0c.StartsWith(#Mk.#Lk(10949), StringComparison.OrdinalIgnoreCase))
			{
				return Configuration.#B0c;
			}
			if (#N0c.StartsWith(#Mk.#Lk(10998), StringComparison.OrdinalIgnoreCase))
			{
				return Configuration.#C0c;
			}
			if (#N0c.StartsWith(#Mk.#Lk(11047), StringComparison.OrdinalIgnoreCase))
			{
				return Configuration.#D0c;
			}
			if (#N0c.StartsWith(#Mk.#Lk(11096), StringComparison.OrdinalIgnoreCase))
			{
				return Configuration.#E0c;
			}
			if (#N0c.StartsWith(#Mk.#Lk(11149), StringComparison.OrdinalIgnoreCase))
			{
				return Configuration.#F0c;
			}
			if (#N0c.StartsWith(#Mk.#Lk(11206), StringComparison.OrdinalIgnoreCase))
			{
				return Configuration.#G0c;
			}
			if (#N0c.StartsWith(#Mk.#Lk(11259), StringComparison.OrdinalIgnoreCase))
			{
				return Configuration.#H0c;
			}
			if (#N0c.StartsWith(#Mk.#Lk(11316), StringComparison.OrdinalIgnoreCase))
			{
				return Configuration.#I0c;
			}
			if (#N0c.StartsWith(#Mk.#Lk(11365), StringComparison.OrdinalIgnoreCase))
			{
				return Configuration.#J0c;
			}
			if (#N0c.StartsWith(#Mk.#Lk(11410), StringComparison.OrdinalIgnoreCase))
			{
				return Configuration.#K0c;
			}
			if (#N0c.StartsWith(#Mk.#Lk(11459), StringComparison.OrdinalIgnoreCase))
			{
				return Configuration.#L0c;
			}
			return #N0c;
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x00015A80 File Offset: 0x00014A80
		protected override string NamePrefix
		{
			get
			{
				return #Mk.#Lk(11512);
			}
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00015A8C File Offset: 0x00014A8C
		public override void Initialize()
		{
			Configuration.Instance.EnsureInitialize();
			if (base.ConfigurationVersion != VersionCheck.GetShortBuild())
			{
				this.Upgrade();
			}
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00015AB0 File Offset: 0x00014AB0
		public override void LoadDefaults()
		{
			DataSourceManager.SaveProviders(new string[]
			{
				Configuration.#z0c,
				Configuration.#A0c,
				Configuration.#B0c,
				Configuration.#C0c,
				Configuration.#D0c,
				Configuration.#E0c,
				Configuration.#F0c,
				Configuration.#G0c,
				Configuration.#H0c,
				Configuration.#I0c,
				Configuration.#J0c,
				Configuration.#K0c,
				Configuration.#L0c
			});
			string text = Path.Combine(Configuration.Instance.CodeSmithDataDirectory, #Mk.#Lk(11533));
			DataSourceCollection dataSources = DataSourceManager.GetDataSources();
			if (!dataSources.Contains(#Mk.#Lk(11550)) && File.Exists(text))
			{
				DataSourceManager.Save(new DataSource(#Mk.#Lk(11571), string.Format(#Mk.#Lk(11592), text), Configuration.#L0c, dataSources.Count == 0));
			}
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00015BA4 File Offset: 0x00014BA4
		public override void ResetDefaults()
		{
			this.LoadDefaults();
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00015BAC File Offset: 0x00014BAC
		public override void Upgrade()
		{
			ConfigurationImport configurationImport = base.UpgradeFile<ConfigurationImport>(#Mk.#Lk(11613));
			if (configurationImport != null)
			{
				List<SchemaProvider> list = DataSourceManager.GetProviders().ToList<SchemaProvider>();
				foreach (string assemblyQualifiedName in configurationImport.SchemaProviders)
				{
					Configuration.#8Lb #8Lb = new Configuration.#8Lb();
					#8Lb.#xfb = new SchemaProvider(assemblyQualifiedName);
					if (!list.Any(new Func<SchemaProvider, bool>(#8Lb.#Z5c)))
					{
						list.Add(#8Lb.#xfb);
					}
				}
				DataSourceManager.SaveProviders(list);
				DataSourceCollection dataSources = DataSourceManager.GetDataSources();
				foreach (DataSource dataSource in configurationImport.DataSourceCollection)
				{
					if (!dataSources.Contains(dataSource.Name))
					{
						DataSourceManager.Save(dataSource);
					}
				}
				if (configurationImport.LastSelectedDataSource != null)
				{
					DataSourceManager.SetSelected(configurationImport.LastSelectedDataSource);
				}
			}
			IEnumerable<SchemaProvider> providers = DataSourceManager.GetProviders(true).Select(new Func<SchemaProvider, <>f__AnonymousType0<SchemaProvider, string>>(this.#O0c)).Select(new Func<<>f__AnonymousType0<SchemaProvider, string>, SchemaProvider>(Configuration.<>c.<>9.#05c));
			DataSourceManager.DeleteProviders();
			DataSourceManager.SaveProviders(providers);
			DataSourceCollection dataSources2 = DataSourceManager.GetDataSources();
			foreach (DataSource dataSource2 in dataSources2)
			{
				dataSource2.ProviderTypeName = this.#M0c(dataSource2.ProviderTypeName);
				DataSourceManager.Save(dataSource2);
			}
			base.ConfigurationVersion = VersionCheck.GetShortBuild();
			this.LoadDefaults();
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x00015D7C File Offset: 0x00014D7C
		protected Configuration()
		{
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x00015D84 File Offset: 0x00014D84
		public static Configuration Instance
		{
			get
			{
				return Configuration.#OLb.#MX;
			}
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00015D8C File Offset: 0x00014D8C
		[CompilerGenerated]
		private <>f__AnonymousType0<SchemaProvider, string> #O0c(SchemaProvider #P0c)
		{
			return new
			{
				upgradeProvider = #P0c,
				providerType = this.#M0c(#P0c.AssemblyQualifiedName)
			};
		}

		// Token: 0x040001AE RID: 430
		private static readonly string #z0c = string.Format(#Mk.#Lk(8416), #Mk.#Lk(8594));

		// Token: 0x040001AF RID: 431
		private static readonly string #A0c = string.Format(#Mk.#Lk(8607), #Mk.#Lk(8594));

		// Token: 0x040001B0 RID: 432
		private static readonly string #B0c = string.Format(#Mk.#Lk(8789), #Mk.#Lk(8594));

		// Token: 0x040001B1 RID: 433
		private static readonly string #C0c = string.Format(#Mk.#Lk(8975), #Mk.#Lk(8594));

		// Token: 0x040001B2 RID: 434
		private static readonly string #D0c = string.Format(#Mk.#Lk(9157), #Mk.#Lk(8594));

		// Token: 0x040001B3 RID: 435
		private static readonly string #E0c = string.Format(#Mk.#Lk(9339), #Mk.#Lk(8594));

		// Token: 0x040001B4 RID: 436
		private static readonly string #F0c = string.Format(#Mk.#Lk(9533), #Mk.#Lk(8594));

		// Token: 0x040001B5 RID: 437
		private static readonly string #G0c = string.Format(#Mk.#Lk(9731), #Mk.#Lk(8594));

		// Token: 0x040001B6 RID: 438
		private static readonly string #H0c = string.Format(#Mk.#Lk(9925), #Mk.#Lk(8594));

		// Token: 0x040001B7 RID: 439
		private static readonly string #I0c = string.Format(#Mk.#Lk(10123), #Mk.#Lk(8594));

		// Token: 0x040001B8 RID: 440
		private static readonly string #J0c = string.Format(#Mk.#Lk(10305), #Mk.#Lk(8594));

		// Token: 0x040001B9 RID: 441
		private static readonly string #K0c = string.Format(#Mk.#Lk(10479), #Mk.#Lk(8594));

		// Token: 0x040001BA RID: 442
		private static readonly string #L0c = string.Format(#Mk.#Lk(10665), #Mk.#Lk(8594));

		// Token: 0x02000082 RID: 130
		private sealed class #OLb
		{
			// Token: 0x060004B0 RID: 1200 RVA: 0x00015DA0 File Offset: 0x00014DA0
			static #OLb()
			{
				Configuration.#OLb.#MX.Initialize();
			}

			// Token: 0x040001BB RID: 443
			internal static readonly Configuration #MX = new Configuration();
		}

		// Token: 0x02000083 RID: 131
		[CompilerGenerated]
		private sealed class #8Lb
		{
			// Token: 0x060004B3 RID: 1203 RVA: 0x00015DC8 File Offset: 0x00014DC8
			internal bool #Z5c(SchemaProvider #ksb)
			{
				return #ksb.DisplayName == this.#xfb.DisplayName;
			}

			// Token: 0x040001BC RID: 444
			public SchemaProvider #xfb;
		}
	}
}
