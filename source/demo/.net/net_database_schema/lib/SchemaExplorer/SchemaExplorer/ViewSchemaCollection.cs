using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;

namespace SchemaExplorer
{
	// Token: 0x020000B6 RID: 182
	[Serializable]
	public class ViewSchemaCollection : SchemaObjectWithOwnerCollection<ViewSchema>
	{
		// Token: 0x06000633 RID: 1587 RVA: 0x00019318 File Offset: 0x00018318
		public ViewSchemaCollection()
		{
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00019320 File Offset: 0x00018320
		public ViewSchemaCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0001932C File Offset: 0x0001832C
		public ViewSchemaCollection(IEnumerable<ViewSchema> collection) : base(collection)
		{
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x00019338 File Offset: 0x00018338
		// Note: this type is marked as 'beforefieldinit'.
		static ViewSchemaCollection()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (ViewSchemaCollection.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000637 RID: 1591
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
