using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;
using CodeSmith.Core.Collections;
using CodeSmith.Core.Extensions;

namespace SchemaExplorer
{
	// Token: 0x02000091 RID: 145
	[Serializable]
	public class IDbSchemaProviderCollection : CodeSmith.Core.Collections.NamedObjectCollection<IDbSchemaProvider>
	{
		// Token: 0x0600052A RID: 1322 RVA: 0x00017254 File Offset: 0x00016254
		public IDbSchemaProviderCollection()
		{
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0001725C File Offset: 0x0001625C
		public IDbSchemaProviderCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00017268 File Offset: 0x00016268
		public IDbSchemaProviderCollection(IEnumerable<IDbSchemaProvider> collection) : base(collection)
		{
		}

		// Token: 0x17000164 RID: 356
		public new IDbSchemaProvider this[string name]
		{
			get
			{
				IDbSchemaProviderCollection.#fj #fj = new IDbSchemaProviderCollection.#fj();
				#fj.#5n = name;
				return this.FirstOrDefault(new Func<IDbSchemaProvider, bool>(#fj.#A5c));
			}
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x000172A0 File Offset: 0x000162A0
		public new bool Contains(string name)
		{
			IDbSchemaProviderCollection.#ij #ij = new IDbSchemaProviderCollection.#ij();
			#ij.#5n = name;
			return this.Any(new Func<IDbSchemaProvider, bool>(#ij.#D5c));
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x000172CC File Offset: 0x000162CC
		public new int IndexOf(string name)
		{
			IDbSchemaProviderCollection.#nj #nj = new IDbSchemaProviderCollection.#nj();
			#nj.#5n = name;
			return this.IndexOf(new Func<IDbSchemaProvider, bool>(#nj.#E5c));
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x000172F8 File Offset: 0x000162F8
		public virtual object Clone()
		{
			return new IDbSchemaProviderCollection(this);
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x00017300 File Offset: 0x00016300
		// Note: this type is marked as 'beforefieldinit'.
		static IDbSchemaProviderCollection()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (IDbSchemaProviderCollection.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000532 RID: 1330
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x02000092 RID: 146
		[CompilerGenerated]
		private sealed class #fj
		{
			// Token: 0x06000534 RID: 1332 RVA: 0x0001735C File Offset: 0x0001635C
			internal bool #A5c(IDbSchemaProvider #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x040001D3 RID: 467
			public string #5n;
		}

		// Token: 0x02000093 RID: 147
		[CompilerGenerated]
		private sealed class #ij
		{
			// Token: 0x06000536 RID: 1334 RVA: 0x00017378 File Offset: 0x00016378
			internal bool #D5c(IDbSchemaProvider #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x040001D4 RID: 468
			public string #5n;
		}

		// Token: 0x02000094 RID: 148
		[CompilerGenerated]
		private sealed class #nj
		{
			// Token: 0x06000538 RID: 1336 RVA: 0x00017394 File Offset: 0x00016394
			internal bool #E5c(IDbSchemaProvider #ln)
			{
				return #ln.Name.Equals(this.#5n, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x040001D5 RID: 469
			public string #5n;
		}
	}
}
