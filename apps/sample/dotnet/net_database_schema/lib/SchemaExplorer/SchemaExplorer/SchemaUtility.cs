using System;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Xml;
using #Nk;

namespace SchemaExplorer
{
	// Token: 0x020000A7 RID: 167
	public class SchemaUtility
	{
		// Token: 0x060005B3 RID: 1459 RVA: 0x000181CC File Offset: 0x000171CC
		public static Type GetSystemType(DbType type)
		{
			switch (type)
			{
			case DbType.AnsiString:
				return typeof(string);
			case DbType.Binary:
				return typeof(byte[]);
			case DbType.Byte:
				return typeof(byte);
			case DbType.Boolean:
				return typeof(bool);
			case DbType.Currency:
				return typeof(decimal);
			case DbType.Date:
				return typeof(DateTime);
			case DbType.DateTime:
				return typeof(DateTime);
			case DbType.Decimal:
				return typeof(decimal);
			case DbType.Double:
				return typeof(double);
			case DbType.Guid:
				return typeof(Guid);
			case DbType.Int16:
				return typeof(short);
			case DbType.Int32:
				return typeof(int);
			case DbType.Int64:
				return typeof(long);
			case DbType.Object:
				return typeof(object);
			case DbType.SByte:
				return typeof(sbyte);
			case DbType.Single:
				return typeof(float);
			case DbType.String:
				return typeof(string);
			case DbType.Time:
				return typeof(TimeSpan);
			case DbType.UInt16:
				return typeof(ushort);
			case DbType.UInt32:
				return typeof(uint);
			case DbType.UInt64:
				return typeof(ulong);
			case DbType.VarNumeric:
				return typeof(decimal);
			case DbType.AnsiStringFixedLength:
				return typeof(string);
			case DbType.StringFixedLength:
				return typeof(string);
			case DbType.Xml:
				return typeof(XmlDocument);
			case DbType.DateTime2:
				return typeof(DateTime);
			case DbType.DateTimeOffset:
				return typeof(DateTimeOffset);
			}
			return typeof(object);
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x00018388 File Offset: 0x00017388
		public static Type GetSystemType(SqlDbType type)
		{
			switch (type)
			{
			case SqlDbType.BigInt:
				return typeof(long);
			case SqlDbType.Binary:
				return typeof(byte[]);
			case SqlDbType.Bit:
				return typeof(bool);
			case SqlDbType.Char:
				return typeof(string);
			case SqlDbType.DateTime:
				return typeof(DateTime);
			case SqlDbType.Decimal:
				return typeof(decimal);
			case SqlDbType.Float:
				return typeof(double);
			case SqlDbType.Image:
				return typeof(byte[]);
			case SqlDbType.Int:
				return typeof(int);
			case SqlDbType.Money:
				return typeof(decimal);
			case SqlDbType.NChar:
				return typeof(string);
			case SqlDbType.NText:
				return typeof(string);
			case SqlDbType.NVarChar:
				return typeof(string);
			case SqlDbType.Real:
				return typeof(float);
			case SqlDbType.UniqueIdentifier:
				return typeof(Guid);
			case SqlDbType.SmallDateTime:
				return typeof(DateTime);
			case SqlDbType.SmallInt:
				return typeof(short);
			case SqlDbType.SmallMoney:
				return typeof(decimal);
			case SqlDbType.Text:
				return typeof(string);
			case SqlDbType.Timestamp:
				return typeof(DateTime);
			case SqlDbType.TinyInt:
				return typeof(byte);
			case SqlDbType.VarBinary:
				return typeof(byte[]);
			case SqlDbType.VarChar:
				return typeof(string);
			case SqlDbType.Variant:
				return typeof(object);
			case SqlDbType.Xml:
				return typeof(XmlDocument);
			case SqlDbType.Date:
				return typeof(DateTime);
			case SqlDbType.Time:
				return typeof(DateTime);
			case SqlDbType.DateTime2:
				return typeof(DateTime);
			case SqlDbType.DateTimeOffset:
				return typeof(DateTimeOffset);
			}
			return typeof(object);
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x00018578 File Offset: 0x00017578
		public static ExtendedPropertyCollection MergeExtendedProperties(ExtendedPropertyCollection target, ExtendedPropertyCollection source)
		{
			if (target == null)
			{
				target = new ExtendedPropertyCollection();
			}
			if (source == null)
			{
				return target;
			}
			foreach (ExtendedProperty extendedProperty in source)
			{
				if (!target.Contains(extendedProperty.Name))
				{
					target.Add(new ExtendedProperty(extendedProperty.Name, extendedProperty.Value, extendedProperty.DataType));
				}
			}
			return target;
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x000185FC File Offset: 0x000175FC
		// Note: this type is marked as 'beforefieldinit'.
		static SchemaUtility()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (SchemaUtility.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x060005B8 RID: 1464
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
