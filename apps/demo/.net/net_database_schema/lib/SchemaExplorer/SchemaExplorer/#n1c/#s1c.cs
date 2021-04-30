using System;
using System.Collections.Generic;
using CodeSmith.Engine;

namespace #n1c
{
	// Token: 0x020000A6 RID: 166
	internal sealed class #s1c
	{
		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060005AB RID: 1451 RVA: 0x000180D4 File Offset: 0x000170D4
		public static #s1c Instance
		{
			get
			{
				if (#s1c.#vr == null)
				{
					object obj = #s1c.#Ifc;
					lock (obj)
					{
						#s1c.#vr = new #s1c();
					}
				}
				return #s1c.#vr;
			}
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x00018124 File Offset: 0x00017124
		public #s1c()
		{
			ProjectCodeGenerator.GenerateEnd += this.#o1c;
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x00018148 File Offset: 0x00017148
		private void #o1c(object #sm, GenerateEndEventArgs #tm)
		{
			if (!ProjectCodeGenerator.IsGenerating)
			{
				this.#ppc();
			}
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x00018158 File Offset: 0x00017158
		public void #p1c(string #9q, object #Nx)
		{
			if (ProjectCodeGenerator.IsGenerating)
			{
				this.#Zn[#9q] = #Nx;
			}
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00018170 File Offset: 0x00017170
		public object #q1c(string #9q)
		{
			if (ProjectCodeGenerator.IsGenerating && this.#Zn.ContainsKey(#9q))
			{
				return this.#Zn[#9q];
			}
			return null;
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x00018198 File Offset: 0x00017198
		public bool #r1c(string #9q)
		{
			return ProjectCodeGenerator.IsGenerating && this.#Zn.ContainsKey(#9q);
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x000181B0 File Offset: 0x000171B0
		public void #ppc()
		{
			this.#Zn.Clear();
		}

		// Token: 0x04000225 RID: 549
		private static #s1c #vr;

		// Token: 0x04000226 RID: 550
		private static readonly object #Ifc = new object();

		// Token: 0x04000227 RID: 551
		private readonly Dictionary<string, object> #Zn = new Dictionary<string, object>();
	}
}
