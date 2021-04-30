using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Xml;
using #Nk;
using CodeSmith.Engine;

namespace SchemaExplorer.Serialization
{
	// Token: 0x020000C0 RID: 192
	public class SchemaObjectFactorySerializer : IPropertySerializer
	{
		// Token: 0x0600067B RID: 1659 RVA: 0x0001A970 File Offset: 0x00019970
		public static IPropertySerializer Create(Type schemaType)
		{
			if (typeof(IDatabaseSchema).IsAssignableFrom(schemaType))
			{
				return new DatabaseSchemaSerializer();
			}
			if (typeof(ITableSchema).IsAssignableFrom(schemaType) || typeof(IEnumerable<ITableSchema>).IsAssignableFrom(schemaType))
			{
				return new SchemaObjectSerializer(#Mk.#Lk(13752), new Func<IDatabaseSchema, string, string, ISchemaObject>(SchemaObjectFactorySerializer.<>c.<>9.#95c));
			}
			if (typeof(ICommandSchema).IsAssignableFrom(schemaType) || typeof(IEnumerable<ICommandSchema>).IsAssignableFrom(schemaType))
			{
				return new SchemaObjectSerializer(#Mk.#Lk(13761), new Func<IDatabaseSchema, string, string, ISchemaObject>(SchemaObjectFactorySerializer.<>c.<>9.#b6c));
			}
			if (typeof(IViewSchema).IsAssignableFrom(schemaType) || typeof(IEnumerable<IViewSchema>).IsAssignableFrom(schemaType))
			{
				return new SchemaObjectSerializer(#Mk.#Lk(13774), new Func<IDatabaseSchema, string, string, ISchemaObject>(SchemaObjectFactorySerializer.<>c.<>9.#c6c));
			}
			if (typeof(IViewColumnSchema).IsAssignableFrom(schemaType) || typeof(IEnumerable<IViewColumnSchema>).IsAssignableFrom(schemaType))
			{
				return new DataObjectSerializer(#Mk.#Lk(13783), new Func<IDatabaseSchema, string, string, ISchemaObject>(SchemaObjectFactorySerializer.<>c.<>9.#d6c));
			}
			if (typeof(IColumnSchema).IsAssignableFrom(schemaType) || typeof(IEnumerable<IColumnSchema>).IsAssignableFrom(schemaType))
			{
				return new DataObjectSerializer(#Mk.#Lk(13800), new Func<IDatabaseSchema, string, string, ISchemaObject>(SchemaObjectFactorySerializer.<>c.<>9.#e6c));
			}
			if (typeof(ITabularObject).IsAssignableFrom(schemaType) || typeof(IEnumerable<ITabularObject>).IsAssignableFrom(schemaType))
			{
				return new SchemaObjectSerializer(#Mk.#Lk(13752), new Func<IDatabaseSchema, string, string, ISchemaObject>(SchemaObjectFactorySerializer.<>c.<>9.#f6c));
			}
			return null;
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x0001AB88 File Offset: 0x00019B88
		public object SaveProperty(PropertySerializerContext context, object propertyValue)
		{
			IPropertySerializer propertySerializer = SchemaObjectFactorySerializer.Create(context.PropertyInfo.PropertyType);
			return propertySerializer.SaveProperty(context, propertyValue);
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x0001ABB0 File Offset: 0x00019BB0
		public object LoadProperty(PropertySerializerContext context, object propertyValue)
		{
			IPropertySerializer propertySerializer = SchemaObjectFactorySerializer.Create(context.PropertyInfo.PropertyType);
			return propertySerializer.LoadProperty(context, propertyValue);
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x0001ABD8 File Offset: 0x00019BD8
		public void WritePropertyXml(PropertySerializerContext context, XmlWriter writer, object propertyValue)
		{
			IPropertySerializer propertySerializer = SchemaObjectFactorySerializer.Create(context.PropertyInfo.PropertyType);
			propertySerializer.WritePropertyXml(context, writer, propertyValue);
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x0001AC00 File Offset: 0x00019C00
		public object ReadPropertyXml(PropertySerializerContext context, XmlNode propertyValue)
		{
			IPropertySerializer propertySerializer = SchemaObjectFactorySerializer.Create(context.PropertyInfo.PropertyType);
			return propertySerializer.ReadPropertyXml(context, propertyValue);
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x0001AC28 File Offset: 0x00019C28
		public object ParseDefaultValue(PropertySerializerContext context, string defaultValue)
		{
			IPropertySerializer propertySerializer = SchemaObjectFactorySerializer.Create(context.PropertyInfo.PropertyType);
			return propertySerializer.ParseDefaultValue(context, defaultValue);
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x0001AC58 File Offset: 0x00019C58
		// Note: this type is marked as 'beforefieldinit'.
		static SchemaObjectFactorySerializer()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (SchemaObjectFactorySerializer.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000683 RID: 1667
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
