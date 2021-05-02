namespace SchemaExplorer.Design
{
	// Token: 0x020000C5 RID: 197
	public partial class SchemaSelectorEditorUI : global::System.Windows.Forms.Form
	{
		// Token: 0x060006B0 RID: 1712 RVA: 0x0001C074 File Offset: 0x0001B074
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.#sS != null)
			{
				this.#sS.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000255 RID: 597
		private global::System.ComponentModel.IContainer #sS;
	}
}
