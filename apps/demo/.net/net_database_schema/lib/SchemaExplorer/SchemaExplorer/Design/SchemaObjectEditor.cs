using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using System.Windows.Input;
using #Nk;
using ActiproSoftware.Windows.Controls.PropertyGrid.Editors;
using ActiproSoftware.Windows.Controls.PropertyGrid.Primitives;
using CodeSmith.Core.Reflection;
using CodeSmith.Engine;

namespace SchemaExplorer.Design
{
	// Token: 0x020000D3 RID: 211
	public class SchemaObjectEditor : DialogPropertyEditor
	{
		// Token: 0x06000749 RID: 1865 RVA: 0x000222C8 File Offset: 0x000212C8
		public override void ShowDialog(object sender, ExecutedRoutedEventArgs e)
		{
			IPropertyDataAccessor propertyDataAccessor = e.Parameter as IPropertyDataAccessor;
			if (propertyDataAccessor == null)
			{
				return;
			}
			if (propertyDataAccessor.ValueType == typeof(ColumnSchema))
			{
				SchemaObjectEditor.#J3c(propertyDataAccessor);
			}
			else if (propertyDataAccessor.ValueType == typeof(ColumnSchemaCollection))
			{
				SchemaObjectEditor.#K3c(propertyDataAccessor);
			}
			else if (propertyDataAccessor.ValueType == typeof(CommandSchema))
			{
				SchemaObjectEditor.#L3c(propertyDataAccessor);
			}
			else if (propertyDataAccessor.ValueType == typeof(CommandSchemaCollection))
			{
				SchemaObjectEditor.#M3c(propertyDataAccessor);
			}
			else if (propertyDataAccessor.ValueType == typeof(DatabaseSchema))
			{
				SchemaObjectEditor.#a2c(propertyDataAccessor);
			}
			else if (propertyDataAccessor.ValueType == typeof(ExtendedPropertyCollection))
			{
				SchemaObjectEditor.#N3c(propertyDataAccessor);
			}
			else if (propertyDataAccessor.ValueType == typeof(TableSchema))
			{
				SchemaObjectEditor.#O3c(propertyDataAccessor);
			}
			else if (propertyDataAccessor.ValueType == typeof(TableSchemaCollection))
			{
				SchemaObjectEditor.#P3c(propertyDataAccessor);
			}
			else if (propertyDataAccessor.ValueType == typeof(TabularObjectBase))
			{
				SchemaObjectEditor.#Q3c(propertyDataAccessor);
			}
			else if (propertyDataAccessor.ValueType == typeof(TabularObjectBaseCollection))
			{
				SchemaObjectEditor.#R3c(propertyDataAccessor);
			}
			else if (propertyDataAccessor.ValueType == typeof(ViewColumnSchema))
			{
				SchemaObjectEditor.#S3c(propertyDataAccessor);
			}
			else if (propertyDataAccessor.ValueType == typeof(ViewSchema))
			{
				SchemaObjectEditor.#T3c(propertyDataAccessor);
			}
			else if (propertyDataAccessor.ValueType == typeof(ViewSchemaCollection))
			{
				SchemaObjectEditor.#U3c(propertyDataAccessor);
			}
			else
			{
				if (!(propertyDataAccessor.ValueType == typeof(SchemaSelector)))
				{
					return;
				}
				SchemaObjectEditor.#V3c(propertyDataAccessor);
			}
			e.Handled = true;
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x000224BC File Offset: 0x000214BC
		private static void #J3c(IPropertyDataAccessor #qp)
		{
			ColumnSchemaPickerUI columnSchemaPickerUI = new ColumnSchemaPickerUI();
			columnSchemaPickerUI.Start(#qp.Value);
			CodeTemplate codeTemplate = #qp.Target as CodeTemplate;
			if (codeTemplate != null)
			{
				string valueName = #qp.ValueName;
				string propertyAttribute = codeTemplate.GetPropertyAttribute(valueName, #Mk.#Lk(18350));
				if (!string.IsNullOrEmpty(propertyAttribute))
				{
					object propertyValue = ObjectCopier.GetPropertyValue(codeTemplate, propertyAttribute);
					columnSchemaPickerUI.Filter(propertyValue);
				}
			}
			if (columnSchemaPickerUI.ShowDialog() == DialogResult.OK)
			{
				#qp.Value = columnSchemaPickerUI.SelectedColumnSchema;
				SchemaObjectEditor.SetDeepLoad(#qp, #qp.Value as SchemaObjectBase);
			}
			#qp.Value = #qp.Value;
			columnSchemaPickerUI.End();
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x00022554 File Offset: 0x00021554
		private static void #K3c(IPropertyDataAccessor #qp)
		{
			ColumnSchemaPickerUI columnSchemaPickerUI = new ColumnSchemaPickerUI(true);
			columnSchemaPickerUI.Start(#qp.Value);
			CodeTemplate codeTemplate = #qp.Target as CodeTemplate;
			if (codeTemplate != null)
			{
				string valueName = #qp.ValueName;
				string propertyAttribute = codeTemplate.GetPropertyAttribute(valueName, #Mk.#Lk(18350));
				if (!string.IsNullOrEmpty(propertyAttribute))
				{
					object propertyValue = ObjectCopier.GetPropertyValue(codeTemplate, propertyAttribute);
					columnSchemaPickerUI.Filter(propertyValue);
				}
			}
			if (columnSchemaPickerUI.ShowDialog() == DialogResult.OK)
			{
				#qp.Value = columnSchemaPickerUI.SelectedColumnSchemaCollection;
				SchemaObjectEditor.SetDeepLoad(#qp, #qp.Value as SchemaObjectBase);
			}
			columnSchemaPickerUI.End();
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x000225E4 File Offset: 0x000215E4
		private static void #L3c(IPropertyDataAccessor #qp)
		{
			CommandSchemaPickerUI commandSchemaPickerUI = new CommandSchemaPickerUI();
			commandSchemaPickerUI.Start(#qp.Value);
			CodeTemplate codeTemplate = #qp.Target as CodeTemplate;
			if (codeTemplate != null)
			{
				string valueName = #qp.ValueName;
				string propertyAttribute = codeTemplate.GetPropertyAttribute(valueName, #Mk.#Lk(18350));
				if (!string.IsNullOrEmpty(propertyAttribute))
				{
					object propertyValue = ObjectCopier.GetPropertyValue(codeTemplate, propertyAttribute);
					commandSchemaPickerUI.Filter(propertyValue);
				}
				string propertyAttribute2 = codeTemplate.GetPropertyAttribute(valueName, #Mk.#Lk(14545));
				if (!string.IsNullOrEmpty(propertyAttribute2))
				{
					bool includeFunctions;
					bool.TryParse(propertyAttribute2, out includeFunctions);
					commandSchemaPickerUI.IncludeFunctions = includeFunctions;
				}
			}
			if (commandSchemaPickerUI.ShowDialog() == DialogResult.OK)
			{
				#qp.Value = commandSchemaPickerUI.SelectedCommandSchema;
				SchemaObjectEditor.SetDeepLoad(#qp, #qp.Value as SchemaObjectBase);
				SchemaObjectEditor.SetIncludeFunctions(#qp, #qp.Value as SchemaObjectBase);
			}
			commandSchemaPickerUI.End();
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x000226B0 File Offset: 0x000216B0
		private static void #M3c(IPropertyDataAccessor #qp)
		{
			CommandSchemaPickerUI commandSchemaPickerUI = new CommandSchemaPickerUI(true);
			commandSchemaPickerUI.Start(#qp.Value);
			CodeTemplate codeTemplate = #qp.Target as CodeTemplate;
			if (codeTemplate != null)
			{
				string valueName = #qp.ValueName;
				string propertyAttribute = codeTemplate.GetPropertyAttribute(valueName, #Mk.#Lk(18350));
				if (!string.IsNullOrEmpty(propertyAttribute))
				{
					object propertyValue = ObjectCopier.GetPropertyValue(codeTemplate, propertyAttribute);
					commandSchemaPickerUI.Filter(propertyValue);
				}
				string propertyAttribute2 = codeTemplate.GetPropertyAttribute(valueName, #Mk.#Lk(14545));
				if (!string.IsNullOrEmpty(propertyAttribute2))
				{
					bool includeFunctions;
					bool.TryParse(propertyAttribute2, out includeFunctions);
					commandSchemaPickerUI.IncludeFunctions = includeFunctions;
				}
			}
			if (commandSchemaPickerUI.ShowDialog() == DialogResult.OK)
			{
				#qp.Value = commandSchemaPickerUI.SelectedCommandSchemaCollection;
				SchemaObjectEditor.SetDeepLoad(#qp, #qp.Value as SchemaObjectBase);
			}
			commandSchemaPickerUI.End();
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x0002276C File Offset: 0x0002176C
		private static void #a2c(IPropertyDataAccessor #qp)
		{
			DatabaseSchemaPickerUI databaseSchemaPickerUI = new DatabaseSchemaPickerUI();
			databaseSchemaPickerUI.DatabaseSchema = (#qp.Value as DatabaseSchema);
			if (databaseSchemaPickerUI.ShowDialog() == DialogResult.OK)
			{
				#qp.Value = databaseSchemaPickerUI.DatabaseSchema;
				SchemaObjectEditor.SetDeepLoad(#qp, #qp.Value as SchemaObjectBase);
			}
			databaseSchemaPickerUI.End();
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x000227BC File Offset: 0x000217BC
		private static void #N3c(IPropertyDataAccessor #qp)
		{
			SchemaObjectBase schemaObjectBase = #qp.Target as SchemaObjectBase;
			ExtendedPropertyEditorUI extendedPropertyEditorUI = new ExtendedPropertyEditorUI();
			extendedPropertyEditorUI.Start(#qp.Value, (schemaObjectBase != null) ? schemaObjectBase.ToString() : null);
			if (extendedPropertyEditorUI.ShowDialog() == DialogResult.OK)
			{
				#qp.Value = extendedPropertyEditorUI.ExtendedPropertyCollection;
				if (schemaObjectBase != null && extendedPropertyEditorUI.IsDirty)
				{
					schemaObjectBase.Database.Provider.SetExtendedProperties(schemaObjectBase.Database.ConnectionString, schemaObjectBase);
				}
			}
			extendedPropertyEditorUI.End();
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x00022838 File Offset: 0x00021838
		private static void #O3c(IPropertyDataAccessor #qp)
		{
			TableSchemaPickerUI tableSchemaPickerUI = new TableSchemaPickerUI();
			tableSchemaPickerUI.Start(#qp.Value);
			if (tableSchemaPickerUI.ShowDialog() == DialogResult.OK)
			{
				#qp.Value = tableSchemaPickerUI.SelectedTableSchema;
				SchemaObjectEditor.SetDeepLoad(#qp, #qp.Value as SchemaObjectBase);
			}
			tableSchemaPickerUI.End();
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x00022884 File Offset: 0x00021884
		private static void #P3c(IPropertyDataAccessor #qp)
		{
			TableSchemaPickerUI tableSchemaPickerUI = new TableSchemaPickerUI(true);
			tableSchemaPickerUI.Start(#qp.Value);
			if (tableSchemaPickerUI.ShowDialog() == DialogResult.OK)
			{
				#qp.Value = tableSchemaPickerUI.SelectedTableSchemaCollection;
				SchemaObjectEditor.SetDeepLoad(#qp, #qp.Value as SchemaObjectBase);
			}
			tableSchemaPickerUI.End();
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x000228D0 File Offset: 0x000218D0
		private static void #Q3c(IPropertyDataAccessor #qp)
		{
			TabularObjectBasePickerUI tabularObjectBasePickerUI = new TabularObjectBasePickerUI();
			tabularObjectBasePickerUI.Start(#qp.Value);
			if (tabularObjectBasePickerUI.ShowDialog() == DialogResult.OK)
			{
				#qp.Value = tabularObjectBasePickerUI.SelectedTabularObjectBase;
				SchemaObjectEditor.SetDeepLoad(#qp, #qp.Value as SchemaObjectBase);
			}
			tabularObjectBasePickerUI.End();
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x0002291C File Offset: 0x0002191C
		private static void #R3c(IPropertyDataAccessor #qp)
		{
			TabularObjectBasePickerUI tabularObjectBasePickerUI = new TabularObjectBasePickerUI(true);
			tabularObjectBasePickerUI.Start(#qp.Value);
			if (tabularObjectBasePickerUI.ShowDialog() == DialogResult.OK)
			{
				#qp.Value = tabularObjectBasePickerUI.SelectedTabularObjectBaseCollection;
				SchemaObjectEditor.SetDeepLoad(#qp, #qp.Value as SchemaObjectBase);
			}
			tabularObjectBasePickerUI.End();
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x00022968 File Offset: 0x00021968
		private static void #S3c(IPropertyDataAccessor #qp)
		{
			ViewColumnSchemaPickerUI viewColumnSchemaPickerUI = new ViewColumnSchemaPickerUI();
			viewColumnSchemaPickerUI.Start(#qp.Value);
			CodeTemplate codeTemplate = #qp.Target as CodeTemplate;
			if (codeTemplate != null)
			{
				string valueName = #qp.ValueName;
				string propertyAttribute = codeTemplate.GetPropertyAttribute(valueName, #Mk.#Lk(18350));
				if (!string.IsNullOrEmpty(propertyAttribute))
				{
					object propertyValue = ObjectCopier.GetPropertyValue(codeTemplate, propertyAttribute);
					viewColumnSchemaPickerUI.Filter(propertyValue);
				}
			}
			if (viewColumnSchemaPickerUI.ShowDialog() == DialogResult.OK)
			{
				#qp.Value = viewColumnSchemaPickerUI.SelectedViewColumnSchema;
				SchemaObjectEditor.SetDeepLoad(#qp, #qp.Value as SchemaObjectBase);
			}
			viewColumnSchemaPickerUI.End();
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x000229F4 File Offset: 0x000219F4
		private static void #T3c(IPropertyDataAccessor #qp)
		{
			ViewSchemaPickerUI viewSchemaPickerUI = new ViewSchemaPickerUI();
			viewSchemaPickerUI.Start(#qp.Value);
			if (viewSchemaPickerUI.ShowDialog() == DialogResult.OK)
			{
				#qp.Value = viewSchemaPickerUI.SelectedViewSchema;
				SchemaObjectEditor.SetDeepLoad(#qp, #qp.Value as SchemaObjectBase);
			}
			viewSchemaPickerUI.End();
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x00022A40 File Offset: 0x00021A40
		private static void #U3c(IPropertyDataAccessor #qp)
		{
			ViewSchemaPickerUI viewSchemaPickerUI = new ViewSchemaPickerUI(true);
			viewSchemaPickerUI.Start(#qp.Value);
			if (viewSchemaPickerUI.ShowDialog() == DialogResult.OK)
			{
				#qp.Value = viewSchemaPickerUI.SelectedViewSchemaCollection;
				SchemaObjectEditor.SetDeepLoad(#qp, #qp.Value as SchemaObjectBase);
			}
			viewSchemaPickerUI.End();
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x00022A8C File Offset: 0x00021A8C
		private static void #V3c(IPropertyDataAccessor #qp)
		{
			SchemaSelectorEditorUI schemaSelectorEditorUI = new SchemaSelectorEditorUI();
			schemaSelectorEditorUI.Start(null, #qp.Value);
			if (schemaSelectorEditorUI.ShowDialog() == DialogResult.OK)
			{
				#qp.Value = schemaSelectorEditorUI.SchemaSelector;
			}
			schemaSelectorEditorUI.End();
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x00022AC8 File Offset: 0x00021AC8
		public static void SetDeepLoad(IPropertyDataAccessor context, SchemaObjectBase schemaObject)
		{
			if (context == null || schemaObject == null || context.Target == null)
			{
				return;
			}
			CodeTemplate codeTemplate = context.Target as CodeTemplate;
			if (codeTemplate == null)
			{
				return;
			}
			string propertyAttribute = codeTemplate.GetPropertyAttribute(context.ValueName, #Mk.#Lk(14532));
			if (string.IsNullOrEmpty(propertyAttribute))
			{
				return;
			}
			bool flag;
			bool.TryParse(propertyAttribute, out flag);
			if (schemaObject.DeepLoad == flag && schemaObject.Database.DeepLoad == flag)
			{
				return;
			}
			schemaObject.DeepLoad = flag;
			schemaObject.Database.DeepLoad = flag;
			if (!flag)
			{
				return;
			}
			schemaObject.Refresh();
			schemaObject.Database.Refresh();
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x00022B60 File Offset: 0x00021B60
		public static void SetIncludeFunctions(IPropertyDataAccessor context, SchemaObjectBase schemaObject)
		{
			if (context == null || schemaObject == null || context.Target == null)
			{
				return;
			}
			CodeTemplate codeTemplate = context.Target as CodeTemplate;
			if (codeTemplate == null)
			{
				return;
			}
			string propertyAttribute = codeTemplate.GetPropertyAttribute(context.ValueName, #Mk.#Lk(14545));
			if (string.IsNullOrEmpty(propertyAttribute))
			{
				return;
			}
			bool flag;
			bool.TryParse(propertyAttribute, out flag);
			if (schemaObject.IncludeFunctions == flag && schemaObject.Database.IncludeFunctions == flag)
			{
				return;
			}
			schemaObject.IncludeFunctions = flag;
			schemaObject.Database.IncludeFunctions = flag;
			if (!flag)
			{
				return;
			}
			schemaObject.Refresh();
			schemaObject.Database.Refresh();
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x00022C00 File Offset: 0x00021C00
		// Note: this type is marked as 'beforefieldinit'.
		static SchemaObjectEditor()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (SchemaObjectEditor.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x0600075C RID: 1884
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);
	}
}
