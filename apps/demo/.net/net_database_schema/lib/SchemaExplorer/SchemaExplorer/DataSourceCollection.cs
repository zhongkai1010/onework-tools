using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CodeSmith.Core.Collections;
using CodeSmith.Core.Extensions;

namespace SchemaExplorer
{
	// Token: 0x02000088 RID: 136
	[Serializable]
	public class DataSourceCollection : ObservableList<DataSource>
	{
		// Token: 0x060004E3 RID: 1251 RVA: 0x00016470 File Offset: 0x00015470
		public DataSourceCollection()
		{
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00016478 File Offset: 0x00015478
		public DataSourceCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00016484 File Offset: 0x00015484
		public DataSourceCollection(IEnumerable<DataSource> collection) : base(collection)
		{
		}

		// Token: 0x17000157 RID: 343
		public DataSource this[string name]
		{
			get
			{
				DataSourceCollection.#fj #fj = new DataSourceCollection.#fj();
				#fj.#5n = name;
				return this.FirstOrDefault(new Func<DataSource, bool>(#fj.#A5c));
			}
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x000164BC File Offset: 0x000154BC
		public bool Contains(string name)
		{
			DataSourceCollection.#ij #ij = new DataSourceCollection.#ij();
			#ij.#5n = name;
			return this.Any(new Func<DataSource, bool>(#ij.#D5c));
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x000164E8 File Offset: 0x000154E8
		public int IndexOf(string name)
		{
			DataSourceCollection.#nj #nj = new DataSourceCollection.#nj();
			#nj.#5n = name;
			return this.IndexOf(new Func<DataSource, bool>(#nj.#E5c));
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x00016514 File Offset: 0x00015514
		public virtual object Clone()
		{
			return new DataSourceCollection(this);
		}

		// Token: 0x02000089 RID: 137
		[CompilerGenerated]
		private sealed class #fj
		{
			// Token: 0x060004EB RID: 1259 RVA: 0x00016524 File Offset: 0x00015524
			internal bool #A5c(DataSource #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x040001CA RID: 458
			public string #5n;
		}

		// Token: 0x0200008A RID: 138
		[CompilerGenerated]
		private sealed class #ij
		{
			// Token: 0x060004ED RID: 1261 RVA: 0x00016540 File Offset: 0x00015540
			internal bool #D5c(DataSource #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x040001CB RID: 459
			public string #5n;
		}

		// Token: 0x0200008B RID: 139
		[CompilerGenerated]
		private sealed class #nj
		{
			// Token: 0x060004EF RID: 1263 RVA: 0x0001655C File Offset: 0x0001555C
			internal bool #E5c(DataSource #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x040001CC RID: 460
			public string #5n;
		}
	}
}
