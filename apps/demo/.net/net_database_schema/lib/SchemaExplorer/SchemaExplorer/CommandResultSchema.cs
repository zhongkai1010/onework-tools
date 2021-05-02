using System;
using System.Collections.Generic;
using System.ComponentModel;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x0200007B RID: 123
	[Serializable]
	public class CommandResultSchema : TabularObjectBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject, ISchemaObjectWithOwner, ITabularObject, ICommandResultSchema
	{
		// Token: 0x06000463 RID: 1123 RVA: 0x000150CC File Offset: 0x000140CC
		public CommandResultSchema(CommandSchema command, string name, IEnumerable<CommandResultColumnSchema> columns) : base(command.Database, name, command.Owner)
		{
			this._command = command;
			this._columns = new CommandResultColumnSchemaCollection(columns);
			this._dataObjects = this._columns;
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00015100 File Offset: 0x00014100
		public CommandResultSchema(CommandSchema command, string name, IEnumerable<CommandResultColumnSchema> columns, ExtendedProperty[] extendedProperties) : base(command.Database, name, command.Owner, extendedProperties)
		{
			this._command = command;
			this._columns = new CommandResultColumnSchemaCollection(columns);
			this._dataObjects = this._columns;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00015138 File Offset: 0x00014138
		public override void Refresh()
		{
			base.Refresh();
			this.Command.Refresh();
			this._extendedProperties = new ExtendedPropertyCollection(this._defaultExtendedProperties);
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000466 RID: 1126 RVA: 0x0001515C File Offset: 0x0001415C
		[Browsable(false)]
		public CommandSchema Command
		{
			get
			{
				return this._command;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000467 RID: 1127 RVA: 0x00015164 File Offset: 0x00014164
		ICommandSchema ICommandResultSchema.Command
		{
			get
			{
				return this._command;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000468 RID: 1128 RVA: 0x0001516C File Offset: 0x0001416C
		[Browsable(false)]
		public CommandResultColumnSchemaCollection Columns
		{
			get
			{
				return this._columns;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x00015174 File Offset: 0x00014174
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<ICommandResultColumnSchema> ICommandResultSchema.Columns
		{
			get
			{
				return this.Columns;
			}
		}

		// Token: 0x0400019A RID: 410
		private readonly CommandSchema _command;

		// Token: 0x0400019B RID: 411
		private readonly CommandResultColumnSchemaCollection _columns;
	}
}
