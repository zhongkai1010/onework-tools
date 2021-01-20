using System;
using System.ComponentModel;
using System.Data;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000078 RID: 120
	[Serializable]
	public class CommandResultColumnSchema : DataObjectBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject, IDataObject, ICommandResultColumnSchema
	{
		// Token: 0x06000458 RID: 1112 RVA: 0x00014FF4 File Offset: 0x00013FF4
		public CommandResultColumnSchema(CommandSchema command, string name, DbType dataType, string nativeType, int size, byte precision, int scale, bool allowDBNull) : base(command, name, dataType, nativeType, size, precision, scale, allowDBNull)
		{
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00015014 File Offset: 0x00014014
		public CommandResultColumnSchema(CommandSchema command, string name, DbType dataType, string nativeType, int size, byte precision, int scale, bool allowDBNull, ExtendedProperty[] extendedProperties) : base(command, name, dataType, nativeType, size, precision, scale, allowDBNull, extendedProperties)
		{
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600045A RID: 1114 RVA: 0x00015038 File Offset: 0x00014038
		[Browsable(false)]
		public CommandSchema Command
		{
			get
			{
				return this._parent as CommandSchema;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x00015048 File Offset: 0x00014048
		ICommandSchema ICommandResultColumnSchema.Command
		{
			get
			{
				return this._parent as ICommandSchema;
			}
		}
	}
}
