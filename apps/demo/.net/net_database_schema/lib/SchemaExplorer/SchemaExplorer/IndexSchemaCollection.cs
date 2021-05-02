using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;

namespace SchemaExplorer
{
	// Token: 0x02000097 RID: 151
	[Serializable]
	public class IndexSchemaCollection : SchemaObjectCollection<IndexSchema>
	{
		// Token: 0x0600054D RID: 1357 RVA: 0x0001754C File Offset: 0x0001654C
		public IndexSchemaCollection()
		{
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x00017554 File Offset: 0x00016554
		public IndexSchemaCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x00017560 File Offset: 0x00016560
		public IndexSchemaCollection(IEnumerable<IndexSchema> collection) : base(collection)
		{
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0001756C File Offset: 0x0001656C
		// Note: this type is marked as 'beforefieldinit'.
		static IndexSchemaCollection()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (IndexSchemaCollection.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000551 RID: 1361
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
