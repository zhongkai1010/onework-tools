using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CodeSmith.Core.Collections;
using CodeSmith.Core.Extensions;

namespace SchemaExplorer
{
	// Token: 0x02000058 RID: 88
	[Serializable]
	public class SchemaObjectWithOwnerCollection<T> : SchemaObjectCollection<T>, CodeSmith.Core.Collections.INamedObjectCollection<T>, IObservableList<T>, IEnumerable, IList<T>, ICollection<T>, IEnumerable<T>, ISchemaObjectCollection<T>, ISchemaObjectWithOwnerCollection<T>, CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<T>, CodeSmith.Core.Collections.IReadOnlyCollection<T>, INotifyCollectionChanged, IReadOnlySchemaObjectCollection<T>, INotifyPropertyChanged, IReadOnlySchemaObjectWithOwnerCollection<T> where T : ISchemaObjectWithOwner
	{
		// Token: 0x06000368 RID: 872 RVA: 0x000135B4 File Offset: 0x000125B4
		public SchemaObjectWithOwnerCollection()
		{
		}

		// Token: 0x06000369 RID: 873 RVA: 0x000135BC File Offset: 0x000125BC
		public SchemaObjectWithOwnerCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x0600036A RID: 874 RVA: 0x000135C8 File Offset: 0x000125C8
		public SchemaObjectWithOwnerCollection(IEnumerable<T> collection) : base(collection)
		{
		}

		// Token: 0x170000E2 RID: 226
		public T this[string owner, string name]
		{
			get
			{
				SchemaObjectWithOwnerCollection<T>.#fj #fj = new SchemaObjectWithOwnerCollection<T>.#fj();
				#fj.#5n = name;
				#fj.#iV = owner;
				if (string.IsNullOrWhiteSpace(#fj.#iV))
				{
					return this[#fj.#5n];
				}
				return this.FirstOrDefault(new Func<T, bool>(#fj.#A5c));
			}
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00013624 File Offset: 0x00012624
		public bool Contains(string owner, string name)
		{
			SchemaObjectWithOwnerCollection<T>.#ij #ij = new SchemaObjectWithOwnerCollection<T>.#ij();
			#ij.#5n = name;
			#ij.#iV = owner;
			if (string.IsNullOrWhiteSpace(#ij.#iV))
			{
				return base.Contains(#ij.#5n);
			}
			return this.Any(new Func<T, bool>(#ij.#D5c));
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00013674 File Offset: 0x00012674
		public int IndexOf(string owner, string name)
		{
			SchemaObjectWithOwnerCollection<T>.#nj #nj = new SchemaObjectWithOwnerCollection<T>.#nj();
			#nj.#5n = name;
			#nj.#iV = owner;
			if (string.IsNullOrWhiteSpace(#nj.#iV))
			{
				return base.IndexOf(#nj.#5n);
			}
			return this.IndexOf(new Func<T, bool>(#nj.#E5c));
		}

		// Token: 0x02000059 RID: 89
		[CompilerGenerated]
		private sealed class #fj
		{
			// Token: 0x0600036F RID: 879 RVA: 0x000136CC File Offset: 0x000126CC
			internal bool #A5c(#6d #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase) && #ln.Owner.Equals(this.#iV, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000161 RID: 353
			public string #5n;

			// Token: 0x04000162 RID: 354
			public string #iV;
		}

		// Token: 0x0200005A RID: 90
		[CompilerGenerated]
		private sealed class #ij
		{
			// Token: 0x06000371 RID: 881 RVA: 0x0001370C File Offset: 0x0001270C
			internal bool #D5c(#6d #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase) && #ln.Owner.Equals(this.#iV, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000163 RID: 355
			public string #5n;

			// Token: 0x04000164 RID: 356
			public string #iV;
		}

		// Token: 0x0200005B RID: 91
		[CompilerGenerated]
		private sealed class #nj
		{
			// Token: 0x06000373 RID: 883 RVA: 0x0001374C File Offset: 0x0001274C
			internal bool #E5c(#6d #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase) && #ln.Owner.Equals(this.#iV, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000165 RID: 357
			public string #5n;

			// Token: 0x04000166 RID: 358
			public string #iV;
		}
	}
}
