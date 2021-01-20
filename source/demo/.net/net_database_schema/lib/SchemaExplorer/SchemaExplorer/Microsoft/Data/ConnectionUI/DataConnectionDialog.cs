using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using #cTc;
using #Nk;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x0200000C RID: 12
	public partial class DataConnectionDialog : Form
	{
		// Token: 0x06000077 RID: 119 RVA: 0x00004338 File Offset: 0x00003338
		public DataConnectionDialog()
		{
			this.#lq();
			this.#HTc.Width = 0;
			this.#sS.Add(new #5Zc(this));
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(#nUc));
			this.#tTc = componentResourceManager.GetString(#Nk.#Mk.#Lk(924));
			this.#vTc = componentResourceManager.GetString(#Nk.#Mk.#Lk(941));
			this.#wTc = #cTc.#Mk.DataConnectionDialog_ChangeDataSourceTitle;
			this.#yTc = new DataConnectionDialog.#C4c(this);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00004414 File Offset: 0x00003414
		public static DialogResult Show(DataConnectionDialog dialog)
		{
			return DataConnectionDialog.Show(dialog, null);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00004420 File Offset: 0x00003420
		public static DialogResult Show(DataConnectionDialog dialog, IWin32Window owner)
		{
			if (dialog == null)
			{
				throw new ArgumentNullException(#Nk.#Mk.#Lk(962));
			}
			if (dialog.DataSources.Count == 0)
			{
				throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_NoDataSourcesAvailable);
			}
			foreach (DataSource dataSource in dialog.DataSources)
			{
				if (dataSource.Providers.Count == 0)
				{
					throw new InvalidOperationException(string.Format(#cTc.#Mk.DataConnectionDialog_NoDataProvidersForDataSource + dataSource.DisplayName.Replace(#Nk.#Mk.#Lk(971), #Nk.#Mk.#Lk(976)), Array.Empty<object>()));
				}
			}
			Application.ThreadException += dialog.#5Tc;
			dialog.#qTc = true;
			DialogResult result;
			try
			{
				if (dialog.SelectedDataSource == null || dialog.SelectedDataProvider == null)
				{
					#nUc #nUc = new #nUc(dialog);
					#nUc.Title = dialog.ChooseDataSourceTitle;
					#nUc.HeaderLabel = dialog.ChooseDataSourceHeaderLabel;
					(#nUc.AcceptButton as Button).Text = dialog.ChooseDataSourceAcceptText;
					if (dialog.Container != null)
					{
						dialog.Container.Add(#nUc);
					}
					try
					{
						if (owner == null)
						{
							#nUc.StartPosition = FormStartPosition.CenterScreen;
						}
						#nUc.ShowDialog(owner);
						if (dialog.SelectedDataSource == null || dialog.SelectedDataProvider == null)
						{
							return DialogResult.Cancel;
						}
						goto IL_15C;
					}
					finally
					{
						if (dialog.Container != null)
						{
							dialog.Container.Remove(#nUc);
						}
						#nUc.Dispose();
					}
				}
				dialog.#CTc = false;
				IL_15C:
				if (owner == null)
				{
					dialog.StartPosition = FormStartPosition.CenterScreen;
				}
				DialogResult dialogResult;
				for (;;)
				{
					dialogResult = dialog.ShowDialog(owner);
					if (dialogResult == DialogResult.Ignore)
					{
						#nUc #nUc2 = new #nUc(dialog);
						#nUc2.Title = dialog.ChangeDataSourceTitle;
						#nUc2.HeaderLabel = dialog.ChangeDataSourceHeaderLabel;
						if (dialog.Container != null)
						{
							dialog.Container.Add(#nUc2);
						}
						try
						{
							if (owner == null)
							{
								#nUc2.StartPosition = FormStartPosition.CenterScreen;
							}
							dialogResult = #nUc2.ShowDialog(owner);
							continue;
						}
						finally
						{
							if (dialog.Container != null)
							{
								dialog.Container.Remove(#nUc2);
							}
							#nUc2.Dispose();
						}
						break;
					}
					break;
				}
				result = dialogResult;
			}
			finally
			{
				dialog.#qTc = false;
				Application.ThreadException -= dialog.#5Tc;
			}
			return result;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00004690 File Offset: 0x00003690
		// (set) Token: 0x0600007B RID: 123 RVA: 0x00004698 File Offset: 0x00003698
		public string Title
		{
			get
			{
				return this.Text;
			}
			set
			{
				this.Text = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600007C RID: 124 RVA: 0x000046A4 File Offset: 0x000036A4
		// (set) Token: 0x0600007D RID: 125 RVA: 0x000046C0 File Offset: 0x000036C0
		public string HeaderLabel
		{
			get
			{
				if (this.#rTc == null)
				{
					return string.Empty;
				}
				return this.#rTc.Text;
			}
			set
			{
				if (this.#qTc)
				{
					throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_CannotModifyState);
				}
				if (this.#rTc == null && (value == null || value.Length == 0))
				{
					return;
				}
				if (this.#rTc != null && value == this.#rTc.Text)
				{
					return;
				}
				if (value != null && value.Length > 0)
				{
					if (this.#rTc == null)
					{
						this.#rTc = new Label();
						this.#rTc.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
						this.#rTc.FlatStyle = FlatStyle.System;
						this.#rTc.Location = new Point(12, 12);
						this.#rTc.Margin = new Padding(3);
						this.#rTc.Name = #Nk.#Mk.#Lk(981);
						this.#rTc.Width = this.#GTc.Width;
						this.#rTc.TabIndex = 100;
						base.Controls.Add(this.#rTc);
					}
					this.#rTc.Text = value;
					this.MinimumSize = Size.Empty;
					this.#rTc.Height = #TVc.#KVc(this.#rTc);
					int num = this.#rTc.Bottom + this.#rTc.Margin.Bottom + this.#FTc.Margin.Top - this.#FTc.Top;
					this.#KTc.Anchor &= ~AnchorStyles.Bottom;
					base.Height += num;
					this.#KTc.Anchor |= AnchorStyles.Bottom;
					this.#KTc.Top += num;
					this.#GTc.Top += num;
					this.#FTc.Top += num;
					this.MinimumSize = base.Size;
					return;
				}
				if (this.#rTc != null)
				{
					int height = this.#rTc.Height;
					try
					{
						base.Controls.Remove(this.#rTc);
					}
					finally
					{
						this.#rTc.Dispose();
						this.#rTc = null;
					}
					this.MinimumSize = Size.Empty;
					this.#FTc.Top -= height;
					this.#GTc.Top -= height;
					this.#KTc.Top -= height;
					this.#KTc.Anchor &= ~AnchorStyles.Bottom;
					base.Height -= height;
					this.#KTc.Anchor |= AnchorStyles.Bottom;
					this.MinimumSize = base.Size;
				}
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600007E RID: 126 RVA: 0x0000497C File Offset: 0x0000397C
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00004984 File Offset: 0x00003984
		public bool TranslateHelpButton
		{
			get
			{
				return this.#sTc;
			}
			set
			{
				this.#sTc = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00004990 File Offset: 0x00003990
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00004998 File Offset: 0x00003998
		public string ChooseDataSourceTitle
		{
			get
			{
				return this.#tTc;
			}
			set
			{
				if (this.#qTc)
				{
					throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_CannotModifyState);
				}
				if (value == null)
				{
					value = string.Empty;
				}
				if (value == this.#tTc)
				{
					return;
				}
				this.#tTc = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000082 RID: 130 RVA: 0x000049D0 File Offset: 0x000039D0
		// (set) Token: 0x06000083 RID: 131 RVA: 0x000049D8 File Offset: 0x000039D8
		public string ChooseDataSourceHeaderLabel
		{
			get
			{
				return this.#uTc;
			}
			set
			{
				if (this.#qTc)
				{
					throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_CannotModifyState);
				}
				if (value == null)
				{
					value = string.Empty;
				}
				if (value == this.#uTc)
				{
					return;
				}
				this.#uTc = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00004A10 File Offset: 0x00003A10
		// (set) Token: 0x06000085 RID: 133 RVA: 0x00004A18 File Offset: 0x00003A18
		public string ChooseDataSourceAcceptText
		{
			get
			{
				return this.#vTc;
			}
			set
			{
				if (this.#qTc)
				{
					throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_CannotModifyState);
				}
				if (value == null)
				{
					value = string.Empty;
				}
				if (value == this.#vTc)
				{
					return;
				}
				this.#vTc = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00004A50 File Offset: 0x00003A50
		// (set) Token: 0x06000087 RID: 135 RVA: 0x00004A58 File Offset: 0x00003A58
		public string ChangeDataSourceTitle
		{
			get
			{
				return this.#wTc;
			}
			set
			{
				if (this.#qTc)
				{
					throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_CannotModifyState);
				}
				if (value == null)
				{
					value = string.Empty;
				}
				if (value == this.#wTc)
				{
					return;
				}
				this.#wTc = value;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00004A90 File Offset: 0x00003A90
		// (set) Token: 0x06000089 RID: 137 RVA: 0x00004A98 File Offset: 0x00003A98
		public string ChangeDataSourceHeaderLabel
		{
			get
			{
				return this.#xTc;
			}
			set
			{
				if (this.#qTc)
				{
					throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_CannotModifyState);
				}
				if (value == null)
				{
					value = string.Empty;
				}
				if (value == this.#xTc)
				{
					return;
				}
				this.#xTc = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00004AD0 File Offset: 0x00003AD0
		public ICollection<DataSource> DataSources
		{
			get
			{
				return this.#yTc;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600008B RID: 139 RVA: 0x00004AD8 File Offset: 0x00003AD8
		public DataSource UnspecifiedDataSource
		{
			get
			{
				return this.#zTc;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600008C RID: 140 RVA: 0x00004AE0 File Offset: 0x00003AE0
		// (set) Token: 0x0600008D RID: 141 RVA: 0x00004B30 File Offset: 0x00003B30
		public DataSource SelectedDataSource
		{
			get
			{
				if (this.#yTc == null)
				{
					return null;
				}
				int count = this.#yTc.Count;
				if (count == 0)
				{
					return null;
				}
				if (count != 1)
				{
					return this.#ATc;
				}
				IEnumerator<DataSource> enumerator = this.#yTc.GetEnumerator();
				enumerator.MoveNext();
				return enumerator.Current;
			}
			set
			{
				if (this.SelectedDataSource != value)
				{
					if (this.#qTc)
					{
						throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_CannotModifyState);
					}
					this.#UTc(value, false);
				}
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00004B58 File Offset: 0x00003B58
		// (set) Token: 0x0600008F RID: 143 RVA: 0x00004B68 File Offset: 0x00003B68
		public DataProvider SelectedDataProvider
		{
			get
			{
				return this.GetSelectedDataProvider(this.SelectedDataSource);
			}
			set
			{
				if (this.SelectedDataProvider != value)
				{
					if (this.SelectedDataSource == null)
					{
						throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_NoDataSourceSelected);
					}
					this.SetSelectedDataProvider(this.SelectedDataSource, value);
				}
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00004B94 File Offset: 0x00003B94
		public DataProvider GetSelectedDataProvider(DataSource dataSource)
		{
			if (dataSource == null)
			{
				return null;
			}
			int count = dataSource.Providers.Count;
			if (count == 0)
			{
				return null;
			}
			if (count == 1)
			{
				IEnumerator<DataProvider> enumerator = dataSource.Providers.GetEnumerator();
				enumerator.MoveNext();
				return enumerator.Current;
			}
			if (!this.#BTc.ContainsKey(dataSource))
			{
				return dataSource.DefaultProvider;
			}
			return this.#BTc[dataSource];
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004BF8 File Offset: 0x00003BF8
		public void SetSelectedDataProvider(DataSource dataSource, DataProvider dataProvider)
		{
			if (this.GetSelectedDataProvider(dataSource) != dataProvider)
			{
				if (dataSource == null)
				{
					throw new ArgumentNullException(#Nk.#Mk.#Lk(1002));
				}
				if (this.#qTc)
				{
					throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_CannotModifyState);
				}
				this.SetSelectedDataProvider(dataSource, dataProvider, false);
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00004C34 File Offset: 0x00003C34
		// (set) Token: 0x06000093 RID: 147 RVA: 0x00004C3C File Offset: 0x00003C3C
		public bool SaveSelection
		{
			get
			{
				return this.#CTc;
			}
			set
			{
				this.#CTc = value;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00004C48 File Offset: 0x00003C48
		public string DisplayConnectionString
		{
			get
			{
				string text = null;
				if (this.ConnectionProperties != null)
				{
					try
					{
						text = this.ConnectionProperties.ToDisplayString();
					}
					catch
					{
					}
				}
				if (text == null)
				{
					return string.Empty;
				}
				return text;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00004C8C File Offset: 0x00003C8C
		// (set) Token: 0x06000096 RID: 150 RVA: 0x00004CD0 File Offset: 0x00003CD0
		public string ConnectionString
		{
			get
			{
				string text = null;
				if (this.ConnectionProperties != null)
				{
					try
					{
						text = this.ConnectionProperties.ToString();
					}
					catch
					{
					}
				}
				if (text == null)
				{
					return string.Empty;
				}
				return text;
			}
			set
			{
				if (this.#qTc)
				{
					throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_CannotModifyState);
				}
				if (this.SelectedDataProvider == null)
				{
					throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_NoDataProviderSelected);
				}
				if (this.ConnectionProperties != null)
				{
					this.ConnectionProperties.Parse(value);
				}
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00004D0C File Offset: 0x00003D0C
		// (set) Token: 0x06000098 RID: 152 RVA: 0x00004D1C File Offset: 0x00003D1C
		public string AcceptButtonText
		{
			get
			{
				return this.#OTc.Text;
			}
			set
			{
				this.#OTc.Text = value;
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000099 RID: 153 RVA: 0x00004D2C File Offset: 0x00003D2C
		// (remove) Token: 0x0600009A RID: 154 RVA: 0x00004D64 File Offset: 0x00003D64
		public event EventHandler VerifySettings
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#mTc;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#mTc, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#mTc;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#mTc, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600009B RID: 155 RVA: 0x00004D9C File Offset: 0x00003D9C
		// (remove) Token: 0x0600009C RID: 156 RVA: 0x00004DD4 File Offset: 0x00003DD4
		public event EventHandler<ContextHelpEventArgs> ContextHelpRequested
		{
			[CompilerGenerated]
			add
			{
				EventHandler<ContextHelpEventArgs> eventHandler = this.#nTc;
				EventHandler<ContextHelpEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<ContextHelpEventArgs> value2 = (EventHandler<ContextHelpEventArgs>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<ContextHelpEventArgs>>(ref this.#nTc, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<ContextHelpEventArgs> eventHandler = this.#nTc;
				EventHandler<ContextHelpEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<ContextHelpEventArgs> value2 = (EventHandler<ContextHelpEventArgs>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<ContextHelpEventArgs>>(ref this.#nTc, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600009D RID: 157 RVA: 0x00004E0C File Offset: 0x00003E0C
		// (remove) Token: 0x0600009E RID: 158 RVA: 0x00004E44 File Offset: 0x00003E44
		public event ThreadExceptionEventHandler DialogException
		{
			[CompilerGenerated]
			add
			{
				ThreadExceptionEventHandler threadExceptionEventHandler = this.#oTc;
				ThreadExceptionEventHandler threadExceptionEventHandler2;
				do
				{
					threadExceptionEventHandler2 = threadExceptionEventHandler;
					ThreadExceptionEventHandler value2 = (ThreadExceptionEventHandler)Delegate.Combine(threadExceptionEventHandler2, value);
					threadExceptionEventHandler = Interlocked.CompareExchange<ThreadExceptionEventHandler>(ref this.#oTc, value2, threadExceptionEventHandler2);
				}
				while (threadExceptionEventHandler != threadExceptionEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ThreadExceptionEventHandler threadExceptionEventHandler = this.#oTc;
				ThreadExceptionEventHandler threadExceptionEventHandler2;
				do
				{
					threadExceptionEventHandler2 = threadExceptionEventHandler;
					ThreadExceptionEventHandler value2 = (ThreadExceptionEventHandler)Delegate.Remove(threadExceptionEventHandler2, value);
					threadExceptionEventHandler = Interlocked.CompareExchange<ThreadExceptionEventHandler>(ref this.#oTc, value2, threadExceptionEventHandler2);
				}
				while (threadExceptionEventHandler != threadExceptionEventHandler2);
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00004E7C File Offset: 0x00003E7C
		internal UserControl ConnectionUIControl
		{
			get
			{
				if (this.SelectedDataProvider == null)
				{
					return null;
				}
				if (!this.#DTc.ContainsKey(this.SelectedDataSource))
				{
					this.#DTc[this.SelectedDataSource] = new Dictionary<DataProvider, IDataConnectionUIControl>();
				}
				if (!this.#DTc[this.SelectedDataSource].ContainsKey(this.SelectedDataProvider))
				{
					IDataConnectionUIControl dataConnectionUIControl = null;
					UserControl userControl = null;
					try
					{
						if (this.SelectedDataSource == this.UnspecifiedDataSource)
						{
							dataConnectionUIControl = this.SelectedDataProvider.CreateConnectionUIControl();
						}
						else
						{
							dataConnectionUIControl = this.SelectedDataProvider.CreateConnectionUIControl(this.SelectedDataSource);
						}
						userControl = (dataConnectionUIControl as UserControl);
						if (userControl == null)
						{
							IContainerControl containerControl = dataConnectionUIControl as IContainerControl;
							if (containerControl != null)
							{
								userControl = (containerControl.ActiveControl as UserControl);
							}
						}
					}
					catch
					{
					}
					if (dataConnectionUIControl == null || userControl == null)
					{
						dataConnectionUIControl = new DataConnectionDialog.#F4c();
						userControl = (dataConnectionUIControl as UserControl);
					}
					userControl.Location = Point.Empty;
					userControl.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
					userControl.AutoSize = false;
					try
					{
						dataConnectionUIControl.Initialize(this.ConnectionProperties);
					}
					catch
					{
					}
					this.#DTc[this.SelectedDataSource][this.SelectedDataProvider] = dataConnectionUIControl;
					this.#sS.Add(userControl);
				}
				UserControl userControl2 = this.#DTc[this.SelectedDataSource][this.SelectedDataProvider] as UserControl;
				if (userControl2 == null)
				{
					userControl2 = ((this.#DTc[this.SelectedDataSource][this.SelectedDataProvider] as IContainerControl).ActiveControl as UserControl);
				}
				return userControl2;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00005008 File Offset: 0x00004008
		internal IDataConnectionProperties ConnectionProperties
		{
			get
			{
				if (this.SelectedDataProvider == null)
				{
					return null;
				}
				if (!this.#ETc.ContainsKey(this.SelectedDataSource))
				{
					this.#ETc[this.SelectedDataSource] = new Dictionary<DataProvider, IDataConnectionProperties>();
				}
				if (!this.#ETc[this.SelectedDataSource].ContainsKey(this.SelectedDataProvider))
				{
					IDataConnectionProperties dataConnectionProperties;
					if (this.SelectedDataSource == this.UnspecifiedDataSource)
					{
						dataConnectionProperties = this.SelectedDataProvider.CreateConnectionProperties();
					}
					else
					{
						dataConnectionProperties = this.SelectedDataProvider.CreateConnectionProperties(this.SelectedDataSource);
					}
					if (dataConnectionProperties == null)
					{
						dataConnectionProperties = new DataConnectionDialog.#H4c();
					}
					dataConnectionProperties.PropertyChanged += this.#2Tc;
					this.#ETc[this.SelectedDataSource][this.SelectedDataProvider] = dataConnectionProperties;
				}
				return this.#ETc[this.SelectedDataSource][this.SelectedDataProvider];
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000050EC File Offset: 0x000040EC
		protected override void OnLoad(EventArgs e)
		{
			if (!this.#qTc)
			{
				throw new NotSupportedException(#cTc.#Mk.DataConnectionDialog_ShowDialogNotSupported);
			}
			this.#WTc();
			this.#XTc();
			this.#ZTc();
			this.#2Tc(this, EventArgs.Empty);
			base.OnLoad(e);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00005128 File Offset: 0x00004128
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			if (this.ConnectionUIControl != null)
			{
				this.ConnectionUIControl.Focus();
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00005148 File Offset: 0x00004148
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			this.#GTc.Anchor &= ~AnchorStyles.Right;
			this.#KTc.Anchor &= ~(AnchorStyles.Bottom | AnchorStyles.Right);
			this.#LTc.Anchor |= (AnchorStyles.Top | AnchorStyles.Left);
			this.#LTc.Anchor &= ~(AnchorStyles.Bottom | AnchorStyles.Right);
			this.#MTc.Anchor |= AnchorStyles.Top;
			this.#MTc.Anchor &= ~(AnchorStyles.Bottom | AnchorStyles.Right);
			this.#NTc.Anchor |= AnchorStyles.Top;
			this.#NTc.Anchor &= ~AnchorStyles.Bottom;
			this.#7Sc.Anchor |= (AnchorStyles.Top | AnchorStyles.Left);
			this.#7Sc.Anchor &= ~(AnchorStyles.Bottom | AnchorStyles.Right);
			Size size = new Size(this.#KTc.Right + this.#KTc.Margin.Right + base.Padding.Right, this.#7Sc.Bottom + this.#7Sc.Margin.Bottom + base.Padding.Bottom);
			size = this.SizeFromClientSize(size);
			Size sz = base.Size - size;
			this.MinimumSize -= sz;
			base.Size -= sz;
			this.#7Sc.Anchor |= (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#7Sc.Anchor &= ~(AnchorStyles.Top | AnchorStyles.Left);
			this.#NTc.Anchor |= AnchorStyles.Bottom;
			this.#NTc.Anchor &= ~AnchorStyles.Top;
			this.#MTc.Anchor |= (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#MTc.Anchor &= ~AnchorStyles.Top;
			this.#LTc.Anchor |= (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#LTc.Anchor &= ~(AnchorStyles.Top | AnchorStyles.Left);
			this.#KTc.Anchor |= (AnchorStyles.Bottom | AnchorStyles.Right);
			this.#GTc.Anchor |= AnchorStyles.Right;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00005384 File Offset: 0x00004384
		protected virtual void OnVerifySettings(EventArgs e)
		{
			if (this.#mTc != null)
			{
				this.#mTc(this, e);
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000539C File Offset: 0x0000439C
		protected internal virtual void OnContextHelpRequested(ContextHelpEventArgs e)
		{
			if (this.#nTc != null)
			{
				this.#nTc(this, e);
			}
			if (!e.Handled)
			{
				this.#Z9b(null, #cTc.#Mk.DataConnectionDialog_NoHelpAvailable);
				e.Handled = true;
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000053D0 File Offset: 0x000043D0
		protected override void OnHelpRequested(HelpEventArgs hevent)
		{
			Control control = this;
			ContainerControl containerControl;
			while ((containerControl = (control as ContainerControl)) != null && containerControl != this.ConnectionUIControl && containerControl.ActiveControl != null)
			{
				control = containerControl.ActiveControl;
			}
			DataConnectionDialogContext context = DataConnectionDialogContext.Main;
			if (control == this.#HTc)
			{
				context = DataConnectionDialogContext.MainDataSourceTextBox;
			}
			if (control == this.#JTc)
			{
				context = DataConnectionDialogContext.MainChangeDataSourceButton;
			}
			if (control == this.ConnectionUIControl)
			{
				context = DataConnectionDialogContext.MainConnectionUIControl;
				if (this.ConnectionUIControl is SqlConnectionUIControl)
				{
					context = DataConnectionDialogContext.MainSqlConnectionUIControl;
				}
				if (this.ConnectionUIControl is SqlFileConnectionUIControl)
				{
					context = DataConnectionDialogContext.MainSqlFileConnectionUIControl;
				}
				if (this.ConnectionUIControl is OracleConnectionUIControl)
				{
					context = DataConnectionDialogContext.MainOracleConnectionUIControl;
				}
				if (this.ConnectionUIControl is AccessConnectionUIControl)
				{
					context = DataConnectionDialogContext.MainAccessConnectionUIControl;
				}
				if (this.ConnectionUIControl is OleDBConnectionUIControl)
				{
					context = DataConnectionDialogContext.MainOleDBConnectionUIControl;
				}
				if (this.ConnectionUIControl is OdbcConnectionUIControl)
				{
					context = DataConnectionDialogContext.MainOdbcConnectionUIControl;
				}
				if (this.ConnectionUIControl is DataConnectionDialog.#F4c)
				{
					context = DataConnectionDialogContext.MainGenericConnectionUIControl;
				}
			}
			if (control == this.#LTc)
			{
				context = DataConnectionDialogContext.MainAdvancedButton;
			}
			if (control == this.#NTc)
			{
				context = DataConnectionDialogContext.MainTestConnectionButton;
			}
			if (control == this.#OTc)
			{
				context = DataConnectionDialogContext.MainAcceptButton;
			}
			if (control == this.#F9b)
			{
				context = DataConnectionDialogContext.MainCancelButton;
			}
			ContextHelpEventArgs contextHelpEventArgs = new ContextHelpEventArgs(context, hevent.MousePos);
			this.OnContextHelpRequested(contextHelpEventArgs);
			hevent.Handled = contextHelpEventArgs.Handled;
			if (!contextHelpEventArgs.Handled)
			{
				base.OnHelpRequested(hevent);
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000552C File Offset: 0x0000452C
		protected virtual void OnDialogException(ThreadExceptionEventArgs e)
		{
			if (this.#oTc != null)
			{
				this.#oTc(this, e);
				return;
			}
			this.#Z9b(null, e.Exception);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00005554 File Offset: 0x00004554
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (base.DialogResult == DialogResult.OK)
			{
				try
				{
					this.OnVerifySettings(EventArgs.Empty);
				}
				catch (Exception ex)
				{
					ExternalException ex2 = ex as ExternalException;
					if (ex2 == null || ex2.ErrorCode != -2147217842)
					{
						this.#Z9b(null, ex);
					}
					e.Cancel = true;
				}
			}
			base.OnFormClosing(e);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000055B8 File Offset: 0x000045B8
		[DebuggerStepThrough]
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message m)
		{
			if (this.#sTc && #JVc.#CVc(ref m))
			{
				#JVc.#HVc(this, ref m);
				base.DefWndProc(ref m);
				return;
			}
			base.WndProc(ref m);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000055E0 File Offset: 0x000045E0
		internal void #RTc(DataSource #am)
		{
			this.#UTc(#am, false);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000055EC File Offset: 0x000045EC
		internal void #STc(DataSource #TTc, DataProvider #am)
		{
			this.SetSelectedDataProvider(#TTc, #am, false);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000055F8 File Offset: 0x000045F8
		private void #UTc(DataSource #am, bool #VTc)
		{
			if (!#VTc && this.#yTc.Count == 1 && this.#ATc != #am)
			{
				IEnumerator<DataSource> enumerator = this.#yTc.GetEnumerator();
				enumerator.MoveNext();
				if (#am != enumerator.Current)
				{
					throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_CannotChangeSingleDataSource);
				}
			}
			if (this.#ATc != #am)
			{
				if (#am != null)
				{
					if (!this.#yTc.Contains(#am))
					{
						throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_DataSourceNotFound);
					}
					this.#ATc = #am;
					int count = this.#ATc.Providers.Count;
					if (count != 0)
					{
						if (count != 1)
						{
							DataProvider #am2 = this.#ATc.DefaultProvider;
							if (this.#BTc.ContainsKey(this.#ATc))
							{
								#am2 = this.#BTc[this.#ATc];
							}
							this.SetSelectedDataProvider(this.#ATc, #am2, #VTc);
						}
						else
						{
							IEnumerator<DataProvider> enumerator2 = this.#ATc.Providers.GetEnumerator();
							enumerator2.MoveNext();
							this.SetSelectedDataProvider(this.#ATc, enumerator2.Current, true);
						}
					}
					else
					{
						this.SetSelectedDataProvider(this.#ATc, null, #VTc);
					}
				}
				else
				{
					this.#ATc = null;
				}
				if (this.#qTc)
				{
					this.#WTc();
				}
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00005728 File Offset: 0x00004728
		private void SetSelectedDataProvider(DataSource #TTc, DataProvider #am, bool #VTc)
		{
			if (!#VTc && #TTc.Providers.Count == 1 && ((this.#BTc.ContainsKey(#TTc) && this.#BTc[#TTc] != #am) || (!this.#BTc.ContainsKey(#TTc) && #am != null)))
			{
				IEnumerator<DataProvider> enumerator = #TTc.Providers.GetEnumerator();
				enumerator.MoveNext();
				if (#am != enumerator.Current)
				{
					throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_CannotChangeSingleDataProvider);
				}
			}
			if ((this.#BTc.ContainsKey(#TTc) && this.#BTc[#TTc] != #am) || (!this.#BTc.ContainsKey(#TTc) && #am != null))
			{
				if (#am != null)
				{
					if (!#TTc.Providers.Contains(#am))
					{
						throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_DataSourceNoAssociation);
					}
					this.#BTc[#TTc] = #am;
				}
				else if (this.#BTc.ContainsKey(#TTc))
				{
					this.#BTc.Remove(#TTc);
				}
				if (this.#qTc)
				{
					this.#ZTc();
				}
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00005820 File Offset: 0x00004820
		private void #WTc()
		{
			if (this.SelectedDataSource != null)
			{
				if (this.SelectedDataSource == this.UnspecifiedDataSource)
				{
					if (this.SelectedDataProvider != null)
					{
						this.#HTc.Text = this.SelectedDataProvider.DisplayName;
					}
					else
					{
						this.#HTc.Text = null;
					}
					this.#ITc.SetToolTip(this.#HTc, null);
				}
				else
				{
					this.#HTc.Text = this.SelectedDataSource.DisplayName;
					if (this.SelectedDataProvider != null)
					{
						if (this.SelectedDataProvider.ShortDisplayName != null)
						{
							this.#HTc.Text = string.Format(#cTc.#Mk.DataConnectionDialog_DataSourceWithShortProvider, this.#HTc.Text, this.SelectedDataProvider.ShortDisplayName);
						}
						this.#ITc.SetToolTip(this.#HTc, this.SelectedDataProvider.DisplayName);
					}
					else
					{
						this.#ITc.SetToolTip(this.#HTc, null);
					}
				}
			}
			else
			{
				this.#HTc.Text = null;
				this.#ITc.SetToolTip(this.#HTc, null);
			}
			this.#HTc.Select(0, 0);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000593C File Offset: 0x0000493C
		private void #XTc()
		{
			this.#JTc.Enabled = (this.DataSources.Count > 1 || this.SelectedDataSource.Providers.Count > 1);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00005970 File Offset: 0x00004970
		private void #YTc(object #sm, EventArgs #tm)
		{
			base.DialogResult = DialogResult.Ignore;
			base.Close();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00005980 File Offset: 0x00004980
		private void #ZTc()
		{
			if (this.#KTc.Controls.Count == 0)
			{
				this.#pTc = this.#KTc.Size;
			}
			if ((this.#KTc.Controls.Count == 0 && this.ConnectionUIControl != null) || (this.#KTc.Controls.Count > 0 && this.ConnectionUIControl != this.#KTc.Controls[0]))
			{
				this.#KTc.Controls.Clear();
				if (this.ConnectionUIControl != null && this.ConnectionUIControl.PreferredSize.Width > 0 && this.ConnectionUIControl.PreferredSize.Height > 0)
				{
					this.#KTc.Controls.Add(this.ConnectionUIControl);
					this.MinimumSize = Size.Empty;
					Size size = this.#KTc.Size;
					this.#KTc.Size = this.#pTc;
					Size preferredSize = this.ConnectionUIControl.PreferredSize;
					this.#KTc.Size = size;
					int num = this.#pTc.Width - (base.Width - base.ClientSize.Width) - base.Padding.Left - this.#KTc.Margin.Left - this.#KTc.Margin.Right - base.Padding.Right;
					num = Math.Max(num, this.#NTc.Width + this.#NTc.Margin.Right + this.#7Sc.Margin.Left + this.#7Sc.Width + this.#7Sc.Margin.Right);
					preferredSize.Width = Math.Max(preferredSize.Width, num);
					base.Size += preferredSize - this.#KTc.Size;
					if (this.#KTc.Bottom == this.#LTc.Top)
					{
						this.#KTc.Margin = new Padding(this.#KTc.Margin.Left, this.#GTc.Margin.Bottom, this.#KTc.Margin.Right, this.#LTc.Margin.Top);
						base.Height += this.#KTc.Margin.Bottom + this.#LTc.Margin.Top;
						this.#KTc.Height -= this.#KTc.Margin.Bottom + this.#LTc.Margin.Top;
					}
					Size size2 = SystemInformation.PrimaryMonitorMaximizedWindowSize - SystemInformation.FrameBorderSize - SystemInformation.FrameBorderSize;
					if (base.Width > size2.Width)
					{
						base.Width = size2.Width;
						if (base.Height + SystemInformation.HorizontalScrollBarHeight <= size2.Height)
						{
							base.Height += SystemInformation.HorizontalScrollBarHeight;
						}
					}
					if (base.Height > size2.Height)
					{
						if (base.Width + SystemInformation.VerticalScrollBarWidth <= size2.Width)
						{
							base.Width += SystemInformation.VerticalScrollBarWidth;
						}
						base.Height = size2.Height;
					}
					this.MinimumSize = base.Size;
					this.#LTc.Enabled = !(this.ConnectionUIControl is DataConnectionDialog.#F4c);
				}
				else
				{
					this.MinimumSize = Size.Empty;
					if (this.#KTc.Bottom != this.#LTc.Top)
					{
						this.#KTc.Height += this.#KTc.Margin.Bottom + this.#LTc.Margin.Top;
						base.Height -= this.#KTc.Margin.Bottom + this.#LTc.Margin.Top;
						this.#KTc.Margin = new Padding(this.#KTc.Margin.Left, 0, this.#KTc.Margin.Right, 0);
					}
					base.Size -= this.#KTc.Size - new Size(300, 0);
					this.MinimumSize = base.Size;
					this.#LTc.Enabled = true;
				}
			}
			if (this.ConnectionUIControl != null)
			{
				try
				{
					this.#DTc[this.SelectedDataSource][this.SelectedDataProvider].LoadProperties();
				}
				catch
				{
				}
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00005EAC File Offset: 0x00004EAC
		private void #0Tc(object #sm, EventArgs #tm)
		{
			if (this.#KTc.Controls.Count > 0)
			{
				DockStyle dock = DockStyle.None;
				Size size = this.#KTc.Size;
				Size minimumSize = this.#KTc.Controls[0].MinimumSize;
				if (size.Width >= minimumSize.Width && size.Height >= minimumSize.Height)
				{
					dock = DockStyle.Fill;
				}
				if (size.Width - SystemInformation.VerticalScrollBarWidth >= minimumSize.Width && size.Height < minimumSize.Height)
				{
					dock = DockStyle.Top;
				}
				if (size.Width < minimumSize.Width && size.Height - SystemInformation.HorizontalScrollBarHeight >= minimumSize.Height)
				{
					dock = DockStyle.Left;
				}
				this.#KTc.Controls[0].Dock = dock;
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00005F80 File Offset: 0x00004F80
		private void #1Tc(object #sm, EventArgs #tm)
		{
			#lTc #lTc = new #lTc(this.ConnectionProperties, this);
			DialogResult dialogResult = DialogResult.None;
			try
			{
				if (base.Container != null)
				{
					base.Container.Add(#lTc);
				}
				dialogResult = #lTc.ShowDialog(this);
			}
			finally
			{
				if (base.Container != null)
				{
					base.Container.Remove(#lTc);
				}
				#lTc.Dispose();
			}
			if (dialogResult == DialogResult.OK && this.ConnectionUIControl != null)
			{
				try
				{
					this.#DTc[this.SelectedDataSource][this.SelectedDataProvider].LoadProperties();
				}
				catch
				{
				}
				this.#2Tc(this, EventArgs.Empty);
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00006030 File Offset: 0x00005030
		private void TestConnection(object #sm, EventArgs #tm)
		{
			Cursor value = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				this.ConnectionProperties.Test();
			}
			catch (Exception #EF)
			{
				Cursor.Current = value;
				this.#Z9b(#cTc.#Mk.DataConnectionDialog_TestResults, #EF);
				return;
			}
			Cursor.Current = value;
			this.#PPb(#cTc.#Mk.DataConnectionDialog_TestResults, #cTc.#Mk.DataConnectionDialog_TestConnectionSucceeded);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00006098 File Offset: 0x00005098
		private void #2Tc(object #sm, EventArgs #tm)
		{
			try
			{
				this.#OTc.Enabled = (this.ConnectionProperties != null && this.ConnectionProperties.IsComplete);
			}
			catch
			{
				this.#OTc.Enabled = true;
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000060E8 File Offset: 0x000050E8
		private void #3Tc(object #sm, EventArgs #tm)
		{
			this.#OTc.Focus();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000060F8 File Offset: 0x000050F8
		private void #4Tc(object #sm, PaintEventArgs #tm)
		{
			Graphics graphics = #tm.Graphics;
			Pen pen = new Pen(ControlPaint.Dark(this.BackColor, 0f));
			Pen pen2 = new Pen(ControlPaint.Light(this.BackColor, 1f));
			int width = this.#MTc.Width;
			graphics.DrawLine(pen, 0, 0, width, 0);
			graphics.DrawLine(pen2, 0, 1, width, 1);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000615C File Offset: 0x0000515C
		private void #5Tc(object #sm, ThreadExceptionEventArgs #tm)
		{
			this.OnDialogException(#tm);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00006168 File Offset: 0x00005168
		private void #PPb(string #dF, string #5l)
		{
			IUIService iuiservice = this.GetService(typeof(IUIService)) as IUIService;
			if (iuiservice != null)
			{
				iuiservice.ShowMessage(#5l);
				return;
			}
			#jYc.Show(#dF, #5l, MessageBoxIcon.Asterisk);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000061A0 File Offset: 0x000051A0
		private void #Z9b(string #dF, Exception #EF)
		{
			IUIService iuiservice = this.GetService(typeof(IUIService)) as IUIService;
			if (iuiservice != null)
			{
				iuiservice.ShowError(#EF);
				return;
			}
			#jYc.Show(#dF, #EF.Message, MessageBoxIcon.Exclamation);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000061E0 File Offset: 0x000051E0
		private void #Z9b(string #dF, string #5l)
		{
			IUIService iuiservice = this.GetService(typeof(IUIService)) as IUIService;
			if (iuiservice != null)
			{
				iuiservice.ShowError(#5l);
				return;
			}
			#jYc.Show(#dF, #5l, MessageBoxIcon.Exclamation);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00006238 File Offset: 0x00005238
		private void #lq()
		{
			this.#sS = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(DataConnectionDialog));
			this.#FTc = new Label();
			this.#GTc = new TableLayoutPanel();
			this.#HTc = new TextBox();
			this.#JTc = new Button();
			this.#KTc = new ContainerControl();
			this.#LTc = new Button();
			this.#MTc = new Panel();
			this.#NTc = new Button();
			this.#7Sc = new TableLayoutPanel();
			this.#OTc = new Button();
			this.#F9b = new Button();
			this.#ITc = new ToolTip(this.#sS);
			this.#GTc.SuspendLayout();
			this.#7Sc.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.#FTc, #Nk.#Mk.#Lk(981));
			this.#FTc.FlatStyle = FlatStyle.System;
			this.#FTc.Name = #Nk.#Mk.#Lk(981);
			componentResourceManager.ApplyResources(this.#GTc, #Nk.#Mk.#Lk(1019));
			this.#GTc.Controls.Add(this.#HTc, 0, 0);
			this.#GTc.Controls.Add(this.#JTc, 1, 0);
			this.#GTc.Name = #Nk.#Mk.#Lk(1019);
			componentResourceManager.ApplyResources(this.#HTc, #Nk.#Mk.#Lk(1056));
			this.#HTc.Name = #Nk.#Mk.#Lk(1056);
			this.#HTc.ReadOnly = true;
			componentResourceManager.ApplyResources(this.#JTc, #Nk.#Mk.#Lk(1081));
			this.#JTc.MinimumSize = new Size(75, 23);
			this.#JTc.Name = #Nk.#Mk.#Lk(1081);
			this.#JTc.Click += this.#YTc;
			componentResourceManager.ApplyResources(this.#KTc, #Nk.#Mk.#Lk(1114));
			this.#KTc.Name = #Nk.#Mk.#Lk(1114);
			this.#KTc.SizeChanged += this.#0Tc;
			componentResourceManager.ApplyResources(this.#LTc, #Nk.#Mk.#Lk(1139));
			this.#LTc.MinimumSize = new Size(81, 23);
			this.#LTc.Name = #Nk.#Mk.#Lk(1139);
			this.#LTc.Click += this.#1Tc;
			componentResourceManager.ApplyResources(this.#MTc, #Nk.#Mk.#Lk(1160));
			this.#MTc.Name = #Nk.#Mk.#Lk(1160);
			this.#MTc.Paint += this.#4Tc;
			componentResourceManager.ApplyResources(this.#NTc, #Nk.#Mk.#Lk(1181));
			this.#NTc.MinimumSize = new Size(101, 23);
			this.#NTc.Name = #Nk.#Mk.#Lk(1181);
			this.#NTc.Click += this.TestConnection;
			componentResourceManager.ApplyResources(this.#7Sc, #Nk.#Mk.#Lk(686));
			this.#7Sc.Controls.Add(this.#OTc, 0, 0);
			this.#7Sc.Controls.Add(this.#F9b, 1, 0);
			this.#7Sc.Name = #Nk.#Mk.#Lk(686);
			componentResourceManager.ApplyResources(this.#OTc, #Nk.#Mk.#Lk(1210));
			this.#OTc.DialogResult = DialogResult.OK;
			this.#OTc.MinimumSize = new Size(75, 23);
			this.#OTc.Name = #Nk.#Mk.#Lk(1210);
			this.#OTc.Click += this.#3Tc;
			componentResourceManager.ApplyResources(this.#F9b, #Nk.#Mk.#Lk(732));
			this.#F9b.DialogResult = DialogResult.Cancel;
			this.#F9b.MinimumSize = new Size(75, 23);
			this.#F9b.Name = #Nk.#Mk.#Lk(732);
			base.AcceptButton = this.#OTc;
			componentResourceManager.ApplyResources(this, #Nk.#Mk.#Lk(598));
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.#F9b;
			base.Controls.Add(this.#7Sc);
			base.Controls.Add(this.#NTc);
			base.Controls.Add(this.#MTc);
			base.Controls.Add(this.#LTc);
			base.Controls.Add(this.#KTc);
			base.Controls.Add(this.#GTc);
			base.Controls.Add(this.#FTc);
			base.HelpButton = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = #Nk.#Mk.#Lk(1227);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.#GTc.ResumeLayout(false);
			this.#GTc.PerformLayout();
			this.#7Sc.ResumeLayout(false);
			this.#7Sc.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400002C RID: 44
		[CompilerGenerated]
		private EventHandler #mTc;

		// Token: 0x0400002D RID: 45
		[CompilerGenerated]
		private EventHandler<ContextHelpEventArgs> #nTc;

		// Token: 0x0400002E RID: 46
		[CompilerGenerated]
		private ThreadExceptionEventHandler #oTc;

		// Token: 0x0400002F RID: 47
		private Size #pTc;

		// Token: 0x04000030 RID: 48
		private bool #qTc;

		// Token: 0x04000031 RID: 49
		private Label #rTc;

		// Token: 0x04000032 RID: 50
		private bool #sTc = true;

		// Token: 0x04000033 RID: 51
		private string #tTc;

		// Token: 0x04000034 RID: 52
		private string #uTc = string.Empty;

		// Token: 0x04000035 RID: 53
		private string #vTc;

		// Token: 0x04000036 RID: 54
		private string #wTc;

		// Token: 0x04000037 RID: 55
		private string #xTc = string.Empty;

		// Token: 0x04000038 RID: 56
		private ICollection<DataSource> #yTc;

		// Token: 0x04000039 RID: 57
		private DataSource #zTc = DataSource.#FUc();

		// Token: 0x0400003A RID: 58
		private DataSource #ATc;

		// Token: 0x0400003B RID: 59
		private IDictionary<DataSource, DataProvider> #BTc = new Dictionary<DataSource, DataProvider>();

		// Token: 0x0400003C RID: 60
		private bool #CTc = true;

		// Token: 0x0400003D RID: 61
		private IDictionary<DataSource, IDictionary<DataProvider, IDataConnectionUIControl>> #DTc = new Dictionary<DataSource, IDictionary<DataProvider, IDataConnectionUIControl>>();

		// Token: 0x0400003E RID: 62
		private IDictionary<DataSource, IDictionary<DataProvider, IDataConnectionProperties>> #ETc = new Dictionary<DataSource, IDictionary<DataProvider, IDataConnectionProperties>>();

		// Token: 0x04000040 RID: 64
		private Label #FTc;

		// Token: 0x04000041 RID: 65
		private TableLayoutPanel #GTc;

		// Token: 0x04000042 RID: 66
		private TextBox #HTc;

		// Token: 0x04000043 RID: 67
		private ToolTip #ITc;

		// Token: 0x04000044 RID: 68
		private Button #JTc;

		// Token: 0x04000045 RID: 69
		private ContainerControl #KTc;

		// Token: 0x04000046 RID: 70
		private Button #LTc;

		// Token: 0x04000047 RID: 71
		private Panel #MTc;

		// Token: 0x04000048 RID: 72
		private Button #NTc;

		// Token: 0x04000049 RID: 73
		private TableLayoutPanel #7Sc;

		// Token: 0x0400004A RID: 74
		private Button #OTc;

		// Token: 0x0400004B RID: 75
		private Button #F9b;

		// Token: 0x0200000D RID: 13
		private sealed class #C4c : ICollection<DataSource>, IEnumerable<DataSource>, IEnumerable
		{
			// Token: 0x060000BE RID: 190 RVA: 0x00006774 File Offset: 0x00005774
			public #C4c(DataConnectionDialog dialog)
			{
				this.#A4c = dialog;
			}

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x060000BF RID: 191 RVA: 0x00006790 File Offset: 0x00005790
			public int Count
			{
				get
				{
					return this.#jqb.Count;
				}
			}

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x060000C0 RID: 192 RVA: 0x000067A0 File Offset: 0x000057A0
			public bool IsReadOnly
			{
				get
				{
					return this.#A4c.#qTc;
				}
			}

			// Token: 0x060000C1 RID: 193 RVA: 0x000067B0 File Offset: 0x000057B0
			public void Add(DataSource item)
			{
				if (item == null)
				{
					throw new ArgumentNullException(#Nk.#Mk.#Lk(19179));
				}
				if (this.#A4c.#qTc)
				{
					throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_CannotModifyState);
				}
				if (!this.#jqb.Contains(item))
				{
					this.#jqb.Add(item);
				}
			}

			// Token: 0x060000C2 RID: 194 RVA: 0x00006804 File Offset: 0x00005804
			public bool Contains(DataSource #Ul)
			{
				return this.#jqb.Contains(#Ul);
			}

			// Token: 0x060000C3 RID: 195 RVA: 0x00006814 File Offset: 0x00005814
			public bool Remove(DataSource #Ul)
			{
				if (this.#A4c.#qTc)
				{
					throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_CannotModifyState);
				}
				bool result = this.#jqb.Remove(#Ul);
				if (#Ul == this.#A4c.SelectedDataSource)
				{
					this.#A4c.#UTc(null, true);
				}
				return result;
			}

			// Token: 0x060000C4 RID: 196 RVA: 0x00006864 File Offset: 0x00005864
			public void Clear()
			{
				if (this.#A4c.#qTc)
				{
					throw new InvalidOperationException(#cTc.#Mk.DataConnectionDialog_CannotModifyState);
				}
				this.#jqb.Clear();
				this.#A4c.#UTc(null, true);
			}

			// Token: 0x060000C5 RID: 197 RVA: 0x00006898 File Offset: 0x00005898
			public void #B4c(DataSource[] #Xl, int #Yl)
			{
				this.#jqb.CopyTo(#Xl, #Yl);
			}

			// Token: 0x060000C6 RID: 198 RVA: 0x000068A8 File Offset: 0x000058A8
			public IEnumerator<DataSource> GetEnumerator()
			{
				return this.#jqb.GetEnumerator();
			}

			// Token: 0x060000C7 RID: 199 RVA: 0x000068BC File Offset: 0x000058BC
			IEnumerator IEnumerable.#Sl()
			{
				return this.#jqb.GetEnumerator();
			}

			// Token: 0x060000C8 RID: 200 RVA: 0x000068D0 File Offset: 0x000058D0
			// Note: this type is marked as 'beforefieldinit'.
			static #C4c()
			{
				bool flag = false;
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				if (DataConnectionDialog.#C4c.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Nk.#Mk.#Lk(774)))
				{
					return;
				}
				throw new SecurityException(#Nk.#Mk.#Lk(799));
			}

			// Token: 0x060000C9 RID: 201
			[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
			[return: MarshalAs(UnmanagedType.Bool)]
			private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

			// Token: 0x0400004C RID: 76
			private List<DataSource> #jqb = new List<DataSource>();

			// Token: 0x0400004D RID: 77
			private DataConnectionDialog #A4c;
		}

		// Token: 0x0200000E RID: 14
		private sealed class #F4c : UserControl, IDataConnectionUIControl
		{
			// Token: 0x060000CA RID: 202 RVA: 0x00006924 File Offset: 0x00005924
			public #F4c()
			{
				this.#hTc = new #lTc.#z4c();
				base.SuspendLayout();
				this.#hTc.CommandsVisibleIfAvailable = true;
				this.#hTc.Dock = DockStyle.Fill;
				this.#hTc.Location = Point.Empty;
				this.#hTc.Margin = new Padding(0);
				this.#hTc.Name = #Nk.#Mk.#Lk(853);
				this.#hTc.TabIndex = 0;
				base.Controls.Add(this.#hTc);
				base.Name = #Nk.#Mk.#Lk(19188);
				base.ResumeLayout(false);
				base.PerformLayout();
			}

			// Token: 0x060000CB RID: 203 RVA: 0x000069D0 File Offset: 0x000059D0
			public void Initialize(IDataConnectionProperties #E4c)
			{
				this.#D4c = #E4c;
			}

			// Token: 0x060000CC RID: 204 RVA: 0x000069DC File Offset: 0x000059DC
			public void LoadProperties()
			{
				this.#hTc.SelectedObject = this.#D4c;
			}

			// Token: 0x060000CD RID: 205 RVA: 0x000069F0 File Offset: 0x000059F0
			public override Size GetPreferredSize(Size #qO)
			{
				return this.#hTc.GetPreferredSize(#qO);
			}

			// Token: 0x0400004E RID: 78
			private IDataConnectionProperties #D4c;

			// Token: 0x0400004F RID: 79
			private #lTc.#z4c #hTc;
		}

		// Token: 0x0200000F RID: 15
		private sealed class #H4c : IDataConnectionProperties
		{
			// Token: 0x060000CF RID: 207 RVA: 0x00006A08 File Offset: 0x00005A08
			public void Reset()
			{
				this.#G4c = string.Empty;
			}

			// Token: 0x060000D0 RID: 208 RVA: 0x00006A18 File Offset: 0x00005A18
			public void Parse(string #lfb)
			{
				this.#G4c = #lfb;
				if (this.#ml != null)
				{
					this.#ml(this, EventArgs.Empty);
				}
			}

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x060000D1 RID: 209 RVA: 0x00006A3C File Offset: 0x00005A3C
			[Browsable(false)]
			public bool IsExtensible
			{
				get
				{
					return false;
				}
			}

			// Token: 0x060000D2 RID: 210 RVA: 0x00006A40 File Offset: 0x00005A40
			public void Add(string #Ekb)
			{
				throw new NotImplementedException();
			}

			// Token: 0x060000D3 RID: 211 RVA: 0x00006A48 File Offset: 0x00005A48
			public bool Contains(string #Ekb)
			{
				return #Ekb == #Nk.#Mk.#Lk(12228);
			}

			// Token: 0x17000026 RID: 38
			public object this[string #Ekb]
			{
				get
				{
					if (#Ekb == #Nk.#Mk.#Lk(12228))
					{
						return this.ConnectionString;
					}
					return null;
				}
				set
				{
					if (#Ekb == #Nk.#Mk.#Lk(12228))
					{
						this.ConnectionString = (value as string);
					}
				}
			}

			// Token: 0x060000D6 RID: 214 RVA: 0x00006A98 File Offset: 0x00005A98
			public void Remove(string #Ekb)
			{
				throw new NotImplementedException();
			}

			// Token: 0x14000006 RID: 6
			// (add) Token: 0x060000D7 RID: 215 RVA: 0x00006AA0 File Offset: 0x00005AA0
			// (remove) Token: 0x060000D8 RID: 216 RVA: 0x00006AD8 File Offset: 0x00005AD8
			public event EventHandler PropertyChanged
			{
				[CompilerGenerated]
				add
				{
					EventHandler eventHandler = this.#ml;
					EventHandler eventHandler2;
					do
					{
						eventHandler2 = eventHandler;
						EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
						eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#ml, value2, eventHandler2);
					}
					while (eventHandler != eventHandler2);
				}
				[CompilerGenerated]
				remove
				{
					EventHandler eventHandler = this.#ml;
					EventHandler eventHandler2;
					do
					{
						eventHandler2 = eventHandler;
						EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
						eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#ml, value2, eventHandler2);
					}
					while (eventHandler != eventHandler2);
				}
			}

			// Token: 0x060000D9 RID: 217 RVA: 0x00006B10 File Offset: 0x00005B10
			public void Reset(string #Ekb)
			{
				this.#G4c = string.Empty;
			}

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x060000DA RID: 218 RVA: 0x00006B20 File Offset: 0x00005B20
			[Browsable(false)]
			public bool IsComplete
			{
				get
				{
					return true;
				}
			}

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x060000DB RID: 219 RVA: 0x00006B24 File Offset: 0x00005B24
			// (set) Token: 0x060000DC RID: 220 RVA: 0x00006B2C File Offset: 0x00005B2C
			public string ConnectionString
			{
				get
				{
					return this.ToFullString();
				}
				set
				{
					this.Parse(value);
				}
			}

			// Token: 0x060000DD RID: 221 RVA: 0x00006B38 File Offset: 0x00005B38
			public void Test()
			{
			}

			// Token: 0x060000DE RID: 222 RVA: 0x00006B3C File Offset: 0x00005B3C
			public string ToFullString()
			{
				return this.#G4c;
			}

			// Token: 0x060000DF RID: 223 RVA: 0x00006B44 File Offset: 0x00005B44
			public string ToDisplayString()
			{
				return this.#G4c;
			}

			// Token: 0x060000E0 RID: 224 RVA: 0x00006B4C File Offset: 0x00005B4C
			// Note: this type is marked as 'beforefieldinit'.
			static #H4c()
			{
				bool flag = false;
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				if (DataConnectionDialog.#H4c.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Nk.#Mk.#Lk(774)))
				{
					return;
				}
				throw new SecurityException(#Nk.#Mk.#Lk(799));
			}

			// Token: 0x060000E1 RID: 225
			[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
			[return: MarshalAs(UnmanagedType.Bool)]
			private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

			// Token: 0x04000050 RID: 80
			[CompilerGenerated]
			private EventHandler #ml;

			// Token: 0x04000051 RID: 81
			private string #G4c;
		}
	}
}
