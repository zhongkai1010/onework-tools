using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Xml;
using System.Xml.XPath;
using #Nk;
using CodeSmith.Core.Extensions;
using CodeSmith.Engine;

namespace SchemaExplorer.Serialization
{
	// Token: 0x020000BC RID: 188
	public class SchemaObjectSerializer : DatabaseSchemaSerializer
	{
		// Token: 0x0600064F RID: 1615 RVA: 0x0001995C File Offset: 0x0001895C
		public SchemaObjectSerializer(string objectName, Func<IDatabaseSchema, string, string, ISchemaObject> findFunction)
		{
			this.ObjectName = objectName.ToCamelCase();
			this.Find = findFunction;
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000650 RID: 1616 RVA: 0x00019978 File Offset: 0x00018978
		// (set) Token: 0x06000651 RID: 1617 RVA: 0x00019980 File Offset: 0x00018980
		protected string ObjectName { get; set; }

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000652 RID: 1618 RVA: 0x0001998C File Offset: 0x0001898C
		// (set) Token: 0x06000653 RID: 1619 RVA: 0x00019994 File Offset: 0x00018994
		protected Func<IDatabaseSchema, string, string, ISchemaObject> Find { get; set; }

		// Token: 0x06000654 RID: 1620 RVA: 0x000199A0 File Offset: 0x000189A0
		public override object ReadPropertyXml(PropertySerializerContext context, XmlNode propertyValue)
		{
			IList list2;
			if (!base.IsCollection(context.PropertyInfo.PropertyType))
			{
				IList list = new SchemaObjectBaseCollection();
				list2 = list;
			}
			else
			{
				list2 = (Activator.CreateInstance(context.PropertyInfo.PropertyType) as IList);
			}
			IList list3 = list2;
			if (list3 == null)
			{
				return null;
			}
			XPathNavigator xpathNavigator = propertyValue.CreateNavigator();
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xpathNavigator.NameTable);
			xmlNamespaceManager.AddNamespace(#Mk.#Lk(13817), #Mk.#Lk(13822));
			IDatabaseSchema databaseSchema = base.CreateDatabaseSchemaFromNavigator(xpathNavigator);
			if (databaseSchema == null)
			{
				return null;
			}
			XPathNodeIterator xpathNodeIterator = null;
			foreach (string xpath in this.GetSchemaObjectExpressions(context))
			{
				XPathExpression expr = XPathExpression.Compile(xpath, xmlNamespaceManager);
				xpathNodeIterator = xpathNavigator.Select(expr);
				if (xpathNodeIterator.Count > 0)
				{
					break;
				}
			}
			if (xpathNodeIterator == null)
			{
				return null;
			}
			DatabaseSchemaSerializer.SetDeepLoad(context, databaseSchema);
			DatabaseSchemaSerializer.SetIncludeFunctions(context, databaseSchema);
			foreach (object obj in xpathNodeIterator)
			{
				XPathNavigator node = (XPathNavigator)obj;
				ISchemaObject schemaObjectFromNavigator = this.GetSchemaObjectFromNavigator(context, databaseSchema, node, xmlNamespaceManager);
				if (schemaObjectFromNavigator != null)
				{
					list3.Add(schemaObjectFromNavigator);
				}
			}
			if (base.IsCollection(context.PropertyInfo.PropertyType))
			{
				return list3;
			}
			if (list3.Count == 1)
			{
				return list3[0];
			}
			return null;
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x00019B04 File Offset: 0x00018B04
		protected virtual string[] GetSchemaObjectExpressions(PropertySerializerContext context)
		{
			return new string[]
			{
				base.IsCollection(context.PropertyInfo.PropertyType) ? (#Mk.#Lk(13536) + this.ObjectName + #Mk.#Lk(13541) + this.ObjectName) : ((#Mk.#Lk(13536) + this.ObjectName) ?? #Mk.#Lk(2068))
			};
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x00019B78 File Offset: 0x00018B78
		protected virtual string[] GetOwnerExpressions(PropertySerializerContext context)
		{
			return new string[]
			{
				#Mk.#Lk(13883)
			};
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x00019B90 File Offset: 0x00018B90
		protected virtual string[] GetNameExpressions(PropertySerializerContext context)
		{
			return new string[]
			{
				#Mk.#Lk(13609),
				#Mk.#Lk(13554) + this.ObjectName + #Mk.#Lk(13592)
			};
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x00019BC8 File Offset: 0x00018BC8
		protected virtual ISchemaObject GetSchemaObjectFromNavigator(PropertySerializerContext context, IDatabaseSchema databaseSchema, XPathNavigator node, XmlNamespaceManager manager)
		{
			string text = null;
			string text2 = null;
			foreach (string xpath in this.GetOwnerExpressions(context))
			{
				XPathExpression expr = XPathExpression.Compile(xpath, manager);
				text = (node.Evaluate(expr) as string);
				if (!string.IsNullOrEmpty(text))
				{
					break;
				}
			}
			foreach (string xpath2 in this.GetNameExpressions(context))
			{
				XPathExpression expr2 = XPathExpression.Compile(xpath2, manager);
				text2 = (node.Evaluate(expr2) as string);
				if (!string.IsNullOrEmpty(text2))
				{
					break;
				}
			}
			if (string.IsNullOrEmpty(text2))
			{
				return null;
			}
			return this.Find(databaseSchema, text, text2);
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x00019C74 File Offset: 0x00018C74
		public override void WritePropertyXml(PropertySerializerContext context, XmlWriter writer, object propertyValue)
		{
			if (propertyValue == null)
			{
				return;
			}
			if (base.IsCollection(context.PropertyInfo.PropertyType))
			{
				SchemaObjectCollection<ISchemaObject> schemaObjectCollection = new SchemaObjectCollection<ISchemaObject>(propertyValue as IEnumerable<ISchemaObject>);
				if (schemaObjectCollection.Count == 0)
				{
					return;
				}
				ISchemaObject schemaObject = schemaObjectCollection.FirstOrDefault(new Func<ISchemaObject, bool>(SchemaObjectSerializer.<>c.<>9.#g6c));
				if (schemaObject == null)
				{
					return;
				}
				base.WritePropertyXml(context, writer, schemaObject.Database);
				writer.WriteStartElement(this.ObjectName + #Mk.#Lk(13916));
				foreach (ISchemaObject schemaObject2 in schemaObjectCollection)
				{
					SchemaObjectBase schemaObject3 = (SchemaObjectBase)schemaObject2;
					this.WriteSchemaObjectXml(writer, schemaObject3);
					writer.WriteEndElement();
				}
				writer.WriteEndElement();
				return;
			}
			else
			{
				ISchemaObject schemaObject4 = propertyValue as ISchemaObject;
				if (schemaObject4 == null || string.IsNullOrWhiteSpace(schemaObject4.Name))
				{
					return;
				}
				base.WritePropertyXml(context, writer, schemaObject4.Database);
				this.WriteSchemaObjectXml(writer, schemaObject4);
				writer.WriteEndElement();
				return;
			}
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x00019D8C File Offset: 0x00018D8C
		protected virtual void WriteSchemaObjectXml(XmlWriter writer, ISchemaObject schemaObject)
		{
			ISchemaObjectWithOwner schemaObjectWithOwner = schemaObject as ISchemaObjectWithOwner;
			writer.WriteStartElement(this.ObjectName);
			if (schemaObjectWithOwner != null)
			{
				writer.WriteElementString(#Mk.#Lk(13925), schemaObjectWithOwner.Owner);
			}
			writer.WriteElementString(#Mk.#Lk(1534), schemaObject.Name);
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x00019DDC File Offset: 0x00018DDC
		public override object ParseDefaultValue(PropertySerializerContext context, string defaultValue)
		{
			if (!base.IsCollection(context.PropertyInfo.PropertyType))
			{
				return this.GetSchemaObjectFromName(defaultValue, context.PropertyInfo.GetValue(context.Instance, null));
			}
			IList list = Activator.CreateInstance(context.PropertyInfo.PropertyType) as IList;
			if (list == null)
			{
				return null;
			}
			string[] array = defaultValue.Split(new char[]
			{
				','
			});
			foreach (string text in array)
			{
				ISchemaObject schemaObjectFromName = this.GetSchemaObjectFromName(text.Trim(), context.PropertyInfo.GetValue(context.Instance, null));
				if (schemaObjectFromName != null)
				{
					list.Add(schemaObjectFromName);
				}
			}
			return list;
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x00019E88 File Offset: 0x00018E88
		public ISchemaObject GetSchemaObjectFromName(string objectName, object currentValue)
		{
			if (string.IsNullOrEmpty(objectName))
			{
				return null;
			}
			string arg = string.Empty;
			string[] array = objectName.Split(new char[]
			{
				'.'
			});
			string arg2;
			IDatabaseSchema databaseSchema;
			if (array.Length == 2)
			{
				arg2 = array[1];
				databaseSchema = DatabaseSchemaSerializer.GetDatabaseSchemaFromName(array[0]);
				if (databaseSchema == null)
				{
					arg = array[0];
					if (currentValue is IList && ((IList)currentValue).Count > 0 && ((IList)currentValue)[0] is ISchemaObject)
					{
						databaseSchema = ((ISchemaObject)((IList)currentValue)[0]).Database;
					}
					else if (currentValue is ISchemaObject)
					{
						databaseSchema = ((ISchemaObject)currentValue).Database;
					}
				}
			}
			else
			{
				if (array.Length != 3)
				{
					throw new ApplicationException(#Mk.#Lk(13934));
				}
				databaseSchema = DatabaseSchemaSerializer.GetDatabaseSchemaFromName(array[0]);
				arg = array[1];
				arg2 = array[2];
			}
			if (databaseSchema == null)
			{
				throw new ApplicationException(#Mk.#Lk(13934));
			}
			return this.Find(databaseSchema, arg, arg2);
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x00019F78 File Offset: 0x00018F78
		// Note: this type is marked as 'beforefieldinit'.
		static SchemaObjectSerializer()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (SchemaObjectSerializer.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x0600065E RID: 1630
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x04000244 RID: 580
		[CompilerGenerated]
		private string #Z1c;

		// Token: 0x04000245 RID: 581
		[CompilerGenerated]
		private Func<IDatabaseSchema, string, string, ISchemaObject> #01c;
	}
}
