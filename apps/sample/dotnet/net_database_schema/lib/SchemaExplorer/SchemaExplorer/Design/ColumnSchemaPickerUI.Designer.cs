namespace SchemaExplorer.Design
{
	// Token: 0x020000C9 RID: 201
	public partial class ColumnSchemaPickerUI : global::System.Windows.Forms.Form
	{
		// Token: 0x060006C3 RID: 1731 RVA: 0x0001D0F4 File Offset: 0x0001C0F4
		protected override void Dispose(bool disposing)
		{
			if (this.#iq)
			{
				return;
			}
			if (disposing)
			{
				if (this.#N2c != null)
				{
					this.#N2c.BeforeExpand -= new global::System.Windows.Forms.TreeViewCancelEventHandler(this.#V2c);
					this.#N2c.DoubleClick -= new global::System.EventHandler(this.#U2c);
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
				base.Load -= new global::System.EventHandler(this.#S2c);
				if (this.#sS != null)
				{
					this.#sS.Dispose();
				}
			}
			this.#iq = true;
			base.Dispose(disposing);
		}

		// Token: 0x0400026D RID: 621
		private global::System.Windows.Forms.Button #m2c;

		// Token: 0x0400026E RID: 622
		private global::System.Windows.Forms.ComboBox #d2c;

		// Token: 0x0400026F RID: 623
		private global::System.Windows.Forms.Button #e2c;

		// Token: 0x04000272 RID: 626
		private global::System.ComponentModel.IContainer #sS;

		// Token: 0x04000276 RID: 630
		private global::SchemaExplorer.Design.ThreeStateTreeView #N2c;

		// Token: 0x0400027B RID: 635
		private bool #iq;
	}
}
