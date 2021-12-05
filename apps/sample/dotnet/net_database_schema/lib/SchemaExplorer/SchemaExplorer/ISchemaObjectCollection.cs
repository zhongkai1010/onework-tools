using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000044 RID: 68
	public interface ISchemaObjectCollection<T> : CodeSmith.Core.Collections.INamedObjectCollection<T>, IObservableList<T>, IEnumerable, IList<T>, ICollection<T>, IEnumerable<T>, INotifyCollectionChanged, INotifyPropertyChanged where T : ISchemaObject
	{
		// Token: 0x0600030A RID: 778
		void Refresh();
	}
}
