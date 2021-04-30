namespace SchemaExplorer.Design
{
	// Token: 0x020000D5 RID: 213
	public partial class TabularObjectBasePickerUI : global::System.Windows.Forms.Form
	{
		// Token: 0x06000775 RID: 1909 RVA: 0x000239FC File Offset: 0x000229FC
		protected override void Dispose(bool disposing)
		{
			if (this.#iq)
			{
				return;
			}
			if (disposing)
			{
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
				if (this.#33c != null)
				{
					this.#33c.DoubleClick -= new global::System.EventHandler(this.#73c);
				}
				base.Load -= new global::System.EventHandler(this.#53c);
				if (this.#sS != null)
				{
					this.#sS.Dispose();
				}
			}
			this.#iq = true;
			base.Dispose(disposing);
		}

		// Token: 0x040002DB RID: 731
		private global::System.Windows.Forms.Button #m2c;

		// Token: 0x040002DC RID: 732
		private global::System.Windows.Forms.ComboBox #d2c;

		// Token: 0x040002DD RID: 733
		private global::System.Windows.Forms.Button #e2c;

		// Token: 0x040002E0 RID: 736
		private global::System.ComponentModel.IContainer #sS;

		// Token: 0x040002E3 RID: 739
		private global::System.Windows.Forms.ListBox #33c;

		// Token: 0x040002E5 RID: 741
		private bool #iq;
	}
}
