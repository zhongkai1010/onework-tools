using System;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using #Nk;

namespace SchemaExplorer.Design
{
	// Token: 0x020000D0 RID: 208
	public partial class ErrorDialog : Form
	{
		// Token: 0x0600071C RID: 1820 RVA: 0x00020DE4 File Offset: 0x0001FDE4
		public ErrorDialog(string title, string errorMessage, string details)
		{
			this.#lq();
			if (errorMessage == null || errorMessage.Length == 0)
			{
				errorMessage = #Mk.#Lk(17799);
			}
			this.#7dc.Text = errorMessage;
			this.#rR = details;
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x00020E1C File Offset: 0x0001FE1C
		private void #lq()
		{
			ResourceManager resourceManager = new ResourceManager(typeof(ErrorDialog));
			this.#H8b = new Button();
			this.#3dc = new Button();
			this.#4dc = new TextBox();
			this.#K8b = new PictureBox();
			this.#7dc = new TextBox();
			base.SuspendLayout();
			this.#H8b.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.#H8b.Location = new Point(282, 96);
			this.#H8b.Name = #Mk.#Lk(17118);
			this.#H8b.TabIndex = 0;
			this.#H8b.Text = #Mk.#Lk(17131);
			this.#H8b.Click += this.#8dc;
			this.#3dc.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.#3dc.Location = new Point(362, 96);
			this.#3dc.Name = #Mk.#Lk(17836);
			this.#3dc.TabIndex = 1;
			this.#3dc.Text = #Mk.#Lk(17857);
			this.#3dc.Click += this.#9dc;
			this.#4dc.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
			this.#4dc.Location = new Point(8, 128);
			this.#4dc.Multiline = true;
			this.#4dc.Name = #Mk.#Lk(17874);
			this.#4dc.ReadOnly = true;
			this.#4dc.ScrollBars = ScrollBars.Both;
			this.#4dc.Size = new Size(428, 224);
			this.#4dc.TabIndex = 7;
			this.#4dc.TabStop = false;
			this.#4dc.Text = #Mk.#Lk(2068);
			this.#4dc.WordWrap = false;
			this.#K8b.Image = (Image)resourceManager.GetObject(#Mk.#Lk(17895));
			this.#K8b.Location = new Point(8, 8);
			this.#K8b.Name = #Mk.#Lk(17920);
			this.#K8b.Size = new Size(32, 32);
			this.#K8b.TabIndex = 8;
			this.#K8b.TabStop = false;
			this.#7dc.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.#7dc.BackColor = SystemColors.Control;
			this.#7dc.BorderStyle = BorderStyle.None;
			this.#7dc.Location = new Point(51, 8);
			this.#7dc.Multiline = true;
			this.#7dc.Name = #Mk.#Lk(17937);
			this.#7dc.ReadOnly = true;
			this.#7dc.ScrollBars = ScrollBars.Both;
			this.#7dc.Size = new Size(386, 80);
			this.#7dc.TabIndex = 0;
			this.#7dc.TabStop = false;
			this.#7dc.Text = #Mk.#Lk(2068);
			this.AutoScaleBaseSize = new Size(5, 13);
			base.ClientSize = new Size(444, 126);
			base.Controls.Add(this.#7dc);
			base.Controls.Add(this.#K8b);
			base.Controls.Add(this.#4dc);
			base.Controls.Add(this.#3dc);
			base.Controls.Add(this.#H8b);
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = #Mk.#Lk(17966);
			base.ShowInTaskbar = false;
			base.SizeGripStyle = SizeGripStyle.Hide;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = #Mk.#Lk(17072);
			base.Resize += this.#aec;
			base.ResumeLayout(false);
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x0002120C File Offset: 0x0002020C
		private void #8dc(object #sm, EventArgs #tm)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x0002121C File Offset: 0x0002021C
		private void #9dc(object #sm, EventArgs #tm)
		{
			if (this.#mdc)
			{
				Size size = base.Size;
				this.#mdc = false;
				base.Size = new Size(size.Width, 152);
				this.#3dc.Text = #Mk.#Lk(17857);
				return;
			}
			Size size2 = base.Size;
			this.#mdc = true;
			base.Size = new Size(size2.Width, 392);
			this.#3dc.Text = #Mk.#Lk(17983);
			if (this.#4dc.Text.Length == 0)
			{
				this.#4dc.Text = this.#rR;
			}
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x000212CC File Offset: 0x000202CC
		private void #aec(object #sm, EventArgs #tm)
		{
			this.#4dc.Top = 128;
			if (this.#mdc)
			{
				this.#4dc.Height = base.Height - 163;
				return;
			}
			base.Size = new Size(base.Size.Width, 152);
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00021328 File Offset: 0x00020328
		public static DialogResult Show(IWin32Window owner, Exception e)
		{
			ErrorDialog errorDialog = new ErrorDialog(#Mk.#Lk(18000), e.Message, e.ToString());
			return errorDialog.ShowDialog(owner);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00021358 File Offset: 0x00020358
		public static DialogResult Show(IWin32Window owner, string errorMessage, string details)
		{
			ErrorDialog errorDialog = new ErrorDialog(#Mk.#Lk(18000), errorMessage, details);
			return errorDialog.ShowDialog(owner);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00021380 File Offset: 0x00020380
		public static DialogResult Show(IWin32Window owner, string title, string errorMessage, string details)
		{
			ErrorDialog errorDialog = new ErrorDialog(title, errorMessage, details);
			return errorDialog.ShowDialog(owner);
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x000213A0 File Offset: 0x000203A0
		// Note: this type is marked as 'beforefieldinit'.
		static ErrorDialog()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (ErrorDialog.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000725 RID: 1829
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x040002AF RID: 687
		private Button #3dc;

		// Token: 0x040002B0 RID: 688
		private TextBox #4dc;

		// Token: 0x040002B1 RID: 689
		private Button #H8b;

		// Token: 0x040002B2 RID: 690
		private bool #mdc;

		// Token: 0x040002B3 RID: 691
		private PictureBox #K8b;

		// Token: 0x040002B4 RID: 692
		private TextBox #7dc;

		// Token: 0x040002B5 RID: 693
		private string #rR;
	}
}
