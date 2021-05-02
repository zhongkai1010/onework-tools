using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using #Nk;
using CodeSmith.Core.Extensions;

namespace CodeSmith.Core.Collections
{
	// Token: 0x020000DA RID: 218
	public class ReadOnlyNamedObjectCollection<T> : ReadOnlyCollection<T>, IEnumerable, IEnumerable<T>, IReadOnlyNamedObjectCollection<T>, IReadOnlyCollection<T> where T : INamedObject
	{
		// Token: 0x060007C2 RID: 1986 RVA: 0x0002675C File Offset: 0x0002575C
		public ReadOnlyNamedObjectCollection(IEnumerable<T> items) : base(items.ToList<T>())
		{
		}

		// Token: 0x170001EE RID: 494
		public virtual T this[string name]
		{
			get
			{
				ReadOnlyNamedObjectCollection<T>.#Ck #Ck = new ReadOnlyNamedObjectCollection<T>.#Ck();
				#Ck.#5n = name;
				return this.FirstOrDefault(new Func<T, bool>(#Ck.#A5c));
			}
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x00026798 File Offset: 0x00025798
		public bool Contains(string name)
		{
			ReadOnlyNamedObjectCollection<T>.#rNb #rNb = new ReadOnlyNamedObjectCollection<T>.#rNb();
			#rNb.#5n = name;
			return this.Any(new Func<T, bool>(#rNb.#D5c));
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x000267C4 File Offset: 0x000257C4
		public int IndexOf(string name)
		{
			ReadOnlyNamedObjectCollection<T>.#fj #fj = new ReadOnlyNamedObjectCollection<T>.#fj();
			#fj.#5n = name;
			return this.IndexOf(new Func<T, bool>(#fj.#E5c));
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x000267F0 File Offset: 0x000257F0
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < base.Count; i++)
			{
				stringBuilder.Append(base[i]);
				if (i < base.Count - 1)
				{
					stringBuilder.Append(#Mk.#Lk(8261));
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x020000DB RID: 219
		[CompilerGenerated]
		private sealed class #Ck
		{
			// Token: 0x060007C8 RID: 1992 RVA: 0x00026854 File Offset: 0x00025854
			internal bool #A5c(#6d #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000307 RID: 775
			public string #5n;
		}

		// Token: 0x020000DC RID: 220
		[CompilerGenerated]
		private sealed class #rNb
		{
			// Token: 0x060007CA RID: 1994 RVA: 0x00026878 File Offset: 0x00025878
			internal bool #D5c(#6d #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000308 RID: 776
			public string #5n;
		}

		// Token: 0x020000DD RID: 221
		[CompilerGenerated]
		private sealed class #fj
		{
			// Token: 0x060007CC RID: 1996 RVA: 0x0002689C File Offset: 0x0002589C
			internal bool #E5c(#6d #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000309 RID: 777
			public string #5n;
		}
	}
}
