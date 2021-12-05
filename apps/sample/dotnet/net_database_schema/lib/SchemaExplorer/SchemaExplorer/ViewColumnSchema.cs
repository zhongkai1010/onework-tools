using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x020000B2 RID: 178
	[Serializable]
	public class ViewColumnSchema : DataObjectBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject, IDataObject, IViewColumnSchema
	{
		// Token: 0x06000616 RID: 1558 RVA: 0x00019038 File Offset: 0x00018038
		internal ViewColumnSchema()
		{
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x00019040 File Offset: 0x00018040
		[Obsolete("Please use the constructors that contain the allowDBNull parameter.", false)]
		public ViewColumnSchema(ViewSchema view, string name, DbType dataType, string nativeType, int size, byte precision, int scale) : base(view, name, dataType, nativeType, size, precision, scale)
		{
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x00019054 File Offset: 0x00018054
		public ViewColumnSchema(ViewSchema view, string name, DbType dataType, string nativeType, int size, byte precision, int scale, bool allowDBNull) : base(view, name, dataType, nativeType, size, precision, scale, allowDBNull)
		{
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x00019074 File Offset: 0x00018074
		[Obsolete("Please use the constructors that contain the allowDBNull parameter.", false)]
		public ViewColumnSchema(ViewSchema view, string name, DbType dataType, string nativeType, int size, byte precision, int scale, ExtendedProperty[] extendedProperties) : base(view, name, dataType, nativeType, size, precision, scale, extendedProperties)
		{
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x00019094 File Offset: 0x00018094
		public ViewColumnSchema(ViewSchema view, string name, DbType dataType, string nativeType, int size, byte precision, int scale, bool allowDBNull, ExtendedProperty[] extendedProperties) : base(view, name, dataType, nativeType, size, precision, scale, allowDBNull, extendedProperties)
		{
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x0600061B RID: 1563 RVA: 0x000190B8 File Offset: 0x000180B8
		[Browsable(false)]
		public virtual ViewSchema View
		{
			get
			{
				return this._parent as ViewSchema;
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x0600061C RID: 1564 RVA: 0x000190C8 File Offset: 0x000180C8
		IViewSchema IViewColumnSchema.View
		{
			get
			{
				return this._parent as IViewSchema;
			}
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x000190D8 File Offset: 0x000180D8
		// Note: this type is marked as 'beforefieldinit'.
		static ViewColumnSchema()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (ViewColumnSchema.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x0600061E RID: 1566
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
