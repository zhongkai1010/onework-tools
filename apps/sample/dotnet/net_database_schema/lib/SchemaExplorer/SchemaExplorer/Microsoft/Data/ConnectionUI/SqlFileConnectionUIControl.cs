using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using #cTc;
using #Nk;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000036 RID: 54
	public class SqlFileConnectionUIControl : UserControl, IDataConnectionUIControl
	{
		// Token: 0x06000279 RID: 633 RVA: 0x00011158 File Offset: 0x00010158
		public SqlFileConnectionUIControl()
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

		// Token: 0x0600027A RID: 634 RVA: 0x00011210 File Offset: 0x00010210
		public void Initialize(IDataConnectionProperties connectionProperties)
		{
			if (!(connectionProperties is SqlFileConnectionProperties))
			{
				throw new ArgumentException(#cTc.#Mk.SqlFileConnectionUIControl_InvalidConnectionProperties);
			}
			this.#KSc = connectionProperties;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0001122C File Offset: 0x0001022C
		public void LoadProperties()
		{
			this.#6yc = true;
			this.#NSc.Text = (this.Properties[#Nk.#Mk.#Lk(3510)] as string);
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			if (this.#NSc.Text.StartsWith(folderPath, StringComparison.OrdinalIgnoreCase))
			{
				this.#NSc.Text = this.#NSc.Text.Substring(folderPath.Length + 1);
			}
			if ((bool)this.Properties[#Nk.#Mk.#Lk(2568)])
			{
				this.#wYc.Checked = true;
			}
			else
			{
				this.#xYc.Checked = true;
			}
			this.#RSc.Text = (this.Properties[#Nk.#Mk.#Lk(263)] as string);
			this.#TSc.Text = (this.Properties[#Nk.#Mk.#Lk(2742)] as string);
			this.#USc.Checked = (bool)this.Properties[#Nk.#Mk.#Lk(212)];
			this.#6yc = false;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00011350 File Offset: 0x00010350
		protected override void OnRightToLeftChanged(EventArgs e)
		{
			base.OnRightToLeftChanged(e);
			if (base.ParentForm != null && base.ParentForm.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)
			{
				#TVc.#OVc(this.#LSc, this.#MSc);
				#TVc.#OVc(this.#wYc);
				#TVc.#OVc(this.#xYc);
				#TVc.#OVc(this.#PSc);
				return;
			}
			#TVc.#QVc(this.#PSc);
			#TVc.#QVc(this.#xYc);
			#TVc.#QVc(this.#wYc);
			#TVc.#QVc(this.#LSc, this.#MSc);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x000113E8 File Offset: 0x000103E8
		protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
		{
			Size size = base.Size;
			this.MinimumSize = Size.Empty;
			base.ScaleControl(factor, specified);
			this.MinimumSize = new Size((int)Math.Round((double)((float)size.Width * factor.Width)), (int)Math.Round((double)((float)size.Height * factor.Height)));
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00011448 File Offset: 0x00010448
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (base.Parent == null)
			{
				this.OnFontChanged(e);
			}
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00011460 File Offset: 0x00010460
		private void #VSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(3510)] = ((this.#NSc.Text.Trim().Length > 0) ? this.#NSc.Text.Trim() : null);
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x000114B8 File Offset: 0x000104B8
		private void #RYc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				string text = (this.#NSc.Text.Trim().Length > 0) ? this.#NSc.Text.Trim() : null;
				if (text != null)
				{
					if (!text.EndsWith(#Nk.#Mk.#Lk(4420), StringComparison.OrdinalIgnoreCase))
					{
						text += #Nk.#Mk.#Lk(4420);
					}
					try
					{
						if (!Path.IsPathRooted(text))
						{
							text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), text);
						}
					}
					catch
					{
					}
				}
				this.Properties[#Nk.#Mk.#Lk(3510)] = text;
			}
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00011564 File Offset: 0x00010564
		private void #WSc(object #sm, EventArgs #tm)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = #cTc.#Mk.SqlConnectionUIControl_BrowseFileTitle;
			openFileDialog.Multiselect = false;
			openFileDialog.CheckFileExists = false;
			openFileDialog.RestoreDirectory = true;
			openFileDialog.Filter = #cTc.#Mk.SqlConnectionUIControl_BrowseFileFilter;
			openFileDialog.DefaultExt = #cTc.#Mk.SqlConnectionUIControl_BrowseFileDefaultExt;
			openFileDialog.FileName = (this.Properties[#Nk.#Mk.#Lk(3510)] as string);
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

		// Token: 0x06000282 RID: 642 RVA: 0x00011638 File Offset: 0x00010638
		private void #IYc(object #sm, EventArgs #tm)
		{
			if (this.#wYc.Checked)
			{
				if (!this.#6yc)
				{
					this.Properties[#Nk.#Mk.#Lk(2568)] = true;
					this.Properties.Reset(#Nk.#Mk.#Lk(263));
					this.Properties.Reset(#Nk.#Mk.#Lk(2742));
					this.Properties.Reset(#Nk.#Mk.#Lk(212));
				}
				this.#PSc.Enabled = false;
				return;
			}
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(2568)] = false;
				this.#XSc(#sm, #tm);
				this.#YSc(#sm, #tm);
				this.#ZSc(#sm, #tm);
			}
			this.#PSc.Enabled = true;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00011708 File Offset: 0x00010708
		private void #XSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(263)] = ((this.#RSc.Text.Trim().Length > 0) ? this.#RSc.Text.Trim() : null);
			}
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00011760 File Offset: 0x00010760
		private void #YSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(2742)] = ((this.#TSc.Text.Length > 0) ? this.#TSc.Text : null);
				this.#TSc.Text = this.#TSc.Text;
			}
		}

		// Token: 0x06000285 RID: 645 RVA: 0x000117C4 File Offset: 0x000107C4
		private void #ZSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(212)] = this.#USc.Checked;
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x000117F4 File Offset: 0x000107F4
		private void #0Sc(object #sm, EventArgs #tm)
		{
			Control control = #sm as Control;
			control.Text = control.Text.Trim();
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000287 RID: 647 RVA: 0x0001181C File Offset: 0x0001081C
		private IDataConnectionProperties Properties
		{
			get
			{
				return this.#KSc;
			}
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00011824 File Offset: 0x00010824
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.#sS != null)
			{
				this.#sS.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00011844 File Offset: 0x00010844
		private void #lq()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SqlFileConnectionUIControl));
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
			this.#xYc = new RadioButton();
			this.#wYc = new RadioButton();
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
			this.#NSc.Leave += this.#RYc;
			this.#NSc.TextChanged += this.#VSc;
			componentResourceManager.ApplyResources(this.#o9b, #Nk.#Mk.#Lk(418));
			this.#o9b.Name = #Nk.#Mk.#Lk(418);
			this.#o9b.Click += this.#WSc;
			componentResourceManager.ApplyResources(this.#OSc, #Nk.#Mk.#Lk(435));
			this.#OSc.Controls.Add(this.#PSc);
			this.#OSc.Controls.Add(this.#xYc);
			this.#OSc.Controls.Add(this.#wYc);
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
			componentResourceManager.ApplyResources(this.#xYc, #Nk.#Mk.#Lk(4029));
			this.#xYc.Name = #Nk.#Mk.#Lk(4029);
			this.#xYc.CheckedChanged += this.#IYc;
			componentResourceManager.ApplyResources(this.#wYc, #Nk.#Mk.#Lk(4070));
			this.#wYc.Name = #Nk.#Mk.#Lk(4070);
			this.#wYc.CheckedChanged += this.#IYc;
			componentResourceManager.ApplyResources(this, #Nk.#Mk.#Lk(598));
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.#OSc);
			base.Controls.Add(this.#MSc);
			base.Controls.Add(this.#LSc);
			this.MinimumSize = new Size(300, 191);
			base.Name = #Nk.#Mk.#Lk(4429);
			this.#MSc.ResumeLayout(false);
			this.#MSc.PerformLayout();
			this.#OSc.ResumeLayout(false);
			this.#OSc.PerformLayout();
			this.#PSc.ResumeLayout(false);
			this.#PSc.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000134 RID: 308
		private bool #6yc;

		// Token: 0x04000135 RID: 309
		private IDataConnectionProperties #KSc;

		// Token: 0x04000136 RID: 310
		private IContainer #sS;

		// Token: 0x04000137 RID: 311
		private Label #LSc;

		// Token: 0x04000138 RID: 312
		private TableLayoutPanel #MSc;

		// Token: 0x04000139 RID: 313
		private TextBox #NSc;

		// Token: 0x0400013A RID: 314
		private Button #o9b;

		// Token: 0x0400013B RID: 315
		private GroupBox #OSc;

		// Token: 0x0400013C RID: 316
		private RadioButton #wYc;

		// Token: 0x0400013D RID: 317
		private RadioButton #xYc;

		// Token: 0x0400013E RID: 318
		private TableLayoutPanel #PSc;

		// Token: 0x0400013F RID: 319
		private Label #QSc;

		// Token: 0x04000140 RID: 320
		private TextBox #RSc;

		// Token: 0x04000141 RID: 321
		private Label #SSc;

		// Token: 0x04000142 RID: 322
		private TextBox #TSc;

		// Token: 0x04000143 RID: 323
		private CheckBox #USc;
	}
}
