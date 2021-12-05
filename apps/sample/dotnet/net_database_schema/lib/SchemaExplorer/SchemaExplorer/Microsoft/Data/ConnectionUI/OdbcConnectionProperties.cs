using System;
using System.Collections.Generic;
using System.Text;
using #cTc;
using #Nk;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000023 RID: 35
	public class OdbcConnectionProperties : AdoDotNetConnectionProperties
	{
		// Token: 0x0600019D RID: 413 RVA: 0x00009878 File Offset: 0x00008878
		public OdbcConnectionProperties() : base(#Nk.#Mk.#Lk(1729))
		{
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600019E RID: 414 RVA: 0x0000988C File Offset: 0x0000888C
		public override bool IsComplete
		{
			get
			{
				return (base.ConnectionStringBuilder[#Nk.#Mk.#Lk(2027)] is string && (base.ConnectionStringBuilder[#Nk.#Mk.#Lk(2027)] as string).Length != 0) || (base.ConnectionStringBuilder[#Nk.#Mk.#Lk(2032)] is string && (base.ConnectionStringBuilder[#Nk.#Mk.#Lk(2032)] as string).Length != 0);
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00009918 File Offset: 0x00008918
		public static List<string> SqlNativeClientDrivers
		{
			get
			{
				if (OdbcConnectionProperties.#cXc == null)
				{
					OdbcConnectionProperties.#cXc = new List<string>();
					List<string> list = OdbcConnectionProperties.#dXc();
					foreach (string text in list)
					{
						if (text.Contains(#Nk.#Mk.#Lk(2041)) && text.Contains(#Nk.#Mk.#Lk(2050)))
						{
							StringBuilder stringBuilder = new StringBuilder(1024);
							int num = #qgc.#CWc(text, #Nk.#Mk.#Lk(2059), #Nk.#Mk.#Lk(2068), stringBuilder, stringBuilder.Capacity, #Nk.#Mk.#Lk(2069));
							if (num > 0 && stringBuilder.Length > 0)
							{
								string text2 = stringBuilder.ToString();
								int num2 = text2.LastIndexOf('\\');
								if (num2 > 0)
								{
									OdbcConnectionProperties.#cXc.Add(text2.Substring(num2 + 1).ToUpperInvariant());
								}
							}
						}
					}
					OdbcConnectionProperties.#cXc.Sort();
				}
				return OdbcConnectionProperties.#cXc;
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00009A30 File Offset: 0x00008A30
		private static List<string> #dXc()
		{
			char[] array = new char[1024];
			int num = 0;
			bool flag = true;
			List<string> list = new List<string>();
			try
			{
				flag = #qgc.#yWc(array, array.Length, ref num);
				while (flag && num > 0 && num == array.Length - 1 && (double)array.Length < Math.Pow(2.0, 30.0))
				{
					array = new char[array.Length * 2];
					flag = #qgc.#yWc(array, array.Length, ref num);
				}
			}
			catch (Exception ex)
			{
				flag = false;
			}
			if (flag)
			{
				int i = 0;
				int num2 = Array.IndexOf<char>(array, '\0', i, num - 1);
				while (i < num - 1)
				{
					list.Add(new string(array, i, num2 - i));
					i = num2 + 1;
					num2 = Array.IndexOf<char>(array, '\0', i, num - 1 - num2);
				}
			}
			return list;
		}

		// Token: 0x040000C7 RID: 199
		private static List<string> #cXc;
	}
}
