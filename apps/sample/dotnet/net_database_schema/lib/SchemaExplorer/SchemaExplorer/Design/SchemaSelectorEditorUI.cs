using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using #Nk;

namespace SchemaExplorer.Design
{
	// Token: 0x020000C5 RID: 197
	public partial class SchemaSelectorEditorUI : Form
	{
		// Token: 0x0600069A RID: 1690 RVA: 0x0001B1C4 File Offset: 0x0001A1C4
		public SchemaSelectorEditorUI()
		{
			this.#lq();
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x0600069B RID: 1691 RVA: 0x0001B1D4 File Offset: 0x0001A1D4
		// (set) Token: 0x0600069C RID: 1692 RVA: 0x0001B1DC File Offset: 0x0001A1DC
		public SchemaSelector SchemaSelector { get; set; }

		// Token: 0x0600069D RID: 1693 RVA: 0x0001B1E8 File Offset: 0x0001A1E8
		public void Start(IWindowsFormsEditorService editorService, object value)
		{
			this.SchemaSelector = (value as SchemaSelector);
			if (this.SchemaSelector == null)
			{
				return;
			}
			this.#l2c.Checked = (this.SchemaSelector.SelectMode == SelectMode.Include);
			this.#k2c.Checked = (this.SchemaSelector.SelectMode == SelectMode.Exclude);
			foreach (string str in this.SchemaSelector.SchemaExpressions)
			{
				this.#i2c.AppendText(str + Environment.NewLine);
			}
			foreach (string str2 in this.SchemaSelector.ColumnExpressions)
			{
				this.#q2c.AppendText(str2 + Environment.NewLine);
			}
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x0001B2EC File Offset: 0x0001A2EC
		public void End()
		{
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x0001B2F0 File Offset: 0x0001A2F0
		private void #t2c()
		{
			this.Cursor = Cursors.WaitCursor;
			this.#o2c.BeginUpdate();
			this.#o2c.Nodes.Clear();
			try
			{
				this.#o0b();
			}
			catch (Exception ex)
			{
				ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(14600), ex.ToString());
			}
			finally
			{
				this.#o2c.EndUpdate();
				this.Cursor = Cursors.Default;
			}
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x0001B384 File Offset: 0x0001A384
		private void #o0b()
		{
			if (this.SchemaSelector == null)
			{
				return;
			}
			TreeNode treeNode = new TreeNode(#Mk.#Lk(14721));
			foreach (TableSchema tableSchema in this.SchemaSelector.Tables.OrderBy(new Func<TableSchema, string>(SchemaSelectorEditorUI.<>c.<>9.#l6c)))
			{
				TreeNode treeNode2 = new TreeNode(tableSchema.SortName);
				treeNode2.Tag = tableSchema;
				treeNode2.ToolTipText = tableSchema.FullName;
				treeNode2.Checked = this.SchemaSelector.SelectedTables.Contains(tableSchema.FullName);
				foreach (ColumnSchema columnSchema in tableSchema.Columns)
				{
					TreeNode treeNode3 = new TreeNode(columnSchema.SortName);
					treeNode3.Tag = columnSchema;
					treeNode3.ToolTipText = columnSchema.FullName;
					treeNode3.Checked = this.SchemaSelector.SelectedColumns.Contains(columnSchema.FullName);
					treeNode2.Nodes.Add(treeNode3);
				}
				treeNode.Nodes.Add(treeNode2);
			}
			treeNode.Expand();
			this.#o2c.Nodes.Add(treeNode);
			TreeNode treeNode4 = new TreeNode(#Mk.#Lk(14730));
			foreach (ViewSchema viewSchema in this.SchemaSelector.Views.OrderBy(new Func<ViewSchema, string>(SchemaSelectorEditorUI.<>c.<>9.#m6c)))
			{
				TreeNode treeNode5 = new TreeNode(viewSchema.SortName);
				treeNode5.Tag = viewSchema;
				treeNode5.ToolTipText = viewSchema.FullName;
				treeNode5.Checked = this.SchemaSelector.SelectedTables.Contains(viewSchema.FullName);
				foreach (ViewColumnSchema viewColumnSchema in viewSchema.Columns)
				{
					TreeNode treeNode6 = new TreeNode(viewColumnSchema.SortName);
					treeNode6.Tag = viewColumnSchema;
					treeNode6.ToolTipText = viewColumnSchema.FullName;
					treeNode6.Checked = this.SchemaSelector.SelectedColumns.Contains(viewColumnSchema.FullName);
					treeNode5.Nodes.Add(treeNode6);
				}
				treeNode4.Nodes.Add(treeNode5);
			}
			treeNode4.Expand();
			this.#o2c.Nodes.Add(treeNode4);
			TreeNode treeNode7 = new TreeNode(#Mk.#Lk(14739));
			foreach (CommandSchema commandSchema in this.SchemaSelector.Commands.OrderBy(new Func<CommandSchema, string>(SchemaSelectorEditorUI.<>c.<>9.#n6c)))
			{
				TreeNode treeNode8 = new TreeNode(commandSchema.SortName);
				treeNode8.Tag = commandSchema;
				treeNode8.ToolTipText = commandSchema.FullName;
				treeNode8.Checked = this.SchemaSelector.SelectedCommands.Contains(commandSchema.FullName);
				treeNode7.Nodes.Add(treeNode8);
			}
			treeNode7.Expand();
			this.#o2c.Nodes.Add(treeNode7);
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x0001B758 File Offset: 0x0001A758
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
				if (this.SchemaSelector != null)
				{
					if (string.Equals(dataSources[i].ConnectionString, this.SchemaSelector.ConnectionString, StringComparison.OrdinalIgnoreCase))
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

		// Token: 0x060006A2 RID: 1698 RVA: 0x0001B850 File Offset: 0x0001A850
		private void #v2c(bool #w2c)
		{
			if (#w2c)
			{
				this.Text = #Mk.#Lk(14765);
				this.#f2c.Enabled = false;
				this.#m2c.Enabled = false;
				return;
			}
			this.Text = #Mk.#Lk(14806);
			this.#f2c.Enabled = true;
			this.#m2c.Enabled = true;
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x0001B8B4 File Offset: 0x0001A8B4
		private void #x2c()
		{
			this.SchemaSelector.Clear();
			this.SchemaSelector.SelectMode = (this.#l2c.Checked ? SelectMode.Include : SelectMode.Exclude);
			this.#y2c(this.#o2c.Nodes);
			foreach (string text in this.#i2c.Lines)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					this.SchemaSelector.SchemaExpressions.Add(text.Trim());
				}
			}
			foreach (string text2 in this.#q2c.Lines)
			{
				if (!string.IsNullOrWhiteSpace(text2))
				{
					this.SchemaSelector.ColumnExpressions.Add(text2.Trim());
				}
			}
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x0001B97C File Offset: 0x0001A97C
		private void #y2c(TreeNodeCollection #DQ)
		{
			if (#DQ == null)
			{
				return;
			}
			foreach (object obj in #DQ)
			{
				TreeNode treeNode = (TreeNode)obj;
				this.#z2c(treeNode);
				this.#y2c(treeNode.Nodes);
			}
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x0001B9E0 File Offset: 0x0001A9E0
		private void #z2c(TreeNode #YQ)
		{
			if (!#YQ.Checked)
			{
				return;
			}
			if (#YQ.Tag is TableSchema)
			{
				this.SchemaSelector.SelectedTables.Add(#YQ.ToolTipText);
				return;
			}
			if (#YQ.Tag is ViewSchema)
			{
				this.SchemaSelector.SelectedTables.Add(#YQ.ToolTipText);
				return;
			}
			if (#YQ.Tag is ColumnSchema)
			{
				this.SchemaSelector.SelectedColumns.Add(#YQ.ToolTipText);
				return;
			}
			if (#YQ.Tag is ViewColumnSchema)
			{
				this.SchemaSelector.SelectedColumns.Add(#YQ.ToolTipText);
				return;
			}
			if (#YQ.Tag is CommandSchema)
			{
				this.SchemaSelector.SelectedCommands.Add(#YQ.ToolTipText);
			}
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x0001BAB0 File Offset: 0x0001AAB0
		private void #A2c()
		{
			this.Cursor = Cursors.WaitCursor;
			this.#v2c(true);
			try
			{
				this.#x2c();
				this.#s2c.Clear();
				foreach (TableSchema tableSchema in this.SchemaSelector.Tables.Selected<TableSchema>())
				{
					string text = string.Format(#Mk.#Lk(14827), tableSchema.SortName, Environment.NewLine);
					this.#s2c.AppendText(text);
					foreach (ColumnSchema columnSchema in tableSchema.Columns.Selected())
					{
						string text2 = string.Format(#Mk.#Lk(14848), columnSchema.SortName, Environment.NewLine);
						this.#s2c.AppendText(text2);
					}
				}
				foreach (ViewSchema viewSchema in this.SchemaSelector.Views.Selected<ViewSchema>())
				{
					string text3 = string.Format(#Mk.#Lk(14873), viewSchema.SortName, Environment.NewLine);
					this.#s2c.AppendText(text3);
					foreach (ViewColumnSchema viewColumnSchema in viewSchema.Columns.Selected())
					{
						string text4 = string.Format(#Mk.#Lk(14848), viewColumnSchema.SortName, Environment.NewLine);
						this.#s2c.AppendText(text4);
					}
				}
				foreach (CommandSchema commandSchema in this.SchemaSelector.Commands.Selected())
				{
					string text5 = string.Format(#Mk.#Lk(14890), commandSchema.SortName, Environment.NewLine);
					this.#s2c.AppendText(text5);
				}
			}
			catch (Exception ex)
			{
				ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(14600), ex.ToString());
			}
			finally
			{
				this.#v2c(false);
				this.Cursor = Cursors.Default;
			}
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x0001BDAC File Offset: 0x0001ADAC
		private void #B2c(object #8j)
		{
			Tuple<DataSource, SchemaSelector> tuple = #8j as Tuple<DataSource, SchemaSelector>;
			DataSource item = tuple.Item1;
			SchemaSelector schemaSelector = tuple.Item2;
			RunWorkerCompletedEventArgs runWorkerCompletedEventArgs = null;
			try
			{
				if (!(item == null))
				{
					if (schemaSelector == null || !string.Equals(schemaSelector.ConnectionString, item.ConnectionString, StringComparison.OrdinalIgnoreCase))
					{
						DatabaseSchema databaseSchema = item.CreateInstance();
						if (databaseSchema == null)
						{
							return;
						}
						schemaSelector = new SchemaSelector(databaseSchema.Provider, databaseSchema.ConnectionString);
						schemaSelector.DeepLoad = true;
					}
					TableSchemaCollection tables = schemaSelector.Tables;
					ViewSchemaCollection views = schemaSelector.Views;
					CommandSchemaCollection commands = schemaSelector.Commands;
					runWorkerCompletedEventArgs = new RunWorkerCompletedEventArgs(schemaSelector, null, false);
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
						item,
						runWorkerCompletedEventArgs
					});
				}
			}
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x0001BEB8 File Offset: 0x0001AEB8
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
						ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(14911), #tm.Error.ToString());
					}
					else
					{
						this.SchemaSelector = (#tm.Result as SchemaSelector);
					}
					this.#t2c();
				}
			}
			finally
			{
				this.#v2c(false);
			}
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x0001BF54 File Offset: 0x0001AF54
		private void #D2c(object #sm, EventArgs #tm)
		{
			this.#v2c(false);
			this.#u2c();
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x0001BF64 File Offset: 0x0001AF64
		private void #E2c(object #sm, EventArgs #tm)
		{
			DataSource dataSource = this.#d2c.SelectedItem as DataSource;
			if (dataSource == null)
			{
				this.#t2c();
				return;
			}
			this.#v2c(true);
			Tuple<DataSource, SchemaSelector> state = new Tuple<DataSource, SchemaSelector>(dataSource, this.SchemaSelector);
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.#B2c), state);
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x0001BFBC File Offset: 0x0001AFBC
		private void #F2c(object #sm, EventArgs #tm)
		{
			DataSourceManagerUI dataSourceManagerUI = new DataSourceManagerUI();
			dataSourceManagerUI.ShowDialog(this);
			this.#u2c();
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x0001BFE0 File Offset: 0x0001AFE0
		private void #G2c(object #sm, EventArgs #tm)
		{
			this.#x2c();
			DataSource dataSource = this.#d2c.SelectedItem as DataSource;
			if (dataSource == null)
			{
				return;
			}
			DataSourceManager.LastSelectedDataSource = dataSource;
			DataSourceManager.Serialize();
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x0001C01C File Offset: 0x0001B01C
		private void #Pec(object #sm, EventArgs #tm)
		{
			base.Close();
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x0001C024 File Offset: 0x0001B024
		private void #H2c(object #sm, TabControlCancelEventArgs #tm)
		{
			if (#tm.TabPage.Name == #Mk.#Lk(15024))
			{
				this.#A2c();
			}
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x0001C048 File Offset: 0x0001B048
		private void #I2c(object #sm, EventArgs #tm)
		{
			if (this.#f2c.SelectedTab.Name == #Mk.#Lk(15024))
			{
				this.#A2c();
			}
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x0001C094 File Offset: 0x0001B094
		private void #lq()
		{
			this.#sS = new Container();
			this.#FTc = new Label();
			this.#d2c = new ComboBox();
			this.#e2c = new Button();
			this.#f2c = new TabControl();
			this.#g2c = new TabPage();
			this.#o2c = new TreeView();
			this.#h2c = new TabPage();
			this.#p2c = new Label();
			this.#q2c = new TextBox();
			this.#n2c = new Label();
			this.#i2c = new TextBox();
			this.#r2c = new TabPage();
			this.#s2c = new TextBox();
			this.#j2c = new GroupBox();
			this.#k2c = new RadioButton();
			this.#l2c = new RadioButton();
			this.#m2c = new Button();
			this.#Rac = new Button();
			this.#r9b = new ToolTip(this.#sS);
			this.#f2c.SuspendLayout();
			this.#g2c.SuspendLayout();
			this.#h2c.SuspendLayout();
			this.#r2c.SuspendLayout();
			this.#j2c.SuspendLayout();
			base.SuspendLayout();
			this.#FTc.Location = new Point(11, 13);
			this.#FTc.Name = #Mk.#Lk(981);
			this.#FTc.Size = new Size(70, 16);
			this.#FTc.TabIndex = 3;
			this.#FTc.Text = #Mk.#Lk(15045);
			this.#d2c.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.#d2c.DropDownStyle = ComboBoxStyle.DropDownList;
			this.#d2c.Location = new Point(83, 9);
			this.#d2c.Name = #Mk.#Lk(15066);
			this.#d2c.Size = new Size(311, 21);
			this.#d2c.TabIndex = 4;
			this.#d2c.SelectedIndexChanged += this.#E2c;
			this.#e2c.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.#e2c.Location = new Point(400, 8);
			this.#e2c.Name = #Mk.#Lk(15091);
			this.#e2c.Size = new Size(23, 22);
			this.#e2c.TabIndex = 5;
			this.#e2c.Text = #Mk.#Lk(15116);
			this.#e2c.Click += this.#F2c;
			this.#f2c.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.#f2c.Controls.Add(this.#g2c);
			this.#f2c.Controls.Add(this.#h2c);
			this.#f2c.Controls.Add(this.#r2c);
			this.#f2c.Location = new Point(11, 39);
			this.#f2c.Name = #Mk.#Lk(15121);
			this.#f2c.SelectedIndex = 0;
			this.#f2c.Size = new Size(412, 287);
			this.#f2c.TabIndex = 8;
			this.#f2c.Selecting += this.#H2c;
			this.#g2c.Controls.Add(this.#o2c);
			this.#g2c.Location = new Point(4, 22);
			this.#g2c.Name = #Mk.#Lk(15146);
			this.#g2c.Size = new Size(404, 261);
			this.#g2c.TabIndex = 0;
			this.#g2c.Text = #Mk.#Lk(15167);
			this.#g2c.UseVisualStyleBackColor = true;
			this.#o2c.CheckBoxes = true;
			this.#o2c.Dock = DockStyle.Fill;
			this.#o2c.Location = new Point(0, 0);
			this.#o2c.Margin = new Padding(0);
			this.#o2c.Name = #Mk.#Lk(15188);
			this.#o2c.Size = new Size(404, 261);
			this.#o2c.TabIndex = 0;
			this.#h2c.Controls.Add(this.#p2c);
			this.#h2c.Controls.Add(this.#q2c);
			this.#h2c.Controls.Add(this.#n2c);
			this.#h2c.Controls.Add(this.#i2c);
			this.#h2c.Location = new Point(4, 22);
			this.#h2c.Name = #Mk.#Lk(15213);
			this.#h2c.Padding = new Padding(3);
			this.#h2c.Size = new Size(404, 261);
			this.#h2c.TabIndex = 1;
			this.#h2c.Text = #Mk.#Lk(15230);
			this.#h2c.UseVisualStyleBackColor = true;
			this.#p2c.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.#p2c.AutoSize = true;
			this.#p2c.Location = new Point(7, 139);
			this.#p2c.Name = #Mk.#Lk(15255);
			this.#p2c.Size = new Size(104, 13);
			this.#p2c.TabIndex = 3;
			this.#p2c.Text = #Mk.#Lk(15284);
			this.#q2c.AcceptsReturn = true;
			this.#q2c.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.#q2c.Location = new Point(6, 158);
			this.#q2c.Multiline = true;
			this.#q2c.Name = #Mk.#Lk(15313);
			this.#q2c.ScrollBars = ScrollBars.Both;
			this.#q2c.Size = new Size(392, 97);
			this.#q2c.TabIndex = 2;
			this.#q2c.WordWrap = false;
			this.#n2c.AutoSize = true;
			this.#n2c.Location = new Point(7, 7);
			this.#n2c.Name = #Mk.#Lk(15346);
			this.#n2c.Size = new Size(108, 13);
			this.#n2c.TabIndex = 1;
			this.#n2c.Text = #Mk.#Lk(15375);
			this.#i2c.AcceptsReturn = true;
			this.#i2c.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.#i2c.Location = new Point(6, 26);
			this.#i2c.Multiline = true;
			this.#i2c.Name = #Mk.#Lk(15404);
			this.#i2c.ScrollBars = ScrollBars.Both;
			this.#i2c.Size = new Size(392, 97);
			this.#i2c.TabIndex = 0;
			this.#i2c.WordWrap = false;
			this.#r2c.Controls.Add(this.#s2c);
			this.#r2c.Location = new Point(4, 22);
			this.#r2c.Name = #Mk.#Lk(15024);
			this.#r2c.Padding = new Padding(3);
			this.#r2c.Size = new Size(404, 261);
			this.#r2c.TabIndex = 2;
			this.#r2c.Text = #Mk.#Lk(15437);
			this.#r2c.UseVisualStyleBackColor = true;
			this.#s2c.AcceptsReturn = true;
			this.#s2c.Dock = DockStyle.Fill;
			this.#s2c.Font = new Font(#Mk.#Lk(15462), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.#s2c.Location = new Point(3, 3);
			this.#s2c.Multiline = true;
			this.#s2c.Name = #Mk.#Lk(15479);
			this.#s2c.ScrollBars = ScrollBars.Both;
			this.#s2c.Size = new Size(398, 255);
			this.#s2c.TabIndex = 2;
			this.#s2c.WordWrap = false;
			this.#j2c.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.#j2c.Controls.Add(this.#k2c);
			this.#j2c.Controls.Add(this.#l2c);
			this.#j2c.Location = new Point(13, 332);
			this.#j2c.Name = #Mk.#Lk(15500);
			this.#j2c.Size = new Size(160, 46);
			this.#j2c.TabIndex = 9;
			this.#j2c.TabStop = false;
			this.#j2c.Text = #Mk.#Lk(15517);
			this.#k2c.AutoSize = true;
			this.#k2c.Checked = true;
			this.#k2c.Location = new Point(19, 18);
			this.#k2c.Name = #Mk.#Lk(15538);
			this.#k2c.Size = new Size(63, 17);
			this.#k2c.TabIndex = 1;
			this.#k2c.TabStop = true;
			this.#k2c.Text = #Mk.#Lk(15563);
			this.#k2c.UseVisualStyleBackColor = true;
			this.#k2c.CheckedChanged += this.#I2c;
			this.#l2c.AutoSize = true;
			this.#l2c.Location = new Point(90, 18);
			this.#l2c.Name = #Mk.#Lk(15576);
			this.#l2c.Size = new Size(60, 17);
			this.#l2c.TabIndex = 0;
			this.#l2c.Text = #Mk.#Lk(15601);
			this.#l2c.UseVisualStyleBackColor = true;
			this.#m2c.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#m2c.DialogResult = DialogResult.OK;
			this.#m2c.Location = new Point(268, 347);
			this.#m2c.Name = #Mk.#Lk(15614);
			this.#m2c.Size = new Size(75, 23);
			this.#m2c.TabIndex = 11;
			this.#m2c.Text = #Mk.#Lk(15631);
			this.#m2c.Click += this.#G2c;
			this.#Rac.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#Rac.DialogResult = DialogResult.Cancel;
			this.#Rac.Location = new Point(348, 347);
			this.#Rac.Name = #Mk.#Lk(15644);
			this.#Rac.Size = new Size(75, 23);
			this.#Rac.TabIndex = 12;
			this.#Rac.Text = #Mk.#Lk(15669);
			this.#Rac.Click += this.#Pec;
			base.AcceptButton = this.#m2c;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.#Rac;
			base.ClientSize = new Size(434, 386);
			base.Controls.Add(this.#f2c);
			base.Controls.Add(this.#j2c);
			base.Controls.Add(this.#m2c);
			base.Controls.Add(this.#Rac);
			base.Controls.Add(this.#FTc);
			base.Controls.Add(this.#d2c);
			base.Controls.Add(this.#e2c);
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new Size(450, 420);
			base.Name = #Mk.#Lk(15682);
			this.Text = #Mk.#Lk(14806);
			base.Load += this.#D2c;
			this.#f2c.ResumeLayout(false);
			this.#g2c.ResumeLayout(false);
			this.#h2c.ResumeLayout(false);
			this.#h2c.PerformLayout();
			this.#r2c.ResumeLayout(false);
			this.#r2c.PerformLayout();
			this.#j2c.ResumeLayout(false);
			this.#j2c.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000254 RID: 596
		[CompilerGenerated]
		private SchemaSelector #c2c;

		// Token: 0x04000256 RID: 598
		private Label #FTc;

		// Token: 0x04000257 RID: 599
		private ComboBox #d2c;

		// Token: 0x04000258 RID: 600
		private Button #e2c;

		// Token: 0x04000259 RID: 601
		private TabControl #f2c;

		// Token: 0x0400025A RID: 602
		private TabPage #g2c;

		// Token: 0x0400025B RID: 603
		private TabPage #h2c;

		// Token: 0x0400025C RID: 604
		private TextBox #i2c;

		// Token: 0x0400025D RID: 605
		private GroupBox #j2c;

		// Token: 0x0400025E RID: 606
		private RadioButton #k2c;

		// Token: 0x0400025F RID: 607
		private RadioButton #l2c;

		// Token: 0x04000260 RID: 608
		private Button #m2c;

		// Token: 0x04000261 RID: 609
		private Button #Rac;

		// Token: 0x04000262 RID: 610
		private Label #n2c;

		// Token: 0x04000263 RID: 611
		private TreeView #o2c;

		// Token: 0x04000264 RID: 612
		private Label #p2c;

		// Token: 0x04000265 RID: 613
		private TextBox #q2c;

		// Token: 0x04000266 RID: 614
		private ToolTip #r9b;

		// Token: 0x04000267 RID: 615
		private TabPage #r2c;

		// Token: 0x04000268 RID: 616
		private TextBox #s2c;
	}
}
