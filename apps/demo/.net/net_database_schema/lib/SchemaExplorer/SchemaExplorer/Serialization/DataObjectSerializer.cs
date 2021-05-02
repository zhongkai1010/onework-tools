using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.XPath;
using #Nk;
using CodeSmith.Core.Extensions;
using CodeSmith.Engine;

namespace SchemaExplorer.Serialization
{
	// Token: 0x020000B9 RID: 185
	public class DataObjectSerializer : SchemaObjectSerializer
	{
		// Token: 0x06000640 RID: 1600 RVA: 0x0001944C File Offset: 0x0001844C
		public DataObjectSerializer(string objectName, Func<IDatabaseSchema, string, string, ISchemaObject> findFunction) : base(objectName, findFunction)
		{
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x00019458 File Offset: 0x00018458
		protected override string[] GetSchemaObjectExpressions(PropertySerializerContext context)
		{
			return new string[]
			{
				base.IsCollection(context.PropertyInfo.PropertyType) ? (#Mk.#Lk(13536) + base.ObjectName + #Mk.#Lk(13541) + base.ObjectName) : ((#Mk.#Lk(13536) + base.ObjectName) ?? #Mk.#Lk(2068)),
				base.IsCollection(context.PropertyInfo.PropertyType) ? (#Mk.#Lk(13536) + this.#X1c(base.ObjectName) + #Mk.#Lk(13541) + this.#X1c(base.ObjectName)) : ((#Mk.#Lk(13536) + this.#X1c(base.ObjectName)) ?? #Mk.#Lk(2068))
			};
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x00019540 File Offset: 0x00018540
		protected override string[] GetOwnerExpressions(PropertySerializerContext context)
		{
			return new string[]
			{
				#Mk.#Lk(13554) + this.#Y1c(base.ObjectName) + #Mk.#Lk(13571)
			};
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x00019570 File Offset: 0x00018570
		protected override string[] GetNameExpressions(PropertySerializerContext context)
		{
			return new string[]
			{
				#Mk.#Lk(13554) + this.#Y1c(base.ObjectName) + #Mk.#Lk(13592)
			};
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x000195A0 File Offset: 0x000185A0
		protected virtual string[] GetObjectNameExpressions(PropertySerializerContext context)
		{
			return new string[]
			{
				#Mk.#Lk(13609)
			};
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x000195B8 File Offset: 0x000185B8
		private string #X1c(string #js)
		{
			string[] array = #js.ToWords();
			if (array.Length <= 1)
			{
				return string.Empty;
			}
			return array[1].ToLower();
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x000195E0 File Offset: 0x000185E0
		private string #Y1c(string #js)
		{
			string[] array = #js.ToWords();
			if (array.Length == 0)
			{
				return string.Empty;
			}
			return array[0].ToLower();
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x00019608 File Offset: 0x00018608
		protected override ISchemaObject GetSchemaObjectFromNavigator(PropertySerializerContext context, IDatabaseSchema databaseSchema, XPathNavigator node, XmlNamespaceManager manager)
		{
			DataObjectSerializer.#Lj #Lj = new DataObjectSerializer.#Lj();
			ITabularObject tabularObject = base.GetSchemaObjectFromNavigator(context, databaseSchema, node, manager) as ITabularObject;
			if (tabularObject == null)
			{
				return null;
			}
			#Lj.#4r = null;
			foreach (string xpath in this.GetObjectNameExpressions(context))
			{
				XPathExpression expr = XPathExpression.Compile(xpath, manager);
				#Lj.#4r = (node.Evaluate(expr) as string);
				if (!string.IsNullOrEmpty(#Lj.#4r))
				{
					break;
				}
			}
			if (string.IsNullOrEmpty(#Lj.#4r))
			{
				return null;
			}
			return tabularObject.DataObjects.FirstOrDefault(new Func<IDataObject, bool>(#Lj.#75c));
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x000196A4 File Offset: 0x000186A4
		protected override void WriteSchemaObjectXml(XmlWriter writer, ISchemaObject schemaObject)
		{
			IDataObject dataObject = schemaObject as IDataObject;
			if (dataObject == null)
			{
				return;
			}
			ISchemaObjectWithOwner schemaObjectWithOwner = dataObject.Parent as ISchemaObjectWithOwner;
			writer.WriteStartElement(base.ObjectName);
			if (schemaObjectWithOwner != null)
			{
				writer.WriteElementString(this.#Y1c(base.ObjectName) + #Mk.#Lk(13642), schemaObjectWithOwner.Owner);
			}
			writer.WriteElementString(this.#Y1c(base.ObjectName) + #Mk.#Lk(12136), dataObject.Parent.Name);
			writer.WriteElementString(#Mk.#Lk(1534), dataObject.Name);
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x00019740 File Offset: 0x00018740
		public override object ParseDefaultValue(PropertySerializerContext context, string defaultValue)
		{
			if (!base.IsCollection(context.PropertyInfo.PropertyType))
			{
				return this.GetDataObjectFromName(defaultValue, context.PropertyInfo.GetValue(context.Instance, null));
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
				ISchemaObject dataObjectFromName = this.GetDataObjectFromName(text.Trim(), context.PropertyInfo.GetValue(context.Instance, null));
				if (dataObjectFromName != null)
				{
					list.Add(dataObjectFromName);
				}
			}
			return list;
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x000197EC File Offset: 0x000187EC
		public IDataObject GetDataObjectFromName(string objectName, object currentValue)
		{
			DataObjectSerializer.#Ti #Ti = new DataObjectSerializer.#Ti();
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
			if (array.Length == 3)
			{
				arg2 = array[1];
				#Ti.#4r = array[2];
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
				if (array.Length != 4)
				{
					throw new ApplicationException(#Mk.#Lk(13651));
				}
				databaseSchema = DatabaseSchemaSerializer.GetDatabaseSchemaFromName(array[0]);
				arg = array[1];
				arg2 = array[2];
				#Ti.#4r = array[3];
			}
			if (databaseSchema == null)
			{
				throw new ApplicationException(#Mk.#Lk(13651));
			}
			ITabularObject tabularObject = base.Find(databaseSchema, arg, arg2) as ITabularObject;
			if (tabularObject == null)
			{
				return null;
			}
			return tabularObject.DataObjects.FirstOrDefault(new Func<IDataObject, bool>(#Ti.#85c));
		}

		// Token: 0x020000BA RID: 186
		[CompilerGenerated]
		private sealed class #Lj
		{
			// Token: 0x0600064C RID: 1612 RVA: 0x0001992C File Offset: 0x0001892C
			internal bool #75c(IDataObject #FN)
			{
				return #FN.Name.Equals(this.#4r, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000242 RID: 578
			public string #4r;
		}

		// Token: 0x020000BB RID: 187
		[CompilerGenerated]
		private sealed class #Ti
		{
			// Token: 0x0600064E RID: 1614 RVA: 0x00019948 File Offset: 0x00018948
			internal bool #85c(IDataObject #FN)
			{
				return #FN.Name.Equals(this.#4r, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000243 RID: 579
			public string #4r;
		}
	}
}
