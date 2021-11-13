using System;
using System.ComponentModel;
using System.Globalization;

namespace SchemaExplorer.TypeConverters
{
	// Token: 0x020000B8 RID: 184
	public class SchemaSelectorTypeConverter : TypeConverter
	{
		// Token: 0x0600063B RID: 1595 RVA: 0x00019410 File Offset: 0x00018410
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return base.CanConvertFrom(context, sourceType);
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x0001941C File Offset: 0x0001841C
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return base.CanConvertTo(context, destinationType);
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x00019428 File Offset: 0x00018428
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			return base.ConvertFrom(context, culture, value);
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x00019434 File Offset: 0x00018434
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
