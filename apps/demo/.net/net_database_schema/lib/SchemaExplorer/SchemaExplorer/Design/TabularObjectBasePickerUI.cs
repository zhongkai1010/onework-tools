using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using #Nk;

namespace SchemaExplorer.Design
{
	// Token: 0x020000D5 RID: 213
	public partial class TabularObjectBasePickerUI : Form
	{
		// Token: 0x0600076F RID: 1903 RVA: 0x000238F8 File Offset: 0x000228F8
		public TabularObjectBasePickerUI() : this(false)
		{
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x00023904 File Offset: 0x00022904
		public TabularObjectBasePickerUI(bool allowMultiple)
		{
			this.#lq();
			if (allowMultiple)
			{
				this.#33c.SelectionMode = SelectionMode.MultiExtended;
				return;
			}
			this.#33c.SelectionMode = SelectionMode.One;
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x00023930 File Offset: 0x00022930
		public void Start(object value)
		{
			if (value is ITabularObject)
			{
				this.#23c = (ITabularObject)value;
				this.#43c = null;
				return;
			}
			if (value is TabularObjectBaseCollection)
			{
				this.#23c = null;
				this.#43c = (TabularObjectBaseCollection)value;
				return;
			}
			this.#43c = null;
			this.#23c = null;
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x00023984 File Offset: 0x00022984
		public void End()
		{
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000773 RID: 1907 RVA: 0x00023988 File Offset: 0x00022988
		public ITabularObject SelectedTabularObjectBase
		{
			get
			{
				return this.#33c.SelectedItem as ITabularObject;
			}
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000774 RID: 1908 RVA: 0x0002399C File Offset: 0x0002299C
		public TabularObjectBaseCollection SelectedTabularObjectBaseCollection
		{
			get
			{
				ITabularObject[] array = new ITabularObject[this.#33c.SelectedItems.Count];
				for (int i = 0; i < this.#33c.SelectedItems.Count; i++)
				{
					array[i] = (ITabularObject)this.#33c.SelectedItems[i];
				}
				return new TabularObjectBaseCollection(array);
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x00023AC8 File Offset: 0x00022AC8
		private void #lq()
		{
			this.#sS = new Container();
			this.#W3c = new GroupBox();
			this.#33c = new ListBox();
			this.#m2c = new Button();
			this.#d2c = new ComboBox();
			this.#e2c = new Button();
			this.#Rac = new Button();
			this.#FTc = new Label();
			this.#L2c = new ToolTip(this.#sS);
			this.#W3c.SuspendLayout();
			base.SuspendLayout();
			this.#W3c.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.#W3c.Controls.Add(this.#33c);
			this.#W3c.Location = new Point(8, 32);
			this.#W3c.Name = #Mk.#Lk(18359);
			this.#W3c.Size = new Size(326, 255);
			this.#W3c.TabIndex = 0;
			this.#W3c.TabStop = false;
			this.#W3c.Text = #Mk.#Lk(18484);
			this.#33c.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.#33c.Location = new Point(8, 16);
			this.#33c.Name = #Mk.#Lk(18505);
			this.#33c.Size = new Size(310, 225);
			this.#33c.TabIndex = 0;
			this.#33c.DoubleClick += this.#73c;
			this.#m2c.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#m2c.DialogResult = DialogResult.OK;
			this.#m2c.Location = new Point(178, 292);
			this.#m2c.Name = #Mk.#Lk(15783);
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
			base.Name = #Mk.#Lk(18534);
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = #Mk.#Lk(18571);
			base.Load += this.#53c;
			this.#W3c.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x00023FAC File Offset: 0x00022FAC
		private void #53c(object #sm, EventArgs #tm)
		{
			this.#u2c();
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x00023FB4 File Offset: 0x00022FB4
		private void #63c()
		{
			this.Cursor = Cursors.WaitCursor;
			this.#33c.BeginUpdate();
			this.#33c.Items.Clear();
			try
			{
				if (this.#d2c.SelectedItem as DataSource != null)
				{
					DatabaseSchema databaseSchema = ((DataSource)this.#d2c.SelectedItem).CreateInstance();
					TabularObjectBaseCollection tabularObjectBaseCollection = new TabularObjectBaseCollection();
					tabularObjectBaseCollection.AddRange(databaseSchema.Tables);
					tabularObjectBaseCollection.AddRange(databaseSchema.Views);
					tabularObjectBaseCollection.Sort(new PropertyComparer(#Mk.#Lk(16047)));
					foreach (ITabularObject tabularObject in tabularObjectBaseCollection)
					{
						this.#33c.Items.Add(tabularObject);
						int num = this.#33c.Items.IndexOf(tabularObject);
						if (this.#23c != null && tabularObject.Equals(this.#23c) && num >= 0)
						{
							this.#33c.SelectedIndex = num;
						}
						if (this.#43c != null && this.#43c.Contains(tabularObject) && num >= 0)
						{
							this.#33c.SetSelected(num, true);
						}
					}
				}
				int count = this.#33c.SelectedItems.Count;
				count = this.#33c.Items.Count;
			}
			catch (Exception ex)
			{
				ErrorDialog.Show(this, #Mk.#Lk(11512), #Mk.#Lk(18600), ex.ToString());
			}
			finally
			{
				this.#33c.EndUpdate();
				this.Cursor = Cursors.Default;
			}
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x000241A0 File Offset: 0x000231A0
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
				if (this.#23c != null)
				{
					if (dataSources[i].ConnectionString == this.#23c.Database.ConnectionString)
					{
						num = i + 1;
					}
				}
				else if (this.#43c != null && this.#43c.Count > 0)
				{
					if (dataSources[i].ConnectionString == this.#43c[0].Database.ConnectionString)
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

		// Token: 0x0600077A RID: 1914 RVA: 0x000242E8 File Offset: 0x000232E8
		private void #73c(object #sm, EventArgs #tm)
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

		// Token: 0x0600077B RID: 1915 RVA: 0x00024328 File Offset: 0x00023328
		private void #F2c(object #sm, EventArgs #tm)
		{
			DataSourceManagerUI dataSourceManagerUI = new DataSourceManagerUI();
			dataSourceManagerUI.ShowDialog(this);
			this.#u2c();
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x0002434C File Offset: 0x0002334C
		private void #E2c(object #sm, EventArgs #tm)
		{
			this.#63c();
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x00024354 File Offset: 0x00023354
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

		// Token: 0x040002DA RID: 730
		private GroupBox #W3c;

		// Token: 0x040002DE RID: 734
		private Label #FTc;

		// Token: 0x040002DF RID: 735
		private Button #Rac;

		// Token: 0x040002E1 RID: 737
		private ITabularObject #23c;

		// Token: 0x040002E2 RID: 738
		private ToolTip #L2c;

		// Token: 0x040002E4 RID: 740
		private TabularObjectBaseCollection #43c;
	}
}
