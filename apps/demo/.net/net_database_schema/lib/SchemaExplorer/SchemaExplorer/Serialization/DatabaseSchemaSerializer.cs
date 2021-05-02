using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.XPath;
using #Nk;
using CodeSmith.Engine;
using CodeSmith.Engine.Json;
using CodeSmith.Engine.Json.Linq;

namespace SchemaExplorer.Serialization
{
	// Token: 0x020000BE RID: 190
	public class DatabaseSchemaSerializer : JsonConverter, IPropertySerializer
	{
		// Token: 0x06000662 RID: 1634 RVA: 0x00019FE8 File Offset: 0x00018FE8
		public virtual object SaveProperty(PropertySerializerContext context, object propertyValue)
		{
			return propertyValue;
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x00019FEC File Offset: 0x00018FEC
		public virtual object LoadProperty(PropertySerializerContext context, object propertyValue)
		{
			if (propertyValue is string)
			{
				return this.ParseDefaultValue(context, propertyValue as string);
			}
			if (propertyValue is ISchemaObject)
			{
				DatabaseSchemaSerializer.SetDeepLoad(context, propertyValue as ISchemaObject);
				DatabaseSchemaSerializer.SetIncludeFunctions(context, propertyValue as ISchemaObject);
			}
			return propertyValue;
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x0001A028 File Offset: 0x00019028
		public virtual void WritePropertyXml(PropertySerializerContext context, XmlWriter writer, object propertyValue)
		{
			if (propertyValue == null)
			{
				return;
			}
			IDatabaseSchema databaseSchema = propertyValue as IDatabaseSchema;
			if (databaseSchema == null || databaseSchema.Provider == null)
			{
				return;
			}
			writer.WriteStartElement(#Mk.#Lk(14344));
			writer.WriteString(databaseSchema.ConnectionString);
			writer.WriteEndElement();
			Type type = databaseSchema.Provider.GetType();
			writer.WriteStartElement(#Mk.#Lk(12158));
			writer.WriteString(string.Format(#Mk.#Lk(14331), type.FullName, type.Assembly.GetName().Name));
			writer.WriteEndElement();
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x0001A0BC File Offset: 0x000190BC
		public virtual object ReadPropertyXml(PropertySerializerContext context, XmlNode propertyValue)
		{
			XPathNavigator navigator = propertyValue.CreateNavigator();
			IDatabaseSchema databaseSchema = this.CreateDatabaseSchemaFromNavigator(navigator);
			DatabaseSchemaSerializer.SetDeepLoad(context, databaseSchema);
			DatabaseSchemaSerializer.SetIncludeFunctions(context, databaseSchema);
			bool flag = databaseSchema != null && !string.IsNullOrEmpty(databaseSchema.ConnectionString);
			if (flag && !DataSourceManager.DataSources.Contains(databaseSchema.Name))
			{
				DataSource dataSource = new DataSource(databaseSchema.Name, databaseSchema.ConnectionString, databaseSchema.Provider.GetType());
				DataSourceManager.Save(dataSource);
			}
			return databaseSchema;
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x0001A134 File Offset: 0x00019134
		public static void SetDeepLoad(PropertySerializerContext context, ISchemaObject schemaObject)
		{
			if (context == null || schemaObject == null || context.Instance == null || context.PropertyInfo == null)
			{
				return;
			}
			string propertyAttribute = context.Instance.GetPropertyAttribute(context.PropertyInfo.Name, #Mk.#Lk(14532));
			if (string.IsNullOrEmpty(propertyAttribute))
			{
				return;
			}
			bool flag;
			bool.TryParse(propertyAttribute, out flag);
			if (schemaObject.DeepLoad != flag || schemaObject.Database.DeepLoad != flag)
			{
				schemaObject.DeepLoad = flag;
				schemaObject.Database.DeepLoad = flag;
				if (flag)
				{
					schemaObject.Refresh();
					if (!(schemaObject is IDatabaseSchema))
					{
						schemaObject.Database.Refresh();
					}
				}
			}
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x0001A1D8 File Offset: 0x000191D8
		public static void SetIncludeFunctions(PropertySerializerContext context, ISchemaObject schemaObject)
		{
			if (context == null || schemaObject == null || context.Instance == null || context.PropertyInfo == null)
			{
				return;
			}
			string propertyAttribute = context.Instance.GetPropertyAttribute(context.PropertyInfo.Name, #Mk.#Lk(14545));
			if (string.IsNullOrEmpty(propertyAttribute))
			{
				return;
			}
			bool flag;
			bool.TryParse(propertyAttribute, out flag);
			if (schemaObject.IncludeFunctions != flag || schemaObject.Database.IncludeFunctions != flag)
			{
				schemaObject.IncludeFunctions = flag;
				schemaObject.Database.IncludeFunctions = flag;
				schemaObject.Refresh();
				if (!(schemaObject is IDatabaseSchema))
				{
					schemaObject.Database.Refresh();
				}
			}
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x0001A278 File Offset: 0x00019278
		protected IDatabaseSchema CreateDatabaseSchemaFromNavigator(XPathNavigator navigator)
		{
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(navigator.NameTable);
			xmlNamespaceManager.AddNamespace(#Mk.#Lk(13817), #Mk.#Lk(13822));
			XPathExpression expr = XPathExpression.Compile(#Mk.#Lk(14023), xmlNamespaceManager);
			string text = navigator.Evaluate(expr) as string;
			XPathExpression expr2 = XPathExpression.Compile(#Mk.#Lk(14072), xmlNamespaceManager);
			string text2 = navigator.Evaluate(expr2) as string;
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2))
			{
				return null;
			}
			return this.CreateDatabaseSchemaInstance(text, text2);
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x0001A304 File Offset: 0x00019304
		protected IDatabaseSchema CreateDatabaseSchemaInstance(string connectionString, string providerType)
		{
			SchemaProvider schemaProvider = new SchemaProvider(providerType);
			IDbSchemaProvider dbSchemaProvider = schemaProvider.CreateProvider();
			if (dbSchemaProvider == null)
			{
				return null;
			}
			return new DatabaseSchema(dbSchemaProvider, connectionString);
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0001A330 File Offset: 0x00019330
		public virtual object ParseDefaultValue(PropertySerializerContext context, string defaultValue)
		{
			IDatabaseSchema databaseSchemaFromName = DatabaseSchemaSerializer.GetDatabaseSchemaFromName(defaultValue);
			DatabaseSchemaSerializer.SetDeepLoad(context, databaseSchemaFromName);
			DatabaseSchemaSerializer.SetIncludeFunctions(context, databaseSchemaFromName);
			return databaseSchemaFromName;
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x0001A354 File Offset: 0x00019354
		public static IDatabaseSchema GetDatabaseSchemaFromName(string dataSourceName)
		{
			if (string.IsNullOrWhiteSpace(dataSourceName))
			{
				throw new ArgumentNullException(#Mk.#Lk(14570));
			}
			dataSourceName = dataSourceName.Trim();
			if (!Configuration.Instance.DataSourceCollection.Contains(dataSourceName))
			{
				return null;
			}
			DataSource dataSource = Configuration.Instance.DataSourceCollection[dataSourceName];
			return dataSource.CreateInstance();
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0001A3B0 File Offset: 0x000193B0
		protected bool IsCollection(Type propertyType)
		{
			return typeof(IEnumerable<ISchemaObject>).IsAssignableFrom(propertyType);
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0001A3C4 File Offset: 0x000193C4
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			SchemaObjectCollection<ISchemaObject> schemaObjectCollection = new SchemaObjectCollection<ISchemaObject>();
			if (value is ISchemaObject)
			{
				schemaObjectCollection.Add(value as ISchemaObject);
			}
			if (value is IEnumerable<ISchemaObject>)
			{
				schemaObjectCollection.AddRange(value as IEnumerable<ISchemaObject>);
			}
			if (schemaObjectCollection.Count == 0)
			{
				return;
			}
			writer.WriteStartObject();
			writer.WritePropertyName(#Mk.#Lk(14344));
			writer.WriteValue(schemaObjectCollection[0].Database.ConnectionString);
			Type type = schemaObjectCollection[0].Database.Provider.GetType();
			writer.WritePropertyName(#Mk.#Lk(12158));
			writer.WriteValue(string.Format(#Mk.#Lk(14331), type.FullName, type.Assembly.GetName().Name));
			bool flag = schemaObjectCollection.Count == 1;
			if (!flag)
			{
				writer.WritePropertyName(#Mk.#Lk(14591));
				writer.WriteStartArray();
			}
			foreach (ISchemaObject #gDb in schemaObjectCollection)
			{
				if (!flag)
				{
					writer.WriteStartObject();
				}
				if (value is IDataObject)
				{
					this.#61c(writer, value, serializer);
				}
				else
				{
					this.#71c(writer, #gDb);
				}
				if (!flag)
				{
					writer.WriteEndObject();
				}
			}
			if (!flag)
			{
				writer.WriteEndArray();
			}
			writer.WriteEndObject();
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x0001A51C File Offset: 0x0001951C
		private void #61c(JsonWriter #Ix, object #am, JsonSerializer #Tlb)
		{
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x0001A520 File Offset: 0x00019520
		private void #71c(JsonWriter #Ix, ISchemaObject #gDb)
		{
			ISchemaObjectWithOwner schemaObjectWithOwner = #gDb as ISchemaObjectWithOwner;
			if (schemaObjectWithOwner != null)
			{
				#Ix.WritePropertyName(#Mk.#Lk(13925));
				#Ix.WriteValue(schemaObjectWithOwner.Owner);
			}
			#Ix.WritePropertyName(#Mk.#Lk(1534));
			#Ix.WriteValue(#gDb.Name);
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x0001A570 File Offset: 0x00019570
		public override object ReadJson(JsonReader reader, Type schemaType, object existingValue, JsonSerializer serializer)
		{
			JObject jobject = JObject.Load(reader);
			JToken value;
			if (!jobject.TryGetValue(#Mk.#Lk(14344), out value))
			{
				return null;
			}
			JToken value2;
			if (!jobject.TryGetValue(#Mk.#Lk(12158), out value2))
			{
				return null;
			}
			IDatabaseSchema databaseSchema = this.CreateDatabaseSchemaInstance(value.Value<string>(), value2.Value<string>());
			if (typeof(IDatabaseSchema).IsAssignableFrom(schemaType))
			{
				return databaseSchema;
			}
			if (typeof(ISchemaObject).IsAssignableFrom(schemaType))
			{
				return this.#81c(schemaType, jobject, databaseSchema);
			}
			if (!typeof(IEnumerable<ISchemaObject>).IsAssignableFrom(schemaType))
			{
				return databaseSchema;
			}
			List<ISchemaObject> list = new List<ISchemaObject>();
			ISchemaObjectWithOwner schemaObjectWithOwner = this.#81c(schemaType, jobject, databaseSchema);
			if (schemaObjectWithOwner != null)
			{
				list.Add(schemaObjectWithOwner);
			}
			if (jobject.Property(#Mk.#Lk(14591)) != null)
			{
				foreach (JToken jtoken in ((IEnumerable<JToken>)jobject[#Mk.#Lk(14591)]))
				{
					schemaObjectWithOwner = this.#81c(schemaType, jtoken as JObject, databaseSchema);
					if (schemaObjectWithOwner != null)
					{
						list.Add(schemaObjectWithOwner);
					}
				}
			}
			if (typeof(IEnumerable<ITableSchema>).IsAssignableFrom(schemaType))
			{
				return new TableSchemaCollection(list.Where(new Func<ISchemaObject, bool>(DatabaseSchemaSerializer.<>c.<>9.#h6c)).Cast<TableSchema>());
			}
			if (typeof(IEnumerable<ICommandSchema>).IsAssignableFrom(schemaType))
			{
				return new CommandSchemaCollection(list.Where(new Func<ISchemaObject, bool>(DatabaseSchemaSerializer.<>c.<>9.#i6c)).Cast<CommandSchema>());
			}
			if (typeof(IEnumerable<IViewSchema>).IsAssignableFrom(schemaType))
			{
				return new ViewSchemaCollection(list.Where(new Func<ISchemaObject, bool>(DatabaseSchemaSerializer.<>c.<>9.#j6c)).Cast<ViewSchema>());
			}
			if (typeof(IEnumerable<ITabularObject>).IsAssignableFrom(schemaType))
			{
				return new TabularObjectBaseCollection(list.Where(new Func<ISchemaObject, bool>(DatabaseSchemaSerializer.<>c.<>9.#k6c)).Cast<ITabularObject>());
			}
			return list;
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x0001A7B0 File Offset: 0x000197B0
		private ISchemaObjectWithOwner #81c(Type #91c, JObject #am, IDatabaseSchema #a2c)
		{
			string owner;
			string name;
			this.#b2c(#am, out owner, out name);
			if (typeof(ITableSchema).IsAssignableFrom(#91c) || typeof(IEnumerable<ITableSchema>).IsAssignableFrom(#91c))
			{
				return #a2c.Tables[owner, name];
			}
			if (typeof(ICommandSchema).IsAssignableFrom(#91c) || typeof(IEnumerable<ICommandSchema>).IsAssignableFrom(#91c))
			{
				return #a2c.Commands[owner, name];
			}
			if (typeof(IViewSchema).IsAssignableFrom(#91c) || typeof(IEnumerable<IViewSchema>).IsAssignableFrom(#91c))
			{
				return #a2c.Views[owner, name];
			}
			if (typeof(ITabularObject).IsAssignableFrom(#91c) || typeof(IEnumerable<ITabularObject>).IsAssignableFrom(#91c))
			{
				if (#a2c.Tables.Contains(owner, name))
				{
					return #a2c.Tables[owner, name];
				}
				if (#a2c.Views.Contains(owner, name))
				{
					return #a2c.Views[owner, name];
				}
			}
			return null;
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x0001A8C0 File Offset: 0x000198C0
		private void #b2c(JObject #am, out string #iV, out string #5n)
		{
			string text;
			#5n = (text = null);
			#iV = text;
			JToken value;
			if (#am.TryGetValue(#Mk.#Lk(13925), out value))
			{
				#iV = value.Value<string>();
			}
			JToken value2;
			if (#am.TryGetValue(#Mk.#Lk(1534), out value2))
			{
				#5n = value2.Value<string>();
			}
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x0001A910 File Offset: 0x00019910
		public override bool CanConvert(Type objectType)
		{
			return typeof(ISchemaObject).IsAssignableFrom(objectType);
		}
	}
}
