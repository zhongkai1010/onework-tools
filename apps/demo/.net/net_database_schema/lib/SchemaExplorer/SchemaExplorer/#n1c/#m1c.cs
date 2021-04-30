using System;
using #Nk;

namespace #n1c
{
	// Token: 0x020000A5 RID: 165
	internal sealed class #m1c
	{
		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060005A8 RID: 1448 RVA: 0x00017FD4 File Offset: 0x00016FD4
		public static string[] HashCodes
		{
			get
			{
				if (#m1c.#j1c == null)
				{
					#m1c.#j1c = new string[]
					{
						#Mk.#Lk(12750),
						#Mk.#Lk(12783),
						#Mk.#Lk(12816),
						#Mk.#Lk(12849),
						#Mk.#Lk(12882),
						#Mk.#Lk(12915),
						#Mk.#Lk(12948),
						#Mk.#Lk(12981),
						#Mk.#Lk(13014),
						#Mk.#Lk(13047),
						#Mk.#Lk(13080),
						#Mk.#Lk(13113),
						#Mk.#Lk(13146)
					};
				}
				return #m1c.#j1c;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060005A9 RID: 1449 RVA: 0x000180AC File Offset: 0x000170AC
		public static string Names
		{
			get
			{
				if (#m1c.#k1c == null)
				{
					#m1c.#k1c = #Mk.#Lk(13179);
				}
				return #m1c.#k1c;
			}
		}

		// Token: 0x04000223 RID: 547
		private static string[] #j1c;

		// Token: 0x04000224 RID: 548
		private static string #k1c;
	}
}
