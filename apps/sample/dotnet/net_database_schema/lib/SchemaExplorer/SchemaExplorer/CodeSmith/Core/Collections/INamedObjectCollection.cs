using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CodeSmith.Core.Collections
{
	// Token: 0x0200003E RID: 62
	public interface INamedObjectCollection<T> : IObservableList<T>, IEnumerable, IList<T>, ICollection<T>, IEnumerable<T>, INotifyCollectionChanged, INotifyPropertyChanged where T : INamedObject
	{
		// Token: 0x170000C0 RID: 192
		T this[string name]
		{
			get;
		}

		// Token: 0x060002EC RID: 748
		bool Contains(string name);

		// Token: 0x060002ED RID: 749
		int IndexOf(string name);
	}
}
