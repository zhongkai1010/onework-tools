using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using #cTc;
using #Nk;
using Microsoft.Win32;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x0200002C RID: 44
	public class OleDBConnectionUIControl : UserControl, IDataConnectionUIControl
	{
		// Token: 0x060001EE RID: 494 RVA: 0x0000BBB8 File Offset: 0x0000ABB8
		public OleDBConnectionUIControl()
		{
			this.#lq();
			this.RightToLeft = RightToLeft.Inherit;
			this.#fXc = Thread.CurrentThread;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0000BBD8 File Offset: 0x0000ABD8
		public void Initialize(IDataConnectionProperties connectionProperties)
		{
			this.Initialize(connectionProperties, false);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0000BBE4 File Offset: 0x0000ABE4
		public void Initialize(IDataConnectionProperties connectionProperties, bool disableProviderSelection)
		{
			if (!(connectionProperties is OleDBConnectionProperties))
			{
				throw new ArgumentException(#cTc.#Mk.OleDBConnectionUIControl_InvalidConnectionProperties);
			}
			this.#3Xc();
			this.#RXc.Enabled = !disableProviderSelection;
			this.#SXc.Enabled = false;
			this.#gXc.Enabled = false;
			this.#OSc.Enabled = false;
			this.#1Xc.Enabled = false;
			this.#2Xc.Enabled = false;
			this.#KSc = connectionProperties;
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0000BC5C File Offset: 0x0000AC5C
		public void LoadProperties()
		{
			this.#6yc = true;
			string text = this.Properties[#Nk.#Mk.#Lk(2469)] as string;
			if (text != null && text.Length > 0)
			{
				object obj = null;
				foreach (object obj2 in this.#RXc.Items)
				{
					OleDBConnectionUIControl.#e5c #e5c = (OleDBConnectionUIControl.#e5c)obj2;
					if (#e5c.ProgId.Equals(text))
					{
						obj = #e5c;
						break;
					}
					if (#e5c.ProgId.StartsWith(text + #Nk.#Mk.#Lk(2619), StringComparison.OrdinalIgnoreCase) && (obj == null || #e5c.ProgId.CompareTo(((OleDBConnectionUIControl.#e5c)obj).ProgId) > 0))
					{
						obj = #e5c;
					}
				}
				this.#RXc.SelectedItem = obj;
			}
			else
			{
				this.#RXc.SelectedItem = null;
			}
			if (this.Properties.Contains(#Nk.#Mk.#Lk(241)) && this.Properties[#Nk.#Mk.#Lk(241)] is string)
			{
				this.#HTc.Text = (this.Properties[#Nk.#Mk.#Lk(241)] as string);
			}
			else
			{
				this.#HTc.Text = null;
			}
			if (this.Properties.Contains(#Nk.#Mk.#Lk(2729)) && this.Properties[#Nk.#Mk.#Lk(2729)] is string)
			{
				this.#UXc.Text = (this.Properties[#Nk.#Mk.#Lk(2729)] as string);
			}
			else
			{
				this.#UXc.Text = null;
			}
			if (this.Properties.Contains(#Nk.#Mk.#Lk(2568)) && this.Properties[#Nk.#Mk.#Lk(2568)] is string && (this.Properties[#Nk.#Mk.#Lk(2568)] as string).Length > 0)
			{
				this.#VXc.Checked = true;
			}
			else
			{
				this.#WXc.Checked = true;
			}
			if (this.Properties.Contains(#Nk.#Mk.#Lk(263)) && this.Properties[#Nk.#Mk.#Lk(263)] is string)
			{
				this.#RSc.Text = (this.Properties[#Nk.#Mk.#Lk(263)] as string);
			}
			else
			{
				this.#RSc.Text = null;
			}
			if (this.Properties.Contains(#Nk.#Mk.#Lk(2742)) && this.Properties[#Nk.#Mk.#Lk(2742)] is string)
			{
				this.#TSc.Text = (this.Properties[#Nk.#Mk.#Lk(2742)] as string);
				this.#ZXc.Checked = (this.#TSc.Text.Length == 0);
			}
			else
			{
				this.#TSc.Text = null;
				this.#ZXc.Checked = false;
			}
			if (this.Properties.Contains(#Nk.#Mk.#Lk(212)) && this.Properties[#Nk.#Mk.#Lk(212)] is bool)
			{
				this.#0Xc.Checked = (bool)this.Properties[#Nk.#Mk.#Lk(212)];
			}
			else
			{
				this.#0Xc.Checked = false;
			}
			if (this.Properties.Contains(#Nk.#Mk.#Lk(2755)) && this.Properties[#Nk.#Mk.#Lk(2755)] is string)
			{
				this.#2Xc.Text = (this.Properties[#Nk.#Mk.#Lk(2755)] as string);
			}
			else
			{
				this.#2Xc.Text = null;
			}
			this.#6yc = false;
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0000C06C File Offset: 0x0000B06C
		public override Size GetPreferredSize(Size proposedSize)
		{
			Size preferredSize = base.GetPreferredSize(proposedSize);
			int num = this.#OSc.Padding.Left + this.#PSc.Margin.Left + this.#ZXc.Margin.Left + this.#ZXc.Width + this.#ZXc.Margin.Right + this.#0Xc.Margin.Left + this.#0Xc.Width + this.#0Xc.Margin.Right + this.#PSc.Margin.Right + this.#OSc.Padding.Right;
			if (num > preferredSize.Width)
			{
				preferredSize = new Size(num, preferredSize.Height);
			}
			return preferredSize;
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0000C154 File Offset: 0x0000B154
		protected override void OnRightToLeftChanged(EventArgs e)
		{
			base.OnRightToLeftChanged(e);
			if (base.ParentForm != null && base.ParentForm.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)
			{
				#TVc.#OVc(this.#PXc, this.#QXc);
				#TVc.#OVc(this.#VXc);
				#TVc.#OVc(this.#WXc);
				#TVc.#OVc(this.#PSc);
				#TVc.#OVc(this.#1Xc, this.#2Xc);
				return;
			}
			#TVc.#QVc(this.#1Xc, this.#2Xc);
			#TVc.#QVc(this.#PSc);
			#TVc.#QVc(this.#WXc);
			#TVc.#QVc(this.#VXc);
			#TVc.#QVc(this.#PXc, this.#QXc);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0000C210 File Offset: 0x0000B210
		protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
		{
			Size size = base.Size;
			this.MinimumSize = Size.Empty;
			base.ScaleControl(factor, specified);
			this.MinimumSize = new Size((int)Math.Round((double)((float)size.Width * factor.Width)), (int)Math.Round((double)((float)size.Height * factor.Height)));
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0000C270 File Offset: 0x0000B270
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (base.Parent == null)
			{
				this.OnFontChanged(e);
			}
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0000C288 File Offset: 0x0000B288
		private void #3Xc()
		{
			Cursor value = Cursor.Current;
			OleDbDataReader oleDbDataReader = null;
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				oleDbDataReader = OleDbEnumerator.GetEnumerator(Type.GetTypeFromCLSID(#qgc.#0Vc));
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				while (oleDbDataReader.Read())
				{
					int @int = oleDbDataReader.GetInt32(oleDbDataReader.GetOrdinal(#Nk.#Mk.#Lk(2482)));
					if (@int == 1 || @int == 3)
					{
						string key = oleDbDataReader[#Nk.#Mk.#Lk(2499)].ToString();
						string value2 = oleDbDataReader[#Nk.#Mk.#Lk(2776)].ToString();
						dictionary[key] = value2;
					}
				}
				Dictionary<string, string> dictionary2 = new Dictionary<string, string>(dictionary.Count);
				RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(#Nk.#Mk.#Lk(2520));
				using (registryKey)
				{
					foreach (KeyValuePair<string, string> keyValuePair in dictionary)
					{
						RegistryKey registryKey3 = registryKey.OpenSubKey(keyValuePair.Key + #Nk.#Mk.#Lk(2529));
						if (registryKey3 != null)
						{
							using (registryKey3)
							{
								string text = registryKey.OpenSubKey(keyValuePair.Key + #Nk.#Mk.#Lk(2529)).GetValue(null) as string;
								if (text != null && !text.Equals(#Nk.#Mk.#Lk(2805), StringComparison.OrdinalIgnoreCase) && !text.StartsWith(#Nk.#Mk.#Lk(2818), StringComparison.OrdinalIgnoreCase) && !text.Equals(#Nk.#Mk.#Lk(2831)))
								{
									dictionary2[text] = keyValuePair.Key;
								}
							}
						}
					}
				}
				foreach (KeyValuePair<string, string> keyValuePair2 in dictionary2)
				{
					this.#RXc.Items.Add(new OleDBConnectionUIControl.#e5c(keyValuePair2.Key, dictionary[keyValuePair2.Value]));
				}
			}
			finally
			{
				if (oleDbDataReader != null)
				{
					oleDbDataReader.Dispose();
				}
				Cursor.Current = value;
			}
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000C51C File Offset: 0x0000B51C
		private void #4Xc(object #sm, EventArgs #tm)
		{
			if (this.#RXc.SelectedItem is OleDBConnectionUIControl.#e5c)
			{
				if (!this.#6yc)
				{
					this.Properties[#Nk.#Mk.#Lk(2469)] = ((OleDBConnectionUIControl.#e5c)this.#RXc.SelectedItem).ProgId;
				}
				foreach (object obj in TypeDescriptor.GetProperties(this.Properties))
				{
					PropertyDescriptor propertyDescriptor = (PropertyDescriptor)obj;
					if (propertyDescriptor.Category.Equals(CategoryAttribute.Default.Category, StringComparison.CurrentCulture))
					{
						this.Properties.Remove(propertyDescriptor.DisplayName);
					}
				}
				this.#SXc.Enabled = true;
				this.#gXc.Enabled = true;
				this.#OSc.Enabled = true;
				this.#PSc.Enabled = true;
				this.#1Xc.Enabled = true;
				this.#2Xc.Enabled = true;
				this.#FTc.Enabled = false;
				this.#HTc.Enabled = false;
				this.#TXc.Enabled = false;
				this.#UXc.Enabled = false;
				this.#VXc.Enabled = false;
				this.#WXc.Enabled = false;
				this.#QSc.Enabled = false;
				this.#RSc.Enabled = false;
				this.#SSc.Enabled = false;
				this.#TSc.Enabled = false;
				this.#ZXc.Enabled = false;
				this.#0Xc.Enabled = false;
				this.#1Xc.Enabled = false;
				this.#2Xc.Enabled = false;
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this.Properties);
				PropertyDescriptor propertyDescriptor2;
				if ((propertyDescriptor2 = properties[#Nk.#Mk.#Lk(2670)]) != null && propertyDescriptor2.IsBrowsable)
				{
					this.#FTc.Enabled = true;
					this.#HTc.Enabled = true;
				}
				if ((propertyDescriptor2 = properties[#Nk.#Mk.#Lk(2729)]) != null && propertyDescriptor2.IsBrowsable)
				{
					this.#TXc.Enabled = true;
					this.#UXc.Enabled = true;
				}
				this.#gXc.Enabled = (this.#HTc.Enabled || this.#UXc.Enabled);
				if ((propertyDescriptor2 = properties[#Nk.#Mk.#Lk(2568)]) != null && propertyDescriptor2.IsBrowsable)
				{
					this.#VXc.Enabled = true;
				}
				if ((propertyDescriptor2 = properties[#Nk.#Mk.#Lk(263)]) != null && propertyDescriptor2.IsBrowsable)
				{
					this.#QSc.Enabled = true;
					this.#RSc.Enabled = true;
				}
				if ((propertyDescriptor2 = properties[#Nk.#Mk.#Lk(2742)]) != null && propertyDescriptor2.IsBrowsable)
				{
					this.#SSc.Enabled = true;
					this.#TSc.Enabled = true;
					this.#ZXc.Enabled = true;
				}
				if (this.#TSc.Enabled && (propertyDescriptor2 = properties[#Nk.#Mk.#Lk(2888)]) != null && propertyDescriptor2.IsBrowsable)
				{
					this.#0Xc.Enabled = true;
				}
				this.#PSc.Enabled = (this.#RSc.Enabled || this.#TSc.Enabled);
				this.#WXc.Enabled = this.#PSc.Enabled;
				this.#OSc.Enabled = (this.#VXc.Enabled || this.#WXc.Enabled);
				if ((propertyDescriptor2 = properties[#Nk.#Mk.#Lk(2755)]) != null && propertyDescriptor2.IsBrowsable)
				{
					this.#1Xc.Enabled = true;
					this.#2Xc.Enabled = true;
				}
			}
			else
			{
				if (!this.#6yc)
				{
					this.Properties[#Nk.#Mk.#Lk(2469)] = null;
				}
				this.#SXc.Enabled = false;
				this.#gXc.Enabled = false;
				this.#OSc.Enabled = false;
				this.#1Xc.Enabled = false;
				this.#2Xc.Enabled = false;
			}
			if (!this.#6yc)
			{
				this.LoadProperties();
			}
			this.#2Xc.Items.Clear();
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000C95C File Offset: 0x0000B95C
		private void #5Xc(object #sm, EventArgs #tm)
		{
			if (this.#RXc.Items.Count > 0)
			{
				int num = 0;
				using (Graphics graphics = Graphics.FromHwnd(this.#RXc.Handle))
				{
					foreach (object obj in this.#RXc.Items)
					{
						int width = TextRenderer.MeasureText(graphics, ((OleDBConnectionUIControl.#e5c)obj).Description, this.#RXc.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.WordBreak).Width;
						if (width > num)
						{
							num = width;
						}
					}
				}
				this.#RXc.DropDownWidth = num + 3;
				if (this.#RXc.Items.Count > this.#RXc.MaxDropDownItems)
				{
					this.#RXc.DropDownWidth += SystemInformation.VerticalScrollBarWidth;
					return;
				}
			}
			else
			{
				this.#RXc.DropDownWidth = this.#RXc.Width;
			}
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000CA8C File Offset: 0x0000BA8C
		private void #6Xc(object #sm, EventArgs #tm)
		{
			try
			{
				Type typeFromCLSID = Type.GetTypeFromCLSID(#qgc.#ZVc);
				#qgc.#W4c #W4c = Activator.CreateInstance(typeFromCLSID) as #qgc.#W4c;
				object #P4c = null;
				#W4c.#K4c(null, 1, this.Properties.ToFullString(), ref #qgc.#YVc, ref #P4c);
				#qgc.#34c #34c = (#qgc.#34c)#W4c;
				#34c.#X4c(null, base.ParentForm.Handle, 18, 0, IntPtr.Zero, null, ref #qgc.#YVc, ref #P4c);
				string s = null;
				#W4c.#O4c(#P4c, true, out s);
				this.Properties.Parse(s);
				this.LoadProperties();
			}
			catch (Exception ex)
			{
				COMException ex2 = ex as COMException;
				if (ex2 == null || ex2.ErrorCode != -2147217842)
				{
					IUIService iuiservice = this.GetService(typeof(IUIService)) as IUIService;
					if (iuiservice != null)
					{
						iuiservice.ShowError(ex);
					}
					else
					{
						#jYc.Show(null, ex.Message, MessageBoxIcon.Exclamation);
					}
				}
			}
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000CB7C File Offset: 0x0000BB7C
		private void #7Xc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(241)] = ((this.#HTc.Text.Trim().Length > 0) ? this.#HTc.Text.Trim() : null);
			}
			this.#2Xc.Items.Clear();
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000CBE4 File Offset: 0x0000BBE4
		private void #8Xc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(2729)] = this.#UXc.Text;
			}
			this.#2Xc.Items.Clear();
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000CC20 File Offset: 0x0000BC20
		private void #9Xc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				if (this.#VXc.Checked)
				{
					this.Properties[#Nk.#Mk.#Lk(2568)] = #Nk.#Mk.#Lk(2597);
					this.Properties.Reset(#Nk.#Mk.#Lk(263));
					this.Properties.Reset(#Nk.#Mk.#Lk(2742));
					this.Properties.Reset(#Nk.#Mk.#Lk(212));
				}
				else
				{
					this.Properties.Reset(#Nk.#Mk.#Lk(2568));
					this.#XSc(#sm, #tm);
					this.#YSc(#sm, #tm);
					this.#aYc(#sm, #tm);
					this.#bYc(#sm, #tm);
				}
			}
			this.#PSc.Enabled = !this.#VXc.Checked;
			this.#2Xc.Items.Clear();
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000CD04 File Offset: 0x0000BD04
		private void #XSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(263)] = ((this.#RSc.Text.Trim().Length > 0) ? this.#RSc.Text.Trim() : null);
			}
			this.#2Xc.Items.Clear();
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000CD6C File Offset: 0x0000BD6C
		private void #YSc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(2742)] = ((this.#TSc.Text.Length > 0) ? this.#TSc.Text : null);
				if (this.#TSc.Text.Length == 0)
				{
					this.Properties.Remove(#Nk.#Mk.#Lk(2742));
				}
				this.#TSc.Text = this.#TSc.Text;
			}
			this.#2Xc.Items.Clear();
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000CE04 File Offset: 0x0000BE04
		private void #aYc(object #sm, EventArgs #tm)
		{
			if (this.#ZXc.Checked)
			{
				if (!this.#6yc)
				{
					this.Properties[#Nk.#Mk.#Lk(2742)] = string.Empty;
				}
				this.#SSc.Enabled = false;
				this.#TSc.Enabled = false;
				return;
			}
			if (!this.#6yc)
			{
				this.#YSc(#sm, #tm);
			}
			this.#SSc.Enabled = true;
			this.#TSc.Enabled = true;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000CE84 File Offset: 0x0000BE84
		private void #bYc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(212)] = this.#0Xc.Checked;
			}
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0000CEB4 File Offset: 0x0000BEB4
		private void #rXc(object #sm, KeyEventArgs #tm)
		{
			if (#tm.KeyCode == Keys.Down)
			{
				this.#dYc(#sm, #tm);
			}
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000CEC8 File Offset: 0x0000BEC8
		private void #cYc(object #sm, EventArgs #tm)
		{
			if (!this.#6yc)
			{
				this.Properties[#Nk.#Mk.#Lk(2755)] = ((this.#2Xc.Text.Trim().Length > 0) ? this.#2Xc.Text.Trim() : null);
				if (this.#2Xc.Items.Count == 0 && this.#OXc == null)
				{
					this.#OXc = new Thread(new ThreadStart(this.#dYc));
					this.#OXc.Start();
				}
			}
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000CF5C File Offset: 0x0000BF5C
		private void #dYc(object #sm, EventArgs #tm)
		{
			if (this.#2Xc.Items.Count == 0)
			{
				Cursor value = Cursor.Current;
				Cursor.Current = Cursors.WaitCursor;
				try
				{
					if (this.#OXc == null || this.#OXc.ThreadState == ThreadState.Stopped)
					{
						this.#dYc();
					}
					else if (this.#OXc.ThreadState == ThreadState.Running)
					{
						this.#OXc.Join();
						this.#eYc();
					}
				}
				finally
				{
					Cursor.Current = value;
				}
			}
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000CFE4 File Offset: 0x0000BFE4
		private void #0Sc(object #sm, EventArgs #tm)
		{
			Control control = #sm as Control;
			control.Text = control.Text.Trim();
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0000D00C File Offset: 0x0000C00C
		private void #dYc()
		{
			DataTable dataTable = null;
			OleDbConnection oleDbConnection = null;
			try
			{
				OleDbConnectionStringBuilder oleDbConnectionStringBuilder = new OleDbConnectionStringBuilder(this.Properties.ToFullString());
				oleDbConnectionStringBuilder.Remove(#Nk.#Mk.#Lk(2755));
				oleDbConnection = new OleDbConnection(oleDbConnectionStringBuilder.ConnectionString);
				oleDbConnection.Open();
				dataTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Catalogs, null);
			}
			catch
			{
				dataTable = new DataTable();
				dataTable.Locale = CultureInfo.InvariantCulture;
			}
			finally
			{
				if (oleDbConnection != null)
				{
					oleDbConnection.Dispose();
				}
			}
			this.#NXc = new object[dataTable.Rows.Count];
			for (int i = 0; i < this.#NXc.Length; i++)
			{
				this.#NXc[i] = dataTable.Rows[i][#Nk.#Mk.#Lk(2917)];
			}
			if (Thread.CurrentThread == this.#fXc)
			{
				this.#eYc();
				return;
			}
			if (base.IsHandleCreated)
			{
				base.BeginInvoke(new ThreadStart(this.#eYc));
			}
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0000D118 File Offset: 0x0000C118
		private void #eYc()
		{
			if (this.#2Xc.Items.Count == 0)
			{
				if (this.#NXc.Length != 0)
				{
					this.#2Xc.Items.AddRange(this.#NXc);
				}
				else
				{
					this.#2Xc.Items.Add(string.Empty);
				}
			}
			this.#OXc = null;
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000207 RID: 519 RVA: 0x0000D178 File Offset: 0x0000C178
		private IDataConnectionProperties Properties
		{
			get
			{
				return this.#KSc;
			}
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0000D180 File Offset: 0x0000C180
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.#sS != null)
			{
				this.#sS.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0000D1A0 File Offset: 0x0000C1A0
		private void #lq()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(OleDBConnectionUIControl));
			this.#PXc = new Label();
			this.#QXc = new TableLayoutPanel();
			this.#RXc = new ComboBox();
			this.#SXc = new Button();
			this.#gXc = new GroupBox();
			this.#GTc = new TableLayoutPanel();
			this.#FTc = new Label();
			this.#HTc = new TextBox();
			this.#TXc = new Label();
			this.#UXc = new TextBox();
			this.#OSc = new GroupBox();
			this.#PSc = new TableLayoutPanel();
			this.#XXc = new TableLayoutPanel();
			this.#QSc = new Label();
			this.#RSc = new TextBox();
			this.#SSc = new Label();
			this.#TSc = new TextBox();
			this.#YXc = new TableLayoutPanel();
			this.#ZXc = new CheckBox();
			this.#0Xc = new CheckBox();
			this.#WXc = new RadioButton();
			this.#VXc = new RadioButton();
			this.#1Xc = new Label();
			this.#2Xc = new ComboBox();
			this.#QXc.SuspendLayout();
			this.#gXc.SuspendLayout();
			this.#GTc.SuspendLayout();
			this.#OSc.SuspendLayout();
			this.#PSc.SuspendLayout();
			this.#XXc.SuspendLayout();
			this.#YXc.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.#PXc, #Nk.#Mk.#Lk(2934));
			this.#PXc.FlatStyle = FlatStyle.System;
			this.#PXc.Name = #Nk.#Mk.#Lk(2934);
			componentResourceManager.ApplyResources(this.#QXc, #Nk.#Mk.#Lk(2955));
			this.#QXc.Controls.Add(this.#RXc, 0, 0);
			this.#QXc.Controls.Add(this.#SXc, 1, -1);
			this.#QXc.Name = #Nk.#Mk.#Lk(2955);
			componentResourceManager.ApplyResources(this.#RXc, #Nk.#Mk.#Lk(2988));
			this.#RXc.DropDownStyle = ComboBoxStyle.DropDownList;
			this.#RXc.FormattingEnabled = true;
			this.#RXc.Name = #Nk.#Mk.#Lk(2988);
			this.#RXc.Sorted = true;
			this.#RXc.SelectedIndexChanged += this.#4Xc;
			this.#RXc.DropDown += this.#5Xc;
			componentResourceManager.ApplyResources(this.#SXc, #Nk.#Mk.#Lk(3013));
			this.#SXc.MinimumSize = new Size(83, 23);
			this.#SXc.Name = #Nk.#Mk.#Lk(3013);
			this.#SXc.Click += this.#6Xc;
			componentResourceManager.ApplyResources(this.#gXc, #Nk.#Mk.#Lk(2118));
			this.#gXc.Controls.Add(this.#GTc);
			this.#gXc.FlatStyle = FlatStyle.System;
			this.#gXc.Name = #Nk.#Mk.#Lk(2118);
			this.#gXc.TabStop = false;
			componentResourceManager.ApplyResources(this.#GTc, #Nk.#Mk.#Lk(1019));
			this.#GTc.Controls.Add(this.#FTc, 0, 0);
			this.#GTc.Controls.Add(this.#HTc, 1, 0);
			this.#GTc.Controls.Add(this.#TXc, 0, 1);
			this.#GTc.Controls.Add(this.#UXc, 1, 1);
			this.#GTc.Name = #Nk.#Mk.#Lk(1019);
			componentResourceManager.ApplyResources(this.#FTc, #Nk.#Mk.#Lk(981));
			this.#FTc.FlatStyle = FlatStyle.System;
			this.#FTc.Name = #Nk.#Mk.#Lk(981);
			componentResourceManager.ApplyResources(this.#HTc, #Nk.#Mk.#Lk(1056));
			this.#HTc.Name = #Nk.#Mk.#Lk(1056);
			this.#HTc.Leave += this.#0Sc;
			this.#HTc.TextChanged += this.#7Xc;
			componentResourceManager.ApplyResources(this.#TXc, #Nk.#Mk.#Lk(3034));
			this.#TXc.FlatStyle = FlatStyle.System;
			this.#TXc.Name = #Nk.#Mk.#Lk(3034);
			componentResourceManager.ApplyResources(this.#UXc, #Nk.#Mk.#Lk(3055));
			this.#UXc.Name = #Nk.#Mk.#Lk(3055);
			this.#UXc.Leave += this.#0Sc;
			this.#UXc.TextChanged += this.#8Xc;
			componentResourceManager.ApplyResources(this.#OSc, #Nk.#Mk.#Lk(435));
			this.#OSc.Controls.Add(this.#PSc);
			this.#OSc.Controls.Add(this.#WXc);
			this.#OSc.Controls.Add(this.#VXc);
			this.#OSc.FlatStyle = FlatStyle.System;
			this.#OSc.Name = #Nk.#Mk.#Lk(435);
			this.#OSc.TabStop = false;
			componentResourceManager.ApplyResources(this.#PSc, #Nk.#Mk.#Lk(456));
			this.#PSc.Controls.Add(this.#XXc, 0, 0);
			this.#PSc.Controls.Add(this.#YXc, 0, 1);
			this.#PSc.Name = #Nk.#Mk.#Lk(456);
			componentResourceManager.ApplyResources(this.#XXc, #Nk.#Mk.#Lk(3076));
			this.#XXc.Controls.Add(this.#QSc, 0, 0);
			this.#XXc.Controls.Add(this.#RSc, 1, 0);
			this.#XXc.Controls.Add(this.#SSc, 0, 1);
			this.#XXc.Controls.Add(this.#TSc, 1, 1);
			this.#XXc.Name = #Nk.#Mk.#Lk(3076);
			componentResourceManager.ApplyResources(this.#QSc, #Nk.#Mk.#Lk(485));
			this.#QSc.FlatStyle = FlatStyle.System;
			this.#QSc.Name = #Nk.#Mk.#Lk(485);
			componentResourceManager.ApplyResources(this.#RSc, #Nk.#Mk.#Lk(506));
			this.#RSc.Name = #Nk.#Mk.#Lk(506);
			this.#RSc.Leave += this.#0Sc;
			this.#RSc.TextChanged += this.#XSc;
			componentResourceManager.ApplyResources(this.#SSc, #Nk.#Mk.#Lk(527));
			this.#SSc.FlatStyle = FlatStyle.System;
			this.#SSc.Name = #Nk.#Mk.#Lk(527);
			componentResourceManager.ApplyResources(this.#TSc, #Nk.#Mk.#Lk(548));
			this.#TSc.Name = #Nk.#Mk.#Lk(548);
			this.#TSc.UseSystemPasswordChar = true;
			this.#TSc.TextChanged += this.#YSc;
			componentResourceManager.ApplyResources(this.#YXc, #Nk.#Mk.#Lk(3109));
			this.#YXc.Controls.Add(this.#ZXc, 0, 0);
			this.#YXc.Controls.Add(this.#0Xc, 1, 0);
			this.#YXc.Name = #Nk.#Mk.#Lk(3109);
			componentResourceManager.ApplyResources(this.#ZXc, #Nk.#Mk.#Lk(3146));
			this.#ZXc.Name = #Nk.#Mk.#Lk(3146);
			this.#ZXc.CheckedChanged += this.#aYc;
			componentResourceManager.ApplyResources(this.#0Xc, #Nk.#Mk.#Lk(3175));
			this.#0Xc.Name = #Nk.#Mk.#Lk(3175);
			this.#0Xc.CheckedChanged += this.#bYc;
			componentResourceManager.ApplyResources(this.#WXc, #Nk.#Mk.#Lk(3212));
			this.#WXc.Name = #Nk.#Mk.#Lk(3212);
			this.#WXc.CheckedChanged += this.#9Xc;
			componentResourceManager.ApplyResources(this.#VXc, #Nk.#Mk.#Lk(3249));
			this.#VXc.Name = #Nk.#Mk.#Lk(3249);
			this.#VXc.CheckedChanged += this.#9Xc;
			componentResourceManager.ApplyResources(this.#1Xc, #Nk.#Mk.#Lk(3290));
			this.#1Xc.FlatStyle = FlatStyle.System;
			this.#1Xc.Name = #Nk.#Mk.#Lk(3290);
			componentResourceManager.ApplyResources(this.#2Xc, #Nk.#Mk.#Lk(3319));
			this.#2Xc.AutoCompleteMode = AutoCompleteMode.Append;
			this.#2Xc.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.#2Xc.FormattingEnabled = true;
			this.#2Xc.Name = #Nk.#Mk.#Lk(3319);
			this.#2Xc.Leave += this.#0Sc;
			this.#2Xc.TextChanged += this.#cYc;
			this.#2Xc.KeyDown += this.#rXc;
			this.#2Xc.DropDown += this.#dYc;
			componentResourceManager.ApplyResources(this, #Nk.#Mk.#Lk(598));
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.#2Xc);
			base.Controls.Add(this.#1Xc);
			base.Controls.Add(this.#OSc);
			base.Controls.Add(this.#gXc);
			base.Controls.Add(this.#QXc);
			base.Controls.Add(this.#PXc);
			this.MinimumSize = new Size(350, 323);
			base.Name = #Nk.#Mk.#Lk(3352);
			this.#QXc.ResumeLayout(false);
			this.#QXc.PerformLayout();
			this.#gXc.ResumeLayout(false);
			this.#gXc.PerformLayout();
			this.#GTc.ResumeLayout(false);
			this.#GTc.PerformLayout();
			this.#OSc.ResumeLayout(false);
			this.#OSc.PerformLayout();
			this.#PSc.ResumeLayout(false);
			this.#PSc.PerformLayout();
			this.#XXc.ResumeLayout(false);
			this.#XXc.PerformLayout();
			this.#YXc.ResumeLayout(false);
			this.#YXc.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000E4 RID: 228
		private bool #6yc;

		// Token: 0x040000E5 RID: 229
		private object[] #NXc;

		// Token: 0x040000E6 RID: 230
		private Thread #fXc;

		// Token: 0x040000E7 RID: 231
		private Thread #OXc;

		// Token: 0x040000E8 RID: 232
		private IDataConnectionProperties #KSc;

		// Token: 0x040000E9 RID: 233
		private IContainer #sS;

		// Token: 0x040000EA RID: 234
		private Label #PXc;

		// Token: 0x040000EB RID: 235
		private TableLayoutPanel #QXc;

		// Token: 0x040000EC RID: 236
		private ComboBox #RXc;

		// Token: 0x040000ED RID: 237
		private Button #SXc;

		// Token: 0x040000EE RID: 238
		private GroupBox #gXc;

		// Token: 0x040000EF RID: 239
		private TableLayoutPanel #GTc;

		// Token: 0x040000F0 RID: 240
		private Label #FTc;

		// Token: 0x040000F1 RID: 241
		private TextBox #HTc;

		// Token: 0x040000F2 RID: 242
		private Label #TXc;

		// Token: 0x040000F3 RID: 243
		private TextBox #UXc;

		// Token: 0x040000F4 RID: 244
		private GroupBox #OSc;

		// Token: 0x040000F5 RID: 245
		private RadioButton #VXc;

		// Token: 0x040000F6 RID: 246
		private RadioButton #WXc;

		// Token: 0x040000F7 RID: 247
		private TableLayoutPanel #PSc;

		// Token: 0x040000F8 RID: 248
		private TableLayoutPanel #XXc;

		// Token: 0x040000F9 RID: 249
		private Label #QSc;

		// Token: 0x040000FA RID: 250
		private TextBox #RSc;

		// Token: 0x040000FB RID: 251
		private Label #SSc;

		// Token: 0x040000FC RID: 252
		private TextBox #TSc;

		// Token: 0x040000FD RID: 253
		private TableLayoutPanel #YXc;

		// Token: 0x040000FE RID: 254
		private CheckBox #ZXc;

		// Token: 0x040000FF RID: 255
		private CheckBox #0Xc;

		// Token: 0x04000100 RID: 256
		private Label #1Xc;

		// Token: 0x04000101 RID: 257
		private ComboBox #2Xc;

		// Token: 0x0200002D RID: 45
		private struct #e5c
		{
			// Token: 0x0600020A RID: 522 RVA: 0x0000DC9C File Offset: 0x0000CC9C
			public #e5c(string progId, string description)
			{
				this.#c5c = progId;
				this.#Wq = description;
			}

			// Token: 0x1700005B RID: 91
			// (get) Token: 0x0600020B RID: 523 RVA: 0x0000DCAC File Offset: 0x0000CCAC
			public string ProgId
			{
				get
				{
					return this.#c5c;
				}
			}

			// Token: 0x1700005C RID: 92
			// (get) Token: 0x0600020C RID: 524 RVA: 0x0000DCB4 File Offset: 0x0000CCB4
			public string Description
			{
				get
				{
					return this.#Wq;
				}
			}

			// Token: 0x0600020D RID: 525 RVA: 0x0000DCBC File Offset: 0x0000CCBC
			public override string ToString()
			{
				return this.#Wq;
			}

			// Token: 0x04000102 RID: 258
			private string #c5c;

			// Token: 0x04000103 RID: 259
			private string #Wq;
		}
	}
}
