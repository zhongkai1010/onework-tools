using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using #Nk;

namespace SchemaExplorer.Design
{
	// Token: 0x020000D1 RID: 209
	public class ExtendedBindableProperty : IDataErrorInfo
	{
		// Token: 0x06000726 RID: 1830 RVA: 0x000213F4 File Offset: 0x000203F4
		public ExtendedBindableProperty()
		{
			this.#x3c = true;
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x0002141C File Offset: 0x0002041C
		public ExtendedBindableProperty(ExtendedProperty property)
		{
			this.#Ro = property.Name;
			this.#w3c = property.DataType;
			this.#Rp = property.Value;
			this.#bA = (property.PropertyState == PropertyStateEnum.ReadOnly);
			this.#Xr = false;
			this.#x3c = false;
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x00021488 File Offset: 0x00020488
		// (set) Token: 0x06000729 RID: 1833 RVA: 0x00021490 File Offset: 0x00020490
		public string Name
		{
			get
			{
				return this.#Ro;
			}
			set
			{
				if (this.#Ro == value)
				{
					return;
				}
				this.#Ro = value;
				if (this.Validate())
				{
					this.#Xr = true;
				}
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x000214B8 File Offset: 0x000204B8
		// (set) Token: 0x0600072B RID: 1835 RVA: 0x000214C0 File Offset: 0x000204C0
		public object Value
		{
			get
			{
				return this.#Rp;
			}
			set
			{
				if (this.#Rp == value)
				{
					return;
				}
				this.#Rp = value;
				if (this.Validate())
				{
					this.#Xr = true;
				}
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x0600072C RID: 1836 RVA: 0x000214E4 File Offset: 0x000204E4
		// (set) Token: 0x0600072D RID: 1837 RVA: 0x000214EC File Offset: 0x000204EC
		public DbType DataType
		{
			get
			{
				return this.#w3c;
			}
			set
			{
				if (this.#w3c == value)
				{
					return;
				}
				this.#w3c = value;
				if (this.Validate())
				{
					this.#Xr = true;
				}
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x0600072E RID: 1838 RVA: 0x00021510 File Offset: 0x00020510
		// (set) Token: 0x0600072F RID: 1839 RVA: 0x00021518 File Offset: 0x00020518
		public bool IsNew
		{
			get
			{
				return this.#x3c;
			}
			set
			{
				this.#x3c = value;
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000730 RID: 1840 RVA: 0x00021524 File Offset: 0x00020524
		// (set) Token: 0x06000731 RID: 1841 RVA: 0x0002152C File Offset: 0x0002052C
		public bool IsDirty
		{
			get
			{
				return this.#Xr;
			}
			set
			{
				this.#Xr = value;
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000732 RID: 1842 RVA: 0x00021538 File Offset: 0x00020538
		// (set) Token: 0x06000733 RID: 1843 RVA: 0x00021540 File Offset: 0x00020540
		public bool IsReadonly
		{
			get
			{
				return this.#bA;
			}
			set
			{
				this.#bA = true;
			}
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x0002154C File Offset: 0x0002054C
		public bool Validate()
		{
			if (!this.#Xr)
			{
				return true;
			}
			bool flag = true;
			if (string.IsNullOrEmpty(this.#Ro))
			{
				this.#u3c[#Mk.#Lk(12136)] = #Mk.#Lk(18021);
				this.#v3c = #Mk.#Lk(18021);
				flag = false;
			}
			else
			{
				this.#u3c[#Mk.#Lk(12136)] = string.Empty;
			}
			try
			{
				Type systemType = SchemaUtility.GetSystemType(this.#w3c);
				if (this.#Rp.GetType() != systemType)
				{
					TypeConverter converter = TypeDescriptor.GetConverter(systemType);
					this.#Rp = converter.ConvertFrom(this.#Rp);
				}
			}
			catch (Exception ex)
			{
				this.#u3c[#Mk.#Lk(12608)] = ex.Message;
				this.#v3c = ex.Message;
				flag = false;
			}
			if (flag)
			{
				this.#u3c.Clear();
				this.#v3c = string.Empty;
			}
			return flag;
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000735 RID: 1845 RVA: 0x00021650 File Offset: 0x00020650
		string IDataErrorInfo.Error
		{
			get
			{
				return this.#v3c;
			}
		}

		// Token: 0x170001E0 RID: 480
		string IDataErrorInfo.this[string #4r]
		{
			get
			{
				string result;
				this.#u3c.TryGetValue(#4r, out result);
				return result;
			}
		}

		// Token: 0x040002B6 RID: 694
		private Dictionary<string, string> #u3c = new Dictionary<string, string>();

		// Token: 0x040002B7 RID: 695
		private string #v3c = string.Empty;

		// Token: 0x040002B8 RID: 696
		private string #Ro;

		// Token: 0x040002B9 RID: 697
		private object #Rp;

		// Token: 0x040002BA RID: 698
		private DbType #w3c;

		// Token: 0x040002BB RID: 699
		private bool #x3c;

		// Token: 0x040002BC RID: 700
		private bool #Xr;

		// Token: 0x040002BD RID: 701
		private bool #bA;
	}
}
