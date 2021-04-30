using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;

namespace CodeSmith.Core.Collections
{
	// Token: 0x02000056 RID: 86
	[Serializable]
	public abstract class NamedObjectBase : INamedObject
	{
		// Token: 0x0600035F RID: 863 RVA: 0x00013520 File Offset: 0x00012520
		public NamedObjectBase()
		{
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00013534 File Offset: 0x00012534
		public NamedObjectBase(string name)
		{
			this._name = name;
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000361 RID: 865 RVA: 0x00013550 File Offset: 0x00012550
		[Description("The Name of the object.")]
		public virtual string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00013558 File Offset: 0x00012558
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00013560 File Offset: 0x00012560
		// Note: this type is marked as 'beforefieldinit'.
		static NamedObjectBase()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (NamedObjectBase.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000364 RID: 868
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x04000160 RID: 352
		protected string _name = string.Empty;
	}
}
