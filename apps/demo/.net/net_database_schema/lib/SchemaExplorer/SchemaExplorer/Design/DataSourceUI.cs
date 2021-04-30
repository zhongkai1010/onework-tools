using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using #J2c;
using #Nk;

namespace SchemaExplorer.Design
{
	// Token: 0x020000CD RID: 205
	public partial class DataSourceUI : Form
	{
		// Token: 0x06000701 RID: 1793 RVA: 0x0001FD44 File Offset: 0x0001ED44
		public DataSourceUI()
		{
			this.#lq();
			this.#l3c();
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x0001FD58 File Offset: 0x0001ED58
		public DataSourceUI(DataSource dataSource) : this()
		{
			this.#8lc = dataSource;
			this.#v9b.Text = this.#8lc.Name;
			this.#nXc.Text = this.#8lc.ConnectionString;
			this.#g3c.SelectedIndex = this.#k3c(this.#8lc.ProviderType);
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x0001FDBC File Offset: 0x0001EDBC
		private int #k3c(Type #N0c)
		{
			if (#N0c == null)
			{
				return -1;
			}
			for (int i = 0; i < this.#g3c.Items.Count; i++)
			{
				if (((#N0c)this.#g3c.Items[i]).#kz.FullName == #N0c.FullName)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x0001FE20 File Offset: 0x0001EE20
		private void #l3c()
		{
			this.#g3c.Items.Clear();
			IEnumerable<SchemaProvider> providers = DataSourceManager.GetProviders();
			foreach (SchemaProvider schemaProvider in providers.Where(new Func<SchemaProvider, bool>(DataSourceUI.<>c.<>9.#o6c)))
			{
				this.#g3c.Items.Add(new #N0c(schemaProvider.GetProviderType(), schemaProvider.GetProviderType().Name));
			}
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x0001FFE4 File Offset: 0x0001EFE4
		private void #lq()
		{
			this.#sS = new Container();
			this.#Rac = new Button();
			this.#H8b = new Button();
			this.#g3c = new ComboBox();
			this.#nXc = new TextBox();
			this.#v9b = new TextBox();
			this.#h3c = new Label();
			this.#i3c = new Label();
			this.#u9b = new Label();
			this.#T9b = new ErrorProvider(this.#sS);
			this.#NTc = new Button();
			this.#j3c = new Button();
			((ISupportInitialize)this.#T9b).BeginInit();
			base.SuspendLayout();
			this.#Rac.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#Rac.DialogResult = DialogResult.Cancel;
			this.#Rac.Location = new Point(325, 158);
			this.#Rac.Name = #Mk.#Lk(15888);
			this.#Rac.Size = new Size(75, 23);
			this.#Rac.TabIndex = 6;
			this.#Rac.Text = #Mk.#Lk(15913);
			this.#H8b.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#H8b.Location = new Point(245, 158);
			this.#H8b.Name = #Mk.#Lk(17118);
			this.#H8b.Size = new Size(75, 23);
			this.#H8b.TabIndex = 5;
			this.#H8b.Text = #Mk.#Lk(17131);
			this.#H8b.Click += this.#mac;
			this.#g3c.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.#g3c.DropDownStyle = ComboBoxStyle.DropDownList;
			this.#g3c.Location = new Point(99, 32);
			this.#g3c.Name = #Mk.#Lk(17136);
			this.#g3c.Size = new Size(234, 21);
			this.#g3c.TabIndex = 1;
			this.#g3c.Validating += this.#n3c;
			this.#g3c.SelectedIndexChanged += this.#r3c;
			this.#nXc.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.#T9b.SetIconAlignment(this.#nXc, ErrorIconAlignment.BottomLeft);
			this.#nXc.Location = new Point(99, 56);
			this.#nXc.Multiline = true;
			this.#nXc.Name = #Mk.#Lk(17165);
			this.#nXc.ScrollBars = ScrollBars.Vertical;
			this.#nXc.Size = new Size(274, 94);
			this.#nXc.TabIndex = 2;
			this.#nXc.Validating += this.#o3c;
			this.#v9b.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.#v9b.Location = new Point(99, 8);
			this.#v9b.Name = #Mk.#Lk(17198);
			this.#v9b.Size = new Size(234, 20);
			this.#v9b.TabIndex = 0;
			this.#v9b.Validating += this.#p3c;
			this.#h3c.Location = new Point(5, 58);
			this.#h3c.Name = #Mk.#Lk(17215);
			this.#h3c.Size = new Size(99, 16);
			this.#h3c.TabIndex = 10;
			this.#h3c.Text = #Mk.#Lk(17244);
			this.#i3c.Location = new Point(5, 35);
			this.#i3c.Name = #Mk.#Lk(17269);
			this.#i3c.Size = new Size(91, 16);
			this.#i3c.TabIndex = 9;
			this.#i3c.Text = #Mk.#Lk(17294);
			this.#u9b.Location = new Point(5, 11);
			this.#u9b.Name = #Mk.#Lk(17315);
			this.#u9b.Size = new Size(91, 16);
			this.#u9b.TabIndex = 8;
			this.#u9b.Text = #Mk.#Lk(17328);
			this.#T9b.ContainerControl = this;
			this.#NTc.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#NTc.Location = new Point(164, 158);
			this.#NTc.Name = #Mk.#Lk(17337);
			this.#NTc.Size = new Size(75, 23);
			this.#NTc.TabIndex = 4;
			this.#NTc.Text = #Mk.#Lk(17366);
			this.#NTc.Click += this.#q3c;
			this.#j3c.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.#j3c.CausesValidation = false;
			this.#j3c.Enabled = false;
			this.#j3c.Location = new Point(376, 54);
			this.#j3c.Name = #Mk.#Lk(17375);
			this.#j3c.Size = new Size(24, 23);
			this.#j3c.TabIndex = 3;
			this.#j3c.Text = #Mk.#Lk(15116);
			this.#j3c.UseVisualStyleBackColor = true;
			this.#j3c.Click += this.#s3c;
			base.AcceptButton = this.#H8b;
			this.AutoScaleBaseSize = new Size(5, 13);
			base.CancelButton = this.#Rac;
			base.ClientSize = new Size(410, 190);
			base.Controls.Add(this.#j3c);
			base.Controls.Add(this.#NTc);
			base.Controls.Add(this.#g3c);
			base.Controls.Add(this.#nXc);
			base.Controls.Add(this.#v9b);
			base.Controls.Add(this.#h3c);
			base.Controls.Add(this.#i3c);
			base.Controls.Add(this.#u9b);
			base.Controls.Add(this.#H8b);
			base.Controls.Add(this.#Rac);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			this.MinimumSize = new Size(200, 150);
			base.Name = #Mk.#Lk(17416);
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = #Mk.#Lk(241);
			base.Load += this.#t3c;
			((ISupportInitialize)this.#T9b).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x000206DC File Offset: 0x0001F6DC
		private void #mac(object #sm, EventArgs #tm)
		{
			if (!this.#m3c())
			{
				return;
			}
			if (this.#8lc == null)
			{
				DataSource dataSource = new DataSource(this.#v9b.Text, this.#nXc.Text, ((#N0c)this.#g3c.SelectedItem).#kz);
				DataSourceManager.Save(dataSource);
				DataSourceManager.LastSelectedDataSource = dataSource;
			}
			else
			{
				this.#8lc.Name = this.#v9b.Text;
				this.#8lc.ConnectionString = this.#nXc.Text;
				this.#8lc.ProviderType = ((#N0c)this.#g3c.SelectedItem).#kz;
				if (this.#8lc.Name != this.#8lc.OriginalName && DataSourceManager.Exists(this.#8lc))
				{
					MessageBox.Show(this, #Mk.#Lk(17433), #Mk.#Lk(17506), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				DataSourceManager.Save(this.#8lc);
				DataSourceManager.LastSelectedDataSource = this.#8lc;
			}
			DataSourceManager.Serialize();
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x00020800 File Offset: 0x0001F800
		private bool #m3c()
		{
			this.#p3c(null, new CancelEventArgs());
			this.#n3c(null, new CancelEventArgs());
			this.#o3c(null, new CancelEventArgs());
			return this.#T9b.GetError(this.#v9b) == #Mk.#Lk(2068) && this.#T9b.GetError(this.#g3c) == #Mk.#Lk(2068) && this.#T9b.GetError(this.#nXc) == #Mk.#Lk(2068);
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x00020898 File Offset: 0x0001F898
		private void #n3c(object #sm, CancelEventArgs #tm)
		{
			if (this.#g3c.SelectedIndex < 0)
			{
				this.#T9b.SetError(this.#g3c, #Mk.#Lk(17543));
				return;
			}
			this.#T9b.SetError(this.#g3c, #Mk.#Lk(2068));
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x000208EC File Offset: 0x0001F8EC
		private void #o3c(object #sm, CancelEventArgs #tm)
		{
			if (this.#nXc.Text.Trim().Length == 0)
			{
				this.#T9b.SetError(this.#nXc, #Mk.#Lk(17580));
				return;
			}
			this.#T9b.SetError(this.#nXc, #Mk.#Lk(2068));
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00020948 File Offset: 0x0001F948
		private void #p3c(object #sm, CancelEventArgs #tm)
		{
			if (this.#v9b.Text.Trim().Length == 0)
			{
				this.#T9b.SetError(this.#v9b, #Mk.#Lk(17633));
				return;
			}
			this.#T9b.SetError(this.#v9b, #Mk.#Lk(2068));
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x000209A4 File Offset: 0x0001F9A4
		private void #q3c(object #sm, EventArgs #tm)
		{
			if (!this.#m3c())
			{
				return;
			}
			this.#NTc.Enabled = false;
			this.Text = #Mk.#Lk(17682);
			try
			{
				DataSource state = new DataSource((this.#v9b.Text.Length > 0) ? this.#v9b.Text : #Mk.#Lk(17366), this.#nXc.Text, ((#N0c)this.#g3c.SelectedItem).#kz);
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.#B2c), state);
			}
			catch (Exception ex)
			{
				string text = ex.Message;
				if (ex.InnerException != null)
				{
					text += string.Format(#Mk.#Lk(17719), ex.InnerException.Message);
				}
				MessageBox.Show(this, string.Format(#Mk.#Lk(17728), text), #Mk.#Lk(17753), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x00020AA4 File Offset: 0x0001FAA4
		public IDbConnectionStringEditor GetConnectionStringEditor()
		{
			Type type = (this.#g3c.SelectedItem != null) ? ((#N0c)this.#g3c.SelectedItem).#kz : null;
			if (!(type != null))
			{
				return null;
			}
			return Activator.CreateInstance(type) as IDbConnectionStringEditor;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x00020AF0 File Offset: 0x0001FAF0
		private void #r3c(object #sm, EventArgs #tm)
		{
			IDbConnectionStringEditor connectionStringEditor = this.GetConnectionStringEditor();
			this.#j3c.Enabled = (connectionStringEditor != null && connectionStringEditor.EditorAvailable);
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x00020B1C File Offset: 0x0001FB1C
		private void #s3c(object #sm, EventArgs #tm)
		{
			IDbConnectionStringEditor connectionStringEditor = this.GetConnectionStringEditor();
			if (connectionStringEditor != null && connectionStringEditor.ShowEditor(this.#nXc.Text))
			{
				this.#nXc.Text = connectionStringEditor.ConnectionString;
			}
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x00020B58 File Offset: 0x0001FB58
		private void #B2c(object #8j)
		{
			DataSource dataSource = #8j as DataSource;
			RunWorkerCompletedEventArgs runWorkerCompletedEventArgs = null;
			try
			{
				if (dataSource != null)
				{
					dataSource.TestConnection();
				}
				runWorkerCompletedEventArgs = new RunWorkerCompletedEventArgs(dataSource, null, false);
			}
			catch (Exception error)
			{
				runWorkerCompletedEventArgs = new RunWorkerCompletedEventArgs(null, error, false);
			}
			finally
			{
				if (runWorkerCompletedEventArgs == null)
				{
					runWorkerCompletedEventArgs = new RunWorkerCompletedEventArgs(null, null, false);
				}
				if (this.#v9b.IsHandleCreated)
				{
					this.#v9b.Invoke(new RunWorkerCompletedEventHandler(this.#C2c), new object[]
					{
						dataSource,
						runWorkerCompletedEventArgs
					});
				}
			}
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x00020BF4 File Offset: 0x0001FBF4
		private void #C2c(object #sm, RunWorkerCompletedEventArgs #tm)
		{
			try
			{
				if (base.IsHandleCreated && base.Visible)
				{
					if (#tm.Error == null)
					{
						MessageBox.Show(this, #Mk.#Lk(17778), #Mk.#Lk(17753), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						string text = #tm.Error.Message;
						if (#tm.Error.InnerException != null)
						{
							text += string.Format(#Mk.#Lk(17719), #tm.Error.InnerException.Message);
						}
						MessageBox.Show(this, string.Format(#Mk.#Lk(17728), text), #Mk.#Lk(17753), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
			}
			finally
			{
				this.#NTc.Enabled = true;
				this.Text = #Mk.#Lk(241);
			}
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x00020CD4 File Offset: 0x0001FCD4
		private void #t3c(object #sm, EventArgs #tm)
		{
			this.#NTc.Enabled = true;
			this.Text = #Mk.#Lk(241);
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00020CF4 File Offset: 0x0001FCF4
		// Note: this type is marked as 'beforefieldinit'.
		static DataSourceUI()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (DataSourceUI.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000714 RID: 1812
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x040002A0 RID: 672
		private Label #h3c;

		// Token: 0x040002A1 RID: 673
		private Label #i3c;

		// Token: 0x040002A2 RID: 674
		private Label #u9b;

		// Token: 0x040002A3 RID: 675
		private Button #Rac;

		// Token: 0x040002A6 RID: 678
		private ErrorProvider #T9b;

		// Token: 0x040002A9 RID: 681
		private readonly DataSource #8lc;
	}
}
