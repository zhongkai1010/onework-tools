using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Xml.Serialization;
using #Nk;

namespace SchemaExplorer
{
	// Token: 0x02000085 RID: 133
	[XmlRoot("schemaExplorer")]
	public class ConfigurationImport
	{
		// Token: 0x060004B7 RID: 1207 RVA: 0x00015E04 File Offset: 0x00014E04
		public ConfigurationImport()
		{
			this.SchemaProviders = new List<string>();
			this.DataSourceCollection = new DataSourceCollection();
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x00015E24 File Offset: 0x00014E24
		// (set) Token: 0x060004B9 RID: 1209 RVA: 0x00015E2C File Offset: 0x00014E2C
		[XmlArray("schemaProviders")]
		[XmlArrayItem("schemaProvider", typeof(string))]
		public List<string> SchemaProviders { get; set; }

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x00015E38 File Offset: 0x00014E38
		// (set) Token: 0x060004BB RID: 1211 RVA: 0x00015E40 File Offset: 0x00014E40
		[XmlArray("dataSources")]
		[XmlArrayItem("dataSource", typeof(DataSource))]
		public DataSourceCollection DataSourceCollection { get; set; }

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x00015E4C File Offset: 0x00014E4C
		// (set) Token: 0x060004BD RID: 1213 RVA: 0x00015E54 File Offset: 0x00014E54
		[XmlElement(ElementName = "selectedDataSource")]
		public DataSource LastSelectedDataSource { get; set; }

		// Token: 0x060004BE RID: 1214 RVA: 0x00015E60 File Offset: 0x00014E60
		// Note: this type is marked as 'beforefieldinit'.
		static ConfigurationImport()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (ConfigurationImport.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x060004BF RID: 1215
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
