namespace SchemaExplorer.Design
{
	// Token: 0x020000CC RID: 204
	public partial class DataSourceManagerUI : global::System.Windows.Forms.Form
	{
		// Token: 0x060006F9 RID: 1785 RVA: 0x0001F4FC File Offset: 0x0001E4FC
		protected override void Dispose(bool disposing)
		{
			if (this.#iq)
			{
				return;
			}
			if (disposing)
			{
				if (this.#62c != null)
				{
					this.#62c.DoubleClick -= new global::System.EventHandler(this.#e3c);
				}
				if (this.#rdc != null)
				{
					this.#rdc.Click -= new global::System.EventHandler(this.#c3c);
				}
				if (this.#72c != null)
				{
					this.#72c.Click -= new global::System.EventHandler(this.#b3c);
				}
				if (this.#RU != null)
				{
					this.#RU.Click -= new global::System.EventHandler(this.#99b);
				}
				if (this.#92c != null)
				{
					this.#92c.Click -= new global::System.EventHandler(this.#d3c);
				}
				if (this.#rV != null)
				{
					this.#rV.Click -= new global::System.EventHandler(this.#f3c);
				}
				if (this.#sS != null)
				{
					this.#sS.Dispose();
				}
			}
			this.#iq = true;
			base.Dispose(disposing);
		}

		// Token: 0x04000293 RID: 659
		private global::#J2c.#Jlc #62c;

		// Token: 0x04000294 RID: 660
		private global::System.Windows.Forms.Button #72c;

		// Token: 0x04000295 RID: 661
		private global::System.Windows.Forms.Button #RU;

		// Token: 0x04000298 RID: 664
		private global::System.Windows.Forms.Button #rdc;

		// Token: 0x04000299 RID: 665
		private global::System.Windows.Forms.Button #92c;

		// Token: 0x0400029A RID: 666
		private global::System.Windows.Forms.Button #rV;

		// Token: 0x0400029B RID: 667
		private global::System.ComponentModel.Container #sS;

		// Token: 0x0400029C RID: 668
		private bool #iq;
	}
}
