namespace SchemaExplorer.Design
{
	// Token: 0x020000D2 RID: 210
	public partial class ExtendedPropertyEditorUI : global::System.Windows.Forms.Form
	{
		// Token: 0x06000747 RID: 1863 RVA: 0x00021B80 File Offset: 0x00020B80
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
				if (this.#B3c != null)
				{
					this.#B3c.UserDeletingRow -= new global::System.Windows.Forms.DataGridViewRowCancelEventHandler(this.#F3c);
					this.#B3c.CellBeginEdit -= new global::System.Windows.Forms.DataGridViewCellCancelEventHandler(this.#E3c);
					this.#B3c.RowValidating -= new global::System.Windows.Forms.DataGridViewCellCancelEventHandler(this.#G3c);
					this.#B3c.DataError -= new global::System.Windows.Forms.DataGridViewDataErrorEventHandler(this.#I3c);
				}
				if (this.#D3c != null)
				{
					this.#D3c.Opening -= new global::System.ComponentModel.CancelEventHandler(this.#H3c);
				}
				if (this.#fcc != null)
				{
					this.#fcc.Click -= new global::System.EventHandler(this.#scc);
				}
				if (this.#sS != null)
				{
					this.#sS.Dispose();
				}
			}
			this.#iq = true;
			base.Dispose(disposing);
		}

		// Token: 0x040002C3 RID: 707
		private bool #iq;

		// Token: 0x040002C4 RID: 708
		private global::System.ComponentModel.IContainer #sS;

		// Token: 0x040002C5 RID: 709
		private global::System.Windows.Forms.Button #H8b;

		// Token: 0x040002C8 RID: 712
		private global::System.Windows.Forms.DataGridView #B3c;

		// Token: 0x040002CC RID: 716
		private global::System.Windows.Forms.ContextMenuStrip #D3c;

		// Token: 0x040002CD RID: 717
		private global::System.Windows.Forms.ToolStripMenuItem #fcc;
	}
}
