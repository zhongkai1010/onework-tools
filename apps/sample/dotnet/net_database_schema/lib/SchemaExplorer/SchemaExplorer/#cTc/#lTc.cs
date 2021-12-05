using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;
using #Nk;
using Microsoft.Data.ConnectionUI;

namespace #cTc
{
	// Token: 0x0200000A RID: 10
	internal sealed partial class #lTc : Form
	{
		// Token: 0x0600005D RID: 93 RVA: 0x00003698 File Offset: 0x00002698
		public #lTc()
		{
			this.#lq();
			if (this.#sS == null)
			{
				this.#sS = new Container();
			}
			this.#sS.Add(new #5Zc(this));
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000036CC File Offset: 0x000026CC
		public #lTc(IDataConnectionProperties connectionProperties, DataConnectionDialog mainDialog) : this()
		{
			this.#fTc = connectionProperties.ToFullString();
			this.#hTc.SelectedObject = connectionProperties;
			this.#4Sc = mainDialog;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000036F4 File Offset: 0x000026F4
		protected override void OnLoad(EventArgs #tm)
		{
			base.OnLoad(#tm);
			this.#jTc();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003704 File Offset: 0x00002704
		protected override void OnShown(EventArgs #tm)
		{
			base.OnShown(#tm);
			this.#hTc.Focus();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000371C File Offset: 0x0000271C
		protected override void OnFontChanged(EventArgs #tm)
		{
			base.OnFontChanged(#tm);
			this.#gTc.Width = this.#hTc.Width;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000373C File Offset: 0x0000273C
		protected override void OnHelpRequested(HelpEventArgs #9Sc)
		{
			Control control = this;
			ContainerControl containerControl;
			while ((containerControl = (control as ContainerControl)) != null && containerControl != this.#hTc && containerControl.ActiveControl != null)
			{
				control = containerControl.ActiveControl;
			}
			DataConnectionDialogContext context = DataConnectionDialogContext.Advanced;
			if (control == this.#hTc)
			{
				context = DataConnectionDialogContext.AdvancedPropertyGrid;
			}
			if (control == this.#gTc)
			{
				context = DataConnectionDialogContext.AdvancedTextBox;
			}
			if (control == this.#H8b)
			{
				context = DataConnectionDialogContext.AdvancedOkButton;
			}
			if (control == this.#F9b)
			{
				context = DataConnectionDialogContext.AdvancedCancelButton;
			}
			ContextHelpEventArgs contextHelpEventArgs = new ContextHelpEventArgs(context, #9Sc.MousePos);
			this.#4Sc.OnContextHelpRequested(contextHelpEventArgs);
			#9Sc.Handled = contextHelpEventArgs.Handled;
			if (!contextHelpEventArgs.Handled)
			{
				base.OnHelpRequested(#9Sc);
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000037E8 File Offset: 0x000027E8
		[DebuggerStepThrough]
		protected override void WndProc(ref Message #WM)
		{
			if (this.#4Sc.TranslateHelpButton && #JVc.#CVc(ref #WM))
			{
				#JVc.#HVc(this, ref #WM);
			}
			base.WndProc(ref #WM);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003810 File Offset: 0x00002810
		private void #iTc(object #lfb, PropertyValueChangedEventArgs #tm)
		{
			this.#jTc();
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003818 File Offset: 0x00002818
		private void #jTc()
		{
			if (this.#hTc.SelectedObject is IDataConnectionProperties)
			{
				try
				{
					this.#gTc.Text = (this.#hTc.SelectedObject as IDataConnectionProperties).ToDisplayString();
					return;
				}
				catch
				{
					this.#gTc.Text = null;
					return;
				}
			}
			this.#gTc.Text = null;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003884 File Offset: 0x00002884
		private void #kTc(object #sm, EventArgs #tm)
		{
			try
			{
				(this.#hTc.SelectedObject as IDataConnectionProperties).Parse(this.#fTc);
			}
			catch
			{
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000038E4 File Offset: 0x000028E4
		private void #lq()
		{
			this.#sS = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(#lTc));
			this.#hTc = new #lTc.#z4c();
			this.#gTc = new TextBox();
			this.#7Sc = new TableLayoutPanel();
			this.#H8b = new Button();
			this.#F9b = new Button();
			this.#7Sc.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.#hTc, #Mk.#Lk(853));
			this.#hTc.CommandsActiveLinkColor = SystemColors.ActiveCaption;
			this.#hTc.CommandsDisabledLinkColor = SystemColors.ControlDark;
			this.#hTc.CommandsLinkColor = SystemColors.ActiveCaption;
			this.#hTc.MinimumSize = new Size(270, 250);
			this.#hTc.Name = #Mk.#Lk(853);
			this.#hTc.PropertyValueChanged += this.#iTc;
			componentResourceManager.ApplyResources(this.#gTc, #Mk.#Lk(870));
			this.#gTc.Name = #Mk.#Lk(870);
			this.#gTc.ReadOnly = true;
			componentResourceManager.ApplyResources(this.#7Sc, #Mk.#Lk(686));
			this.#7Sc.Controls.Add(this.#H8b, 0, 0);
			this.#7Sc.Controls.Add(this.#F9b, 1, 0);
			this.#7Sc.Name = #Mk.#Lk(686);
			componentResourceManager.ApplyResources(this.#H8b, #Mk.#Lk(719));
			this.#H8b.DialogResult = DialogResult.OK;
			this.#H8b.MinimumSize = new Size(75, 23);
			this.#H8b.Name = #Mk.#Lk(719);
			componentResourceManager.ApplyResources(this.#F9b, #Mk.#Lk(732));
			this.#F9b.DialogResult = DialogResult.Cancel;
			this.#F9b.MinimumSize = new Size(75, 23);
			this.#F9b.Name = #Mk.#Lk(732);
			this.#F9b.Click += this.#kTc;
			base.AcceptButton = this.#H8b;
			componentResourceManager.ApplyResources(this, #Mk.#Lk(598));
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.#F9b;
			base.Controls.Add(this.#7Sc);
			base.Controls.Add(this.#gTc);
			base.Controls.Add(this.#hTc);
			base.HelpButton = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = #Mk.#Lk(883);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.#7Sc.ResumeLayout(false);
			this.#7Sc.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003BDC File Offset: 0x00002BDC
		// Note: this type is marked as 'beforefieldinit'.
		static #lTc()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (#lTc.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x0600006A RID: 106
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x04000023 RID: 35
		private string #fTc;

		// Token: 0x04000024 RID: 36
		private DataConnectionDialog #4Sc;

		// Token: 0x04000026 RID: 38
		private TextBox #gTc;

		// Token: 0x04000027 RID: 39
		private TableLayoutPanel #7Sc;

		// Token: 0x04000028 RID: 40
		private Button #H8b;

		// Token: 0x04000029 RID: 41
		private Button #F9b;

		// Token: 0x0400002A RID: 42
		private #lTc.#z4c #hTc;

		// Token: 0x0200000B RID: 11
		internal sealed class #z4c : PropertyGrid
		{
			// Token: 0x0600006B RID: 107 RVA: 0x00003C30 File Offset: 0x00002C30
			public #z4c()
			{
				this.#r4c = new ContextMenuStrip();
				this.#r4c.Items.AddRange(new ToolStripItem[]
				{
					new ToolStripMenuItem(),
					new ToolStripSeparator(),
					new ToolStripMenuItem(),
					new ToolStripMenuItem(),
					new ToolStripSeparator(),
					new ToolStripMenuItem()
				});
				this.#r4c.Items[0].Text = #Mk.DataConnectionAdvancedDialog_Reset;
				this.#r4c.Items[0].Click += this.#t4c;
				this.#r4c.Items[2].Text = #Mk.DataConnectionAdvancedDialog_Add;
				this.#r4c.Items[2].Click += this.#u4c;
				this.#r4c.Items[3].Text = #Mk.DataConnectionAdvancedDialog_Remove;
				this.#r4c.Items[3].Click += this.#v4c;
				this.#r4c.Items[5].Text = #Mk.DataConnectionAdvancedDialog_Description;
				this.#r4c.Items[5].Click += this.#w4c;
				(this.#r4c.Items[5] as ToolStripMenuItem).Checked = this.HelpVisible;
				this.#r4c.Opened += this.#s4c;
				this.ContextMenuStrip = this.#r4c;
				base.DrawFlatToolbar = true;
				base.Size = new Size(270, 250);
				this.MinimumSize = base.Size;
			}

			// Token: 0x0600006C RID: 108 RVA: 0x00003DF4 File Offset: 0x00002DF4
			protected override void OnHandleCreated(EventArgs #tm)
			{
				ProfessionalColorTable professionalColorTable = (base.ParentForm != null && base.ParentForm.Site != null) ? (base.ParentForm.Site.GetService(typeof(ProfessionalColorTable)) as ProfessionalColorTable) : null;
				if (professionalColorTable != null)
				{
					base.ToolStripRenderer = new ToolStripProfessionalRenderer(professionalColorTable);
				}
				base.OnHandleCreated(#tm);
			}

			// Token: 0x0600006D RID: 109 RVA: 0x00003E50 File Offset: 0x00002E50
			protected override void OnFontChanged(EventArgs #tm)
			{
				base.OnFontChanged(#tm);
				base.LargeButtons = ((double)this.Font.SizeInPoints >= 15.0);
			}

			// Token: 0x0600006E RID: 110 RVA: 0x00003E7C File Offset: 0x00002E7C
			[DebuggerStepThrough]
			protected override void WndProc(ref Message #WM)
			{
				int msg = #WM.Msg;
				if (msg == 7)
				{
					base.Focus();
					((IComPropertyBrowser)this).HandleF4();
				}
				base.WndProc(ref #WM);
			}

			// Token: 0x0600006F RID: 111 RVA: 0x00003EA8 File Offset: 0x00002EA8
			private void #s4c(object #sm, EventArgs #tm)
			{
				this.#r4c.Items[0].Enabled = (base.SelectedGridItem.GridItemType == GridItemType.Property);
				if (this.#r4c.Items[0].Enabled && base.SelectedGridItem.PropertyDescriptor != null)
				{
					object component = base.SelectedObject;
					if (base.SelectedObject is ICustomTypeDescriptor)
					{
						component = (base.SelectedObject as ICustomTypeDescriptor).GetPropertyOwner(base.SelectedGridItem.PropertyDescriptor);
					}
					this.#r4c.Items[0].Enabled = (this.#r4c.Items[3].Enabled = base.SelectedGridItem.PropertyDescriptor.CanResetValue(component));
				}
				this.#r4c.Items[2].Visible = (this.#r4c.Items[3].Visible = (base.SelectedObject as IDataConnectionProperties).IsExtensible);
				if (this.#r4c.Items[3].Visible)
				{
					this.#r4c.Items[3].Enabled = (base.SelectedGridItem.GridItemType == GridItemType.Property);
					if (this.#r4c.Items[3].Enabled && base.SelectedGridItem.PropertyDescriptor != null)
					{
						this.#r4c.Items[3].Enabled = !base.SelectedGridItem.PropertyDescriptor.IsReadOnly;
					}
				}
				this.#r4c.Items[1].Visible = (this.#r4c.Items[2].Visible || this.#r4c.Items[3].Visible);
			}

			// Token: 0x06000070 RID: 112 RVA: 0x00004080 File Offset: 0x00003080
			private void #t4c(object #sm, EventArgs #tm)
			{
				object value = base.SelectedGridItem.Value;
				object component = base.SelectedObject;
				if (base.SelectedObject is ICustomTypeDescriptor)
				{
					component = (base.SelectedObject as ICustomTypeDescriptor).GetPropertyOwner(base.SelectedGridItem.PropertyDescriptor);
				}
				base.SelectedGridItem.PropertyDescriptor.ResetValue(component);
				this.Refresh();
				this.OnPropertyValueChanged(new PropertyValueChangedEventArgs(base.SelectedGridItem, value));
			}

			// Token: 0x06000071 RID: 113 RVA: 0x000040F4 File Offset: 0x000030F4
			private void #u4c(object #sm, EventArgs #tm)
			{
				DataConnectionDialog dataConnectionDialog = base.ParentForm as DataConnectionDialog;
				if (dataConnectionDialog == null)
				{
					dataConnectionDialog = (base.ParentForm as #lTc).#4Sc;
				}
				#bTc #bTc = new #bTc(dataConnectionDialog);
				try
				{
					if (base.ParentForm.Container != null)
					{
						base.ParentForm.Container.Add(#bTc);
					}
					DialogResult dialogResult = #bTc.ShowDialog(base.ParentForm);
					if (dialogResult == DialogResult.OK)
					{
						(base.SelectedObject as IDataConnectionProperties).Add(#bTc.PropertyName);
						this.Refresh();
						GridItem gridItem = base.SelectedGridItem;
						while (gridItem.Parent != null)
						{
							gridItem = gridItem.Parent;
						}
						GridItem gridItem2 = this.#x4c(gridItem, #bTc.PropertyName);
						if (gridItem2 != null)
						{
							base.SelectedGridItem = gridItem2;
						}
					}
				}
				finally
				{
					if (base.ParentForm.Container != null)
					{
						base.ParentForm.Container.Remove(#bTc);
					}
					#bTc.Dispose();
				}
			}

			// Token: 0x06000072 RID: 114 RVA: 0x000041E0 File Offset: 0x000031E0
			private void #v4c(object #sm, EventArgs #tm)
			{
				(base.SelectedObject as IDataConnectionProperties).Remove(base.SelectedGridItem.Label);
				this.Refresh();
				this.OnPropertyValueChanged(new PropertyValueChangedEventArgs(null, null));
			}

			// Token: 0x06000073 RID: 115 RVA: 0x00004210 File Offset: 0x00003210
			private void #w4c(object #sm, EventArgs #tm)
			{
				this.HelpVisible = !this.HelpVisible;
				(this.#r4c.Items[5] as ToolStripMenuItem).Checked = !(this.#r4c.Items[5] as ToolStripMenuItem).Checked;
			}

			// Token: 0x06000074 RID: 116 RVA: 0x00004268 File Offset: 0x00003268
			private GridItem #x4c(GridItem #y4c, string #Ekb)
			{
				if (#y4c.GridItemType == GridItemType.Property && #y4c.Label.Equals(#Ekb, StringComparison.CurrentCulture))
				{
					return #y4c;
				}
				GridItem gridItem = null;
				foreach (object obj in #y4c.GridItems)
				{
					GridItem #y4c2 = (GridItem)obj;
					gridItem = this.#x4c(#y4c2, #Ekb);
					if (gridItem != null)
					{
						break;
					}
				}
				return gridItem;
			}

			// Token: 0x06000075 RID: 117 RVA: 0x000042E4 File Offset: 0x000032E4
			// Note: this type is marked as 'beforefieldinit'.
			static #z4c()
			{
				bool flag = false;
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				if (#lTc.#z4c.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
				{
					return;
				}
				throw new SecurityException(#Mk.#Lk(799));
			}

			// Token: 0x06000076 RID: 118
			[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
			[return: MarshalAs(UnmanagedType.Bool)]
			private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

			// Token: 0x0400002B RID: 43
			private ContextMenuStrip #r4c;
		}
	}
}
