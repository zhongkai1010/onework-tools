namespace SchemaExplorer.Design
{
	// Token: 0x020000CA RID: 202
	public partial class CommandSchemaPickerUI : global::System.Windows.Forms.Form
	{
		// Token: 0x060006D9 RID: 1753 RVA: 0x0001E00C File Offset: 0x0001D00C
		protected override void Dispose(bool disposing)
		{
			if (this.#iq)
			{
				return;
			}
			if (disposing)
			{
				if (this.#X2c != null)
				{
					this.#X2c.DoubleClick -= new global::System.EventHandler(this.#32c);
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
				base.Load -= new global::System.EventHandler(this.#12c);
				if (this.#sS != null)
				{
					this.#sS.Dispose();
				}
			}
			this.#iq = true;
			base.Dispose(disposing);
		}

		// Token: 0x0400027D RID: 637
		private global::System.Windows.Forms.ListBox #X2c;

		// Token: 0x0400027E RID: 638
		private global::System.Windows.Forms.Button #m2c;

		// Token: 0x0400027F RID: 639
		private global::System.Windows.Forms.ComboBox #d2c;

		// Token: 0x04000280 RID: 640
		private global::System.Windows.Forms.Button #e2c;

		// Token: 0x04000283 RID: 643
		private global::System.ComponentModel.IContainer #sS;

		// Token: 0x04000288 RID: 648
		private bool #iq;
	}
}
