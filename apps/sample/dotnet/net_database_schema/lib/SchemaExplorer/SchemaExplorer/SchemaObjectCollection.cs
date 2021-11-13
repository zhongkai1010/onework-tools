using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using #Nk;
using ActiproSoftware.Windows.Controls.PropertyGrid.Editors;
using CodeSmith.Core.Collections;
using CodeSmith.Engine;
using CodeSmith.Engine.Json;
using SchemaExplorer.Design;
using SchemaExplorer.Serialization;
using SchemaExplorer.TypeConverters;

namespace SchemaExplorer
{
	// Token: 0x0200004C RID: 76
	[JsonConverter(typeof(DatabaseSchemaSerializer))]
	[PropertyRefresher(typeof(MethodPropertyRefresher))]
	[PropertySerializer(typeof(SchemaObjectFactorySerializer))]
	[TypeConverter(typeof(SchemaObjectFactoryTypeConverter))]
	[Editor(typeof(SchemaObjectEditor), typeof(PropertyEditor))]
	[Serializable]
	public class SchemaObjectCollection<T> : CodeSmith.Core.Collections.NamedObjectCollection<T>, CodeSmith.Core.Collections.INamedObjectCollection<T>, IObservableList<T>, IEnumerable, IList<T>, ICollection<T>, IEnumerable<T>, ISchemaObjectCollection<T>, CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<T>, CodeSmith.Core.Collections.IReadOnlyCollection<T>, INotifyCollectionChanged, IReadOnlySchemaObjectCollection<T>, INotifyPropertyChanged where T : ISchemaObject
	{
		// Token: 0x06000320 RID: 800 RVA: 0x00012D08 File Offset: 0x00011D08
		public SchemaObjectCollection()
		{
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00012D10 File Offset: 0x00011D10
		public SchemaObjectCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00012D1C File Offset: 0x00011D1C
		public SchemaObjectCollection(IEnumerable<T> collection) : base(collection)
		{
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00012D28 File Offset: 0x00011D28
		public object Clone()
		{
			Type type = base.GetType();
			IList<T> list = Activator.CreateInstance(type) as IList<T>;
			if (list == null)
			{
				return null;
			}
			foreach (T item in this)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00012D8C File Offset: 0x00011D8C
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

		// Token: 0x06000325 RID: 805 RVA: 0x00012DE8 File Offset: 0x00011DE8
		public void Refresh()
		{
			foreach (T t in this)
			{
				t.Refresh();
			}
		}
	}
}
