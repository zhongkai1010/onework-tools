namespace SchemaExplorer.Design
{
	// Token: 0x020000D8 RID: 216
	public partial class ViewSchemaPickerUI : global::System.Windows.Forms.Form
	{
		// Token: 0x060007AF RID: 1967 RVA: 0x00025B64 File Offset: 0x00024B64
		protected override void Dispose(bool disposing)
		{
			if (this.#iq)
			{
				return;
			}
			if (disposing)
			{
				if (this.#l4c != null)
				{
					this.#l4c.DoubleClick -= new global::System.EventHandler(this.#q4c);
				}
				if (this.#m2c != null)
				{
					this.#m2c.Click -= new global::System.EventHandler(this.#G2c);
				}
				if (this.#d2c != null)
				{
					this.#d2c.SelectedIndexChanged -= new global::System.EventHandler(this.#E2c);
				}
				if (this.#e2c != null)
				{
					this.#e2c.Click -= new global::System.EventHandler(this.#F2c);
				}
				base.Load -= new global::System.EventHandler(this.#o4c);
				if (this.#sS != null)
				{
					this.#sS.Dispose();
				}
			}
			this.#iq = true;
			base.Dispose(disposing);
		}

		// Token: 0x040002FB RID: 763
		private global::System.Windows.Forms.ListBox #l4c;

		// Token: 0x040002FC RID: 764
		private global::System.Windows.Forms.Button #m2c;

		// Token: 0x040002FD RID: 765
		private global::System.Windows.Forms.ComboBox #d2c;

		// Token: 0x040002FE RID: 766
		private global::System.Windows.Forms.Button #e2c;

		// Token: 0x04000301 RID: 769
		private global::System.ComponentModel.IContainer #sS;

		// Token: 0x04000305 RID: 773
		private bool #iq;
	}
}
