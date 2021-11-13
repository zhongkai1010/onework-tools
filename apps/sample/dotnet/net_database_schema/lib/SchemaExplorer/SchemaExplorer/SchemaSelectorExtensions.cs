using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text.RegularExpressions;
using #Nk;

namespace SchemaExplorer
{
	// Token: 0x0200006C RID: 108
	public static class SchemaSelectorExtensions
	{
		// Token: 0x06000422 RID: 1058 RVA: 0x0001494C File Offset: 0x0001394C
		public static IEnumerable<TTabular> Selected<TTabular>(this IEnumerable<TTabular> items) where TTabular : ITabularObject
		{
			if (items == null)
			{
				return Enumerable.Empty<TTabular>();
			}
			return items.Where(new Func<TTabular, bool>(SchemaSelectorExtensions.<>c__0<TTabular>.<>9.#G5c));
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0001497C File Offset: 0x0001397C
		public static IEnumerable<CommandSchema> Selected(this IEnumerable<CommandSchema> items)
		{
			if (items == null)
			{
				return Enumerable.Empty<CommandSchema>();
			}
			return items.Where(new Func<CommandSchema, bool>(SchemaSelectorExtensions.<>c.<>9.#H5c));
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x000149AC File Offset: 0x000139AC
		public static IEnumerable<ColumnSchema> Selected(this IEnumerable<ColumnSchema> items)
		{
			if (items == null)
			{
				return Enumerable.Empty<ColumnSchema>();
			}
			return items.Where(new Func<ColumnSchema, bool>(SchemaSelectorExtensions.<>c.<>9.#I5c));
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x000149DC File Offset: 0x000139DC
		public static IEnumerable<ViewColumnSchema> Selected(this IEnumerable<ViewColumnSchema> items)
		{
			if (items == null)
			{
				return Enumerable.Empty<ViewColumnSchema>();
			}
			return items.Where(new Func<ViewColumnSchema, bool>(SchemaSelectorExtensions.<>c.<>9.#J5c));
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00014A0C File Offset: 0x00013A0C
		public static IEnumerable<TableKeySchema> Selected(this IEnumerable<TableKeySchema> items)
		{
			if (items == null)
			{
				return Enumerable.Empty<TableKeySchema>();
			}
			return items.Where(new Func<TableKeySchema, bool>(SchemaSelectorExtensions.<>c.<>9.#K5c));
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00014A3C File Offset: 0x00013A3C
		public static TableSchemaCollection ToTables(this IEnumerable<TableSchema> items)
		{
			return new TableSchemaCollection(items);
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00014A54 File Offset: 0x00013A54
		public static ViewSchemaCollection ToViews(this IEnumerable<ViewSchema> items)
		{
			return new ViewSchemaCollection(items);
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00014A6C File Offset: 0x00013A6C
		public static CommandSchemaCollection ToCommands(this IEnumerable<CommandSchema> items)
		{
			return new CommandSchemaCollection(items);
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00014A84 File Offset: 0x00013A84
		public static ColumnSchemaCollection ToColumns(this IEnumerable<ColumnSchema> items)
		{
			return new ColumnSchemaCollection(items);
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00014A9C File Offset: 0x00013A9C
		public static ViewColumnSchemaCollection ToColumns(this IEnumerable<ViewColumnSchema> items)
		{
			return new ViewColumnSchemaCollection(items);
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x00014AB4 File Offset: 0x00013AB4
		public static TableKeySchemaCollection ToKeys(this IEnumerable<TableKeySchema> items)
		{
			return new TableKeySchemaCollection(items);
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x00014ACC File Offset: 0x00013ACC
		public static bool Selected(this ITabularObject item)
		{
			SchemaSelectorExtensions.#zk #zk = new SchemaSelectorExtensions.#zk();
			if (item == null)
			{
				return false;
			}
			SchemaSelector schemaSelector = item.Database as SchemaSelector;
			if (schemaSelector == null)
			{
				return true;
			}
			#zk.#O5c = item.FullName;
			bool flag = schemaSelector.SelectedTables.Contains(#zk.#O5c);
			bool flag2 = schemaSelector.SchemaExpressions.Any(new Func<string, bool>(#zk.#P5c));
			bool flag3 = flag || flag2;
			return (schemaSelector.SelectMode != SelectMode.Exclude || !flag3) && (schemaSelector.SelectMode != SelectMode.Include || flag3);
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x00014B50 File Offset: 0x00013B50
		public static bool Selected(this IColumnSchema item)
		{
			return SchemaSelectorExtensions.#i0c(item);
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00014B58 File Offset: 0x00013B58
		public static bool Selected(this IViewColumnSchema item)
		{
			return SchemaSelectorExtensions.#i0c(item);
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00014B60 File Offset: 0x00013B60
		public static bool Selected(this ICommandSchema item)
		{
			SchemaSelectorExtensions.#Wj #Wj = new SchemaSelectorExtensions.#Wj();
			if (item == null)
			{
				return false;
			}
			SchemaSelector schemaSelector = item.Database as SchemaSelector;
			if (schemaSelector == null)
			{
				return true;
			}
			#Wj.#O5c = item.FullName;
			bool flag = schemaSelector.SelectedCommands.Contains(#Wj.#O5c);
			bool flag2 = schemaSelector.SchemaExpressions.Any(new Func<string, bool>(#Wj.#P5c));
			bool flag3 = flag || flag2;
			return (schemaSelector.SelectMode != SelectMode.Exclude || !flag3) && (schemaSelector.SelectMode != SelectMode.Include || flag3);
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00014BE4 File Offset: 0x00013BE4
		public static bool Selected(this ITableKeySchema item)
		{
			if (item == null)
			{
				return false;
			}
			if (!(item.Database is SchemaSelector))
			{
				return true;
			}
			if (item.PrimaryKeyTable == null || item.PrimaryKeyMemberColumns == null || item.ForeignKeyTable == null || item.ForeignKeyMemberColumns == null)
			{
				return false;
			}
			if (item.PrimaryKeyTable.Selected() && item.ForeignKeyTable.Selected())
			{
				if (item.PrimaryKeyMemberColumns.All(new Func<IMemberColumnSchema, bool>(SchemaSelectorExtensions.<>c.<>9.#L5c)))
				{
					return item.ForeignKeyMemberColumns.All(new Func<IMemberColumnSchema, bool>(SchemaSelectorExtensions.<>c.<>9.#M5c));
				}
			}
			return false;
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00014C9C File Offset: 0x00013C9C
		public static bool Selected(this IPrimaryKeySchema item)
		{
			if (item == null)
			{
				return false;
			}
			if (!(item.Database is SchemaSelector))
			{
				return true;
			}
			if (item.Table == null || item.MemberColumns == null)
			{
				return false;
			}
			if (item.Table.Selected())
			{
				return item.MemberColumns.All(new Func<IMemberColumnSchema, bool>(SchemaSelectorExtensions.<>c.<>9.#N5c));
			}
			return false;
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00014D0C File Offset: 0x00013D0C
		private static bool #i0c(IDataObject #Ul)
		{
			SchemaSelectorExtensions.#R5c #R5c = new SchemaSelectorExtensions.#R5c();
			if (#Ul == null)
			{
				return false;
			}
			SchemaSelector schemaSelector = #Ul.Database as SchemaSelector;
			if (schemaSelector == null)
			{
				return true;
			}
			#R5c.#4r = #Ul.FullName;
			bool flag = schemaSelector.SelectedColumns.Count > 0;
			bool flag2 = schemaSelector.ColumnExpressions.Count > 0;
			if (!flag && !flag2)
			{
				return true;
			}
			bool flag3 = flag && schemaSelector.SelectedColumns.Contains(#R5c.#4r);
			bool flag4 = flag2 && schemaSelector.ColumnExpressions.Any(new Func<string, bool>(#R5c.#Q5c));
			bool flag5 = flag3 || flag4;
			return (schemaSelector.SelectMode != SelectMode.Exclude || !flag5) && (schemaSelector.SelectMode != SelectMode.Include || flag5);
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00014DC8 File Offset: 0x00013DC8
		// Note: this type is marked as 'beforefieldinit'.
		static SchemaSelectorExtensions()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (SchemaSelectorExtensions.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000435 RID: 1077
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x0200006F RID: 111
		[CompilerGenerated]
		private sealed class #zk
		{
			// Token: 0x06000443 RID: 1091 RVA: 0x00014E94 File Offset: 0x00013E94
			internal bool #P5c(string #6d)
			{
				return Regex.IsMatch(this.#O5c, #6d);
			}

			// Token: 0x04000193 RID: 403
			public string #O5c;
		}

		// Token: 0x02000070 RID: 112
		[CompilerGenerated]
		private sealed class #Wj
		{
			// Token: 0x06000445 RID: 1093 RVA: 0x00014EAC File Offset: 0x00013EAC
			internal bool #P5c(string #6d)
			{
				return Regex.IsMatch(this.#O5c, #6d);
			}

			// Token: 0x04000194 RID: 404
			public string #O5c;
		}

		// Token: 0x02000071 RID: 113
		[CompilerGenerated]
		private sealed class #R5c
		{
			// Token: 0x06000447 RID: 1095 RVA: 0x00014EC4 File Offset: 0x00013EC4
			internal bool #Q5c(string #FN)
			{
				return Regex.IsMatch(this.#4r, #FN);
			}

			// Token: 0x04000195 RID: 405
			public string #4r;
		}
	}
}
