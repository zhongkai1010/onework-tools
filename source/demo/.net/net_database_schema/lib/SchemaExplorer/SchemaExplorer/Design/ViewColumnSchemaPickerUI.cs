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
	// Token: 0x020000D7 RID: 215
	public partial class ViewColumnSchemaPickerUI : Form
	{
		// Token: 0x06000793 RID: 1939 RVA: 0x000249A0 File Offset: 0x000239A0
		public ViewColumnSchemaPickerUI() : this(false)
		{
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x000249AC File Offset: 0x000239AC
		public ViewColumnSchemaPickerUI(bool allowMultiple)
		{
			this.#lq();
			if (allowMultiple)
			{
				this.#N2c.CheckBoxes = true;
				return;
			}
			this.#N2c.CheckBoxes = false;
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x000249EC File Offset: 0x000239EC
		public void Start(object value)
		{
			this.#P2c.Clear();
			this.#R2c = null;
			this.#j4c.Clear();
			if (value is ViewColumnSchema)
			{
				this.#h4c = (ViewColumnSchema)value;
				this.#i4c = null;
				this.#P2c.Add(this.#h4c.View, new List<ViewColumnSchema>
				{
					this.#h4c
				});
				return;
			}
			if (value is ViewColumnSchemaCollection)
			{
				this.#h4c = null;
				this.#i4c = (ViewColumnSchemaCollection)value;
				using (IEnumerator<ViewColumnSchema> enumerator = this.#i4c.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ViewColumnSchema viewColumnSchema = enumerator.Current;
						if (this.#P2c.ContainsKey(viewColumnSchema.View))
						{
							this.#P2c[viewColumnSchema.View].Add(viewColumnSchema);
						}
						else
						{
							this.#P2c.Add(viewColumnSchema.View, new List<ViewColumnSchema>
							{
								viewColumnSchema
							});
						}
					}
					return;
				}
			}
			this.#i4c = null;
			this.#h4c = null;
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x00024B08 File Offset: 0x00023B08
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
			if (filter is ViewSchema)
			{
				this.#j4c.Add(filter as ViewSchema, filter.ToString());
				this.#R2c = (filter as ViewSchema).Database;
				return;
			}
			if (filter is ViewSchemaCollection)
			{
				foreach (ViewSchema viewSchema in (filter as ViewSchemaCollection))
				{
					this.#j4c.Add(viewSchema, viewSchema.ToString());
					if (this.#R2c == null)
					{
						this.#R2c = viewSchema.Database;
					}
				}
			}
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x00024BC8 File Offset: 0x00023BC8
		public void End()
		{
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000798 RID: 1944 RVA: 0x00024BCC File Offset: 0x00023BCC
		public ViewColumnSchema SelectedViewColumnSchema
		{
			get
			{
				if (this.#N2c.SelectedNode == null)
				{
					return null;
				}
				return this.#N2c.SelectedNode.Tag as ViewColumnSchema;
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000799 RID: 1945 RVA: 0x00024BF4 File Offset: 0x00023BF4
		public ViewColumnSchemaCollection SelectedViewColumnSchemaCollection
		{
			get
			{
				List<ViewColumnSchema> list = new List<ViewColumnSchema>();
				foreach (TreeNode treeNode in this.#N2c.CheckedNodes())
				{
					if (treeNode.Tag is ViewColumnSchema)
					{
						list.Add(treeNode.Tag as ViewColumnSchema);
					}
				}
				return new ViewColumnSchemaCollection(list.ToArray());
			}
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x00024D54 File Offset: 0x00023D54
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
			base.Name = #Mk.#Lk(18725);
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = #Mk.#Lk(18758);
			base.Load += this.#S2c;
			this.#M2c.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x00025294 File Offset: 0x00024294
		private void #S2c(object #sm, EventArgs #tm)
		{
			this.#v2c(false);
			this.#u2c();
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x000252A4 File Offset: 0x000242A4
		private void #v2c(bool #w2c)
		{
			if (#w2c)
			{
				this.#N2c.Enabled = false;
				this.#N2c.BackColor = SystemColors.ControlLight;
				this.#m2c.Enabled = false;
				this.Text = #Mk.#Lk(18783);
				return;
			}
			this.#N2c.Enabled = true;
			this.#N2c.BackColor = SystemColors.Window;
			this.#m2c.Enabled = true;
			this.Text = #Mk.#Lk(18758);
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x00025328 File Offset: 0x00024328
		private void #T2c(ViewSchemaCollection #onc)
		{
			this.Cursor = Cursors.WaitCursor;
			this.#N2c.BeginUpdate();
			this.#N2c.Nodes.Clear();
			try
			{
				if (#onc != null)
				{
					#onc.Sort(new PropertyComparer(#Mk.#Lk(16047)));
					bool flag = this.#j4c.Count > 0;
					foreach (ViewSchema viewSchema in #onc)
					{
						if (!flag || this.#j4c.ContainsKey(viewSchema))
						{
							TreeNode treeNode = new TreeNode(viewSchema.SortName);
							treeNode.Tag = viewSchema;
							treeNode.ToolTipText = viewSchema.FullName;
							treeNode.Nodes.Add(#Mk.#Lk(16064));
							treeNode.StateImageIndex = 0;
							this.#N2c.Nodes.Add(treeNode);
							if (this.#P2c.ContainsKey(viewSchema) || flag)
							{
								treeNode.Expand();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(18828), ex.ToString());
			}
			finally
			{
				this.#N2c.EndUpdate();
				this.Cursor = Cursors.Default;
			}
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x00025488 File Offset: 0x00024488
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
				if (this.#h4c != null)
				{
					if (dataSources[i].ConnectionString == this.#h4c.Database.ConnectionString)
					{
						num = i + 1;
					}
				}
				else if (this.#i4c != null && this.#i4c.Count > 0)
				{
					if (dataSources[i].ConnectionString == this.#i4c[0].Database.ConnectionString)
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

		// Token: 0x060007A0 RID: 1952 RVA: 0x00025600 File Offset: 0x00024600
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

		// Token: 0x060007A1 RID: 1953 RVA: 0x00025640 File Offset: 0x00024640
		private void #F2c(object #sm, EventArgs #tm)
		{
			DataSourceManagerUI dataSourceManagerUI = new DataSourceManagerUI();
			dataSourceManagerUI.ShowDialog(this);
			this.#u2c();
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x00025664 File Offset: 0x00024664
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

		// Token: 0x060007A3 RID: 1955 RVA: 0x000256B0 File Offset: 0x000246B0
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

		// Token: 0x060007A4 RID: 1956 RVA: 0x000256E4 File Offset: 0x000246E4
		private void #V2c(object #sm, TreeViewCancelEventArgs #tm)
		{
			bool flag = #tm.Node.Tag is ViewSchema;
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
				ViewSchema viewSchema = node.Tag as ViewSchema;
				if (viewSchema != null)
				{
					foreach (ViewColumnSchema viewColumnSchema in viewSchema.Columns)
					{
						TreeNode treeNode = new TreeNode(viewColumnSchema.Name);
						treeNode.Tag = viewColumnSchema;
						treeNode.ToolTipText = viewColumnSchema.Name;
						treeNode.StateImageIndex = 0;
						node.Nodes.Add(treeNode);
						if (this.#P2c.ContainsKey(viewSchema) && this.#P2c[viewSchema].Contains(viewColumnSchema))
						{
							if (this.#h4c != null)
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

		// Token: 0x060007A5 RID: 1957 RVA: 0x000258C8 File Offset: 0x000248C8
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

		// Token: 0x060007A6 RID: 1958 RVA: 0x00025974 File Offset: 0x00024974
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
						ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(18828), #tm.Error.ToString());
					}
					else
					{
						#onc = (#tm.Result as ViewSchemaCollection);
					}
					this.#T2c(#onc);
				}
			}
			finally
			{
				this.#v2c(false);
			}
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x00025A0C File Offset: 0x00024A0C
		// Note: this type is marked as 'beforefieldinit'.
		static ViewColumnSchemaPickerUI()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (ViewColumnSchemaPickerUI.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x060007A8 RID: 1960
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x040002EE RID: 750
		private Label #FTc;

		// Token: 0x040002EF RID: 751
		private Button #Rac;

		// Token: 0x040002F1 RID: 753
		private ViewColumnSchema #h4c;

		// Token: 0x040002F2 RID: 754
		private ToolTip #L2c;

		// Token: 0x040002F3 RID: 755
		private GroupBox #M2c;

		// Token: 0x040002F5 RID: 757
		private ViewColumnSchemaCollection #i4c;

		// Token: 0x040002F6 RID: 758
		private Dictionary<ViewSchema, List<ViewColumnSchema>> #P2c = new Dictionary<ViewSchema, List<ViewColumnSchema>>();

		// Token: 0x040002F7 RID: 759
		private Dictionary<ViewSchema, string> #j4c = new Dictionary<ViewSchema, string>();

		// Token: 0x040002F8 RID: 760
		private DatabaseSchema #R2c;
	}
}
