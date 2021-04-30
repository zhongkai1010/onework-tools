using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using #Nk;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x0200003F RID: 63
	public class WrappedSchemaObjectCollection<TBase, TActual> : WrappedObservableList<TBase, TActual>, CodeSmith.Core.Collections.INamedObjectCollection<TBase>, IObservableList<TBase>, IEnumerable, IList<TBase>, ICollection<TBase>, IEnumerable<TBase>, ISchemaObjectCollection<TBase>, INotifyCollectionChanged, INotifyPropertyChanged where TBase : class, ISchemaObject where TActual : class, ISchemaObject, TBase
	{
		// Token: 0x060002EE RID: 750 RVA: 0x000128F8 File Offset: 0x000118F8
		public WrappedSchemaObjectCollection() : this(null)
		{
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00012904 File Offset: 0x00011904
		public WrappedSchemaObjectCollection(IEnumerable<TBase> data) : this((data == null) ? null : data.Cast<TActual>())
		{
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00012918 File Offset: 0x00011918
		public WrappedSchemaObjectCollection(IEnumerable<TActual> data) : base(data)
		{
		}

		// Token: 0x170000C1 RID: 193
		public virtual TBase this[string name]
		{
			get
			{
				WrappedSchemaObjectCollection<TBase, TActual>.#fj #fj = new WrappedSchemaObjectCollection<TBase, TActual>.#fj();
				#fj.#5n = name;
				return this.FirstOrDefault(new Func<TBase, bool>(#fj.#A5c));
			}
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00012950 File Offset: 0x00011950
		public bool Contains(string name)
		{
			WrappedSchemaObjectCollection<TBase, TActual>.#ij #ij = new WrappedSchemaObjectCollection<TBase, TActual>.#ij();
			#ij.#5n = name;
			return this.Any(new Func<TBase, bool>(#ij.#D5c));
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0001297C File Offset: 0x0001197C
		public int IndexOf(string name)
		{
			WrappedSchemaObjectCollection<TBase, TActual>.#nj #nj = new WrappedSchemaObjectCollection<TBase, TActual>.#nj();
			#nj.#5n = name;
			return base.FindIndex(new Predicate<TBase>(#nj.#E5c));
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x000129A8 File Offset: 0x000119A8
		public SchemaObjectCollection<TBase> Clone()
		{
			return new SchemaObjectCollection<TBase>(this);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x000129B0 File Offset: 0x000119B0
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

		// Token: 0x060002F6 RID: 758 RVA: 0x00012A0C File Offset: 0x00011A0C
		public void Refresh()
		{
			foreach (TBase tbase in this)
			{
				tbase.Refresh();
			}
		}

		// Token: 0x02000040 RID: 64
		[CompilerGenerated]
		private sealed class #fj
		{
			// Token: 0x060002F8 RID: 760 RVA: 0x00012A60 File Offset: 0x00011A60
			internal bool #A5c(#B5c #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x0400014B RID: 331
			public string #5n;
		}

		// Token: 0x02000041 RID: 65
		[CompilerGenerated]
		private sealed class #ij
		{
			// Token: 0x060002FA RID: 762 RVA: 0x00012A84 File Offset: 0x00011A84
			internal bool #D5c(#B5c #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x0400014C RID: 332
			public string #5n;
		}

		// Token: 0x02000042 RID: 66
		[CompilerGenerated]
		private sealed class #nj
		{
			// Token: 0x060002FC RID: 764 RVA: 0x00012AA8 File Offset: 0x00011AA8
			internal bool #E5c(#B5c #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x0400014D RID: 333
			public string #5n;
		}
	}
}
