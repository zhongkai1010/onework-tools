using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using #cTc;
using #Nk;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000024 RID: 36
	public class OdbcConnectionUIControl : UserControl, IDataConnectionUIControl
	{
		// Token: 0x060001A2 RID: 418 RVA: 0x00009B08 File Offset: 0x00008B08
		public OdbcConnectionUIControl()
		{
			this.#lq();
			this.RightToLeft = RightToLeft.Inherit;
			this.#jXc.AccessibleName = OdbcConnectionUIControl.#zXc(this.#hXc.Text);
			this.#nXc.AccessibleName = OdbcConnectionUIControl.#zXc(this.#lXc.Text);
			this.#fXc = Thread.CurrentThread;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00009B6C File Offset: 0x00008B6C
		public void Initialize(IDataConnectionProperties connectionProperties)
		{
			if (!(connectionProperties is OdbcConnectionProperties))
			{
				throw new ArgumentException(#cTc.#Mk.OdbcConnectionUIControl_InvalidConnectionProperties);
			}
			this.#KSc = connectionProperties;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00009B88 File Offset: 0x00008B88
		public void LoadProperties()
		{
			this.#6yc = true;
			this.#sXc();
			if (this.Properties.ToFullString().Length == 0 || (this.Properties[#Nk.#Mk.#Lk(2086)] is string && (this.Properties[#Nk.#Mk.#Lk(2086)] as string).Length > 0))
			{
				this.#hXc.Checked = true;
			}
			else
			{
				this.#lXc.Checked = true;
			}
			this.#xXc();
			this.#6yc = false;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00009C1C File Offset: 0x00008C1C
		protected override void OnRightToLeftChanged(EventArgs e)
		{
			base.OnRightToLeftChanged(e);
			if (base.ParentForm != null && base.ParentForm.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)
			{
				#TVc.#OVc(this.#hXc);
				#TVc.#OVc(this.#iXc);
				#TVc.#OVc(this.#lXc);
				#TVc.#OVc(this.#mXc);
				return;
			}
			#TVc.#QVc(this.#mXc);
			#TVc.#QVc(this.#lXc);
			#TVc.#QVc(this.#iXc);
			#TVc.#QVc(this.#hXc);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00009CA8 File Offset: 0x00008CA8
		protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
		{
			Size size = base.Size;
			this.MinimumSize = Size.Empty;
			base.ScaleControl(factor, specified);
			this.MinimumSize = new Size((int)Math.Round((double)((float)size.Width * factor.Width)), (int)Math.Round((double)((float)size.Height * factor.Height)));
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00009D08 File Offset: 0x00008D08
		[UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (base.ActiveControl == this.#hXc && (keyData & Keys.KeyCode) == Keys.Down)
			{
				this.#lXc.Focus();
				return true;
			}
			if (base.ActiveControl == this.#lXc && (keyData & Keys.KeyCode) == Keys.Down)
			{
				this.#hXc.Focus();
				return true;
			}
			return base.ProcessDialogKey(keyData);
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00009D6C File Offset: 0x00008D6C
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (base.Parent == null)
			{
				this.OnFontChanged(e);
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00009D84 File Offset: 0x00008D84
		private void #qXc(object #sm, EventArgs #tm)
		{
			if (this.#hXc.Checked)
			{
				this.#iXc.Enabled = true;
				if (!this.#6yc)
				{
					string value = this.Properties[#Nk.#Mk.#Lk(2086)] as string;
					string value2 = this.Properties.Contains(#Nk.#Mk.#Lk(2091)) ? (this.Properties[#Nk.#Mk.#Lk(2091)] as string) : null;
					string value3 = this.Properties.Contains(#Nk.#Mk.#Lk(2096)) ? (this.Properties[#Nk.#Mk.#Lk(2096)] as string) : null;
					this.Properties.Parse(string.Empty);
					this.Properties[#Nk.#Mk.#Lk(2086)] = value;
					this.Properties[#Nk.#Mk.#Lk(2091)] = value2;
					this.Properties[#Nk.#Mk.#Lk(2096)] = value3;
				}
				this.#xXc();
				this.#mXc.Enabled = false;
				return;
			}
			this.#iXc.Enabled = false;
			if (!this.#6yc)
			{
				string value4 = this.Properties[#Nk.#Mk.#Lk(2086)] as string;
				string value5 = this.Properties.Contains(#Nk.#Mk.#Lk(2091)) ? (this.Properties[#Nk.#Mk.#Lk(2091)] as string) : null;
				string value6 = this.Properties.Contains(#Nk.#Mk.#Lk(2096)) ? (this.Properties[#Nk.#Mk.#Lk(2096)] as string) : null;
				this.Properties.Parse(this.#nXc.Text);
				this.Properties[#Nk.#Mk.#Lk(2086)] = value4;
				this.Properties[#Nk.#Mk.#Lk(2091)] = value5;
				this.Properties[#Nk.#Mk.#Lk(2096)] = value6;
			}
			this.#xXc();
			this.#mXc.Enabled = true;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00009FAC File Offset: 0x00008FAC
		private void #rXc(object #sm, KeyEventArgs #tm)
		{
			if (#tm.KeyCode == Keys.Down)
			{
				this.#sXc(#sm, #tm);
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00009FC0 File Offset: 0x00008FC0
		private void #sXc(object #sm, EventArgs #tm)
		{
			if (this.#jXc.Items.Count == 0)
			{
				Cursor value = Cursor.Current;
				Cursor.Current = Cursors.WaitCursor;
				try
				{
					this.#sXc();
				}
				finally
				{
					Cursor.Current = value;
				}
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000A010 File Offset: 0x00009010
		private void #tXc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(2086)] = ((this.#jXc.Text.Length > 0) ? this.#jXc.Text : null);
			}
			this.#xXc();
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0000A064 File Offset: 0x00009064
		private void #uXc(object #sm, EventArgs #tm)
		{
			this.#jXc.Items.Clear();
			this.#sXc(#sm, #tm);
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0000A080 File Offset: 0x00009080
		private void #vXc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				string text = this.Properties.Contains(#Nk.#Mk.#Lk(2096)) ? (this.Properties[#Nk.#Mk.#Lk(2096)] as string) : null;
				try
				{
					this.Properties.Parse(this.#nXc.Text.Trim());
				}
				catch (ArgumentException ex)
				{
					IUIService iuiservice = null;
					if (base.ParentForm != null && base.ParentForm.Site != null)
					{
						iuiservice = (base.ParentForm.Site.GetService(typeof(IUIService)) as IUIService);
					}
					if (iuiservice != null)
					{
						iuiservice.ShowError(ex);
					}
					else
					{
						#jYc.Show(null, ex.Message, MessageBoxIcon.Exclamation);
					}
				}
				if (this.#nXc.Text.Trim().Length > 0 && !this.Properties.Contains(#Nk.#Mk.#Lk(2096)) && text != null)
				{
					this.Properties[#Nk.#Mk.#Lk(2096)] = text;
				}
				this.#nXc.Text = this.Properties.ToDisplayString();
			}
			this.#xXc();
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000A1B4 File Offset: 0x000091B4
		private void #wXc(object #sm, EventArgs #tm)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			try
			{
				short num = #qgc.#jWc(out zero);
				if (!#qgc.#gWc(num))
				{
					throw new ApplicationException(#cTc.#Mk.OdbcConnectionUIControl_SQLAllocEnvFailed);
				}
				num = #qgc.#lWc(zero, out zero2);
				if (!#qgc.#gWc(num))
				{
					throw new ApplicationException(#cTc.#Mk.OdbcConnectionUIControl_SQLAllocConnectFailed);
				}
				string text = this.Properties.ToFullString();
				StringBuilder stringBuilder = new StringBuilder(1024);
				short num2 = 0;
				num = #qgc.#nWc(zero2, base.ParentForm.Handle, text, (short)text.Length, stringBuilder, 1024, out num2, 2);
				if (!#qgc.#gWc(num) && num != 100)
				{
					num = #qgc.#nWc(zero2, base.ParentForm.Handle, null, 0, stringBuilder, 1024, out num2, 2);
				}
				if (!#qgc.#gWc(num) && num != 100)
				{
					throw new ApplicationException(#cTc.#Mk.OdbcConnectionUIControl_SQLDriverConnectFailed);
				}
				#qgc.#vWc(zero2);
				if (num2 > 0)
				{
					this.#uXc(#sm, #tm);
					this.Properties.Parse(stringBuilder.ToString());
					this.#xXc();
				}
			}
			finally
			{
				if (zero2 != IntPtr.Zero)
				{
					#qgc.#wWc(zero2);
				}
				if (zero != IntPtr.Zero)
				{
					#qgc.#xWc(zero);
				}
			}
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000A2F0 File Offset: 0x000092F0
		private void #XSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(2091)] = ((this.#RSc.Text.Trim().Length > 0) ? this.#RSc.Text.Trim() : null);
			}
			this.#xXc();
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000A34C File Offset: 0x0000934C
		private void #YSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(2096)] = ((this.#TSc.Text.Length > 0) ? this.#TSc.Text : null);
				this.#TSc.Text = this.#TSc.Text;
			}
			this.#xXc();
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000A3B4 File Offset: 0x000093B4
		private void #0Sc(object #sm, EventArgs #tm)
		{
			Control control = #sm as Control;
			control.Text = control.Text.Trim();
			this.#xXc();
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000A3E0 File Offset: 0x000093E0
		private void #xXc()
		{
			if (this.Properties[#Nk.#Mk.#Lk(2086)] is string && (this.Properties[#Nk.#Mk.#Lk(2086)] as string).Length > 0 && this.#jXc.Items.Contains(this.Properties[#Nk.#Mk.#Lk(2086)]))
			{
				this.#jXc.Text = (this.Properties[#Nk.#Mk.#Lk(2086)] as string);
			}
			else
			{
				this.#jXc.Text = null;
			}
			this.#nXc.Text = this.Properties.ToDisplayString();
			if (this.Properties.Contains(#Nk.#Mk.#Lk(2091)))
			{
				this.#RSc.Text = (this.Properties[#Nk.#Mk.#Lk(2091)] as string);
			}
			else
			{
				this.#RSc.Text = null;
			}
			if (this.Properties.Contains(#Nk.#Mk.#Lk(2096)))
			{
				this.#TSc.Text = (this.Properties[#Nk.#Mk.#Lk(2096)] as string);
				return;
			}
			this.#TSc.Text = null;
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0000A530 File Offset: 0x00009530
		private void #sXc()
		{
			DataTable dataTable = new DataTable();
			dataTable.Locale = CultureInfo.InvariantCulture;
			try
			{
				OleDbDataReader enumerator = OleDbEnumerator.GetEnumerator(Type.GetTypeFromCLSID(#qgc.#1Vc));
				using (enumerator)
				{
					dataTable.Load(enumerator);
				}
			}
			catch
			{
			}
			this.#eXc = new object[dataTable.Rows.Count];
			for (int i = 0; i < this.#eXc.Length; i++)
			{
				this.#eXc[i] = (dataTable.Rows[i][#Nk.#Mk.#Lk(2101)] as string);
			}
			Array.Sort<object>(this.#eXc);
			if (Thread.CurrentThread == this.#fXc)
			{
				this.#yXc();
				return;
			}
			if (base.IsHandleCreated)
			{
				base.BeginInvoke(new ThreadStart(this.#yXc));
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0000A620 File Offset: 0x00009620
		private void #yXc()
		{
			if (this.#jXc.Items.Count == 0)
			{
				if (this.#eXc.Length != 0)
				{
					this.#jXc.Items.AddRange(this.#eXc);
					return;
				}
				this.#jXc.Items.Add(string.Empty);
			}
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0000A678 File Offset: 0x00009678
		private static string #zXc(string #TL)
		{
			if (#TL == null)
			{
				return null;
			}
			int i = #TL.IndexOf('&');
			if (i == -1)
			{
				return #TL;
			}
			StringBuilder stringBuilder = new StringBuilder(#TL.Substring(0, i));
			while (i < #TL.Length)
			{
				if (#TL[i] == '&')
				{
					i++;
				}
				if (i < #TL.Length)
				{
					stringBuilder.Append(#TL[i]);
				}
				i++;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x0000A6E4 File Offset: 0x000096E4
		private IDataConnectionProperties Properties
		{
			get
			{
				return this.#KSc;
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0000A6EC File Offset: 0x000096EC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.#sS != null)
			{
				this.#sS.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000A70C File Offset: 0x0000970C
		private void #lq()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(OdbcConnectionUIControl));
			this.#gXc = new GroupBox();
			this.#mXc = new TableLayoutPanel();
			this.#nXc = new TextBox();
			this.#oXc = new Button();
			this.#lXc = new RadioButton();
			this.#iXc = new TableLayoutPanel();
			this.#jXc = new ComboBox();
			this.#kXc = new Button();
			this.#hXc = new RadioButton();
			this.#pXc = new GroupBox();
			this.#PSc = new TableLayoutPanel();
			this.#QSc = new Label();
			this.#RSc = new TextBox();
			this.#SSc = new Label();
			this.#TSc = new TextBox();
			this.#gXc.SuspendLayout();
			this.#mXc.SuspendLayout();
			this.#iXc.SuspendLayout();
			this.#pXc.SuspendLayout();
			this.#PSc.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.#gXc, #Nk.#Mk.#Lk(2118));
			this.#gXc.Controls.Add(this.#mXc);
			this.#gXc.Controls.Add(this.#lXc);
			this.#gXc.Controls.Add(this.#iXc);
			this.#gXc.Controls.Add(this.#hXc);
			this.#gXc.FlatStyle = FlatStyle.System;
			this.#gXc.Name = #Nk.#Mk.#Lk(2118);
			this.#gXc.TabStop = false;
			componentResourceManager.ApplyResources(this.#mXc, #Nk.#Mk.#Lk(2143));
			this.#mXc.Controls.Add(this.#nXc, 0, 0);
			this.#mXc.Controls.Add(this.#oXc, 1, 0);
			this.#mXc.Name = #Nk.#Mk.#Lk(2143);
			componentResourceManager.ApplyResources(this.#nXc, #Nk.#Mk.#Lk(2188));
			this.#nXc.Name = #Nk.#Mk.#Lk(2188);
			this.#nXc.Leave += this.#vXc;
			componentResourceManager.ApplyResources(this.#oXc, #Nk.#Mk.#Lk(2221));
			this.#oXc.MinimumSize = new Size(75, 23);
			this.#oXc.Name = #Nk.#Mk.#Lk(2221);
			this.#oXc.Click += this.#wXc;
			componentResourceManager.ApplyResources(this.#lXc, #Nk.#Mk.#Lk(2238));
			this.#lXc.Name = #Nk.#Mk.#Lk(2238);
			this.#lXc.CheckedChanged += this.#qXc;
			componentResourceManager.ApplyResources(this.#iXc, #Nk.#Mk.#Lk(2279));
			this.#iXc.Controls.Add(this.#jXc, 0, 0);
			this.#iXc.Controls.Add(this.#kXc, 1, 0);
			this.#iXc.Name = #Nk.#Mk.#Lk(2279);
			componentResourceManager.ApplyResources(this.#jXc, #Nk.#Mk.#Lk(2320));
			this.#jXc.AutoCompleteMode = AutoCompleteMode.Append;
			this.#jXc.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.#jXc.DropDownStyle = ComboBoxStyle.DropDownList;
			this.#jXc.FormattingEnabled = true;
			this.#jXc.Name = #Nk.#Mk.#Lk(2320);
			this.#jXc.Leave += this.#tXc;
			this.#jXc.SelectedIndexChanged += this.#tXc;
			this.#jXc.KeyDown += this.#rXc;
			this.#jXc.DropDown += this.#sXc;
			componentResourceManager.ApplyResources(this.#kXc, #Nk.#Mk.#Lk(2353));
			this.#kXc.MinimumSize = new Size(75, 23);
			this.#kXc.Name = #Nk.#Mk.#Lk(2353);
			this.#kXc.Click += this.#uXc;
			componentResourceManager.ApplyResources(this.#hXc, #Nk.#Mk.#Lk(2374));
			this.#hXc.Name = #Nk.#Mk.#Lk(2374);
			this.#hXc.CheckedChanged += this.#qXc;
			componentResourceManager.ApplyResources(this.#pXc, #Nk.#Mk.#Lk(2415));
			this.#pXc.Controls.Add(this.#PSc);
			this.#pXc.FlatStyle = FlatStyle.System;
			this.#pXc.Name = #Nk.#Mk.#Lk(2415);
			this.#pXc.TabStop = false;
			componentResourceManager.ApplyResources(this.#PSc, #Nk.#Mk.#Lk(456));
			this.#PSc.Controls.Add(this.#QSc, 0, 0);
			this.#PSc.Controls.Add(this.#RSc, 1, 0);
			this.#PSc.Controls.Add(this.#SSc, 0, 1);
			this.#PSc.Controls.Add(this.#TSc, 1, 1);
			this.#PSc.Name = #Nk.#Mk.#Lk(456);
			componentResourceManager.ApplyResources(this.#QSc, #Nk.#Mk.#Lk(485));
			this.#QSc.FlatStyle = FlatStyle.System;
			this.#QSc.Name = #Nk.#Mk.#Lk(485);
			componentResourceManager.ApplyResources(this.#RSc, #Nk.#Mk.#Lk(506));
			this.#RSc.Name = #Nk.#Mk.#Lk(506);
			this.#RSc.Leave += this.#XSc;
			componentResourceManager.ApplyResources(this.#SSc, #Nk.#Mk.#Lk(527));
			this.#SSc.FlatStyle = FlatStyle.System;
			this.#SSc.Name = #Nk.#Mk.#Lk(527);
			componentResourceManager.ApplyResources(this.#TSc, #Nk.#Mk.#Lk(548));
			this.#TSc.Name = #Nk.#Mk.#Lk(548);
			this.#TSc.UseSystemPasswordChar = true;
			this.#TSc.Leave += this.#YSc;
			componentResourceManager.ApplyResources(this, #Nk.#Mk.#Lk(598));
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.#pXc);
			base.Controls.Add(this.#gXc);
			this.MinimumSize = new Size(350, 215);
			base.Name = #Nk.#Mk.#Lk(2436);
			this.#gXc.ResumeLayout(false);
			this.#gXc.PerformLayout();
			this.#mXc.ResumeLayout(false);
			this.#mXc.PerformLayout();
			this.#iXc.ResumeLayout(false);
			this.#iXc.PerformLayout();
			this.#pXc.ResumeLayout(false);
			this.#pXc.PerformLayout();
			this.#PSc.ResumeLayout(false);
			this.#PSc.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040000C8 RID: 200
		private bool #6yc;

		// Token: 0x040000C9 RID: 201
		private object[] #eXc;

		// Token: 0x040000CA RID: 202
		private Thread #fXc;

		// Token: 0x040000CB RID: 203
		private IDataConnectionProperties #KSc;

		// Token: 0x040000CC RID: 204
		private IContainer #sS;

		// Token: 0x040000CD RID: 205
		private GroupBox #gXc;

		// Token: 0x040000CE RID: 206
		private RadioButton #hXc;

		// Token: 0x040000CF RID: 207
		private TableLayoutPanel #iXc;

		// Token: 0x040000D0 RID: 208
		private ComboBox #jXc;

		// Token: 0x040000D1 RID: 209
		private Button #kXc;

		// Token: 0x040000D2 RID: 210
		private RadioButton #lXc;

		// Token: 0x040000D3 RID: 211
		private TableLayoutPanel #mXc;

		// Token: 0x040000D4 RID: 212
		private TextBox #nXc;

		// Token: 0x040000D5 RID: 213
		private Button #oXc;

		// Token: 0x040000D6 RID: 214
		private GroupBox #pXc;

		// Token: 0x040000D7 RID: 215
		private TableLayoutPanel #PSc;

		// Token: 0x040000D8 RID: 216
		private Label #QSc;

		// Token: 0x040000D9 RID: 217
		private TextBox #RSc;

		// Token: 0x040000DA RID: 218
		private Label #SSc;

		// Token: 0x040000DB RID: 219
		private TextBox #TSc;
	}
}
