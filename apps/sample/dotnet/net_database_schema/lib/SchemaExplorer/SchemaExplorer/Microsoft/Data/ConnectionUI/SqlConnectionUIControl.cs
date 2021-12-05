using System;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using #cTc;
using #Nk;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000034 RID: 52
	public class SqlConnectionUIControl : UserControl, IDataConnectionUIControl
	{
		// Token: 0x0600023F RID: 575 RVA: 0x0000EED4 File Offset: 0x0000DED4
		public SqlConnectionUIControl()
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
			this.#AYc.AccessibleName = SqlConnectionUIControl.#zXc(this.#zYc.Text);
			this.#DYc.AccessibleName = SqlConnectionUIControl.#zXc(this.#BYc.Text);
			this.#fXc = Thread.CurrentThread;
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0000EFCC File Offset: 0x0000DFCC
		public void Initialize(IDataConnectionProperties connectionProperties)
		{
			if (connectionProperties == null)
			{
				throw new ArgumentNullException(#Nk.#Mk.#Lk(174));
			}
			if (!(connectionProperties is SqlConnectionProperties) && !(connectionProperties is OleDBSqlConnectionProperties))
			{
				throw new ArgumentException(#cTc.#Mk.SqlConnectionUIControl_InvalidConnectionProperties);
			}
			if (connectionProperties is OleDBSqlConnectionProperties)
			{
				this.#rYc = (connectionProperties[#Nk.#Mk.#Lk(2469)] as string);
			}
			if (connectionProperties is OdbcConnectionProperties)
			{
				this.#USc.Enabled = false;
			}
			this.#tYc = new SqlConnectionUIControl.#z5c(connectionProperties);
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000F04C File Offset: 0x0000E04C
		public void LoadProperties()
		{
			this.#6yc = true;
			if (this.#rYc != this.Properties.Provider)
			{
				this.#AYc.Items.Clear();
				this.#rYc = this.Properties.Provider;
			}
			this.#vYc.Text = this.Properties.ServerName;
			if (this.Properties.UseWindowsAuthentication)
			{
				this.#wYc.Checked = true;
			}
			else
			{
				this.#xYc.Checked = true;
			}
			if (this.#sYc != this.Properties.UserInstance)
			{
				this.#AYc.Items.Clear();
			}
			this.#sYc = this.Properties.UserInstance;
			this.#RSc.Text = this.Properties.UserName;
			this.#TSc.Text = this.Properties.Password;
			this.#USc.Checked = this.Properties.SavePassword;
			if (this.Properties.DatabaseFile == null || this.Properties.DatabaseFile.Length == 0)
			{
				this.#zYc.Checked = true;
				this.#AYc.Text = this.Properties.DatabaseName;
				this.#DYc.Text = null;
				this.#FYc.Text = null;
			}
			else
			{
				this.#BYc.Checked = true;
				this.#AYc.Text = null;
				this.#DYc.Text = this.Properties.DatabaseFile;
				this.#FYc.Text = this.Properties.LogicalDatabaseName;
			}
			this.#6yc = false;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000F1F4 File Offset: 0x0000E1F4
		protected override void OnRightToLeftChanged(EventArgs e)
		{
			base.OnRightToLeftChanged(e);
			if (base.ParentForm != null && base.ParentForm.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)
			{
				#TVc.#OVc(this.#fYc, this.#uYc);
				#TVc.#OVc(this.#wYc);
				#TVc.#OVc(this.#xYc);
				#TVc.#OVc(this.#PSc);
				#TVc.#OVc(this.#zYc);
				#TVc.#OVc(this.#AYc);
				#TVc.#OVc(this.#BYc);
				#TVc.#OVc(this.#CYc);
				#TVc.#OVc(this.#EYc);
				#TVc.#OVc(this.#FYc);
				return;
			}
			#TVc.#QVc(this.#FYc);
			#TVc.#QVc(this.#EYc);
			#TVc.#QVc(this.#CYc);
			#TVc.#QVc(this.#BYc);
			#TVc.#QVc(this.#AYc);
			#TVc.#QVc(this.#zYc);
			#TVc.#QVc(this.#PSc);
			#TVc.#QVc(this.#xYc);
			#TVc.#QVc(this.#wYc);
			#TVc.#QVc(this.#fYc, this.#uYc);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000F314 File Offset: 0x0000E314
		protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
		{
			Size size = base.Size;
			this.MinimumSize = Size.Empty;
			base.ScaleControl(factor, specified);
			this.MinimumSize = new Size((int)Math.Round((double)((float)size.Width * factor.Width)), (int)Math.Round((double)((float)size.Height * factor.Height)));
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000F374 File Offset: 0x0000E374
		[UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (base.ActiveControl == this.#zYc && (keyData & Keys.KeyCode) == Keys.Down)
			{
				this.#BYc.Focus();
				return true;
			}
			if (base.ActiveControl == this.#BYc && (keyData & Keys.KeyCode) == Keys.Down)
			{
				this.#zYc.Focus();
				return true;
			}
			return base.ProcessDialogKey(keyData);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000F3D8 File Offset: 0x0000E3D8
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (base.Parent == null)
			{
				this.OnFontChanged(e);
			}
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000F3F0 File Offset: 0x0000E3F0
		private void #rXc(object #sm, KeyEventArgs #tm)
		{
			if (#tm.KeyCode == Keys.Down)
			{
				if (#sm == this.#vYc)
				{
					this.#GYc(#sm, #tm);
				}
				if (#sm == this.#AYc)
				{
					this.#MYc(#sm, #tm);
				}
			}
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000F420 File Offset: 0x0000E420
		private void #GYc(object #sm, EventArgs #tm)
		{
			if (this.#vYc.Items.Count == 0)
			{
				Cursor value = Cursor.Current;
				Cursor.Current = Cursors.WaitCursor;
				try
				{
					if (this.#pYc == null || this.#pYc.ThreadState == ThreadState.Stopped)
					{
						this.#GYc();
					}
					else if (this.#pYc.ThreadState == ThreadState.Running)
					{
						this.#pYc.Join();
						this.#PYc();
					}
				}
				finally
				{
					Cursor.Current = value;
				}
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000F4A8 File Offset: 0x0000E4A8
		private void #hYc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties.ServerName = this.#vYc.Text;
				if (this.#vYc.Items.Count == 0 && this.#pYc == null)
				{
					this.#pYc = new Thread(new ThreadStart(this.#GYc));
					this.#pYc.Start();
				}
			}
			this.#JYc(#sm, #tm);
			this.#AYc.Items.Clear();
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000F528 File Offset: 0x0000E528
		private void #HYc(object #sm, EventArgs #tm)
		{
			this.#vYc.Items.Clear();
			this.#GYc(#sm, #tm);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000F544 File Offset: 0x0000E544
		private void #IYc(object #sm, EventArgs #tm)
		{
			if (this.#wYc.Checked)
			{
				if (!this.#6yc)
				{
					this.Properties.UseWindowsAuthentication = true;
					this.Properties.UserName = null;
					this.Properties.Password = null;
					this.Properties.SavePassword = false;
				}
				this.#PSc.Enabled = false;
			}
			else
			{
				if (!this.#6yc)
				{
					this.Properties.UseWindowsAuthentication = false;
					this.#XSc(#sm, #tm);
					this.#YSc(#sm, #tm);
					this.#ZSc(#sm, #tm);
				}
				this.#PSc.Enabled = true;
			}
			this.#JYc(#sm, #tm);
			this.#AYc.Items.Clear();
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000F5F4 File Offset: 0x0000E5F4
		private void #XSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties.UserName = this.#RSc.Text;
			}
			this.#JYc(#sm, #tm);
			this.#AYc.Items.Clear();
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000F62C File Offset: 0x0000E62C
		private void #YSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties.Password = this.#TSc.Text;
				this.#TSc.Text = this.#TSc.Text;
			}
			this.#AYc.Items.Clear();
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000F680 File Offset: 0x0000E680
		private void #ZSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties.SavePassword = this.#USc.Checked;
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000F6A0 File Offset: 0x0000E6A0
		private void #JYc(object #sm, EventArgs #tm)
		{
			if (this.#vYc.Text.Trim().Length > 0 && (this.#wYc.Checked || this.#RSc.Text.Trim().Length > 0))
			{
				this.#yYc.Enabled = true;
				return;
			}
			this.#yYc.Enabled = false;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000F704 File Offset: 0x0000E704
		private void #KYc(object #sm, EventArgs #tm)
		{
			if (this.#zYc.Checked)
			{
				this.#LYc(#sm, #tm);
				this.#NYc(#sm, #tm);
				this.#AYc.Enabled = true;
				this.#CYc.Enabled = false;
				this.#EYc.Enabled = false;
				this.#FYc.Enabled = false;
				return;
			}
			this.#NYc(#sm, #tm);
			this.#OYc(#sm, #tm);
			this.#AYc.Enabled = false;
			this.#CYc.Enabled = true;
			this.#EYc.Enabled = true;
			this.#FYc.Enabled = true;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000F7A0 File Offset: 0x0000E7A0
		private void #LYc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties.DatabaseName = this.#AYc.Text;
				if (this.#AYc.Items.Count == 0 && this.#qYc == null)
				{
					this.#qYc = new Thread(new ThreadStart(this.#MYc));
					this.#qYc.Start();
				}
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000F808 File Offset: 0x0000E808
		private void #MYc(object #sm, EventArgs #tm)
		{
			if (this.#AYc.Items.Count == 0)
			{
				Cursor value = Cursor.Current;
				Cursor.Current = Cursors.WaitCursor;
				try
				{
					if (this.#qYc == null || this.#qYc.ThreadState == ThreadState.Stopped)
					{
						this.#MYc();
					}
					else if (this.#qYc.ThreadState == ThreadState.Running)
					{
						this.#qYc.Join();
						this.#QYc();
					}
				}
				finally
				{
					Cursor.Current = value;
				}
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000F890 File Offset: 0x0000E890
		private void #NYc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				if (this.#zYc.Checked)
				{
					this.Properties.DatabaseFile = null;
					return;
				}
				this.Properties.DatabaseFile = this.#DYc.Text;
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000F8CC File Offset: 0x0000E8CC
		private void #OYc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				if (this.#zYc.Checked)
				{
					this.Properties.LogicalDatabaseName = null;
					return;
				}
				this.Properties.LogicalDatabaseName = this.#FYc.Text;
			}
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000F908 File Offset: 0x0000E908
		private void #WSc(object #sm, EventArgs #tm)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = #cTc.#Mk.SqlConnectionUIControl_BrowseFileTitle;
			openFileDialog.Multiselect = false;
			openFileDialog.RestoreDirectory = true;
			openFileDialog.Filter = #cTc.#Mk.SqlConnectionUIControl_BrowseFileFilter;
			openFileDialog.DefaultExt = #cTc.#Mk.SqlConnectionUIControl_BrowseFileDefaultExt;
			if (base.Container != null)
			{
				base.Container.Add(openFileDialog);
			}
			try
			{
				DialogResult dialogResult = openFileDialog.ShowDialog(base.ParentForm);
				if (dialogResult == DialogResult.OK)
				{
					this.#DYc.Text = openFileDialog.FileName.Trim();
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

		// Token: 0x06000255 RID: 597 RVA: 0x0000F9B4 File Offset: 0x0000E9B4
		private void #0Sc(object #sm, EventArgs #tm)
		{
			Control control = #sm as Control;
			control.Text = control.Text.Trim();
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000F9DC File Offset: 0x0000E9DC
		private void #GYc()
		{
			DataTable dataTable = null;
			try
			{
				dataTable = SqlDataSourceEnumerator.Instance.GetDataSources();
			}
			catch
			{
				dataTable = new DataTable();
				dataTable.Locale = CultureInfo.InvariantCulture;
			}
			this.#13 = new object[dataTable.Rows.Count];
			for (int i = 0; i < this.#13.Length; i++)
			{
				string text = dataTable.Rows[i][#Nk.#Mk.#Lk(3581)].ToString();
				string text2 = dataTable.Rows[i][#Nk.#Mk.#Lk(3598)].ToString();
				if (text2.Length == 0)
				{
					this.#13[i] = text;
				}
				else
				{
					this.#13[i] = text + #Nk.#Mk.#Lk(3505) + text2;
				}
			}
			Array.Sort<object>(this.#13);
			if (Thread.CurrentThread == this.#fXc)
			{
				this.#PYc();
				return;
			}
			if (base.IsHandleCreated)
			{
				base.BeginInvoke(new ThreadStart(this.#PYc));
			}
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000FAF0 File Offset: 0x0000EAF0
		private void #PYc()
		{
			if (this.#vYc.Items.Count == 0)
			{
				if (this.#13.Length != 0)
				{
					this.#vYc.Items.AddRange(this.#13);
					return;
				}
				this.#vYc.Items.Add(string.Empty);
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000FB48 File Offset: 0x0000EB48
		private void #MYc()
		{
			DataTable dataTable = null;
			IDbConnection dbConnection = null;
			IDataReader dataReader = null;
			try
			{
				dbConnection = this.Properties.#w5c();
				IDbCommand dbCommand = dbConnection.CreateCommand();
				dbCommand.CommandText = #Nk.#Mk.#Lk(3615);
				dbConnection.Open();
				if ((int)dbCommand.ExecuteScalar() == 1)
				{
					dbCommand.CommandText = #Nk.#Mk.#Lk(3789);
				}
				else
				{
					dbCommand.CommandText = #Nk.#Mk.#Lk(3862);
				}
				dataReader = dbCommand.ExecuteReader();
				dataTable = new DataTable();
				dataTable.Locale = CultureInfo.CurrentCulture;
				dataTable.Load(dataReader);
			}
			catch
			{
				dataTable = new DataTable();
				dataTable.Locale = CultureInfo.InvariantCulture;
			}
			finally
			{
				if (dataReader != null)
				{
					dataReader.Dispose();
				}
				if (dbConnection != null)
				{
					dbConnection.Dispose();
				}
			}
			this.#oYc = new object[dataTable.Rows.Count];
			for (int i = 0; i < this.#oYc.Length; i++)
			{
				this.#oYc[i] = dataTable.Rows[i][#Nk.#Mk.#Lk(1534)];
			}
			if (Thread.CurrentThread == this.#fXc)
			{
				this.#QYc();
				return;
			}
			if (base.IsHandleCreated)
			{
				base.BeginInvoke(new ThreadStart(this.#QYc));
			}
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000FC9C File Offset: 0x0000EC9C
		private void #QYc()
		{
			if (this.#AYc.Items.Count == 0)
			{
				if (this.#oYc.Length != 0)
				{
					this.#AYc.Items.AddRange(this.#oYc);
				}
				else
				{
					this.#AYc.Items.Add(string.Empty);
				}
			}
			this.#qYc = null;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000FCFC File Offset: 0x0000ECFC
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

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600025B RID: 603 RVA: 0x0000FD68 File Offset: 0x0000ED68
		private SqlConnectionUIControl.#z5c Properties
		{
			get
			{
				return this.#tYc;
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000FD70 File Offset: 0x0000ED70
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.#sS != null)
			{
				this.#sS.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000FD90 File Offset: 0x0000ED90
		private void #lq()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SqlConnectionUIControl));
			this.#fYc = new Label();
			this.#uYc = new TableLayoutPanel();
			this.#vYc = new ComboBox();
			this.#kXc = new Button();
			this.#OSc = new GroupBox();
			this.#PSc = new TableLayoutPanel();
			this.#QSc = new Label();
			this.#RSc = new TextBox();
			this.#SSc = new Label();
			this.#TSc = new TextBox();
			this.#USc = new CheckBox();
			this.#xYc = new RadioButton();
			this.#wYc = new RadioButton();
			this.#yYc = new GroupBox();
			this.#FYc = new TextBox();
			this.#EYc = new Label();
			this.#CYc = new TableLayoutPanel();
			this.#DYc = new TextBox();
			this.#o9b = new Button();
			this.#BYc = new RadioButton();
			this.#AYc = new ComboBox();
			this.#zYc = new RadioButton();
			this.#uYc.SuspendLayout();
			this.#OSc.SuspendLayout();
			this.#PSc.SuspendLayout();
			this.#yYc.SuspendLayout();
			this.#CYc.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.#fYc, #Nk.#Mk.#Lk(3420));
			this.#fYc.FlatStyle = FlatStyle.System;
			this.#fYc.Name = #Nk.#Mk.#Lk(3420);
			componentResourceManager.ApplyResources(this.#uYc, #Nk.#Mk.#Lk(3975));
			this.#uYc.Controls.Add(this.#vYc, 0, 0);
			this.#uYc.Controls.Add(this.#kXc, 1, 0);
			this.#uYc.Name = #Nk.#Mk.#Lk(3975);
			componentResourceManager.ApplyResources(this.#vYc, #Nk.#Mk.#Lk(4008));
			this.#vYc.AutoCompleteMode = AutoCompleteMode.Append;
			this.#vYc.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.#vYc.FormattingEnabled = true;
			this.#vYc.Name = #Nk.#Mk.#Lk(4008);
			this.#vYc.Leave += this.#0Sc;
			this.#vYc.TextChanged += this.#hYc;
			this.#vYc.KeyDown += this.#rXc;
			this.#vYc.DropDown += this.#GYc;
			componentResourceManager.ApplyResources(this.#kXc, #Nk.#Mk.#Lk(2353));
			this.#kXc.MinimumSize = new Size(75, 23);
			this.#kXc.Name = #Nk.#Mk.#Lk(2353);
			this.#kXc.Click += this.#HYc;
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
			componentResourceManager.ApplyResources(this.#yYc, #Nk.#Mk.#Lk(4115));
			this.#yYc.Controls.Add(this.#FYc);
			this.#yYc.Controls.Add(this.#EYc);
			this.#yYc.Controls.Add(this.#CYc);
			this.#yYc.Controls.Add(this.#BYc);
			this.#yYc.Controls.Add(this.#AYc);
			this.#yYc.Controls.Add(this.#zYc);
			this.#yYc.FlatStyle = FlatStyle.System;
			this.#yYc.Name = #Nk.#Mk.#Lk(4115);
			this.#yYc.TabStop = false;
			componentResourceManager.ApplyResources(this.#FYc, #Nk.#Mk.#Lk(4140));
			this.#FYc.Name = #Nk.#Mk.#Lk(4140);
			this.#FYc.Leave += this.#0Sc;
			this.#FYc.TextChanged += this.#OYc;
			componentResourceManager.ApplyResources(this.#EYc, #Nk.#Mk.#Lk(4177));
			this.#EYc.FlatStyle = FlatStyle.System;
			this.#EYc.Name = #Nk.#Mk.#Lk(4177);
			componentResourceManager.ApplyResources(this.#CYc, #Nk.#Mk.#Lk(4210));
			this.#CYc.Controls.Add(this.#DYc, 0, 0);
			this.#CYc.Controls.Add(this.#o9b, 1, 0);
			this.#CYc.Name = #Nk.#Mk.#Lk(4210);
			componentResourceManager.ApplyResources(this.#DYc, #Nk.#Mk.#Lk(4251));
			this.#DYc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.#DYc.AutoCompleteSource = AutoCompleteSource.FileSystem;
			this.#DYc.Name = #Nk.#Mk.#Lk(4251);
			this.#DYc.Leave += this.#0Sc;
			this.#DYc.TextChanged += this.#NYc;
			componentResourceManager.ApplyResources(this.#o9b, #Nk.#Mk.#Lk(418));
			this.#o9b.MinimumSize = new Size(75, 23);
			this.#o9b.Name = #Nk.#Mk.#Lk(418);
			this.#o9b.Click += this.#WSc;
			componentResourceManager.ApplyResources(this.#BYc, #Nk.#Mk.#Lk(4280));
			this.#BYc.Name = #Nk.#Mk.#Lk(4280);
			this.#BYc.CheckedChanged += this.#KYc;
			componentResourceManager.ApplyResources(this.#AYc, #Nk.#Mk.#Lk(4317));
			this.#AYc.AutoCompleteMode = AutoCompleteMode.Append;
			this.#AYc.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.#AYc.FormattingEnabled = true;
			this.#AYc.Name = #Nk.#Mk.#Lk(4317);
			this.#AYc.Leave += this.#0Sc;
			this.#AYc.TextChanged += this.#LYc;
			this.#AYc.KeyDown += this.#rXc;
			this.#AYc.DropDown += this.#MYc;
			componentResourceManager.ApplyResources(this.#zYc, #Nk.#Mk.#Lk(4350));
			this.#zYc.Name = #Nk.#Mk.#Lk(4350);
			this.#zYc.CheckedChanged += this.#KYc;
			componentResourceManager.ApplyResources(this, #Nk.#Mk.#Lk(598));
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.#yYc);
			base.Controls.Add(this.#OSc);
			base.Controls.Add(this.#uYc);
			base.Controls.Add(this.#fYc);
			this.MinimumSize = new Size(350, 360);
			base.Name = #Nk.#Mk.#Lk(4387);
			this.#uYc.ResumeLayout(false);
			this.#uYc.PerformLayout();
			this.#OSc.ResumeLayout(false);
			this.#OSc.PerformLayout();
			this.#PSc.ResumeLayout(false);
			this.#PSc.PerformLayout();
			this.#yYc.ResumeLayout(false);
			this.#yYc.PerformLayout();
			this.#CYc.ResumeLayout(false);
			this.#CYc.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000113 RID: 275
		private bool #6yc;

		// Token: 0x04000114 RID: 276
		private object[] #13;

		// Token: 0x04000115 RID: 277
		private object[] #oYc;

		// Token: 0x04000116 RID: 278
		private Thread #fXc;

		// Token: 0x04000117 RID: 279
		private Thread #pYc;

		// Token: 0x04000118 RID: 280
		private Thread #qYc;

		// Token: 0x04000119 RID: 281
		private string #rYc;

		// Token: 0x0400011A RID: 282
		private bool #sYc;

		// Token: 0x0400011B RID: 283
		private SqlConnectionUIControl.#z5c #tYc;

		// Token: 0x0400011C RID: 284
		private IContainer #sS;

		// Token: 0x0400011D RID: 285
		private Label #fYc;

		// Token: 0x0400011E RID: 286
		private TableLayoutPanel #uYc;

		// Token: 0x0400011F RID: 287
		private ComboBox #vYc;

		// Token: 0x04000120 RID: 288
		private Button #kXc;

		// Token: 0x04000121 RID: 289
		private GroupBox #OSc;

		// Token: 0x04000122 RID: 290
		private RadioButton #wYc;

		// Token: 0x04000123 RID: 291
		private RadioButton #xYc;

		// Token: 0x04000124 RID: 292
		private TableLayoutPanel #PSc;

		// Token: 0x04000125 RID: 293
		private Label #QSc;

		// Token: 0x04000126 RID: 294
		private TextBox #RSc;

		// Token: 0x04000127 RID: 295
		private Label #SSc;

		// Token: 0x04000128 RID: 296
		private TextBox #TSc;

		// Token: 0x04000129 RID: 297
		private CheckBox #USc;

		// Token: 0x0400012A RID: 298
		private GroupBox #yYc;

		// Token: 0x0400012B RID: 299
		private RadioButton #zYc;

		// Token: 0x0400012C RID: 300
		private ComboBox #AYc;

		// Token: 0x0400012D RID: 301
		private RadioButton #BYc;

		// Token: 0x0400012E RID: 302
		private TableLayoutPanel #CYc;

		// Token: 0x0400012F RID: 303
		private TextBox #DYc;

		// Token: 0x04000130 RID: 304
		private Button #o9b;

		// Token: 0x04000131 RID: 305
		private Label #EYc;

		// Token: 0x04000132 RID: 306
		private TextBox #FYc;

		// Token: 0x02000035 RID: 53
		private sealed class #z5c
		{
			// Token: 0x0600025E RID: 606 RVA: 0x00010824 File Offset: 0x0000F824
			public #z5c(IDataConnectionProperties properties)
			{
				this.#bp = properties;
			}

			// Token: 0x17000066 RID: 102
			// (get) Token: 0x0600025F RID: 607 RVA: 0x00010834 File Offset: 0x0000F834
			public string Provider
			{
				get
				{
					if (this.#bp is OleDBSqlConnectionProperties)
					{
						return this.#bp[#Nk.#Mk.#Lk(2469)] as string;
					}
					return null;
				}
			}

			// Token: 0x17000067 RID: 103
			// (get) Token: 0x06000260 RID: 608 RVA: 0x00010860 File Offset: 0x0000F860
			// (set) Token: 0x06000261 RID: 609 RVA: 0x00010878 File Offset: 0x0000F878
			public string ServerName
			{
				get
				{
					return this.#bp[this.ServerNameProperty] as string;
				}
				set
				{
					if (value != null && value.Trim().Length > 0)
					{
						this.#bp[this.ServerNameProperty] = value.Trim();
						return;
					}
					this.#bp.Reset(this.ServerNameProperty);
				}
			}

			// Token: 0x17000068 RID: 104
			// (get) Token: 0x06000262 RID: 610 RVA: 0x000108B4 File Offset: 0x0000F8B4
			public bool UserInstance
			{
				get
				{
					return this.#bp is SqlConnectionProperties && (bool)this.#bp[#Nk.#Mk.#Lk(3535)];
				}
			}

			// Token: 0x17000069 RID: 105
			// (get) Token: 0x06000263 RID: 611 RVA: 0x000108E0 File Offset: 0x0000F8E0
			// (set) Token: 0x06000264 RID: 612 RVA: 0x000109F0 File Offset: 0x0000F9F0
			public bool UseWindowsAuthentication
			{
				get
				{
					if (this.#bp is SqlConnectionProperties)
					{
						return (bool)this.#bp[#Nk.#Mk.#Lk(2568)];
					}
					if (this.#bp is OleDBConnectionProperties)
					{
						return this.#bp.Contains(#Nk.#Mk.#Lk(2568)) && this.#bp[#Nk.#Mk.#Lk(2568)] is string && (this.#bp[#Nk.#Mk.#Lk(2568)] as string).Equals(#Nk.#Mk.#Lk(2597), StringComparison.OrdinalIgnoreCase);
					}
					return this.#bp is OdbcConnectionProperties && (this.#bp.Contains(#Nk.#Mk.#Lk(19320)) && this.#bp[#Nk.#Mk.#Lk(19320)] is string) && (this.#bp[#Nk.#Mk.#Lk(19320)] as string).Equals(#Nk.#Mk.#Lk(19345), StringComparison.OrdinalIgnoreCase);
				}
				set
				{
					if (this.#bp is SqlConnectionProperties)
					{
						if (value)
						{
							this.#bp[#Nk.#Mk.#Lk(2568)] = value;
						}
						else
						{
							this.#bp.Reset(#Nk.#Mk.#Lk(2568));
						}
					}
					if (this.#bp is OleDBConnectionProperties)
					{
						if (value)
						{
							this.#bp[#Nk.#Mk.#Lk(2568)] = #Nk.#Mk.#Lk(2597);
						}
						else
						{
							this.#bp.Reset(#Nk.#Mk.#Lk(2568));
						}
					}
					if (this.#bp is OdbcConnectionProperties)
					{
						if (value)
						{
							this.#bp[#Nk.#Mk.#Lk(19320)] = #Nk.#Mk.#Lk(19345);
							return;
						}
						this.#bp.Remove(#Nk.#Mk.#Lk(19320));
					}
				}
			}

			// Token: 0x1700006A RID: 106
			// (get) Token: 0x06000265 RID: 613 RVA: 0x00010ACC File Offset: 0x0000FACC
			// (set) Token: 0x06000266 RID: 614 RVA: 0x00010AE4 File Offset: 0x0000FAE4
			public string UserName
			{
				get
				{
					return this.#bp[this.UserNameProperty] as string;
				}
				set
				{
					if (value != null && value.Trim().Length > 0)
					{
						this.#bp[this.UserNameProperty] = value.Trim();
						return;
					}
					this.#bp.Reset(this.UserNameProperty);
				}
			}

			// Token: 0x1700006B RID: 107
			// (get) Token: 0x06000267 RID: 615 RVA: 0x00010B20 File Offset: 0x0000FB20
			// (set) Token: 0x06000268 RID: 616 RVA: 0x00010B38 File Offset: 0x0000FB38
			public string Password
			{
				get
				{
					return this.#bp[this.PasswordProperty] as string;
				}
				set
				{
					if (value != null && value.Length > 0)
					{
						this.#bp[this.PasswordProperty] = value;
						return;
					}
					this.#bp.Reset(this.PasswordProperty);
				}
			}

			// Token: 0x1700006C RID: 108
			// (get) Token: 0x06000269 RID: 617 RVA: 0x00010B6C File Offset: 0x0000FB6C
			// (set) Token: 0x0600026A RID: 618 RVA: 0x00010B98 File Offset: 0x0000FB98
			public bool SavePassword
			{
				get
				{
					return !(this.#bp is OdbcConnectionProperties) && (bool)this.#bp[#Nk.#Mk.#Lk(212)];
				}
				set
				{
					if (value)
					{
						this.#bp[#Nk.#Mk.#Lk(212)] = value;
						return;
					}
					this.#bp.Reset(#Nk.#Mk.#Lk(212));
				}
			}

			// Token: 0x1700006D RID: 109
			// (get) Token: 0x0600026B RID: 619 RVA: 0x00010BD0 File Offset: 0x0000FBD0
			// (set) Token: 0x0600026C RID: 620 RVA: 0x00010BE8 File Offset: 0x0000FBE8
			public string DatabaseName
			{
				get
				{
					return this.#bp[this.DatabaseNameProperty] as string;
				}
				set
				{
					if (value != null && value.Trim().Length > 0)
					{
						this.#bp[this.DatabaseNameProperty] = value.Trim();
						return;
					}
					this.#bp.Reset(this.DatabaseNameProperty);
				}
			}

			// Token: 0x1700006E RID: 110
			// (get) Token: 0x0600026D RID: 621 RVA: 0x00010C24 File Offset: 0x0000FC24
			// (set) Token: 0x0600026E RID: 622 RVA: 0x00010C3C File Offset: 0x0000FC3C
			public string DatabaseFile
			{
				get
				{
					return this.#bp[this.DatabaseFileProperty] as string;
				}
				set
				{
					if (value != null && value.Trim().Length > 0)
					{
						this.#bp[this.DatabaseFileProperty] = value.Trim();
						return;
					}
					this.#bp.Reset(this.DatabaseFileProperty);
				}
			}

			// Token: 0x1700006F RID: 111
			// (get) Token: 0x0600026F RID: 623 RVA: 0x00010C78 File Offset: 0x0000FC78
			// (set) Token: 0x06000270 RID: 624 RVA: 0x00010C80 File Offset: 0x0000FC80
			public string LogicalDatabaseName
			{
				get
				{
					return this.DatabaseName;
				}
				set
				{
					this.DatabaseName = value;
				}
			}

			// Token: 0x06000271 RID: 625 RVA: 0x00010C8C File Offset: 0x0000FC8C
			public IDbConnection #w5c()
			{
				IDbConnection result = null;
				string text = string.Empty;
				if (this.#bp is SqlConnectionProperties || this.#bp is OleDBConnectionProperties)
				{
					if (this.#bp is OleDBConnectionProperties)
					{
						text = text + #Nk.#Mk.#Lk(19350) + this.#bp[#Nk.#Mk.#Lk(2469)].ToString() + #Nk.#Mk.#Lk(19363);
					}
					text = text + #Nk.#Mk.#Lk(19368) + this.ServerName.Replace(#Nk.#Mk.#Lk(971), #Nk.#Mk.#Lk(976)) + #Nk.#Mk.#Lk(19389);
					if (this.UserInstance)
					{
						text += #Nk.#Mk.#Lk(19394);
					}
					if (this.UseWindowsAuthentication)
					{
						text = text + #Nk.#Mk.#Lk(19423) + this.#bp[#Nk.#Mk.#Lk(2568)].ToString() + #Nk.#Mk.#Lk(19363);
					}
					else
					{
						text = text + #Nk.#Mk.#Lk(19452) + this.UserName.Replace(#Nk.#Mk.#Lk(971), #Nk.#Mk.#Lk(976)) + #Nk.#Mk.#Lk(19389);
						text = text + #Nk.#Mk.#Lk(19465) + this.Password.Replace(#Nk.#Mk.#Lk(971), #Nk.#Mk.#Lk(976)) + #Nk.#Mk.#Lk(19389);
					}
					if (this.#bp is SqlConnectionProperties)
					{
						text += #Nk.#Mk.#Lk(19482);
					}
				}
				if (this.#bp is OdbcConnectionProperties)
				{
					text += #Nk.#Mk.#Lk(19503);
					text = text + #Nk.#Mk.#Lk(19532) + this.ServerName.Replace(#Nk.#Mk.#Lk(19545), #Nk.#Mk.#Lk(19550)) + #Nk.#Mk.#Lk(19555);
					if (this.UseWindowsAuthentication)
					{
						text += #Nk.#Mk.#Lk(19560);
					}
					else
					{
						text = text + #Nk.#Mk.#Lk(19593) + this.UserName.Replace(#Nk.#Mk.#Lk(19545), #Nk.#Mk.#Lk(19550)) + #Nk.#Mk.#Lk(19555);
						text = text + #Nk.#Mk.#Lk(19602) + this.Password.Replace(#Nk.#Mk.#Lk(19545), #Nk.#Mk.#Lk(19550)) + #Nk.#Mk.#Lk(19555);
					}
				}
				if (this.#bp is SqlConnectionProperties)
				{
					result = new SqlConnection(text);
				}
				if (this.#bp is OleDBConnectionProperties)
				{
					result = new OleDbConnection(text);
				}
				if (this.#bp is OdbcConnectionProperties)
				{
					result = new OdbcConnection(text);
				}
				return result;
			}

			// Token: 0x17000070 RID: 112
			// (get) Token: 0x06000272 RID: 626 RVA: 0x00010F4C File Offset: 0x0000FF4C
			private string ServerNameProperty
			{
				get
				{
					if (this.#bp is SqlConnectionProperties)
					{
						return #Nk.#Mk.#Lk(241);
					}
					if (this.#bp is OleDBConnectionProperties)
					{
						return #Nk.#Mk.#Lk(241);
					}
					if (!(this.#bp is OdbcConnectionProperties))
					{
						return null;
					}
					return #Nk.#Mk.#Lk(3411);
				}
			}

			// Token: 0x17000071 RID: 113
			// (get) Token: 0x06000273 RID: 627 RVA: 0x00010FA4 File Offset: 0x0000FFA4
			private string UserNameProperty
			{
				get
				{
					if (this.#bp is SqlConnectionProperties)
					{
						return #Nk.#Mk.#Lk(263);
					}
					if (this.#bp is OleDBConnectionProperties)
					{
						return #Nk.#Mk.#Lk(263);
					}
					if (!(this.#bp is OdbcConnectionProperties))
					{
						return null;
					}
					return #Nk.#Mk.#Lk(276);
				}
			}

			// Token: 0x17000072 RID: 114
			// (get) Token: 0x06000274 RID: 628 RVA: 0x00010FFC File Offset: 0x0000FFFC
			private string PasswordProperty
			{
				get
				{
					if (this.#bp is SqlConnectionProperties)
					{
						return #Nk.#Mk.#Lk(2742);
					}
					if (this.#bp is OleDBConnectionProperties)
					{
						return #Nk.#Mk.#Lk(2742);
					}
					if (!(this.#bp is OdbcConnectionProperties))
					{
						return null;
					}
					return #Nk.#Mk.#Lk(318);
				}
			}

			// Token: 0x17000073 RID: 115
			// (get) Token: 0x06000275 RID: 629 RVA: 0x00011054 File Offset: 0x00010054
			private string DatabaseNameProperty
			{
				get
				{
					if (this.#bp is SqlConnectionProperties)
					{
						return #Nk.#Mk.#Lk(2755);
					}
					if (this.#bp is OleDBConnectionProperties)
					{
						return #Nk.#Mk.#Lk(2755);
					}
					if (!(this.#bp is OdbcConnectionProperties))
					{
						return null;
					}
					return #Nk.#Mk.#Lk(19611);
				}
			}

			// Token: 0x17000074 RID: 116
			// (get) Token: 0x06000276 RID: 630 RVA: 0x000110AC File Offset: 0x000100AC
			private string DatabaseFileProperty
			{
				get
				{
					if (this.#bp is SqlConnectionProperties)
					{
						return #Nk.#Mk.#Lk(3510);
					}
					if (this.#bp is OleDBConnectionProperties)
					{
						return #Nk.#Mk.#Lk(19649);
					}
					if (!(this.#bp is OdbcConnectionProperties))
					{
						return null;
					}
					return #Nk.#Mk.#Lk(19624);
				}
			}

			// Token: 0x06000277 RID: 631 RVA: 0x00011104 File Offset: 0x00010104
			// Note: this type is marked as 'beforefieldinit'.
			static #z5c()
			{
				bool flag = false;
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				if (SqlConnectionUIControl.#z5c.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Nk.#Mk.#Lk(774)))
				{
					return;
				}
				throw new SecurityException(#Nk.#Mk.#Lk(799));
			}

			// Token: 0x06000278 RID: 632
			[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
			[return: MarshalAs(UnmanagedType.Bool)]
			private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

			// Token: 0x04000133 RID: 307
			private IDataConnectionProperties #bp;
		}
	}
}
