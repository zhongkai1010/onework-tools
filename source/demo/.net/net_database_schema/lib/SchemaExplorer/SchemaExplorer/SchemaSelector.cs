using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;
using ActiproSoftware.Windows.Controls.PropertyGrid.Editors;
using CodeSmith.Engine;
using SchemaExplorer.Design;
using SchemaExplorer.Serialization;
using SchemaExplorer.TypeConverters;

namespace SchemaExplorer
{
	// Token: 0x02000067 RID: 103
	[PropertySerializer(typeof(SchemaSelectorSerializer))]
	[TypeConverter(typeof(SchemaSelectorTypeConverter))]
	[Editor(typeof(SchemaObjectEditor), typeof(PropertyEditor))]
	[PropertyRefresher(typeof(MethodPropertyRefresher))]
	[Serializable]
	public class SchemaSelector : DatabaseSchema
	{
		// Token: 0x060003EB RID: 1003 RVA: 0x0001413C File Offset: 0x0001313C
		public SchemaSelector()
		{
			this.SelectMode = SelectMode.Exclude;
			this.SelectedTables = new HashSet<string>();
			this.SelectedColumns = new HashSet<string>();
			this.SelectedCommands = new HashSet<string>();
			this.SchemaExpressions = new HashSet<string>();
			this.ColumnExpressions = new HashSet<string>();
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00014190 File Offset: 0x00013190
		public SchemaSelector(IDbSchemaProvider provider, string connectionString) : base(provider, connectionString)
		{
			this.SelectMode = SelectMode.Exclude;
			this.SelectedTables = new HashSet<string>();
			this.SelectedColumns = new HashSet<string>();
			this.SelectedCommands = new HashSet<string>();
			this.SchemaExpressions = new HashSet<string>();
			this.ColumnExpressions = new HashSet<string>();
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060003ED RID: 1005 RVA: 0x000141E4 File Offset: 0x000131E4
		// (set) Token: 0x060003EE RID: 1006 RVA: 0x000141EC File Offset: 0x000131EC
		public SelectMode SelectMode { get; set; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x000141F8 File Offset: 0x000131F8
		// (set) Token: 0x060003F0 RID: 1008 RVA: 0x00014200 File Offset: 0x00013200
		public HashSet<string> SelectedTables { get; set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x0001420C File Offset: 0x0001320C
		// (set) Token: 0x060003F2 RID: 1010 RVA: 0x00014214 File Offset: 0x00013214
		public HashSet<string> SelectedColumns { get; set; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x00014220 File Offset: 0x00013220
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x00014228 File Offset: 0x00013228
		public HashSet<string> SelectedCommands { get; set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x00014234 File Offset: 0x00013234
		// (set) Token: 0x060003F6 RID: 1014 RVA: 0x0001423C File Offset: 0x0001323C
		public HashSet<string> SchemaExpressions { get; set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x00014248 File Offset: 0x00013248
		// (set) Token: 0x060003F8 RID: 1016 RVA: 0x00014250 File Offset: 0x00013250
		public HashSet<string> ColumnExpressions { get; set; }

		// Token: 0x060003F9 RID: 1017 RVA: 0x0001425C File Offset: 0x0001325C
		public void Clear()
		{
			this.SelectedTables.Clear();
			this.SelectedColumns.Clear();
			this.SelectedCommands.Clear();
			this.SchemaExpressions.Clear();
			this.ColumnExpressions.Clear();
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00014298 File Offset: 0x00013298
		// Note: this type is marked as 'beforefieldinit'.
		static SchemaSelector()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (SchemaSelector.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x060003FB RID: 1019
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
