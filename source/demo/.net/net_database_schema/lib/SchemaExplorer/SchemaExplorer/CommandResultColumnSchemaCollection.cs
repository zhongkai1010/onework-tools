using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;

namespace SchemaExplorer
{
	// Token: 0x02000079 RID: 121
	[Serializable]
	public class CommandResultColumnSchemaCollection : DataObjectBaseCollection<CommandResultColumnSchema>
	{
		// Token: 0x0600045C RID: 1116 RVA: 0x00015058 File Offset: 0x00014058
		public CommandResultColumnSchemaCollection()
		{
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00015060 File Offset: 0x00014060
		public CommandResultColumnSchemaCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0001506C File Offset: 0x0001406C
		public CommandResultColumnSchemaCollection(IEnumerable<CommandResultColumnSchema> collection) : base(collection)
		{
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00015078 File Offset: 0x00014078
		// Note: this type is marked as 'beforefieldinit'.
		static CommandResultColumnSchemaCollection()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (CommandResultColumnSchemaCollection.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000460 RID: 1120
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
