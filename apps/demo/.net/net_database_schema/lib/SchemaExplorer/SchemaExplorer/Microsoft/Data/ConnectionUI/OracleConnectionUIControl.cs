using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using #cTc;
using #Nk;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x0200002F RID: 47
	public class OracleConnectionUIControl : UserControl, IDataConnectionUIControl
	{
		// Token: 0x06000215 RID: 533 RVA: 0x0000DEA0 File Offset: 0x0000CEA0
		public OracleConnectionUIControl()
		{
			this.#lq();
			this.RightToLeft = RightToLeft.Inherit;
			int num = #TVc.#MVc(this.#USc);
			if (this.#USc.Height < num)
			{
				this.#USc.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
				this.#PSc.Height += this.#PSc.Margin.Bottom;
				this.#PSc.Margin = new Padding(this.#PSc.Margin.Left, this.#PSc.Margin.Top, this.#PSc.Margin.Right, 0);
			}
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000DF58 File Offset: 0x0000CF58
		public void Initialize(IDataConnectionProperties connectionProperties)
		{
			if (connectionProperties == null)
			{
				throw new ArgumentNullException(#Nk.#Mk.#Lk(174));
			}
			if (!(connectionProperties is OracleConnectionProperties) && !(connectionProperties is OleDBOracleConnectionProperties))
			{
				throw new ArgumentException(#cTc.#Mk.OracleConnectionUIControl_InvalidConnectionProperties);
			}
			if (connectionProperties is OdbcConnectionProperties)
			{
				this.#USc.Enabled = false;
			}
			this.#KSc = connectionProperties;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0000DFB0 File Offset: 0x0000CFB0
		public void LoadProperties()
		{
			this.#6yc = true;
			this.#gYc.Text = (this.Properties[this.ServerProperty] as string);
			this.#RSc.Text = (this.Properties[this.UserNameProperty] as string);
			this.#TSc.Text = (this.Properties[this.PasswordProperty] as string);
			if (!(this.Properties is OdbcConnectionProperties))
			{
				this.#USc.Checked = (bool)this.Properties[#Nk.#Mk.#Lk(212)];
			}
			else
			{
				this.#USc.Checked = false;
			}
			this.#6yc = false;
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0000E070 File Offset: 0x0000D070
		protected override void OnRightToLeftChanged(EventArgs e)
		{
			base.OnRightToLeftChanged(e);
			if (base.ParentForm != null && base.ParentForm.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)
			{
				#TVc.#OVc(this.#fYc, this.#gYc);
				return;
			}
			#TVc.#QVc(this.#fYc, this.#gYc);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000E0C8 File Offset: 0x0000D0C8
		protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
		{
			Size size = base.Size;
			this.MinimumSize = Size.Empty;
			base.ScaleControl(factor, specified);
			this.MinimumSize = new Size((int)Math.Round((double)((float)size.Width * factor.Width)), (int)Math.Round((double)((float)size.Height * factor.Height)));
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000E128 File Offset: 0x0000D128
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (base.Parent == null)
			{
				this.OnFontChanged(e);
			}
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000E140 File Offset: 0x0000D140
		private void #hYc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[this.ServerProperty] = ((this.#gYc.Text.Trim().Length > 0) ? this.#gYc.Text.Trim() : null);
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000E194 File Offset: 0x0000D194
		private void #XSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[this.UserNameProperty] = ((this.#RSc.Text.Trim().Length > 0) ? this.#RSc.Text.Trim() : null);
			}
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000E1E8 File Offset: 0x0000D1E8
		private void #YSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[this.PasswordProperty] = ((this.#TSc.Text.Length > 0) ? this.#TSc.Text : null);
				this.#TSc.Text = this.#TSc.Text;
			}
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000E248 File Offset: 0x0000D248
		private void #ZSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(212)] = this.#USc.Checked;
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0000E278 File Offset: 0x0000D278
		private void #0Sc(object #sm, EventArgs #tm)
		{
			Control control = #sm as Control;
			control.Text = control.Text.Trim();
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000220 RID: 544 RVA: 0x0000E2A0 File Offset: 0x0000D2A0
		private string ServerProperty
		{
			get
			{
				if (!(this.Properties is OdbcConnectionProperties))
				{
					return #Nk.#Mk.#Lk(241);
				}
				return #Nk.#Mk.#Lk(3411);
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000221 RID: 545 RVA: 0x0000E2C4 File Offset: 0x0000D2C4
		private string UserNameProperty
		{
			get
			{
				if (!(this.Properties is OdbcConnectionProperties))
				{
					return #Nk.#Mk.#Lk(263);
				}
				return #Nk.#Mk.#Lk(276);
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000222 RID: 546 RVA: 0x0000E2E8 File Offset: 0x0000D2E8
		private string PasswordProperty
		{
			get
			{
				if (!(this.Properties is OdbcConnectionProperties))
				{
					return #Nk.#Mk.#Lk(2742);
				}
				return #Nk.#Mk.#Lk(318);
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000223 RID: 547 RVA: 0x0000E30C File Offset: 0x0000D30C
		private IDataConnectionProperties Properties
		{
			get
			{
				return this.#KSc;
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000E314 File Offset: 0x0000D314
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.#sS != null)
			{
				this.#sS.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000E334 File Offset: 0x0000D334
		private void #lq()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(OracleConnectionUIControl));
			this.#fYc = new Label();
			this.#gYc = new TextBox();
			this.#OSc = new GroupBox();
			this.#PSc = new TableLayoutPanel();
			this.#QSc = new Label();
			this.#RSc = new TextBox();
			this.#SSc = new Label();
			this.#TSc = new TextBox();
			this.#USc = new CheckBox();
			this.#OSc.SuspendLayout();
			this.#PSc.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.#fYc, #Nk.#Mk.#Lk(3420));
			this.#fYc.FlatStyle = FlatStyle.System;
			this.#fYc.Name = #Nk.#Mk.#Lk(3420);
			componentResourceManager.ApplyResources(this.#gYc, #Nk.#Mk.#Lk(3437));
			this.#gYc.Name = #Nk.#Mk.#Lk(3437);
			this.#gYc.Leave += this.#0Sc;
			this.#gYc.TextChanged += this.#hYc;
			componentResourceManager.ApplyResources(this.#OSc, #Nk.#Mk.#Lk(435));
			this.#OSc.Controls.Add(this.#PSc);
			this.#OSc.FlatStyle = FlatStyle.System;
			this.#OSc.Name = #Nk.#Mk.#Lk(435);
			this.#OSc.TabStop = false;
			componentResourceManager.ApplyResources(this.#PSc, #Nk.#Mk.#Lk(456));
			this.#PSc.Controls.Add(this.#QSc, 0, 0);
			this.#PSc.Controls.Add(this.#RSc, 1, 0);
			this.#PSc.Controls.Add(this.#SSc, 0, 1);
			this.#PSc.Controls.Add(this.#TSc, 1, 1);
			this.#PSc.Controls.Add(this.#USc, 1, 2);
			this.#PSc.Name = #Nk.#Mk.#Lk(456);
			componentResourceManager.ApplyResources(this.#QSc, #Nk.#Mk.#Lk(485));
			this.#QSc.FlatStyle = FlatStyle.System;
			this.#QSc.Name = #Nk.#Mk.#Lk(485);
			componentResourceManager.ApplyResources(this.#RSc, #Nk.#Mk.#Lk(506));
			this.#RSc.Name = #Nk.#Mk.#Lk(506);
			this.#RSc.Leave += this.#0Sc;
			this.#RSc.TextChanged += this.#XSc;
			componentResourceManager.ApplyResources(this.#SSc, #Nk.#Mk.#Lk(527));
			this.#SSc.FlatStyle = FlatStyle.System;
			this.#SSc.Name = #Nk.#Mk.#Lk(527);
			componentResourceManager.ApplyResources(this.#TSc, #Nk.#Mk.#Lk(548));
			this.#TSc.Name = #Nk.#Mk.#Lk(548);
			this.#TSc.UseSystemPasswordChar = true;
			this.#TSc.TextChanged += this.#YSc;
			componentResourceManager.ApplyResources(this.#USc, #Nk.#Mk.#Lk(569));
			this.#USc.Name = #Nk.#Mk.#Lk(569);
			this.#USc.CheckedChanged += this.#ZSc;
			componentResourceManager.ApplyResources(this, #Nk.#Mk.#Lk(598));
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.#OSc);
			base.Controls.Add(this.#gYc);
			base.Controls.Add(this.#fYc);
			this.MinimumSize = new Size(300, 146);
			base.Name = #Nk.#Mk.#Lk(3458);
			this.#OSc.ResumeLayout(false);
			this.#OSc.PerformLayout();
			this.#PSc.ResumeLayout(false);
			this.#PSc.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000104 RID: 260
		private bool #6yc;

		// Token: 0x04000105 RID: 261
		private IDataConnectionProperties #KSc;

		// Token: 0x04000106 RID: 262
		private IContainer #sS;

		// Token: 0x04000107 RID: 263
		private Label #fYc;

		// Token: 0x04000108 RID: 264
		private TextBox #gYc;

		// Token: 0x04000109 RID: 265
		private GroupBox #OSc;

		// Token: 0x0400010A RID: 266
		private TableLayoutPanel #PSc;

		// Token: 0x0400010B RID: 267
		private Label #QSc;

		// Token: 0x0400010C RID: 268
		private TextBox #RSc;

		// Token: 0x0400010D RID: 269
		private Label #SSc;

		// Token: 0x0400010E RID: 270
		private TextBox #TSc;

		// Token: 0x0400010F RID: 271
		private CheckBox #USc;
	}
}
