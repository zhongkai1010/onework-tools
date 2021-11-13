namespace SchemaExplorer.Design
{
	// Token: 0x020000D7 RID: 215
	public partial class ViewColumnSchemaPickerUI : global::System.Windows.Forms.Form
	{
		// Token: 0x0600079A RID: 1946 RVA: 0x00024C70 File Offset: 0x00023C70
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

		// Token: 0x040002EB RID: 747
		private global::System.Windows.Forms.Button #m2c;

		// Token: 0x040002EC RID: 748
		private global::System.Windows.Forms.ComboBox #d2c;

		// Token: 0x040002ED RID: 749
		private global::System.Windows.Forms.Button #e2c;

		// Token: 0x040002F0 RID: 752
		private global::System.ComponentModel.IContainer #sS;

		// Token: 0x040002F4 RID: 756
		private global::SchemaExplorer.Design.ThreeStateTreeView #N2c;

		// Token: 0x040002F9 RID: 761
		private bool #iq;
	}
}
