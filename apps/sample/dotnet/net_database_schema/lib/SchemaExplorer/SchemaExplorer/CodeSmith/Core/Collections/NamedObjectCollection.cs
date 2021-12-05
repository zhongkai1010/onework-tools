using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using #Nk;
using CodeSmith.Core.Extensions;

namespace CodeSmith.Core.Collections
{
	// Token: 0x0200004D RID: 77
	[Serializable]
	public class NamedObjectCollection<T> : ObservableList<T>, INamedObjectCollection<T>, IObservableList<T>, IEnumerable, IList<T>, ICollection<T>, IEnumerable<T>, IReadOnlyNamedObjectCollection<T>, IReadOnlyCollection<T>, INotifyCollectionChanged, INotifyPropertyChanged where T : INamedObject
	{
		// Token: 0x06000326 RID: 806 RVA: 0x00012E38 File Offset: 0x00011E38
		public NamedObjectCollection()
		{
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00012E40 File Offset: 0x00011E40
		public NamedObjectCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00012E4C File Offset: 0x00011E4C
		public NamedObjectCollection(IEnumerable<T> collection) : base(collection)
		{
		}

		// Token: 0x170000CE RID: 206
		public virtual T this[string name]
		{
			get
			{
				NamedObjectCollection<T>.#fj #fj = new NamedObjectCollection<T>.#fj();
				#fj.#5n = name;
				return this.FirstOrDefault(new Func<T, bool>(#fj.#A5c));
			}
			set
			{
				int num = this.IndexOf(name);
				if (num >= 0)
				{
					base[num] = value;
					return;
				}
				base.Add(value);
			}
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00012EB0 File Offset: 0x00011EB0
		public bool Contains(string name)
		{
			NamedObjectCollection<T>.#nj #nj = new NamedObjectCollection<T>.#nj();
			#nj.#5n = name;
			return this.Any(new Func<T, bool>(#nj.#D5c));
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00012EDC File Offset: 0x00011EDC
		public int IndexOf(string name)
		{
			NamedObjectCollection<T>.#Lj #Lj = new NamedObjectCollection<T>.#Lj();
			#Lj.#5n = name;
			return this.IndexOf(new Func<T, bool>(#Lj.#E5c));
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00012F08 File Offset: 0x00011F08
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

		// Token: 0x0200004E RID: 78
		[CompilerGenerated]
		private sealed class #fj
		{
			// Token: 0x0600032F RID: 815 RVA: 0x00012F6C File Offset: 0x00011F6C
			internal bool #A5c(#6d #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000154 RID: 340
			public string #5n;
		}

		// Token: 0x0200004F RID: 79
		[CompilerGenerated]
		private sealed class #nj
		{
			// Token: 0x06000331 RID: 817 RVA: 0x00012F90 File Offset: 0x00011F90
			internal bool #D5c(#6d #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000155 RID: 341
			public string #5n;
		}

		// Token: 0x02000050 RID: 80
		[CompilerGenerated]
		private sealed class #Lj
		{
			// Token: 0x06000333 RID: 819 RVA: 0x00012FB4 File Offset: 0x00011FB4
			internal bool #E5c(#6d #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000156 RID: 342
			public string #5n;
		}
	}
}
