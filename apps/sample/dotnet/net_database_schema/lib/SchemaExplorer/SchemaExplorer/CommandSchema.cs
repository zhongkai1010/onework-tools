using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x0200007E RID: 126
	[Serializable]
	public class CommandSchema : SchemaObjectWithOwnerBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject, ISchemaObjectWithOwner, ICommandSchema
	{
		// Token: 0x06000477 RID: 1143 RVA: 0x0001519C File Offset: 0x0001419C
		public CommandSchema(DatabaseSchema database, string name, string owner, DateTime dateCreated) : base(database, name, owner, dateCreated)
		{
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x000151B4 File Offset: 0x000141B4
		public CommandSchema(DatabaseSchema database, string name, string owner, DateTime dateCreated, ExtendedProperty[] extendedProperties) : base(database, name, owner, dateCreated, extendedProperties)
		{
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x000151D0 File Offset: 0x000141D0
		public override void Refresh()
		{
			base.Refresh();
			this._commandText = string.Empty;
			this._parameters = null;
			this._commandResultSchemas = null;
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x000151F4 File Offset: 0x000141F4
		// (set) Token: 0x0600047B RID: 1147 RVA: 0x00015204 File Offset: 0x00014204
		[Browsable(false)]
		public ParameterSchemaCollection Parameters
		{
			get
			{
				this.#m0c();
				return this._parameters;
			}
			set
			{
				this._parameters = value;
				this._parameters.CollectionChanged += this.#n0c;
				this.#o0c();
			}
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0001522C File Offset: 0x0001422C
		private void #m0c()
		{
			if (this._parameters != null)
			{
				return;
			}
			this.Database.#T0c();
			this._parameters = new ParameterSchemaCollection(this.Database.Provider.GetCommandParameters(this.Database.ConnectionString, this));
			this.#o0c();
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0001527C File Offset: 0x0001427C
		private void #n0c(object #sm, NotifyCollectionChangedEventArgs #tm)
		{
			this.#o0c();
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00015284 File Offset: 0x00014284
		private void #o0c()
		{
			this._inputParameters = null;
			this._outputParameters = null;
			this._inputOutputParameters = null;
			this._allInputParameters = null;
			this._allOutputParameters = null;
			this._nonReturnValueParameters = null;
			this._returnValueParameter = null;
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x0600047F RID: 1151 RVA: 0x000152B8 File Offset: 0x000142B8
		[Browsable(false)]
		public CommandResultSchemaCollection CommandResults
		{
			get
			{
				this.#p0c();
				return this._commandResultSchemas;
			}
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x000152C8 File Offset: 0x000142C8
		private void #p0c()
		{
			if (this._commandResultSchemas != null)
			{
				return;
			}
			this.Database.#T0c();
			this._commandResultSchemas = new CommandResultSchemaCollection(this.Database.Provider.GetCommandResultSchemas(this.Database.ConnectionString, this));
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x00015308 File Offset: 0x00014308
		[Browsable(false)]
		public ParameterSchemaCollection InputParameters
		{
			get
			{
				this.#m0c();
				if (this._inputParameters == null)
				{
					this._inputParameters = new ParameterSchemaCollection(this._parameters.Where(new Func<ParameterSchema, bool>(CommandSchema.<>c.<>9.#S5c)).ToList<ParameterSchema>());
				}
				return this._inputParameters;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x00015364 File Offset: 0x00014364
		[Browsable(false)]
		public ParameterSchemaCollection OutputParameters
		{
			get
			{
				this.#m0c();
				if (this._outputParameters == null)
				{
					this._outputParameters = new ParameterSchemaCollection(this._parameters.Where(new Func<ParameterSchema, bool>(CommandSchema.<>c.<>9.#T5c)).ToList<ParameterSchema>());
				}
				return this._outputParameters;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x000153C0 File Offset: 0x000143C0
		[Browsable(false)]
		public ParameterSchemaCollection InputOutputParameters
		{
			get
			{
				this.#m0c();
				if (this._inputOutputParameters == null)
				{
					this._inputOutputParameters = new ParameterSchemaCollection(this._parameters.Where(new Func<ParameterSchema, bool>(CommandSchema.<>c.<>9.#U5c)).ToList<ParameterSchema>());
				}
				return this._inputOutputParameters;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x0001541C File Offset: 0x0001441C
		[Browsable(false)]
		public ParameterSchemaCollection AllInputParameters
		{
			get
			{
				this.#m0c();
				if (this._allInputParameters == null)
				{
					this._allInputParameters = new ParameterSchemaCollection(this._parameters.Where(new Func<ParameterSchema, bool>(CommandSchema.<>c.<>9.#V5c)).ToList<ParameterSchema>());
				}
				return this._allInputParameters;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x00015478 File Offset: 0x00014478
		[Browsable(false)]
		public ParameterSchemaCollection AllOutputParameters
		{
			get
			{
				this.#m0c();
				if (this._allOutputParameters == null)
				{
					this._allOutputParameters = new ParameterSchemaCollection(this._parameters.Where(new Func<ParameterSchema, bool>(CommandSchema.<>c.<>9.#W5c)).ToList<ParameterSchema>());
				}
				return this._allOutputParameters;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x000154D4 File Offset: 0x000144D4
		[Browsable(false)]
		public ParameterSchemaCollection NonReturnValueParameters
		{
			get
			{
				this.#m0c();
				if (this._nonReturnValueParameters == null)
				{
					this._nonReturnValueParameters = new ParameterSchemaCollection(this._parameters.Where(new Func<ParameterSchema, bool>(CommandSchema.<>c.<>9.#X5c)).ToList<ParameterSchema>());
				}
				return this._nonReturnValueParameters;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x00015530 File Offset: 0x00014530
		[Browsable(false)]
		public ParameterSchema ReturnValueParameter
		{
			get
			{
				this.#m0c();
				if (this._returnValueParameter == null)
				{
					this._returnValueParameter = this._parameters.FirstOrDefault(new Func<ParameterSchema, bool>(CommandSchema.<>c.<>9.#Y5c));
				}
				return this._returnValueParameter;
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000488 RID: 1160 RVA: 0x00015584 File Offset: 0x00014584
		[Browsable(false)]
		public string CommandText
		{
			get
			{
				if (this._commandText == string.Empty)
				{
					this.Database.#T0c();
					this._commandText = this.Database.Provider.GetCommandText(this.Database.ConnectionString, this);
				}
				return this._commandText;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x000155D8 File Offset: 0x000145D8
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IParameterSchema> ICommandSchema.Parameters
		{
			get
			{
				return this.Parameters;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x0600048A RID: 1162 RVA: 0x000155E0 File Offset: 0x000145E0
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<ICommandResultSchema> ICommandSchema.CommandResults
		{
			get
			{
				return this.CommandResults;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x000155E8 File Offset: 0x000145E8
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IParameterSchema> ICommandSchema.InputParameters
		{
			get
			{
				return this.InputParameters;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x000155F0 File Offset: 0x000145F0
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IParameterSchema> ICommandSchema.OutputParameters
		{
			get
			{
				return this.OutputParameters;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x000155F8 File Offset: 0x000145F8
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IParameterSchema> ICommandSchema.InputOutputParameters
		{
			get
			{
				return this.InputOutputParameters;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x0600048E RID: 1166 RVA: 0x00015600 File Offset: 0x00014600
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IParameterSchema> ICommandSchema.AllInputParameters
		{
			get
			{
				return this.AllInputParameters;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x00015608 File Offset: 0x00014608
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IParameterSchema> ICommandSchema.AllOutputParameters
		{
			get
			{
				return this.AllOutputParameters;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000490 RID: 1168 RVA: 0x00015610 File Offset: 0x00014610
		CodeSmith.Core.Collections.IReadOnlyNamedObjectCollection<IParameterSchema> ICommandSchema.NonReturnValueParameters
		{
			get
			{
				return this.NonReturnValueParameters;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x00015618 File Offset: 0x00014618
		IParameterSchema ICommandSchema.ReturnValueParameter
		{
			get
			{
				return this.ReturnValueParameter;
			}
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x00015620 File Offset: 0x00014620
		// Note: this type is marked as 'beforefieldinit'.
		static CommandSchema()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (CommandSchema.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000493 RID: 1171
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x0400019C RID: 412
		private string _commandText = string.Empty;

		// Token: 0x0400019D RID: 413
		private ParameterSchemaCollection _parameters;

		// Token: 0x0400019E RID: 414
		private CommandResultSchemaCollection _commandResultSchemas;

		// Token: 0x0400019F RID: 415
		private ParameterSchema _returnValueParameter;

		// Token: 0x040001A0 RID: 416
		private ParameterSchemaCollection _nonReturnValueParameters;

		// Token: 0x040001A1 RID: 417
		private ParameterSchemaCollection _inputParameters;

		// Token: 0x040001A2 RID: 418
		private ParameterSchemaCollection _outputParameters;

		// Token: 0x040001A3 RID: 419
		private ParameterSchemaCollection _inputOutputParameters;

		// Token: 0x040001A4 RID: 420
		private ParameterSchemaCollection _allOutputParameters;

		// Token: 0x040001A5 RID: 421
		private ParameterSchemaCollection _allInputParameters;
	}
}
