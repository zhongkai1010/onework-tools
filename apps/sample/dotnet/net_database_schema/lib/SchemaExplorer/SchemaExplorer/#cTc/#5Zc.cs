using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using #Nk;
using Microsoft.Win32;

namespace #cTc
{
	// Token: 0x02000038 RID: 56
	internal sealed class #5Zc : IComponent, IDisposable
	{
		// Token: 0x060002D3 RID: 723 RVA: 0x00012608 File Offset: 0x00011608
		public #5Zc(Form form)
		{
			SystemEvents.UserPreferenceChanged += this.#4Zc;
			this.#Odc = form;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00012628 File Offset: 0x00011628
		protected void #ZZc()
		{
			try
			{
				this.Dispose(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x00012658 File Offset: 0x00011658
		// (set) Token: 0x060002D6 RID: 726 RVA: 0x00012668 File Offset: 0x00011668
		public ISite Site
		{
			get
			{
				return this.#Odc.Site;
			}
			set
			{
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060002D7 RID: 727 RVA: 0x0001266C File Offset: 0x0001166C
		// (remove) Token: 0x060002D8 RID: 728 RVA: 0x000126A4 File Offset: 0x000116A4
		public event EventHandler Disposed
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#ip;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#ip, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#ip;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#ip, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x000126DC File Offset: 0x000116DC
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x000126EC File Offset: 0x000116EC
		private void #4Zc(object #sm, UserPreferenceChangedEventArgs #tm)
		{
			IUIService iuiservice = (this.#Odc.Site != null) ? (this.#Odc.Site.GetService(typeof(IUIService)) as IUIService) : null;
			if (iuiservice != null)
			{
				Font font = iuiservice.Styles[#Mk.#Lk(8244)] as Font;
				if (font != null)
				{
					this.#Odc.Font = font;
				}
			}
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00012758 File Offset: 0x00011758
		private void Dispose(bool #kq)
		{
			if (#kq)
			{
				SystemEvents.UserPreferenceChanged -= this.#4Zc;
				if (this.#ip != null)
				{
					this.#ip(this, EventArgs.Empty);
				}
			}
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00012788 File Offset: 0x00011788
		// Note: this type is marked as 'beforefieldinit'.
		static #5Zc()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (#5Zc.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x060002DD RID: 733
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x04000146 RID: 326
		[CompilerGenerated]
		private EventHandler #ip;

		// Token: 0x04000147 RID: 327
		private Form #Odc;
	}
}
