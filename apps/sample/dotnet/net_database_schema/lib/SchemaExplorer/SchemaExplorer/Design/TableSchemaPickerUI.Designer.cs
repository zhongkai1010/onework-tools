namespace SchemaExplorer.Design
{
	// Token: 0x020000D4 RID: 212
	public partial class TableSchemaPickerUI : global::System.Windows.Forms.Form
	{
		// Token: 0x06000763 RID: 1891 RVA: 0x00022D4C File Offset: 0x00021D4C
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
				base.Load -= new global::System.EventHandler(this.#52c);
				if (this.#sS != null)
				{
					this.#sS.Dispose();
				}
			}
			this.#iq = true;
			base.Dispose(disposing);
		}

		// Token: 0x040002D0 RID: 720
		private global::System.Windows.Forms.Button #m2c;

		// Token: 0x040002D1 RID: 721
		private global::System.Windows.Forms.ComboBox #d2c;

		// Token: 0x040002D2 RID: 722
		private global::System.Windows.Forms.Button #e2c;

		// Token: 0x040002D5 RID: 725
		private global::System.ComponentModel.IContainer #sS;

		// Token: 0x040002D9 RID: 729
		private bool #iq;
	}
}
