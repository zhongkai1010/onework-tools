using System;
using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000009 RID: 9
	public class ContextHelpEventArgs : HelpEventArgs
	{
		// Token: 0x0600005B RID: 91 RVA: 0x00003680 File Offset: 0x00002680
		public ContextHelpEventArgs(DataConnectionDialogContext context, Point mousePos) : base(mousePos)
		{
			this.#cK = context;
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00003690 File Offset: 0x00002690
		public DataConnectionDialogContext Context
		{
			get
			{
				return this.#cK;
			}
		}

		// Token: 0x04000022 RID: 34
		private DataConnectionDialogContext #cK;
	}
}
