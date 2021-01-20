using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SchemaExplorer.Design
{
	// Token: 0x020000C4 RID: 196
	public class SchemaSelectorEditor : UITypeEditor
	{
		// Token: 0x06000697 RID: 1687 RVA: 0x0001B160 File Offset: 0x0001A160
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (windowsFormsEditorService == null)
			{
				return value;
			}
			SchemaSelectorEditorUI schemaSelectorEditorUI = new SchemaSelectorEditorUI();
			schemaSelectorEditorUI.Start(windowsFormsEditorService, value);
			windowsFormsEditorService.ShowDialog(schemaSelectorEditorUI);
			if (schemaSelectorEditorUI.DialogResult == DialogResult.OK)
			{
				value = schemaSelectorEditorUI.SchemaSelector;
			}
			schemaSelectorEditorUI.End();
			return value;
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x0001B1B8 File Offset: 0x0001A1B8
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}
	}
}
