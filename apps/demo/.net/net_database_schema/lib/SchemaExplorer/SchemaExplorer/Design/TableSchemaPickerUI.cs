using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using #Nk;
using CodeSmith.Engine;

namespace SchemaExplorer.Design
{
	// Token: 0x020000D4 RID: 212
	public partial class TableSchemaPickerUI : Form
	{
		// Token: 0x0600075D RID: 1885 RVA: 0x00022C54 File Offset: 0x00021C54
		public TableSchemaPickerUI() : this(false)
		{
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x00022C60 File Offset: 0x00021C60
		public TableSchemaPickerUI(bool allowMultiple)
		{
			this.#lq();
			this.#X3c.SelectionMode = (allowMultiple ? SelectionMode.MultiExtended : SelectionMode.One);
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x00022C80 File Offset: 0x00021C80
		public void Start(object value)
		{
			if (value is TableSchema)
			{
				this.#Y3c = (TableSchema)value;
				this.#Z3c = null;
				return;
			}
			if (value is TableSchemaCollection)
			{
				this.#Y3c = null;
				this.#Z3c = (TableSchemaCollection)value;
				return;
			}
			this.#Z3c = null;
			this.#Y3c = null;
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x00022CD4 File Offset: 0x00021CD4
		public void End()
		{
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x00022CD8 File Offset: 0x00021CD8
		public TableSchema SelectedTableSchema
		{
			get
			{
				return this.#X3c.SelectedItem as TableSchema;
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000762 RID: 1890 RVA: 0x00022CEC File Offset: 0x00021CEC
		public TableSchemaCollection SelectedTableSchemaCollection
		{
			get
			{
				TableSchema[] array = new TableSchema[this.#X3c.SelectedItems.Count];
				for (int i = 0; i < this.#X3c.SelectedItems.Count; i++)
				{
					array[i] = (TableSchema)this.#X3c.SelectedItems[i];
				}
				return new TableSchemaCollection(array);
			}
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x00022DF8 File Offset: 0x00021DF8
		private void #lq()
		{
			this.#sS = new Container();
			this.#W3c = new GroupBox();
			this.#X3c = new ListBox();
			this.#m2c = new Button();
			this.#d2c = new ComboBox();
			this.#e2c = new Button();
			this.#Rac = new Button();
			this.#FTc = new Label();
			this.#L2c = new ToolTip(this.#sS);
			this.#W3c.SuspendLayout();
			base.SuspendLayout();
			this.#W3c.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.#W3c.Controls.Add(this.#X3c);
			this.#W3c.Location = new Point(8, 32);
			this.#W3c.Name = #Mk.#Lk(18359);
			this.#W3c.Size = new Size(326, 255);
			this.#W3c.TabIndex = 0;
			this.#W3c.TabStop = false;
			this.#W3c.Text = #Mk.#Lk(14721);
			this.#X3c.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.#X3c.BackColor = SystemColors.Window;
			this.#X3c.Location = new Point(8, 16);
			this.#X3c.Name = #Mk.#Lk(18380);
			this.#X3c.Size = new Size(310, 225);
			this.#X3c.TabIndex = 0;
			this.#X3c.DoubleClick += this.#13c;
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
			base.Controls.Add(this.#W3c);
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new Size(200, 200);
			base.Name = #Mk.#Lk(18401);
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = #Mk.#Lk(18430);
			base.Load += this.#52c;
			this.#W3c.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x00023314 File Offset: 0x00022314
		private void #52c(object #sm, EventArgs #tm)
		{
			this.#v2c(false);
			this.#u2c();
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x00023324 File Offset: 0x00022324
		private void #03c(TableSchemaCollection #hnc)
		{
			this.Cursor = Cursors.WaitCursor;
			this.#X3c.BeginUpdate();
			this.#X3c.Items.Clear();
			this.#X3c.DisplayMember = #Mk.#Lk(16286);
			try
			{
				if (#hnc != null)
				{
					#hnc.Sort(new PropertyComparer(#Mk.#Lk(16299)));
					foreach (TableSchema tableSchema in #hnc)
					{
						this.#X3c.Items.Add(tableSchema);
						int num = this.#X3c.Items.IndexOf(tableSchema);
						if (this.#Y3c != null && tableSchema.Equals(this.#Y3c) && num >= 0)
						{
							this.#X3c.SelectedIndex = num;
						}
						if (this.#Z3c != null && this.#Z3c.Contains(tableSchema) && num >= 0)
						{
							this.#X3c.SetSelected(num, true);
						}
					}
				}
				int count = this.#X3c.SelectedItems.Count;
				count = this.#X3c.Items.Count;
			}
			catch (FeatureNotAllowedException ex)
			{
				MessageBox.Show(ex.Message, #Mk.#Lk(11512), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			catch (Exception ex2)
			{
				ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(14911), ex2.ToString());
			}
			finally
			{
				this.#X3c.EndUpdate();
				this.Cursor = Cursors.Default;
			}
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x00023504 File Offset: 0x00022504
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
				if (this.#Y3c != null)
				{
					if (dataSources[i].ConnectionString == this.#Y3c.Database.ConnectionString)
					{
						num = i + 1;
					}
				}
				else if (this.#Z3c != null && this.#Z3c.Count > 0)
				{
					if (dataSources[i].ConnectionString == this.#Z3c[0].Database.ConnectionString)
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

		// Token: 0x06000768 RID: 1896 RVA: 0x0002364C File Offset: 0x0002264C
		private void #13c(object #sm, EventArgs #tm)
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

		// Token: 0x06000769 RID: 1897 RVA: 0x0002368C File Offset: 0x0002268C
		private void #F2c(object #sm, EventArgs #tm)
		{
			DataSourceManagerUI dataSourceManagerUI = new DataSourceManagerUI();
			dataSourceManagerUI.ShowDialog(this);
			this.#u2c();
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x000236B0 File Offset: 0x000226B0
		private void #E2c(object #sm, EventArgs #tm)
		{
			DataSource dataSource = this.#d2c.SelectedItem as DataSource;
			if (dataSource == null)
			{
				this.#03c(null);
				return;
			}
			this.#v2c(true);
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.#B2c), dataSource);
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x000236FC File Offset: 0x000226FC
		private void #v2c(bool #w2c)
		{
			if (#w2c)
			{
				this.Text = #Mk.#Lk(18447);
				this.#X3c.Enabled = false;
				this.#X3c.BackColor = SystemColors.ControlLight;
				this.#m2c.Enabled = false;
				return;
			}
			this.Text = #Mk.#Lk(18430);
			this.#X3c.Enabled = true;
			this.#X3c.BackColor = SystemColors.Window;
			this.#m2c.Enabled = true;
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x00023780 File Offset: 0x00022780
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
						TableSchemaCollection tables = databaseSchema.Tables;
						runWorkerCompletedEventArgs = new RunWorkerCompletedEventArgs(tables, null, false);
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

		// Token: 0x0600076D RID: 1901 RVA: 0x0002382C File Offset: 0x0002282C
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

		// Token: 0x0600076E RID: 1902 RVA: 0x00023860 File Offset: 0x00022860
		private void #C2c(object #sm, RunWorkerCompletedEventArgs #tm)
		{
			try
			{
				TableSchemaCollection #hnc = null;
				DataSource left = this.#d2c.SelectedItem as DataSource;
				DataSource right = #sm as DataSource;
				if (base.IsHandleCreated && !(left != right))
				{
					if (#tm.Error != null)
					{
						ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(14911), #tm.Error.ToString());
					}
					else
					{
						#hnc = (#tm.Result as TableSchemaCollection);
					}
					this.#03c(#hnc);
				}
			}
			finally
			{
				this.#v2c(false);
			}
		}

		// Token: 0x040002CE RID: 718
		private GroupBox #W3c;

		// Token: 0x040002CF RID: 719
		private ListBox #X3c;

		// Token: 0x040002D3 RID: 723
		private Label #FTc;

		// Token: 0x040002D4 RID: 724
		private Button #Rac;

		// Token: 0x040002D6 RID: 726
		private TableSchema #Y3c;

		// Token: 0x040002D7 RID: 727
		private ToolTip #L2c;

		// Token: 0x040002D8 RID: 728
		private TableSchemaCollection #Z3c;
	}
}
