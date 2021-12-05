using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;

namespace SchemaExplorer
{
	// Token: 0x020000B3 RID: 179
	[Serializable]
	public class ViewColumnSchemaCollection : DataObjectBaseCollection<ViewColumnSchema>
	{
		// Token: 0x0600061F RID: 1567 RVA: 0x0001912C File Offset: 0x0001812C
		public ViewColumnSchemaCollection()
		{
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00019134 File Offset: 0x00018134
		public ViewColumnSchemaCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00019140 File Offset: 0x00018140
		public ViewColumnSchemaCollection(IEnumerable<ViewColumnSchema> collection) : base(collection)
		{
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x0001914C File Offset: 0x0001814C
		// Note: this type is marked as 'beforefieldinit'.
		static ViewColumnSchemaCollection()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (ViewColumnSchemaCollection.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000623 RID: 1571
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
