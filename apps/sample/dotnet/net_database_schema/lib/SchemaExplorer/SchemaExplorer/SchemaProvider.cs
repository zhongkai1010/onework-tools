using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using #Nk;
using CodeSmith.Core.Reflection;

namespace SchemaExplorer
{
	// Token: 0x0200005C RID: 92
	public class SchemaProvider : IComparable, IComparable<string>, IComparable<SchemaProvider>, IEquatable<string>, IEquatable<SchemaProvider>
	{
		// Token: 0x06000374 RID: 884 RVA: 0x00013784 File Offset: 0x00012784
		public SchemaProvider(string assemblyQualifiedName) : this(assemblyQualifiedName, SchemaProvider.#c0c(assemblyQualifiedName))
		{
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00013794 File Offset: 0x00012794
		public SchemaProvider(string assemblyQualifiedName, string displayName)
		{
			this.#b0c = assemblyQualifiedName;
			this.#sUc = displayName;
			this.#6Zc = new Lazy<Type>(new Func<Type>(this.#e0c));
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000376 RID: 886 RVA: 0x000137C4 File Offset: 0x000127C4
		public string DisplayName
		{
			get
			{
				return this.#sUc;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000377 RID: 887 RVA: 0x000137CC File Offset: 0x000127CC
		public string AssemblyQualifiedName
		{
			get
			{
				return this.#b0c;
			}
		}

		// Token: 0x06000378 RID: 888 RVA: 0x000137D4 File Offset: 0x000127D4
		public Type GetProviderType()
		{
			return this.#6Zc.Value;
		}

		// Token: 0x06000379 RID: 889 RVA: 0x000137E4 File Offset: 0x000127E4
		public IDbSchemaProvider CreateProvider()
		{
			return this.CreateProvider(false);
		}

		// Token: 0x0600037A RID: 890 RVA: 0x000137F0 File Offset: 0x000127F0
		public IDbSchemaProvider CreateProvider(bool cache)
		{
			if (cache && this.#8Zc)
			{
				return this.#7Zc;
			}
			this.#8Zc = true;
			Type value = this.#6Zc.Value;
			if (value == null)
			{
				return null;
			}
			this.#7Zc = (Activator.CreateInstance(value) as IDbSchemaProvider);
			return this.#7Zc;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00013844 File Offset: 0x00012844
		public IDbConnectionStringEditor CreateEditor()
		{
			return this.CreateEditor(false);
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00013850 File Offset: 0x00012850
		public IDbConnectionStringEditor CreateEditor(bool cache)
		{
			if (cache && this.#a0c)
			{
				return this.#9Zc;
			}
			this.#a0c = true;
			Type value = this.#6Zc.Value;
			if (value == null)
			{
				return null;
			}
			Type @interface = value.GetInterface(#Mk.#Lk(8279));
			if (@interface == null)
			{
				return null;
			}
			this.#9Zc = (Activator.CreateInstance(value) as IDbConnectionStringEditor);
			return this.#9Zc;
		}

		// Token: 0x0600037D RID: 893 RVA: 0x000138C0 File Offset: 0x000128C0
		private static string #c0c(string #d0c)
		{
			string result;
			try
			{
				TypeSpec typeSpec = TypeSpec.Parse(#d0c);
				result = typeSpec.GetName();
			}
			catch (ArgumentException)
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x000138F8 File Offset: 0x000128F8
		public static implicit operator SchemaProvider(string assemblyQualifiedName)
		{
			return new SchemaProvider(assemblyQualifiedName);
		}

		// Token: 0x0600037F RID: 895 RVA: 0x00013900 File Offset: 0x00012900
		public static implicit operator string(SchemaProvider schemaProvider)
		{
			return schemaProvider.AssemblyQualifiedName;
		}

		// Token: 0x06000380 RID: 896 RVA: 0x00013908 File Offset: 0x00012908
		int IComparable.#Mp(object #bi)
		{
			if (#bi is string)
			{
				return ((IComparable<string>)this).CompareTo((string)#bi);
			}
			if (#bi is SchemaProvider)
			{
				return ((IComparable<SchemaProvider>)this).CompareTo((SchemaProvider)#bi);
			}
			throw new ArgumentException(#Mk.#Lk(8316));
		}

		// Token: 0x06000381 RID: 897 RVA: 0x00013944 File Offset: 0x00012944
		public int CompareTo(string other)
		{
			return this.AssemblyQualifiedName.CompareTo(other);
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00013954 File Offset: 0x00012954
		public int CompareTo(SchemaProvider other)
		{
			if (other == null)
			{
				return 1;
			}
			return this.AssemblyQualifiedName.CompareTo(other.AssemblyQualifiedName);
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0001396C File Offset: 0x0001296C
		public bool Equals(string other)
		{
			return other != null && (this.AssemblyQualifiedName == other || string.Equals(other, this.AssemblyQualifiedName));
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0001398C File Offset: 0x0001298C
		public bool Equals(SchemaProvider other)
		{
			return other != null && (this == other || string.Equals(other.AssemblyQualifiedName, this.AssemblyQualifiedName));
		}

		// Token: 0x06000385 RID: 901 RVA: 0x000139AC File Offset: 0x000129AC
		public override bool Equals(object obj)
		{
			return obj != null && (this == obj || (!(obj.GetType() != typeof(SchemaProvider)) && this.Equals((SchemaProvider)obj)));
		}

		// Token: 0x06000386 RID: 902 RVA: 0x000139E0 File Offset: 0x000129E0
		public override int GetHashCode()
		{
			if (this.#b0c == null)
			{
				return 0;
			}
			return this.#b0c.GetHashCode();
		}

		// Token: 0x06000387 RID: 903 RVA: 0x000139F8 File Offset: 0x000129F8
		public override string ToString()
		{
			return this.AssemblyQualifiedName;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00013A00 File Offset: 0x00012A00
		[CompilerGenerated]
		private Type #e0c()
		{
			return Type.GetType(this.#b0c, new Func<AssemblyName, Assembly>(SchemaProvider.<>c.<>9.#F5c), null, false, true);
		}

		// Token: 0x04000167 RID: 359
		private readonly Lazy<Type> #6Zc;

		// Token: 0x04000168 RID: 360
		private IDbSchemaProvider #7Zc;

		// Token: 0x04000169 RID: 361
		private bool #8Zc;

		// Token: 0x0400016A RID: 362
		private IDbConnectionStringEditor #9Zc;

		// Token: 0x0400016B RID: 363
		private bool #a0c;

		// Token: 0x0400016C RID: 364
		private readonly string #sUc;

		// Token: 0x0400016D RID: 365
		private readonly string #b0c;
	}
}
