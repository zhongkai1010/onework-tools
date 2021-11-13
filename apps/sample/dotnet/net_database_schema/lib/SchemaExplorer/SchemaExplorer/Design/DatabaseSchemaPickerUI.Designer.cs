namespace SchemaExplorer.Design
{
	// Token: 0x020000CB RID: 203
	public partial class DatabaseSchemaPickerUI : global::System.Windows.Forms.Form
	{
		// Token: 0x060006EE RID: 1774 RVA: 0x0001EC4C File Offset: 0x0001DC4C
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

		// Token: 0x0400028A RID: 650
		private global::System.Windows.Forms.Button #m2c;

		// Token: 0x0400028B RID: 651
		private global::System.Windows.Forms.ComboBox #d2c;

		// Token: 0x0400028C RID: 652
		private global::System.Windows.Forms.Button #e2c;

		// Token: 0x04000290 RID: 656
		private global::System.ComponentModel.IContainer #sS;

		// Token: 0x04000292 RID: 658
		private bool #iq;
	}
}
