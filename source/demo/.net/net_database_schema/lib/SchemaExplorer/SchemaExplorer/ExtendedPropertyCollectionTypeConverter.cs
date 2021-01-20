using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;

namespace SchemaExplorer
{
	// Token: 0x0200008D RID: 141
	public class ExtendedPropertyCollectionTypeConverter : TypeConverter
	{
		// Token: 0x06000509 RID: 1289 RVA: 0x00016F6C File Offset: 0x00015F6C
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x00016F8C File Offset: 0x00015F8C
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			ExtendedPropertyCollection extendedPropertyCollection = value as ExtendedPropertyCollection;
			if (destinationType == typeof(string) && extendedPropertyCollection != null)
			{
				return string.Format(#Mk.#Lk(12583), extendedPropertyCollection.Count);
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x00016FE4 File Offset: 0x00015FE4
		// Note: this type is marked as 'beforefieldinit'.
		static ExtendedPropertyCollectionTypeConverter()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (ExtendedPropertyCollectionTypeConverter.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x0600050D RID: 1293
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
