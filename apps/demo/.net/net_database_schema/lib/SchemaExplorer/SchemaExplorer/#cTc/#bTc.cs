using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using #Nk;
using Microsoft.Data.ConnectionUI;

namespace #cTc
{
	// Token: 0x02000006 RID: 6
	internal sealed partial class #bTc : Form
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00002C48 File Offset: 0x00001C48
		public #bTc()
		{
			this.#lq();
			if (this.#sS == null)
			{
				this.#sS = new Container();
			}
			this.#sS.Add(new #5Zc(this));
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002C7C File Offset: 0x00001C7C
		public #bTc(DataConnectionDialog mainDialog) : this()
		{
			this.#4Sc = mainDialog;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002C8C File Offset: 0x00001C8C
		public string PropertyName
		{
			get
			{
				return this.#6Sc.Text;
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002C9C File Offset: 0x00001C9C
		protected override void OnFontChanged(EventArgs #tm)
		{
			base.OnFontChanged(#tm);
			this.#6Sc.Width = this.#7Sc.Right - this.#6Sc.Left;
			int num = base.Padding.Left + this.#7Sc.Margin.Left + this.#7Sc.Width + this.#7Sc.Margin.Right + base.Padding.Right;
			if (base.ClientSize.Width < num)
			{
				base.ClientSize = new Size(num, base.ClientSize.Height);
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002D50 File Offset: 0x00001D50
		protected override void OnHelpRequested(HelpEventArgs #9Sc)
		{
			Control control = #JVc.#IVc(this);
			DataConnectionDialogContext context = DataConnectionDialogContext.AddProperty;
			if (control == this.#6Sc)
			{
				context = DataConnectionDialogContext.AddPropertyTextBox;
			}
			if (control == this.#H8b)
			{
				context = DataConnectionDialogContext.AddPropertyOkButton;
			}
			if (control == this.#F9b)
			{
				context = DataConnectionDialogContext.AddPropertyCancelButton;
			}
			ContextHelpEventArgs contextHelpEventArgs = new ContextHelpEventArgs(context, #9Sc.MousePos);
			this.#4Sc.OnContextHelpRequested(contextHelpEventArgs);
			#9Sc.Handled = contextHelpEventArgs.Handled;
			if (!contextHelpEventArgs.Handled)
			{
				base.OnHelpRequested(#9Sc);
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002DCC File Offset: 0x00001DCC
		[DebuggerStepThrough]
		protected override void WndProc(ref Message #WM)
		{
			if (this.#4Sc.TranslateHelpButton && #JVc.#CVc(ref #WM))
			{
				#JVc.#HVc(this, ref #WM);
			}
			base.WndProc(ref #WM);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002DF4 File Offset: 0x00001DF4
		private void #aTc(object #sm, EventArgs #tm)
		{
			this.#H8b.Enabled = (this.#6Sc.Text.Trim().Length > 0);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002E3C File Offset: 0x00001E3C
		private void #lq()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(#bTc));
			this.#5Sc = new Label();
			this.#6Sc = new TextBox();
			this.#7Sc = new TableLayoutPanel();
			this.#H8b = new Button();
			this.#F9b = new Button();
			this.#7Sc.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.#5Sc, #Mk.#Lk(644));
			this.#5Sc.FlatStyle = FlatStyle.System;
			this.#5Sc.Name = #Mk.#Lk(644);
			componentResourceManager.ApplyResources(this.#6Sc, #Mk.#Lk(665));
			this.#6Sc.Name = #Mk.#Lk(665);
			this.#6Sc.TextChanged += this.#aTc;
			componentResourceManager.ApplyResources(this.#7Sc, #Mk.#Lk(686));
			this.#7Sc.Controls.Add(this.#H8b, 0, 0);
			this.#7Sc.Controls.Add(this.#F9b, 1, 0);
			this.#7Sc.Name = #Mk.#Lk(686);
			componentResourceManager.ApplyResources(this.#H8b, #Mk.#Lk(719));
			this.#H8b.DialogResult = DialogResult.OK;
			this.#H8b.MinimumSize = new Size(75, 23);
			this.#H8b.Name = #Mk.#Lk(719);
			componentResourceManager.ApplyResources(this.#F9b, #Mk.#Lk(732));
			this.#F9b.DialogResult = DialogResult.Cancel;
			this.#F9b.MinimumSize = new Size(75, 23);
			this.#F9b.Name = #Mk.#Lk(732);
			base.AcceptButton = this.#H8b;
			componentResourceManager.ApplyResources(this, #Mk.#Lk(598));
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.#F9b;
			base.Controls.Add(this.#7Sc);
			base.Controls.Add(this.#6Sc);
			base.Controls.Add(this.#5Sc);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.HelpButton = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = #Mk.#Lk(749);
			base.ShowInTaskbar = false;
			this.#7Sc.ResumeLayout(false);
			this.#7Sc.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000030C8 File Offset: 0x000020C8
		// Note: this type is marked as 'beforefieldinit'.
		static #bTc()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (#bTc.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000026 RID: 38
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x04000018 RID: 24
		private DataConnectionDialog #4Sc;

		// Token: 0x0400001A RID: 26
		private Label #5Sc;

		// Token: 0x0400001B RID: 27
		private TextBox #6Sc;

		// Token: 0x0400001C RID: 28
		private TableLayoutPanel #7Sc;

		// Token: 0x0400001D RID: 29
		private Button #H8b;

		// Token: 0x0400001E RID: 30
		private Button #F9b;
	}
}
