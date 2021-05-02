namespace SchemaExplorer.Design
{
	// Token: 0x020000CD RID: 205
	public partial class DataSourceUI : global::System.Windows.Forms.Form
	{
		// Token: 0x06000705 RID: 1797 RVA: 0x0001FEC4 File Offset: 0x0001EEC4
		protected override void Dispose(bool disposing)
		{
			if (this.#iq)
			{
				return;
			}
			if (disposing)
			{
				if (this.#H8b != null)
				{
					this.#H8b.Click -= new global::System.EventHandler(this.#mac);
				}
				if (this.#g3c != null)
				{
					this.#g3c.Validating -= new global::System.ComponentModel.CancelEventHandler(this.#n3c);
					this.#g3c.SelectedIndexChanged -= new global::System.EventHandler(this.#r3c);
				}
				if (this.#nXc != null)
				{
					this.#nXc.Validating -= new global::System.ComponentModel.CancelEventHandler(this.#o3c);
				}
				if (this.#v9b != null)
				{
					this.#v9b.Validating -= new global::System.ComponentModel.CancelEventHandler(this.#p3c);
				}
				if (this.#NTc != null)
				{
					this.#NTc.Click -= new global::System.EventHandler(this.#q3c);
				}
				if (this.#j3c != null)
				{
					this.#j3c.Click -= new global::System.EventHandler(this.#s3c);
				}
				base.Load -= new global::System.EventHandler(this.#t3c);
				if (this.#sS != null)
				{
					this.#sS.Dispose();
				}
			}
			this.#iq = true;
			base.Dispose(disposing);
		}

		// Token: 0x0400029D RID: 669
		private global::System.Windows.Forms.ComboBox #g3c;

		// Token: 0x0400029E RID: 670
		private global::System.Windows.Forms.TextBox #nXc;

		// Token: 0x0400029F RID: 671
		private global::System.Windows.Forms.TextBox #v9b;

		// Token: 0x040002A4 RID: 676
		private global::System.Windows.Forms.Button #H8b;

		// Token: 0x040002A5 RID: 677
		private global::System.ComponentModel.IContainer #sS;

		// Token: 0x040002A7 RID: 679
		private global::System.Windows.Forms.Button #NTc;

		// Token: 0x040002A8 RID: 680
		private global::System.Windows.Forms.Button #j3c;

		// Token: 0x040002AA RID: 682
		private bool #iq;
	}
}
