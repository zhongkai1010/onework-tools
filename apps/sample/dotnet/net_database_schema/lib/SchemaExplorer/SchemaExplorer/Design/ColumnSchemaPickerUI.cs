using System;
using System.Collections.Generic;
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
	// Token: 0x020000C9 RID: 201
	public partial class ColumnSchemaPickerUI : Form
	{
		// Token: 0x060006BC RID: 1724 RVA: 0x0001CE24 File Offset: 0x0001BE24
		public ColumnSchemaPickerUI() : this(false)
		{
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x0001CE30 File Offset: 0x0001BE30
		public ColumnSchemaPickerUI(bool allowMultiple)
		{
			this.#lq();
			if (allowMultiple)
			{
				this.#N2c.CheckBoxes = true;
				return;
			}
			this.#N2c.CheckBoxes = false;
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x0001CE70 File Offset: 0x0001BE70
		public void Start(object value)
		{
			this.#P2c.Clear();
			this.#R2c = null;
			this.#Q2c.Clear();
			if (value is ColumnSchema)
			{
				this.#K2c = (ColumnSchema)value;
				this.#O2c = null;
				this.#P2c.Add(this.#K2c.Table, new List<ColumnSchema>
				{
					this.#K2c
				});
				return;
			}
			if (value is ColumnSchemaCollection)
			{
				this.#K2c = null;
				this.#O2c = (ColumnSchemaCollection)value;
				using (IEnumerator<ColumnSchema> enumerator = this.#O2c.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ColumnSchema columnSchema = enumerator.Current;
						if (this.#P2c.ContainsKey(columnSchema.Table))
						{
							this.#P2c[columnSchema.Table].Add(columnSchema);
						}
						else
						{
							this.#P2c.Add(columnSchema.Table, new List<ColumnSchema>
							{
								columnSchema
							});
						}
					}
					return;
				}
			}
			this.#O2c = null;
			this.#K2c = null;
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x0001CF8C File Offset: 0x0001BF8C
		public void Filter(object filter)
		{
			if (filter == null)
			{
				return;
			}
			if (filter is DatabaseSchema)
			{
				this.#R2c = (filter as DatabaseSchema);
				return;
			}
			if (filter is TableSchema)
			{
				this.#Q2c.Add(filter as TableSchema, filter.ToString());
				this.#R2c = (filter as TableSchema).Database;
				return;
			}
			if (filter is TableSchemaCollection)
			{
				foreach (TableSchema tableSchema in (filter as TableSchemaCollection))
				{
					this.#Q2c.Add(tableSchema, tableSchema.ToString());
					if (this.#R2c == null)
					{
						this.#R2c = tableSchema.Database;
					}
				}
			}
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x0001D04C File Offset: 0x0001C04C
		public void End()
		{
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x060006C1 RID: 1729 RVA: 0x0001D050 File Offset: 0x0001C050
		public ColumnSchema SelectedColumnSchema
		{
			get
			{
				if (this.#N2c.SelectedNode == null)
				{
					return null;
				}
				return this.#N2c.SelectedNode.Tag as ColumnSchema;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x060006C2 RID: 1730 RVA: 0x0001D078 File Offset: 0x0001C078
		public ColumnSchemaCollection SelectedColumnSchemaCollection
		{
			get
			{
				List<ColumnSchema> list = new List<ColumnSchema>();
				foreach (TreeNode treeNode in this.#N2c.CheckedNodes())
				{
					if (treeNode.Tag is ColumnSchema)
					{
						list.Add(treeNode.Tag as ColumnSchema);
					}
				}
				return new ColumnSchemaCollection(list.ToArray());
			}
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x0001D1D8 File Offset: 0x0001C1D8
		private void #lq()
		{
			this.#sS = new Container();
			this.#M2c = new GroupBox();
			this.#N2c = new ThreeStateTreeView();
			this.#m2c = new Button();
			this.#d2c = new ComboBox();
			this.#e2c = new Button();
			this.#Rac = new Button();
			this.#FTc = new Label();
			this.#L2c = new ToolTip(this.#sS);
			this.#M2c.SuspendLayout();
			base.SuspendLayout();
			this.#M2c.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.#M2c.Controls.Add(this.#N2c);
			this.#M2c.Location = new Point(8, 32);
			this.#M2c.Name = #Mk.#Lk(15728);
			this.#M2c.Size = new Size(326, 255);
			this.#M2c.TabIndex = 0;
			this.#M2c.TabStop = false;
			this.#M2c.Text = #Mk.#Lk(15749);
			this.#N2c.BackColor = SystemColors.Window;
			this.#N2c.Dock = DockStyle.Fill;
			this.#N2c.HideSelection = false;
			this.#N2c.Location = new Point(3, 16);
			this.#N2c.Name = #Mk.#Lk(15762);
			this.#N2c.Size = new Size(320, 236);
			this.#N2c.TabIndex = 0;
			this.#N2c.BeforeExpand += this.#V2c;
			this.#N2c.DoubleClick += this.#U2c;
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
			base.Controls.Add(this.#M2c);
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new Size(200, 200);
			base.Name = #Mk.#Lk(15960);
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = #Mk.#Lk(15989);
			base.Load += this.#S2c;
			this.#M2c.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x0001D718 File Offset: 0x0001C718
		private void #S2c(object #sm, EventArgs #tm)
		{
			this.#v2c(false);
			this.#u2c();
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0001D728 File Offset: 0x0001C728
		private void #v2c(bool #w2c)
		{
			if (#w2c)
			{
				this.#N2c.Enabled = false;
				this.#N2c.BackColor = SystemColors.ControlLight;
				this.#m2c.Enabled = false;
				this.Text = #Mk.#Lk(16010);
				return;
			}
			this.#N2c.Enabled = true;
			this.#N2c.BackColor = SystemColors.Window;
			this.#m2c.Enabled = true;
			this.Text = #Mk.#Lk(15989);
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x0001D7AC File Offset: 0x0001C7AC
		private void #T2c(TableSchemaCollection #hnc)
		{
			this.Cursor = Cursors.WaitCursor;
			this.#N2c.BeginUpdate();
			this.#N2c.Nodes.Clear();
			try
			{
				if (#hnc != null)
				{
					#hnc.Sort(new PropertyComparer(#Mk.#Lk(16047)));
					bool flag = this.#Q2c.Count > 0;
					foreach (TableSchema tableSchema in #hnc)
					{
						if (!flag || this.#Q2c.ContainsKey(tableSchema))
						{
							TreeNode treeNode = new TreeNode(tableSchema.SortName);
							treeNode.Tag = tableSchema;
							treeNode.ToolTipText = tableSchema.FullName;
							treeNode.Nodes.Add(#Mk.#Lk(16064));
							treeNode.StateImageIndex = 0;
							this.#N2c.Nodes.Add(treeNode);
							if (this.#P2c.ContainsKey(tableSchema) || flag)
							{
								treeNode.Expand();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(16077), ex.ToString());
			}
			finally
			{
				this.#N2c.EndUpdate();
				this.Cursor = Cursors.Default;
			}
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x0001D90C File Offset: 0x0001C90C
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
				if (this.#K2c != null)
				{
					if (dataSources[i].ConnectionString == this.#K2c.Database.ConnectionString)
					{
						num = i + 1;
					}
				}
				else if (this.#O2c != null && this.#O2c.Count > 0)
				{
					if (dataSources[i].ConnectionString == this.#O2c[0].Database.ConnectionString)
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

		// Token: 0x060006C9 RID: 1737 RVA: 0x0001DA84 File Offset: 0x0001CA84
		private void #U2c(object #sm, EventArgs #tm)
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

		// Token: 0x060006CA RID: 1738 RVA: 0x0001DAC4 File Offset: 0x0001CAC4
		private void #F2c(object #sm, EventArgs #tm)
		{
			DataSourceManagerUI dataSourceManagerUI = new DataSourceManagerUI();
			dataSourceManagerUI.ShowDialog(this);
			this.#u2c();
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x0001DAE8 File Offset: 0x0001CAE8
		private void #E2c(object #sm, EventArgs #tm)
		{
			DataSource dataSource = this.#d2c.SelectedItem as DataSource;
			if (dataSource == null)
			{
				this.#T2c(null);
				return;
			}
			this.#v2c(true);
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.#B2c), dataSource);
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x0001DB34 File Offset: 0x0001CB34
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

		// Token: 0x060006CD RID: 1741 RVA: 0x0001DB68 File Offset: 0x0001CB68
		private void #V2c(object #sm, TreeViewCancelEventArgs #tm)
		{
			bool flag = #tm.Node.Tag is TableSchema;
			bool flag2 = #tm.Node.Nodes.Count == 1 && #tm.Node.Nodes[0].Text == #Mk.#Lk(16064);
			if (!flag || !flag2)
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			this.#N2c.BeginUpdate();
			try
			{
				TreeNode node = #tm.Node;
				node.Nodes.Clear();
				TableSchema tableSchema = node.Tag as TableSchema;
				if (tableSchema != null)
				{
					foreach (ColumnSchema columnSchema in tableSchema.Columns)
					{
						TreeNode treeNode = new TreeNode(columnSchema.Name);
						treeNode.Tag = columnSchema;
						treeNode.ToolTipText = columnSchema.Name;
						treeNode.StateImageIndex = 0;
						node.Nodes.Add(treeNode);
						if (this.#P2c.ContainsKey(tableSchema) && this.#P2c[tableSchema].Contains(columnSchema))
						{
							if (this.#K2c != null)
							{
								this.#N2c.SelectedNode = treeNode;
							}
							else
							{
								this.#N2c.SetChecked(treeNode);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(16077), ex.ToString());
			}
			finally
			{
				this.#N2c.EndUpdate();
				this.Cursor = Cursors.Default;
			}
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x0001DD4C File Offset: 0x0001CD4C
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

		// Token: 0x060006CF RID: 1743 RVA: 0x0001DDF8 File Offset: 0x0001CDF8
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
						ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(16077), #tm.Error.ToString());
					}
					else
					{
						#hnc = (#tm.Result as TableSchemaCollection);
					}
					this.#T2c(#hnc);
				}
			}
			finally
			{
				this.#v2c(false);
			}
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x0001DE90 File Offset: 0x0001CE90
		// Note: this type is marked as 'beforefieldinit'.
		static ColumnSchemaPickerUI()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (ColumnSchemaPickerUI.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x060006D1 RID: 1745
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x04000270 RID: 624
		private Label #FTc;

		// Token: 0x04000271 RID: 625
		private Button #Rac;

		// Token: 0x04000273 RID: 627
		private ColumnSchema #K2c;

		// Token: 0x04000274 RID: 628
		private ToolTip #L2c;

		// Token: 0x04000275 RID: 629
		private GroupBox #M2c;

		// Token: 0x04000277 RID: 631
		private ColumnSchemaCollection #O2c;

		// Token: 0x04000278 RID: 632
		private Dictionary<TableSchema, List<ColumnSchema>> #P2c = new Dictionary<TableSchema, List<ColumnSchema>>();

		// Token: 0x04000279 RID: 633
		private Dictionary<TableSchema, string> #Q2c = new Dictionary<TableSchema, string>();

		// Token: 0x0400027A RID: 634
		private DatabaseSchema #R2c;
	}
}
