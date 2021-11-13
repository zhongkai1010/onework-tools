using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;
using #Nk;
using CodeSmith.Engine;

namespace SchemaExplorer.Serialization
{
	// Token: 0x020000C2 RID: 194
	public class SchemaSelectorSerializer : IPropertySerializer
	{
		// Token: 0x0600068C RID: 1676 RVA: 0x0001AD50 File Offset: 0x00019D50
		public object SaveProperty(PropertySerializerContext context, object propertyValue)
		{
			return propertyValue;
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x0001AD54 File Offset: 0x00019D54
		public object LoadProperty(PropertySerializerContext context, object propertyValue)
		{
			return propertyValue;
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0001AD58 File Offset: 0x00019D58
		public object ParseDefaultValue(PropertySerializerContext context, string defaultValue)
		{
			return null;
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0001AD5C File Offset: 0x00019D5C
		public object ReadPropertyXml(PropertySerializerContext context, XmlNode propertyValue)
		{
			XPathNavigator xpathNavigator = propertyValue.CreateNavigator();
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xpathNavigator.NameTable);
			xmlNamespaceManager.AddNamespace(#Mk.#Lk(13817), #Mk.#Lk(13822));
			XPathExpression expr = XPathExpression.Compile(#Mk.#Lk(14023), xmlNamespaceManager);
			string text = xpathNavigator.Evaluate(expr) as string;
			XPathExpression expr2 = XPathExpression.Compile(#Mk.#Lk(14072), xmlNamespaceManager);
			string text2 = xpathNavigator.Evaluate(expr2) as string;
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2))
			{
				return null;
			}
			SchemaSelector schemaSelector = this.#11c(text, text2);
			if (schemaSelector == null)
			{
				return null;
			}
			XPathExpression expr3 = XPathExpression.Compile(#Mk.#Lk(14113), xmlNamespaceManager);
			string value = xpathNavigator.Evaluate(expr3) as string;
			SelectMode selectMode;
			if (Enum.TryParse<SelectMode>(value, out selectMode))
			{
				schemaSelector.SelectMode = selectMode;
			}
			schemaSelector.SelectedTables = SchemaSelectorSerializer.#21c(xpathNavigator, xmlNamespaceManager, #Mk.#Lk(14146));
			schemaSelector.SelectedColumns = SchemaSelectorSerializer.#21c(xpathNavigator, xmlNamespaceManager, #Mk.#Lk(14171));
			schemaSelector.SelectedCommands = SchemaSelectorSerializer.#21c(xpathNavigator, xmlNamespaceManager, #Mk.#Lk(14200));
			schemaSelector.SchemaExpressions = SchemaSelectorSerializer.#21c(xpathNavigator, xmlNamespaceManager, #Mk.#Lk(14233));
			schemaSelector.ColumnExpressions = SchemaSelectorSerializer.#21c(xpathNavigator, xmlNamespaceManager, #Mk.#Lk(14282));
			return schemaSelector;
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0001AEA8 File Offset: 0x00019EA8
		public void WritePropertyXml(PropertySerializerContext context, XmlWriter writer, object propertyValue)
		{
			if (propertyValue == null)
			{
				return;
			}
			SchemaSelector schemaSelector = propertyValue as SchemaSelector;
			if (schemaSelector == null)
			{
				return;
			}
			Type type = schemaSelector.Provider.GetType();
			string value = string.Format(#Mk.#Lk(14331), type.FullName, type.Assembly.GetName().Name);
			writer.WriteElementString(#Mk.#Lk(14344), schemaSelector.ConnectionString);
			writer.WriteElementString(#Mk.#Lk(12158), value);
			writer.WriteElementString(#Mk.#Lk(14369), schemaSelector.SelectMode.ToString());
			SchemaSelectorSerializer.#vEb(writer, schemaSelector.SelectedTables, #Mk.#Lk(14378), #Mk.#Lk(14387));
			SchemaSelectorSerializer.#vEb(writer, schemaSelector.SelectedColumns, #Mk.#Lk(14396), #Mk.#Lk(14409));
			SchemaSelectorSerializer.#vEb(writer, schemaSelector.SelectedCommands, #Mk.#Lk(14418), #Mk.#Lk(14431));
			SchemaSelectorSerializer.#vEb(writer, schemaSelector.SchemaExpressions, #Mk.#Lk(14444), #Mk.#Lk(14469));
			SchemaSelectorSerializer.#vEb(writer, schemaSelector.ColumnExpressions, #Mk.#Lk(14486), #Mk.#Lk(14469));
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0001AFE4 File Offset: 0x00019FE4
		private SchemaSelector #11c(string #JMb, string #N0c)
		{
			SchemaProvider schemaProvider = new SchemaProvider(#N0c);
			IDbSchemaProvider dbSchemaProvider = schemaProvider.CreateProvider();
			if (dbSchemaProvider == null)
			{
				return null;
			}
			return new SchemaSelector(dbSchemaProvider, #JMb);
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0001B010 File Offset: 0x0001A010
		private static HashSet<string> #21c(XPathNavigator #31c, XmlNamespaceManager #41c, string #51c)
		{
			HashSet<string> hashSet = new HashSet<string>();
			XPathExpression expr = XPathExpression.Compile(#Mk.#Lk(14511), #41c);
			XPathExpression expr2 = XPathExpression.Compile(#51c, #41c);
			XPathNodeIterator xpathNodeIterator = #31c.Select(expr2);
			while (xpathNodeIterator.MoveNext())
			{
				XPathNavigator xpathNavigator = xpathNodeIterator.Current;
				string text = xpathNavigator.Evaluate(expr) as string;
				if (!string.IsNullOrEmpty(text))
				{
					hashSet.Add(text);
				}
			}
			return hashSet;
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0001B074 File Offset: 0x0001A074
		private static void #vEb(XmlWriter #Ix, ICollection<string> #lz, string #Ofb, string #n3)
		{
			if (#lz.Count <= 0)
			{
				return;
			}
			#Ix.WriteStartElement(#Ofb);
			foreach (string value in #lz)
			{
				#Ix.WriteElementString(#n3, value);
			}
			#Ix.WriteEndElement();
		}
	}
}
