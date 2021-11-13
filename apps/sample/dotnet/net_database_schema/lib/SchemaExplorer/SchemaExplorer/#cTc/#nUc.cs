using System;
using System.Collections.Generic;
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
	// Token: 0x02000014 RID: 20
	internal sealed partial class #nUc : Form
	{
		// Token: 0x06000110 RID: 272 RVA: 0x00007630 File Offset: 0x00006630
		public #nUc()
		{
			this.#lq();
			if (this.#sS == null)
			{
				this.#sS = new Container();
			}
			this.#sS.Add(new #5Zc(this));
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00007670 File Offset: 0x00006670
		public #nUc(DataConnectionDialog mainDialog) : this()
		{
			this.#4Sc = mainDialog;
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000112 RID: 274 RVA: 0x00007680 File Offset: 0x00006680
		// (set) Token: 0x06000113 RID: 275 RVA: 0x00007688 File Offset: 0x00006688
		public string Title
		{
			get
			{
				return this.Text;
			}
			set
			{
				this.Text = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000114 RID: 276 RVA: 0x00007694 File Offset: 0x00006694
		// (set) Token: 0x06000115 RID: 277 RVA: 0x000076B0 File Offset: 0x000066B0
		public string HeaderLabel
		{
			get
			{
				if (this.#rTc == null)
				{
					return string.Empty;
				}
				return this.#rTc.Text;
			}
			set
			{
				if (this.#rTc == null && (value == null || value.Length == 0))
				{
					return;
				}
				if (this.#rTc != null && value == this.#rTc.Text)
				{
					return;
				}
				if (value != null)
				{
					if (this.#rTc == null)
					{
						this.#rTc = new Label();
						this.#rTc.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
						this.#rTc.FlatStyle = FlatStyle.System;
						this.#rTc.Location = new Point(12, 12);
						this.#rTc.Margin = new Padding(3);
						this.#rTc.Name = #Mk.#Lk(981);
						this.#rTc.Width = this.#7Tc.Width;
						this.#rTc.TabIndex = 100;
						base.Controls.Add(this.#rTc);
					}
					this.#rTc.Text = value;
					this.MinimumSize = Size.Empty;
					this.#rTc.Height = #TVc.#KVc(this.#rTc);
					int num = this.#rTc.Bottom + this.#rTc.Margin.Bottom + this.#7Tc.Margin.Top - this.#7Tc.Top;
					this.#7Tc.Anchor &= ~AnchorStyles.Bottom;
					base.Height += num;
					this.#7Tc.Anchor |= AnchorStyles.Bottom;
					this.#7Tc.Top += num;
					this.MinimumSize = base.Size;
					return;
				}
				if (this.#rTc != null)
				{
					int height = this.#rTc.Height;
					try
					{
						base.Controls.Remove(this.#rTc);
					}
					finally
					{
						this.#rTc.Dispose();
						this.#rTc = null;
					}
					this.MinimumSize = Size.Empty;
					this.#7Tc.Top -= height;
					this.#7Tc.Anchor &= ~AnchorStyles.Bottom;
					base.Height -= height;
					this.#7Tc.Anchor |= AnchorStyles.Bottom;
					this.MinimumSize = base.Size;
				}
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00007900 File Offset: 0x00006900
		protected override void OnLoad(EventArgs #tm)
		{
			if (this.#4Sc != null)
			{
				foreach (DataSource dataSource in this.#4Sc.DataSources)
				{
					if (dataSource != this.#4Sc.UnspecifiedDataSource)
					{
						this.#9Tc.Items.Add(dataSource);
					}
				}
				if (this.#4Sc.DataSources.Contains(this.#4Sc.UnspecifiedDataSource))
				{
					this.#9Tc.Sorted = false;
					this.#9Tc.Items.Add(this.#4Sc.UnspecifiedDataSource);
				}
				int num = this.#9Tc.Width - (this.#9Tc.Width - this.#9Tc.ClientSize.Width);
				foreach (object obj in this.#9Tc.Items)
				{
					Size size = TextRenderer.MeasureText((obj as DataSource).DisplayName, this.#9Tc.Font);
					size.Width += 3;
					num = Math.Max(num, size.Width);
				}
				num += this.#9Tc.Width - this.#9Tc.ClientSize.Width;
				num = Math.Max(num, this.#9Tc.MinimumSize.Width);
				int num2 = num - this.#9Tc.Size.Width;
				base.Width += num2 * 2;
				this.MinimumSize = base.Size;
				if (this.#4Sc.SelectedDataSource != null)
				{
					this.#9Tc.SelectedItem = this.#4Sc.SelectedDataSource;
					if (this.#4Sc.SelectedDataProvider != null)
					{
						this.#bUc.SelectedItem = this.#4Sc.SelectedDataProvider;
					}
				}
				foreach (object obj2 in this.#9Tc.Items)
				{
					DataSource dataSource2 = (DataSource)obj2;
					DataProvider selectedDataProvider = this.#4Sc.GetSelectedDataProvider(dataSource2);
					if (selectedDataProvider != null)
					{
						this.#6Tc[dataSource2] = selectedDataProvider;
					}
				}
			}
			this.#dUc.Checked = this.#4Sc.SaveSelection;
			this.#aTc();
			base.OnLoad(#tm);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00007BB8 File Offset: 0x00006BB8
		protected override void OnFontChanged(EventArgs #tm)
		{
			base.OnFontChanged(#tm);
			this.#bUc.Top = this.#8Tc.Height - this.#8Tc.Padding.Bottom - this.#bUc.Margin.Bottom - this.#bUc.Height;
			this.#aUc.Top = this.#bUc.Top - this.#bUc.Margin.Top - this.#aUc.Margin.Bottom - this.#aUc.Height;
			int num = this.#dUc.Right + this.#dUc.Margin.Right - (this.#7Sc.Left - this.#7Sc.Margin.Left);
			if (num > 0)
			{
				base.Width += num;
				this.MinimumSize = new Size(this.MinimumSize.Width + num, this.MinimumSize.Height);
			}
			this.#7Tc.Anchor &= ~AnchorStyles.Bottom;
			this.#dUc.Anchor &= ~AnchorStyles.Bottom;
			this.#dUc.Anchor |= AnchorStyles.Top;
			this.#7Sc.Anchor &= ~AnchorStyles.Bottom;
			this.#7Sc.Anchor |= AnchorStyles.Top;
			int height = this.#7Sc.Top + this.#7Sc.Height + this.#7Sc.Margin.Bottom + base.Padding.Bottom;
			int num2 = base.Height - this.SizeFromClientSize(new Size(0, height)).Height;
			this.MinimumSize = new Size(this.MinimumSize.Width, this.MinimumSize.Height - num2);
			base.Height -= num2;
			this.#7Sc.Anchor &= ~AnchorStyles.Top;
			this.#7Sc.Anchor |= AnchorStyles.Bottom;
			this.#dUc.Anchor &= ~AnchorStyles.Top;
			this.#dUc.Anchor |= AnchorStyles.Bottom;
			this.#7Tc.Anchor |= AnchorStyles.Bottom;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00007E34 File Offset: 0x00006E34
		protected void #eUc(EventArgs #tm)
		{
			base.OnRightToLeftLayoutChanged(#tm);
			if (this.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)
			{
				#TVc.#OVc(this.#FTc, this.#9Tc);
				#TVc.#OVc(this.#aUc, this.#bUc);
				return;
			}
			#TVc.#QVc(this.#aUc, this.#bUc);
			#TVc.#QVc(this.#FTc, this.#9Tc);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00007EA0 File Offset: 0x00006EA0
		protected override void OnRightToLeftChanged(EventArgs #tm)
		{
			base.OnRightToLeftChanged(#tm);
			if (this.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)
			{
				#TVc.#OVc(this.#FTc, this.#9Tc);
				#TVc.#OVc(this.#aUc, this.#bUc);
				return;
			}
			#TVc.#QVc(this.#aUc, this.#bUc);
			#TVc.#QVc(this.#FTc, this.#9Tc);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00007F0C File Offset: 0x00006F0C
		protected override void OnHelpRequested(HelpEventArgs #9Sc)
		{
			Control control = #JVc.#IVc(this);
			DataConnectionDialogContext context = DataConnectionDialogContext.Source;
			if (control == this.#9Tc)
			{
				context = DataConnectionDialogContext.SourceListBox;
			}
			if (control == this.#bUc)
			{
				context = DataConnectionDialogContext.SourceProviderComboBox;
			}
			if (control == this.#H8b)
			{
				context = DataConnectionDialogContext.SourceOkButton;
			}
			if (control == this.#F9b)
			{
				context = DataConnectionDialogContext.SourceCancelButton;
			}
			ContextHelpEventArgs contextHelpEventArgs = new ContextHelpEventArgs(context, #9Sc.MousePos);
			this.#4Sc.OnContextHelpRequested(contextHelpEventArgs);
			#9Sc.Handled = contextHelpEventArgs.Handled;
			if (!contextHelpEventArgs.Handled)
			{
				base.OnHelpRequested(#9Sc);
			}
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00007F98 File Offset: 0x00006F98
		[DebuggerStepThrough]
		protected override void WndProc(ref Message #WM)
		{
			if (this.#4Sc.TranslateHelpButton && #JVc.#CVc(ref #WM))
			{
				#JVc.#HVc(this, ref #WM);
			}
			base.WndProc(ref #WM);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00007FC0 File Offset: 0x00006FC0
		private void #fUc(object #sm, ListControlConvertEventArgs #tm)
		{
			if (#tm.DesiredType == typeof(string))
			{
				#tm.Value = (#tm.ListItem as DataSource).DisplayName;
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00007FF0 File Offset: 0x00006FF0
		private void #YTc(object #sm, EventArgs #tm)
		{
			DataSource dataSource = this.#9Tc.SelectedItem as DataSource;
			this.#bUc.Items.Clear();
			if (dataSource != null)
			{
				foreach (DataProvider item in dataSource.Providers)
				{
					this.#bUc.Items.Add(item);
				}
				if (!this.#6Tc.ContainsKey(dataSource))
				{
					this.#6Tc.Add(dataSource, dataSource.DefaultProvider);
				}
				this.#bUc.SelectedItem = this.#6Tc[dataSource];
			}
			else
			{
				this.#bUc.Items.Add(string.Empty);
			}
			this.#kUc();
			this.#aTc();
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000080C8 File Offset: 0x000070C8
		private void #gUc(object #sm, EventArgs #tm)
		{
			if (this.#H8b.Enabled)
			{
				base.DialogResult = DialogResult.OK;
				this.#mUc(#sm, #tm);
				base.Close();
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000080EC File Offset: 0x000070EC
		private void #hUc(object #sm, ListControlConvertEventArgs #tm)
		{
			if (#tm.DesiredType == typeof(string))
			{
				#tm.Value = ((#tm.ListItem is DataProvider) ? (#tm.ListItem as DataProvider).DisplayName : #tm.ListItem.ToString());
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00008140 File Offset: 0x00007140
		private void #iUc(object #sm, EventArgs #tm)
		{
			if (this.#bUc.Items.Count > 0 && !(this.#bUc.Items[0] is string))
			{
				int num = 0;
				using (Graphics graphics = Graphics.FromHwnd(this.#bUc.Handle))
				{
					foreach (object obj in this.#bUc.Items)
					{
						DataProvider dataProvider = (DataProvider)obj;
						int width = TextRenderer.MeasureText(graphics, dataProvider.DisplayName, this.#bUc.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.WordBreak).Width;
						if (width > num)
						{
							num = width;
						}
					}
				}
				this.#bUc.DropDownWidth = num + 3;
				if (this.#bUc.Items.Count > this.#bUc.MaxDropDownItems)
				{
					this.#bUc.DropDownWidth += SystemInformation.VerticalScrollBarWidth;
					return;
				}
			}
			else
			{
				this.#bUc.DropDownWidth = this.#bUc.Width;
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00008288 File Offset: 0x00007288
		private void #jUc(object #sm, EventArgs #tm)
		{
			if (this.#9Tc.SelectedItem != null)
			{
				this.#6Tc[this.#9Tc.SelectedItem as DataSource] = (this.#bUc.SelectedItem as DataProvider);
			}
			this.#kUc();
			this.#aTc();
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000082DC File Offset: 0x000072DC
		private void #kUc()
		{
			if (!(this.#bUc.SelectedItem is DataProvider))
			{
				this.#Occ.Text = null;
				return;
			}
			if (this.#9Tc.SelectedItem == this.#4Sc.UnspecifiedDataSource)
			{
				this.#Occ.Text = (this.#bUc.SelectedItem as DataProvider).Description;
				return;
			}
			this.#Occ.Text = (this.#bUc.SelectedItem as DataProvider).GetDescription(this.#9Tc.SelectedItem as DataSource);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00008374 File Offset: 0x00007374
		private void #lUc(object #sm, EventArgs #tm)
		{
			this.#4Sc.SaveSelection = this.#dUc.Checked;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000838C File Offset: 0x0000738C
		private void #aTc()
		{
			this.#H8b.Enabled = (this.#9Tc.SelectedItem is DataSource && this.#bUc.SelectedItem is DataProvider);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000083C4 File Offset: 0x000073C4
		private void #mUc(object #sm, EventArgs #tm)
		{
			this.#4Sc.#RTc(this.#9Tc.SelectedItem as DataSource);
			foreach (object obj in this.#9Tc.Items)
			{
				DataSource dataSource = (DataSource)obj;
				DataProvider #am = this.#6Tc.ContainsKey(dataSource) ? this.#6Tc[dataSource] : null;
				this.#4Sc.#STc(dataSource, #am);
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00008484 File Offset: 0x00007484
		private void #lq()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(#nUc));
			this.#7Tc = new TableLayoutPanel();
			this.#8Tc = new Panel();
			this.#FTc = new Label();
			this.#9Tc = new ListBox();
			this.#aUc = new Label();
			this.#bUc = new ComboBox();
			this.#cUc = new GroupBox();
			this.#Occ = new Label();
			this.#dUc = new CheckBox();
			this.#7Sc = new TableLayoutPanel();
			this.#H8b = new Button();
			this.#F9b = new Button();
			this.#7Tc.SuspendLayout();
			this.#8Tc.SuspendLayout();
			this.#cUc.SuspendLayout();
			this.#7Sc.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.#7Tc, #Mk.#Lk(1256));
			this.#7Tc.Controls.Add(this.#8Tc, 0, 0);
			this.#7Tc.Controls.Add(this.#cUc, 1, 0);
			this.#7Tc.Name = #Mk.#Lk(1256);
			this.#8Tc.Controls.Add(this.#FTc);
			this.#8Tc.Controls.Add(this.#9Tc);
			this.#8Tc.Controls.Add(this.#aUc);
			this.#8Tc.Controls.Add(this.#bUc);
			componentResourceManager.ApplyResources(this.#8Tc, #Mk.#Lk(1285));
			this.#8Tc.Name = #Mk.#Lk(1285);
			componentResourceManager.ApplyResources(this.#FTc, #Mk.#Lk(981));
			this.#FTc.FlatStyle = FlatStyle.System;
			this.#FTc.Name = #Mk.#Lk(981);
			componentResourceManager.ApplyResources(this.#9Tc, #Mk.#Lk(1298));
			this.#9Tc.FormattingEnabled = true;
			this.#9Tc.MinimumSize = new Size(200, 108);
			this.#9Tc.Name = #Mk.#Lk(1298);
			this.#9Tc.Sorted = true;
			this.#9Tc.DoubleClick += this.#gUc;
			this.#9Tc.SelectedIndexChanged += this.#YTc;
			this.#9Tc.Format += this.#fUc;
			componentResourceManager.ApplyResources(this.#aUc, #Mk.#Lk(1323));
			this.#aUc.FlatStyle = FlatStyle.System;
			this.#aUc.Name = #Mk.#Lk(1323);
			componentResourceManager.ApplyResources(this.#bUc, #Mk.#Lk(1348));
			this.#bUc.DropDownStyle = ComboBoxStyle.DropDownList;
			this.#bUc.FormattingEnabled = true;
			this.#bUc.Items.AddRange(new object[]
			{
				componentResourceManager.GetString(#Mk.#Lk(1377))
			});
			this.#bUc.Name = #Mk.#Lk(1348);
			this.#bUc.Sorted = true;
			this.#bUc.SelectedIndexChanged += this.#jUc;
			this.#bUc.DropDown += this.#iUc;
			this.#bUc.Format += this.#hUc;
			componentResourceManager.ApplyResources(this.#cUc, #Mk.#Lk(1414));
			this.#cUc.Controls.Add(this.#Occ);
			this.#cUc.FlatStyle = FlatStyle.System;
			this.#cUc.Name = #Mk.#Lk(1414);
			this.#cUc.TabStop = false;
			componentResourceManager.ApplyResources(this.#Occ, #Mk.#Lk(1443));
			this.#Occ.FlatStyle = FlatStyle.System;
			this.#Occ.Name = #Mk.#Lk(1443);
			componentResourceManager.ApplyResources(this.#dUc, #Mk.#Lk(1468));
			this.#dUc.Name = #Mk.#Lk(1468);
			this.#dUc.CheckedChanged += this.#lUc;
			componentResourceManager.ApplyResources(this.#7Sc, #Mk.#Lk(686));
			this.#7Sc.Controls.Add(this.#H8b, 0, 0);
			this.#7Sc.Controls.Add(this.#F9b, 1, 0);
			this.#7Sc.Name = #Mk.#Lk(686);
			componentResourceManager.ApplyResources(this.#H8b, #Mk.#Lk(719));
			this.#H8b.DialogResult = DialogResult.OK;
			this.#H8b.MinimumSize = new Size(75, 23);
			this.#H8b.Name = #Mk.#Lk(719);
			this.#H8b.Click += this.#mUc;
			componentResourceManager.ApplyResources(this.#F9b, #Mk.#Lk(732));
			this.#F9b.DialogResult = DialogResult.Cancel;
			this.#F9b.MinimumSize = new Size(75, 23);
			this.#F9b.Name = #Mk.#Lk(732);
			base.AcceptButton = this.#H8b;
			componentResourceManager.ApplyResources(this, #Mk.#Lk(598));
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.#F9b;
			base.Controls.Add(this.#7Tc);
			base.Controls.Add(this.#dUc);
			base.Controls.Add(this.#7Sc);
			base.HelpButton = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = #Mk.#Lk(1497);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.#7Tc.ResumeLayout(false);
			this.#8Tc.ResumeLayout(false);
			this.#8Tc.PerformLayout();
			this.#cUc.ResumeLayout(false);
			this.#7Sc.ResumeLayout(false);
			this.#7Sc.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00008AC4 File Offset: 0x00007AC4
		// Note: this type is marked as 'beforefieldinit'.
		static #nUc()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (#nUc.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000129 RID: 297
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x04000089 RID: 137
		private Label #rTc;

		// Token: 0x0400008A RID: 138
		private Dictionary<DataSource, DataProvider> #6Tc = new Dictionary<DataSource, DataProvider>();

		// Token: 0x0400008B RID: 139
		private DataConnectionDialog #4Sc;

		// Token: 0x0400008D RID: 141
		private TableLayoutPanel #7Tc;

		// Token: 0x0400008E RID: 142
		private Panel #8Tc;

		// Token: 0x0400008F RID: 143
		private Label #FTc;

		// Token: 0x04000090 RID: 144
		private ListBox #9Tc;

		// Token: 0x04000091 RID: 145
		private Label #aUc;

		// Token: 0x04000092 RID: 146
		private ComboBox #bUc;

		// Token: 0x04000093 RID: 147
		private GroupBox #cUc;

		// Token: 0x04000094 RID: 148
		private Label #Occ;

		// Token: 0x04000095 RID: 149
		private CheckBox #dUc;

		// Token: 0x04000096 RID: 150
		private TableLayoutPanel #7Sc;

		// Token: 0x04000097 RID: 151
		private Button #H8b;

		// Token: 0x04000098 RID: 152
		private Button #F9b;
	}
}
