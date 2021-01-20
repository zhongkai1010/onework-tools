using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using #Nk;

namespace SchemaExplorer.Design
{
	// Token: 0x020000CA RID: 202
	public partial class CommandSchemaPickerUI : Form
	{
		// Token: 0x060006D2 RID: 1746 RVA: 0x0001DEE4 File Offset: 0x0001CEE4
		public CommandSchemaPickerUI() : this(false)
		{
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x0001DEF0 File Offset: 0x0001CEF0
		public CommandSchemaPickerUI(bool allowMultiple)
		{
			this.#lq();
			if (allowMultiple)
			{
				this.#X2c.SelectionMode = SelectionMode.MultiExtended;
				return;
			}
			this.#X2c.SelectionMode = SelectionMode.One;
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x0001DF1C File Offset: 0x0001CF1C
		public void Start(object value)
		{
			this.#R2c = null;
			if (value is CommandSchema)
			{
				this.#Y2c = (CommandSchema)value;
				this.#Z2c = null;
				return;
			}
			if (value is CommandSchemaCollection)
			{
				this.#Y2c = null;
				this.#Z2c = (CommandSchemaCollection)value;
				return;
			}
			this.#Z2c = null;
			this.#Y2c = null;
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x0001DF78 File Offset: 0x0001CF78
		public void Filter(object filter)
		{
			if (filter == null)
			{
				return;
			}
			if (filter is DatabaseSchema)
			{
				this.#R2c = (filter as DatabaseSchema);
			}
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x0001DF94 File Offset: 0x0001CF94
		public void End()
		{
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x0001DF98 File Offset: 0x0001CF98
		public CommandSchema SelectedCommandSchema
		{
			get
			{
				return this.#X2c.SelectedItem as CommandSchema;
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x060006D8 RID: 1752 RVA: 0x0001DFAC File Offset: 0x0001CFAC
		public CommandSchemaCollection SelectedCommandSchemaCollection
		{
			get
			{
				CommandSchema[] array = new CommandSchema[this.#X2c.SelectedItems.Count];
				for (int i = 0; i < this.#X2c.SelectedItems.Count; i++)
				{
					array[i] = (CommandSchema)this.#X2c.SelectedItems[i];
				}
				return new CommandSchemaCollection(array);
			}
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x0001E0D8 File Offset: 0x0001D0D8
		private void #lq()
		{
			this.#sS = new Container();
			this.#W2c = new GroupBox();
			this.#X2c = new ListBox();
			this.#m2c = new Button();
			this.#d2c = new ComboBox();
			this.#e2c = new Button();
			this.#Rac = new Button();
			this.#FTc = new Label();
			this.#L2c = new ToolTip(this.#sS);
			this.#W2c.SuspendLayout();
			base.SuspendLayout();
			this.#W2c.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.#W2c.Controls.Add(this.#X2c);
			this.#W2c.Location = new Point(8, 32);
			this.#W2c.Name = #Mk.#Lk(16190);
			this.#W2c.Size = new Size(326, 255);
			this.#W2c.TabIndex = 0;
			this.#W2c.TabStop = false;
			this.#W2c.Text = #Mk.#Lk(14739);
			this.#X2c.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.#X2c.Location = new Point(8, 16);
			this.#X2c.Name = #Mk.#Lk(16215);
			this.#X2c.Size = new Size(310, 225);
			this.#X2c.TabIndex = 0;
			this.#X2c.DoubleClick += this.#32c;
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
			base.Controls.Add(this.#W2c);
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new Size(200, 200);
			base.Name = #Mk.#Lk(16236);
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = #Mk.#Lk(16265);
			base.Load += this.#12c;
			this.#W2c.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x0001E5E4 File Offset: 0x0001D5E4
		private void #12c(object #sm, EventArgs #tm)
		{
			this.#v2c(false);
			this.#u2c();
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x0001E5F4 File Offset: 0x0001D5F4
		private void #22c(CommandSchemaCollection #2lc)
		{
			this.Cursor = Cursors.WaitCursor;
			this.#X2c.BeginUpdate();
			this.#X2c.Items.Clear();
			this.#X2c.DisplayMember = #Mk.#Lk(16286);
			try
			{
				if (#2lc != null)
				{
					#2lc.Sort(new PropertyComparer(#Mk.#Lk(16299)));
					foreach (CommandSchema commandSchema in #2lc)
					{
						this.#X2c.Items.Add(commandSchema);
						int num = this.#X2c.Items.IndexOf(commandSchema);
						if (this.#Y2c != null && commandSchema.Equals(this.#Y2c) && num >= 0)
						{
							this.#X2c.SelectedIndex = num;
						}
						if (this.#Z2c != null && this.#Z2c.Contains(commandSchema) && num >= 0)
						{
							this.#X2c.SetSelected(num, true);
						}
					}
				}
				int count = this.#X2c.SelectedItems.Count;
			}
			catch (Exception ex)
			{
				ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(16316), ex.ToString());
			}
			finally
			{
				this.#X2c.EndUpdate();
				this.Cursor = Cursors.Default;
			}
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x0001E768 File Offset: 0x0001D768
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
				if (this.#Y2c != null)
				{
					if (dataSources[i].ConnectionString == this.#Y2c.Database.ConnectionString)
					{
						num = i + 1;
					}
				}
				else if (this.#Z2c != null && this.#Z2c.Count > 0)
				{
					if (dataSources[i].ConnectionString == this.#Z2c[0].Database.ConnectionString)
					{
						num = i + 1;
					}
				}
				else if (this.#R2c != null)
				{
					if (dataSources[i].ConnectionString == this.#R2c.ConnectionString)
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

		// Token: 0x060006DE RID: 1758 RVA: 0x0001E8E0 File Offset: 0x0001D8E0
		private void #32c(object #sm, EventArgs #tm)
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

		// Token: 0x060006DF RID: 1759 RVA: 0x0001E920 File Offset: 0x0001D920
		private void #F2c(object #sm, EventArgs #tm)
		{
			DataSourceManagerUI dataSourceManagerUI = new DataSourceManagerUI();
			dataSourceManagerUI.ShowDialog(this);
			this.#u2c();
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x0001E944 File Offset: 0x0001D944
		private void #E2c(object #sm, EventArgs #tm)
		{
			DataSource dataSource = this.#d2c.SelectedItem as DataSource;
			if (dataSource == null)
			{
				this.#22c(null);
				return;
			}
			this.#v2c(true);
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.#B2c), dataSource);
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x0001E990 File Offset: 0x0001D990
		private void #v2c(bool #w2c)
		{
			if (#w2c)
			{
				this.Text = #Mk.#Lk(16433);
				this.#X2c.Enabled = false;
				this.#X2c.BackColor = SystemColors.ControlLight;
				this.#m2c.Enabled = false;
				return;
			}
			this.Text = #Mk.#Lk(16265);
			this.#X2c.Enabled = true;
			this.#X2c.BackColor = SystemColors.Window;
			this.#m2c.Enabled = true;
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x0001EA14 File Offset: 0x0001DA14
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

		// Token: 0x060006E3 RID: 1763 RVA: 0x0001EA48 File Offset: 0x0001DA48
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
						databaseSchema.IncludeFunctions = this.IncludeFunctions;
						CommandSchemaCollection commands = databaseSchema.Commands;
						runWorkerCompletedEventArgs = new RunWorkerCompletedEventArgs(commands, null, false);
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

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x060006E4 RID: 1764 RVA: 0x0001EB00 File Offset: 0x0001DB00
		// (set) Token: 0x060006E5 RID: 1765 RVA: 0x0001EB08 File Offset: 0x0001DB08
		public bool IncludeFunctions { get; set; }

		// Token: 0x060006E6 RID: 1766 RVA: 0x0001EB14 File Offset: 0x0001DB14
		private void #C2c(object #sm, RunWorkerCompletedEventArgs #tm)
		{
			try
			{
				CommandSchemaCollection #2lc = null;
				DataSource left = this.#d2c.SelectedItem as DataSource;
				DataSource right = #sm as DataSource;
				if (base.IsHandleCreated && !(left != right))
				{
					if (#tm.Error != null)
					{
						ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(16316), #tm.Error.ToString());
					}
					else
					{
						#2lc = (#tm.Result as CommandSchemaCollection);
					}
					this.#22c(#2lc);
				}
			}
			finally
			{
				this.#v2c(false);
			}
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x0001EBAC File Offset: 0x0001DBAC
		// Note: this type is marked as 'beforefieldinit'.
		static CommandSchemaPickerUI()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (CommandSchemaPickerUI.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x060006E8 RID: 1768
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x0400027C RID: 636
		private GroupBox #W2c;

		// Token: 0x04000281 RID: 641
		private Label #FTc;

		// Token: 0x04000282 RID: 642
		private Button #Rac;

		// Token: 0x04000284 RID: 644
		private CommandSchema #Y2c;

		// Token: 0x04000285 RID: 645
		private ToolTip #L2c;

		// Token: 0x04000286 RID: 646
		private CommandSchemaCollection #Z2c;

		// Token: 0x04000287 RID: 647
		private DatabaseSchema #R2c;

		// Token: 0x04000289 RID: 649
		[CompilerGenerated]
		private bool #02c;
	}
}
