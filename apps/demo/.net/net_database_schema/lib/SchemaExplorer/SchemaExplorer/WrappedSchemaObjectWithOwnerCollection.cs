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
	// Token: 0x02000045 RID: 69
	[Serializable]
	public class WrappedSchemaObjectWithOwnerCollection<TBase, TActual> : WrappedSchemaObjectCollection<TBase, TActual>, CodeSmith.Core.Collections.INamedObjectCollection<TBase>, IObservableList<TBase>, IEnumerable, IList<TBase>, ICollection<TBase>, IEnumerable<TBase>, ISchemaObjectCollection<TBase>, ISchemaObjectWithOwnerCollection<TBase>, INotifyCollectionChanged, INotifyPropertyChanged where TBase : class, ISchemaObjectWithOwner where TActual : class, ISchemaObjectWithOwner, TBase
	{
		// Token: 0x0600030B RID: 779 RVA: 0x00012AC4 File Offset: 0x00011AC4
		public WrappedSchemaObjectWithOwnerCollection() : this(null)
		{
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00012AD0 File Offset: 0x00011AD0
		public WrappedSchemaObjectWithOwnerCollection(IEnumerable<TBase> data) : this((data == null) ? null : data.Cast<TActual>())
		{
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00012AE4 File Offset: 0x00011AE4
		public WrappedSchemaObjectWithOwnerCollection(IEnumerable<TActual> data) : base(data)
		{
		}

		// Token: 0x170000CB RID: 203
		public TBase this[string owner, string name]
		{
			get
			{
				WrappedSchemaObjectWithOwnerCollection<TBase, TActual>.#fj #fj = new WrappedSchemaObjectWithOwnerCollection<TBase, TActual>.#fj();
				#fj.#5n = name;
				#fj.#iV = owner;
				if (string.IsNullOrWhiteSpace(#fj.#iV))
				{
					return this[#fj.#5n];
				}
				return this.FirstOrDefault(new Func<TBase, bool>(#fj.#A5c));
			}
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00012B40 File Offset: 0x00011B40
		public bool Contains(string owner, string name)
		{
			WrappedSchemaObjectWithOwnerCollection<TBase, TActual>.#ij #ij = new WrappedSchemaObjectWithOwnerCollection<TBase, TActual>.#ij();
			#ij.#5n = name;
			#ij.#iV = owner;
			if (string.IsNullOrWhiteSpace(#ij.#iV))
			{
				return base.Contains(#ij.#5n);
			}
			return this.Any(new Func<TBase, bool>(#ij.#D5c));
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00012B90 File Offset: 0x00011B90
		public int IndexOf(string owner, string name)
		{
			WrappedSchemaObjectWithOwnerCollection<TBase, TActual>.#nj #nj = new WrappedSchemaObjectWithOwnerCollection<TBase, TActual>.#nj();
			#nj.#5n = name;
			#nj.#iV = owner;
			if (string.IsNullOrWhiteSpace(#nj.#iV))
			{
				return base.IndexOf(#nj.#5n);
			}
			return base.FindIndex(new Predicate<TBase>(#nj.#E5c));
		}

		// Token: 0x02000046 RID: 70
		[CompilerGenerated]
		private sealed class #fj
		{
			// Token: 0x06000312 RID: 786 RVA: 0x00012BE8 File Offset: 0x00011BE8
			internal bool #A5c(#B5c #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase) && #ln.Owner.Equals(this.#iV, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x0400014E RID: 334
			public string #5n;

			// Token: 0x0400014F RID: 335
			public string #iV;
		}

		// Token: 0x02000047 RID: 71
		[CompilerGenerated]
		private sealed class #ij
		{
			// Token: 0x06000314 RID: 788 RVA: 0x00012C24 File Offset: 0x00011C24
			internal bool #D5c(#B5c #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase) && #ln.Owner.Equals(this.#iV, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000150 RID: 336
			public string #5n;

			// Token: 0x04000151 RID: 337
			public string #iV;
		}

		// Token: 0x02000048 RID: 72
		[CompilerGenerated]
		private sealed class #nj
		{
			// Token: 0x06000316 RID: 790 RVA: 0x00012C60 File Offset: 0x00011C60
			internal bool #E5c(#B5c #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase) && #ln.Owner.Equals(this.#iV, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000152 RID: 338
			public string #5n;

			// Token: 0x04000153 RID: 339
			public string #iV;
		}
	}
}
