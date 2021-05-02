using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x0200004A RID: 74
	public interface ISchemaObjectWithOwnerCollection<T> : CodeSmith.Core.Collections.INamedObjectCollection<T>, IObservableList<T>, IEnumerable, IList<T>, ICollection<T>, IEnumerable<T>, ISchemaObjectCollection<T>, INotifyCollectionChanged, INotifyPropertyChanged where T : ISchemaObjectWithOwner
	{
		// Token: 0x170000CD RID: 205
		T this[string owner, string name]
		{
			get;
		}

		// Token: 0x06000319 RID: 793
		bool Contains(string owner, string name);

		// Token: 0x0600031A RID: 794
		int IndexOf(string owner, string name);
	}
}
