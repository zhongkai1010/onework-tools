using System;
using System.Collections.Generic;
using System.ComponentModel;
using #Nk;

namespace #cTc
{
	// Token: 0x02000015 RID: 21
	internal sealed class #uVc : PropertyDescriptor
	{
		// Token: 0x0600012A RID: 298 RVA: 0x00008B18 File Offset: 0x00007B18
		public #uVc(string name) : base(name, null)
		{
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00008B24 File Offset: 0x00007B24
		public #uVc(string name, params Attribute[] attributes) : base(name, #uVc.#tVc(attributes))
		{
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00008B34 File Offset: 0x00007B34
		public #uVc(PropertyDescriptor baseDescriptor) : this(baseDescriptor, null)
		{
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00008B40 File Offset: 0x00007B40
		public #uVc(PropertyDescriptor baseDescriptor, params Attribute[] newAttributes) : base(baseDescriptor, newAttributes)
		{
			this.AttributeArray = #uVc.#tVc(this.AttributeArray);
			this.#PUc = baseDescriptor;
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00008B64 File Offset: 0x00007B64
		public override string Name
		{
			get
			{
				if (this.#Ro != null)
				{
					return this.#Ro;
				}
				return base.Name;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600012F RID: 303 RVA: 0x00008B7C File Offset: 0x00007B7C
		public string Category
		{
			get
			{
				if (this.#GUc != null)
				{
					return this.#GUc;
				}
				return base.Category;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00008B94 File Offset: 0x00007B94
		public override string Description
		{
			get
			{
				if (this.#Wq != null)
				{
					return this.#Wq;
				}
				return base.Description;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000131 RID: 305 RVA: 0x00008BAC File Offset: 0x00007BAC
		public Type PropertyType
		{
			get
			{
				if (this.#Czb != null)
				{
					return this.#Czb;
				}
				if (this.#PUc != null)
				{
					return this.#PUc.PropertyType;
				}
				return null;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000132 RID: 306 RVA: 0x00008BD8 File Offset: 0x00007BD8
		public bool IsReadOnly
		{
			get
			{
				return ReadOnlyAttribute.Yes.Equals(this.Attributes[typeof(ReadOnlyAttribute)]);
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00008BFC File Offset: 0x00007BFC
		public TypeConverter Converter
		{
			get
			{
				if (this.#HUc != null)
				{
					if (this.#8jc == null)
					{
						Type typeFromName = base.GetTypeFromName(this.#HUc);
						if (typeof(TypeConverter).IsAssignableFrom(typeFromName))
						{
							this.#8jc = (TypeConverter)base.CreateInstance(typeFromName);
						}
					}
					if (this.#8jc != null)
					{
						return this.#8jc;
					}
				}
				return base.Converter;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00008C60 File Offset: 0x00007C60
		public AttributeCollection Attributes
		{
			get
			{
				if (this.#Jib != null)
				{
					Dictionary<object, Attribute> dictionary = new Dictionary<object, Attribute>();
					foreach (Attribute attribute in this.AttributeArray)
					{
						dictionary[attribute.TypeId] = attribute;
					}
					foreach (Attribute attribute2 in this.#Jib)
					{
						if (!attribute2.IsDefaultAttribute())
						{
							dictionary[attribute2.TypeId] = attribute2;
						}
						else if (dictionary.ContainsKey(attribute2.TypeId))
						{
							dictionary.Remove(attribute2.TypeId);
						}
						CategoryAttribute categoryAttribute = attribute2 as CategoryAttribute;
						if (categoryAttribute != null)
						{
							this.#GUc = categoryAttribute.Category;
						}
						DescriptionAttribute descriptionAttribute = attribute2 as DescriptionAttribute;
						if (descriptionAttribute != null)
						{
							this.#Wq = descriptionAttribute.Description;
						}
						TypeConverterAttribute typeConverterAttribute = attribute2 as TypeConverterAttribute;
						if (typeConverterAttribute != null)
						{
							this.#HUc = typeConverterAttribute.ConverterTypeName;
							this.#8jc = null;
						}
					}
					Attribute[] array = new Attribute[dictionary.Values.Count];
					dictionary.Values.CopyTo(array, 0);
					this.AttributeArray = array;
					this.#Jib = null;
				}
				return base.Attributes;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00008DAC File Offset: 0x00007DAC
		// (set) Token: 0x06000136 RID: 310 RVA: 0x00008DB4 File Offset: 0x00007DB4
		public #vVc GetValueHandler
		{
			get
			{
				return this.#IUc;
			}
			set
			{
				this.#IUc = value;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00008DC0 File Offset: 0x00007DC0
		// (set) Token: 0x06000138 RID: 312 RVA: 0x00008DC8 File Offset: 0x00007DC8
		public #wVc SetValueHandler
		{
			get
			{
				return this.#JUc;
			}
			set
			{
				this.#JUc = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00008DD4 File Offset: 0x00007DD4
		// (set) Token: 0x0600013A RID: 314 RVA: 0x00008DDC File Offset: 0x00007DDC
		public #xVc CanResetValueHandler
		{
			get
			{
				return this.#KUc;
			}
			set
			{
				this.#KUc = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00008DE8 File Offset: 0x00007DE8
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00008DF0 File Offset: 0x00007DF0
		public #yVc ResetValueHandler
		{
			get
			{
				return this.#LUc;
			}
			set
			{
				this.#LUc = value;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00008DFC File Offset: 0x00007DFC
		// (set) Token: 0x0600013E RID: 318 RVA: 0x00008E04 File Offset: 0x00007E04
		public #zVc ShouldSerializeValueHandler
		{
			get
			{
				return this.#MUc;
			}
			set
			{
				this.#MUc = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600013F RID: 319 RVA: 0x00008E10 File Offset: 0x00007E10
		// (set) Token: 0x06000140 RID: 320 RVA: 0x00008E18 File Offset: 0x00007E18
		public #AVc GetChildPropertiesHandler
		{
			get
			{
				return this.#NUc;
			}
			set
			{
				this.#NUc = value;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000141 RID: 321 RVA: 0x00008E24 File Offset: 0x00007E24
		public Type ComponentType
		{
			get
			{
				if (this.#OUc != null)
				{
					return this.#OUc;
				}
				if (this.#PUc != null)
				{
					return this.#PUc.ComponentType;
				}
				return null;
			}
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00008E50 File Offset: 0x00007E50
		public void #8Uc(string #am)
		{
			if (#am == null)
			{
				#am = string.Empty;
			}
			this.#Ro = #am;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00008E64 File Offset: 0x00007E64
		public void #9Uc(string #am)
		{
			if (#am == null)
			{
				#am = DisplayNameAttribute.Default.DisplayName;
			}
			this.#iVc(new DisplayNameAttribute(#am));
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00008E84 File Offset: 0x00007E84
		public void #aVc(string #am)
		{
			if (#am == null)
			{
				#am = CategoryAttribute.Default.Category;
			}
			this.#GUc = #am;
			this.#iVc(new CategoryAttribute(#am));
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00008EA8 File Offset: 0x00007EA8
		public void #bVc(string #am)
		{
			if (#am == null)
			{
				#am = DescriptionAttribute.Default.Description;
			}
			this.#Wq = #am;
			this.#iVc(new DescriptionAttribute(#am));
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00008ECC File Offset: 0x00007ECC
		public void #cVc(Type #am)
		{
			if (#am == null)
			{
				throw new ArgumentNullException(#Mk.#Lk(1822));
			}
			this.#Czb = #am;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00008EF0 File Offset: 0x00007EF0
		public void #dVc(bool #am)
		{
			this.#iVc(new DesignOnlyAttribute(#am));
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00008F00 File Offset: 0x00007F00
		public void #eVc(bool #am)
		{
			this.#iVc(new BrowsableAttribute(#am));
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00008F10 File Offset: 0x00007F10
		public void #fVc(bool #am)
		{
			this.#iVc(new LocalizableAttribute(#am));
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00008F20 File Offset: 0x00007F20
		public void #gVc(bool #am)
		{
			this.#iVc(new ReadOnlyAttribute(#am));
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00008F30 File Offset: 0x00007F30
		public void #hVc(Type #am)
		{
			this.#HUc = ((#am != null) ? #am.AssemblyQualifiedName : null);
			if (this.#HUc != null)
			{
				this.#iVc(new TypeConverterAttribute(#am));
			}
			else
			{
				this.#iVc(TypeConverterAttribute.Default);
			}
			this.#8jc = null;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00008F80 File Offset: 0x00007F80
		public void #iVc(Attribute #am)
		{
			if (#am == null)
			{
				throw new ArgumentNullException(#Mk.#Lk(1822));
			}
			if (this.#Jib == null)
			{
				this.#Jib = new List<Attribute>();
			}
			this.#Jib.Add(#am);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00008FB4 File Offset: 0x00007FB4
		public void #jVc(params Attribute[] #sy)
		{
			foreach (Attribute #am in #sy)
			{
				this.#iVc(#am);
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00008FDC File Offset: 0x00007FDC
		public void #kVc(Type #am)
		{
			this.#OUc = #am;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00008FE8 File Offset: 0x00007FE8
		public object #lVc(object #mVc)
		{
			if (this.GetValueHandler != null)
			{
				return this.GetValueHandler(#mVc);
			}
			if (this.#PUc != null)
			{
				return this.#PUc.GetValue(#mVc);
			}
			return null;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00009018 File Offset: 0x00008018
		public void #nVc(object #mVc, object #am)
		{
			if (this.SetValueHandler != null)
			{
				this.SetValueHandler(#mVc, #am);
				this.OnValueChanged(#mVc, EventArgs.Empty);
				return;
			}
			if (this.#PUc != null)
			{
				this.#PUc.SetValue(#mVc, #am);
				this.OnValueChanged(#mVc, EventArgs.Empty);
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00009068 File Offset: 0x00008068
		public bool #oVc(object #mVc)
		{
			if (this.CanResetValueHandler != null)
			{
				return this.CanResetValueHandler(#mVc);
			}
			if (this.#PUc != null)
			{
				return this.#PUc.CanResetValue(#mVc);
			}
			return this.Attributes[typeof(DefaultValueAttribute)] != null;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000090B8 File Offset: 0x000080B8
		public void #pVc(object #mVc)
		{
			if (this.ResetValueHandler != null)
			{
				this.ResetValueHandler(#mVc);
				return;
			}
			if (this.#PUc != null)
			{
				this.#PUc.ResetValue(#mVc);
				return;
			}
			DefaultValueAttribute defaultValueAttribute = this.Attributes[typeof(DefaultValueAttribute)] as DefaultValueAttribute;
			if (defaultValueAttribute != null)
			{
				this.SetValue(#mVc, defaultValueAttribute.Value);
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000911C File Offset: 0x0000811C
		public bool #qVc(object #mVc)
		{
			if (this.ShouldSerializeValueHandler != null)
			{
				return this.ShouldSerializeValueHandler(#mVc);
			}
			if (this.#PUc != null)
			{
				return this.#PUc.ShouldSerializeValue(#mVc);
			}
			DefaultValueAttribute defaultValueAttribute = this.Attributes[typeof(DefaultValueAttribute)] as DefaultValueAttribute;
			return defaultValueAttribute != null && !object.Equals(this.GetValue(#mVc), defaultValueAttribute.Value);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00009188 File Offset: 0x00008188
		public PropertyDescriptorCollection #rVc(object #8h, Attribute[] #DK)
		{
			if (this.GetChildPropertiesHandler != null)
			{
				return this.GetChildPropertiesHandler(#8h, #DK);
			}
			if (this.#PUc != null)
			{
				return this.#PUc.GetChildProperties(#8h, #DK);
			}
			return base.GetChildProperties(#8h, #DK);
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000155 RID: 341 RVA: 0x000091C0 File Offset: 0x000081C0
		protected int NameHashCode
		{
			get
			{
				if (this.#Ro == null)
				{
					return base.NameHashCode;
				}
				return this.#Ro.GetHashCode();
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000091DC File Offset: 0x000081DC
		private static Attribute[] #tVc(Attribute[] #0Sb)
		{
			Dictionary<object, Attribute> dictionary = new Dictionary<object, Attribute>();
			foreach (Attribute attribute in #0Sb)
			{
				if (!attribute.IsDefaultAttribute())
				{
					dictionary.Add(attribute.TypeId, attribute);
				}
			}
			Attribute[] array = new Attribute[dictionary.Values.Count];
			dictionary.Values.CopyTo(array, 0);
			return array;
		}

		// Token: 0x04000099 RID: 153
		private string #Ro;

		// Token: 0x0400009A RID: 154
		private string #GUc;

		// Token: 0x0400009B RID: 155
		private string #Wq;

		// Token: 0x0400009C RID: 156
		private Type #Czb;

		// Token: 0x0400009D RID: 157
		private string #HUc;

		// Token: 0x0400009E RID: 158
		private TypeConverter #8jc;

		// Token: 0x0400009F RID: 159
		private List<Attribute> #Jib;

		// Token: 0x040000A0 RID: 160
		private #vVc #IUc;

		// Token: 0x040000A1 RID: 161
		private #wVc #JUc;

		// Token: 0x040000A2 RID: 162
		private #xVc #KUc;

		// Token: 0x040000A3 RID: 163
		private #yVc #LUc;

		// Token: 0x040000A4 RID: 164
		private #zVc #MUc;

		// Token: 0x040000A5 RID: 165
		private #AVc #NUc;

		// Token: 0x040000A6 RID: 166
		private Type #OUc;

		// Token: 0x040000A7 RID: 167
		private PropertyDescriptor #PUc;
	}
}
