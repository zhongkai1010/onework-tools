namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x0200000C RID: 12
	public partial class DataConnectionDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x060000BC RID: 188 RVA: 0x00006218 File Offset: 0x00005218
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.#sS != null)
			{
				this.#sS.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0400003F RID: 63
		private global::System.ComponentModel.IContainer #sS;
	}
}
