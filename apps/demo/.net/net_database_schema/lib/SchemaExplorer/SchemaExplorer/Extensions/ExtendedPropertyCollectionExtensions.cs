using System;
using CodeSmith.Core.Collections;
using CodeSmith.Core.Helpers;

namespace SchemaExplorer.Extensions
{
	// Token: 0x020000C3 RID: 195
	public static class ExtendedPropertyCollectionExtensions
	{
		// Token: 0x06000695 RID: 1685 RVA: 0x0001B0DC File Offset: 0x0001A0DC
		public static object GetByKey(this CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IExtendedProperty> collection, string key)
		{
			if (string.IsNullOrEmpty(key) || collection == null || !collection.Contains(key))
			{
				return null;
			}
			return collection[key].Value;
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0001B100 File Offset: 0x0001A100
		public static T GetByKey<T>(this CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IExtendedProperty> collection, string key)
		{
			if (string.IsNullOrEmpty(key) || collection == null || !collection.Contains(key))
			{
				return default(T);
			}
			try
			{
				return TypeHelper.ChangeType<T>(collection[key].Value);
			}
			catch (Exception)
			{
			}
			return default(T);
		}
	}
}
