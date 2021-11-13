using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using #cTc;
using #Nk;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000004 RID: 4
	public class AccessConnectionUIControl : UserControl, IDataConnectionUIControl
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002198 File Offset: 0x00001198
		public AccessConnectionUIControl()
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

		// Token: 0x06000009 RID: 9 RVA: 0x00002250 File Offset: 0x00001250
		public void Initialize(IDataConnectionProperties connectionProperties)
		{
			if (connectionProperties == null)
			{
				throw new ArgumentNullException(#Nk.#Mk.#Lk(174));
			}
			if (!(connectionProperties is OleDBAccessConnectionProperties))
			{
				throw new ArgumentException(#cTc.#Mk.AccessConnectionUIControl_InvalidConnectionProperties);
			}
			if (connectionProperties is OdbcConnectionProperties)
			{
				this.#USc.Enabled = false;
			}
			this.#KSc = connectionProperties;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000022A0 File Offset: 0x000012A0
		public void LoadProperties()
		{
			this.#6yc = true;
			this.#NSc.Text = (this.Properties[this.DatabaseFileProperty] as string);
			this.#RSc.Text = (this.Properties[this.UserNameProperty] as string);
			if (this.#RSc.Text.Length == 0)
			{
				this.#RSc.Text = #Nk.#Mk.#Lk(203);
			}
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

		// Token: 0x0600000B RID: 11 RVA: 0x00002388 File Offset: 0x00001388
		protected override void OnRightToLeftChanged(EventArgs e)
		{
			base.OnRightToLeftChanged(e);
			if (base.ParentForm != null && base.ParentForm.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)
			{
				#TVc.#OVc(this.#LSc, this.#MSc);
				return;
			}
			#TVc.#QVc(this.#LSc, this.#MSc);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000023E0 File Offset: 0x000013E0
		protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
		{
			Size size = base.Size;
			this.MinimumSize = Size.Empty;
			base.ScaleControl(factor, specified);
			this.MinimumSize = new Size((int)Math.Round((double)((float)size.Width * factor.Width)), (int)Math.Round((double)((float)size.Height * factor.Height)));
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002440 File Offset: 0x00001440
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (base.Parent == null)
			{
				this.OnFontChanged(e);
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002458 File Offset: 0x00001458
		private void #VSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[this.DatabaseFileProperty] = ((this.#NSc.Text.Trim().Length > 0) ? this.#NSc.Text.Trim() : null);
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000024AC File Offset: 0x000014AC
		private void #WSc(object #sm, EventArgs #tm)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = #cTc.#Mk.AccessConnectionUIControl_BrowseFileTitle;
			openFileDialog.Multiselect = false;
			openFileDialog.RestoreDirectory = true;
			openFileDialog.Filter = #cTc.#Mk.AccessConnectionUIControl_BrowseFileFilter;
			openFileDialog.DefaultExt = #cTc.#Mk.AccessConnectionUIControl_BrowseFileDefaultExt;
			if (base.Container != null)
			{
				base.Container.Add(openFileDialog);
			}
			try
			{
				DialogResult dialogResult = openFileDialog.ShowDialog(base.ParentForm);
				if (dialogResult == DialogResult.OK)
				{
					this.#NSc.Text = openFileDialog.FileName.Trim();
				}
			}
			finally
			{
				if (base.Container != null)
				{
					base.Container.Remove(openFileDialog);
				}
				openFileDialog.Dispose();
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002558 File Offset: 0x00001558
		private void #XSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[this.UserNameProperty] = ((this.#RSc.Text.Trim().Length > 0) ? this.#RSc.Text.Trim() : null);
				if ((this.Properties[this.UserNameProperty] as string).Equals(#Nk.#Mk.#Lk(203)))
				{
					this.Properties[this.UserNameProperty] = null;
				}
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000025E4 File Offset: 0x000015E4
		private void #YSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[this.PasswordProperty] = ((this.#TSc.Text.Length > 0) ? this.#TSc.Text : null);
				this.#TSc.Text = this.#TSc.Text;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002644 File Offset: 0x00001644
		private void #ZSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(212)] = this.#USc.Checked;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002674 File Offset: 0x00001674
		private void #0Sc(object #sm, EventArgs #tm)
		{
			Control control = #sm as Control;
			control.Text = control.Text.Trim();
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000014 RID: 20 RVA: 0x0000269C File Offset: 0x0000169C
		private string DatabaseFileProperty
		{
			get
			{
				if (!(this.Properties is OdbcConnectionProperties))
				{
					return #Nk.#Mk.#Lk(241);
				}
				return #Nk.#Mk.#Lk(258);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000026C0 File Offset: 0x000016C0
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

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000026E4 File Offset: 0x000016E4
		private string PasswordProperty
		{
			get
			{
				if (!(this.Properties is OdbcConnectionProperties))
				{
					return #Nk.#Mk.#Lk(281);
				}
				return #Nk.#Mk.#Lk(318);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002708 File Offset: 0x00001708
		private IDataConnectionProperties Properties
		{
			get
			{
				return this.#KSc;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002710 File Offset: 0x00001710
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.#sS != null)
			{
				this.#sS.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002730 File Offset: 0x00001730
		private void #lq()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AccessConnectionUIControl));
			this.#LSc = new Label();
			this.#MSc = new TableLayoutPanel();
			this.#NSc = new TextBox();
			this.#o9b = new Button();
			this.#OSc = new GroupBox();
			this.#PSc = new TableLayoutPanel();
			this.#QSc = new Label();
			this.#RSc = new TextBox();
			this.#SSc = new Label();
			this.#TSc = new TextBox();
			this.#USc = new CheckBox();
			this.#MSc.SuspendLayout();
			this.#OSc.SuspendLayout();
			this.#PSc.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.#LSc, #Nk.#Mk.#Lk(323));
			this.#LSc.FlatStyle = FlatStyle.System;
			this.#LSc.Name = #Nk.#Mk.#Lk(323);
			componentResourceManager.ApplyResources(this.#MSc, #Nk.#Mk.#Lk(348));
			this.#MSc.Controls.Add(this.#NSc, 0, 0);
			this.#MSc.Controls.Add(this.#o9b, 1, 0);
			this.#MSc.Name = #Nk.#Mk.#Lk(348);
			componentResourceManager.ApplyResources(this.#NSc, #Nk.#Mk.#Lk(389));
			this.#NSc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.#NSc.AutoCompleteSource = AutoCompleteSource.FileSystem;
			this.#NSc.Name = #Nk.#Mk.#Lk(389);
			this.#NSc.Leave += this.#0Sc;
			this.#NSc.TextChanged += this.#VSc;
			componentResourceManager.ApplyResources(this.#o9b, #Nk.#Mk.#Lk(418));
			this.#o9b.Name = #Nk.#Mk.#Lk(418);
			this.#o9b.Click += this.#WSc;
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
			base.Controls.Add(this.#MSc);
			base.Controls.Add(this.#LSc);
			this.MinimumSize = new Size(300, 148);
			base.Name = #Nk.#Mk.#Lk(607);
			this.#MSc.ResumeLayout(false);
			this.#MSc.PerformLayout();
			this.#OSc.ResumeLayout(false);
			this.#OSc.PerformLayout();
			this.#PSc.ResumeLayout(false);
			this.#PSc.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400000A RID: 10
		private bool #6yc;

		// Token: 0x0400000B RID: 11
		private IDataConnectionProperties #KSc;

		// Token: 0x0400000C RID: 12
		private IContainer #sS;

		// Token: 0x0400000D RID: 13
		private Label #LSc;

		// Token: 0x0400000E RID: 14
		private TableLayoutPanel #MSc;

		// Token: 0x0400000F RID: 15
		private TextBox #NSc;

		// Token: 0x04000010 RID: 16
		private Button #o9b;

		// Token: 0x04000011 RID: 17
		private GroupBox #OSc;

		// Token: 0x04000012 RID: 18
		private TableLayoutPanel #PSc;

		// Token: 0x04000013 RID: 19
		private Label #QSc;

		// Token: 0x04000014 RID: 20
		private TextBox #RSc;

		// Token: 0x04000015 RID: 21
		private Label #SSc;

		// Token: 0x04000016 RID: 22
		private TextBox #TSc;

		// Token: 0x04000017 RID: 23
		private CheckBox #USc;
	}
}
