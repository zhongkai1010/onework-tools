using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using #Nk;

namespace SchemaExplorer.Design
{
	// Token: 0x020000CB RID: 203
	public partial class DatabaseSchemaPickerUI : Form
	{
		// Token: 0x060006E9 RID: 1769 RVA: 0x0001EC00 File Offset: 0x0001DC00
		public DatabaseSchemaPickerUI()
		{
			this.#lq();
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0001EC10 File Offset: 0x0001DC10
		public void Start(IWindowsFormsEditorService editorService, object value)
		{
			if (value is DatabaseSchema)
			{
				this.#42c = (DatabaseSchema)value;
			}
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0001EC28 File Offset: 0x0001DC28
		public void End()
		{
			this.DatabaseSchema = null;
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x060006EC RID: 1772 RVA: 0x0001EC34 File Offset: 0x0001DC34
		// (set) Token: 0x060006ED RID: 1773 RVA: 0x0001EC3C File Offset: 0x0001DC3C
		public DatabaseSchema DatabaseSchema
		{
			get
			{
				return this.#42c;
			}
			set
			{
				this.#42c = value;
				this.#u2c();
			}
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0001ECF8 File Offset: 0x0001DCF8
		private void #lq()
		{
			this.#sS = new Container();
			this.#m2c = new Button();
			this.#d2c = new ComboBox();
			this.#e2c = new Button();
			this.#Rac = new Button();
			this.#FTc = new Label();
			this.#L2c = new ToolTip(this.#sS);
			base.SuspendLayout();
			this.#m2c.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#m2c.DialogResult = DialogResult.OK;
			this.#m2c.Location = new Point(188, 35);
			this.#m2c.Name = #Mk.#Lk(15783);
			this.#m2c.Size = new Size(75, 23);
			this.#m2c.TabIndex = 1;
			this.#m2c.Text = #Mk.#Lk(15800);
			this.#m2c.Click += this.#G2c;
			this.#d2c.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.#d2c.DropDownStyle = ComboBoxStyle.DropDownList;
			this.#d2c.Location = new Point(80, 8);
			this.#d2c.Name = #Mk.#Lk(15809);
			this.#d2c.Size = new Size(238, 21);
			this.#d2c.TabIndex = 3;
			this.#d2c.SelectedIndexChanged += this.#E2c;
			this.#e2c.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.#e2c.Location = new Point(320, 8);
			this.#e2c.Name = #Mk.#Lk(15834);
			this.#e2c.Size = new Size(23, 22);
			this.#e2c.TabIndex = 4;
			this.#e2c.Text = #Mk.#Lk(15116);
			this.#L2c.SetToolTip(this.#e2c, #Mk.#Lk(15859));
			this.#e2c.Click += this.#F2c;
			this.#Rac.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#Rac.DialogResult = DialogResult.Cancel;
			this.#Rac.Location = new Point(268, 35);
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
			base.ClientSize = new Size(352, 64);
			base.Controls.Add(this.#d2c);
			base.Controls.Add(this.#FTc);
			base.Controls.Add(this.#Rac);
			base.Controls.Add(this.#e2c);
			base.Controls.Add(this.#m2c);
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			this.MaximumSize = new Size(1000, 98);
			this.MinimumSize = new Size(200, 98);
			base.Name = #Mk.#Lk(16474);
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = #Mk.#Lk(16507);
			base.Load += this.#52c;
			base.ResumeLayout(false);
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0001F0C8 File Offset: 0x0001E0C8
		private void #52c(object #sm, EventArgs #tm)
		{
			this.Text = #Mk.#Lk(16507);
			this.#m2c.Enabled = true;
			this.#u2c();
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x0001F0EC File Offset: 0x0001E0EC
		private void #u2c()
		{
			int selectedIndex = 0;
			this.#d2c.Items.Clear();
			DataSourceCollection dataSources = DataSourceManager.DataSources;
			dataSources.Sort(new PropertyComparer(#Mk.#Lk(14752)));
			for (int i = 0; i < dataSources.Count; i++)
			{
				this.#d2c.Items.Add(dataSources[i]);
				if (dataSources[i].IsSelected || (this.#42c != null && string.Equals(dataSources[i].ConnectionString, this.#42c.ConnectionString, StringComparison.OrdinalIgnoreCase)))
				{
					selectedIndex = i;
				}
			}
			if (this.#d2c.Items.Count > 0)
			{
				this.#d2c.SelectedIndex = selectedIndex;
			}
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x0001F1A8 File Offset: 0x0001E1A8
		private void #F2c(object #sm, EventArgs #tm)
		{
			DataSourceManagerUI dataSourceManagerUI = new DataSourceManagerUI();
			dataSourceManagerUI.ShowDialog(this);
			this.#u2c();
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x0001F1CC File Offset: 0x0001E1CC
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

		// Token: 0x060006F4 RID: 1780 RVA: 0x0001F200 File Offset: 0x0001E200
		private void #E2c(object #sm, EventArgs #tm)
		{
			DataSource dataSource = this.#d2c.SelectedItem as DataSource;
			if (dataSource == null)
			{
				return;
			}
			this.Text = #Mk.#Lk(16528);
			this.#m2c.Enabled = false;
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.#B2c), dataSource);
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x0001F258 File Offset: 0x0001E258
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
						string name = databaseSchema.Name;
						runWorkerCompletedEventArgs = new RunWorkerCompletedEventArgs(databaseSchema, null, false);
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

		// Token: 0x060006F6 RID: 1782 RVA: 0x0001F304 File Offset: 0x0001E304
		private void #C2c(object #sm, RunWorkerCompletedEventArgs #tm)
		{
			try
			{
				DataSource left = this.#d2c.SelectedItem as DataSource;
				DataSource right = #sm as DataSource;
				if (base.IsHandleCreated && !(left != right))
				{
					if (#tm.Error != null)
					{
						ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(16569), #tm.Error.ToString());
					}
					else
					{
						this.#42c = (#tm.Result as DatabaseSchema);
					}
				}
			}
			finally
			{
				this.Text = #Mk.#Lk(16507);
				this.#m2c.Enabled = true;
			}
		}

		// Token: 0x0400028D RID: 653
		private Label #FTc;

		// Token: 0x0400028E RID: 654
		private Button #Rac;

		// Token: 0x0400028F RID: 655
		private ToolTip #L2c;

		// Token: 0x04000291 RID: 657
		private DatabaseSchema #42c;
	}
}
