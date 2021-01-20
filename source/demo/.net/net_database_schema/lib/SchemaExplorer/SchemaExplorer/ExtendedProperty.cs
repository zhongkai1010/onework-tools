using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;
using CodeSmith.Core.Collections;

namespace SchemaExplorer
{
	// Token: 0x0200008F RID: 143
	[DebuggerDisplay("Name {Name}, Value {Value}")]
	[Serializable]
	public class ExtendedProperty : INotifyPropertyChanged, CodeSmith.Core.Collections.INamedObject, IExtendedProperty
	{
		// Token: 0x06000513 RID: 1299 RVA: 0x00017038 File Offset: 0x00016038
		public ExtendedProperty()
		{
			this._propertyState = PropertyStateEnum.New;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00017048 File Offset: 0x00016048
		public ExtendedProperty(string name, object value, DbType dataType)
		{
			this._name = name;
			this._value = value;
			this._dataType = dataType;
			this._propertyState = PropertyStateEnum.Unmodified;
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0001706C File Offset: 0x0001606C
		public ExtendedProperty(string name, object value, DbType dataType, PropertyStateEnum state)
		{
			this._name = name;
			this._value = value;
			this._dataType = dataType;
			this._propertyState = state;
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000516 RID: 1302 RVA: 0x00017094 File Offset: 0x00016094
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000517 RID: 1303 RVA: 0x0001709C File Offset: 0x0001609C
		// (set) Token: 0x06000518 RID: 1304 RVA: 0x000170A4 File Offset: 0x000160A4
		public object Value
		{
			get
			{
				return this._value;
			}
			set
			{
				if (value != this._value)
				{
					this._value = value;
					this.OnPropertyChanged(#Mk.#Lk(12608));
				}
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000519 RID: 1305 RVA: 0x000170C8 File Offset: 0x000160C8
		public DbType DataType
		{
			get
			{
				return this._dataType;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x000170D0 File Offset: 0x000160D0
		// (set) Token: 0x0600051B RID: 1307 RVA: 0x000170D8 File Offset: 0x000160D8
		[Bindable(false)]
		public PropertyStateEnum PropertyState
		{
			get
			{
				return this._propertyState;
			}
			set
			{
				this._propertyState = value;
			}
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x000170E4 File Offset: 0x000160E4
		public static ExtendedProperty Readonly(string name, string value)
		{
			return new ExtendedProperty(name, value ?? string.Empty, DbType.AnsiString, PropertyStateEnum.ReadOnly);
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x000170F8 File Offset: 0x000160F8
		public static ExtendedProperty Readonly(string name, int value)
		{
			return new ExtendedProperty(name, value, DbType.Int32, PropertyStateEnum.ReadOnly);
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0001710C File Offset: 0x0001610C
		public static ExtendedProperty Readonly(string name, long value)
		{
			return new ExtendedProperty(name, value, DbType.Int64, PropertyStateEnum.ReadOnly);
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00017120 File Offset: 0x00016120
		public static ExtendedProperty Readonly(string name, bool value)
		{
			return new ExtendedProperty(name, value, DbType.Boolean, PropertyStateEnum.ReadOnly);
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00017130 File Offset: 0x00016130
		protected virtual void OnPropertyChanged(string propertyName)
		{
			this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00017140 File Offset: 0x00016140
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (this._propertyState == PropertyStateEnum.Unmodified)
			{
				this._propertyState = PropertyStateEnum.Dirty;
			}
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, e);
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000522 RID: 1314 RVA: 0x00017168 File Offset: 0x00016168
		// (remove) Token: 0x06000523 RID: 1315 RVA: 0x000171A0 File Offset: 0x000161A0
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x06000524 RID: 1316 RVA: 0x000171D8 File Offset: 0x000161D8
		// Note: this type is marked as 'beforefieldinit'.
		static ExtendedProperty()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (ExtendedProperty.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000525 RID: 1317
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x040001CE RID: 462
		private readonly string _name;

		// Token: 0x040001CF RID: 463
		private object _value;

		// Token: 0x040001D0 RID: 464
		private readonly DbType _dataType;

		// Token: 0x040001D1 RID: 465
		private PropertyStateEnum _propertyState;
	}
}
