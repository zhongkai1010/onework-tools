using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using #Nk;

namespace SchemaExplorer.Design
{
	// Token: 0x020000D8 RID: 216
	public partial class ViewSchemaPickerUI : Form
	{
		// Token: 0x060007A9 RID: 1961 RVA: 0x00025A60 File Offset: 0x00024A60
		public ViewSchemaPickerUI() : this(false)
		{
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x00025A6C File Offset: 0x00024A6C
		public ViewSchemaPickerUI(bool allowMultiple)
		{
			this.#lq();
			if (allowMultiple)
			{
				this.#l4c.SelectionMode = SelectionMode.MultiExtended;
				return;
			}
			this.#l4c.SelectionMode = SelectionMode.One;
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x00025A98 File Offset: 0x00024A98
		public void Start(object value)
		{
			if (value is ViewSchema)
			{
				this.#m4c = (ViewSchema)value;
				this.#n4c = null;
				return;
			}
			if (value is ViewSchemaCollection)
			{
				this.#m4c = null;
				this.#n4c = (ViewSchemaCollection)value;
				return;
			}
			this.#n4c = null;
			this.#m4c = null;
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x00025AEC File Offset: 0x00024AEC
		public void End()
		{
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x060007AD RID: 1965 RVA: 0x00025AF0 File Offset: 0x00024AF0
		public ViewSchema SelectedViewSchema
		{
			get
			{
				return this.#l4c.SelectedItem as ViewSchema;
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x060007AE RID: 1966 RVA: 0x00025B04 File Offset: 0x00024B04
		public ViewSchemaCollection SelectedViewSchemaCollection
		{
			get
			{
				ViewSchema[] array = new ViewSchema[this.#l4c.SelectedItems.Count];
				for (int i = 0; i < this.#l4c.SelectedItems.Count; i++)
				{
					array[i] = (ViewSchema)this.#l4c.SelectedItems[i];
				}
				return new ViewSchemaCollection(array);
			}
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x00025C30 File Offset: 0x00024C30
		private void #lq()
		{
			this.#sS = new Container();
			this.#k4c = new GroupBox();
			this.#l4c = new ListBox();
			this.#m2c = new Button();
			this.#d2c = new ComboBox();
			this.#e2c = new Button();
			this.#Rac = new Button();
			this.#FTc = new Label();
			this.#L2c = new ToolTip(this.#sS);
			this.#k4c.SuspendLayout();
			base.SuspendLayout();
			this.#k4c.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.#k4c.Controls.Add(this.#l4c);
			this.#k4c.Location = new Point(8, 32);
			this.#k4c.Name = #Mk.#Lk(18949);
			this.#k4c.Size = new Size(326, 255);
			this.#k4c.TabIndex = 0;
			this.#k4c.TabStop = false;
			this.#k4c.Text = #Mk.#Lk(14730);
			this.#l4c.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.#l4c.Location = new Point(8, 16);
			this.#l4c.Name = #Mk.#Lk(18970);
			this.#l4c.Size = new Size(310, 225);
			this.#l4c.TabIndex = 0;
			this.#l4c.DoubleClick += this.#q4c;
			this.#m2c.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#m2c.DialogResult = DialogResult.OK;
			this.#m2c.Location = new Point(178, 292);
			this.#m2c.Name = #Mk.#Lk(15783);
			this.#m2c.Size = new Size(75, 23);
			this.#m2c.TabIndex = 1;
			this.#m2c.Text = #Mk.#Lk(15800);
			this.#m2c.Click += this.#G2c;
			this.#d2c.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.#d2c.DropDownStyle = ComboBoxStyle.DropDownList;
			this.#d2c.Location = new Point(80, 8);
			this.#d2c.Name = #Mk.#Lk(15809);
			this.#d2c.Size = new Size(228, 21);
			this.#d2c.TabIndex = 3;
			this.#d2c.SelectedIndexChanged += this.#E2c;
			this.#e2c.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.#e2c.Location = new Point(310, 8);
			this.#e2c.Name = #Mk.#Lk(15834);
			this.#e2c.Size = new Size(23, 22);
			this.#e2c.TabIndex = 4;
			this.#e2c.Text = #Mk.#Lk(15116);
			this.#L2c.SetToolTip(this.#e2c, #Mk.#Lk(15859));
			this.#e2c.Click += this.#F2c;
			this.#Rac.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#Rac.DialogResult = DialogResult.Cancel;
			this.#Rac.Location = new Point(258, 292);
			this.#Rac.Name = #Mk.#Lk(15888);
			this.#Rac.Size = new Size(75, 23);
			this.#Rac.TabIndex = 2;
			this.#Rac.Text = #Mk.#Lk(15913);
			this.#FTc.Location = new Point(8, 12);
			this.#FTc.Name = #Mk.#Lk(15922);
			this.#FTc.Size = new Size(70, 16);
			this.#FTc.TabIndex = 5;
			this.#FTc.Text = #Mk.#Lk(15943);
			this.AutoScaleBaseSize = new Size(5, 13);
			base.ClientSize = new Size(342, 324);
			base.Controls.Add(this.#d2c);
			base.Controls.Add(this.#FTc);
			base.Controls.Add(this.#Rac);
			base.Controls.Add(this.#e2c);
			base.Controls.Add(this.#m2c);
			base.Controls.Add(this.#k4c);
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new Size(200, 200);
			base.Name = #Mk.#Lk(18987);
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = #Mk.#Lk(19012);
			base.Load += this.#o4c;
			this.#k4c.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x0002613C File Offset: 0x0002513C
		private void #o4c(object #sm, EventArgs #tm)
		{
			this.#v2c(false);
			this.#u2c();
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x0002614C File Offset: 0x0002514C
		private void #p4c(ViewSchemaCollection #onc)
		{
			this.Cursor = Cursors.WaitCursor;
			this.#l4c.BeginUpdate();
			this.#l4c.Items.Clear();
			this.#l4c.DisplayMember = #Mk.#Lk(16286);
			try
			{
				if (#onc != null)
				{
					#onc.Sort(new PropertyComparer(#Mk.#Lk(16299)));
					foreach (ViewSchema viewSchema in #onc)
					{
						this.#l4c.Items.Add(viewSchema);
						int num = this.#l4c.Items.IndexOf(viewSchema);
						if (this.#m4c != null && viewSchema.Equals(this.#m4c) && num >= 0)
						{
							this.#l4c.SelectedIndex = num;
						}
						if (this.#n4c != null && this.#n4c.Contains(viewSchema) && num >= 0)
						{
							this.#l4c.SetSelected(num, true);
						}
					}
				}
				int count = this.#l4c.SelectedItems.Count;
			}
			catch (Exception ex)
			{
				ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(19029), ex.ToString());
			}
			finally
			{
				this.#l4c.EndUpdate();
				this.Cursor = Cursors.Default;
			}
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x000262C0 File Offset: 0x000252C0
		private void #u2c()
		{
			this.Cursor = Cursors.WaitCursor;
			int num = 0;
			this.#d2c.Items.Clear();
			this.#d2c.Items.Add(#Mk.#Lk(2068));
			DataSourceCollection dataSources = DataSourceManager.DataSources;
			dataSources.Sort(new PropertyComparer(#Mk.#Lk(14752)));
			for (int i = 0; i < dataSources.Count; i++)
			{
				this.#d2c.Items.Add(dataSources[i]);
				if (this.#m4c != null)
				{
					if (dataSources[i].ConnectionString == this.#m4c.Database.ConnectionString)
					{
						num = i + 1;
					}
				}
				else if (this.#n4c != null && this.#n4c.Count > 0)
				{
					if (dataSources[i].ConnectionString == this.#n4c[0].Database.ConnectionString)
					{
						num = i + 1;
					}
				}
				else if (dataSources[i].IsSelected)
				{
					num = i + 1;
				}
			}
			if (this.#d2c.Items.Count > 1 && num >= 0)
			{
				this.#d2c.SelectedIndex = num;
			}
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x00026408 File Offset: 0x00025408
		private void #q4c(object #sm, EventArgs #tm)
		{
			DataSource dataSource = this.#d2c.SelectedItem as DataSource;
			if (dataSource != null)
			{
				DataSourceManager.LastSelectedDataSource = dataSource;
				DataSourceManager.Serialize();
			}
			base.DialogResult = DialogResult.OK;
			base.Hide();
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x00026448 File Offset: 0x00025448
		private void #F2c(object #sm, EventArgs #tm)
		{
			DataSourceManagerUI dataSourceManagerUI = new DataSourceManagerUI();
			dataSourceManagerUI.ShowDialog(this);
			this.#u2c();
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x0002646C File Offset: 0x0002546C
		private void #E2c(object #sm, EventArgs #tm)
		{
			DataSource dataSource = this.#d2c.SelectedItem as DataSource;
			if (dataSource == null)
			{
				this.#p4c(null);
				return;
			}
			this.#v2c(true);
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.#B2c), dataSource);
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x000264B8 File Offset: 0x000254B8
		private void #v2c(bool #w2c)
		{
			if (#w2c)
			{
				this.Text = #Mk.#Lk(19142);
				this.#l4c.Enabled = false;
				this.#l4c.BackColor = SystemColors.ControlLight;
				this.#m2c.Enabled = false;
				return;
			}
			this.Text = #Mk.#Lk(19012);
			this.#l4c.Enabled = true;
			this.#l4c.BackColor = SystemColors.Window;
			this.#m2c.Enabled = true;
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x0002653C File Offset: 0x0002553C
		private void #G2c(object #sm, EventArgs #tm)
		{
			DataSource dataSource = this.#d2c.SelectedItem as DataSource;
			if (dataSource == null)
			{
				return;
			}
			DataSourceManager.LastSelectedDataSource = dataSource;
			DataSourceManager.Serialize();
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x00026570 File Offset: 0x00025570
		private void #B2c(object #8j)
		{
			DataSource dataSource = #8j as DataSource;
			RunWorkerCompletedEventArgs runWorkerCompletedEventArgs = null;
			try
			{
				if (!(dataSource == null))
				{
					DatabaseSchema databaseSchema = dataSource.CreateInstance();
					if (databaseSchema != null)
					{
						ViewSchemaCollection views = databaseSchema.Views;
						runWorkerCompletedEventArgs = new RunWorkerCompletedEventArgs(views, null, false);
					}
				}
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
				if (this.#d2c.IsHandleCreated)
				{
					this.#d2c.Invoke(new RunWorkerCompletedEventHandler(this.#C2c), new object[]
					{
						dataSource,
						runWorkerCompletedEventArgs
					});
				}
			}
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x0002661C File Offset: 0x0002561C
		private void #C2c(object #sm, RunWorkerCompletedEventArgs #tm)
		{
			try
			{
				ViewSchemaCollection #onc = null;
				DataSource left = this.#d2c.SelectedItem as DataSource;
				DataSource right = #sm as DataSource;
				if (base.IsHandleCreated && !(left != right))
				{
					if (#tm.Error != null)
					{
						ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(19029), #tm.Error.ToString());
					}
					else
					{
						#onc = (#tm.Result as ViewSchemaCollection);
					}
					this.#p4c(#onc);
				}
			}
			finally
			{
				this.#v2c(false);
			}
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x000266B4 File Offset: 0x000256B4
		// Note: this type is marked as 'beforefieldinit'.
		static ViewSchemaPickerUI()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (ViewSchemaPickerUI.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x060007BC RID: 1980
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x040002FA RID: 762
		private GroupBox #k4c;

		// Token: 0x040002FF RID: 767
		private Label #FTc;

		// Token: 0x04000300 RID: 768
		private Button #Rac;

		// Token: 0x04000302 RID: 770
		private ViewSchema #m4c;

		// Token: 0x04000303 RID: 771
		private ToolTip #L2c;

		// Token: 0x04000304 RID: 772
		private ViewSchemaCollection #n4c;
	}
}
