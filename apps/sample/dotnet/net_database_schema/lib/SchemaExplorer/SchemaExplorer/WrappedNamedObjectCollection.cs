using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000039 RID: 57
	[Serializable]
	public class WrappedNamedObjectCollection<TBase, TActual> : WrappedObservableList<TBase, TActual>, CodeSmith.Core.Collections.INamedObjectCollection<TBase>, IObservableList<TBase>, IEnumerable, IList<TBase>, ICollection<TBase>, IEnumerable<TBase>, INotifyCollectionChanged, INotifyPropertyChanged where TBase : class, CodeSmith.Core.Collections.INamedObject where TActual : class, CodeSmith.Core.Collections.INamedObject, TBase
	{
		// Token: 0x060002DE RID: 734 RVA: 0x000127DC File Offset: 0x000117DC
		public WrappedNamedObjectCollection() : this(null)
		{
		}

		// Token: 0x060002DF RID: 735 RVA: 0x000127E8 File Offset: 0x000117E8
		public WrappedNamedObjectCollection(IEnumerable<TBase> data) : this((data == null) ? null : data.Cast<TActual>())
		{
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x000127FC File Offset: 0x000117FC
		public WrappedNamedObjectCollection(IEnumerable<TActual> data) : base(data)
		{
		}

		// Token: 0x170000BE RID: 190
		public TBase this[string name]
		{
			get
			{
				WrappedNamedObjectCollection<TBase, TActual>.#fj #fj = new WrappedNamedObjectCollection<TBase, TActual>.#fj();
				#fj.#5n = name;
				return this.FirstOrDefault(new Func<TBase, bool>(#fj.#A5c));
			}
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00012834 File Offset: 0x00011834
		public bool Contains(string name)
		{
			WrappedNamedObjectCollection<TBase, TActual>.#ij #ij = new WrappedNamedObjectCollection<TBase, TActual>.#ij();
			#ij.#5n = name;
			return this.Any(new Func<TBase, bool>(#ij.#D5c));
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00012860 File Offset: 0x00011860
		public int IndexOf(string name)
		{
			WrappedNamedObjectCollection<TBase, TActual>.#nj #nj = new WrappedNamedObjectCollection<TBase, TActual>.#nj();
			#nj.#5n = name;
			return base.FindIndex(new Predicate<TBase>(#nj.#E5c));
		}

		// Token: 0x0200003A RID: 58
		[CompilerGenerated]
		private sealed class #fj
		{
			// Token: 0x060002E5 RID: 741 RVA: 0x00012894 File Offset: 0x00011894
			internal bool #A5c(#B5c #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000148 RID: 328
			public string #5n;
		}

		// Token: 0x0200003B RID: 59
		[CompilerGenerated]
		private sealed class #ij
		{
			// Token: 0x060002E7 RID: 743 RVA: 0x000128B8 File Offset: 0x000118B8
			internal bool #D5c(#B5c #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000149 RID: 329
			public string #5n;
		}

		// Token: 0x0200003C RID: 60
		[CompilerGenerated]
		private sealed class #nj
		{
			// Token: 0x060002E9 RID: 745 RVA: 0x000128DC File Offset: 0x000118DC
			internal bool #E5c(#B5c #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x0400014A RID: 330
			public string #5n;
		}
	}
}
