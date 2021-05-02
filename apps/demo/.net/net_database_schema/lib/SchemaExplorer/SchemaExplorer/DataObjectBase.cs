using System;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x02000064 RID: 100
	[Serializable]
	public abstract class DataObjectBase : SchemaObjectBase, CodeSmith.Core.Collections.INamedObject, ISchemaObject, IDataObject
	{
		// Token: 0x060003D0 RID: 976 RVA: 0x00013EBC File Offset: 0x00012EBC
		internal DataObjectBase()
		{
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00013ED0 File Offset: 0x00012ED0
		[Obsolete("Please use the constructors that contain the allowDBNull parameter.", false)]
		public DataObjectBase(ISchemaObject parent, string name, DbType dataType, string nativeType, int size, byte precision, int scale) : base(parent.Database as DatabaseSchema, name)
		{
			this._parent = parent;
			this._name = name;
			this._dataType = dataType;
			this._nativeType = nativeType;
			this._size = size;
			this._precision = precision;
			this._scale = scale;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00013F30 File Offset: 0x00012F30
		public DataObjectBase(ISchemaObject parent, string name, DbType dataType, string nativeType, int size, byte precision, int scale, bool allowDBNull) : this(parent, name, dataType, nativeType, size, precision, scale)
		{
			this._allowDBNull = allowDBNull;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00013F4C File Offset: 0x00012F4C
		[Obsolete("Please use the constructors that contain the allowDBNull parameter.", false)]
		public DataObjectBase(ISchemaObject parent, string name, DbType dataType, string nativeType, int size, byte precision, int scale, ExtendedProperty[] extendedProperties) : this(parent, name, dataType, nativeType, size, precision, scale)
		{
			this._defaultExtendedProperties = (extendedProperties ?? new ExtendedProperty[0]);
			this._extendedProperties = new ExtendedPropertyCollection(extendedProperties);
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00013F80 File Offset: 0x00012F80
		public DataObjectBase(ISchemaObject parent, string name, DbType dataType, string nativeType, int size, byte precision, int scale, bool allowDBNull, ExtendedProperty[] extendedProperties) : this(parent, name, dataType, nativeType, size, precision, scale, allowDBNull)
		{
			this._defaultExtendedProperties = (extendedProperties ?? new ExtendedProperty[0]);
			this._extendedProperties = new ExtendedPropertyCollection(extendedProperties);
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x00013FC0 File Offset: 0x00012FC0
		public virtual DbType DataType
		{
			get
			{
				return this._dataType;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x00013FC8 File Offset: 0x00012FC8
		public virtual Type SystemType
		{
			get
			{
				return SchemaUtility.GetSystemType(this.DataType);
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x00013FD8 File Offset: 0x00012FD8
		public virtual ISchemaObject Parent
		{
			get
			{
				return this._parent;
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x00013FE0 File Offset: 0x00012FE0
		public virtual string NativeType
		{
			get
			{
				return this._nativeType;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x00013FE8 File Offset: 0x00012FE8
		public virtual int Size
		{
			get
			{
				return this._size;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060003DA RID: 986 RVA: 0x00013FF0 File Offset: 0x00012FF0
		public virtual byte Precision
		{
			get
			{
				return this._precision;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060003DB RID: 987 RVA: 0x00013FF8 File Offset: 0x00012FF8
		public virtual int Scale
		{
			get
			{
				return this._scale;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060003DC RID: 988 RVA: 0x00014000 File Offset: 0x00013000
		public virtual bool AllowDBNull
		{
			get
			{
				return this._allowDBNull;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060003DD RID: 989 RVA: 0x00014008 File Offset: 0x00013008
		public override string FullName
		{
			get
			{
				return string.Format(#Mk.#Lk(12145), this.Parent, this.Name);
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060003DE RID: 990 RVA: 0x00014028 File Offset: 0x00013028
		public override string SortName
		{
			get
			{
				return string.Format(#Mk.#Lk(8266), this.Name, this.Parent);
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00014048 File Offset: 0x00013048
		public override string ToString()
		{
			return this.FullName;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00014050 File Offset: 0x00013050
		public override void Refresh()
		{
			base.Refresh();
			this.Parent.Refresh();
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00014064 File Offset: 0x00013064
		public override bool Equals(object obj)
		{
			DataObjectBase dataObjectBase = obj as DataObjectBase;
			return dataObjectBase != null && dataObjectBase.GetHashCode() == this.GetHashCode();
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0001408C File Offset: 0x0001308C
		public override int GetHashCode()
		{
			return this.Parent.GetHashCode() ^ this.Name.GetHashCode();
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x000140A8 File Offset: 0x000130A8
		// Note: this type is marked as 'beforefieldinit'.
		static DataObjectBase()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (DataObjectBase.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x060003E4 RID: 996
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x04000171 RID: 369
		protected DbType _dataType;

		// Token: 0x04000172 RID: 370
		protected string _nativeType = string.Empty;

		// Token: 0x04000173 RID: 371
		protected int _size;

		// Token: 0x04000174 RID: 372
		protected byte _precision;

		// Token: 0x04000175 RID: 373
		protected int _scale;

		// Token: 0x04000176 RID: 374
		protected bool _allowDBNull;

		// Token: 0x04000177 RID: 375
		protected ISchemaObject _parent;
	}
}
