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
	// Token: 0x0200009C RID: 156
	[Serializable]
	public class ParameterSchema : DataObjectBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject, IDataObject, IParameterSchema
	{
		// Token: 0x06000579 RID: 1401 RVA: 0x000178C8 File Offset: 0x000168C8
		public ParameterSchema(CommandSchema command, string name, ParameterDirection direction, DbType dataType, string nativeType, int size, byte precision, int scale, bool allowDbNull) : base(command, name, dataType, nativeType, size, precision, scale, allowDbNull)
		{
			this._direction = direction;
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x000178F0 File Offset: 0x000168F0
		public ParameterSchema(CommandSchema command, string name, ParameterDirection direction, DbType dataType, string nativeType, int size, byte precision, int scale, bool allowDbNull, ExtendedProperty[] extendedProperties) : base(command, name, dataType, nativeType, size, precision, scale, allowDbNull, extendedProperties)
		{
			this._direction = direction;
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x0001791C File Offset: 0x0001691C
		[Browsable(false)]
		public CommandSchema Command
		{
			get
			{
				return this._parent as CommandSchema;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x0600057C RID: 1404 RVA: 0x0001792C File Offset: 0x0001692C
		ICommandSchema IParameterSchema.Command
		{
			get
			{
				return this._parent as ICommandSchema;
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x0600057D RID: 1405 RVA: 0x0001793C File Offset: 0x0001693C
		public ParameterDirection Direction
		{
			get
			{
				return this._direction;
			}
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x00017944 File Offset: 0x00016944
		// Note: this type is marked as 'beforefieldinit'.
		static ParameterSchema()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (ParameterSchema.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x0600057F RID: 1407
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x040001DD RID: 477
		private readonly ParameterDirection _direction;
	}
}
