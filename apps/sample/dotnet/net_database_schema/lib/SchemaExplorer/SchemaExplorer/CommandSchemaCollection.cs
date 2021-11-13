using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;

namespace SchemaExplorer
{
	// Token: 0x02000080 RID: 128
	[Serializable]
	public class CommandSchemaCollection : SchemaObjectWithOwnerCollection<CommandSchema>
	{
		// Token: 0x0600049D RID: 1181 RVA: 0x000156F8 File Offset: 0x000146F8
		public CommandSchemaCollection()
		{
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00015700 File Offset: 0x00014700
		public CommandSchemaCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0001570C File Offset: 0x0001470C
		public CommandSchemaCollection(IEnumerable<CommandSchema> collection) : base(collection)
		{
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00015718 File Offset: 0x00014718
		// Note: this type is marked as 'beforefieldinit'.
		static CommandSchemaCollection()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (CommandSchemaCollection.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x060004A1 RID: 1185
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
