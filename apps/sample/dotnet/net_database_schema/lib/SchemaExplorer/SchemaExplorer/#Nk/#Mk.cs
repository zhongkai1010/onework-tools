using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace #Nk
{
	// Token: 0x020000DE RID: 222
	internal sealed class #Mk
	{
		// Token: 0x060007CD RID: 1997 RVA: 0x000268B8 File Offset: 0x000258B8
		public static string #Lk(int #Gl)
		{
			#Gl -= #Mk.#Kk;
			if (#Mk.#Jk)
			{
				string text;
				#Mk.#Ik.TryGetValue(#Gl, out text);
				if (text != null)
				{
					return text;
				}
			}
			int index = #Gl;
			int num = (int)#Mk.#Hk[index++];
			int num2;
			if ((num & 128) == 0)
			{
				num2 = num;
				if (num2 == 0)
				{
					return string.Empty;
				}
			}
			else if ((num & 64) == 0)
			{
				num2 = ((num & 63) << 8) + (int)#Mk.#Hk[index++];
			}
			else
			{
				num2 = ((num & 31) << 24) + ((int)#Mk.#Hk[index++] << 16) + ((int)#Mk.#Hk[index++] << 8) + (int)#Mk.#Hk[index++];
			}
			string result;
			try
			{
				byte[] array = Convert.FromBase64String(Encoding.UTF8.GetString(#Mk.#Hk, index, num2));
				string text2 = string.Intern(Encoding.UTF8.GetString(array, 0, array.Length));
				if (#Mk.#Jk)
				{
					try
					{
						#Mk.#Ik.Add(#Gl, text2);
					}
					catch
					{
					}
				}
				result = text2;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x000269CC File Offset: 0x000259CC
		static #Mk()
		{
			if (#Mk.#Fk == "1")
			{
				#Mk.#Jk = true;
				#Mk.#Ik = new Dictionary<int, string>();
			}
			#Mk.#Kk = Convert.ToInt32(#Mk.#Gk);
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream("{e50e1315-a36b-44b9-b646-bebd7ff104fb}"))
			{
				int num = Convert.ToInt32(manifestResourceStream.Length);
				#Mk.#Hk = new byte[num];
				manifestResourceStream.Read(#Mk.#Hk, 0, num);
				manifestResourceStream.Close();
			}
		}

		// Token: 0x0400030A RID: 778
		private static readonly string #Fk = "0";

		// Token: 0x0400030B RID: 779
		private static readonly string #Gk = "109";

		// Token: 0x0400030C RID: 780
		private static readonly byte[] #Hk = null;

		// Token: 0x0400030D RID: 781
		private static readonly Dictionary<int, string> #Ik;

		// Token: 0x0400030E RID: 782
		private static readonly bool #Jk = false;

		// Token: 0x0400030F RID: 783
		private static readonly int #Kk = 0;
	}
}
