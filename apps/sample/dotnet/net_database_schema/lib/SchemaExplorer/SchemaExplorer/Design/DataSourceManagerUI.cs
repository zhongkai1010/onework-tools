using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using #J2c;
using #Nk;
using CodeSmith.Engine.Utility;

namespace SchemaExplorer.Design
{
	// Token: 0x020000CC RID: 204
	public partial class DataSourceManagerUI : Form
	{
		// Token: 0x060006F7 RID: 1783 RVA: 0x0001F3AC File Offset: 0x0001E3AC
		public DataSourceManagerUI()
		{
			this.#lq();
			this.#a3c();
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x0001F3C0 File Offset: 0x0001E3C0
		private void #a3c()
		{
			this.#62c.Items.Clear();
			foreach (DataSource dataSource in DataSourceManager.DataSources)
			{
				ListViewItem listViewItem = new ListViewItem
				{
					Tag = dataSource,
					Text = dataSource.Name
				};
				string text = null;
				try
				{
					text = ((dataSource.ProviderType != null) ? dataSource.ProviderType.Name : #Mk.#Lk(16678));
				}
				catch (ArgumentException innerException)
				{
					string message = string.Format(#Mk.#Lk(16683), dataSource.Name);
					ErrorDialog.Show(this, new ArgumentException(message, innerException));
				}
				catch (FileLoadException inner)
				{
					string message2 = string.Format(#Mk.#Lk(16683), dataSource.Name);
					ErrorDialog.Show(this, new FileLoadException(message2, inner));
				}
				listViewItem.SubItems.Add(text ?? #Mk.#Lk(16678));
				this.#62c.Items.Add(listViewItem);
			}
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x0001F5F4 File Offset: 0x0001E5F4
		private void #lq()
		{
			this.#62c = new #Jlc();
			this.#kec = new ColumnHeader();
			this.#82c = new ColumnHeader();
			this.#rdc = new Button();
			this.#72c = new Button();
			this.#RU = new Button();
			this.#92c = new Button();
			this.#rV = new Button();
			base.SuspendLayout();
			this.#62c.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.#62c.Columns.AddRange(new ColumnHeader[]
			{
				this.#kec,
				this.#82c
			});
			this.#62c.FullRowSelect = true;
			this.#62c.Location = new Point(8, 8);
			this.#62c.MultiSelect = false;
			this.#62c.Name = #Mk.#Lk(16760);
			this.#62c.Size = new Size(395, 168);
			this.#62c.Sorting = SortOrder.Ascending;
			this.#62c.TabIndex = 0;
			this.#62c.UseCompatibleStateImageBehavior = false;
			this.#62c.View = View.Details;
			this.#62c.DoubleClick += this.#e3c;
			this.#kec.Text = #Mk.#Lk(12136);
			this.#kec.Width = 253;
			this.#82c.Text = #Mk.#Lk(16785);
			this.#82c.Width = 125;
			this.#rdc.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#rdc.DialogResult = DialogResult.Cancel;
			this.#rdc.Location = new Point(328, 184);
			this.#rdc.Name = #Mk.#Lk(16794);
			this.#rdc.Size = new Size(75, 23);
			this.#rdc.TabIndex = 4;
			this.#rdc.Text = #Mk.#Lk(16811);
			this.#rdc.Click += this.#c3c;
			this.#72c.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#72c.Location = new Point(248, 184);
			this.#72c.Name = #Mk.#Lk(16820);
			this.#72c.Size = new Size(75, 23);
			this.#72c.TabIndex = 3;
			this.#72c.Text = #Mk.#Lk(16837);
			this.#72c.Click += this.#b3c;
			this.#RU.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#RU.Location = new Point(88, 184);
			this.#RU.Name = #Mk.#Lk(16846);
			this.#RU.Size = new Size(75, 23);
			this.#RU.TabIndex = 1;
			this.#RU.Text = #Mk.#Lk(16859);
			this.#RU.Click += this.#99b;
			this.#92c.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#92c.Location = new Point(168, 184);
			this.#92c.Name = #Mk.#Lk(16864);
			this.#92c.Size = new Size(75, 23);
			this.#92c.TabIndex = 2;
			this.#92c.Text = #Mk.#Lk(16881);
			this.#92c.Click += this.#d3c;
			this.#rV.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#rV.Location = new Point(8, 184);
			this.#rV.Name = #Mk.#Lk(16890);
			this.#rV.Size = new Size(75, 23);
			this.#rV.TabIndex = 5;
			this.#rV.Text = #Mk.#Lk(16907);
			this.#rV.Click += this.#f3c;
			this.AutoScaleBaseSize = new Size(5, 13);
			base.CancelButton = this.#rdc;
			base.ClientSize = new Size(413, 216);
			base.Controls.Add(this.#rV);
			base.Controls.Add(this.#92c);
			base.Controls.Add(this.#RU);
			base.Controls.Add(this.#72c);
			base.Controls.Add(this.#rdc);
			base.Controls.Add(this.#62c);
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			this.MinimumSize = new Size(421, 200);
			base.Name = #Mk.#Lk(16916);
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = #Mk.#Lk(16945);
			base.ResumeLayout(false);
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x0001FB1C File Offset: 0x0001EB1C
		private void #b3c(object #sm, EventArgs #tm)
		{
			if (this.#62c.SelectedItems.Count == 1 && MessageBox.Show(this, #Mk.#Lk(16974), #Mk.#Lk(17047), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				DataSourceManager.Delete((DataSource)this.#62c.SelectedItems[0].Tag);
				DataSourceManager.Serialize();
			}
			this.#a3c();
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x0001FB88 File Offset: 0x0001EB88
		private void #c3c(object #sm, EventArgs #tm)
		{
			if (this.#62c.SelectedItems.Count > 0)
			{
				DataSource dataSource = this.#62c.SelectedItems[0].Tag as DataSource;
				if (dataSource != null)
				{
					DataSourceManager.LastSelectedDataSource = dataSource;
				}
			}
			base.Close();
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x0001FBDC File Offset: 0x0001EBDC
		private void #99b(object #sm, EventArgs #tm)
		{
			try
			{
				DataSourceUI dataSourceUI = new DataSourceUI();
				DialogResult dialogResult = dataSourceUI.ShowDialog(this);
				if (dialogResult == DialogResult.OK)
				{
					this.#a3c();
				}
			}
			catch (Exception ex)
			{
				if (!ExceptionHelper.IsLicenseException(ex))
				{
					throw;
				}
				MessageBox.Show(ex.Message, #Mk.#Lk(17072), MessageBoxButtons.OK);
			}
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x0001FC38 File Offset: 0x0001EC38
		private void #d3c(object #sm, EventArgs #tm)
		{
			if (this.#62c.SelectedItems.Count == 1)
			{
				try
				{
					DataSourceUI dataSourceUI = new DataSourceUI((DataSource)this.#62c.SelectedItems[0].Tag);
					DialogResult dialogResult = dataSourceUI.ShowDialog(this);
					if (dialogResult == DialogResult.OK)
					{
						this.#a3c();
					}
				}
				catch (Exception ex)
				{
					if (!ExceptionHelper.IsLicenseException(ex))
					{
						throw;
					}
					MessageBox.Show(ex.Message, #Mk.#Lk(17072), MessageBoxButtons.OK);
				}
			}
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x0001FCC4 File Offset: 0x0001ECC4
		private void #e3c(object #sm, EventArgs #tm)
		{
			this.#d3c(null, EventArgs.Empty);
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x0001FCD4 File Offset: 0x0001ECD4
		private void #f3c(object #sm, EventArgs #tm)
		{
			if (this.#62c.SelectedItems.Count == 1)
			{
				DataSource dataSource = this.#62c.SelectedItems[0].Tag as DataSource;
				DataSourceManager.Save(new DataSource(string.Format(#Mk.#Lk(17101), dataSource.Name), dataSource.ConnectionString, dataSource.ProviderType));
				this.#a3c();
			}
		}

		// Token: 0x04000296 RID: 662
		private ColumnHeader #kec;

		// Token: 0x04000297 RID: 663
		private ColumnHeader #82c;
	}
}
