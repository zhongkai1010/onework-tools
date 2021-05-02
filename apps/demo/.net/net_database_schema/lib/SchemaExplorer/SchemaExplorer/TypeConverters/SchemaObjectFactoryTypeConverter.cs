using System;
using System.ComponentModel;
using System.Globalization;
using CodeSmith.Engine;
using SchemaExplorer.Serialization;

namespace SchemaExplorer.TypeConverters
{
	// Token: 0x020000B7 RID: 183
	public class SchemaObjectFactoryTypeConverter : TypeConverter
	{
		// Token: 0x06000638 RID: 1592 RVA: 0x0001938C File Offset: 0x0001838C
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x000193AC File Offset: 0x000183AC
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (context == null || context.PropertyDescriptor == null || !(value is string))
			{
				return base.ConvertFrom(context, culture, value);
			}
			IPropertySerializer propertySerializer = SchemaObjectFactorySerializer.Create(context.PropertyDescriptor.PropertyType);
			if (propertySerializer == null)
			{
				return base.ConvertFrom(context, culture, value);
			}
			return propertySerializer.ParseDefaultValue(new PropertySerializerContext(context), value as string);
		}
	}
}
