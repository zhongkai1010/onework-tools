using System;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;
using #cTc;
using #Nk;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000031 RID: 49
	public class SqlConnectionProperties : AdoDotNetConnectionProperties
	{
		// Token: 0x0600022A RID: 554 RVA: 0x0000E7F0 File Offset: 0x0000D7F0
		public SqlConnectionProperties() : base(#Nk.#Mk.#Lk(1642))
		{
			this.#CXc();
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000E808 File Offset: 0x0000D808
		public override void Reset()
		{
			base.Reset();
			this.#CXc();
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600022C RID: 556 RVA: 0x0000E818 File Offset: 0x0000D818
		public override bool IsComplete
		{
			get
			{
				return base.ConnectionStringBuilder[#Nk.#Mk.#Lk(241)] is string && (base.ConnectionStringBuilder[#Nk.#Mk.#Lk(241)] as string).Length != 0 && ((bool)base.ConnectionStringBuilder[#Nk.#Mk.#Lk(2568)] || (base.ConnectionStringBuilder[#Nk.#Mk.#Lk(263)] is string && (base.ConnectionStringBuilder[#Nk.#Mk.#Lk(263)] as string).Length != 0));
			}
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000E8C0 File Offset: 0x0000D8C0
		public override void Test()
		{
			string text = base.ConnectionStringBuilder[#Nk.#Mk.#Lk(241)] as string;
			if (text == null || text.Length == 0)
			{
				throw new InvalidOperationException(#cTc.#Mk.SqlConnectionProperties_MustSpecifyDataSource);
			}
			string text2 = base.ConnectionStringBuilder[#Nk.#Mk.#Lk(2755)] as string;
			try
			{
				base.Test();
			}
			catch (SqlException ex)
			{
				if (ex.Number == 4060 && text2 != null && text2.Length > 0)
				{
					throw new InvalidOperationException(#cTc.#Mk.SqlConnectionProperties_CannotTestNonExistentDatabase);
				}
				throw;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600022E RID: 558 RVA: 0x0000E958 File Offset: 0x0000D958
		protected override PropertyDescriptor DefaultProperty
		{
			get
			{
				return this.GetProperties(new Attribute[0])[#Nk.#Mk.#Lk(2670)];
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000E978 File Offset: 0x0000D978
		protected override string ToTestString()
		{
			bool flag = (bool)base.ConnectionStringBuilder[#Nk.#Mk.#Lk(3385)];
			bool flag2 = !base.ConnectionStringBuilder.ShouldSerialize(#Nk.#Mk.#Lk(3385));
			base.ConnectionStringBuilder[#Nk.#Mk.#Lk(3385)] = false;
			string connectionString = base.ConnectionStringBuilder.ConnectionString;
			base.ConnectionStringBuilder[#Nk.#Mk.#Lk(3385)] = flag;
			if (flag2)
			{
				base.ConnectionStringBuilder.Remove(#Nk.#Mk.#Lk(3385));
			}
			return connectionString;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000EA18 File Offset: 0x0000DA18
		protected override void Inspect(DbConnection connection)
		{
			if (connection.ServerVersion.StartsWith(#Nk.#Mk.#Lk(3495), StringComparison.Ordinal) || connection.ServerVersion.StartsWith(#Nk.#Mk.#Lk(3500), StringComparison.Ordinal))
			{
				throw new NotSupportedException(#cTc.#Mk.SqlConnectionProperties_UnsupportedSqlVersion);
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000EA58 File Offset: 0x0000DA58
		private void #CXc()
		{
			this[#Nk.#Mk.#Lk(2568)] = true;
		}

		// Token: 0x04000110 RID: 272
		private const int #kYc = 4060;
	}
}
