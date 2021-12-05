using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;

namespace SchemaExplorer
{
	// Token: 0x0200004B RID: 75
	[Serializable]
	public class SchemaObjectBaseCollection : SchemaObjectCollection<ISchemaObject>
	{
		// Token: 0x0600031B RID: 795 RVA: 0x00012C94 File Offset: 0x00011C94
		public SchemaObjectBaseCollection()
		{
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00012C9C File Offset: 0x00011C9C
		public SchemaObjectBaseCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00012CA8 File Offset: 0x00011CA8
		public SchemaObjectBaseCollection(IEnumerable<ISchemaObject> collection) : base(collection)
		{
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00012CB4 File Offset: 0x00011CB4
		// Note: this type is marked as 'beforefieldinit'.
		static SchemaObjectBaseCollection()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (SchemaObjectBaseCollection.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x0600031F RID: 799
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
