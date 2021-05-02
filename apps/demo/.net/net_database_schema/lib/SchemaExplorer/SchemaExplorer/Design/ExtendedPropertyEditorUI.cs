using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using #Nk;

namespace SchemaExplorer.Design
{
	// Token: 0x020000D2 RID: 210
	public partial class ExtendedPropertyEditorUI : Form
	{
		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000737 RID: 1847 RVA: 0x00021678 File Offset: 0x00020678
		// (set) Token: 0x06000738 RID: 1848 RVA: 0x00021680 File Offset: 0x00020680
		public ExtendedPropertyCollection ExtendedPropertyCollection
		{
			get
			{
				return this.#y3c;
			}
			set
			{
				this.#y3c = value;
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000739 RID: 1849 RVA: 0x0002168C File Offset: 0x0002068C
		// (set) Token: 0x0600073A RID: 1850 RVA: 0x00021694 File Offset: 0x00020694
		public bool IsDirty
		{
			get
			{
				return this.#Xr;
			}
			set
			{
				this.#Xr = value;
			}
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x000216A0 File Offset: 0x000206A0
		static ExtendedPropertyEditorUI()
		{
			ExtendedPropertyEditorUI.#So.Add(DbType.AnsiString);
			ExtendedPropertyEditorUI.#So.Add(DbType.Boolean);
			ExtendedPropertyEditorUI.#So.Add(DbType.Currency);
			ExtendedPropertyEditorUI.#So.Add(DbType.DateTime);
			ExtendedPropertyEditorUI.#So.Add(DbType.Decimal);
			ExtendedPropertyEditorUI.#So.Add(DbType.Double);
			ExtendedPropertyEditorUI.#So.Add(DbType.Guid);
			ExtendedPropertyEditorUI.#So.Add(DbType.Int16);
			ExtendedPropertyEditorUI.#So.Add(DbType.Int32);
			ExtendedPropertyEditorUI.#So.Add(DbType.Int64);
			ExtendedPropertyEditorUI.#So.Add(DbType.Single);
			ExtendedPropertyEditorUI.#So.Add(DbType.String);
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x00021744 File Offset: 0x00020744
		public ExtendedPropertyEditorUI()
		{
			this.#lq();
			this.#bp = new BindingList<ExtendedBindableProperty>();
			this.#z3c = new List<ExtendedBindableProperty>();
			this.#B3c.AutoGenerateColumns = false;
			this.#C3c.ValueType = typeof(DbType);
			this.#C3c.DataSource = ExtendedPropertyEditorUI.#So;
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x000217A4 File Offset: 0x000207A4
		public ExtendedPropertyEditorUI(SchemaObjectBase schemaObject) : this()
		{
			this.#y3c = schemaObject.ExtendedProperties;
			foreach (ExtendedProperty property in this.#y3c)
			{
				this.#bp.Add(new ExtendedBindableProperty(property));
			}
			this.#B3c.DataSource = this.#bp;
			this.Text = #Mk.#Lk(18062) + schemaObject.ToString();
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x0002183C File Offset: 0x0002083C
		public void Start(object value, string name)
		{
			if (value is ExtendedPropertyCollection)
			{
				this.#y3c = (ExtendedPropertyCollection)value;
				foreach (ExtendedProperty property in this.#y3c)
				{
					this.#bp.Add(new ExtendedBindableProperty(property));
				}
				this.#B3c.DataSource = this.#bp;
				this.Text = #Mk.#Lk(18062) + name;
			}
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x000218D0 File Offset: 0x000208D0
		public void End()
		{
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x000218D4 File Offset: 0x000208D4
		private void #mac(object #sm, EventArgs #tm)
		{
			foreach (ExtendedBindableProperty extendedBindableProperty in this.#bp)
			{
				if (!extendedBindableProperty.IsReadonly && extendedBindableProperty.IsDirty)
				{
					if (extendedBindableProperty.IsNew)
					{
						this.#y3c.Add(new ExtendedProperty(extendedBindableProperty.Name, extendedBindableProperty.Value, extendedBindableProperty.DataType, PropertyStateEnum.New));
						this.#Xr = true;
					}
					else
					{
						ExtendedProperty extendedProperty = this.#y3c[extendedBindableProperty.Name];
						extendedProperty.Value = extendedBindableProperty.Value;
						this.#Xr = true;
					}
				}
			}
			foreach (ExtendedBindableProperty extendedBindableProperty2 in this.#z3c)
			{
				if (!extendedBindableProperty2.IsReadonly)
				{
					ExtendedProperty extendedProperty2 = this.#y3c[extendedBindableProperty2.Name];
					extendedProperty2.PropertyState = PropertyStateEnum.Deleted;
					this.#Xr = true;
				}
			}
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x000219F0 File Offset: 0x000209F0
		private void #E3c(object #sm, DataGridViewCellCancelEventArgs #tm)
		{
			ExtendedBindableProperty extendedBindableProperty = this.#B3c.Rows[#tm.RowIndex].DataBoundItem as ExtendedBindableProperty;
			if (extendedBindableProperty == null)
			{
				return;
			}
			if (extendedBindableProperty.IsReadonly)
			{
				#tm.Cancel = true;
				return;
			}
			if (#tm.ColumnIndex <= 1 && !extendedBindableProperty.IsNew)
			{
				#tm.Cancel = true;
				return;
			}
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00021A4C File Offset: 0x00020A4C
		private void #F3c(object #sm, DataGridViewRowCancelEventArgs #tm)
		{
			ExtendedBindableProperty extendedBindableProperty = #tm.Row.DataBoundItem as ExtendedBindableProperty;
			if (extendedBindableProperty == null)
			{
				return;
			}
			if (extendedBindableProperty.IsReadonly)
			{
				#tm.Cancel = true;
				return;
			}
			this.#z3c.Add(extendedBindableProperty);
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x00021A8C File Offset: 0x00020A8C
		private void #G3c(object #sm, DataGridViewCellCancelEventArgs #tm)
		{
			ExtendedBindableProperty extendedBindableProperty = this.#B3c.Rows[#tm.RowIndex].DataBoundItem as ExtendedBindableProperty;
			if (extendedBindableProperty == null)
			{
				return;
			}
			if (!extendedBindableProperty.Validate())
			{
				#tm.Cancel = true;
			}
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x00021AD0 File Offset: 0x00020AD0
		private void #H3c(object #sm, CancelEventArgs #tm)
		{
			if (this.#B3c.CurrentRow == null)
			{
				#tm.Cancel = true;
				return;
			}
			ExtendedBindableProperty extendedBindableProperty = this.#B3c.CurrentRow.DataBoundItem as ExtendedBindableProperty;
			if (extendedBindableProperty == null)
			{
				#tm.Cancel = true;
				return;
			}
			this.#fcc.Enabled = !extendedBindableProperty.IsReadonly;
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x00021B28 File Offset: 0x00020B28
		private void #scc(object #sm, EventArgs #tm)
		{
			if (this.#B3c.CurrentRow == null)
			{
				return;
			}
			ExtendedBindableProperty extendedBindableProperty = this.#B3c.CurrentRow.DataBoundItem as ExtendedBindableProperty;
			if (extendedBindableProperty.IsReadonly)
			{
				return;
			}
			this.#bp.Remove(extendedBindableProperty);
			this.#z3c.Add(extendedBindableProperty);
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x00021B7C File Offset: 0x00020B7C
		private void #I3c(object #sm, DataGridViewDataErrorEventArgs #tm)
		{
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x00021C80 File Offset: 0x00020C80
		private void #lq()
		{
			this.#sS = new Container();
			this.#H8b = new Button();
			this.#F9b = new Button();
			this.#A3c = new Panel();
			this.#B3c = new DataGridView();
			this.#Ucc = new DataGridViewTextBoxColumn();
			this.#C3c = new DataGridViewComboBoxColumn();
			this.#Vcc = new DataGridViewTextBoxColumn();
			this.#D3c = new ContextMenuStrip(this.#sS);
			this.#fcc = new ToolStripMenuItem();
			this.#A3c.SuspendLayout();
			((ISupportInitialize)this.#B3c).BeginInit();
			this.#D3c.SuspendLayout();
			base.SuspendLayout();
			this.#H8b.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#H8b.DialogResult = DialogResult.OK;
			this.#H8b.Location = new Point(326, 6);
			this.#H8b.Name = #Mk.#Lk(719);
			this.#H8b.Size = new Size(75, 23);
			this.#H8b.TabIndex = 3;
			this.#H8b.Text = #Mk.#Lk(17131);
			this.#H8b.Click += this.#mac;
			this.#F9b.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#F9b.DialogResult = DialogResult.Cancel;
			this.#F9b.Location = new Point(407, 6);
			this.#F9b.Name = #Mk.#Lk(732);
			this.#F9b.Size = new Size(75, 23);
			this.#F9b.TabIndex = 4;
			this.#F9b.Text = #Mk.#Lk(15913);
			this.#A3c.Controls.Add(this.#H8b);
			this.#A3c.Controls.Add(this.#F9b);
			this.#A3c.Dock = DockStyle.Bottom;
			this.#A3c.Location = new Point(0, 289);
			this.#A3c.Name = #Mk.#Lk(18099);
			this.#A3c.Size = new Size(492, 35);
			this.#A3c.TabIndex = 7;
			this.#B3c.AllowUserToResizeRows = false;
			this.#B3c.BackgroundColor = SystemColors.Window;
			this.#B3c.BorderStyle = BorderStyle.None;
			this.#B3c.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.#B3c.Columns.AddRange(new DataGridViewColumn[]
			{
				this.#Ucc,
				this.#C3c,
				this.#Vcc
			});
			this.#B3c.ContextMenuStrip = this.#D3c;
			this.#B3c.Dock = DockStyle.Fill;
			this.#B3c.EnableHeadersVisualStyles = false;
			this.#B3c.Location = new Point(0, 0);
			this.#B3c.MultiSelect = false;
			this.#B3c.Name = #Mk.#Lk(18116);
			this.#B3c.RowHeadersWidth = 40;
			this.#B3c.Size = new Size(492, 289);
			this.#B3c.TabIndex = 6;
			this.#B3c.UserDeletingRow += this.#F3c;
			this.#B3c.CellBeginEdit += this.#E3c;
			this.#B3c.RowValidating += this.#G3c;
			this.#B3c.DataError += this.#I3c;
			this.#Ucc.DataPropertyName = #Mk.#Lk(12136);
			this.#Ucc.HeaderText = #Mk.#Lk(12136);
			this.#Ucc.MinimumWidth = 100;
			this.#Ucc.Name = #Mk.#Lk(18141);
			this.#Ucc.Width = 125;
			this.#C3c.DataPropertyName = #Mk.#Lk(18158);
			this.#C3c.FlatStyle = FlatStyle.Flat;
			this.#C3c.HeaderText = #Mk.#Lk(16785);
			this.#C3c.Name = #Mk.#Lk(18171);
			this.#C3c.Resizable = DataGridViewTriState.True;
			this.#C3c.SortMode = DataGridViewColumnSortMode.Automatic;
			this.#C3c.Width = 80;
			this.#Vcc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.#Vcc.DataPropertyName = #Mk.#Lk(12608);
			this.#Vcc.HeaderText = #Mk.#Lk(12608);
			this.#Vcc.Name = #Mk.#Lk(18188);
			this.#D3c.Items.AddRange(new ToolStripItem[]
			{
				this.#fcc
			});
			this.#D3c.Name = #Mk.#Lk(18205);
			this.#D3c.RenderMode = ToolStripRenderMode.System;
			this.#D3c.ShowImageMargin = false;
			this.#D3c.Size = new Size(92, 26);
			this.#D3c.Opening += this.#H3c;
			this.#fcc.Name = #Mk.#Lk(18234);
			this.#fcc.Size = new Size(91, 22);
			this.#fcc.Text = #Mk.#Lk(18271);
			this.#fcc.Click += this.#scc;
			base.AcceptButton = this.#H8b;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.#F9b;
			base.ClientSize = new Size(492, 324);
			base.Controls.Add(this.#B3c);
			base.Controls.Add(this.#A3c);
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = #Mk.#Lk(18284);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = #Mk.#Lk(18317);
			this.#A3c.ResumeLayout(false);
			((ISupportInitialize)this.#B3c).EndInit();
			this.#D3c.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040002BE RID: 702
		private ExtendedPropertyCollection #y3c;

		// Token: 0x040002BF RID: 703
		private BindingList<ExtendedBindableProperty> #bp;

		// Token: 0x040002C0 RID: 704
		private List<ExtendedBindableProperty> #z3c;

		// Token: 0x040002C1 RID: 705
		private static readonly List<DbType> #So = new List<DbType>(12);

		// Token: 0x040002C2 RID: 706
		private bool #Xr;

		// Token: 0x040002C6 RID: 710
		private Button #F9b;

		// Token: 0x040002C7 RID: 711
		private Panel #A3c;

		// Token: 0x040002C9 RID: 713
		private DataGridViewTextBoxColumn #Ucc;

		// Token: 0x040002CA RID: 714
		private DataGridViewComboBoxColumn #C3c;

		// Token: 0x040002CB RID: 715
		private DataGridViewTextBoxColumn #Vcc;
	}
}
