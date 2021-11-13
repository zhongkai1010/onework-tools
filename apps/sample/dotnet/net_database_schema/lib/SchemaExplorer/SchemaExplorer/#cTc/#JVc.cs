using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace #cTc
{
	// Token: 0x0200001C RID: 28
	internal sealed class #JVc
	{
		// Token: 0x0600016F RID: 367 RVA: 0x0000923C File Offset: 0x0000823C
		private #JVc()
		{
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00009244 File Offset: 0x00008244
		public static bool #CVc(ref Message #WM)
		{
			return #WM.Msg == 274 && ((int)#WM.WParam & 65520) == 61824;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00009270 File Offset: 0x00008270
		public static bool #DVc()
		{
			bool result = false;
			if (Environment.OSVersion.Version.Major >= 5)
			{
				Process currentProcess = Process.GetCurrentProcess();
				try
				{
					#qgc.#JWc(currentProcess.Handle, out result);
				}
				catch (Exception ex)
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x000092C0 File Offset: 0x000082C0
		public static string[] #EVc(string #FVc, int #GVc)
		{
			UIntPtr zero = UIntPtr.Zero;
			UIntPtr zero2 = UIntPtr.Zero;
			int num = 0;
			string[] array = null;
			try
			{
				num = #qgc.#MWc(#qgc.#UVc, #FVc, 0, #GVc, out zero2);
			}
			catch
			{
			}
			if (num == 0 && !object.Equals(zero2, UIntPtr.Zero))
			{
				uint num2 = 0U;
				try
				{
					uint num3;
					num = #qgc.#XWc(zero2, null, IntPtr.Zero, IntPtr.Zero, out num3, IntPtr.Zero, IntPtr.Zero, out num2, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
				}
				catch
				{
				}
				if (num == 0)
				{
					array = new string[num2];
					for (uint num4 = 0U; num4 < num2; num4 += 1U)
					{
						StringBuilder stringBuilder = new StringBuilder(1024);
						uint num5 = 1024U;
						try
						{
							num = #qgc.#8Wc(zero2, num4, stringBuilder, ref num5, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
						}
						catch
						{
						}
						if (num == 0)
						{
							array[(int)num4] = stringBuilder.ToString();
						}
					}
				}
			}
			if (array != null)
			{
				return array;
			}
			return new string[0];
		}

		// Token: 0x06000173 RID: 371 RVA: 0x000093E4 File Offset: 0x000083E4
		public static void #HVc(Form #ZMb, ref Message #WM)
		{
			Control control = #JVc.#IVc(#ZMb);
			if (control != null)
			{
				#WM.HWnd = control.Handle;
				#WM.Msg = 83;
				#WM.WParam = IntPtr.Zero;
				#qgc.#94c #94c = new #qgc.#94c();
				#94c.#44c = 1;
				#94c.#54c = #ZMb.Handle.ToInt32();
				#94c.#64c = control.Handle;
				#94c.#74c = 0;
				#94c.#84c.#W = (int)#qgc.#n((int)#WM.LParam);
				#94c.#84c.#X = (int)#qgc.#l((int)#WM.LParam);
				#WM.LParam = Marshal.AllocHGlobal(Marshal.SizeOf<#qgc.#94c>(#94c));
				Marshal.StructureToPtr<#qgc.#94c>(#94c, #WM.LParam, false);
			}
		}

		// Token: 0x06000174 RID: 372 RVA: 0x000094A8 File Offset: 0x000084A8
		public static Control #IVc(Form #ZMb)
		{
			Control control = #ZMb;
			ContainerControl containerControl;
			while ((containerControl = (control as ContainerControl)) != null && containerControl.ActiveControl != null)
			{
				control = containerControl.ActiveControl;
			}
			return control;
		}

		// Token: 0x040000A8 RID: 168
		private const int #BVc = 1024;
	}
}
