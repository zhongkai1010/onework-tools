using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using #Nk;
using CodeSmith.Core.Extensions;
using CodeSmith.Engine;
using CodeSmith.Engine.Utility;
using Microsoft.Win32;

namespace SchemaExplorer
{
	// Token: 0x0200008C RID: 140
	public class DataSourceManager
	{
		// Token: 0x060004F0 RID: 1264 RVA: 0x00016570 File Offset: 0x00015570
		static DataSourceManager()
		{
			Configuration.Instance.EnsureInitialize();
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x0001657C File Offset: 0x0001557C
		private static string DataSourceSubKey
		{
			get
			{
				return #Mk.#Lk(2670);
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060004F2 RID: 1266 RVA: 0x00016588 File Offset: 0x00015588
		private static string SchemaProviderSubKey
		{
			get
			{
				return #Mk.#Lk(11512);
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x00016594 File Offset: 0x00015594
		public static IList<SchemaProvider> SchemaProviders
		{
			get
			{
				return DataSourceManager.GetProviders().ToList<SchemaProvider>();
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060004F4 RID: 1268 RVA: 0x000165A0 File Offset: 0x000155A0
		public static DataSourceCollection DataSources
		{
			get
			{
				return DataSourceManager.GetDataSources();
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060004F5 RID: 1269 RVA: 0x000165A8 File Offset: 0x000155A8
		// (set) Token: 0x060004F6 RID: 1270 RVA: 0x000165B0 File Offset: 0x000155B0
		public static DataSource LastSelectedDataSource
		{
			get
			{
				return DataSourceManager.GetSelected();
			}
			set
			{
				DataSourceManager.SetSelected(value);
			}
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x000165B8 File Offset: 0x000155B8
		public static void Serialize()
		{
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x000165BC File Offset: 0x000155BC
		public static void Save(DataSource dataSource)
		{
			if (dataSource == null)
			{
				throw new ArgumentNullException(#Mk.#Lk(1002));
			}
			using (RegistryKey registryKey = RegistryUtil.CreateSubKey(RegistryUtil.Key, DataSourceManager.DataSourceSubKey))
			{
				DataSourceManager.Delete(dataSource);
				RegistryUtil.SetString(registryKey, dataSource.Name, #Mk.#Lk(12228), dataSource.ConnectionString);
				RegistryUtil.SetString(registryKey, dataSource.Name, #Mk.#Lk(12316), dataSource.ProviderTypeName);
				RegistryUtil.SetBoolean(registryKey, dataSource.Name, #Mk.#Lk(12467), dataSource.IsSelected);
			}
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00016668 File Offset: 0x00015668
		public static bool Exists(DataSource dataSource)
		{
			if (dataSource == null)
			{
				return false;
			}
			bool result;
			using (RegistryKey registryKey = RegistryUtil.CreateSubKey(RegistryUtil.Key, DataSourceManager.DataSourceSubKey))
			{
				result = RegistryUtil.Exists(registryKey, dataSource.Name);
			}
			return result;
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x000166BC File Offset: 0x000156BC
		public static void Delete(DataSource dataSource)
		{
			if (dataSource == null)
			{
				throw new ArgumentNullException(#Mk.#Lk(1002));
			}
			using (RegistryKey registryKey = RegistryUtil.CreateSubKey(RegistryUtil.Key, DataSourceManager.DataSourceSubKey))
			{
				string subKey = string.IsNullOrEmpty(dataSource.OriginalName) ? dataSource.Name : dataSource.OriginalName;
				if (RegistryUtil.Exists(registryKey, subKey))
				{
					RegistryUtil.DeleteSubKeyTree(registryKey, subKey);
				}
			}
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0001673C File Offset: 0x0001573C
		public static void SetSelected(DataSource dataSource)
		{
			if (dataSource == null)
			{
				throw new ArgumentNullException(#Mk.#Lk(1002));
			}
			foreach (DataSource dataSource2 in DataSourceManager.DataSources)
			{
				if (dataSource2.IsSelected)
				{
					dataSource2.IsSelected = false;
					DataSourceManager.Save(dataSource2);
				}
			}
			dataSource.IsSelected = true;
			DataSourceManager.Save(dataSource);
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x000167BC File Offset: 0x000157BC
		public static DataSource GetSelected()
		{
			DataSourceCollection dataSources = DataSourceManager.DataSources;
			DataSource dataSource = null;
			foreach (DataSource dataSource2 in dataSources)
			{
				if (dataSource2.IsSelected)
				{
					dataSource = dataSource2;
				}
			}
			if (dataSource == null && dataSources.Count > 0)
			{
				return dataSources[0];
			}
			return dataSource;
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x0001682C File Offset: 0x0001582C
		public static DataSourceCollection GetDataSources()
		{
			DataSourceCollection dataSourceCollection = new DataSourceCollection();
			using (RegistryKey registryKey = RegistryUtil.CreateSubKey(RegistryUtil.Key, DataSourceManager.DataSourceSubKey))
			{
				foreach (string text in RegistryUtil.SubKeys(registryKey, string.Empty))
				{
					DataSource item = new DataSource
					{
						Name = text,
						OriginalName = text,
						ConnectionString = RegistryUtil.GetString(registryKey, text, #Mk.#Lk(12228)),
						ProviderTypeName = RegistryUtil.GetString(registryKey, text, #Mk.#Lk(12316)),
						IsSelected = RegistryUtil.GetBoolean(registryKey, text, #Mk.#Lk(12467))
					};
					dataSourceCollection.Add(item);
				}
			}
			return dataSourceCollection;
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00016908 File Offset: 0x00015908
		public static IEnumerable<SchemaProvider> GetProviders()
		{
			return DataSourceManager.GetProviders(!DataSourceManager.#10c);
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00016918 File Offset: 0x00015918
		public static IEnumerable<SchemaProvider> GetProviders(bool probe)
		{
			if (probe)
			{
				IEnumerable<SchemaProvider> providers = DataSourceManager.FindProviders();
				DataSourceManager.SaveProviders(providers);
				DataSourceManager.#10c = true;
			}
			List<SchemaProvider> list = new List<SchemaProvider>();
			using (RegistryKey registryKey = RegistryUtil.CreateSubKey(RegistryUtil.Key, DataSourceManager.SchemaProviderSubKey))
			{
				foreach (string text in RegistryUtil.SubKeys(registryKey, string.Empty))
				{
					string @string = RegistryUtil.GetString(registryKey, text, #Mk.#Lk(12316));
					SchemaProvider item = new SchemaProvider(@string, text);
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x000169D0 File Offset: 0x000159D0
		public static void SaveProviders(IEnumerable<string> providers)
		{
			List<SchemaProvider> list = new List<SchemaProvider>();
			foreach (string assemblyQualifiedName in providers)
			{
				list.Add(new SchemaProvider(assemblyQualifiedName));
			}
			DataSourceManager.SaveProviders(list);
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00016A2C File Offset: 0x00015A2C
		public static void SaveProviders(IEnumerable<SchemaProvider> providers)
		{
			if (providers == null)
			{
				throw new ArgumentNullException(#Mk.#Lk(12480));
			}
			using (RegistryKey registryKey = RegistryUtil.CreateSubKey(RegistryUtil.Key, DataSourceManager.SchemaProviderSubKey))
			{
				foreach (SchemaProvider schemaProvider in providers)
				{
					if (RegistryUtil.Exists(registryKey, schemaProvider.DisplayName))
					{
						RegistryUtil.DeleteSubKeyTree(registryKey, schemaProvider.DisplayName);
					}
					RegistryUtil.SetString(registryKey, schemaProvider.DisplayName, #Mk.#Lk(12316), schemaProvider.AssemblyQualifiedName);
				}
			}
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00016ADC File Offset: 0x00015ADC
		public static void SaveProvider(SchemaProvider provider)
		{
			if (provider == null)
			{
				throw new ArgumentNullException(#Mk.#Lk(12493));
			}
			using (RegistryKey registryKey = RegistryUtil.CreateSubKey(RegistryUtil.Key, DataSourceManager.SchemaProviderSubKey))
			{
				if (RegistryUtil.Exists(registryKey, provider.DisplayName))
				{
					RegistryUtil.DeleteSubKeyTree(registryKey, provider.DisplayName);
				}
				RegistryUtil.SetString(registryKey, provider.DisplayName, #Mk.#Lk(12316), provider.AssemblyQualifiedName);
			}
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x00016B60 File Offset: 0x00015B60
		public static void DeleteProviders()
		{
			if (RegistryUtil.Exists(RegistryUtil.Key, DataSourceManager.SchemaProviderSubKey))
			{
				RegistryUtil.DeleteSubKeyTree(RegistryUtil.Key, DataSourceManager.SchemaProviderSubKey);
			}
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00016B84 File Offset: 0x00015B84
		public static void DeleteProviders(IEnumerable<SchemaProvider> providers)
		{
			if (providers == null)
			{
				throw new ArgumentNullException(#Mk.#Lk(12480));
			}
			using (RegistryKey registryKey = RegistryUtil.CreateSubKey(RegistryUtil.Key, DataSourceManager.SchemaProviderSubKey))
			{
				foreach (SchemaProvider schemaProvider in providers)
				{
					if (RegistryUtil.Exists(registryKey, schemaProvider.DisplayName))
					{
						RegistryUtil.DeleteSubKeyTree(registryKey, schemaProvider.DisplayName);
					}
				}
			}
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00016C18 File Offset: 0x00015C18
		public static IEnumerable<SchemaProvider> FindProviders()
		{
			IEnumerable<string> enumerable = DataSourceManager.#50c();
			HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			foreach (string path in enumerable)
			{
				if (Directory.Exists(path))
				{
					hashSet.AddRange(Directory.GetFiles(path, #Mk.#Lk(12506)));
				}
			}
			ConcurrentBag<SchemaProvider> concurrentBag = new ConcurrentBag<SchemaProvider>();
			foreach (string #7n in hashSet)
			{
				SchemaProvider schemaProvider = DataSourceManager.#40c(#7n);
				if (schemaProvider != null && !concurrentBag.Contains(schemaProvider))
				{
					concurrentBag.Add(schemaProvider);
				}
			}
			return concurrentBag;
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00016CEC File Offset: 0x00015CEC
		private static SchemaProvider #40c(string #7n)
		{
			try
			{
				Assembly assembly = Assembly.LoadFrom(#7n);
				if (assembly == null)
				{
					return null;
				}
				foreach (Type type in assembly.GetTypes())
				{
					Type @interface = type.GetInterface(typeof(IDbSchemaProvider).FullName);
					if (!(@interface == null))
					{
						IDbSchemaProvider dbSchemaProvider = Activator.CreateInstance(type) as IDbSchemaProvider;
						if (dbSchemaProvider != null)
						{
							string assemblyQualifiedName = dbSchemaProvider.GetType().AssemblyQualifiedName;
							if (!string.IsNullOrEmpty(assemblyQualifiedName))
							{
								string[] array = assemblyQualifiedName.Split(new char[]
								{
									','
								});
								return new SchemaProvider(string.Format(#Mk.#Lk(12535), array[0], array[1]));
							}
						}
					}
				}
			}
			catch (InvalidCastException ex)
			{
			}
			catch (FileLoadException ex2)
			{
			}
			catch (ReflectionTypeLoadException ex3)
			{
			}
			catch (Exception ex4)
			{
			}
			return null;
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x00016DF8 File Offset: 0x00015DF8
		private static IEnumerable<string> #50c()
		{
			HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			string text = Configuration.Instance.ApplicationDirectory;
			if (!string.IsNullOrEmpty(text))
			{
				hashSet.Add(text);
				hashSet.Add(Path.Combine(text, #Mk.#Lk(12548)));
				hashSet.Add(Path.Combine(text, #Mk.#Lk(12569)));
				hashSet.Add(Path.Combine(text, #Mk.#Lk(12578)));
			}
			text = AppDomain.CurrentDomain.BaseDirectory;
			if (!string.IsNullOrEmpty(text))
			{
				hashSet.Add(text);
				hashSet.Add(Path.Combine(text, #Mk.#Lk(12548)));
				hashSet.Add(Path.Combine(text, #Mk.#Lk(12569)));
				hashSet.Add(Path.Combine(text, #Mk.#Lk(12578)));
			}
			text = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			if (!string.IsNullOrEmpty(text))
			{
				hashSet.Add(text);
			}
			Assembly entryAssembly = Assembly.GetEntryAssembly();
			if (entryAssembly != null)
			{
				text = Path.GetDirectoryName(entryAssembly.Location);
				if (!string.IsNullOrEmpty(text))
				{
					hashSet.Add(text);
					hashSet.Add(Path.Combine(text, #Mk.#Lk(12548)));
					hashSet.Add(Path.Combine(text, #Mk.#Lk(12569)));
					hashSet.Add(Path.Combine(text, #Mk.#Lk(12578)));
				}
			}
			return hashSet;
		}

		// Token: 0x040001CD RID: 461
		private static bool #10c;
	}
}
