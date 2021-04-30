using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using #Nk;

namespace #cTc
{
	// Token: 0x0200001E RID: 30
	internal sealed class #qgc
	{
		// Token: 0x0600017E RID: 382 RVA: 0x00009724 File Offset: 0x00008724
		private #qgc()
		{
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000972C File Offset: 0x0000872C
		internal static bool #gWc(short #hWc)
		{
			return (#hWc & -2) == 0;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00009738 File Offset: 0x00008738
		internal static short #n(int #iWc)
		{
			return (short)(#iWc & 65535);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00009744 File Offset: 0x00008744
		internal static short #l(int #iWc)
		{
			return (short)(#iWc >> 16 & 65535);
		}

		// Token: 0x06000182 RID: 386
		[DllImport("odbc32.dll", EntryPoint = "SQLAllocEnv")]
		internal static extern short #jWc(out IntPtr #kWc);

		// Token: 0x06000183 RID: 387
		[DllImport("odbc32.dll", EntryPoint = "SQLAllocConnect")]
		internal static extern short #lWc(IntPtr #kWc, out IntPtr #mWc);

		// Token: 0x06000184 RID: 388
		[DllImport("odbc32.dll", CharSet = CharSet.Unicode, EntryPoint = "SQLDriverConnectW")]
		internal static extern short #nWc(IntPtr #oWc, IntPtr #R, string #pWc, short #qWc, StringBuilder #rWc, short #sWc, out short #tWc, ushort #uWc);

		// Token: 0x06000185 RID: 389
		[DllImport("odbc32.dll", EntryPoint = "SQLDisconnect")]
		internal static extern short #vWc(IntPtr #mWc);

		// Token: 0x06000186 RID: 390
		[DllImport("odbc32.dll", EntryPoint = "SQLFreeConnect")]
		internal static extern short #wWc(IntPtr #mWc);

		// Token: 0x06000187 RID: 391
		[DllImport("odbc32.dll", EntryPoint = "SQLFreeEnv")]
		internal static extern short #xWc(IntPtr #kWc);

		// Token: 0x06000188 RID: 392
		[DllImport("odbccp32.dll", CharSet = CharSet.Unicode, EntryPoint = "SQLGetInstalledDrivers")]
		internal static extern bool #yWc(char[] #zWc, int #AWc, ref int #BWc);

		// Token: 0x06000189 RID: 393
		[DllImport("odbccp32.dll", CharSet = CharSet.Unicode, EntryPoint = "SQLGetPrivateProfileString")]
		internal static extern int #CWc(string #DWc, string #EWc, string #FWc, StringBuilder #GWc, int #HWc, string #IWc);

		// Token: 0x0600018A RID: 394
		[DllImport("kernel32", EntryPoint = "IsWow64Process")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool #JWc(IntPtr #KWc, out bool #LWc);

		// Token: 0x0600018B RID: 395
		[DllImport("advapi32", EntryPoint = "RegOpenKeyEx")]
		internal static extern int #MWc(UIntPtr #NWc, string #OWc, int #GVc, int #PWc, out UIntPtr #QWc);

		// Token: 0x0600018C RID: 396
		[DllImport("advapi32", EntryPoint = "RegQueryValueEx")]
		internal static extern int #RWc(UIntPtr #NWc, string #SWc, uint #TWc, ref uint #UWc, IntPtr #VWc, ref int #WWc);

		// Token: 0x0600018D RID: 397
		[DllImport("advapi32.dll", EntryPoint = "RegQueryInfoKey")]
		internal static extern int #XWc(UIntPtr #NWc, byte[] #YWc, IntPtr #ZWc, IntPtr #TWc, out uint #0Wc, IntPtr #1Wc, IntPtr #2Wc, out uint #3Wc, IntPtr #4Wc, IntPtr #5Wc, IntPtr #6Wc, IntPtr #7Wc);

		// Token: 0x0600018E RID: 398
		[DllImport("advapi32.dll", EntryPoint = "RegEnumValue")]
		internal static extern int #8Wc(UIntPtr #NWc, uint #5q, StringBuilder #SWc, ref uint #9Wc, IntPtr #7P, IntPtr #UWc, IntPtr #VWc, IntPtr #aXc);

		// Token: 0x0600018F RID: 399
		[DllImport("advapi32", EntryPoint = "RegCloseKey")]
		internal static extern uint #bXc(UIntPtr #NWc);

		// Token: 0x06000190 RID: 400 RVA: 0x00009754 File Offset: 0x00008754
		// Note: this type is marked as 'beforefieldinit'.
		static #qgc()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (#qgc.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				#qgc.#UVc = new UIntPtr(2147483650U);
				#qgc.#YVc = new Guid(#Mk.#Lk(1831));
				#qgc.#ZVc = new Guid(#Mk.#Lk(1880));
				#qgc.#0Vc = new Guid(#Mk.#Lk(1929));
				#qgc.#1Vc = new Guid(#Mk.#Lk(1978));
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000191 RID: 401
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x040000A9 RID: 169
		internal static readonly UIntPtr #UVc;

		// Token: 0x040000AA RID: 170
		internal const int #VVc = 256;

		// Token: 0x040000AB RID: 171
		internal const int #WVc = 512;

		// Token: 0x040000AC RID: 172
		internal const int #XVc = 1;

		// Token: 0x040000AD RID: 173
		internal static Guid #YVc;

		// Token: 0x040000AE RID: 174
		internal static Guid #ZVc;

		// Token: 0x040000AF RID: 175
		internal static Guid #0Vc;

		// Token: 0x040000B0 RID: 176
		internal static Guid #1Vc;

		// Token: 0x040000B1 RID: 177
		internal const int #2Vc = -2147217842;

		// Token: 0x040000B2 RID: 178
		internal const int #3Vc = 1;

		// Token: 0x040000B3 RID: 179
		internal const int #4Vc = 7;

		// Token: 0x040000B4 RID: 180
		internal const int #5Vc = 83;

		// Token: 0x040000B5 RID: 181
		internal const int #6Vc = 123;

		// Token: 0x040000B6 RID: 182
		internal const int #7Vc = 274;

		// Token: 0x040000B7 RID: 183
		internal const int #8Vc = 61824;

		// Token: 0x040000B8 RID: 184
		internal const int #9Vc = 1;

		// Token: 0x040000B9 RID: 185
		internal const int #aWc = 1;

		// Token: 0x040000BA RID: 186
		internal const int #bWc = 3;

		// Token: 0x040000BB RID: 187
		internal const int #cWc = 2;

		// Token: 0x040000BC RID: 188
		internal const int #dWc = 16;

		// Token: 0x040000BD RID: 189
		internal const ushort #eWc = 2;

		// Token: 0x040000BE RID: 190
		internal const short #fWc = 100;

		// Token: 0x0200001F RID: 31
		[Guid("2206CCB1-19C1-11D1-89E0-00C04FD7A829")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[ComImport]
		internal interface #W4c
		{
			// Token: 0x06000192 RID: 402
			void #K4c([MarshalAs(UnmanagedType.IUnknown)] [In] object #9Pb, [MarshalAs(UnmanagedType.U4)] [In] int #L4c, [MarshalAs(UnmanagedType.LPWStr)] [In] string #M4c, [In] ref Guid #aQb, [MarshalAs(UnmanagedType.IUnknown)] [In] [Out] ref object #N4c);

			// Token: 0x06000193 RID: 403
			void #O4c([MarshalAs(UnmanagedType.IUnknown)] [In] object #P4c, [MarshalAs(UnmanagedType.I1)] [In] bool #Q4c, [MarshalAs(UnmanagedType.LPWStr)] out string #R4c);

			// Token: 0x06000194 RID: 404
			void #S4c();

			// Token: 0x06000195 RID: 405
			void #T4c();

			// Token: 0x06000196 RID: 406
			void #U4c();

			// Token: 0x06000197 RID: 407
			void #V4c();
		}

		// Token: 0x02000020 RID: 32
		[Guid("2206CCB0-19C1-11D1-89E0-00C04FD7A829")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[ComImport]
		internal interface #34c
		{
			// Token: 0x06000198 RID: 408
			void #X4c([MarshalAs(UnmanagedType.IUnknown)] [In] object #9Pb, [In] IntPtr #prc, [MarshalAs(UnmanagedType.U4)] [In] int #Y4c, [MarshalAs(UnmanagedType.U4)] [In] int #Z4c, [In] IntPtr #04c, [MarshalAs(UnmanagedType.LPWStr)] [In] string #14c, [In] ref Guid #aQb, [MarshalAs(UnmanagedType.IUnknown)] [In] [Out] ref object #N4c);

			// Token: 0x06000199 RID: 409
			void #24c();
		}

		// Token: 0x02000021 RID: 33
		[StructLayout(LayoutKind.Sequential)]
		internal sealed class #94c
		{
			// Token: 0x0600019B RID: 411 RVA: 0x00009824 File Offset: 0x00008824
			// Note: this type is marked as 'beforefieldinit'.
			static #94c()
			{
				bool flag = false;
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				if (#qgc.#94c.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
				{
					return;
				}
				throw new SecurityException(#Mk.#Lk(799));
			}

			// Token: 0x0600019C RID: 412
			[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
			[return: MarshalAs(UnmanagedType.Bool)]
			private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

			// Token: 0x040000BF RID: 191
			public int #pi = Marshal.SizeOf(typeof(#qgc.#94c));

			// Token: 0x040000C0 RID: 192
			public int #44c;

			// Token: 0x040000C1 RID: 193
			public int #54c;

			// Token: 0x040000C2 RID: 194
			public IntPtr #64c;

			// Token: 0x040000C3 RID: 195
			public int #74c;

			// Token: 0x040000C4 RID: 196
			public #qgc.#ui #84c;
		}

		// Token: 0x02000022 RID: 34
		internal struct #ui
		{
			// Token: 0x040000C5 RID: 197
			public int #W;

			// Token: 0x040000C6 RID: 198
			public int #X;
		}
	}
}
